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
    public partial class Form11 : Form
    {
        SqlConnection sqlConnection;

        List<string[]> dataOrder = new List<string[]>();
        public Form11()
        {
            InitializeComponent();
        }

        private void refreshTable(string searchStr)
        {
            if (searchStr == null)
            {
                foreach (string[] row in dataOrder)
                    dataGridView1.Rows.Add(row);
            }
        }
        private async void Form11_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Andrey\source\repos\WorkingWithBD\WorkingWithBD\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Order]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    dataOrder.Add(new string[4]);

                    dataOrder[dataOrder.Count - 1][0] = Convert.ToString(sqlReader["Id"]);
                    dataOrder[dataOrder.Count - 1][1] = Convert.ToString(sqlReader["userId"]);
                    dataOrder[dataOrder.Count - 1][2] = Convert.ToString(sqlReader["paymentMethod"]);
                    dataOrder[dataOrder.Count - 1][3] = Convert.ToString(sqlReader["productId"]);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            dataOrder.Clear();
            dataGridView1.Rows.Clear();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Order]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    dataOrder.Add(new string[4]);

                    dataOrder[dataOrder.Count - 1][0] = Convert.ToString(sqlReader["Id"]);
                    dataOrder[dataOrder.Count - 1][1] = Convert.ToString(sqlReader["userId"]);
                    dataOrder[dataOrder.Count - 1][2] = Convert.ToString(sqlReader["paymentMethod"]);
                    dataOrder[dataOrder.Count - 1][3] = Convert.ToString(sqlReader["productId"]);
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

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label9.Visible)
                label9.Visible = false;

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Order] WHERE [Id]=@Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox6.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Поле 'ID' должно быть заполнено";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 admin = new Form5();
            admin.ShowDialog();
            Close();
        }
    }
}
