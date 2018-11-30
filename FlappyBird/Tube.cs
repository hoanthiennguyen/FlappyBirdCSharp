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
        readonly bool isUp;
        
        public Tube(int x, int height, bool isUp)
        {
            this.Width = 20;
            this.Height = height;
            this.Left = x;
            this.BackColor = Color.Blue;
            this.isUp = isUp;
            if (isUp)
                this.Top = 200;
            else
                this.Top = 50;
        }
        public void update(int newHeightForNewTurn)
        {
            if (this.Left > 0)
            {
                this.Left -= 2;
            }
            else
            {
                this.Left = GameBoard.TUBE_LEFT;
                if(isUp)
                {
                    this.Top = 200 + GameBoard.TUBE_HEIGHT - newHeightForNewTurn;
                }
                this.Height = newHeightForNewTurn;
            }
                
        }
    }
}
