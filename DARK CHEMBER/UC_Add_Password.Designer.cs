namespace DARK_CHEMBER
{
    partial class UC_Add_Password
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.background_panel = new System.Windows.Forms.Panel();
            this.generate_password_Button = new Guna.UI2.WinForms.Guna2Button();
            this.insert_Button = new Guna.UI2.WinForms.Guna2Button();
            this.background_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // background_panel
            // 
            this.background_panel.BackColor = System.Drawing.Color.Black;
            this.background_panel.Controls.Add(this.generate_password_Button);
            this.background_panel.Controls.Add(this.insert_Button);
            this.background_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background_panel.Location = new System.Drawing.Point(0, 0);
            this.background_panel.Name = "background_panel";
            this.background_panel.Size = new System.Drawing.Size(502, 79);
            this.background_panel.TabIndex = 0;
            // 
            // generate_password_Button
            // 
            this.generate_password_Button.BorderRadius = 20;
            this.generate_password_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generate_password_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.generate_password_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.generate_password_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.generate_password_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.generate_password_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(123)))), ((int)(((byte)(3)))));
            this.generate_password_Button.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.generate_password_Button.ForeColor = System.Drawing.Color.White;
            this.generate_password_Button.Location = new System.Drawing.Point(48, 18);
            this.generate_password_Button.Name = "generate_password_Button";
            this.generate_password_Button.Size = new System.Drawing.Size(160, 40);
            this.generate_password_Button.TabIndex = 2;
            this.generate_password_Button.Text = "GENERATE PASS";
            this.generate_password_Button.Click += new System.EventHandler(this.generate_password_Button_Click);
            // 
            // insert_Button
            // 
            this.insert_Button.BorderRadius = 20;
            this.insert_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insert_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.insert_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.insert_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.insert_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.insert_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.insert_Button.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.insert_Button.ForeColor = System.Drawing.Color.White;
            this.insert_Button.Location = new System.Drawing.Point(324, 18);
            this.insert_Button.Name = "insert_Button";
            this.insert_Button.Size = new System.Drawing.Size(141, 40);
            this.insert_Button.TabIndex = 1;
            this.insert_Button.Text = "INSERT";
            this.insert_Button.Click += new System.EventHandler(this.insert_Button_Click);
            // 
            // UC_Add_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.background_panel);
            this.Name = "UC_Add_Password";
            this.Size = new System.Drawing.Size(502, 79);
            this.background_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel background_panel;
        public Guna.UI2.WinForms.Guna2Button insert_Button;
        public Guna.UI2.WinForms.Guna2Button generate_password_Button;
    }
}
