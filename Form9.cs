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

namespace WorkingWithBD
{
    public partial class Form9 : Form
    {
        SqlConnection sqlConnection;

        List<string[]> dataUsers = new List<string[]>();
        public Form9()
        {
            InitializeComponent();
        }
private void refreshTable(string searchStr)
        {
            if (searchStr == null)
            {
                foreach (string[] row in dataUsers)
                    dataGridView1.Rows.Add(row);
            }
        }
        private async void Form9_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Andrey\source\repos\WorkingWithBD\WorkingWithBD\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [User]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    dataUsers.Add(new string[6]);

                    dataUsers[dataUsers.Count - 1][0] = Convert.ToString(sqlReader["id"]);
                    dataUsers[dataUsers.Count - 1][1] = Convert.ToString(sqlReader["login"]);
                    dataUsers[dataUsers.Count - 1][2] = Convert.ToString(sqlReader["name"]);
                    dataUsers[dataUsers.Count - 1][3] = Convert.ToString(sqlReader["surname"]);
                    dataUsers[dataUsers.Count - 1][4] = Convert.ToString(sqlReader["adress"]);
                    dataUsers[dataUsers.Count - 1][5] = Convert.ToString(sqlReader["phoneNumber"]);
                }

                refreshTable(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 admin = new Form5();
            admin.ShowDialog();
            Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label9.Visible)
                label9.Visible = false;

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [User] WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox6.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Поле 'ID' должно быть заполнено";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            dataUsers.Clear();
            dataGridView1.Rows.Clear();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [User]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    dataUsers.Add(new string[6]);

                    dataUsers[dataUsers.Count - 1][0] = Convert.ToString(sqlReader["id"]);
                    dataUsers[dataUsers.Count - 1][1] = Convert.ToString(sqlReader["login"]);
                    dataUsers[dataUsers.Count - 1][2] = Convert.ToString(sqlReader["name"]);
                    dataUsers[dataUsers.Count - 1][3] = Convert.ToString(sqlReader["surname"]);
                    dataUsers[dataUsers.Count - 1][4] = Convert.ToString(sqlReader["adress"]);
                    dataUsers[dataUsers.Count - 1][5] = Convert.ToString(sqlReader["phoneNumber"]);
                }

                refreshTable(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }
    }
}
