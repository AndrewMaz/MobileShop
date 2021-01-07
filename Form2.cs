using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkingWithBD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 adminLogin = new Form4();
            adminLogin.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 guest = new Form6();
            guest.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 login = new Form3();
            login.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form8 register = new Form8();
            register.ShowDialog();
            Close();
        }
