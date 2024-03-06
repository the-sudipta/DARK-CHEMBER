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
    public partial class Search_Password : Form
    {

        #region Color
        Color hintColor = Color.FromArgb(78, 82, 79);
        Color textColor = Color.FromArgb(255, 255, 255);
        #endregion Color

        #region Font
        Font textHintFont = new Font("Segoe UI", 11);
        Font textFont = new Font("Segoe UI", 18);
        #endregion Font

        bool isDataAvailable = true;



		MySqlConnection sc = new MySqlConnection(SQLConnectionClass.conReturn());

		private void InitializeComponent2()
        {
            comboBox.SelectedIndex = 0;
            setHint();
            ///search_item_textBox.Focus();
        }


        public Search_Password()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        private void minimize_pictureBox_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private void close_pictureBox_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        public void showData(string columnName, string rowValue)
		{
			string query = "SELECT date, siteLink, siteName, mail, username, password FROM Password_Table WHERE " + columnName + " = @rowValue";

			try
			{
				MySqlCommand cmd = new MySqlCommand(query, sc);
				cmd.Parameters.AddWithValue("@rowValue", rowValue);

				sc.Open();
				MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
				DataTable table = new DataTable();
				adapter.Fill(table);
				search_password_dataGridView.DataSource = table;
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred while fetching data: " + ex.Message);
			}
			finally
			{
				sc.Close();
			}
		}

		private void search_Button_Click(object sender, EventArgs e)
        {
            string columName = "";
            string getvalue = comboBox.SelectedItem.ToString();
            string rowvalue = search_item_textBox.Text;
            if(getvalue == "Site Name")
            {
                columName = "siteName"; isDataAvailable = true;
            }
            else if(getvalue == "Mail ID")
            {
                columName = "mail"; isDataAvailable = true;
            }
            else if(getvalue == "Username")
            {
                columName = "username"; isDataAvailable = true;
            }
            else
            {
                MessageBox.Show("Please select the type that you're searching for");
                isDataAvailable = false;
            }
            if (isDataAvailable) { showData(columName, rowvalue); }
            

        }

        private void search_item_textBox_Enter(object sender, EventArgs e)
        {
            if(search_item_textBox.Text.Contains("Enter the "))
            {
                search_item_textBox.Text = "";
                search_item_textBox.ForeColor = textColor;
                search_item_textBox.Font = textFont;
            }
        }

        private void search_item_textBox_Leave(object sender, EventArgs e)
        {
            if (search_item_textBox.Text == "")
            {
                search_item_textBox.Text = "Enter the " + comboBox.SelectedItem.ToString();
                search_item_textBox.ForeColor = hintColor;
                search_item_textBox.Font = textHintFont;
            }
        }


        public void setHint()
        {

            search_item_textBox.ForeColor = hintColor;
            search_item_textBox.Font = textHintFont;
            search_item_textBox.Text = "Enter the " + comboBox.SelectedItem.ToString();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setHint();
        }

        private void search_item_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                search_Button_Click(this, new EventArgs());
            }
        }
    }
    }
