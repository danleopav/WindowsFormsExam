using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExam
{
    public static class ClientAccountValidator
    {
        public static bool CheckUsername(string username, DbSet<Client> clients)
        {
            foreach(var client in clients)
            {
                if (client.Username == username)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckPassword(string password, DbSet<Client> clients)
        {
            foreach(var client in clients)
            {
                if (client.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckEmail(string email, DbSet<Client> clients)
        {
            foreach (var client in clients)
            {
                if (client.Email == email)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
