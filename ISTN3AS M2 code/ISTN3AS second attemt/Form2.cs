using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        System.Windows.Forms.ToolTip dgvToolTip = new System.Windows.Forms.ToolTip();
        // checking if changes are working

        public Form2()
        {
            InitializeComponent();

            dgvAppointments.CellToolTipTextNeeded += DgvAppointments_CellToolTipTextNeeded;
            dgvAppointments.ShowCellToolTips = true;




            if (tabControl2.SelectedTab == tabControl2.TabPages["addStafftab"])
            {
                button6.Text = "Update or Delete Staff";
            }
            else
            {
                button6.Text = "Add new Staff";
            }
            if (tabControl3.SelectedTab == tabControl3.TabPages["addCusttab"])
            {
                button7.Text = "Update or Delete Customer";
            }
            else
            {
                button7.Text = "Add new Customer";
            }
            if (tabControl5.SelectedTab == tabControl5.TabPages["Services"])
            {
                button13.Text = "Add new Service";
            }
            else
            {
                
                button13.Text = "Update or Delete Service";
            }


            //-----------------------------------------------
            dtpDate.MinDate = DateTime.Today;
            dtpNewDate.MinDate = DateTime.Today;
            //------------------------------------------






        }
        // validation Functions  
        public static bool IsNotEmpty(System.Windows.Forms.TextBox box)
        {
            bool result= !string.IsNullOrWhiteSpace(box.Text);
            box.BackColor = result ? Color.White : Color.Red;
            box.Refresh();
            return result;
            
        }

        public static bool IsValidEmail(System.Windows.Forms.TextBox box)
        {
            string email = box.Text.Trim().ToLower();
            bool result= IsNotEmpty(box) && (email.EndsWith("@gmail.com") || email.EndsWith("@outlook.com"));
            box.BackColor = result ? Color.White : Color.Red;
            return result;
        }

        public static bool IsValidPhone(System.Windows.Forms.TextBox box)
        {
            string phone = box.Text.Trim();
            bool result= IsNotEmpty(box) && phone.Length == 10 && phone.StartsWith("0") && phone.All(char.IsDigit);
            box.BackColor = result ? Color.White : Color.Red;
            return result;
        }
 
        public static bool IsComboBoxSelected(System.Windows.Forms.ComboBox combo)
        {
            bool result = combo.SelectedIndex >= 0;
            combo.BackColor = result ? Color.White : Color.Red;
            return result;
        }
        //End of Validation Functions


        private void button1_Click(object sender, EventArgs e)
        {
            tabInvoice.SelectedTab = tabPage1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabInvoice.SelectedTab = tabPage2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabInvoice.SelectedTab = tabPage3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabInvoice.SelectedTab = tabPage4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabInvoice.SelectedTab = tabPage5;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            

            // TODO: This line of code loads data into the 'wstGrp14DataSet1.Service' table. You can move, or remove it, as needed.
            this.serviceTableAdapter.Fill(this.wstGrp14DataSet.Service);
            // TODO: This line of code loads data into the 'wstGrp14DataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.wstGrp14DataSet.Product);
            // TODO: This line of code loads data into the 'wstGrp14DataSet.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.wstGrp14DataSet.Staff);
            // TODO: This line of code loads data into the 'wstGrp14DataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.wstGrp14DataSet.Customer);
            // TODO: This line of code loads data into the 'wstGrp14DataSet.Service' table. You can move, or remove it, as needed.
            this.serviceTableAdapter.Fill(this.wstGrp14DataSet.Service);

            //Load appointments into DataGridView
            LoadAppointments();
            LoadSales();



            //dgvAppointments.ReadOnly = true;
            //dgvAppointments.Columns[6].ReadOnly = false; // Comment column
            //dgvAppointments.Columns[7].ReadOnly = false; // Rating column
            //dgvAppointments.Columns["Comments"].ReadOnly = false;
            //dgvAppointments.Columns["Rating"].ReadOnly = false;


            if (!dgvAppointments.Columns.Contains("CustomerName"))
            {
                DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
                nameCol.Name = "CustomerName";
                nameCol.HeaderText = "Customer Name";
                nameCol.Visible = false; // keep it hidden
                dgvAppointments.Columns.Add(nameCol);
            }

            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                if (row.Cells.Count > 1 &&
                    row.Cells[1].Value != null &&
                    row.Cells[1].Value != DBNull.Value)
                {
                    int customerId;
                    if (int.TryParse(row.Cells[1].Value.ToString(), out customerId))
                    {
                        var customer = customerTableAdapter.GetData()
                                          .FirstOrDefault(c => c.CustomerID == customerId);
                        if (customer != null)
                        {
                            row.Cells["CustomerName"].Value = customer.FirstName + " " + customer.LastName;
                        }
                    }
                }
            }





            LoadCart();

            dgvSalesHistory.CellClick += dgvSalesHistory_CellClick;










            cbTime.Items.Clear();
            cbTime.Items.Add("09:00");
            cbTime.Items.Add("10:00");
            cbTime.Items.Add("11:30");
            cbTime.Items.Add("13:00");
            cbTime.Items.Add("14:30");
            cbTime.Items.Add("16:00");

            cbNewTime.Items.Clear();
            cbNewTime.Items.Add("09:00");
            cbNewTime.Items.Add("10:00");
            cbNewTime.Items.Add("11:30");
            cbNewTime.Items.Add("13:00");
            cbNewTime.Items.Add("15:00");







        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt16(staffTableAdapter.UserNameExists(BoxEmail.Text.ToLower()));
            string name = NmeBox.Text;
            string selectRole = RoleComboBox.SelectedItem?.ToString();
            string lastName = LastNmeBox.Text;
            string email = BoxEmail.Text;
            string phoneNo = NumberPhoneBox.Text;
            string username = UserBox.Text;
            string password = PassBox.Text;

            if (IsComboBoxSelected(RoleComboBox) && IsNotEmpty(NmeBox) && IsNotEmpty(LastNmeBox)  && IsValidEmail(BoxEmail) && IsValidPhone(NumberPhoneBox) && IsNotEmpty(UserBox) && IsNotEmpty(PassBox))
            {
                if (count > 0)
                {
                    MessageBox.Show("UserName already exists");
                }
                else
                {
                    staffTableAdapter.InsertStaff(name, lastName, selectRole, email.ToLower(), phoneNo, username, password, true);
                    staffTableAdapter.Fill(wstGrp14DataSet.Staff);
                    MessageBox.Show("Staff: "+name+" was added successfully");
                    ClearFields();
                }
            }

        }




        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {
           // int count = Convert.ToInt16(staffTableAdapter.UserNameExists(BoxEmail.Text.ToLower())); 
            if (IsComboBoxSelected(IDcomboBox3) && IsComboBoxSelected(rolecomboBox2)&& IsNotEmpty(nameBox) && IsNotEmpty(LASTnBox) &&
                   IsValidEmail(EMAILBox) && IsValidPhone(PhoneNumberBox) && IsNotEmpty(UserNameBox) && IsNotEmpty(passWordBox))

            {
                if (!int.TryParse(IDcomboBox3.SelectedItem.ToString(), out int selectedId))
                {
                    MessageBox.Show("Invalid Staff ID selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                staffTableAdapter.UpdateStaff(nameBox.Text, LASTnBox.Text, rolecomboBox2.SelectedItem.ToString(), EMAILBox.Text.ToLower(),
                    PhoneNumberBox.Text, UserNameBox.Text, passWordBox.Text, ActiveCheckBox.Checked, selectedId);

                staffTableAdapter.Fill(wstGrp14DataSet.Staff);
                MessageBox.Show("Staff with ID:"+IDcomboBox3.SelectedItem.ToString()+" was updated successfully");
                ClearFields();

            }

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IDcomboBox3.SelectedValue != null)
            {
                int index = Convert.ToInt16(IDcomboBox3.SelectedValue);
                DataRow[] rows = wstGrp14DataSet.Staff.Select("StaffID =" + index);
                DataRow row = rows[0];
                nameBox.Text = row["FirstName"].ToString();
                LASTnBox.Text = row["LastName"].ToString();
                EMAILBox.Text = row["Email"].ToString();
                PhoneNumberBox.Text = row["PhoneNumber"].ToString();
                UserNameBox.Text = row["Username"].ToString();
                passWordBox.Text = row["Password"].ToString();

                // Handle role selection
                string role = row["Role"].ToString();
                if (rolecomboBox2.Items.Contains(role))
                {
                    rolecomboBox2.SelectedItem = role;
                }
                else
                {
                    rolecomboBox2.SelectedIndex = -1; // Clear selection if role not found
                }

                // Set checkbox based on Active status
                ActiveCheckBox.Checked = row["Active"] != DBNull.Value && Convert.ToBoolean(row["Active"]);
            }


        }

        private void ClearFields()
        {
            nameBox.Clear();
            LASTnBox.Clear();
            rolecomboBox2.SelectedIndex = -1;
            EMAILBox.Clear();
            PhoneNumberBox.Clear();
            UserNameBox.Clear();
            passWordBox.Clear();
            ActiveCheckBox.Checked = false;
            IDcomboBox3.SelectedIndex = -1;
            NmeBox.Clear();
            RoleComboBox.SelectedIndex=-1;
            LastNmeBox.Clear();
            BoxEmail.Clear();
            NumberPhoneBox.Clear();
            UserBox.Clear();
            PassBox.Clear();
            checkBox1.Checked = false;
            custCheck.Checked = false;
            FNBox.Clear();
            LNBox.Clear();
            EmilBox.Clear();
            PNBox.Clear();
            IDComboBox.SelectedItem = -1;
            FirtsNameBox.Clear();
            LastNameBox.Clear();
            EmailB.Clear();
            PhoneBox.Clear();
            nameBox.Clear();
            LASTnBox.Clear();
            EMAILBox.Clear();
            PhoneNumberBox.Clear();
            UserNameBox.Clear();
            passWordBox.Clear();
            rolecomboBox2.SelectedIndex = -1;
            textBox8.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            checkBox3.Checked = false;
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            checkBox2.Checked = false;
            textBox3.Clear();
        }

        private void FirtsNameBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void button9_Click(object sender, EventArgs e)
        {
            
            string firstName = FNBox.Text;
            string lastName = LNBox.Text;
            string email = EmilBox.Text.ToLower();
            string phoneNo = PNBox.Text;
            

            if (IsComboBoxSelected(IDComboBox) && IsNotEmpty(FNBox) && IsNotEmpty(LNBox) && IsValidEmail(EmilBox) && IsValidPhone(PNBox))
            {
                
                if (!int.TryParse(IDComboBox.SelectedItem.ToString(), out int selectedId))
                {
                    MessageBox.Show("Invalid Customer ID selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                customerTableAdapter.UpdateCustomer(firstName, lastName, email, phoneNo, custCheck.Checked, selectedId);
                customerTableAdapter.Fill(wstGrp14DataSet.Customer);
                MessageBox.Show("Customer was ID: "+ selectedId+" was updated successfully");
                ClearFields();
            }
        }

        private void IDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IDComboBox.SelectedValue != null)
            {
                int index = Convert.ToInt16(IDComboBox.SelectedValue);
                DataRow[] rows = wstGrp14DataSet.Customer.Select("CustomerID =" + index);
                DataRow row = rows[0];
                FNBox.Text = row["FirstName"].ToString();
                LNBox.Text = row["LastName"].ToString();
                EmilBox.Text = row["Email"].ToString();
                PNBox.Text = row["PhoneNumber"].ToString();
                custCheck.Checked = Convert.ToBoolean(row["Active"]);
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Firstname = FirtsNameBox.Text;
            string lastName = LastNameBox.Text;
            string email = EmailB.Text;
            string phoneNo = PhoneBox.Text;


            if ( IsNotEmpty(FirtsNameBox) && IsNotEmpty(LastNameBox) && IsValidEmail(EmailB) && IsValidPhone(PhoneBox))
            {
                customerTableAdapter.InsertCustomer(Firstname, lastName, email.ToLower(), phoneNo, true);
                customerTableAdapter.Fill(wstGrp14DataSet.Customer);
                MessageBox.Show("Customer: "+Firstname+" was added successfully");
                ClearFields();

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tabControl2.TabPages["addStafftab"])
            {
                button6.Text = "Add new Staff";
                tabControl2.SelectedTab = updateStafftab;
            }
            else
            {
                button6.Text = "Update or Delete Staff";
                tabControl2.SelectedTab = addStafftab;
            }
        }

        private void deletestuff_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(IDcomboBox3.SelectedItem.ToString(), out int selectedId))
            {
                MessageBox.Show("Invalid Staff ID selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            staffTableAdapter.DeleteStaff(selectedId);
            staffTableAdapter.Fill(wstGrp14DataSet.Staff);
            MessageBox.Show("Staff with ID:" + IDcomboBox3.SelectedItem.ToString() + " was deleted successfully");
            ClearFields();

        }

        private void CustDeletebtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(IDComboBox.SelectedItem.ToString(), out int selectedId))
            {
                MessageBox.Show("Invalid Staff ID selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            customerTableAdapter.DeleteCustomer(selectedId);
            customerTableAdapter.Fill(wstGrp14DataSet.Customer);
            MessageBox.Show("Customer was ID: " + selectedId + " was deleted successfully");
            ClearFields();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            if (tabControl3.SelectedTab == tabControl3.TabPages["addCusttab"])
            {
                button7.Text = "Add new Customer";
                tabControl3.SelectedTab = updateCusttab;
            }
            else
            {
                button7.Text = "Update or Delete Customer";
                tabControl3.SelectedTab = addCusttab;
            }
        }

        private void CustomerSearchtxt_TextChanged(object sender, EventArgs e)
        {
            customerTableAdapter.FilterCustomer(wstGrp14DataSet.Customer, CustomerSearchtxt.Text, CustomerSearchtxt.Text);
            dataGridView2.DataSource = wstGrp14DataSet.Customer;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            staffTableAdapter.Filter(wstGrp14DataSet.Staff, textBox1.Text, textBox1.Text);
            dataGridView1.DataSource = wstGrp14DataSet.Staff;
            //staffTableAdapter.Fill(wstGrp14DataSet.Staff);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            serviceTableAdapter.FilterService(wstGrp14DataSet.Service, textBox2.Text);
            dataGridView3.DataSource = wstGrp14DataSet.Service;

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (IsNotEmpty(textBox8) && IsNotEmpty(textBox7) && IsNotEmpty(textBox6) && IsNotEmpty(textBox5))
            {
                if (checkBox3.Checked)
                {
                    if (IsNotEmpty(textBox4))
                    {
                        serviceTableAdapter.InsertService(textBox8.Text, Convert.ToInt16(textBox7.Text), Convert.ToDecimal(textBox6.Text), textBox5.Text, true, checkBox3.Checked, Convert.ToDecimal(textBox4.Text));
                        dataGridView3.DataSource = wstGrp14DataSet.Service;
                        
                        MessageBox.Show("Service: "+ textBox8.Text+" was added successfully");
                        ClearFields();
                    }

                }
                else
                {
                    serviceTableAdapter.InsertService(textBox8.Text, Convert.ToInt16(textBox7.Text), Convert.ToDecimal(textBox6.Text), textBox5.Text, true, checkBox3.Checked, Convert.ToDecimal(textBox4.Text));
                    dataGridView3.DataSource = wstGrp14DataSet.Service;
                    MessageBox.Show("Service: " + textBox8.Text + " was added successfully");
                    ClearFields();
                }

                    
            }
            
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

            productTableAdapter.Filter(wstGrp14DataSet.Product, textBox15.Text);
            dataGridView4.DataSource = wstGrp14DataSet.Product;

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                textBox4.Enabled = false;
            }
            else
            {
                textBox4.Enabled = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (IsComboBoxSelected(comboBox1)&&IsNotEmpty(textBox12)&&IsNotEmpty(textBox11)&&IsNotEmpty(textBox10))
            {
                if (checkBox2.Checked)
                {
                    if (IsNotEmpty(textBox3))
                    {
                        serviceTableAdapter.UpdateService(textBox12.Text, Convert.ToInt16(textBox11.Text), Convert.ToDecimal(textBox10.Text), textBox9.Text, checkBox1.Checked, checkBox2.Checked, Convert.ToDecimal(textBox3.Text), Convert.ToInt16(comboBox1.SelectedValue));
                        dataGridView3.DataSource = wstGrp14DataSet.Service;
                        serviceTableAdapter.Fill(wstGrp14DataSet.Service);
                        MessageBox.Show("Service with ID: "+ Convert.ToInt16(comboBox1.SelectedValue)+" was updated successfully");
                        ClearFields();
                    }

                }
                else
                {
                    serviceTableAdapter.UpdateService(textBox12.Text, Convert.ToInt16(textBox11.Text), Convert.ToDecimal(textBox10.Text), textBox9.Text, checkBox1.Checked, checkBox2.Checked, Convert.ToDecimal(textBox3.Text), Convert.ToInt16(comboBox1.SelectedValue));
                    dataGridView3.DataSource = wstGrp14DataSet.Service;
                    serviceTableAdapter.Fill(wstGrp14DataSet.Service);
                    MessageBox.Show("Service with ID: " + Convert.ToInt16(comboBox1.SelectedValue) + " was updated successfully");
                    ClearFields();

                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int selectedId = Convert.ToInt32(comboBox1.SelectedValue);

                // Select rows matching the ServiceID
                DataRow[] rows = wstGrp14DataSet.Service.Select("ServiceID = " + selectedId);
                DataRow row = rows[0];

                textBox12.Text = row["ServiceName"] != DBNull.Value ? row["ServiceName"].ToString() : "";
                textBox11.Text = row["Duration"] != DBNull.Value ? row["Duration"].ToString() : "";
                textBox10.Text = row["Price"] != DBNull.Value ? row["Price"].ToString() : "";
                textBox9.Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "";
                textBox3.Text = row["PromotionPrice"] != DBNull.Value ? row["PromotionPrice"].ToString() : "";
                checkBox1.Checked = row["Active"] != DBNull.Value && Convert.ToBoolean(row["Active"]);
                checkBox2.Checked = row["Promotion"] != DBNull.Value && Convert.ToBoolean(row["Promotion"]);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            serviceTableAdapter.DeleteService(Convert.ToInt16(comboBox1.SelectedValue));
            dataGridView3.DataSource = wstGrp14DataSet.Service;
            MessageBox.Show("Service with ID: " + Convert.ToInt16(comboBox1.SelectedValue) + " was deleted successfully");
            ClearFields();
        }


        //Appointments coding

        private void LoadAppointments()
        {
            this.appointmentTableAdapter1.Fill(this.wstGrp14DataSet.Appointment);
            dgvAppointments.DataSource = wstGrp14DataSet.Appointment;
            


        }
        private void dgvAppointments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string columnName = dgvAppointments.Columns[e.ColumnIndex].Name;

                if (columnName == "Comments" || columnName == "Rating")
                {
                    var row = dgvAppointments.Rows[e.RowIndex];

                    int appointmentId = Convert.ToInt32(row.Cells[0].Value);
                    string newComment = row.Cells["Comments"].Value?.ToString() ?? "";
                    int newRating = int.TryParse(row.Cells["Rating"].Value?.ToString(), out int val) ? val : 0;

                    appointmentTableAdapter1.UpdateCommentAndRating(newComment, newRating, appointmentId);

                    MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            appointmentTableAdapter1.Update(wstGrp14DataSet.Appointment);
        }






        private void btnBook_Click(object sender, EventArgs e)
        {
            // Validate dropdowns
            if (cbCustomers.SelectedIndex == -1 ||
                cbStaff.SelectedIndex == -1 ||
                cbServices.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields before booking.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate time format (manually typed)
            if (!TimeSpan.TryParse(txtTime.Text, out TimeSpan appointmentTime))
            {
                MessageBox.Show("Please enter a valid time in HH:mm format (e.g., 14:30).", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate comments
            if (string.IsNullOrWhiteSpace(txtComments.Text))
            {
                MessageBox.Show("Please enter a comment or note for the appointment.", "Missing Comments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent past dates
            if (dtpDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("You cannot book an appointment in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                int customerId = Convert.ToInt32(cbCustomers.SelectedValue);
                int staffId = Convert.ToInt32(cbStaff.SelectedValue);
                int serviceId = Convert.ToInt32(cbServices.SelectedValue);
                DateTime appointmentDate = dtpDate.Value.Date;
                string status = "Scheduled";
                string comments = txtComments.Text;
                int rating = 0;

                //  Get duration from service 
                int duration = serviceTableAdapter.GetDurationById(serviceId) ?? 30;  
                TimeSpan appointmentEnd = appointmentTime.Add(TimeSpan.FromMinutes(duration));

                //Staff conflict: overlapping appointment
                var staffConflict = wstGrp14DataSet.Appointment.AsEnumerable().FirstOrDefault(row =>
                    row.Field<int>("StaffID") == staffId &&
                    row.Field<DateTime>("AppointmentDate").Date == appointmentDate &&
                    row.Field<string>("Status") != "Cancelled" &&
                    appointmentTime < row.Field<TimeSpan>("AppointmentTime").Add(TimeSpan.FromMinutes(row.Field<int>("Duration"))) &&
                    appointmentEnd > row.Field<TimeSpan>("AppointmentTime")
                );

                if (staffConflict != null)
                {
                    MessageBox.Show("This staff member is already booked during that time.", "Staff Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Customer conflict: overlapping appointment
                var customerConflict = wstGrp14DataSet.Appointment.AsEnumerable().FirstOrDefault(row =>
                    row.Field<int>("CustomerID") == customerId &&
                    row.Field<DateTime>("AppointmentDate").Date == appointmentDate &&
                    row.Field<string>("Status") != "Cancelled" &&
                    appointmentTime < row.Field<TimeSpan>("AppointmentTime").Add(TimeSpan.FromMinutes(row.Field<int>("Duration"))) &&
                    appointmentEnd > row.Field<TimeSpan>("AppointmentTime")
                );

                if (customerConflict != null)
                {
                    MessageBox.Show("This customer already has an appointment during that time.", "Customer Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert appointment
                appointmentTableAdapter1.InsertAppointment(
                    customerId, staffId, appointmentDate, appointmentTime,
                    status, comments, rating, duration
                );

                LoadAppointments();
                ClearBookingForm();
                MessageBox.Show("Appointment booked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }






        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                string status = dgvAppointments.CurrentRow.Cells[5].Value.ToString();

                //Block already cancelled or rescheduled
                if (status == "Cancelled" || status == "Rescheduled")
                {
                    MessageBox.Show("You cannot cancel an appointment that is already cancelled or rescheduled.");
                    return;
                }

                //Block if appointment is today or in the past
                DateTime appointmentDate = Convert.ToDateTime(dgvAppointments.CurrentRow.Cells[3].Value); // index 3 = AppointmentDate
                if (appointmentDate <= DateTime.Today)
                {
                    MessageBox.Show("You cannot cancel an appointment that is today or in the past.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm and cancel
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to cancel this appointment?",
                    "Confirm Cancellation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
                    appointmentTableAdapter1.UpdateStatus("Cancelled", appointmentId);
                    LoadAppointments();
                    MessageBox.Show("Appointment cancelled successfully.");
                }
            }
        }



        private void btnReschedule_Click(object sender, EventArgs e)
        {
            //Dont allow rescheduling to a past date
            if (dtpNewDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("You cannot reschedule to a past date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Time must be selected
            if (cbNewTime.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a new time before rescheduling.", "Missing Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvAppointments.CurrentRow != null)
            {
                string status = dgvAppointments.CurrentRow.Cells[5].Value.ToString();

                //Already cancelled or rescheduled
                if (status == "Cancelled" || status == "Rescheduled")
                {
                    MessageBox.Show("You cannot reschedule an appointment that is already cancelled or rescheduled.");
                    return;
                }

                //Get original appointment details
                int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
                DateTime originalDate = Convert.ToDateTime(dgvAppointments.CurrentRow.Cells[3].Value); // AppointmentDate
                TimeSpan originalTime = TimeSpan.Parse(dgvAppointments.CurrentRow.Cells[4].Value.ToString()); // AppointmentTime

                int customerId = Convert.ToInt32(cbCustomers.SelectedValue);
                int staffId = Convert.ToInt32(cbStaff.SelectedValue);
                DateTime newDate = dtpNewDate.Value.Date;
                string selectedTime = cbNewTime.SelectedItem?.ToString() ?? "09:00";
                TimeSpan newTime = TimeSpan.Parse(selectedTime);

                //Can't reschedule to same slot
                if (newDate == originalDate && newTime == originalTime)
                {
                    MessageBox.Show("The new schedule is the same as the current one. Please choose a different time.", "No Change Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Check if staff is already booked at new slot
                var staffConflict = wstGrp14DataSet.Appointment.AsEnumerable().FirstOrDefault(row =>
                    row.Field<int>("StaffID") == staffId &&
                    row.Field<DateTime>("AppointmentDate").Date == newDate &&
                    row.Field<TimeSpan>("AppointmentTime") == newTime &&
                    row.Field<string>("Status") != "Cancelled" &&
                    row.Field<int>("AppointmentID") != appointmentId
                );

                if (staffConflict != null)
                {
                    MessageBox.Show("The staff member is already booked at that time.", "Staff Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Check if customer already has another appointment
                var customerConflict = wstGrp14DataSet.Appointment.AsEnumerable().FirstOrDefault(row =>
                    row.Field<int>("CustomerID") == customerId &&
                    row.Field<DateTime>("AppointmentDate").Date == newDate &&
                    row.Field<TimeSpan>("AppointmentTime") == newTime &&
                    row.Field<string>("Status") != "Cancelled" &&
                    row.Field<int>("AppointmentID") != appointmentId
                );

                if (customerConflict != null)
                {
                    MessageBox.Show("This customer already has another appointment at that time.", "Customer Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Confirm & update
                DialogResult result = MessageBox.Show(
                    $"Reschedule this appointment to:\n{newDate:yyyy-MM-dd} at {selectedTime}?",
                    "Confirm Reschedule",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    appointmentTableAdapter1.UpdateAppointmentSchedule(newDate.ToString("yyyy-MM-dd"), newTime, "Rescheduled", appointmentId);
                    LoadAppointments();
                    ClearRescheduleForm();
                    MessageBox.Show("Appointment rescheduled successfully.");
                }
            }
        }




        private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                string status = dgvAppointments.CurrentRow.Cells[5].Value.ToString();

                if (status == "Cancelled" || status == "Rescheduled")
                {
                    btnCancel.Enabled = false;
                    btnReschedule.Enabled = false;
                }
                else
                {
                    btnCancel.Enabled = true;
                    btnReschedule.Enabled = true;
                }

                txtCommentFeedback.Text = dgvAppointments.CurrentRow.Cells["Comments"].Value?.ToString();
                numRatingFeedback.Value = int.TryParse(dgvAppointments.CurrentRow.Cells["Rating"].Value?.ToString(), out int val) ? val : 0;
            }


            
        }

        private void dgvAppointments_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvAppointments.Rows[e.RowIndex];
            var status = row.Cells[5].Value?.ToString();

            // Highlight today's appointments 
            if (row.Cells[3].Value != null)
            {
                DateTime apptDate = Convert.ToDateTime(row.Cells[3].Value);
                if (apptDate.Date == DateTime.Today)
                {
                    row.Cells[3].Style.BackColor = Color.Aquamarine;
                }
            }

            
            if (status == "Cancelled")
            {
                row.Cells[5].Style.BackColor = Color.LightCoral;
            }
            else if (status == "Rescheduled")
            {
                row.Cells[5].Style.BackColor = Color.Khaki;
            }
            else
            {
                row.Cells[5].Style.BackColor = Color.White;
            }
        }











        private void ClearBookingForm()
        {
            cbCustomers.SelectedIndex = -1;
            cbStaff.SelectedIndex = -1;
            cbServices.SelectedIndex = -1;
            cbTime.SelectedIndex = -1;
            txtComments.Clear();
            dtpDate.Value = DateTime.Today;
        }

        private void ClearRescheduleForm()
        {
            cbNewTime.SelectedIndex = -1;
            dtpNewDate.Value = DateTime.Today;
        }

        private void LoadCart()
        {
            
            productTableAdapter.Fill(wstGrp14DataSet.Product);

            dgvCart.Rows.Clear();

            foreach (DataRow row in wstGrp14DataSet.Product.Rows)
            {
                string name = row["Name"].ToString();
                decimal price = Convert.ToDecimal(row["Price"]);

                dgvCart.Rows.Add(name, price.ToString("0.00"), "", "");
            }
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["colQuantity"].Index && e.RowIndex >= 0)
            {
                var row = dgvCart.Rows[e.RowIndex];
                if (int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int qty) &&
                    decimal.TryParse(row.Cells["colPrice"].Value?.ToString(), out decimal price))
                {
                    decimal lineTotal = qty * price;
                    row.Cells["colLineTotal"].Value = lineTotal.ToString("0.00");
                }
                else
                {
                    row.Cells["colLineTotal"].Value = "";
                }
            }
        }




















        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void LNBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["colQuantity"].Index && e.RowIndex >= 0)
            {
                var row = dgvCart.Rows[e.RowIndex];

                if (int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int qty) &&
                    decimal.TryParse(row.Cells["colPrice"].Value?.ToString(), out decimal price))
                {
                    decimal lineTotal = qty * price;
                    row.Cells["colLineTotal"].Value = lineTotal.ToString("0.00");
                }
                else
                {
                    row.Cells["colLineTotal"].Value = "";
                }
            }
        }

        private void btnCalculateTotal_Click(object sender, EventArgs e)
        {
            decimal grandTotal = 0;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["colLineTotal"].Value != null &&
                    decimal.TryParse(row.Cells["colLineTotal"].Value.ToString(), out decimal lineTotal))
                {
                    grandTotal += lineTotal;
                }
            }

            // Apply discount if any
            decimal discountPercent = 0;
            if (!string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                if (decimal.TryParse(txtDiscount.Text, out decimal discountInput))
                {
                    discountPercent = discountInput / 100m;
                }
            }

            decimal discountedTotal = grandTotal * (1 - discountPercent);

            lblTotal.Text = $"Total: R {discountedTotal:F2}";
        }

        private void SaveInvoiceToDatabase()
        {
            decimal total = 0;
            decimal.TryParse(lblTotal.Text.Replace("Total: R", "").Trim(), out total);
            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text, out discount);

            //Insert Invoice and get generated InvoiceID
            int customerId = Convert.ToInt32(cbCustomers.SelectedValue);
            int invoiceId = Convert.ToInt32(invoiceTableAdapter1.InsertThis(customerId, DateTime.Now, total, discount));

            // Insert each item
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.IsNewRow) continue;

                string productName = row.Cells["colProductName"].Value?.ToString();
                var productRow = wstGrp14DataSet.Product.FirstOrDefault(prod => prod.Name == productName);

                int productId = productRow?.ProductID ?? 0;

                if (productId == 0)
                {
                    MessageBox.Show($"Invalid product: {productName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }


                int quantity = int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int q) ? q : 0;
                decimal price = decimal.TryParse(row.Cells["colPrice"].Value?.ToString(), out decimal p) ? p : 0;

                invoiceItemTableAdapter.Insert(invoiceId, productId, quantity, price);

            }

            MessageBox.Show("Invoice saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["colQuantity"].Value = null;
                    row.Cells["colLineTotal"].Value = null;
                }
            }

            lblTotal.Text = "Total: R 0.00";
            txtDiscount.Text = "";


        }

        private void SaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCustomerSale.SelectedIndex == -1 || dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("Please select a customer and ensure the cart has items.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Get Customer ID safely
                int customerId = Convert.ToInt32(cbCustomerSale.SelectedValue);

                // ✅ Parse total from label
                string totalText = lblTotal.Text.Replace("Total: R", "").Trim();
                decimal totalSale = decimal.TryParse(totalText, out decimal parsedTotal) ? parsedTotal : 0;

                // ✅ Insert into Sale table and get SaleID
                object newIdObj = saleTableAdapter1.InsertSaleReturnID(customerId, totalSale, DateTime.Now);
                int saleId = (newIdObj != null && int.TryParse(newIdObj.ToString(), out int sId)) ? sId : 0;

                if (saleId == 0)
                {
                    MessageBox.Show("Failed to retrieve Sale ID after insert.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Loop and insert SaleItems
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.IsNewRow) continue;

                    string productName = row.Cells["colProductName"].Value?.ToString()?.Trim();
                    string quantityStr = row.Cells["colQuantity"].Value?.ToString()?.Trim();
                    string priceStr = row.Cells["colPrice"].Value?.ToString()?.Trim();

                    // ❌ Skip if quantity is missing or 0
                    if (string.IsNullOrWhiteSpace(quantityStr) || quantityStr == "0") continue;
                    if (!int.TryParse(quantityStr, out int quantity) || quantity <= 0) continue;
                    if (!decimal.TryParse(priceStr, out decimal price) || price <= 0) continue;

                    // ✅ Get ProductID using updated GetProductIDByName
                    object productIdObj = productTableAdapter.GetProductIDByName(productName);
                    if (productIdObj == null)
                    {
                        MessageBox.Show($"Product not found: {productName}", "Missing Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    int productId = Convert.ToInt32(productIdObj);

                    // ✅ Insert into SaleItem table
                    saleItemTableAdapter1.InsertSaleItem(saleId, productId, quantity, price);
                }

                MessageBox.Show("Sale saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCart.Rows.Clear();
                lblTotal.Text = "Total: R0.00";
                LoadSales(); // Reload to reflect the new sale
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save sale: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSales()
        {
            
            try
            {
                // Load from SaleTableAdapter into your DataGridView
                dgvSale.DataSource = saleTableAdapter1.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load sales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAppointments_CellMouseEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dgv = sender as DataGridView;

                
                int customerIdColIndex = 1; 
                int staffIdColIndex = 2;   

                string tooltipText = "";

                if (e.ColumnIndex == customerIdColIndex)
                {
                    var value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (value == null) return;

                    int customerId = Convert.ToInt32(value);
                    var customer = wstGrp14DataSet.Customer.FirstOrDefault(c => c.CustomerID == customerId);
                    tooltipText = customer != null ? $"{customer.FirstName} {customer.LastName}" : "Unknown Customer";
                }
                else if (e.ColumnIndex == staffIdColIndex)
                {
                    var value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (value == null) return;

                    int staffId = Convert.ToInt32(value);
                    var staff = wstGrp14DataSet.Staff.FirstOrDefault(s => s.StaffID == staffId);
                    tooltipText = staff != null ? $"{staff.FirstName} {staff.LastName}" : "Unknown Staff";
                }

                if (!string.IsNullOrEmpty(tooltipText))
                {
                    dgvToolTip.SetToolTip(dgv, tooltipText);
                }
                else
                {
                    dgvToolTip.Hide(dgv);
                }
            }

        }

        private void DgvAppointments_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dgvAppointments.Rows[e.RowIndex];
                int customerIdColIndex = 1; 
                int staffIdColIndex = 2;    

                if (e.ColumnIndex == customerIdColIndex)
                {
                    int customerId = Convert.ToInt32(row.Cells[customerIdColIndex].Value);
                    var customer = wstGrp14DataSet.Customer.FirstOrDefault(c => c.CustomerID == customerId);
                    e.ToolTipText = customer != null ? $"{customer.FirstName} {customer.LastName}" : "Unknown Customer";
                }
                else if (e.ColumnIndex == staffIdColIndex)
                {
                    int staffId = Convert.ToInt32(row.Cells[staffIdColIndex].Value);
                    var staff = wstGrp14DataSet.Staff.FirstOrDefault(s => s.StaffID == staffId);
                    e.ToolTipText = staff != null ? $"{staff.FirstName} {staff.LastName}" : "Unknown Staff";
                }
            }
        }

        private void btnSaveFeedback_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                try
                {
                    int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);
                    string newComment = txtCommentFeedback.Text.Trim();
                    int newRating = (int)numRatingFeedback.Value;

                    appointmentTableAdapter1.UpdateCommentAndRating(newComment, newRating, appointmentId);

                    LoadAppointments(); // Refresh the DataGridView
                    MessageBox.Show("Feedback updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update feedback: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }











        // my addition to Customer tab
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                int customerId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["CustomerID"].Value);
                string customerName = dataGridView2.CurrentRow.Cells["CustomerName"].Value.ToString();

                lblCustomerHeader.Text = $"Appointment History for {customerName} (ID: {customerId})";

                LoadAppointmentHistory(customerId);
            }
        }

        private void LoadAppointmentHistory(int customerId)
        {
            var historyData = appointmentTableAdapter1.GetHistoryByCustomerID(customerId);
            dgvAppointmentHistory.DataSource = historyData;
            if (dgvAppointmentHistory.Columns.Contains("Duration"))
            {
                dgvAppointmentHistory.Columns["Duration"].Visible = false;
            }
        }

       

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get selected customer info
                var row = dataGridView2.Rows[e.RowIndex];
                int customerId = Convert.ToInt32(row.Cells["customerIDDataGridViewTextBoxColumn"].Value); // or use index
                string customerName = row.Cells["firstNameDataGridViewTextBoxColumn"].Value?.ToString(); // adjust column name

                // Set header label
                lblCustomerHeader.Text = $"{customerName} ({customerId})";

                // Fill appointment history grid
                var historyData = appointmentTableAdapter1.GetHistoryByCustomerID(customerId);
                dgvAppointmentHistory.DataSource = historyData;
            }



            if (dataGridView2.CurrentRow != null)
            {
                int customerId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["customerIDDataGridViewTextBoxColumn"].Value);
                LoadSalesHistory(customerId);
            }
        }


        private void LoadSalesHistory(int customerId)
        {
            try
            {
                var salesData = saleTableAdapter1.GetDataByCustomerID(customerId); // You may need to create this query
                dgvSalesHistory.DataSource = salesData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load sales history:\n" + ex.Message);
            }
        }


        private void dgvSalesHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSalesHistory.Rows[e.RowIndex];
                int saleId = Convert.ToInt32(row.Cells["SaleID"].Value);

                var items = saleItemTableAdapter1.GetDataBySaleID(saleId);
                dgvSaleItems.DataSource = items;
            }
        }






        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (tabControl5.SelectedTab == tabPage10)
            {
                
                button13.Text = "Update or Delete Service";
                tabControl5.SelectedTab = tabPage9;

            }
            else
            {
                button13.Text = "Add new Service";
                tabControl5.SelectedTab = tabPage10;

            }
        }

        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }
        }

        private void PNBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PNBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void PNBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }
        }

        private void NumberPhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }

        }

        private void PhoneNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore key press
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}

