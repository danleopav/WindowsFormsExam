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
    public partial class FormClientManager : Form
    {
        ClientContext db = new ClientContext();
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
            Client client = listBoxClients.SelectedItem as Client;
            if (client != null)
            {
                db.Clients.Remove(client);
                clients.Remove(client);
                db.SaveChanges();
            }

            listBoxClients.DataSource = null;
            listBoxClients.DataSource = clients;
            listBoxClients.DisplayMember = "FullName";
            listBoxClients.ValueMember = "Id";
        }
    }
}
