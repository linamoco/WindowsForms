using System;
using System.Drawing;
using System.Windows.Forms;




namespace WindowsFormsApp9
{
    public partial class FractalForm : Form
    {
        // Конструктор класса FractalForm
        public FractalForm()
        {
            InitializeComponent();

            this.panel1.MouseWheel += new MouseEventHandler(this.panel1_MouseWheel);

        }
        // Отвечает за приближение или отдаление 
        private int zoom = 1; // Увеличение в данный момент
        private double zoomfactor = 2; // На сколько надо увеличить 
        private int iter; // глубина  рекурсии(задается пользователем)
        /// <summary>
        /// Увеличивает масштаб изображения, если колесико мышки прокрутилось вперед
        /// </summary>
        private void ZoomIn()
        {
            SetZOOMFactor(true);

            pictureBox1.Width = Convert.ToInt32(pictureBox1.Width * zoomfactor);
            pictureBox1.Height = Convert.ToInt32(pictureBox1.Height * zoomfactor);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        /// Уменьшает масштаб изображения, если колесико мышки прокрутилось назад
        /// </summary>
        private void ZoomOut()
        {
            SetZOOMFactor(false);

            pictureBox1.Width = Convert.ToInt32(pictureBox1.Width * zoomfactor);
            pictureBox1.Height = Convert.ToInt32(pictureBox1.Height * zoomfactor);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        /// <summary>
        /// Определяет, насколько надо увеличить или уменьшить масштаб изображения
        /// </summary>
        /// <param name="tmp">показывает, в какую сторону прокрутилось коллесико мышки</param>
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
                    zoomfactor = 5 / 3.0;
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
                    // возвратить изображение на первоначальные координаты
                    pictureBox1.Location = pictureBox2.Location;

                }
                else if (zoom == 2)
                {

                    zoomfactor = 0.5;
                    zoom = 1;

                }
                else if (zoom == 3)
                {
                    zoomfactor = 2 / 3.0;
                    zoom = 2;
                }
                else if (zoom == 5)
                {
                    zoomfactor = 3 / 5.0;
                    zoom = 3;

                }
            }

        }
        // Событие колесика мышки
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                ZoomIn();
            }

            else
            {
                ZoomOut();
            }
        }
        bool flagmousebutton = false; // true, если нажата левая кнопка мышки
        int mouseX, mouseY;
        // Событие нажатия кнопки мышки
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                flagmousebutton = true;
                // координаты мышки при нажатии левой кнопки
                mouseX = e.X; 
                mouseY = e.Y;
                // изменить форму курсора
                this.Cursor = Cursors.Hand;
            }
        }
        // Событие : кнопка мыши была отпущена
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (flagmousebutton == true)
            {
                flagmousebutton = false;
                this.Cursor = Cursors.Default; // вернуть курсор в обычный вид
            }
        }
        // передвижение мышки с нажатой кнопкой
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Форма
            Control control = (Control)sender;
            if (flagmousebutton == true)
            { 
                // разность старых и новых координат
                int dx = e.X - mouseX;
                int dy = e.Y - mouseY;

                int sumx = control.Height - control.Height / 2;
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
            if(comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Заполните, пожалуйста, все поля");
            }
            else
            {
                try
                {

                    Event();

                }
                catch (IndexOutOfRangeException) { MessageBox.Show("Заполните, пожалуйста, все поля"); }
            }
            

        }
        
        O_fractal O;
        T_fractal T;
        MyFractal M;
        H_fractal H;

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void Event()
        {

            Bitmap map = new Bitmap(pictureBox1.Width, pictureBox1.Height);//Подключаем Битмап
            Graphics gH = Graphics.FromHwnd(pictureBox1.Handle);
            g = Graphics.FromImage(map); //Подключаем графику
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Включаем сглаживание
            g.Clear(Color.Black);
            if (comboBox1.SelectedIndex == 0)
            {
                O = new O_fractal(trackBar1.Value, button1.BackColor, button2.BackColor, g);
                PointF A = new PointF(0, 0);
                O.Draw(A, pictureBox1.Height - 60, iter);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                T = new T_fractal(trackBar1.Value, button1.BackColor, button2.BackColor, g);
                PointF A = new PointF(pictureBox1.Width / 2 - pictureBox1.Height / 4, pictureBox1.Height / 4);
                T.Draw(A, pictureBox1.Height / 2 - pictureBox1.Height / 10, iter);

            }
            if (comboBox1.SelectedIndex == 2)
            {
                M = new MyFractal(trackBar1.Value, button1.BackColor, button2.BackColor, g);
                PointF A = new PointF(pictureBox1.Width / 2 - pictureBox1.Height / 4, pictureBox1.Height / 4);
                M.Draw(A, pictureBox1.Height / 2 - pictureBox1.Height / 10, iter);
            }
            pictureBox1.BackgroundImage = map;
            pictureBox1.Image = map;
            if (comboBox1.SelectedIndex == 3)
            {

                H_fractal H = new H_fractal(trackBar1.Value, button1.BackColor, button2.BackColor, gH);
                H.Draw(pictureBox1.Size.Height / 2, pictureBox1.Size.Height / 2, pictureBox1.Size.Height / 4, iter);
                map = (System.Drawing.Bitmap)pictureBox1.BackgroundImage;
                pictureBox1.Image = map;
            }

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            zoom = 1;
            zoomfactor = 2;
            panel1.Width = control.Size.Height;
            panel1.Height = control.Size.Height;
            pictureBox1.Width = control.Size.Height;
            pictureBox1.Height = control.Size.Height;
            pictureBox2.Width = control.Size.Height;
            pictureBox2.Height = control.Size.Height;
            try
            {
                Event();
            }
            catch (IndexOutOfRangeException) { MessageBox.Show("Заполните, пожалуйста, все поля"); }

        }
    }
    
}




    

