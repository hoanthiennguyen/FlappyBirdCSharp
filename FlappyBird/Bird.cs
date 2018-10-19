using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    class Bird :  Button
    {
        public bool pressing { get; set; }
        float V = 100;
        const int g = 100;
        const int Vo = 100;
        const float timeInterval = 0.03f;
        public bool restarting;
        public Bird()
        {
            
            this.BackColor = Color.Orange;
            this.Left = 50;
            this.Top = 100;
            this.Width = 20;
            this.Height = 20;
            this.pressing = false;
            this.KeyPress += new KeyPressEventHandler(evt);

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
            return this.Left == another.Right;
        }
        public void evt(Object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
                this.pressing = true;
            
        }
    }
}
