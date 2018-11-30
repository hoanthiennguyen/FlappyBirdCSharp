using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird
{

    class GameBoard : Panel
    {
        public Bird bird;

        public const int TUBE_HEIGHT_AMPLITUDE = 30;

        const int NUMBER_OF_TUBEPARIR = 5;
        const int GAP = 100;
        public const int WIDTH = 500;
        public const int HEIGHT = 250;
        const int GAP_BETWEEN_BIRD_FIRST_TUBE = 100;
        int score = 0;
        Label lbScore;

        
        public GameBoard()
        {
            this.Top = 50;
            this.Width = WIDTH;
            this.Height = HEIGHT;
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
            const int LEFT_MOST = WIDTH + GAP_BETWEEN_BIRD_FIRST_TUBE;
            for (int i = 0; i < NUMBER_OF_TUBEPARIR*2; i++)
            {
                bool isUp = i % 2 == 0;
                int delheight = (int)Math.Pow(-1, i % 2) * 10*(i%3);
                int pairNumber = i/2;
                
                Tube tube = new Tube(LEFT_MOST - pairNumber * GAP, Tube.HEIGHT + delheight, isUp);
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
                        tube.update(Tube.HEIGHT + deltaHeight);
                    }
                    //downTube
                    else
                        tube.update(Tube.HEIGHT - deltaHeight);

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
