using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp9
{
    class O_fractal : Fractal
    {
        public double StartRad{get;}
        public O_fractal(int Iter, Color StartColor, Color EndColor, Graphics g) : base(Iter, StartColor, EndColor, g)
        {
        }

        Size size { get; set; }
  
        override public int Draw(PointF A, int size, int iter)
        {
            RectangleF R = new RectangleF(A.X, A.Y, size, size); // Создали квадрат заданных размеров 
            Color[] colors = Grad(); //Массив цветов
            //Если итерация одна, то рисуем просто круг
            if (iter == 1)
            {
                g.FillEllipse(new SolidBrush(colors[iter - 1]), R);
                return 0;
            }
            else
            {
                
               g.FillEllipse(new SolidBrush(colors[iter - 1]), R);

                
                float d = (float)(size / 6.0); //Вспомогательная переменная, шестая длины исходного квадрата
                PointF[] M = new PointF[7];  //Координаты левых верхних углов порожденных квадратов

                for (int i = 0; i < 7; i++)
                {
                    M[i] = new PointF();
                }
                //Среднйи круг
                M[6].X = A.X + size/3;
                M[6].Y = A.Y + size/3;
                
                //Левый верхний квадрат
                M[0].X = A.X + (float)(size/2-d*(Math.Sqrt(3) + 1));
                M[0].Y = A.Y + d;

                //Левый нижний квадрат
                M[5].X = A.X +(float)(size / 2 - d * (Math.Sqrt(3) + 1));
                M[5].Y = A.Y + size/2;
                //Верхний
                M[4].X = A.X + size / 2 - d;
                M[4].Y = A.Y ;
                //Нижний
                M[1].X = A.X + size / 2 - d;
                M[1].Y = A.Y + size / 2 + d;
                //Правый верхний квадрат
                M[2].X = A.X + size/2 + d - (float)(size / 2 - d * (Math.Sqrt(3) + 1));
                M[2].Y = A.Y + d;

                //Правый нижний квадрат
                M[3].X = A.X + +size / 2 + d - (float)(size / 2 - d * (Math.Sqrt(3) + 1));
                M[3].Y = A.Y + +size / 2;
                
                //Вызываем рекурсивно для каждого квадрата

                
                for (int i = 0; i < 7; i++)
                {
                    Draw(M[i], size/3, iter - 1);
                }
                
                return 0;
            }
           
        }
    }
}
