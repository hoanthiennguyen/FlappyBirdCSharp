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

        Random random = new Random();
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
        public void update(int newHeightForNewTurn, int newLeftForNewTurn)
        {
            if (this.Left > -20)
            {
                this.Left -= 2;
                if (this.Left < 0) this.Visible = false;
            }
            else
            {
                this.Visible = true;
                this.Left = newLeftForNewTurn;
                this.Height = newHeightForNewTurn;
            }
                
        }
    }
}
