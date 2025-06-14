namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CodeBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.SendEmailbutton = new System.Windows.Forms.Button();
            this.VerifyCodebutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.VerifyPassbutton = new System.Windows.Forms.Button();
            this.VerifyPasswordBox = new System.Windows.Forms.TextBox();
            this.EnterNewPassBox = new System.Windows.Forms.TextBox();
            this.EnterUsernameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.wstGrp14DataSet = new WindowsFormsApp1.WstGrp14DataSet();
            this.staffTableAdapter = new WindowsFormsApp1.WstGrp14DataSetTableAdapters.StaffTableAdapter();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SignInbutton = new System.Windows.Forms.Button();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wstGrp14DataSet)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(687, 480);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SeaShell;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.CodeBox);
            this.tabPage2.Controls.Add(this.EmailBox);
            this.tabPage2.Controls.Add(this.SendEmailbutton);
            this.tabPage2.Controls.Add(this.VerifyCodebutton);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Font = new System.Drawing.Font("Harrington", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(679, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // CodeBox
            // 
            this.CodeBox.Location = new System.Drawing.Point(237, 331);
            this.CodeBox.Margin = new System.Windows.Forms.Padding(2);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(275, 32);
            this.CodeBox.TabIndex = 5;
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(237, 200);
            this.EmailBox.Margin = new System.Windows.Forms.Padding(2);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(275, 32);
            this.EmailBox.TabIndex = 4;
            // 
            // SendEmailbutton
            // 
            this.SendEmailbutton.Location = new System.Drawing.Point(324, 266);
            this.SendEmailbutton.Margin = new System.Windows.Forms.Padding(2);
            this.SendEmailbutton.Name = "SendEmailbutton";
            this.SendEmailbutton.Size = new System.Drawing.Size(88, 35);
            this.SendEmailbutton.TabIndex = 3;
            this.SendEmailbutton.Text = "Send Email";
            this.SendEmailbutton.UseVisualStyleBackColor = true;
            this.SendEmailbutton.Click += new System.EventHandler(this.button3_Click);
            // 
            // VerifyCodebutton
            // 
            this.VerifyCodebutton.Location = new System.Drawing.Point(317, 389);
            this.VerifyCodebutton.Margin = new System.Windows.Forms.Padding(2);
            this.VerifyCodebutton.Name = "VerifyCodebutton";
            this.VerifyCodebutton.Size = new System.Drawing.Size(95, 36);
            this.VerifyCodebutton.TabIndex = 2;
            this.VerifyCodebutton.Text = "Verify Code";
            this.VerifyCodebutton.UseVisualStyleBackColor = true;
            this.VerifyCodebutton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(65, 334);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Enter Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(58, 203);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Enter Email:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SeaShell;
            this.tabPage3.Controls.Add(this.VerifyPassbutton);
            this.tabPage3.Controls.Add(this.VerifyPasswordBox);
            this.tabPage3.Controls.Add(this.EnterNewPassBox);
            this.tabPage3.Controls.Add(this.EnterUsernameBox);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(679, 454);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // VerifyPassbutton
            // 
            this.VerifyPassbutton.Location = new System.Drawing.Point(191, 223);
            this.VerifyPassbutton.Margin = new System.Windows.Forms.Padding(2);
            this.VerifyPassbutton.Name = "VerifyPassbutton";
            this.VerifyPassbutton.Size = new System.Drawing.Size(91, 19);
            this.VerifyPassbutton.TabIndex = 6;
            this.VerifyPassbutton.Text = "Verify Password";
            this.VerifyPassbutton.UseVisualStyleBackColor = true;
            this.VerifyPassbutton.Click += new System.EventHandler(this.VerifyPassbutton_Click);
            // 
            // VerifyPasswordBox
            // 
            this.VerifyPasswordBox.Location = new System.Drawing.Point(290, 152);
            this.VerifyPasswordBox.Margin = new System.Windows.Forms.Padding(2);
            this.VerifyPasswordBox.Name = "VerifyPasswordBox";
            this.VerifyPasswordBox.Size = new System.Drawing.Size(76, 20);
            this.VerifyPasswordBox.TabIndex = 5;
            // 
            // EnterNewPassBox
            // 
            this.EnterNewPassBox.Location = new System.Drawing.Point(290, 92);
            this.EnterNewPassBox.Margin = new System.Windows.Forms.Padding(2);
            this.EnterNewPassBox.Name = "EnterNewPassBox";
            this.EnterNewPassBox.Size = new System.Drawing.Size(76, 20);
            this.EnterNewPassBox.TabIndex = 4;
            // 
            // EnterUsernameBox
            // 
            this.EnterUsernameBox.Location = new System.Drawing.Point(290, 37);
            this.EnterUsernameBox.Margin = new System.Windows.Forms.Padding(2);
            this.EnterUsernameBox.Name = "EnterUsernameBox";
            this.EnterUsernameBox.Size = new System.Drawing.Size(76, 20);
            this.EnterUsernameBox.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 152);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Verify Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Enter New Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Enter Username:";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Staff";
            this.bindingSource1.DataSource = this.wstGrp14DataSet;
            // 
            // wstGrp14DataSet
            // 
            this.wstGrp14DataSet.DataSetName = "WstGrp14DataSet";
            this.wstGrp14DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // staffTableAdapter
            // 
            this.staffTableAdapter.ClearBeforeFill = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources._360_F_393855516_0BcgVZqNlVrvDE0kiD3YTlVJaur8Q02G;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.SignInbutton);
            this.tabPage1.Controls.Add(this.passwordBox);
            this.tabPage1.Controls.Add(this.usernameBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Harrington", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(679, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Harrington", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox1.Location = new System.Drawing.Point(228, 208);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(214, 33);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Show Password";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Harrington", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(217, 261);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 29);
            this.label8.TabIndex = 12;
            this.label8.Text = "Forgot Password?";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // SignInbutton
            // 
            this.SignInbutton.Font = new System.Drawing.Font("Harrington", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SignInbutton.Location = new System.Drawing.Point(132, 309);
            this.SignInbutton.Margin = new System.Windows.Forms.Padding(2);
            this.SignInbutton.Name = "SignInbutton";
            this.SignInbutton.Size = new System.Drawing.Size(404, 43);
            this.SignInbutton.TabIndex = 11;
            this.SignInbutton.Text = "Sign in";
            this.SignInbutton.UseVisualStyleBackColor = true;
            this.SignInbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(272, 127);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(2);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(264, 26);
            this.passwordBox.TabIndex = 10;
            this.passwordBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(272, 70);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(2);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(264, 26);
            this.usernameBox.TabIndex = 9;
            this.usernameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Harrington", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(120, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Harrington", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(120, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.ChatGPT_Image_Jun_3__2025__08_50_42_AM__2_;
            this.pictureBox1.Location = new System.Drawing.Point(294, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(198, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(249, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Forgot your Password?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Harrington", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(38, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(604, 19);
            this.label10.TabIndex = 8;
            this.label10.Text = "Please enter your email and we will send you a code to reset yourpassword";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 480);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wstGrp14DataSet)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button SignInbutton;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox CodeBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Button SendEmailbutton;
        private System.Windows.Forms.Button VerifyCodebutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button VerifyPassbutton;
        private System.Windows.Forms.TextBox VerifyPasswordBox;
        private System.Windows.Forms.TextBox EnterNewPassBox;
        private System.Windows.Forms.TextBox EnterUsernameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private WstGrp14DataSet wstGrp14DataSet;
        private WstGrp14DataSetTableAdapters.StaffTableAdapter staffTableAdapter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

