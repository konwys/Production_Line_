using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace linia_produkcyjna
{ 
    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
        }

        Form2 okno1;

        private void button1_Click(object sender, EventArgs e)
        { 
           
            if (textBox1.Text=="admin" && textBox2.Text=="admin" )
            {
                this.Hide();
                okno1 = new Form2();
                okno1.Show();
            }
            else
            {
                MessageBox.Show("Niepoprawne hasło lub login");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
