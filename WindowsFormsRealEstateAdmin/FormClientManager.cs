using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsExam;

namespace WindowsFormsRealEstateAdmin
{
    public partial class FormClientManager : Form
    {
        AgencyContext db = new AgencyContext();
        List<Client> clients;

        public FormClientManager()
        {
            InitializeComponent();

            clients = db.Clients.ToList();

            listBoxClients.DataSource = clients;
            listBoxClients.DisplayMember = "FullName";
            listBoxClients.ValueMember = "Id";
        }

        private void buttonEvict_Click(object sender, EventArgs e)
        {
            Client selectedClient = listBoxClients.SelectedItem as Client;

            if (selectedClient == null)
            {
                return;
            }

            if (selectedClient.Username == "admin")
            {
                MessageBox.Show("You cant evict admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedClient.Status == Status.Renting ||
                selectedClient.Status == Status.Waiting)
            {
                Client client = db.Clients.Single(x => x.Id == selectedClient.Id);
                client.Status = Status.None;
                RealEstate tmp = db.RealEstate.Single(x => x.Id == selectedClient.Id);
                int realEstateClientId = tmp.Id;
                tmp = db.RealEstate.Single(x => x.Id == realEstateClientId);
                tmp.Client = db.Clients.FirstOrDefault();
                tmp.Status = Status.None;
            }
            else
            {
                MessageBox.Show("This client not renting anything", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
