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
    public partial class Form7 : Form
    {
        SqlConnection sqlConnection;

        List<string[]> dataProducts = new List<string[]>();
        public string userID
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public Form7()
        {
            InitializeComponent();
        }

        private void refreshTable(string searchStr)
        {
            if (searchStr == null)
            {
                foreach (string[] row in dataProducts)
                    dataGridView1.Rows.Add(row);
            }
        }
        private async void Form7_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Andrey\source\repos\WorkingWithBD\WorkingWithBD\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            SqlCommand command = new SqlCommand("SELECT * FROM [Products]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    dataProducts.Add(new string[9]);

                    dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                    dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                    dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                    dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                    dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                    dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                    dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                    dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                    dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
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
private async void button4_Click_1(object sender, EventArgs e)
        {
            dataProducts.Clear();
            dataGridView1.Rows.Clear();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Products]", sqlConnection);

            string choose1 = null, choose2 = null, choose3 = null, choose4 = null;


            choose1 = Convert.ToString(comboBox1.SelectedItem);
            choose2 = Convert.ToString(comboBox2.SelectedItem);
            choose3 = Convert.ToString(comboBox3.SelectedItem);
            choose4 = Convert.ToString(comboBox4.SelectedItem);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                if (comboBox1.SelectedIndex != 0 || comboBox2.SelectedIndex != 0 || comboBox3.SelectedIndex != 0 || comboBox4.SelectedIndex != 0)
                {
                    while (await sqlReader.ReadAsync())
                    {
                        if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["os"]) == choose2)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }


                        if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex != 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["memory"]) == choose3)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex != 0)
                        {
                            if (Convert.ToString(sqlReader["ram"]) == choose4)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1 && Convert.ToString(sqlReader["os"]) == choose2)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex != 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1 && Convert.ToString(sqlReader["memory"]) == choose3)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex != 0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1 && Convert.ToString(sqlReader["ram"]) == choose4)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex != 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["memory"]) == choose3 && Convert.ToString(sqlReader["os"]) == choose2)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex != 0 && comboBox4.SelectedIndex != 0)
                        {
                            if (Convert.ToString(sqlReader["memory"]) == choose3 && Convert.ToString(sqlReader["ram"]) == choose4)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex != 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1 && Convert.ToString(sqlReader["os"]) == choose2 && Convert.ToString(sqlReader["memory"]) == choose3)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex != 0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1 && Convert.ToString(sqlReader["os"]) == choose2 && Convert.ToString(sqlReader["ram"]) == choose4)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1 && Convert.ToString(sqlReader["memory"]) == choose3 && Convert.ToString(sqlReader["ram"]) == choose4)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex != 0 && comboBox4.SelectedIndex == 0)
                        {
                            if (Convert.ToString(sqlReader["os"]) == choose2 && Convert.ToString(sqlReader["memory"]) == choose3 && Convert.ToString(sqlReader["ram"]) == choose4)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }

                        if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex != 0 && comboBox4.SelectedIndex != 0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1 && Convert.ToString(sqlReader["os"]) == choose2 && Convert.ToString(sqlReader["memory"]) == choose3 && Convert.ToString(sqlReader["ram"]) == choose4)
                            {
                                dataProducts.Add(new string[9]);

                                dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                refreshTable(null);
                            }
                        }
                    }

                }

                else
                {
                    if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)
                        && !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
                    {

                        {
                            while (await sqlReader.ReadAsync())
                            {
                                if (Convert.ToInt32(sqlReader["price"]) >= Convert.ToInt32(textBox7.Text) && Convert.ToInt32(sqlReader["price"]) <= Convert.ToInt32(textBox8.Text))
                                {
                                    dataProducts.Add(new string[9]);

                                    dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                    dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                    dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                    dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                    dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                    dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                    dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                    dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                    dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                }

                            }

                            refreshTable(null);
                        }
                    }

                    if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)
                        && string.IsNullOrEmpty(textBox8.Text) && string.IsNullOrWhiteSpace(textBox8.Text))
                    {

                        {
                            while (await sqlReader.ReadAsync())
                            {
                                if (Convert.ToInt32(sqlReader["price"]) >= Convert.ToInt32(textBox7.Text))
                                {
                                    dataProducts.Add(new string[9]);

                                    dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                    dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                    dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                    dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                    dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                    dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                    dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                    dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                    dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                }

                            }

                            refreshTable(null);
                        }
                    }

                    if (string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrWhiteSpace(textBox7.Text)
                        && !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
                    {

                        {
                            while (await sqlReader.ReadAsync())
                            {
                                if (Convert.ToInt32(sqlReader["price"]) <= Convert.ToInt32(textBox8.Text))
                                {
                                    dataProducts.Add(new string[9]);

                                    dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                                    dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                                    dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                                    dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                                    dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                                    dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                                    dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                                    dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                                    dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                                }

                            }

                            refreshTable(null);
                        }
                    }

                    if (string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrWhiteSpace(textBox7.Text)
                        && string.IsNullOrEmpty(textBox8.Text) && string.IsNullOrWhiteSpace(textBox8.Text))
                    {
                        while (await sqlReader.ReadAsync())
                        {

                            dataProducts.Add(new string[9]);

                            dataProducts[dataProducts.Count - 1][0] = Convert.ToString(sqlReader["productId"]);
                            dataProducts[dataProducts.Count - 1][1] = Convert.ToString(sqlReader["name"]);
                            dataProducts[dataProducts.Count - 1][2] = Convert.ToString(sqlReader["price"]);
                            dataProducts[dataProducts.Count - 1][3] = Convert.ToString(sqlReader["camera"]);
                            dataProducts[dataProducts.Count - 1][4] = Convert.ToString(sqlReader["os"]);
                            dataProducts[dataProducts.Count - 1][5] = Convert.ToString(sqlReader["ram"]);
                            dataProducts[dataProducts.Count - 1][6] = Convert.ToString(sqlReader["memory"]);
                            dataProducts[dataProducts.Count - 1][7] = Convert.ToString(sqlReader["resolution"]);
                            dataProducts[dataProducts.Count - 1][8] = Convert.ToString(sqlReader["amount"]);
                        }

                        refreshTable(null);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 login = new Form3();
            login.ShowDialog();
            Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;

            SqlDataReader sqlReaderProd = null;

            SqlCommand commandProd = new SqlCommand("SELECT * FROM [Products]", sqlConnection);

            try
            {
                sqlReaderProd = await commandProd.ExecuteReaderAsync();

                while (await sqlReaderProd.ReadAsync())
                {
                    if (Convert.ToString(textBox1.Text) == Convert.ToString(sqlReaderProd["ProductId"]))
                        if (Convert.ToInt32(sqlReaderProd["amount"]) != 0)
                        {
                            int amount = Convert.ToInt32(sqlReaderProd["amount"]);
                            amount--;

                            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                                && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                                && comboBox5.SelectedIndex != -1)
                            {
                                sqlReaderProd.Close();

                                SqlCommand command1 = new SqlCommand("INSERT INTO [Order] (productId, userId, paymentMethod)VALUES(@productId, @userId, @paymentMethod)", sqlConnection);

                                command1.Parameters.AddWithValue("productId", textBox1.Text);
                                command1.Parameters.AddWithValue("userId", textBox2.Text);
                                command1.Parameters.AddWithValue("paymentMethod", comboBox5.SelectedItem);

                                await command1.ExecuteNonQueryAsync();

                                SqlCommand command2 = new SqlCommand("UPDATE [Products] SET [amount]=@amount WHERE [productId]=@productId", sqlConnection);

                                command2.Parameters.AddWithValue("amount", amount);
                                command2.Parameters.AddWithValue("productId", textBox1.Text);

                                await command2.ExecuteNonQueryAsync();

                                Hide();
                                Form10 fanks = new Form10();
                                fanks.ShowDialog();
                                Close();
                            }

                            else
                            {
                                label5.Visible = true;
                                label5.Text = "Все поля должны быть заполнены или товара нет в наличии";

                            }
                        }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (sqlReaderProd != null)
                    sqlReaderProd.Close();
            }

        }
    }
}
