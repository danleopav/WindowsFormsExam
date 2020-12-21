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
        List<RealEstate> realEsate;

        public FormRealEstateManager()
        {
            InitializeComponent();
            realEsate = db.RealEstate.ToList();

            listBoxRealEstate.DataSource = realEsate;
            listBoxRealEstate.DisplayMember = "Street";
            listBoxRealEstate.ValueMember = "Id";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormRealEstateCreator realEstateManager = new FormRealEstateCreator();
            realEstateManager.ShowDialog();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RealEstate tmpRealEstate = listBoxRealEstate.SelectedItem as RealEstate;
            if (tmpRealEstate != null)
            {
                realEsate.Remove(tmpRealEstate);
                db.RealEstate.Remove(tmpRealEstate);
                db.SaveChanges();

                listBoxRealEstate.DataSource = null;
                listBoxRealEstate.DataSource = db.RealEstate.ToList();
                listBoxRealEstate.DisplayMember = "Street";
                listBoxRealEstate.ValueMember = "Id";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            RealEstate tmpRealEstate = listBoxRealEstate.SelectedItem as RealEstate;
            if (tmpRealEstate != null)
            {
                FormRealEstateEditor apartmentEditor = new FormRealEstateEditor(tmpRealEstate);
                apartmentEditor.ShowDialog();
            }
        }
    }
}
