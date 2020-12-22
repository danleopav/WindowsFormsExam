using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    public partial class FormClient : Form
    {
        AgencyContext db = new AgencyContext();
        Client client;
        RealEstate realEstate;

        public FormClient(Client c)
        {
            InitializeComponent();
            client = db.Clients.Single(x=>x.Id==c.Id);
            
            labelWelcome.Text = "Welcome, " + client.FirstName;
            pictureBoxProfilePhoto.Image = ImageManip.ByteArrayToImage(client.ProfilePhoto);
            if (client.Status == Status.Renting)
            {
                RealEstate tmp = db.RealEstate.Single(x => x.Id == client.Id);
                int realEstateClientId = tmp.Id;
                realEstate = db.RealEstate.Single(x => x.Id == realEstateClientId);
                labelRentingNow.Text = "Yes";
                labelPrice.Text = "$" + realEstate.Price.ToString();
                labelStreet.Text = realEstate.Street;
                labelFloor.Text = realEstate.Floor.ToString();
            }
            else
            {
                labelRentingNow.Text = "No";
                labelPrice.Text = "$0";
                labelStreet.Text = "Unknown";
                labelFloor.Text = "0";
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            FormSearchRealEstate search = new FormSearchRealEstate(client);
            search.ShowDialog();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormProfileSetup formProfile = new FormProfileSetup(client);
            formProfile.ShowDialog();
        }

        private void buttonStopRenting_Click(object sender, EventArgs e)
        {
            if (client.Status == Status.Renting ||
                client.Status == Status.Waiting)
            {
                client.Status = Status.None;
                RealEstate tmp = db.RealEstate.Single(x => x.Id == client.Id);
                int realEstateClientId = tmp.Id;
                realEstate = db.RealEstate.Single(x => x.Id == realEstateClientId);
                realEstate.Client = db.Clients.FirstOrDefault();
                realEstate.Status = Status.None;
            }
            db.SaveChanges();
        }
    }
}
