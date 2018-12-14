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
        //рисует 1 букву Н по заданным координатам ыершин буквы Н
        private void H(int x, int y, int hight, Color color)
        {


            
            grafika.DrawLine(new Pen(color, 5), x - hight, y - hight, x - hight, y + hight);
            grafika.DrawLine(new Pen(color, 5), x - hight, y, x + hight, y);
            grafika.DrawLine(new Pen(color, 5), x + hight, y - hight, x + hight, y + hight);
        }
        int x1; int y1;
        int x2; int y2;
        int x3; int y3;
        int x4; int y4;
        public override int Draw(int x1, int y1, int hight, int iter)
        {
            Color[] colors = Grad(); //Массив цветов
            this.x1 = x1 + hight;
            this.y1 = y1 + hight;
            x2 = x1 - hight;
            y2 = y1 + hight;
            x4 = x1 + hight;
            y4 = y1 - hight;
            x3 = x1 - hight;
            y3 = y1 - hight;


            if (iter <= 1)
            {

                H(x1, y1, hight, colors[iter]);
                hight = hight / 2;
                                    
                return 0;
            }
            else
            {
                H(x1, y1, hight, colors[iter]);
                hight = hight / 2;
                Draw(this.x1, this.y1, hight, iter  -1);
                Draw(x2, y2, hight, iter  -1);
                Draw(x4, y4, hight, iter - 1);
                Draw(x3, y3, hight, iter - 1);
            }
            return 0;
    

        }

    }
}