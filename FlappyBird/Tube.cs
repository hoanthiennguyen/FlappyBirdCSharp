using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird
{
    class Tube : Label
    {
        readonly bool isUpward;
        const int UPPER_TOP = 20;
        const int BELOW_TOP = GameBoard.HEIGHT - HEIGHT;
        public const int HEIGHT = 50;

        public Tube(int x, int height, bool isUpward)
        {
            this.Width = 20;
            this.Height = height;
            this.Left = x;
            this.BackColor = Color.Blue;
            this.isUpward = isUpward;
            if (isUpward)
            {
                this.Top = BELOW_TOP + HEIGHT - height;
            }
            else
                this.Top = UPPER_TOP;
        }
        public void update(int newHeightForNewTurn)
        {
            if (this.Left > 0)
            {
                this.Left -= 2;
            }
            else
            {
                this.Left = GameBoard.WIDTH;
                if(isUpward)
                {
                    this.Top = BELOW_TOP + HEIGHT - newHeightForNewTurn;
                }
                this.Height = newHeightForNewTurn;
            }
                
        }
    }
}
