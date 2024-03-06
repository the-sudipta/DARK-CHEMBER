using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DARK_CHEMBER
{
	public partial class UC_Update_Delete_Password : UserControl
	{
		MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());// Connection String
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
			try
			{
				string currentTimeDate = Utilities.getDate();
				MySqlCommand cmd = new MySqlCommand("UPDATE Password_Table SET " +
					"date = @date, " +
					"siteLink = @siteLink," +
					"siteName = @siteName, " +
					"mail = @mail, " +
					"username = @username, " +
					"password = @password " +
					" WHERE " +
					"siteLink = @oldSiteLink AND " +
					"siteName = @oldSiteName AND " +
					"mail = @oldMail AND " +
					"username = @oldUsername AND " +
					"password = @oldPassword ", sc);

				cmd.Parameters.AddWithValue("@date", currentTimeDate);
				cmd.Parameters.AddWithValue("@siteLink", Utilities.DASHBOARD.siteLink_textBox.Text);
				cmd.Parameters.AddWithValue("@siteName", Utilities.DASHBOARD.siteName_textBox.Text);
				cmd.Parameters.AddWithValue("@mail", Utilities.DASHBOARD.mail_textBox.Text);
				cmd.Parameters.AddWithValue("@username", Utilities.DASHBOARD.username_textBox.Text);
				cmd.Parameters.AddWithValue("@password", Utilities.DASHBOARD.password_textBox.Text);

				cmd.Parameters.AddWithValue("@oldSiteLink", Indicator.siteLink);
				cmd.Parameters.AddWithValue("@oldSiteName", Indicator.siteName);
				cmd.Parameters.AddWithValue("@oldMail", Indicator.mail);
				cmd.Parameters.AddWithValue("@oldUsername", Indicator.username);
				cmd.Parameters.AddWithValue("@oldPassword", Indicator.password);

				Utilities.DASHBOARD.time_date_label.Text = currentTimeDate;
				sc.Open();
				cmd.ExecuteNonQuery();
				sc.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			MessageBox.Show("Data Updated Successfully");
			Utilities.DASHBOARD.showData();
			Utilities.DASHBOARD.setHint();
		}

		private void delete_Button_Click(object sender, EventArgs e)
		{
			try
			{
				string currentTimeDate = Utilities.getDate();
				MySqlCommand cmd = new MySqlCommand("DELETE FROM Password_Table " +
					" WHERE " +
					"siteLink = @siteLink AND " +
					"siteName = @siteName AND " +
					"mail = @mail AND " +
					"username = @username AND " +
					"password = @password ", sc);

				cmd.Parameters.AddWithValue("@siteLink", Indicator.siteLink);
				cmd.Parameters.AddWithValue("@siteName", Indicator.siteName);
				cmd.Parameters.AddWithValue("@mail", Indicator.mail);
				cmd.Parameters.AddWithValue("@username", Indicator.username);
				cmd.Parameters.AddWithValue("@password", Indicator.password);

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
			if (Utilities.DASHBOARD.siteLink_textBox.Text != "" && Utilities.DASHBOARD.siteName_textBox.Text != "" && Utilities.DASHBOARD.mail_textBox.Text != ""
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
