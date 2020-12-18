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
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            FormSearchApartment search = new FormSearchApartment();
            search.ShowDialog();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormProfileSetup formProfile = new FormProfileSetup(client);
            formProfile.ShowDialog();
        }
    }
}
