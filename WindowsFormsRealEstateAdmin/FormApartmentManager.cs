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
    public partial class FormApartmentManager : Form
    {
        RealEstateContext db = new RealEstateContext();
        List<RealEstate> apartments;

        public FormApartmentManager()
        {
            InitializeComponent();
            apartments = db.Apartments.ToList();

            listBoxRealEstate.DataSource = apartments;
            listBoxRealEstate.DisplayMember = "Street";
            listBoxRealEstate.ValueMember = "Id";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormApartmentCreator apartmentManager = new FormApartmentCreator();
            apartmentManager.ShowDialog();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RealEstate apartment = listBoxRealEstate.SelectedItem as RealEstate;
            if (apartment != null)
            {
                apartments.Remove(apartment);
                db.Apartments.Remove(apartment);
                db.SaveChanges();

                listBoxRealEstate.DataSource = null;
                listBoxRealEstate.DataSource = db.Apartments.ToList();
                listBoxRealEstate.DisplayMember = "Street";
                listBoxRealEstate.ValueMember = "Id";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            RealEstate apartment = listBoxRealEstate.SelectedItem as RealEstate;
            if (apartment != null)
            {
                FormApartmentEditor apartmentEditor = new FormApartmentEditor(apartment);
                apartmentEditor.ShowDialog();
            }
        }
    }
}
