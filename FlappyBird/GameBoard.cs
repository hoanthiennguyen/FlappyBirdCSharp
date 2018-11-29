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
        public const int TUBE_LEFT = 400;
        public const int TUBE_HEIGHT = 50;
        public const int TUBE_HEIGHT_AMPLITUDE = 30;

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
             upTube2 = new Tube(TUBE_LEFT , 40, "up");
             downTube2 = new Tube(TUBE_LEFT, 60, "down");
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
            up.update(TUBE_HEIGHT + tubeHeightVariation);
            down.update(TUBE_HEIGHT - tubeHeightVariation);
        }
        public bool update()
        {
            bird.update();
            updateTubes();
            
            if (CheckColliding())
                return false;
            else
                return true;
        }
        private void updateTubes()
        {
            int i = 0;
            Random random = new Random();
            int deltaHeight = 10;
            foreach (Control control in this.Controls)
            {
                if (control is Tube tube)
                {
                    //upTube
                    if(i % 2 == 0)
                    {
                        deltaHeight = random.Next(-TUBE_HEIGHT_AMPLITUDE, TUBE_HEIGHT_AMPLITUDE);
                        if(bird.passing(tube))
                        {
                            score++;
                            lbScore.Text = score.ToString();
                        }
                        tube.update(TUBE_HEIGHT + deltaHeight);
                    }
                    //downTube
                    else
                        tube.update(TUBE_HEIGHT - deltaHeight);

                    i++;
                }
            }
        }
        private bool CheckColliding()
        {
            if (bird.Top <= 0 || bird.Bottom >= this.Height) return true;
            foreach(Control control in this.Controls)
            {
                if(control is Tube)
                {
                    if (bird.colliding(control)) return true;
                }
            }
            return false;
        }
        
    }
}
