using MySql.Data.MySqlClient;
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
    public partial class Settings : Form
    {

        Color updateButtonColor = Color.FromArgb(0, 192, 0);
        Color changeButtonColor = Color.FromArgb(252, 123, 3);


		MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());

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
					MySqlCommand cmd = new MySqlCommand("UPDATE MasterPass_Table SET " +
						"mail = @mail, " +
						"masterPassword = @masterPassword " +
						"WHERE " +
						"mail = @oldMail", sc);

					cmd.Parameters.AddWithValue("@mail", Utilities.SETTINGS.mail_textBox.Text);
					cmd.Parameters.AddWithValue("@masterPassword", Utilities.SETTINGS.password_textBox.Text);
					cmd.Parameters.AddWithValue("@oldMail", Indicator.MASTER_MAIL);

					sc.Open();
					cmd.ExecuteNonQuery();
					sc.Close();
					Indicator.MASTER_MAIL = Utilities.SETTINGS.mail_textBox.Text;
					Indicator.MASTER_PASSWORD = Utilities.SETTINGS.password_textBox.Text;
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
					MySqlCommand cmd = new MySqlCommand("UPDATE Settings_Table SET " +
						"displaySiteLink = @displaySiteLink, " +
						"displaySiteName = @displaySiteName, " +
						"displayMail = @displayMail, " +
						"displayUsername = @displayUsername, " +
						"displayPassword = @displayPassword, " +
						"useSmallAlphabets = @useSmallAlphabets, " +
						"useCapitalAlphabets = @useCapitalAlphabets, " +
						"useNumbers = @useNumbers, " +
						"useSpecialChar = @useSpecialChar " +
						"WHERE " +
						"indicator = @indicator", sc);

					cmd.Parameters.AddWithValue("@displaySiteLink", Settings_Indicator.DISPLAY_SITE_LINK);
					cmd.Parameters.AddWithValue("@displaySiteName", Settings_Indicator.DISPLAY_SITE_NAME);
					cmd.Parameters.AddWithValue("@displayMail", Settings_Indicator.DISPLAY_MAIL);
					cmd.Parameters.AddWithValue("@displayUsername", Settings_Indicator.DISPLAY_USERNAME);
					cmd.Parameters.AddWithValue("@displayPassword", Settings_Indicator.DISPLAY_PASSWORD);
					cmd.Parameters.AddWithValue("@useSmallAlphabets", Settings_Indicator.USE_SMALL_ALPHABETS);
					cmd.Parameters.AddWithValue("@useCapitalAlphabets", Settings_Indicator.USE_CAPITAL_ALPHABETS);
					cmd.Parameters.AddWithValue("@useNumbers", Settings_Indicator.USE_NUMBERS);
					cmd.Parameters.AddWithValue("@useSpecialChar", Settings_Indicator.USE_SPECIAL_CHAR);
					cmd.Parameters.AddWithValue("@indicator", 1);

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
