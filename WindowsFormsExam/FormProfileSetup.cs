using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    public partial class FormProfileSetup : Form
    {
        RealEstateContext db = new RealEstateContext();
        Client client;
        byte[] profilePhotoByteArr;

        public FormProfileSetup(Client c)
        {
            InitializeComponent();

            textBoxFirstName.Text = c.FirstName;
            textBoxLastName.Text = c.LastName;
            textBoxUsername.Text = c.Username;
            textBoxPassword.Text = c.Password;
            textBoxEmail.Text = c.Email;
            dateTimePickerDateOfBirth.Value = c.DateOfBirth;

            Image img = ImageManip.ByteArrayToImage(c.ProfilePhoto);
            img = ImageManip.ResizeImage(img, new Size(200, 220));
            pictureBoxProfilePhoto.Image = img;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            client = db.Clients.Single(x => x.Id == client.Id);

            if (String.IsNullOrWhiteSpace(textBoxUsername.Text) ||
                String.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                String.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                String.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                String.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Fields can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TimeSpan span = DateTime.Today - dateTimePickerDateOfBirth.Value;
            double dif = span.Days / 365.25;
            if (dif < 18.00)
            {
                MessageBox.Show("you must be at least 18 years old", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ClientAccountValidator.CheckUsername(textBoxUsername.Text, db.Clients))
            {
                MessageBox.Show("This username already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ClientAccountValidator.CheckEmail(textBoxEmail.Text, db.Clients))
            {
                MessageBox.Show("Inputed e-mail currently being used by other user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            client.Username = textBoxUsername.Text;
            client.Password = textBoxPassword.Text;
            client.FirstName = textBoxFirstName.Text;
            client.LastName = textBoxLastName.Text;
            client.FullName = textBoxFirstName.Text + " " + textBoxLastName.Text;
            client.DateOfBirth = dateTimePickerDateOfBirth.Value;

            if (ClientAccountValidator.ValidEmail(textBoxEmail.Text))
            {
                client.Email = textBoxEmail.Text;
            }
            else
            {
                MessageBox.Show("Input correct e-mail address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            client.ProfilePhoto = profilePhotoByteArr; 

            db.SaveChanges();

            textBoxUsername.Text = String.Empty;
            textBoxPassword.Text = String.Empty;
            textBoxFirstName.Text = String.Empty;
            textBoxLastName.Text = String.Empty;
            textBoxEmail.Text = String.Empty;
            profilePhotoByteArr = null;
            pictureBoxProfilePhoto.Image = null;
            dateTimePickerDateOfBirth.Value = DateTime.Today;
        }

        private void buttonAddProfilePhoto_Click(object sender, EventArgs e)
        {
            Image profilePhoto = null;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select profile photo";
            ofd.Filter = "JPG|*.jpg|PNG|*.png";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                profilePhoto = Image.FromFile(ofd.FileName);
                profilePhoto = ImageManip.ResizeImage(profilePhoto, new Size(200, 220));
            }

            profilePhotoByteArr = ImageManip.ImageToByteArray(profilePhoto);
            pictureBoxProfilePhoto.Image = profilePhoto;
        }
    }
}
