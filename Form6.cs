private void refreshTable(string searchStr)
        {
            if (searchStr == null)
            {
                foreach (string[] row in dataProducts)
                    dataGridView1.Rows.Add(row);
            }
        }
        private async void Form6_Load(object sender, EventArgs e)
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

        private async void button4_Click(object sender, EventArgs e)
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
            Form2 mainMenu = new Form2();
            mainMenu.ShowDialog();
            Close();
        }
    }
}
