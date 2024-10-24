using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int boruHızı = 8;
        int gravity = 10;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            BoruAlt.Left -= boruHızı;
            BoruÜst.Left -= boruHızı;
            ScoreText.Text = "Score: " + score;
            if(BoruAlt.Left<-150)
            {
                BoruAlt.Left = 800;
                score++;
            }
            if(BoruÜst.Left<-180)
            {
                BoruÜst.Left = 950;
                
            }
            if(FlappyBird.Bounds.IntersectsWith(BoruAlt.Bounds)||FlappyBird.Bounds.IntersectsWith(BoruÜst.Bounds)||FlappyBird.Bounds.IntersectsWith(Zemin.Bounds))
            {
                endGame();
            }
            //score'un 5 i geçmesinden sonra oyunu hızlandırıyoruz
            if(score>5)
            {
                boruHızı = 15;
            }
            //kuşun ekranın üstünden kaybolmaması için
            if(FlappyBird.Top<-25)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            ScoreText.Text = "Game Over!";
        }
    }
}
