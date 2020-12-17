using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsExam;

namespace WindowsFormsRealEstateAdmin
{
    public partial class FormApartmentCreator : Form
    {
        ClientContext db = new ClientContext();
        Apartment apartment;
        Image photo = null;
        OpenFileDialog ofd = new OpenFileDialog();
        byte[] photoByteArr;
        int photoNumber = 0;

        public FormApartmentCreator()
        {
            InitializeComponent();
            comboBoxCity.DataSource = Enum.GetValues(typeof(Cities));
            numericUpDownRooms.DecimalPlaces = 0;
            numericUpDownRooms.Minimum = 1;
            numericUpDownRooms.Maximum = 99;
            textBoxPrice.Text = "0";

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
                apartment = new Apartment()
                {
                    Street = textBoxStreet.Text,
                    Description = textBoxDescription.Text,
                    Rooms = Convert.ToInt32(numericUpDownRooms.Value),
                };
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
        }

        bool CheckPrice(string price)
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
            ChooseImage();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (photoNumber + 1 > 5)
            {
                return;
            }
            photoNumber++;
            labelPhotoNumber.Text = $"{photoNumber + 1}/5";

            ChooseImage();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (photoNumber - 1 < 0)
            {
                return;
            }
            photoNumber--;
            labelPhotoNumber.Text = $"{photoNumber - 1}/5";

            ChooseImage();
        }


        void ChooseImage()
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                photo = Image.FromFile(ofd.FileName);
                photo = ImageManip.ResizeImage(photo, new Size(400, 240));
            }

            photoByteArr = ImageManip.ImageToByteArray(photo);
            pictureBoxSlider.Image = photo;

            apartment.Photos[photoNumber] = photoByteArr;
        }
    }
}
