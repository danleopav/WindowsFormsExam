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
    public partial class FormSearchApartment : Form
    {
        RealEstateContext db = new RealEstateContext();
        List<Apartment> apartments;
        Apartment apartment;
        byte[][] photoSlider;
        int photoNumber = 0;
        string noImagePath = @"C:\Users\danle\source\repos\WindowsFormsExam\WindowsFormsRealEstateAdmin\img\no_photo.png";

        public FormSearchApartment()
        {
            InitializeComponent();
            apartments = db.Apartments.ToList();

            listBoxRealEstate.DataSource = apartments;
            listBoxRealEstate.DisplayMember = "Street";
            listBoxRealEstate.ValueMember = "Id";
        }

        private void listBoxRealEstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            apartment = listBoxRealEstate.SelectedItem as Apartment;
            textBoxStreet.Text = apartment.Street;
            textBoxCity.Text = apartment.City.ToString();
            textBoxPrice.Text = apartment.Price.ToString();
            textBoxRoom.Text = apartment.Rooms.ToString();
            textBoxFloor.Text = apartment.Floor.ToString();
            textBoxDescription.Text = apartment.Description;

            photoNumber = 0;
            labelPhotoNumber.Text = "1/5";

            photoSlider = ImageManip.ByteArrToPhotoSlider(apartment.PhotoSlider);
            pictureBoxSlider.Image = ImageManip.ByteArrayToImage(photoSlider[photoNumber]);
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
                Image img = Image.FromFile(noImagePath);
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
                Image img = Image.FromFile(noImagePath);
                img = ImageManip.ResizeImage(img, new Size(400, 240));
                pictureBoxSlider.Image = img;
            }
        }
    }
}
