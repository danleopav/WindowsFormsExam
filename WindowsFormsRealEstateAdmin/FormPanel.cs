using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsExam;

namespace WindowsFormsRealEstateAdmin
{
    public partial class FormPanel : Form
    {
        RealEstateContext db = new RealEstateContext();
        List<Client> pendingClients = new List<Client>();
        int clientId;
        TcpListener server;
        NetworkStream stream = null;

        public FormPanel()
        {
            InitializeComponent();

            server = new TcpListener(IPAddress.Loopback, 8888);
            server.Start();

            Thread thread = new Thread(TcpListen);
            thread.Start();
        }

        void TcpListen()
        {
            while (true)
            {
                TcpClient tcpClient = server.AcceptTcpClient();

                Thread thread = new Thread(() => TcpProcess(tcpClient));
                thread.Start();
            }
        }

        void TcpProcess(TcpClient tcpClient)
        {
            try
            {
                stream = tcpClient.GetStream();
                byte[] buff = new byte[256];
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    do
                    {
                        int size = stream.Read(buff, 0, buff.Length);
                        builder.Append(Encoding.UTF8.GetString(buff, 0, size));
                    } while (stream.DataAvailable);
                    clientId = Convert.ToInt32(builder.ToString());
                    Client tmp = db.Clients.Single(x => x.Id == clientId);
                    pendingClients.Add(tmp);
                   
                    listBoxPendingClients.DataSource = null;
                    listBoxPendingClients.DataSource = pendingClients;
                    listBoxPendingClients.DisplayMember = "FullName";
                    listBoxPendingClients.ValueMember = "Id";
                    Image bellImg = Image.FromFile(@"C:\Users\danle\source\repos\WindowsFormsExam\WindowsFormsRealEstateAdmin\img\yes_bell.png");
                    pictureBoxBell.Image = bellImg; 
                }
            }
            catch (Exception exc)
            { MessageBox.Show($"{exc.Message}"); }
        }

        private void buttonManageClients_Click(object sender, EventArgs e)
        {
            FormClientManager clientManager = new FormClientManager();
            clientManager.ShowDialog();
        }

        private void buttonManageApartments_Click(object sender, EventArgs e)
        {
            FormApartmentManager apartmentAdministration = new FormApartmentManager();
            apartmentAdministration.ShowDialog();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxBell.Image = Image.FromFile(@"C:\Users\danle\source\repos\WindowsFormsExam\WindowsFormsRealEstateAdmin\img\no_bell.png");
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {

            if (listBoxPendingClients.SelectedItem != null)
            {
                Client tmp = listBoxPendingClients.SelectedItem as Client;
                tmp = db.Clients.Single(x => x.Id == tmp.Id);

                byte[] buff = Encoding.UTF8.GetBytes("accept");
                stream.Write(buff, 0, buff.Length);

                pendingClients.Remove(tmp);
                listBoxPendingClients.DataSource = null;
                listBoxPendingClients.DataSource = pendingClients;
                listBoxPendingClients.DisplayMember = "FullName";
                listBoxPendingClients.ValueMember = "Id";

                db.SaveChanges();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            NetworkStream stream = null;
            if (listBoxPendingClients.SelectedItem != null)
            {
                Client tmp = listBoxPendingClients.SelectedItem as Client;
                tmp = db.Clients.Single(x => x.Id == tmp.Id);

                byte[] buff = Encoding.UTF8.GetBytes("cancel");
                stream.Write(buff, 0, buff.Length);

                pendingClients.Remove(tmp);
                listBoxPendingClients.DataSource = null;
                listBoxPendingClients.DataSource = pendingClients;
                listBoxPendingClients.DisplayMember = "FullName";
                listBoxPendingClients.ValueMember = "Id";

                db.SaveChanges();
            }
        }
    }
}
