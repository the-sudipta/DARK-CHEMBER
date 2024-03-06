using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DARK_CHEMBER
{
    public partial class Signup : UserControl
    {

        #region Color
        Color ashColor = Color.FromArgb(78, 82, 79);
        Color WHITE = Color.FromArgb(235, 237, 236);
        Color BLACK = Color.FromArgb(0, 0, 0);
        #endregion Color

        #region Font
        Font textHintFont = new Font("Segoe UI", 14);
        Font textFont = new Font("Segoe UI", 18);
        #endregion Font

        public static string hello_lebel, greetings1, greetings2;
		//MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());  // Connection String


		private void InitializeComponent2() // Custom Constructor
        {
            // Initialize Panel
            panelControls.BackColor = BLACK;
            signupDecoration();
            setHint(); // Setting inline hints
            signup_Button.Enabled = false;

        }


        public Signup() // Main Constructor
        {
            InitializeComponent();
            InitializeComponent2();
        }


        #region My Methods
        
        public void AddControlsToPanel(Control c) // This Will Help to add the User Controls on the specific panel (Here Named panelControls)
        {
            if (c != null)
            {
                // Set The specific panel to the position where it will show up whenever that specific button will be clicked
                panelControls.Controls.Clear(); // Clearing Previous UserConrtols
                c.Dock = DockStyle.Fill;
                c.BringToFront();
                c.Focus();
                panelControls.Controls.Add(c);
            }
        }

        private void signupDecoration()
        {
            Utilities.tempLOGIN.hello_label.Text = hello_lebel;
            Utilities.tempLOGIN.greetings1_label.Text = greetings1;
            Utilities.tempLOGIN.greetings2_label.Text = greetings2;
        }


        private void setHint()
        {
            mail_textBox.ForeColor = ashColor;
            mail_textBox.Font = textHintFont;

            password_textBox.ForeColor = ashColor;
            password_textBox.Font = textHintFont;

            ConfirmPass_textBox.ForeColor = ashColor;
            ConfirmPass_textBox.Font = textHintFont;
        }


        private void mail_textBox_Enter(object sender, EventArgs e)
        {
            if (mail_textBox.Text == "Enter your gmail ID")
            {
                mail_textBox.Text = "";
                mail_textBox.ForeColor = WHITE;
                mail_textBox.Font = textHintFont;
            }
        }

        private void mail_textBox_Leave(object sender, EventArgs e)
        {
            if (mail_textBox.Text == "")
            {
                mail_textBox.Text = "Enter your gmail ID";
                mail_textBox.ForeColor = ashColor;
                mail_textBox.Font = textFont;
            }
        }

        private void password_textBox_Enter(object sender, EventArgs e)
        {
            if (password_textBox.Text == "Enter new password")
            {
                password_textBox.Text = "";
                password_textBox.ForeColor = WHITE;
                password_textBox.Font = textHintFont;
            }
        }

        private void password_textBox_Leave(object sender, EventArgs e)
        {
            if (password_textBox.Text == "")
            {
                password_textBox.Text = "Enter new password";
                password_textBox.ForeColor = ashColor;
                password_textBox.Font = textFont;
            }
        }

        private void ConfirmPass_textBox_Enter(object sender, EventArgs e)
        {
            if (ConfirmPass_textBox.Text == "Confirm your password")
            {
                ConfirmPass_textBox.Text = "";
                ConfirmPass_textBox.ForeColor = WHITE;
                ConfirmPass_textBox.Font = textHintFont;
            }
        }

        private void ConfirmPass_textBox_Leave(object sender, EventArgs e)
        {
            if (ConfirmPass_textBox.Text == "")
            {
                ConfirmPass_textBox.Text = "Confirm your password";
                ConfirmPass_textBox.ForeColor = ashColor;
                ConfirmPass_textBox.Font = textFont;
            }
        }

        private void storeData()
        {
            if (password_textBox.Text == ConfirmPass_textBox.Text)
            {
                if (mail_textBox.Text.Contains("@gmail.com"))
                {
                    // Send data to the Master password !
                    signup_Button.Enabled = false;
                   
                    Utilities util = new Utilities();
                    //MessageBox.Show("Signup Page\n mail = " + mail_textBox.Text + "\n Pass = " + password_textBox.Text);
                    util.insertSignUpData(mail_textBox.Text, password_textBox.Text);


                    //MessageBox.Show("Signup Cpmpleted !");
                    this.Hide();
                    Login login = new Login();
                    Utilities.LOGIN = login;
                    Utilities.tempLOGIN.Hide();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("You must use a valid gmail account !!");
                }
            }
            else
            {
                MessageBox.Show("Confirm password didn't matched");
            }

        }

        private bool checkSignupAvailability()
        {
            if (mail_textBox.Text != "Enter your gmail ID" && password_textBox.Text != "Enter new password" && ConfirmPass_textBox.Text != "Confirm your password" )
            {
                signup_Button.Enabled = true;
                return true;
            }
            else if(signup_Button.Text == "Update")
            {
                if(password_textBox.Text != "Enter new password" && ConfirmPass_textBox.Text != "Confirm your password")
                {
                    signup_Button.Enabled = true;
                    return true;
                }
            }
            return false;
        }


        private void mail_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                password_textBox.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (checkSignupAvailability())
                {
                    storeData();
                }
                else
                {
                    MessageBox.Show("Fill up all the informations");
                }
            }
        }

        private void password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ConfirmPass_textBox.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (signup_Button.Text == "Sign Up")
                {
                    if (checkSignupAvailability())
                    {
                        storeData();
                    }
                    else
                    {
                        MessageBox.Show("Fill up all the informations");
                    }
                }
                else if (signup_Button.Text == "Update")
                {

                    if (checkSignupAvailability() && (password_textBox.Text == ConfirmPass_textBox.Text))
                    {
                        // Update the data to master password
                        signup_Button.Enabled = false;
                        // Update the Password
                        Utilities util = new Utilities();
                        util.insertForgetPassData(password_textBox.Text);
                        MessageBox.Show("Password Updated");
                        this.Hide();
                        Login login = new Login();
                        Utilities.LOGIN = login;
                        Utilities.tempLOGIN.Hide();
                        login.Show();
                    }

                }
            }


        }

        private void password_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                mail_textBox.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (signup_Button.Text == "Sign Up")
                {
                    if (checkSignupAvailability())
                    {
                        storeData();
                    }
                    else
                    {
                        MessageBox.Show("Fill up all the informations");
                    }
                }
                else if (signup_Button.Text == "Update")
                {

                    if (checkSignupAvailability() && (password_textBox.Text == ConfirmPass_textBox.Text))
                    {
                        // Update the data to master password
                        signup_Button.Enabled = false;
                        // Update the Password
                        Utilities util = new Utilities();
                        util.insertForgetPassData(password_textBox.Text);
                        MessageBox.Show("Password Updated");
                        this.Hide();
                        Login login = new Login();
                        Utilities.LOGIN = login;
                        Utilities.tempLOGIN.Hide();
                        login.Show();
                    }

                }
            }
        }

        private void ConfirmPass_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                password_textBox.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (signup_Button.Text == "Sign Up")
                {
                    if (checkSignupAvailability())
                    {
                        storeData();
                    }
                    else
                    {
                        MessageBox.Show("Fill up all the informations");
                    }
                }
                else if (signup_Button.Text == "Update")
                {

                    if (checkSignupAvailability() && (password_textBox.Text == ConfirmPass_textBox.Text))
                    {
                        // Update the data to master password
                        signup_Button.Enabled = false;
                        // Update the Password
                        Utilities util = new Utilities();
                        util.insertForgetPassData(password_textBox.Text);
                        MessageBox.Show("Password Updated");
                        this.Hide();
                        Login login = new Login();
                        Utilities.LOGIN = login;
                        Utilities.tempLOGIN.Hide();
                        login.Show();
                    }
                    
                }
            }
        }










        #endregion My Methods

        private void mail_textBox_TextChanged(object sender, EventArgs e)
        {
            checkSignupAvailability();
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
            checkSignupAvailability();
        }

        private void ConfirmPass_textBox_TextChanged(object sender, EventArgs e)
        {
            checkSignupAvailability();
        }

        private void signup_Button_Click(object sender, EventArgs e)
        {
            if(signup_Button.Text == "Sign Up")
            {
                if (checkSignupAvailability())
                {
                    storeData();
                }
                else
                {
                    MessageBox.Show("Fill up all the informations");
                }
            }
            else if(signup_Button.Text == "Update")
            {
                
                if (checkSignupAvailability() && (password_textBox.Text == ConfirmPass_textBox.Text ))
                {
                    // Update the data to master password
                    signup_Button.Enabled = false;
                    // Update the Password
                    Utilities util = new Utilities();
                    util.insertForgetPassData(password_textBox.Text);


                    MessageBox.Show("Password Updated");
                    this.Hide();
                    Login login = new Login();
                    Utilities.LOGIN = login;
                    Utilities.tempLOGIN.Hide();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Confirm Password didn't matched !");
                }
            }
        }
    }
}
