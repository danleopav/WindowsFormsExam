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
    public partial class FormPanel : Form
    {
        public FormPanel()
        {
            InitializeComponent();
        }

        private void buttonManageClients_Click(object sender, EventArgs e)
        {
            FormClientManager clientManager = new FormClientManager();
            clientManager.ShowDialog();
        }

        private void buttonManageApartments_Click(object sender, EventArgs e)
        {
            FormApartmentManager apartmentManager = new FormApartmentManager();
            apartmentManager.ShowDialog();
        }
    }
}
