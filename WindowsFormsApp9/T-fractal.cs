using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp9
{
    class T_fractal : Fractal
    {
        Size size { get; set; }
        public T_fractal(int Iter, Color StartColor, Color EndColor, Graphics g) : base(Iter, StartColor, EndColor, g)
        {
        }
        override public int Draw(PointF A, int size, int iter)
        {
            Color[] colors = Grad(); //массив цветов
            if (iter == 1)
            {
                grafika.FillRectangle(new SolidBrush(colors[0]), A.X, A.Y, size, size);
                return 0;
            }
            //g.FillEllipse
            grafika.FillRectangle(new SolidBrush(colors[iter - 1]), A.X, A.Y, size, size);
            int d = size / 4; // сторона квадрата следующей операции
            PointF[] coordinates = new PointF[4];  //Координаты левых верхних углов порожденных квадратов

            for (int i = 0; i < 4; i++)
            {
                coordinates[i] = new PointF();
            }

            //Левый верхний квадрат
            coordinates[0].X = A.X - d;
            coordinates[0].Y = A.Y - d;

            //Левый нижний квадрат
            coordinates[1].X = A.X - d;
            coordinates[1].Y = A.Y + size - d;

            //Правый верхний квадрат
            coordinates[2].X = A.X + size - d;
            coordinates[2].Y = A.Y - d;

            //Правый нижний квадрат
            coordinates[3].X = A.X + size - d;
            coordinates[3].Y = A.Y + size - d;

            //Вызываем рекурсивно для каждого квадрата
            for (int i = 0; i < 4; i++)
            {
                Draw(coordinates[i], size / 2, iter - 1);
            }

            return 0;
        }
    }
}
