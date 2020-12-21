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
    public partial class FormRealEstateManager : Form
    {
        AgencyContext db = new AgencyContext();
        List<RealEstate> apartments;

        public FormRealEstateManager()
        {
            InitializeComponent();
            apartments = db.RealEstate.ToList();

            listBoxRealEstate.DataSource = apartments;
            listBoxRealEstate.DisplayMember = "Street";
            listBoxRealEstate.ValueMember = "Id";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormRealEstateCreator apartmentManager = new FormRealEstateCreator();
            apartmentManager.ShowDialog();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RealEstate apartment = listBoxRealEstate.SelectedItem as RealEstate;
            if (apartment != null)
            {
                apartments.Remove(apartment);
                db.RealEstate.Remove(apartment);
                db.SaveChanges();

                listBoxRealEstate.DataSource = null;
                listBoxRealEstate.DataSource = db.RealEstate.ToList();
                listBoxRealEstate.DisplayMember = "Street";
                listBoxRealEstate.ValueMember = "Id";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            RealEstate apartment = listBoxRealEstate.SelectedItem as RealEstate;
            if (apartment != null)
            {
                FormRealEstateEditor apartmentEditor = new FormRealEstateEditor(apartment);
                apartmentEditor.ShowDialog();
            }
        }
    }
}
