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

            if (!CheckLogin("admin"))
            {
                db.Clients.Add(new Client()
                {
                    FirstName = "admin"
                });
                db.SaveChanges();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!CheckLogin(textBoxUsername.Text))
            {
                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUsername.Text = String.Empty;
                textBoxPassword.Text = String.Empty;
            }

            if (CheckLogin(textBoxUsername.Text) && CheckPassword(textBoxPassword.Text))
            {
                Client client = FindClient(textBoxUsername.Text);

                textBoxUsername.Text = String.Empty;
                textBoxPassword.Text = String.Empty;

                FormClient formClient = new FormClient(client);
                formClient.ShowDialog();
            }
        }


        Client FindClient(string username)
        {
            foreach (var client in db.Clients)
            {
                if (client.Username == username)
                {
                    return client;
                }
            }
            return null;
        }

        bool CheckLogin(string username)
        {
            if (db.Clients.Count() == 0)
            {
                return false;
            }

            foreach (var client in db.Clients)
            {
                if (client.Username == username)
                {
                    return true;
                }
            }

            return false;
        }

        bool CheckPassword(string pass)
        {
            foreach (var client in db.Clients)
            {
                if (client.Password == pass)
                {
                    return true;
                }
            }

            return false;
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
