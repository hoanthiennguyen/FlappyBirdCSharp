using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        
        GameBoard gameBoard = new GameBoard();
        TimerCallback cb;
        System.Threading.Timer timer;
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(gameBoard);

            
            cb = new TimerCallback(update);
            timer = new System.Threading.Timer(cb, "nothing", 0, 30);
        }
        public void update(object state)
        {
            if (!gameBoard.update())
            {
                timer.Dispose();
            }
            
        }

    }
}
