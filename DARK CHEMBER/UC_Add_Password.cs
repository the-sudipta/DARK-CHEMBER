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
    public partial class UC_Add_Password : UserControl
    {

        SqlConnection sc = new SqlConnection(SQLConnectionClass.conReturn());// Connection String


        public UC_Add_Password()
        {
            InitializeComponent();
        }

        private void insert_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string currentTimeDate = Utilities.getDate();
                SqlCommand cmd = new SqlCommand("INSERT INTO Password_Table  " +
                    "(date,siteLink,siteName,mail,username,password) VALUES( '" + currentTimeDate + "', '" +
                    Utilities.DASHBOARD.siteLink_textBox.Text + "','" +
                    Utilities.DASHBOARD.siteName_textBox.Text + "', '" +
                    Utilities.DASHBOARD.mail_textBox.Text + "', '" +
                    Utilities.DASHBOARD.username_textBox.Text + "', '" +
                    Utilities.DASHBOARD.password_textBox.Text + "') " , sc);
                Utilities.DASHBOARD.time_date_label.Text = currentTimeDate;
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //string password = "Time = "+Utilities.getDate() + ", " +
            //        "Site Link =  "+Utilities.DASHBOARD.siteLink_textBox.Text + ", " +
            //        "Site Name =  " + Utilities.DASHBOARD.siteName_textBox.Text + ", " +
            //        "Mail =  " + Utilities.DASHBOARD.mail_textBox.Text + ", " +
            //        "Username =  " + Utilities.DASHBOARD.username_textBox.Text + ", " +
            //        "Password =  " + Utilities.DASHBOARD.password_textBox.Text + " ";


            //Utilities.sendMailWithPass("New Added", Indicator.MASTER_MAIL, password,"New Password Added");


            MessageBox.Show("Password Added Successfully");
            Utilities.DASHBOARD.showData();
            Utilities.DASHBOARD.setHint();
        }

        private void generate_password_Button_Click(object sender, EventArgs e)
        {
            Utilities.DASHBOARD.password_textBox.Text = Utilities.randomPasswordGenerate();
        }
    }
}
