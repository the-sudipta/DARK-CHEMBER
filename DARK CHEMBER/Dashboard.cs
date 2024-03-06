using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DARK_CHEMBER
{
	public partial class Dashboard : Form
	{
		#region Color
		Color panelSelect = Color.FromArgb(255, 255, 255);
		Color panelLeaveColor = Color.FromArgb(16, 15, 15);
		Color BLACK = Color.FromArgb(0, 0, 0);
		Color WHITE = Color.FromArgb(255, 255, 255);
		Color BLUE = Color.FromArgb(17, 49, 99);
		Color GREEN = Color.FromArgb(0, 192, 0);
		Color ashColor = Color.FromArgb(78, 82, 79);
		#endregion Color

		#region Font
		Font textHintFont = new Font("Segoe UI", 11);
		Font textFont = new Font("Segoe UI", 18);
		#endregion Font

		MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());

		public bool updatePanelIsHidden = true;
		public bool addPanelIsHidden = true;
		public bool searchPanelIsHidden = true;
		public bool settingsPanelIsHidden = true;

		public Dashboard()
		{
			InitializeComponent();
			InitializeComponent2();
		}

		private void minimize_pictureBox_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void close_pictureBox_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void InitializeComponent2()
		{
			left_panel.BackColor = panelLeaveColor;
			setHint();
			showData();
			navigationPanelPosition(all_password_button);
		}

		private void navigationPanelPosition(Button button)
		{
			navigation_Blue_Panel.Height = button.Height;
			navigation_Blue_Panel.Top = button.Top;
			navigation_Blue_Panel.Left = button.Left;
			button.BackColor = BLACK;
		}

		private void navigationPanelLeave(Button button)
		{
			button.BackColor = panelLeaveColor;
		}

		private void all_password_button_Click(object sender, EventArgs e)
		{
			navigationPanelPosition(all_password_button);
			setHint();
			Utilities.UPDATE_DELETE.Hide();
			Utilities.ADD_PASSWORD.Hide();
			updatePanelIsHidden = true;
		}

		private void all_password_button_Leave(object sender, EventArgs e)
		{
			navigationPanelLeave(all_password_button);
		}

		private void add_button_Click(object sender, EventArgs e)
		{
			setHint();
			Utilities.UPDATE_DELETE.update_Button.Enabled = false;
			Utilities.UPDATE_DELETE.delete_Button.Enabled = false;
			Utilities.ADD_PASSWORD.insert_Button.Enabled = false;
			Utilities.ADD_PASSWORD.generate_password_Button.Enabled = false;
			Utilities.SETTINGS.Hide();
			navigationPanelPosition(add_button);
			if (addPanelIsHidden == true)
			{
				Add_Controls_To_Update_Delete_Panel(Utilities.ADD_PASSWORD);
				Utilities.ADD_PASSWORD.Show();
				addPanelIsHidden = false;
			}
			else
			{
				Add_Controls_To_Update_Delete_Panel(Utilities.ADD_PASSWORD);
				Utilities.ADD_PASSWORD.Show();
				addPanelIsHidden = true;
			}
			textBoxUnlock(true);
		}

		private void add_button_Leave(object sender, EventArgs e)
		{
			navigationPanelLeave(add_button);
		}

		private void search_button_Click(object sender, EventArgs e)
		{
			navigationPanelPosition(search_button);
			setHint();
			Utilities.UPDATE_DELETE.Hide();
			Utilities.ADD_PASSWORD.Hide();
			updatePanelIsHidden = true;
			Utilities.SETTINGS.Hide();
			Utilities.SEARCH_PASSWORD.Hide();
			Utilities.SEARCH_PASSWORD.Show();
		}

		private void search_button_Leave(object sender, EventArgs e)
		{
			navigationPanelLeave(search_button);
		}

		private void delete_button_Click(object sender, EventArgs e)
		{
			navigationPanelPosition(delete_button);
			Utilities.UPDATE_DELETE.update_Button.Enabled = false;
			Utilities.UPDATE_DELETE.delete_Button.Enabled = false;
			Utilities.SETTINGS.Hide();
			if (updatePanelIsHidden == true)
			{
				Add_Controls_To_Update_Delete_Panel(Utilities.UPDATE_DELETE);
				Utilities.UPDATE_DELETE.Show();
				updatePanelIsHidden = false;
			}
			else
			{
				Add_Controls_To_Update_Delete_Panel(Utilities.UPDATE_DELETE);
				Utilities.UPDATE_DELETE.Show();
				updatePanelIsHidden = true;
			}
			textBoxUnlock(true);
		}

		private void delete_button_Leave(object sender, EventArgs e)
		{
			navigationPanelLeave(delete_button);
		}

		private void settings_button_Click(object sender, EventArgs e)
		{
			navigationPanelPosition(settings_button);
			Utilities.ADD_PASSWORD.Hide();
			Utilities.UPDATE_DELETE.Hide();
			Utilities.SEARCH_PASSWORD.Hide();
			Utilities.SETTINGS.Hide();
			Utilities.SETTINGS.Show();
		}

		private void settings_button_Leave(object sender, EventArgs e)
		{
			navigationPanelLeave(settings_button);
		}

		private void Add_Controls_To_Update_Delete_Panel(Control c)
		{
			c.Dock = DockStyle.Fill;
			updateDelete_panel.Controls.Clear();
			updateDelete_panel.Controls.Add(c);
		}

		private void textBoxUnlock(bool decision)
		{
			if (decision)
			{
				siteLink_textBox.ReadOnly = false;
				siteName_textBox.ReadOnly = false;
				mail_textBox.ReadOnly = false;
				username_textBox.ReadOnly = false;
				password_textBox.ReadOnly = false;
			}
			else if (decision == false)
			{
				siteLink_textBox.ReadOnly = true;
				siteName_textBox.ReadOnly = true;
				mail_textBox.ReadOnly = true;
				username_textBox.ReadOnly = true;
				password_textBox.ReadOnly = true;
			}
		}

		#region TEXT BOX HINTS
		public void setHint()
		{
			time_date_label.ForeColor = ashColor;
			time_date_label.Font = textHintFont;
			time_date_label.Text = "Previous Update Time";

			siteLink_textBox.ForeColor = ashColor;
			siteLink_textBox.Font = textHintFont;
			siteLink_textBox.Text = "Site Link";

			siteName_textBox.ForeColor = ashColor;
			siteName_textBox.Font = textHintFont;
			siteName_textBox.Text = "Site Name";

			mail_textBox.ForeColor = ashColor;
			mail_textBox.Font = textHintFont;
			mail_textBox.Text = "Gmail ID";

			username_textBox.ForeColor = ashColor;
			username_textBox.Font = textHintFont;
			username_textBox.Text = "Username";

			password_textBox.ForeColor = ashColor;
			password_textBox.Font = textHintFont;
			password_textBox.Text = "Password";
		}

		private void siteLink_textBox_Enter(object sender, EventArgs e)
		{
			if (siteLink_textBox.Text == "Site Link")
			{
				siteLink_textBox.Text = "";
				siteLink_textBox.ForeColor = WHITE;
				siteLink_textBox.Font = textFont;
			}
		}

		private void siteLink_textBox_Leave(object sender, EventArgs e)
		{
			if (siteLink_textBox.Text == "")
			{
				siteLink_textBox.Text = "Site Link";
				siteLink_textBox.ForeColor = ashColor;
				siteLink_textBox.Font = textHintFont;
			}
		}

		private void siteName_textBox_Enter(object sender, EventArgs e)
		{
			if (siteName_textBox.Text == "Site Name")
			{
				siteName_textBox.Text = "";
				siteName_textBox.ForeColor = WHITE;
				siteName_textBox.Font = textFont;
			}
		}

		private void siteName_textBox_Leave(object sender, EventArgs e)
		{
			if (siteName_textBox.Text == "")
			{
				siteName_textBox.Text = "Site Name";
				siteName_textBox.ForeColor = ashColor;
				siteName_textBox.Font = textHintFont;
			}
		}

		private void mail_textBox_Enter(object sender, EventArgs e)
		{
			if (mail_textBox.Text == "Gmail ID")
			{
				mail_textBox.Text = "";
				mail_textBox.ForeColor = WHITE;
				mail_textBox.Font = textFont;
			}
		}

		private void mail_textBox_Leave(object sender, EventArgs e)
		{
			if (mail_textBox.Text == "")
			{
				mail_textBox.Text = "Gmail ID";
				mail_textBox.ForeColor = ashColor;
				mail_textBox.Font = textHintFont;
			}
		}

		private void username_textBox_Enter(object sender, EventArgs e)
		{
			if (username_textBox.Text == "Username")
			{
				username_textBox.Text = "";
				username_textBox.ForeColor = WHITE;
				username_textBox.Font = textFont;
			}
		}

		private void username_textBox_Leave(object sender, EventArgs e)
		{
			if (username_textBox.Text == "")
			{
				username_textBox.Text = "Username";
				username_textBox.ForeColor = ashColor;
				username_textBox.Font = textHintFont;
			}
		}

		private void password_textBox_Enter(object sender, EventArgs e)
		{
			if (password_textBox.Text == "Password")
			{
				password_textBox.Text = "";
				password_textBox.ForeColor = WHITE;
				password_textBox.Font = textFont;
			}
		}

		private void password_textBox_Leave(object sender, EventArgs e)
		{
			if (password_textBox.Text == "")
			{
				password_textBox.Text = "Password";
				password_textBox.ForeColor = ashColor;
				password_textBox.Font = textHintFont;
			}
		}
		#endregion TEXT BOX HINTS

		private void siteLink_textBox_TextChanged(object sender, EventArgs e)
		{
			update_delete_Button_Enable_Check();
		}

		private void siteName_textBox_TextChanged(object sender, EventArgs e)
		{
			update_delete_Button_Enable_Check();
		}

		private void mail_textBox_TextChanged(object sender, EventArgs e)
		{
			update_delete_Button_Enable_Check();
		}

		private void username_textBox_TextChanged(object sender, EventArgs e)
		{
			update_delete_Button_Enable_Check();
		}

		private void password_textBox_TextChanged(object sender, EventArgs e)
		{
			update_delete_Button_Enable_Check();
		}

		public void update_delete_Button_Enable_Check()
		{
			if (siteLink_textBox.Text != "" && siteName_textBox.Text != "" && mail_textBox.Text != ""
			   && username_textBox.Text != "" && password_textBox.Text != "" &&
			   siteLink_textBox.Text != "Site Link" && siteName_textBox.Text != "Site Name" && mail_textBox.Text != "Gmail ID"
			   && username_textBox.Text != "Username" && password_textBox.Text != "Password")
			{
				Utilities.UPDATE_DELETE.update_Button.Enabled = true;
				Utilities.UPDATE_DELETE.delete_Button.Enabled = true;
				Utilities.ADD_PASSWORD.insert_Button.Enabled = true;
				Utilities.ADD_PASSWORD.generate_password_Button.Enabled = true;
			}
			else
			{
				Utilities.UPDATE_DELETE.update_Button.Enabled = false;
				Utilities.UPDATE_DELETE.delete_Button.Enabled = false;
				Utilities.ADD_PASSWORD.insert_Button.Enabled = false;
				Utilities.ADD_PASSWORD.generate_password_Button.Enabled = false;
			}
		}

		public void showData()
		{
			try
			{
				sc.Open();
				MySqlCommand cmd = new MySqlCommand("SELECT date, siteLink, siteName, mail, username, password FROM Password_Table", sc);
				var reader = cmd.ExecuteReader();
				DataTable table = new DataTable();
				table.Load(reader);
				all_password_dataGridView.DataSource = table;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
			finally
			{
				sc.Close();
			}
		}

		private void all_password_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				time_date_label.ForeColor = WHITE;
				time_date_label.Font = textFont;
				siteLink_textBox.ForeColor = WHITE;
				siteLink_textBox.Font = textFont;
				siteName_textBox.ForeColor = WHITE;
				siteName_textBox.Font = textFont;
				mail_textBox.ForeColor = WHITE;
				mail_textBox.Font = textFont;
				username_textBox.ForeColor = WHITE;
				username_textBox.Font = textFont;
				username_textBox.ForeColor = WHITE;
				username_textBox.Font = textFont;
				password_textBox.ForeColor = WHITE;
				password_textBox.Font = textFont;

				time_date_label.Text = all_password_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
				siteLink_textBox.Text = all_password_dataGridView.SelectedRows[0].Cells[1].Value.ToString();
				siteName_textBox.Text = all_password_dataGridView.SelectedRows[0].Cells[2].Value.ToString();
				mail_textBox.Text = all_password_dataGridView.SelectedRows[0].Cells[3].Value.ToString();
				username_textBox.Text = all_password_dataGridView.SelectedRows[0].Cells[4].Value.ToString();
				password_textBox.Text = all_password_dataGridView.SelectedRows[0].Cells[5].Value.ToString();

				Indicator.date = time_date_label.Text;
				Indicator.siteLink = siteLink_textBox.Text;
				Indicator.siteName = siteName_textBox.Text;
				Indicator.mail = mail_textBox.Text;
				Indicator.username = username_textBox.Text;
				Indicator.password = password_textBox.Text;
			}
		}

		private void siteLink_textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				siteName_textBox.Focus();
			}
		}

		private void siteName_textBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				siteLink_textBox.Focus();
			}
		}

		private void siteName_textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				mail_textBox.Focus();
			}
		}

		private void mail_textBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				siteName_textBox.Focus();
			}
		}

		private void mail_textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				username_textBox.Focus();
			}
		}

		private void username_textBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				mail_textBox.Focus();
			}
		}

		private void username_textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				password_textBox.Focus();
			}
		}

		private void password_textBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				username_textBox.Focus();
			}
		}
	}
}
