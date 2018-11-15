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
        
        GameBoard gameBoard;
        TimerCallback cb;
        System.Threading.Timer timer;
        public Form1()
        {
            InitializeComponent();
            Start();
            this.ActiveControl = gameBoard.bird;
        }
        private void Start()
        {
            this.Controls.Remove(gameBoard);
            gameBoard = new GameBoard();
            this.Controls.Add(gameBoard);
            gameBoard.bird.Focus();

            CreateThread();
        }
        private void CreateThread()
        {
            cb = new TimerCallback(Update);
            timer = new System.Threading.Timer(cb, "nothing", 0, 30);
        }
        private void Update(object state)
        {
            if (!gameBoard.update())
            {
                timer.Dispose();
            }
            
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
