using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    class TubePair : Control
    {
        public Tube upTube;
        public Tube downTube;
        public TubePair(int x)
        {
            upTube = new Tube(x, 50, "up");
            downTube = new Tube(x, 50, "down");
        }
        public void update()
        {
            
        }

        public void AddedTo(GameBoard gameBoard)
        {
            gameBoard.Controls.Add(this.upTube);
            gameBoard.Controls.Add(this.downTube);
        }
    }
}
