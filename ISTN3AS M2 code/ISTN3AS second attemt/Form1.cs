using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.WstGrp14DataSetTableAdapters;

namespace WindowsFormsApp1
{

   
    public partial class Form1: Form

    {
        string randomcode;
        public static string to;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wstGrp14DataSet.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.wstGrp14DataSet.Staff);
            // TODO: This line of code loads data into the 'ist3gaDataSet.Staff' table. You can move, or remove it, as needed.
            // this.staffTableAdapter.Fill(this.ist3gaDataSet.Staff);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection("Data Source=146.230.177.46\\istn3;Initial Catalog=ist3ga;User ID=ist3ga;Password=xj29so");
            //connection.Open();
            //SqlCommand command = new SqlCommand("SELECT *  FROM Staff where StaffID=2", connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);
            //dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            staffTableAdapter.CheckLogin(wstGrp14DataSet.Staff, usernameBox.Text, passwordBox.Text);
            if (wstGrp14DataSet.Staff.Rows.Count > 0)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt16( staffTableAdapter.EmailExists(EmailBox.Text.ToLower().Trim()));
            if (count > 0)
            {
                String Password, from, messagebody;
                Random rand = new Random();
                randomcode = (rand.Next(99999)).ToString().ToLower();
                MailMessage message = new MailMessage();
                to = EmailBox.Text.Trim().ToLower();
                from = "erikanaidoo2@gmail.com";
                Password = "gnftsgnonuzkvycg";
                messagebody = "Your reset code for Beauty Hub is " + randomcode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messagebody;
                message.Subject = "Password reseting code";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, Password);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Code sent successfully");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Email does not exist");
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (randomcode == CodeBox.Text)
            {
                MessageBox.Show("Correct code");
                tabControl1.SelectedTab = tabPage3;

            }
            else
            {
                MessageBox.Show("incorrect code");


            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        

        private void VerifyPassbutton_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt16(staffTableAdapter.UserNameExists(EnterUsernameBox.Text));
            if (count > 0)
            {

                if (EnterNewPassBox.Text == VerifyPasswordBox.Text)
                {
                    staffTableAdapter.UpdatePassword(EnterNewPassBox.Text, EnterUsernameBox.Text);
                    MessageBox.Show("Password updated successfully.");
                }
                else
                {
                    MessageBox.Show("Passwords do not match.");
                }
            }
            else
            {
                MessageBox.Show("UserName not found.");
            }


        }
    }
}
