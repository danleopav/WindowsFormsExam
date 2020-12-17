using System;
using System.Windows.Forms;

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
