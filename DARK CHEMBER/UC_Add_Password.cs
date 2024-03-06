using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DARK_CHEMBER
{
	public partial class UC_Add_Password : UserControl
	{
		MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());// Connection String

		public UC_Add_Password()
		{
			InitializeComponent();
		}

		private void insert_Button_Click(object sender, EventArgs e)
		{
			try
			{
				string currentTimeDate = Utilities.getDate();
				MySqlCommand cmd = new MySqlCommand("INSERT INTO Password_Table  " +
					"(date,siteLink,siteName,mail,username,password) VALUES( @currentTimeDate, @siteLink, @siteName, @mail, @username, @password)", sc);
				cmd.Parameters.AddWithValue("@currentTimeDate", currentTimeDate);
				cmd.Parameters.AddWithValue("@siteLink", Utilities.DASHBOARD.siteLink_textBox.Text);
				cmd.Parameters.AddWithValue("@siteName", Utilities.DASHBOARD.siteName_textBox.Text);
				cmd.Parameters.AddWithValue("@mail", Utilities.DASHBOARD.mail_textBox.Text);
				cmd.Parameters.AddWithValue("@username", Utilities.DASHBOARD.username_textBox.Text);
				cmd.Parameters.AddWithValue("@password", Utilities.DASHBOARD.password_textBox.Text);

				Utilities.DASHBOARD.time_date_label.Text = currentTimeDate;
				sc.Open();
				cmd.ExecuteNonQuery();
				sc.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

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
