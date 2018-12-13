using System;
using System.Drawing;
using System.Windows.Forms;




namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();

            this.panel1.MouseWheel += new MouseEventHandler(this.panel1_MouseWheel);

        }
        // Отвечает за приближение или отдаление 
        private int zoom = 1;
        private double zoomfactor = 2;
        private int iter;
        private void ZoomIn()
        {
            SetZOOMFactor(true);
            
                pictureBox1.Width = Convert.ToInt32(pictureBox1.Width * zoomfactor);
                pictureBox1.Height = Convert.ToInt32(pictureBox1.Height * zoomfactor);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ZoomOut()
        {
            SetZOOMFactor(false);

                pictureBox1.Width = Convert.ToInt32(pictureBox1.Width * zoomfactor);
                pictureBox1.Height = Convert.ToInt32(pictureBox1.Height * zoomfactor);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void SetZOOMFactor(bool tmp)
        {
            if (tmp)
            {
                if (zoom == 1)
                {
                    zoomfactor = 2;
                    zoom = 2;
                }
                else if (zoom == 2)
                {
                    zoomfactor = 1.5;
                    zoom = 3;
                }
                else if (zoom == 3)
                {
                    zoomfactor = 5/3.0;
                    zoom = 5;
                }
                else if (zoom == 5)
                {
                    zoomfactor = 1;
                    
                }
            }
            else
            {
                if (zoom == 1)
                {
                    zoomfactor = 1;
                    pictureBox1.Location = pictureBox2.Location;

                }
                else if (zoom == 2)
                {
                    
                    zoomfactor = 0.5;
                    zoom = 1;
                    
                }
                else if (zoom == 3)
                {
                    zoomfactor = 2/3.0;
                    zoom = 2;
                }
                else if (zoom == 5)
                {
                    zoomfactor = 3/5.0;
                    zoom = 3;

                }
            }
            
        }
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta>0 )
            {
                
                ZoomIn();
            }
           
            else
            {
                ZoomOut();
            }
        }
        bool flagmousebutton = false;
        int mouseX, mouseY;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                flagmousebutton = true;
              
                    mouseX = e.X;
                    mouseY = e.Y;

                this.Cursor = Cursors.Hand;
            }
        }
        //
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (flagmousebutton == true)
            {
                flagmousebutton = false;
                this.Cursor = Cursors.Default;
            }
        }
        int countx = 0;
        int county = 0;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (flagmousebutton == true)
            {
                int dx = e.X - mouseX;
                int dy = e.Y - mouseY;
                countx += dx;
                county += dy;
                int sumx = control.Height - control.Height / 2;
                
                //if (pictureBox1.Location.X <= label1.Location.X + pictureBox1.Location.X/10)
                    pictureBox1.Location = new Point(pictureBox1.Location.X + dx, pictureBox1.Location.Y + dy);
            }
        }

        public Graphics g; //Графика
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus(); // установка фокуса
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = String.Format("Текущее значение: {0}", trackBar1.Value);
            iter = trackBar1.Value;
        }

        private void содержаниеToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                button2.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value >= 13 || trackBar1.Value <= 1)
                MessageBox.Show("Заполните, пожалуйста, все поля");
            else
            {

                if (button1.BackColor == button2.BackColor) MessageBox.Show("Внимание, начальные и конечные цвета совпадают");
                var map = new Bitmap(pictureBox1.Width, pictureBox1.Height);//Подключаем Битмап
                g = Graphics.FromImage(map); //Подключаем графику
                g.Clear(Color.Black);
                /*
                T_fractal T = new T_fractal(trackBar1.Value, button1.BackColor, button2.BackColor, g);
                PointF A = new PointF(pictureBox1.Width / 2 - pictureBox1.Height / 4, pictureBox1.Height / 4);
                T.Draw(A, pictureBox1.Height / 2 - pictureBox1.Height / 10, iter);
                pictureBox1.BackgroundImage = map;
                pictureBox1.Image = map;
                */
                /*
                H_fractal H = new H_fractal(trackBar1.Value, button1.BackColor, button2.BackColor, g);
                H.Draw(pictureBox1.Size.Height/2, pictureBox1.Size.Height / 2, pictureBox1.Size.Height / 4);
                pictureBox1.BackgroundImage = map;
                pictureBox1.Image = map;
                */
                O_fractal O = new O_fractal(trackBar1.Value, button1.BackColor, button2.BackColor, g);
                PointF A = new PointF(pictureBox1.Width / 2 - pictureBox1.Height / 4, pictureBox1.Height / 4);
                O.Draw(A, pictureBox1.Height / 2 - pictureBox1.Height / 10, iter);
                pictureBox1.BackgroundImage = map;
                pictureBox1.Image = map;
            }
                
               
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }
       
        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            zoom = 1;
            zoomfactor = 2;
        /*
        if (control.Size.Height != control.Size.Width)
        {
            control.Size = new Size(control.Size.Height, control.Size.Width);
        }
        */
        panel1.Width = control.Size.Height;
            panel1.Height = control.Size.Height;
            pictureBox1.Width = control.Size.Height;
            pictureBox1.Height = control.Size.Height;
            pictureBox2.Width = control.Size.Height;
            pictureBox2.Height = control.Size.Height;
            /*
            var map = new Bitmap(pictureBox1.Width, pictureBox1.Height);//Подключаем Битмап
            g = Graphics.FromImage(map); //Подключаем графику
            g.Clear(Color.Black);
            T_fractal T = new T_fractal(trackBar1.Value, button1.BackColor, button2.BackColor, g);
            PointF A = new PointF(pictureBox1.Width / 2 - pictureBox1.Height / 4, pictureBox1.Height / 4);
            T.Draw(A, pictureBox1.Height / 2 - pictureBox1.Height / 10, iter);
            pictureBox1.BackgroundImage = map;
            pictureBox1.Image = map;
            */
            var map = new Bitmap(pictureBox1.Width, pictureBox1.Height);//Подключаем Битмап
            g = Graphics.FromImage(map); //Подключаем графику
            g.Clear(Color.Black);
            O_fractal O = new O_fractal(trackBar1.Value, button1.BackColor, button2.BackColor, g);
            PointF A = new PointF(pictureBox1.Width / 2 - pictureBox1.Height / 4, pictureBox1.Height / 4);
            O.Draw(A, pictureBox1.Height / 2 - pictureBox1.Height / 10, iter);
            pictureBox1.BackgroundImage = map;
            pictureBox1.Image = map;
        }



    }
}
    

