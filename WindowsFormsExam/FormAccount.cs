using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    public partial class FormAccount : Form
    {
        RealEstateContext db = new RealEstateContext();
        bool isEyeOn = false;

        public FormAccount()
        {
            InitializeComponent();

            textBoxPassword.PasswordChar = '*';

            if (!ClientAccountValidator.CheckUsername("admin", db.Clients))
            {
                db.Clients.Add(new Client()
                {
                    Username = "admin",
                    FullName = "admin"
                });
                db.SaveChanges();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            db.Dispose();
            db = new RealEstateContext();

            if (!ClientAccountValidator.CheckUsername(textBoxUsername.Text, db.Clients))
            {
                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUsername.Text = String.Empty;
                textBoxPassword.Text = String.Empty;
            }

            if (ClientAccountValidator.CheckUsername(textBoxUsername.Text, db.Clients) && ClientAccountValidator.CheckPassword(textBoxPassword.Text, db.Clients))
            {
                Client client = ClientAccountValidator.FindClient(textBoxUsername.Text, db.Clients);

                textBoxUsername.Text = String.Empty;
                textBoxPassword.Text = String.Empty;

                FormClient formClient = new FormClient(client);
                formClient.ShowDialog();
            }
        }

        private void buttonEye_Click(object sender, EventArgs e)
        {
            if (!isEyeOn)
            {
                textBoxPassword.PasswordChar = '\0';
                buttonEye.Image = Properties.Resources.eye_on;
                isEyeOn = true;
            } 
            else
            {
                textBoxPassword.PasswordChar = '*';
                buttonEye.Image = Properties.Resources.eye_off;
                isEyeOn = false;
            } 
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegistration formRegistration = new FormRegistration();
            formRegistration.ShowDialog();
        }
    }
}
