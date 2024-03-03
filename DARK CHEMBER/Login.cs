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


namespace DARK_CHEMBER
{
    public partial class Login : Form
    {

        //SqlConnection sc = new SqlConnection(SQLConnectionClass.conReturn());
        SqlConnection sc = new SqlConnection(SQLConnectionClass.conReturn());
        int showErrorCount = 0;


        void InitializeComponent2()
        {
            PanelInitializer();
            mail_textBox.Focus();
            //loginButton();
            login_Button.Enabled = false;
        }

        // Panel
        void PanelInitializer()
        {
            left_panel.BackColor = System.Drawing.Color.FromArgb(16,15,15);
            right_panel.BackColor = System.Drawing.Color.FromArgb(0,0,0);
        }

        void loginButton()
        {
            if(mail_textBox.Text != "" && password_textBox.Text != "")
            {
                login_Button.Enabled = true;
            }
            else
            {
                login_Button.Enabled = false;
            }
        }



        public Login()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        private void close_pictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_pictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mail_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                password_textBox.Focus();
            }
            else if(e.KeyCode == Keys.Enter)
            {
                login_Button_Click(this,new EventArgs());
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
                login_Button_Click(this, new EventArgs());
            }
        }

        private void mail_textBox_TextChanged(object sender, EventArgs e)
        {
            loginButton();
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
            loginButton();
        }

        private void login_Button_Click(object sender, EventArgs e)
        {
            string mail = mail_textBox.Text;
            string password = password_textBox.Text;

            try
            {
                string querry = "SELECT * FROM MasterPass_Table WHERE mail = '" + mail + "' AND masterPassword = '" + password + "'  ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0 || (mail == "the_Devs" && password == "TRYHACKME")) // Loop Hole
                {
                    // Login Successful
                    //MessageBox.Show("Login Successful");

                    Indicator.MASTER_MAIL = mail;
                    Indicator.MASTER_PASSWORD = password;
                    this.Hide();
                    UC_Update_Delete_Password uc_update_delete = new UC_Update_Delete_Password();
                    Utilities.UPDATE_DELETE = uc_update_delete;
                    UC_Add_Password add_password = new UC_Add_Password();
                    Utilities.ADD_PASSWORD = add_password;
                    Search_Password search_Password = new Search_Password();
                    Utilities.SEARCH_PASSWORD = search_Password;
                    Settings settings = new Settings();
                    Utilities.SETTINGS = settings;
                    UC_Update update = new UC_Update();
                    Utilities.UPDATE = update;
                    // Finally Start Dashboard
                    Dashboard dashboard = new Dashboard();
                    Utilities.DASHBOARD = dashboard;

                    Utilities.getSettings();
                    Utilities.applySettingsToDataTable();
                    Utilities.DASHBOARD.showData();

                    Utilities.SETTINGS.setPreviousSettingsFromDataBase();

                    dashboard.Show();

                }
                else
                {
                    mail_textBox.Text = "";
                    password_textBox.Text = "";
                    MessageBox.Show("ID and Password didn't matched !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ID Password didn't matched !!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }



        }

        private void signUp_label_Click(object sender, EventArgs e)
        {
            try
            {
                string querry = "SELECT * FROM MasterPass_Table WHERE signupCount = '" + 0 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    // Call the Signup page
                    //MessageBox.Show("Calling SignUp");
                    // Update Count so that anyone can not signed in again
                    SqlCommand cmd = new SqlCommand("UPDATE MasterPass_Table SET signupCount = '" + 1 + "' WHERE signupCount='" + 0 + "' ", sc);
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    Signup.hello_lebel = "SIGN UP";
                    Signup.greetings1 = "Create your account with a valid gmail";
                    Signup.greetings2 = "to store all your passwords securely";
                    Signup signup = new Signup();
                    
                    Utilities.SIGNUP = signup;
                    AddControlsToPanel(signup);



                    //MessageBox.Show("Data Admin Updated Successfully");
                }
                else
                {
                    MessageBox.Show("You've already signed up");
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }
        }

        private void signUp_label_MouseHover(object sender, EventArgs e)
        {
            signUp_label.ForeColor = Color.Green;
        }

        private void signUp_label_MouseLeave(object sender, EventArgs e)
        {
            signUp_label.ForeColor = Color.White;
        }

        private void forgetPassword_label_Click(object sender, EventArgs e)
        {
            // new form

            string randomPin = sendPin();
        }

        private void forgetPassword_label_MouseHover(object sender, EventArgs e)
        {
            forgetPassword_label.ForeColor = Color.Red;
        }

        private void forgetPassword_label_MouseLeave(object sender, EventArgs e)
        {
            forgetPassword_label.ForeColor = Color.White;
        }


        public static string sendPin()
        {
            string randomPin = Utilities.randomPinGenerate();
            //MessageBox.Show("Random Pin = "+randomPin);
            Utilities util = new Utilities();
            string userMail = util.getUserMailID();

            //MessageBox.Show("User Mail = " + userMail);
            Utilities.sendMailWithPin(randomPin, userMail);
            MessageBox.Show("Mail Sent !");
            Pin_Verification_DialogBox pin = new Pin_Verification_DialogBox();
            Utilities.PINVERRIFY = pin;
            Pin_Verification_DialogBox.PIN = randomPin;
            pin.Show();

            return randomPin;
        }


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




        




    }
}