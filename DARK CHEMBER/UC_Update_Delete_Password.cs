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
    public partial class UC_Update_Delete_Password : UserControl
    {

        SqlConnection sc = new SqlConnection(SQLConnectionClass.conReturn());// Connection String

        Color BLACK = Color.FromArgb(0, 0, 0);


        private void InitializeComponent2()
        {
            update_Button.Enabled = false;
            delete_Button.Enabled = false;
        }

        public UC_Update_Delete_Password()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        private void update_Button_Click(object sender, EventArgs e)
        {
            //Utilities.DASHBOARD.delete_button;
            //Utilities.DASHBOARD.delete_button.BackColor = BLACK;

            //MessageBox.Show(
            //    Indicator.date +"\n"+
            //Indicator.siteLink + "\n" +
            //Indicator.siteName + "\n" +
            //Indicator.mail + "\n" +
            //Indicator.username + "\n" +
            //Indicator.password
            //    );

            try
            {
                string currentTimeDate = Utilities.getDate();
                SqlCommand cmd = new SqlCommand("UPDATE Password_Table SET " +
                    "date = '" + currentTimeDate + "', " +
                    "siteLink = '" + Utilities.DASHBOARD.siteLink_textBox.Text + "'," +
                    "siteName = '" + Utilities.DASHBOARD.siteName_textBox.Text + "', " +
                    "mail = '" + Utilities.DASHBOARD.mail_textBox.Text + "', " +
                    "username = '" + Utilities.DASHBOARD.username_textBox.Text + "', " +
                    "password = '" + Utilities.DASHBOARD.password_textBox.Text + "' " +
                    " WHERE " +
                    "siteLink = '" + Indicator.siteLink + "' AND " +
                    "siteName = '" + Indicator.siteName + "' AND " +
                    "mail = '" + Indicator.mail + "' AND " +
                    "username = '" + Indicator.username + "' AND " +
                    "password = '" + Indicator.password + "' ", sc);
                Utilities.DASHBOARD.time_date_label.Text = currentTimeDate;
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            //string password = "Time = " + Utilities.getDate() + ", " +
            //        "Site Link =  " + Utilities.DASHBOARD.siteLink_textBox.Text + ", " +
            //        "Site Name =  " + Utilities.DASHBOARD.siteName_textBox.Text + ", " +
            //        "Mail =  " + Utilities.DASHBOARD.mail_textBox.Text + ", " +
            //        "Username =  " + Utilities.DASHBOARD.username_textBox.Text + ", " +
            //        "Password =  " + Utilities.DASHBOARD.password_textBox.Text + " ";


            //Utilities.sendMailWithPass("Updated", Indicator.MASTER_MAIL, password, "Password Updated");







            MessageBox.Show("Data Updated Successfully");
            Utilities.DASHBOARD.showData();
            Utilities.DASHBOARD.setHint();
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            //Utilities.DASHBOARD.delete_button.BackColor = BLACK;
            //Utilities.DASHBOARD.time_date_label.Text = "";

            try
            {
                string currentTimeDate = Utilities.getDate();
                SqlCommand cmd = new SqlCommand("DELETE FROM Password_Table " +
                    " WHERE " +
                    "siteLink = '" + Indicator.siteLink + "' AND " +
                    "siteName = '" + Indicator.siteName + "' AND " +
                    "mail = '" + Indicator.mail + "' AND " +
                    "username = '" + Indicator.username + "' AND " +
                    "password = '" + Indicator.password + "' ", sc);
                Utilities.DASHBOARD.time_date_label.Text = currentTimeDate;
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Data Deleted Successfully");
            Utilities.DASHBOARD.showData();
            Utilities.DASHBOARD.setHint();


        }
        

        public void update_delete_Button_Enable_Check()
        {
            if(Utilities.DASHBOARD.siteLink_textBox.Text != "" && Utilities.DASHBOARD.siteName_textBox.Text != "" && Utilities.DASHBOARD.mail_textBox.Text != ""
               && Utilities.DASHBOARD.username_textBox.Text != "" && Utilities.DASHBOARD.password_textBox.Text != "")
            {
                update_Button.Enabled = true;
                delete_Button.Enabled = true;
            }
            else
            {
                update_Button.Enabled = false;
                delete_Button.Enabled = false;
            }
        }

        


    }
}
