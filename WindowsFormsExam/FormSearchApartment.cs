using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    public partial class FormSearchApartment : Form
    {
        AgencyContext db = new AgencyContext();
        List<RealEstate> apartments;
        RealEstate realEstate;
        Client client;
        byte[][] photoSlider;
        int photoNumber = 0;
        string noImagePath = @"C:\Users\danle\source\repos\WindowsFormsExam\WindowsFormsRealEstateAdmin\img\no_photo.png";
        TcpClient tcpClient;
        NetworkStream stream;

        public FormSearchApartment(Client client)
        {
            InitializeComponent();

            this.client = client;

            apartments = db.RealEstate.ToList();

            listBoxRealEstate.DataSource = apartments;
            listBoxRealEstate.DisplayMember = "Street";
            listBoxRealEstate.ValueMember = "Id";

            if (realEstate.Status == Status.Waiting ||
                realEstate.Status == Status.Renting)
            {
                labelAvailable.Text = "X";
                labelAvailable.ForeColor = Color.Red;
            }
            else
            {
                labelAvailable.Text = "V";
                labelAvailable.ForeColor = Color.Green;
            }

            Thread thread = new Thread(TcpRecive);
            thread.Start();
        }

        private void listBoxRealEstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            realEstate = listBoxRealEstate.SelectedItem as RealEstate;
            textBoxStreet.Text = realEstate.Street;
            textBoxCity.Text = realEstate.City.ToString();
            textBoxPrice.Text = realEstate.Price.ToString();
            textBoxRoom.Text = realEstate.Rooms.ToString();
            textBoxFloor.Text = realEstate.Floor.ToString();
            textBoxDescription.Text = realEstate.Description;

            photoNumber = 0;
            labelPhotoNumber.Text = "1/5";
            if (realEstate.Status == Status.Waiting ||
                realEstate.Status == Status.Renting)
            {
                labelAvailable.Text = "X";
                labelAvailable.ForeColor = Color.Red;
            }
            else
            {
                labelAvailable.Text = "V";
                labelAvailable.ForeColor = Color.Green;
            }

            photoSlider = ImageManip.ByteArrToPhotoSlider(realEstate.PhotoSlider);
            pictureBoxSlider.Image = ImageManip.ByteArrayToImage(photoSlider[photoNumber]);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (photoNumber + 1 >= 5)
            {
                return;
            }
            if (photoSlider == null)
            {
                return;
            }

            photoNumber++;
            labelPhotoNumber.Text = $"{photoNumber + 1}/5";

            if (photoSlider[photoNumber] != null)
            {
                pictureBoxSlider.Image = ImageManip.ByteArrayToImage(photoSlider[photoNumber]);
            }
            else
            {
                Image img = Image.FromFile(noImagePath);
                img = ImageManip.ResizeImage(img, new Size(400, 240));
                pictureBoxSlider.Image = img;
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (photoNumber - 1 < 0)
            {
                return;
            }
            if (photoSlider == null)
            {
                return;
            }

            photoNumber--;
            labelPhotoNumber.Text = $"{photoNumber + 1}/5";

            if (photoSlider[photoNumber] != null)
            {
                pictureBoxSlider.Image = ImageManip.ByteArrayToImage(photoSlider[photoNumber]);
            }
            else
            {
                Image img = Image.FromFile(noImagePath);
                img = ImageManip.ResizeImage(img, new Size(400, 240));
                pictureBoxSlider.Image = img;
            }
        }

        private void buttonSendRequest_Click(object sender, EventArgs e)
        {
            if (client.Status == Status.Renting)
            {
                MessageBox.Show("You can rent only one real estate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread thread = new Thread(TcpSend);
            thread.Start();
        }

        void TcpSend()
        {
            try
            {
                Client tmpClient = db.Clients.Single(x => x.Id == client.Id);
                RealEstate tmpRealEstate = db.RealEstate.Single(x => x.Id == realEstate.Id);
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Loopback, 8888);
                stream = tcpClient.GetStream();
                while (true)
                {
                    if (tmpClient.Status == Status.Renting ||
                        tmpClient.Status == Status.Waiting)
                    {
                        return;
                    }
                    if (tmpRealEstate.Status == Status.Renting ||
                        tmpRealEstate.Status == Status.Waiting)
                    {
                        MessageBox.Show("This apartment is taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string clientId = tmpClient.Id.ToString();
                    byte[] buff = Encoding.UTF8.GetBytes(clientId);
                    stream.Write(buff, 0, buff.Length);

                    tmpClient.Status = Status.Waiting;
                    tmpRealEstate.Status = Status.Waiting;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }

        void TcpRecive()
        {
            try
            {
                Client tmpClient = db.Clients.Single(x => x.Id == client.Id);
                RealEstate tmpRealEstate = db.RealEstate.Single(x => x.Id == realEstate.Id);
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Loopback, 8888);
                stream = tcpClient.GetStream();
                while (true)
                {
                    byte[] buff = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    do
                    {
                        int size = stream.Read(buff, 0, buff.Length);
                        builder.Append(Encoding.UTF8.GetString(buff, 0, size));
                    } while (stream.DataAvailable);

                    string response = builder.ToString();
                    if (response == "accept")
                    {
                        tmpClient.Status = Status.Renting;
                        tmpRealEstate.Client = tmpClient;
                        tmpRealEstate.Status = Status.Renting;
                    }
                    else
                    {
                        tmpClient.Status = Status.None;
                        tmpRealEstate.Client = null;
                        tmpRealEstate.Status = Status.None;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }
    }
}