using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    abstract class Fractal
    {
        public Graphics g; //Графика

        public int Iter { get; } // количество итераций
        public Color StartColor { get; } // Начальный цвет
        public Color EndColor { get; } // Конечный цвет
        // Конструктор класса фрактал
        public Fractal(int Iter, Color StartColor, Color EndColor, Graphics g)
        {
            this.Iter = Iter;
            this.StartColor = StartColor;
            this.EndColor = EndColor;
            this.g = g;
        }
        public Color[] Grad()
        {
            var colorArr = new Color[Iter];
            if (Iter != 1)
            {
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
                    colorArr[i] = (Color.FromArgb(rAverage, gAverage, bAverage));
                }
                Array.Reverse(colorArr);
                
            }
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
