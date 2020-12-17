using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    public partial class FormRegistration : Form
    {
        ClientContext db = new ClientContext();
        byte[] profilePhotoByteArr;

        public FormRegistration()
        {
            InitializeComponent();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
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

            Client client = new Client()
            {
                Username = textBoxUsername.Text,
                Password = textBoxPassword.Text,
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                FullName = textBoxFirstName.Text + " " + textBoxLastName.Text,
                DateOfBirth = dateTimePickerDateOfBirth.Value
            };

            if (IsEmailValid(textBoxEmail.Text))
            {
                client.Email = textBoxEmail.Text;
            }
            else
            {
                MessageBox.Show("Input correct e-mail address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (profilePhotoByteArr == null)
            {
                MessageBox.Show("Select profile photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            client.ProfilePhoto = profilePhotoByteArr;

            db.Clients.Add(client);
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

        bool IsEmailValid(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;   
            }
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
                profilePhoto = ImageManip.ResizeImage(profilePhoto, new Size(200,220));
            }

            profilePhotoByteArr = ImageManip.ImageToByteArray(profilePhoto);
            pictureBoxProfilePhoto.Image = profilePhoto;  
        }
    }
}
