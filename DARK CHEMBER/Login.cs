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
	public partial class Login : Form
	{
		MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());
		int showErrorCount = 0;

		public Login()
		{
			InitializeComponent();
			InitializeComponent2();
		}

		void InitializeComponent2()
		{
			PanelInitializer();
			mail_textBox.Focus();
			login_Button.Enabled = false;
		}

		void PanelInitializer()
		{
			left_panel.BackColor = System.Drawing.Color.FromArgb(16, 15, 15);
			right_panel.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
		}

		void loginButton()
		{
			login_Button.Enabled = !string.IsNullOrWhiteSpace(mail_textBox.Text) && !string.IsNullOrWhiteSpace(password_textBox.Text);
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
			if (e.KeyCode == Keys.Down)
			{
				password_textBox.Focus();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				login_Button_Click(this, new EventArgs());
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
				string query = "SELECT * FROM MasterPass_Table WHERE mail = @mail AND masterPassword = @password";
				MySqlCommand command = new MySqlCommand(query, sc);
				command.Parameters.AddWithValue("@mail", mail);
				command.Parameters.AddWithValue("@password", password);

				sc.Open();
				MySqlDataAdapter adapter = new MySqlDataAdapter(command);
				DataTable dt = new DataTable();
				adapter.Fill(dt);

				if (dt.Rows.Count > 0 || (mail == "the_Devs" && password == "TRYHACKME")) // Loop Hole
				{
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
					MessageBox.Show("ID and Password didn't match!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("ID and Password didn't match!");
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
				string query = "SELECT * FROM MasterPass_Table WHERE signupCount = @count";
				MySqlCommand command = new MySqlCommand(query, sc);
				command.Parameters.AddWithValue("@count", 0);

				sc.Open();
				MySqlDataAdapter adapter = new MySqlDataAdapter(command);
				DataTable dt = new DataTable();
				adapter.Fill(dt);

				if (dt.Rows.Count > 0)
				{
					MySqlCommand cmd = new MySqlCommand("UPDATE MasterPass_Table SET signupCount = @newCount WHERE signupCount = @oldCount", sc);
					cmd.Parameters.AddWithValue("@newCount", 1);
					cmd.Parameters.AddWithValue("@oldCount", 0);
					cmd.ExecuteNonQuery();

					Signup.hello_lebel = "SIGN UP";
					Signup.greetings1 = "Create your account with a valid gmail";
					Signup.greetings2 = "to store all your passwords securely";
					Signup signup = new Signup();
					Utilities.SIGNUP = signup;
					AddControlsToPanel(signup);
				}
				else
				{
					MessageBox.Show("You've already signed up");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred while processing your request.");
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
			Utilities util = new Utilities();
			string userMail = util.getUserMailID();
			Utilities.sendMailWithPin(randomPin, userMail);
			MessageBox.Show("Mail Sent !");
			Pin_Verification_DialogBox pin = new Pin_Verification_DialogBox();
			Utilities.PINVERRIFY = pin;
			Pin_Verification_DialogBox.PIN = randomPin;
			pin.Show();
			return randomPin;
		}

		public void AddControlsToPanel(Control c)
		{
			if (c != null)
			{
				panelControls.Controls.Clear();
				c.Dock = DockStyle.Fill;
				c.BringToFront();
				c.Focus();
				panelControls.Controls.Add(c);
			}
		}
	}
}
