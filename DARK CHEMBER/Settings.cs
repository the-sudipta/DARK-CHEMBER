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
    public partial class Settings : Form
    {

        Color updateButtonColor = Color.FromArgb(0, 192, 0);
        Color changeButtonColor = Color.FromArgb(252, 123, 3);


        SqlConnection sc = new SqlConnection(SQLConnectionClass.conReturn());

        private void InitializeComponent2()
        {
            mail_textBox.Text = Indicator.MASTER_MAIL;
            mail_textBox.ReadOnly = true;
            password_textBox.Text = Indicator.MASTER_PASSWORD;
            password_textBox.ReadOnly = true;
            setPreviousSettingsFromDataBase();
        }


        public Settings()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        private void close_pictureBox_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void change_Button_Click(object sender, EventArgs e)
        {
            if(change_Button.Text == "UNLOCK SETTINGS")
            {
                mail_textBox.ReadOnly = false;
                password_textBox.ReadOnly = false;
                

                change_Button.Text = "UPDATE ALL";
                change_Button.BackColor = updateButtonColor;

            }else if(change_Button.Text == "UPDATE ALL")
            {
                #region UPDATE BUTTON CLICKED
                try
                {
                    // MASTER MAIL AND PASSWORD                     
                    SqlCommand cmd = new SqlCommand("UPDATE MasterPass_Table SET " +
                    "mail = '" + Utilities.SETTINGS.mail_textBox.Text + "', " +
                    "masterPassword = '" + Utilities.SETTINGS.password_textBox.Text + "' " +
                    "WHERE " +
                    "mail ='" + Indicator.MASTER_MAIL + "' ", sc);

                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();
                    Indicator.MASTER_MAIL = Utilities.SETTINGS.mail_textBox.Text;
                    Indicator.MASTER_PASSWORD = Utilities.SETTINGS.password_textBox.Text;
                    //MessageBox.Show("New Mail = "+ Utilities.SETTINGS.mail_textBox.Text+"\n"
                    //    +"New Pass = "+ Utilities.SETTINGS.password_textBox.Text+"\n\n"
                    //    + "OLD Mail = " + Indicator.MASTER_MAIL + "\n"
                    //    + "OLD Pass = " + Indicator.MASTER_PASSWORD);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't Update because of some technical error");
                    MessageBox.Show("MasterPass Error = "+ex.Message);
                    //MessageBox.Show("Error = "+ ex.Message);
                    Console.WriteLine(ex.Message);
                }


                // DISPLAY SETTINGS








                updateDisplayCheckBoxDecisions();
                updatePasswordCheckBoxDecisions();


                //"SELECT displaySiteLink, displaySiteName, displayMail, displayUsername,
                //displayPassword, useSmallAlphabets, useCapitalAlphabets, useNumbers, useSpecialChar
                //FROM Settings_Table Where indicator = '" + 1 + "' ", sc);




                try
                {
                    // CheckBox Settings
                    SqlCommand cmd = new SqlCommand("UPDATE Settings_Table SET " +
                    "displaySiteLink = '" + Settings_Indicator.DISPLAY_SITE_LINK + "', " +
                    "displaySiteName = '" + Settings_Indicator.DISPLAY_SITE_NAME + "', " +
                    "displayMail = '" + Settings_Indicator.DISPLAY_MAIL + "', " +
                    "displayUsername = '" + Settings_Indicator.DISPLAY_USERNAME + "', " +
                    "displayPassword = '" + Settings_Indicator.DISPLAY_PASSWORD + "', " +
                    "useSmallAlphabets = '" + Settings_Indicator.USE_SMALL_ALPHABETS + "', " +
                    "useCapitalAlphabets = '" + Settings_Indicator.USE_CAPITAL_ALPHABETS + "', " +
                    "useNumbers = '" + Settings_Indicator.USE_NUMBERS + "', " +
                    "useSpecialChar = '" + Settings_Indicator.USE_SPECIAL_CHAR + "' " +
                    "WHERE " +
                    "indicator = '" + 1 + "' ", sc);

                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't Update because of some technical error");
                    MessageBox.Show("Settings Error = " + ex.Message);
                    //MessageBox.Show("Error = "+ ex.Message);
                    Console.WriteLine(ex.Message);
                }

                #endregion UPDATE BUTTON CLICKED


                //Utilities.getSettings();
                //Utilities.applySettingsToDataTable();

                mail_textBox.ReadOnly = true;
                mail_textBox.Text = Indicator.MASTER_MAIL;
                password_textBox.ReadOnly = true;
                password_textBox.Text = Indicator.MASTER_PASSWORD;

                Utilities.SETTINGS.settings_label.Text = "Settings will be applied, the next time you log in";

                change_Button.Text = "UNLOCK SETTINGS";
                change_Button.BackColor = changeButtonColor;

                //siteLink_checkBox.Enabled = false;
                //siteName_checkBox.Enabled = false;
                //mail_checkBox.Enabled = false;
                //username_checkBox.Enabled = false;
                //password_checkBox.Enabled = false;
                //smallAlphabet_checkBox.Enabled = false;
                //capitalAlphabet_checkBox.Enabled = false;
                //numbers_checkBox.Enabled = false;
                //specialChar_checkBox.Enabled = false;







            }
        }



        private void updateDisplayCheckBoxDecisions()
        {
            if (siteLink_checkBox.Checked) { Settings_Indicator.DISPLAY_SITE_LINK = 1; } else { Settings_Indicator.DISPLAY_SITE_LINK = 0; }
            if (siteName_checkBox.Checked) { Settings_Indicator.DISPLAY_SITE_NAME = 1; } else { Settings_Indicator.DISPLAY_SITE_NAME = 0; }
            if (mail_checkBox.Checked) { Settings_Indicator.DISPLAY_MAIL = 1; }          else { Settings_Indicator.DISPLAY_MAIL = 0; }
            if (username_checkBox.Checked) { Settings_Indicator.DISPLAY_USERNAME = 1; } else { Settings_Indicator.DISPLAY_USERNAME = 0; }
            if (password_checkBox.Checked) { Settings_Indicator.DISPLAY_PASSWORD = 1; } else { Settings_Indicator.DISPLAY_PASSWORD = 0; }
        }

        private void updatePasswordCheckBoxDecisions()
        {
            if (smallAlphabet_checkBox.Checked) { Settings_Indicator.USE_SMALL_ALPHABETS = 1; } else { Settings_Indicator.USE_SMALL_ALPHABETS = 0; }
            if (capitalAlphabet_checkBox.Checked) { Settings_Indicator.USE_CAPITAL_ALPHABETS = 1; } else { Settings_Indicator.USE_CAPITAL_ALPHABETS = 0; }
            if (numbers_checkBox.Checked) { Settings_Indicator.USE_NUMBERS = 1; } else { Settings_Indicator.USE_NUMBERS = 0; }
            if (specialChar_checkBox.Checked) { Settings_Indicator.USE_SPECIAL_CHAR = 1; } else { Settings_Indicator.USE_SPECIAL_CHAR = 0; }
        }


        public void setPreviousSettingsFromDataBase()
        {
            if (Settings_Indicator.DISPLAY_SITE_LINK == 1) { siteLink_checkBox.Checked = true; } else { siteLink_checkBox.Checked = false; }
            if (Settings_Indicator.DISPLAY_SITE_NAME == 1) { siteName_checkBox.Checked = true; } else { siteName_checkBox.Checked = false; }
            if (Settings_Indicator.DISPLAY_MAIL == 1)      { mail_checkBox.Checked = true; }     else { mail_checkBox.Checked = false; }
            if (Settings_Indicator.DISPLAY_USERNAME == 1)  { username_checkBox.Checked = true; } else { username_checkBox.Checked = false; }
            if (Settings_Indicator.DISPLAY_PASSWORD == 1)  { password_checkBox.Checked = true; } else { password_checkBox.Checked = false; }

            if (Settings_Indicator.USE_SMALL_ALPHABETS == 1)  { smallAlphabet_checkBox.Checked = true; } else { password_checkBox.Checked = false; }
            if (Settings_Indicator.USE_CAPITAL_ALPHABETS == 1)  { capitalAlphabet_checkBox.Checked = true; } else { password_checkBox.Checked = false; }
            if (Settings_Indicator.USE_NUMBERS == 1)  { numbers_checkBox.Checked = true; } else { password_checkBox.Checked = false; }
            if (Settings_Indicator.USE_SPECIAL_CHAR == 1)  { specialChar_checkBox.Checked = true; } else { password_checkBox.Checked = false; }
        }




        // Settings will be applied, the next time you log in

    }
}
