using System;
using System.Drawing;

namespace WindowsFormsApp9
{
    abstract class Fractal
    {
        public Graphics grafika; //Графика
        public int MaxIter { get; } // количество итераций
        public int Iter { get; } // количество итераций
        public Color StartColor { get; } // Начальный цвет
        public Color EndColor { get; } // Конечный цвет
        // Конструктор класса фрактал
        public Fractal(int Iter, Color StartColor, Color EndColor, Graphics g)
        {
            this.Iter = Iter;
            this.StartColor = StartColor;
            this.EndColor = EndColor;
            this.grafika = g;
        }
        /// <summary>
        /// Создает массив цветов, которыми нужно сделать графиент
        /// </summary>
        /// <returns>массив цветов</returns>
        public Color[] Grad()
        {
            // массив цветов
            var colorArr = new Color[Iter];
            if (Iter != 1)
            {
                // разложение конечного и начальноого цвета на составляющие
                int rMax = EndColor.R;
                int rMin = StartColor.R;
                int gMax = EndColor.G;
                int gMin = StartColor.G;
                int bMax = EndColor.B;
                int bMin = StartColor.B;
                
                for (int i = 0; i < Iter; i++)

                {
               
                    var rAverage = rMin + (int)((rMax - rMin) * i / (Iter - 1));
                    var gAverage = gMin + (int)((gMax - gMin) * i / (Iter - 1));
                    var bAverage = bMin + (int)((bMax - bMin) * i / (Iter - 1));
                    // восстановить цвет по составляющим 
                    colorArr[i] = (Color.FromArgb(rAverage, gAverage, bAverage));
                }
                //цвета записали в обратном порядке, поэтому надо восстановить порядок
                Array.Reverse(colorArr);
                
            }
            // если итерация всего одна, то просто записываем начальный цвет
            else
                colorArr[0] = StartColor; 
            return colorArr;

        }
        virtual public int Draw(PointF A, int size, int iter)
        {
            return 0;
        }
        virtual public int Draw(int x1, int y1, int razm_f, int minimum)
        {
            return 0;
        }
        virtual public int Draw(int x, int y, double a, double b, Pen p)
        {
            return 0;
        }
        virtual public int Draw(int x1, int y1, int razm_f)
        {
            return 0;
        }

    }
}
