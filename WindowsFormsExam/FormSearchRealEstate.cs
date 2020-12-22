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
    public partial class FormSearchRealEstate : Form
    {
        AgencyContext db = new AgencyContext();
        List<RealEstate> realEstates;
        RealEstate realEstate;
        Client client;
        byte[][] photoSlider;
        int photoNumber = 0;
        string noImagePath = @"C:\Users\danle\source\repos\WindowsFormsExam\WindowsFormsRealEstateAdmin\img\no_photo.png";
        TcpClient tcpClient;
        NetworkStream stream;

        public FormSearchRealEstate(Client client)
        {
            InitializeComponent();

            this.client = client;

            realEstates = db.RealEstate.ToList();

            listBoxRealEstate.DataSource = realEstates;
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

/*            Thread thread = new Thread(TcpRecive);
            thread.Start();*/
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
            Thread thread = new Thread(TcpProcess);
            thread.Start();
        }

        void TcpProcess()
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
                        MessageBox.Show("This real estate is taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string realEstateId = tmpRealEstate.Id.ToString();
                    string clientId = tmpClient.Id.ToString();
                    string ids = realEstateId + "." + clientId;
                    byte[] buff = Encoding.UTF8.GetBytes(ids);

                    stream.Write(buff, 0, buff.Length);

                    tmpClient.Status = Status.Waiting;
                    tmpRealEstate.Status = Status.Waiting;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }
    }
}