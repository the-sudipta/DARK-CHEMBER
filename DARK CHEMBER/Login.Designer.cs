namespace DARK_CHEMBER
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			background_panel = new Panel();
			right_panel = new Panel();
			panelControls = new Panel();
			forgetPassword_label = new Label();
			signUp_label = new Label();
			label4 = new Label();
			login_Button = new Guna.UI2.WinForms.Guna2Button();
			panel10 = new Panel();
			password_textBox = new TextBox();
			panel9 = new Panel();
			mail_textBox = new TextBox();
			pictureBox5 = new PictureBox();
			panel8 = new Panel();
			pictureBox4 = new PictureBox();
			greetings2_label = new Label();
			greetings1_label = new Label();
			hello_label = new Label();
			panel7 = new Panel();
			panel6 = new Panel();
			left_panel = new Panel();
			panel5 = new Panel();
			panel12 = new Panel();
			panel11 = new Panel();
			pictureBox3 = new PictureBox();
			panel4 = new Panel();
			panel1 = new Panel();
			panel2 = new Panel();
			panel3 = new Panel();
			minimize_pictureBox = new PictureBox();
			pictureBox2 = new PictureBox();
			close_pictureBox = new PictureBox();
			background_panel.SuspendLayout();
			right_panel.SuspendLayout();
			panelControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			left_panel.SuspendLayout();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)minimize_pictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)close_pictureBox).BeginInit();
			SuspendLayout();
			// 
			// background_panel
			// 
			background_panel.BackColor = Color.Black;
			background_panel.Controls.Add(right_panel);
			background_panel.Controls.Add(left_panel);
			background_panel.Controls.Add(panel2);
			background_panel.Dock = DockStyle.Fill;
			background_panel.Location = new Point(0, 0);
			background_panel.Name = "background_panel";
			background_panel.Size = new Size(1551, 985);
			background_panel.TabIndex = 0;
			// 
			// right_panel
			// 
			right_panel.BackColor = Color.Silver;
			right_panel.Controls.Add(panelControls);
			right_panel.Controls.Add(greetings2_label);
			right_panel.Controls.Add(greetings1_label);
			right_panel.Controls.Add(hello_label);
			right_panel.Controls.Add(panel7);
			right_panel.Controls.Add(panel6);
			right_panel.Dock = DockStyle.Fill;
			right_panel.Location = new Point(569, 46);
			right_panel.Name = "right_panel";
			right_panel.Size = new Size(982, 939);
			right_panel.TabIndex = 3;
			// 
			// panelControls
			// 
			panelControls.Controls.Add(forgetPassword_label);
			panelControls.Controls.Add(signUp_label);
			panelControls.Controls.Add(label4);
			panelControls.Controls.Add(login_Button);
			panelControls.Controls.Add(panel10);
			panelControls.Controls.Add(password_textBox);
			panelControls.Controls.Add(panel9);
			panelControls.Controls.Add(mail_textBox);
			panelControls.Controls.Add(pictureBox5);
			panelControls.Controls.Add(panel8);
			panelControls.Controls.Add(pictureBox4);
			panelControls.Dock = DockStyle.Left;
			panelControls.Location = new Point(329, 329);
			panelControls.Name = "panelControls";
			panelControls.Size = new Size(695, 610);
			panelControls.TabIndex = 8;
			// 
			// forgetPassword_label
			// 
			forgetPassword_label.AutoSize = true;
			forgetPassword_label.Cursor = Cursors.Hand;
			forgetPassword_label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			forgetPassword_label.ForeColor = Color.White;
			forgetPassword_label.Location = new Point(453, 289);
			forgetPassword_label.Name = "forgetPassword_label";
			forgetPassword_label.Size = new Size(117, 20);
			forgetPassword_label.TabIndex = 10;
			forgetPassword_label.Text = "Forget Password";
			forgetPassword_label.Click += forgetPassword_label_Click;
			forgetPassword_label.MouseLeave += forgetPassword_label_MouseLeave;
			forgetPassword_label.MouseHover += forgetPassword_label_MouseHover;
			// 
			// signUp_label
			// 
			signUp_label.AutoSize = true;
			signUp_label.Cursor = Cursors.Hand;
			signUp_label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			signUp_label.ForeColor = Color.White;
			signUp_label.Location = new Point(277, 458);
			signUp_label.Name = "signUp_label";
			signUp_label.Size = new Size(61, 20);
			signUp_label.TabIndex = 9;
			signUp_label.Text = "Sign Up";
			signUp_label.Click += signUp_label_Click;
			signUp_label.MouseLeave += signUp_label_MouseLeave;
			signUp_label.MouseHover += signUp_label_MouseHover;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			label4.ForeColor = Color.White;
			label4.Location = new Point(107, 458);
			label4.Name = "label4";
			label4.Size = new Size(170, 20);
			label4.TabIndex = 8;
			label4.Text = "Don't have any account?";
			// 
			// login_Button
			// 
			login_Button.BorderRadius = 22;
			login_Button.Cursor = Cursors.Hand;
			login_Button.DisabledState.BorderColor = Color.DarkGray;
			login_Button.DisabledState.CustomBorderColor = Color.DarkGray;
			login_Button.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			login_Button.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			login_Button.FillColor = Color.FromArgb(0, 192, 0);
			login_Button.FocusedColor = Color.FromArgb(0, 64, 0);
			login_Button.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			login_Button.ForeColor = Color.White;
			login_Button.HoverState.ForeColor = Color.FromArgb(0, 64, 0);
			login_Button.Location = new Point(388, 326);
			login_Button.Name = "login_Button";
			login_Button.Size = new Size(180, 45);
			login_Button.TabIndex = 7;
			login_Button.Text = "Log in";
			login_Button.Click += login_Button_Click;
			// 
			// panel10
			// 
			panel10.BackColor = Color.White;
			panel10.Location = new Point(118, 274);
			panel10.Name = "panel10";
			panel10.Size = new Size(450, 2);
			panel10.TabIndex = 6;
			// 
			// password_textBox
			// 
			password_textBox.BackColor = Color.Black;
			password_textBox.BorderStyle = BorderStyle.None;
			password_textBox.Cursor = Cursors.Hand;
			password_textBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
			password_textBox.ForeColor = Color.White;
			password_textBox.Location = new Point(118, 243);
			password_textBox.Name = "password_textBox";
			password_textBox.PasswordChar = '•';
			password_textBox.Size = new Size(447, 32);
			password_textBox.TabIndex = 5;
			password_textBox.TextChanged += password_textBox_TextChanged;
			password_textBox.KeyUp += password_textBox_KeyUp;
			// 
			// panel9
			// 
			panel9.BackColor = Color.White;
			panel9.Location = new Point(118, 201);
			panel9.Name = "panel9";
			panel9.Size = new Size(450, 2);
			panel9.TabIndex = 4;
			// 
			// mail_textBox
			// 
			mail_textBox.BackColor = Color.Black;
			mail_textBox.BorderStyle = BorderStyle.None;
			mail_textBox.Cursor = Cursors.Hand;
			mail_textBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
			mail_textBox.ForeColor = Color.White;
			mail_textBox.Location = new Point(118, 170);
			mail_textBox.Name = "mail_textBox";
			mail_textBox.Size = new Size(447, 32);
			mail_textBox.TabIndex = 3;
			mail_textBox.TextChanged += mail_textBox_TextChanged;
			mail_textBox.KeyDown += mail_textBox_KeyDown;
			// 
			// pictureBox5
			// 
			pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
			pictureBox5.Location = new Point(76, 238);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new Size(29, 38);
			pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox5.TabIndex = 2;
			pictureBox5.TabStop = false;
			// 
			// panel8
			// 
			panel8.Dock = DockStyle.Left;
			panel8.Location = new Point(0, 0);
			panel8.Name = "panel8";
			panel8.Size = new Size(65, 610);
			panel8.TabIndex = 1;
			// 
			// pictureBox4
			// 
			pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
			pictureBox4.Location = new Point(71, 174);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new Size(39, 28);
			pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox4.TabIndex = 0;
			pictureBox4.TabStop = false;
			// 
			// greetings2_label
			// 
			greetings2_label.AutoSize = true;
			greetings2_label.Dock = DockStyle.Top;
			greetings2_label.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			greetings2_label.ForeColor = Color.White;
			greetings2_label.Location = new Point(329, 309);
			greetings2_label.Name = "greetings2_label";
			greetings2_label.Size = new Size(359, 20);
			greetings2_label.TabIndex = 7;
			greetings2_label.Text = "               to get all your passwords in  dark chember";
			// 
			// greetings1_label
			// 
			greetings1_label.AutoSize = true;
			greetings1_label.Dock = DockStyle.Top;
			greetings1_label.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			greetings1_label.ForeColor = Color.White;
			greetings1_label.Location = new Point(329, 289);
			greetings1_label.Name = "greetings1_label";
			greetings1_label.Size = new Size(277, 20);
			greetings1_label.TabIndex = 6;
			greetings1_label.Text = "               Welcome back ! Log in to your";
			// 
			// hello_label
			// 
			hello_label.AutoSize = true;
			hello_label.Dock = DockStyle.Top;
			hello_label.Font = new Font("Showcard Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point);
			hello_label.ForeColor = Color.WhiteSmoke;
			hello_label.Location = new Point(329, 249);
			hello_label.Name = "hello_label";
			hello_label.Size = new Size(315, 40);
			hello_label.TabIndex = 5;
			hello_label.Text = "        HELLO THERE !";
			// 
			// panel7
			// 
			panel7.BackColor = Color.Black;
			panel7.Dock = DockStyle.Left;
			panel7.Location = new Point(0, 249);
			panel7.Name = "panel7";
			panel7.Size = new Size(329, 690);
			panel7.TabIndex = 1;
			// 
			// panel6
			// 
			panel6.Dock = DockStyle.Top;
			panel6.Location = new Point(0, 0);
			panel6.Name = "panel6";
			panel6.Size = new Size(982, 249);
			panel6.TabIndex = 0;
			// 
			// left_panel
			// 
			left_panel.BackColor = Color.Gray;
			left_panel.Controls.Add(panel5);
			left_panel.Controls.Add(panel4);
			left_panel.Controls.Add(panel1);
			left_panel.Dock = DockStyle.Left;
			left_panel.Location = new Point(0, 46);
			left_panel.Name = "left_panel";
			left_panel.Size = new Size(569, 939);
			left_panel.TabIndex = 2;
			// 
			// panel5
			// 
			panel5.Controls.Add(panel12);
			panel5.Controls.Add(panel11);
			panel5.Controls.Add(pictureBox3);
			panel5.Dock = DockStyle.Left;
			panel5.Location = new Point(0, 210);
			panel5.Name = "panel5";
			panel5.Size = new Size(569, 519);
			panel5.TabIndex = 3;
			// 
			// panel12
			// 
			panel12.Dock = DockStyle.Left;
			panel12.Location = new Point(0, 0);
			panel12.Name = "panel12";
			panel12.Size = new Size(38, 519);
			panel12.TabIndex = 2;
			// 
			// panel11
			// 
			panel11.Dock = DockStyle.Right;
			panel11.Location = new Point(530, 0);
			panel11.Name = "panel11";
			panel11.Size = new Size(39, 519);
			panel11.TabIndex = 1;
			// 
			// pictureBox3
			// 
			pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
			pictureBox3.Location = new Point(44, 0);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(480, 519);
			pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 0;
			pictureBox3.TabStop = false;
			// 
			// panel4
			// 
			panel4.Dock = DockStyle.Bottom;
			panel4.Location = new Point(0, 729);
			panel4.Name = "panel4";
			panel4.Size = new Size(569, 210);
			panel4.TabIndex = 2;
			// 
			// panel1
			// 
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(569, 210);
			panel1.TabIndex = 1;
			// 
			// panel2
			// 
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(panel3);
			panel2.Dock = DockStyle.Top;
			panel2.Location = new Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new Size(1551, 46);
			panel2.TabIndex = 0;
			// 
			// panel3
			// 
			panel3.Controls.Add(minimize_pictureBox);
			panel3.Controls.Add(pictureBox2);
			panel3.Controls.Add(close_pictureBox);
			panel3.Dock = DockStyle.Right;
			panel3.Location = new Point(1420, 0);
			panel3.Name = "panel3";
			panel3.Padding = new Padding(0, 5, 10, 5);
			panel3.Size = new Size(129, 44);
			panel3.TabIndex = 1;
			// 
			// minimize_pictureBox
			// 
			minimize_pictureBox.BackColor = Color.Black;
			minimize_pictureBox.Cursor = Cursors.Hand;
			minimize_pictureBox.Dock = DockStyle.Left;
			minimize_pictureBox.Image = (Image)resources.GetObject("minimize_pictureBox.Image");
			minimize_pictureBox.Location = new Point(0, 5);
			minimize_pictureBox.Name = "minimize_pictureBox";
			minimize_pictureBox.Size = new Size(36, 34);
			minimize_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			minimize_pictureBox.TabIndex = 2;
			minimize_pictureBox.TabStop = false;
			minimize_pictureBox.Click += minimize_pictureBox_Click;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new Point(42, 5);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(36, 34);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 0;
			pictureBox2.TabStop = false;
			// 
			// close_pictureBox
			// 
			close_pictureBox.Cursor = Cursors.Hand;
			close_pictureBox.Dock = DockStyle.Right;
			close_pictureBox.Image = (Image)resources.GetObject("close_pictureBox.Image");
			close_pictureBox.Location = new Point(83, 5);
			close_pictureBox.Name = "close_pictureBox";
			close_pictureBox.Size = new Size(36, 34);
			close_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			close_pictureBox.TabIndex = 1;
			close_pictureBox.TabStop = false;
			close_pictureBox.Click += close_pictureBox_Click;
			// 
			// Login
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1551, 985);
			Controls.Add(background_panel);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "Login";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Login";
			WindowState = FormWindowState.Maximized;
			background_panel.ResumeLayout(false);
			right_panel.ResumeLayout(false);
			right_panel.PerformLayout();
			panelControls.ResumeLayout(false);
			panelControls.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			left_panel.ResumeLayout(false);
			panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			panel2.ResumeLayout(false);
			panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)minimize_pictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)close_pictureBox).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel background_panel;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox2;
        private PictureBox close_pictureBox;
        private PictureBox minimize_pictureBox;
        private Panel left_panel;
        private Panel right_panel;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel11;
        private Panel panel12;
        private Panel panel7;
        public Panel panelControls;
        private Label forgetPassword_label;
        private Label signUp_label;
        private Label label4;
        private Guna.UI2.WinForms.Guna2Button login_Button;
        private Panel panel10;
        private TextBox password_textBox;
        private Panel panel9;
        private TextBox mail_textBox;
        private PictureBox pictureBox5;
        private Panel panel8;
        private PictureBox pictureBox4;
        public Label greetings2_label;
        public Label greetings1_label;
        public Label hello_label;
    }
}