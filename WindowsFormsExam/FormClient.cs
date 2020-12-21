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
        Client client;

        public FormClient(Client c)
        {
            InitializeComponent();
            client = c;
            labelWelcome.Text = "Welcome, " + client.FirstName;
            pictureBoxProfilePhoto.Image = ImageManip.ByteArrayToImage(client.ProfilePhoto);
            if (client.Status == Status.Renting)
            {
                labelRentingNow.Text = "Yes";
            }
            else
            {
                labelRentingNow.Text = "No";
                //labelPrice.Text = $"$0";
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
    }
}
