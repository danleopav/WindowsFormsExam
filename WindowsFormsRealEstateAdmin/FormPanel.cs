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
        AgencyContext db = new AgencyContext();
        List<Client> pendingClients = new List<Client>();
        int realEstateId;
        int clientId;
        RealEstate tmpRealEstate;
        Client tmpClient;
        TcpListener server;
        NetworkStream stream;

        public FormPanel()
        {
            InitializeComponent();

            server = new TcpListener(IPAddress.Loopback, 8888);
            server.Start();

            Thread threadListen = new Thread(TcpListen);
            threadListen.Start();
        }

        void TcpListen()
        {
            while (true)
            {
                TcpClient tcpClient = server.AcceptTcpClient();
                stream = tcpClient.GetStream();
                Thread threadTcp = new Thread(() => TcpProcess(tcpClient));
                threadTcp.Start();
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
                    string[] ids = builder.ToString().Split('.');
                    realEstateId = Convert.ToInt32(ids[0]);
                    clientId = Convert.ToInt32(ids[1]);
                    tmpRealEstate = db.RealEstate.Single(x => x.Id == realEstateId);
                    tmpClient = db.Clients.Single(x => x.Id == clientId);
                    pendingClients.Add(tmpClient);
                   
                    listBoxPendingClients.DataSource = null;
                    listBoxPendingClients.DataSource = pendingClients;
                    listBoxPendingClients.DisplayMember = "FullName";
                    listBoxPendingClients.ValueMember = "Id";
                    Image bellImg = Image.FromFile(@"C:\Users\danle\source\repos\WindowsFormsExam\WindowsFormsRealEstateAdmin\img\yes_bell.png");
                    pictureBoxBell.Image = bellImg; 
                }
            }
            catch (Exception)
            { }
        }

        private void buttonManageClients_Click(object sender, EventArgs e)
        {
            FormClientManager clientManager = new FormClientManager();
            clientManager.ShowDialog();
        }

        private void buttonManageApartments_Click(object sender, EventArgs e)
        {
            FormRealEstateManager apartmentAdministration = new FormRealEstateManager();
            apartmentAdministration.ShowDialog();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxBell.Image = Image.FromFile(@"C:\Users\danle\source\repos\WindowsFormsExam\WindowsFormsRealEstateAdmin\img\no_bell.png");

            listBoxPendingClients.DataSource = null;
            listBoxPendingClients.DataSource = pendingClients;
            listBoxPendingClients.DisplayMember = "FullName";
            listBoxPendingClients.ValueMember = "Id";
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (listBoxPendingClients.SelectedItem != null)
            {
                tmpClient.Status = Status.Renting;
                tmpRealEstate.Client = tmpClient;
                tmpRealEstate.Status = Status.Renting;

                listBoxPendingClients.Items.Remove(tmpClient);
                listBoxPendingClients.DataSource = null;
                listBoxPendingClients.DataSource = pendingClients;
                listBoxPendingClients.DisplayMember = "FullName";
                listBoxPendingClients.ValueMember = "Id";

                db.SaveChanges();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (listBoxPendingClients.SelectedItem != null)
            {
                tmpClient.Status = Status.None;
                tmpRealEstate.Client = db.Clients.FirstOrDefault();
                tmpRealEstate.Status = Status.None;

                listBoxPendingClients.Items.Remove(tmpClient);
                listBoxPendingClients.DataSource = null;
                listBoxPendingClients.DataSource = pendingClients;
                listBoxPendingClients.DisplayMember = "FullName";
                listBoxPendingClients.ValueMember = "Id";

                db.SaveChanges();
            }
        }
    }
}
