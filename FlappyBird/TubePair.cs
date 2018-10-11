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
            Random rd = new Random();
            int variation = rd.Next(10,21);
            upTube = new Tube(x, 50 + variation, "up");
            downTube = new Tube(x, 50 - variation, "down");
            
        }
        public void update()
        {
            if (upTube.Left >= 0)
            {
                upTube.Left -= 2;
                downTube.Left -= 2;
            }
            else
            {
                upTube.Left = 350;
                downTube.Left = 350;
            }
        }
    }
}
