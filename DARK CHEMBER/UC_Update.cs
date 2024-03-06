using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DARK_CHEMBER
{
	public partial class UC_Update : UserControl
	{
		MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());

		public UC_Update()
		{
			InitializeComponent();
		}

		private void update_Button_Click(object sender, EventArgs e)
		{
			try
			{
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
				//MessageBox.Show("New Mail = "+ Utilities.SETTINGS.mail_textBox.Text+"\n"
				//    +"New Pass = "+ Utilities.SETTINGS.password_textBox.Text+"\n\n"
				//    + "OLD Mail = " + Indicator.MASTER_MAIL + "\n"
				//    + "OLD Pass = " + Indicator.MASTER_PASSWORD);

			}
			catch (Exception ex)
			{
				MessageBox.Show("Couldn't Update because of some technical error");
				//MessageBox.Show("Error = "+ ex.Message);
				Console.WriteLine(ex.Message);
			}

			Utilities.SETTINGS.mail_textBox.ReadOnly = true;
			Utilities.SETTINGS.mail_textBox.Text = Indicator.MASTER_MAIL;
			Utilities.SETTINGS.password_textBox.ReadOnly = true;
			Utilities.SETTINGS.password_textBox.Text = Indicator.MASTER_PASSWORD;
		}
	}
}
