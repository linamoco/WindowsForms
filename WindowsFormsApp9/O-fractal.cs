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
                grafika.FillEllipse(new SolidBrush(colors[iter - 1]), R);
                return 0;
            }
            else
            {
                
               grafika.FillEllipse(new SolidBrush(colors[iter - 1]), R);

                
                float d = (float)(size / 6.0); //Радиус круга следующей итерации
                PointF[] сoordinates = new PointF[7];  //Координаты левых верхних углов порожденных квадратов, а которые вписываются круги

                for (int i = 0; i < 7; i++)
                {
                    сoordinates[i] = new PointF();
                }
                // Координаты
                //Средний круг
                сoordinates[6].X = A.X + size/3;
                сoordinates[6].Y = A.Y + size/3;
                
                //Левый верхний круг
                сoordinates[0].X = A.X + (float)(size/2-d*(Math.Sqrt(3) + 1));
                сoordinates[0].Y = A.Y + d;

                //Левый нижний круг
                сoordinates[5].X = A.X +(float)(size / 2 - d * (Math.Sqrt(3) + 1));
                сoordinates[5].Y = A.Y + size/2;
                //Верхний круг
                сoordinates[4].X = A.X + size / 2 - d;
                сoordinates[4].Y = A.Y ;
                //Нижний круг
                сoordinates[1].X = A.X + size / 2 - d;
                сoordinates[1].Y = A.Y + size / 2 + d;
                //Правый верхний круг
                сoordinates[2].X = A.X + size/2 + d - (float)(size / 2 - d * (Math.Sqrt(3) + 1));
                сoordinates[2].Y = A.Y + d;

                //Правый нижний круг
                сoordinates[3].X = A.X + +size / 2 + d - (float)(size / 2 - d * (Math.Sqrt(3) + 1));
                сoordinates[3].Y = A.Y + +size / 2;
                
                //Вызываем рекурсивно для каждого круга

                
                for (int i = 0; i < 7; i++)
                {
                    Draw(сoordinates[i], size/3, iter - 1);
                }
                
                return 0;
            }
           
        }
    }
}
