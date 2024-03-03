namespace DARK_CHEMBER
{
    partial class UC_Update_Delete_Password
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
            this.delete_Button = new Guna.UI2.WinForms.Guna2Button();
            this.update_Button = new Guna.UI2.WinForms.Guna2Button();
            this.background_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // background_panel
            // 
            this.background_panel.BackColor = System.Drawing.Color.Black;
            this.background_panel.Controls.Add(this.delete_Button);
            this.background_panel.Controls.Add(this.update_Button);
            this.background_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background_panel.Location = new System.Drawing.Point(0, 0);
            this.background_panel.Name = "background_panel";
            this.background_panel.Size = new System.Drawing.Size(502, 79);
            this.background_panel.TabIndex = 0;
            // 
            // delete_Button
            // 
            this.delete_Button.BorderRadius = 20;
            this.delete_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.delete_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.delete_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.delete_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.delete_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(57)))), ((int)(((byte)(36)))));
            this.delete_Button.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.delete_Button.ForeColor = System.Drawing.Color.White;
            this.delete_Button.Location = new System.Drawing.Point(32, 19);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(141, 40);
            this.delete_Button.TabIndex = 1;
            this.delete_Button.Text = "DELETE";
            this.delete_Button.Click += new System.EventHandler(this.delete_Button_Click);
            // 
            // update_Button
            // 
            this.update_Button.BorderRadius = 20;
            this.update_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.update_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.update_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.update_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.update_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(119)))), ((int)(((byte)(36)))));
            this.update_Button.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.update_Button.ForeColor = System.Drawing.Color.White;
            this.update_Button.Location = new System.Drawing.Point(330, 19);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(141, 40);
            this.update_Button.TabIndex = 0;
            this.update_Button.Text = "UPDATE";
            this.update_Button.Click += new System.EventHandler(this.update_Button_Click);
            // 
            // UC_Update_Delete_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.background_panel);
            this.Name = "UC_Update_Delete_Password";
            this.Size = new System.Drawing.Size(502, 79);
            this.background_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel background_panel;
        public Guna.UI2.WinForms.Guna2Button update_Button;
        public Guna.UI2.WinForms.Guna2Button delete_Button;
    }
}
