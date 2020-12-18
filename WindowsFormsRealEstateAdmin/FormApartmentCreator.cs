using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WindowsFormsExam;

namespace WindowsFormsRealEstateAdmin
{
    public partial class FormApartmentCreator : Form
    {
        RealEstateContext db = new RealEstateContext();
        Apartment apartment;
        Image photo = null;
        OpenFileDialog ofd = new OpenFileDialog();
        byte[][] photoSlider { get; set; } = new byte[5][];
        byte[] photoByteArr;
        string noPhotoPath = @"C:\Users\danle\source\repos\WindowsFormsExam\WindowsFormsRealEstateAdmin\img\no_photo.png";
        int photoNumber = 0;

        public FormApartmentCreator()
        {
            InitializeComponent();
            apartment = new Apartment();

            numericUpDownRooms.DecimalPlaces = 0;
            numericUpDownRooms.Minimum = 1;
            numericUpDownRooms.Maximum = 99;
            numericUpDownFloor.DecimalPlaces = 0;
            numericUpDownFloor.Minimum = 1;
            numericUpDownFloor.Maximum = 99;

            textBoxPrice.Text = "0";
            comboBoxCity.DataSource = Enum.GetValues(typeof(Cities));

            ofd.Title = "Select profile photo";
            ofd.Filter = "JPG|*.jpg|PNG|*.png";
            ofd.Multiselect = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxStreet.Text) ||
                String.IsNullOrWhiteSpace(textBoxPrice.Text) || 
                String.IsNullOrWhiteSpace(textBoxDescription.Text))
            {
                MessageBox.Show("Fields can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                apartment.Street = textBoxStreet.Text;
                apartment.Description = textBoxDescription.Text;
                apartment.Rooms = Convert.ToInt32(numericUpDownRooms.Value);
                apartment.Floor = Convert.ToInt32(numericUpDownFloor.Value);
            }

            Cities city;
            Enum.TryParse(comboBoxCity.SelectedValue.ToString(), out city);
            apartment.City = city;

            if (CheckPrice(textBoxPrice.Text))
            {
                apartment.Price = Convert.ToInt32(textBoxPrice.Text);
            }   
            else
            {
                MessageBox.Show("Invalid price value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            apartment.PhotoSlider = ImageManip.PhotoSliderToByteArray(photoSlider);

            apartment.Client = db.Clients.FirstOrDefault();

            db.Apartments.Add(apartment);
            db.SaveChanges();

            textBoxStreet.Text = String.Empty;
            textBoxDescription.Text = String.Empty;
            textBoxPrice.Text = "0";
            numericUpDownRooms.Value = 1;
            numericUpDownFloor.Value = 1;
            pictureBoxSlider.Image = null;
            photoNumber = 0;
            labelPhotoNumber.Text = "1/5";
            apartment = null;
        }

        public static bool CheckPrice(string price)
        {
            try
            {
                int tmp = Convert.ToInt32(price);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                photo = Image.FromFile(ofd.FileName);
                photo = ImageManip.ResizeImage(photo, new Size(400, 240));
            }

            photoByteArr = ImageManip.ImageToByteArray(photo);
            pictureBoxSlider.Image = photo;

            photoSlider[photoNumber] = photoByteArr;
        }

        private void buttonNext_Click(object sender, EventArgs e)                           
        {
            if (photoNumber + 1 >= 5)
            {
                return;
            }
            photoNumber++;
            labelPhotoNumber.Text = $"{photoNumber + 1}/5";

            if (photoSlider[photoNumber] != null)
            {
                pictureBoxSlider.Image = ImageManip.ByteArrayToImage(photoSlider[photoNumber]);
            }
            else
            {
                Image img = Image.FromFile(noPhotoPath);
                img = ImageManip.ResizeImage(img, new Size(400, 240));
                pictureBoxSlider.Image = img; 
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (photoNumber - 1 < 0)
            {
                return;
            }
            photoNumber--;
            labelPhotoNumber.Text = $"{photoNumber + 1}/5";

            if (photoSlider[photoNumber] != null)
            {
                pictureBoxSlider.Image = ImageManip.ByteArrayToImage(photoSlider[photoNumber]);
            }
            else
            {
                Image img = Image.FromFile(noPhotoPath);
                img = ImageManip.ResizeImage(img, new Size(400, 240));
                pictureBoxSlider.Image = img;
            }
        }

        private void buttonDeletePhoto_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(noPhotoPath);
            img = ImageManip.ResizeImage(img, new Size(400, 240));
            photoSlider[photoNumber] = ImageManip.ImageToByteArray(img);
            pictureBoxSlider.Image = img;
        }
    }
}
