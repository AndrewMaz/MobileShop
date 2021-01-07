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
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
public Form3()
        {
            InitializeComponent();
        }
	private async void button1_Click(object sender, EventArgs e)
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
                    if (Convert.ToString(sqlReader["login"]) == textBox1.Text && Convert.ToString(sqlReader["pass"]) == textBox2.Text)
                    {
                        Hide();
                        Form7 userMenu = new Form7();
                        userMenu.userID = Convert.ToString(sqlReader["Id"]);
                        userMenu.ShowDialog();
                        Close();
                    }
                    else
                    {
                        label3.Visible = true;
                        label3.Text = "Неверный логин или пароль";
                    }
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 mainMenu = new Form2();
            mainMenu.ShowDialog();
            Close();
        }
    }
}
