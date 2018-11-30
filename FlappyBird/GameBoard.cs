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
        public Bird bird;
        public const int TUBE_LEFT = 500;
        public const int TUBE_HEIGHT = 50;
        public const int TUBE_HEIGHT_AMPLITUDE = 30;

        const int NUMBER_OF_TUBEPARIR = 5;
        const int GAP = 100;
        int score = 0;
        Label lbScore;

        
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
            bird = new Bird();
            this.Controls.Add(bird);
            AddTubes();

            Label lbText = new Label
            {
                Text = "Score",
                Width = 35
            };
            this.Controls.Add(lbText);

            lbScore = new Label
            {
                Text = "0",
                Left = 40
            };
            this.Controls.Add(lbScore);

        }

        private void AddTubes()
        {
            for (int i = 0; i < NUMBER_OF_TUBEPARIR*2; i++)
            {
                bool isUp = i % 2 == 0;
                Tube tube = new Tube(TUBE_LEFT + 120 - (i / 2) * GAP, 50, isUp);
                this.Controls.Add(tube);
            }
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
                        CalculateScore(tube);
                        tube.update(TUBE_HEIGHT + deltaHeight);
                    }
                    //downTube
                    else
                        tube.update(TUBE_HEIGHT - deltaHeight);

                    i++;
                }
            }
        }
        private void CalculateScore(Tube tube)
        {
            if (bird.passing(tube))
            {
                score++;
                lbScore.Text = score.ToString();
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
