using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    class Tube : Label
    {
        

        public Tube(int x, int height, string orien)
        {
            this.Width = 20;
            this.Height = height;
            this.Left = x;
            this.BackColor = Color.Blue;
            if (orien == "up")
                this.Top = 200;
            else
                this.Top = 50;
        }
        public void update()
        {
            if (this.Left > 0)
                this.Left -= 2;
            else
            {
                this.Left = 300;
                this.Height = 30 + new Random().Next(10, 20);
            }
                
        }
    }
}
