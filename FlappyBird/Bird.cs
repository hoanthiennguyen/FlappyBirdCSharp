using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird
{
    class Bird :  Button
    {
        public bool pressing { get; set; }
        float V = 100;
        const int g = 120;
        const int Vo = 80;
        const float timeInterval = 0.03f;
        
        public Bird()
        {
            
            this.BackColor = Color.Orange;
            this.Left = 50;
            this.Top = 100;
            this.Width = 20;
            this.Height = 20;
            this.pressing = false;
            this.KeyPress += new KeyPressEventHandler(evt);
            this.V = 0;
        }
        public  void update()
        {
              if(pressing == true)
              {
                V = Vo;
                pressing = false;
              }
              else
              {
                V = V - g * timeInterval;
                this.Top = (int)(this.Top - V * timeInterval);
              }
              
            
        }
        public bool colliding(Control another)
        {
            int totalWidth = this.Width + another.Width;
            int totalHeight = this.Height + another.Height;
            int containerWidth = Math.Max(Math.Abs(this.Left - another.Right), Math.Abs(this.Right - another.Left));
            int containerHeight = Math.Max(Math.Abs(this.Top - another.Bottom), Math.Abs(this.Bottom - another.Top));
            return totalWidth > containerWidth && totalHeight > containerHeight;
        }
        public bool passing(Control another)
        {
            bool result =  this.Left == another.Right  || this.Left == another.Right+1;
            if(result)
            {
                
            }
            return result;
        }
        public void evt(Object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
                this.pressing = true;
            
        }
    }
}
