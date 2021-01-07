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
    public partial class Form8 : Form
    {
        SqlConnection sqlConnection;
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 mainMenu = new Form2();
            mainMenu.ShowDialog();
            Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Andrey\source\repos\WorkingWithBD\WorkingWithBD\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            if (label7.Visible)
                label7.Visible = false;

            if (
                   !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [User] (login, pass, name, surname, adress, phoneNumber)VALUES(@login, @pass, @name, @surname, @adress, @phoneNumber)", sqlConnection);

                command.Parameters.AddWithValue("login", textBox1.Text);
                command.Parameters.AddWithValue("pass", textBox2.Text);
                command.Parameters.AddWithValue("name", textBox3.Text);
                command.Parameters.AddWithValue("surname", textBox4.Text);
                command.Parameters.AddWithValue("adress", textBox5.Text);
                command.Parameters.AddWithValue("phoneNumber", textBox6.Text);

                await command.ExecuteNonQueryAsync();

                Hide();
                Form12 fanks = new Form12();
                fanks.ShowDialog();
                Close();
            }

            else
            {
                label7.Visible = true;
                label7.Text = "Все обязательные поля должны быть заполнены";
            }
        }
