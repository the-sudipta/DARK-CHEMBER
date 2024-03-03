using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DARK_CHEMBER
{
    public partial class Pin_Verification_DialogBox : Form
    {

        public static string PIN; 


        private void InitializeComponent2()
        {
            PanelInitializer();
            password_textBox.Focus();
            password_textBox.MaxLength = 14;
            next_Button.Enabled = false;
        }

        public Pin_Verification_DialogBox()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        void PanelInitializer()
        {
            left_panel.BackColor = System.Drawing.Color.FromArgb(16, 15, 15);
        }



        private void close_pictureBox_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void next_Button_Click(object sender, EventArgs e)
        {
            if(password_textBox.Text == PIN)
            {
                // Call Sign UP page again just mail textBox is locked
                this.Hide();
                //MessageBox.Show("PIN MATCHED !!!");
                Signup signup = new Signup();
                signup.mail_textBox.Enabled = false;
                signup.mail_textBox.Text = "You can not change mail right now";
                signup.signup_Button.Text = "Update";
                Utilities.SIGNUP = signup;
               
                Utilities.tempLOGIN.hello_label.Text = "CHANGE MASTER PASSWORD";
                Utilities.tempLOGIN.greetings1_label.Text = "To change your gmail id";
                Utilities.tempLOGIN.greetings2_label.Text = "you've to login first";
                Utilities.tempLOGIN.AddControlsToPanel(signup);
                //Login login = new Login();
                //login.Show();

            }
            else
            {
                MessageBox.Show("WRONG PIN !!!");
                password_textBox.Text = "";
            }
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
            if(password_textBox.TextLength == 6)
            {
                next_Button.Enabled = true;
            }
        }

        private void password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (next_Button.Enabled)
                {
                    next_Button_Click(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("The pin code has 6 digits !!");
                }
            }
        }


        public void AddControlsToPanel(Control c) // This Will Help to add the User Controls on the specific panel (Here Named panelControls)
        {
            if (c != null)
            {
                // Set The specific panel to the position where it will show up whenever that specific button will be clicked
               Utilities.tempLOGIN.panelControls.Controls.Clear(); // Clearing Previous UserConrtols
                c.Dock = DockStyle.Fill;
                c.BringToFront();
                c.Focus();
                Utilities.tempLOGIN.Controls.Add(c);
            }
        }










    }
}
