using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                label1.Text = text;
            }
            int old = 1, last = 0;
            string text = "Член ряда Пелла: ";

            private void button1_Click(object sender, EventArgs e)
            {
                // 3ащита от переполнения:
                if (old > int.MaxValue - last - last)
                {
                    // Диалоговое окно, захватывающее фокус: 
                    MessageBox.Show("Переполнение!" +
                            " \n Ряд начнем с начала!");
                    last = 0; old = 1;
                }
                // Локальная переменная метода:
                int now = old + 2 * last;
                old = last; last = now;
                label1.Text = text + now.ToString();
            } // button1_Click
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
