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
        Random random = new Random();
        public Bird bird;
        const int TUBE_LEFT = 400;
        const int TUBE_HEIGHT = 50;
        const int TUBE_LEFT_AMPLITUDE = 40;
        const int TUBE_HEIGHT_AMPLITUDE = 30;

        int score = 0;
        Label lbScore;

        Tube upTube, downTube, upTube2, downTube2;
        
        public GameBoard()
        {
            this.Top = 50;
            this.Width = 500;
            this.Height = 300;
            this.BackColor = Color.Azure;
            initTubes();
            addComponenets();
        }
        private void initTubes()
        {
             upTube = new Tube(300, 50, "up");
             downTube = new Tube(300, 50, "down");
             upTube2 = new Tube(TUBE_LEFT + TUBE_LEFT_AMPLITUDE, 40, "up");
             downTube2 = new Tube(TUBE_LEFT + TUBE_LEFT_AMPLITUDE, 60, "down");
        }
        public void addComponenets()
        {
            bird = new Bird();
            this.Controls.Add(bird);

            this.Controls.Add(upTube);
            this.Controls.Add(downTube);
            this.Controls.Add(upTube2);
            this.Controls.Add(downTube2);

            Label lbText = new Label();
            lbText.Text = "Score";
            lbText.Width = 35;
            this.Controls.Add(lbText);

            lbScore = new Label();
            lbScore.Text = "0";
            lbScore.Left = 40;
            this.Controls.Add(lbScore);
            
        }
        private int createRandom(int A)
        {
            return random.Next(-A, A);
        }
        private void updatePair(Tube up, Tube down)
        {
            int tubeHeightVariation = createRandom(TUBE_HEIGHT_AMPLITUDE);
            int tubeLeftVariation = createRandom(TUBE_LEFT_AMPLITUDE);
            up.update(TUBE_HEIGHT + tubeHeightVariation, TUBE_LEFT + tubeLeftVariation);
            down.update(TUBE_HEIGHT - tubeHeightVariation, TUBE_LEFT + tubeLeftVariation);
        }
        public bool update()
        {
            bird.update();
            updatePair(upTube, downTube);
            updatePair(upTube2, downTube2);
            if (bird.passing(upTube) || bird.passing(upTube2))
            {
                score++;
                lbScore.Text = score.ToString();
            }
            
            if (bird.colliding(upTube) || bird.colliding(downTube) || bird.colliding(upTube2)|| bird.colliding(downTube2)
                || bird.Top <= 0 || bird.Bottom >= this.Height)
                return false;
            else
                return true;
        }
        
        
    }
}
