using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsExam;

namespace WindowsFormsRealEstateAdmin
{
    public partial class FormClientManager : Form
    {
        RealEstateContext db = new RealEstateContext();
        List<Client> clients;

        public FormClientManager()
        {
            InitializeComponent();

            clients = db.Clients.ToList();

            listBoxClients.DataSource = clients;
            listBoxClients.DisplayMember = "FullName";
            listBoxClients.ValueMember = "Id";
        }

        private void buttonBan_Click(object sender, EventArgs e)
        {
            Client selectedClient = listBoxClients.SelectedItem as Client;

            if (selectedClient == null)
            {
                return;
            }

            if (selectedClient.Username == "admin")
            {
                MessageBox.Show("You cant ban admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (selectedClient.Status != Status.Renting)
            {
                Client tmp = db.Clients.Single(x => x.Id == selectedClient.Id);
                db.Clients.Remove(tmp);
                clients.Remove(tmp);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Evict this client before ban", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxClients.DataSource = null;
            listBoxClients.DataSource = clients;
            listBoxClients.DisplayMember = "FullName";
            listBoxClients.ValueMember = "Id";
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            db.Dispose();
            db = new RealEstateContext();

            listBoxClients.DataSource = null;
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

            if (selectedClient.Status == Status.Renting)
            {
                Client tmp = clients.Single(x => x.Id == selectedClient.Id);

                tmp.Status = Status.None;
                tmp.Status = Status.None;

                db.SaveChanges();

                listBoxClients.DataSource = null;
                listBoxClients.DataSource = clients;
                listBoxClients.DisplayMember = "FullName";
                listBoxClients.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("This client not renting anything", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
