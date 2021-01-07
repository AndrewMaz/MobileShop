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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        List<string[]> dataProducts = new List<string[]>();
        public Form1()
        {
            InitializeComponent();
        }
	private void refreshTable(string searchStr)
        {
            if (searchStr==null)
            {
                foreach (string[] row in dataProducts)
                    dataGridView1.Rows.Add(row);
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text)&&!string.IsNullOrWhiteSpace(textBox1.Text) 
                && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                &&!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text)
                && !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)
                && !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text)
                && !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text)
                && !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text)
                && !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox14.Text))
            {

                SqlCommand command = new SqlCommand("INSERT INTO [Products] (name, price, camera, os, ram, memory, resolution, amount)VALUES(@name, @price, @camera, @os, @ram, @memory, @resolution, @amount)", sqlConnection);

                command.Parameters.AddWithValue("name", textBox1.Text);
                command.Parameters.AddWithValue("price", textBox2.Text);
                command.Parameters.AddWithValue("camera", textBox9.Text);
                command.Parameters.AddWithValue("os", textBox10.Text);
                command.Parameters.AddWithValue("ram", textBox11.Text);
                command.Parameters.AddWithValue("memory", textBox13.Text);
                command.Parameters.AddWithValue("resolution", textBox12.Text);
                command.Parameters.AddWithValue("amount", textBox14.Text);

                await command.ExecuteNonQueryAsync();
            }

            else
            {
                label7.Visible = true;
                label7.Text="Все поля должны быть заполнены";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
                label8.Visible = false;

            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)&&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Products] SET [name]=@name, [price]=@price WHERE [productId]=@productId", sqlConnection);

                command.Parameters.AddWithValue("productId", textBox5.Text);
                command.Parameters.AddWithValue("name", textBox4.Text);
                command.Parameters.AddWithValue("price", textBox3.Text);

                await command.ExecuteNonQueryAsync();

            }

            else
            {
                label8.Visible = true;
                label8.Text = "Все поля должны быть заполнены";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            if (label9.Visible)
                label9.Visible = false;

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Products] WHERE [productId]=@productId", sqlConnection);

                command.Parameters.AddWithValue("productId", textBox6.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Поле 'ID' должно быть заполнено";
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            dataProducts.Clear();
            dataGridView1.Rows.Clear();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Products]", sqlConnection);

            string choose1=null, choose2=null, choose3=null, choose4=null;
            

            choose1 = Convert.ToString(comboBox1.SelectedItem);
            choose2 = Convert.ToString(comboBox2.SelectedItem);
            choose3 = Convert.ToString(comboBox3.SelectedItem);
            choose4 = Convert.ToString(comboBox4.SelectedItem);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                if (comboBox1.SelectedIndex!=0 || comboBox2.SelectedIndex!=0 || comboBox3.SelectedIndex!=0 || comboBox4.SelectedIndex!=0)
                {
                    while (await sqlReader.ReadAsync())
                    {
                        if (comboBox1.SelectedIndex !=0 && comboBox2.SelectedIndex==0 && comboBox3.SelectedIndex==0 && comboBox4.SelectedIndex==0)
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

                        if (comboBox1.SelectedIndex !=0 && comboBox2.SelectedIndex !=0 && comboBox3.SelectedIndex ==0 && comboBox4.SelectedIndex ==0)
                        {
                            if (Convert.ToString(sqlReader["camera"]) == choose1 && Convert.ToString(sqlReader["os"])== choose2)
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

                        if (comboBox1.SelectedIndex !=0 && comboBox2.SelectedIndex ==0 && comboBox3.SelectedIndex !=0 && comboBox4.SelectedIndex ==0)
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

                        if (comboBox1.SelectedIndex !=0 && comboBox2.SelectedIndex ==0 && comboBox3.SelectedIndex ==0 && comboBox4.SelectedIndex !=0)
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
private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 admin = new Form5();
            admin.ShowDialog();
            Close();
        }


        private async void button6_Click(object sender, EventArgs e)
        {
            dataProducts.Clear();
            dataGridView1.Rows.Clear();

            string toSearch = Convert.ToString(textBox15.Text) + '%';

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Products] WHERE [name] LIKE @toSearch", sqlConnection);

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
    }
}
