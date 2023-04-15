using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emailer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        void PrepareAndSend()
        {
            string from = fromTextBox.Text;
            if(from == String.Empty)
            {
                throw new Exception("From field cannot be empty!");
            }
            string to = toTextBox.Text;
            if(to == String.Empty)
            {
                throw new Exception("To field cannot be empty!");
            }
            string subject = subjectTextBox.Text;
            string body = bodyTextBox.Text;
            string server = serverTextBox.Text;
            if(server == String.Empty)
            {
                throw new Exception("Server address cannot be empty!");
            }
            int port = Convert.ToInt32(portTextBox.Text);
            if(port <= 0 || port > 65535)
            {
                throw new Exception("Incorrect port number!");
            }
            string login = loginTextBox.Text;
            if (login == String.Empty)
            {
                throw new Exception("Login cannot be empty!");
            }
            string password = passwordTextBox.Text;
            if (password == String.Empty)
            {
                throw new Exception("Password cannot be empty!");
            }
            SendEmail(from, to, subject, body, server, port, login, password);
        }
        
        static void SendEmail(string from, string to, string subject, string body, string server, int port, string login, string password)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient(server, port);
            client.Credentials = new NetworkCredential(login, password);
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PrepareAndSend();
                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
