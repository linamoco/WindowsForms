using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp9
{
    class H_fractal : Fractal
    {
        public H_fractal(int Iter, Color StartColor, Color EndColor, Graphics g) : base(Iter, StartColor, EndColor, g)
        {
        }
        public void H1(int x, int y, int razmer, Color color)//функция отрисовки одной Н
        {
            //Выбираем перо "myPen" черного цвета Black
            //толщиной в 1 пиксель:
            Pen myPen = new Pen(color, 1);
            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            g.DrawLine(myPen, x - razmer, y - razmer, x - razmer, y + razmer);
            g.DrawLine(myPen, x - razmer, y, x + razmer, y);
            g.DrawLine(myPen, x + razmer, y - razmer, x + razmer, y + razmer);
        }

        public int Draw(int x1, int y1, int razm_f)
        {
            var colors = Grad();
            //вершины фигуры Н
            int x11; int y11;
            int x01; int y01;
            int x00; int y00;
            int x10; int y10;
            x11 = x1 + razm_f;
            y11 = y1 + razm_f;
            x01 = x1 - razm_f;
            y01 = y1 + razm_f;
            x10 = x1 + razm_f;
            y10 = y1 - razm_f;
            x00 = x1 - razm_f;
            y00 = y1 - razm_f;


            H1(x1, y1, razm_f, colors[Iter - 1]);//рисуем одну фигуру Н
            razm_f = razm_f / 2;//уменьшаем размер в 2 раза
                                // если размер не меньше минимального, то рисуем в 4-х вершинах
            if (Iter > 1)
            {
                Draw(x11, y11, razm_f);
                Draw(x01, y01, razm_f);
                Draw(x10, y10, razm_f);
                Draw(x00, y00, razm_f);
            }
            else return 0;
            return 0;
        }

        private int height_;
        private int width_;

    }
}