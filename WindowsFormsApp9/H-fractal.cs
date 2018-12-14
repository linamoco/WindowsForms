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

        private void H(int x, int y, int razmer)
        {


            Color[] colors = Grad(); //Массив цветов
            g.DrawLine(new Pen(colors[Iter-1], 5), x - razmer, y - razmer, x - razmer, y + razmer);
            g.DrawLine(new Pen(colors[Iter-1], 5), x - razmer, y, x + razmer, y);
            g.DrawLine(new Pen(colors[Iter-1], 5), x + razmer, y - razmer, x + razmer, y + razmer);
        }
        int x11; int y11;
        int x01; int y01;
        int x00; int y00;
        int x10; int y10;
        public override int Draw(int x1, int y1, int razm_f, int iter)
        {
           
            x11 = x1 + razm_f;
            y11 = y1 + razm_f;
            x01 = x1 - razm_f;
            y01 = y1 + razm_f;
            x10 = x1 + razm_f;
            y10 = y1 - razm_f;
            x00 = x1 - razm_f;
            y00 = y1 - razm_f;


            if (iter <= 1)
            {

                H(x1, y1, razm_f);
                razm_f = razm_f / 2;
                                    
                return 0;
            }
            else
            {
                Draw(x11, y11, razm_f, iter  -1);
                Draw(x01, y01, razm_f, iter  -1);
                Draw(x10, y10, razm_f, iter - 1);
                Draw(x00, y00, razm_f, iter - 1);
            }
            return 0;
    

        }

    }
}