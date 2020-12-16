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
            pictureBoxProfilePhoto.Image = ByteToImage(client.ProfilePhoto);
        }

        Image ByteToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            Image img = Image.FromStream(ms);
            return img;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {

        }
    }
}
