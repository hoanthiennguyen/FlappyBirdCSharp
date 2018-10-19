using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    class GameBoard : Panel
    {
        public Bird bird = new Bird();
        Tube upTube = new Tube(300,50,"up");
        Tube downTube = new Tube(300, 50, "down");
        int score = 0;
        Label lbScore = new Label();
        
        public GameBoard()
        {
            this.Top = 50;
            this.Width = 500;
            this.Height = 300;
            this.BackColor = Color.Azure;
            addComponenets();
        }
        public void addComponenets()
        {
            this.Controls.Add(bird);
            this.Controls.Add(upTube);
            this.Controls.Add(downTube);

            Label lbText = new Label();
            lbText.Text = "Score";
            lbText.Width = 35;
            this.Controls.Add(lbText);

            lbScore.Text = "0";
            lbScore.Left = 40;
            this.Controls.Add(lbScore);
            
        }
        public bool update()
        {
            bird.update();
            upTube.update();
            downTube.update();
            if(bird.passing(upTube))
            {
                score++;
                lbScore.Text = score.ToString();
            }
            
            if (bird.colliding(upTube) || bird.colliding(downTube))
                return false;
            else
                return true;
        }
        
        
    }
}
