namespace DARK_CHEMBER
{
    partial class UC_Update
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
            this.back_panel = new System.Windows.Forms.Panel();
            this.update_Button = new Guna.UI2.WinForms.Guna2Button();
            this.back_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // back_panel
            // 
            this.back_panel.BackColor = System.Drawing.Color.Black;
            this.back_panel.Controls.Add(this.update_Button);
            this.back_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back_panel.Location = new System.Drawing.Point(0, 0);
            this.back_panel.Name = "back_panel";
            this.back_panel.Size = new System.Drawing.Size(657, 86);
            this.back_panel.TabIndex = 0;
            // 
            // update_Button
            // 
            this.update_Button.BorderRadius = 20;
            this.update_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.update_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.update_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.update_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.update_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.update_Button.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.update_Button.ForeColor = System.Drawing.Color.White;
            this.update_Button.Location = new System.Drawing.Point(258, 23);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(141, 40);
            this.update_Button.TabIndex = 2;
            this.update_Button.Text = "UPDATE";
            this.update_Button.Click += new System.EventHandler(this.update_Button_Click);
            // 
            // UC_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.back_panel);
            this.Name = "UC_Update";
            this.Size = new System.Drawing.Size(657, 86);
            this.back_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel back_panel;
        public Guna.UI2.WinForms.Guna2Button update_Button;
    }
}
