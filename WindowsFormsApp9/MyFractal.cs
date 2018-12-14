using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp9
{
    class MyFractal : Fractal
    {

        Size size { get; set; }
        public MyFractal(int Iter, Color StartColor, Color EndColor, Graphics g) : base(Iter, StartColor, EndColor, g)
        {
        }
        override public int Draw(PointF A, int size, int iter)
        {
            RectangleF R = new RectangleF(A.X, A.Y, size, size);
            Color[] colors = Grad();
            if (iter == 1)
            {

                //g.FillRectangle(new SolidBrush(colors[0]), A.X, A.Y, size, size);
                grafika.FillEllipse(new SolidBrush(colors[iter - 1]), R);
                return 0;
            }
            R = new RectangleF(A.X, A.Y, size, size);
            grafika.FillEllipse(new SolidBrush(colors[iter - 1]), R);

            // g.FillRectangle(new SolidBrush(colors[iter - 1]), A.X, A.Y, size, size);
            int d = size / 4; 
            PointF[] M = new PointF[4];  //Координаты левых верхних углов порожденных квадратов

            for (int i = 0; i < 4; i++)
            {
                M[i] = new PointF();
            }

            //Левый верхний квадрат
            M[0].X = A.X - d;
            M[0].Y = A.Y - d;

            //Левый нижний квадрат
            M[1].X = A.X - d;
            M[1].Y = A.Y + size - d;

            //Правый верхний квадрат
            M[2].X = A.X + size - d;
            M[2].Y = A.Y - d;

            //Правый нижний квадрат
            M[3].X = A.X + size - d;
            M[3].Y = A.Y + size - d;

            //Вызываем рекурсивно для каждого квадрата
            for (int i = 0; i < 4; i++)
            {
                Draw(M[i], size / 2, iter - 1);
            }

            return 0;
        }
    }
}
