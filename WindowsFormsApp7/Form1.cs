using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Visible = false; // скрыть кнопку


        }
        string[] lines = new string[]
       { "один", "два", "три", "четыре", "пять", "шесть", "семь" };


        private void Form1_Load(object sender, EventArgs e)
        {

        }
 

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Lines = lines;
            button2.Visible = true;		// показать вторую кнопку
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // В textBox1.Lines - измененный список 
            string res = string.Join("  ", textBox1.Lines);
            MessageBox.Show("Результат изменений:\n" + res);
        }
    }
}
