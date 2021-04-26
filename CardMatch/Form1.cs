using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardMatch
{
    public partial class CardGame : Form
    {

        Label first, second;
        int score = 0;
        Random random = new Random();
        public CardGame()
        {
            InitializeComponent();
            RandomFilling();
        }

        private void CardGame_Load(object sender, EventArgs e)
        {

        }
        private void RandomFilling()
        {
            first = null;
            second=null;
            score = 0;
            int randomIndex = 0;
            List<char> assets = new List<char> { '☀', '☀', '☁', '☁', '☂', '☂', '☃', '☃', '❤', '❤', '✿', '✿', '☽', '☽', '☾', '☾' };
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                randomIndex = random.Next(0, assets.Count);
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    tableLayoutPanel1.Controls[i].Text = assets[randomIndex].ToString();
                    assets.RemoveAt(randomIndex);
                    //tableLayoutPanel1.Controls[i].Visible = false;
                    tableLayoutPanel1.Controls[i].ForeColor = tableLayoutPanel1.BackColor;
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            timer1.Stop();

            first.ForeColor = tableLayoutPanel1.BackColor;
            second.ForeColor = tableLayoutPanel1.BackColor;

           
            first = null;
            second = null;

        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                
                if (clickedLabel.ForeColor == Color.White)
                    return;

                
                if (first == null)
                {
                    first = clickedLabel;
                    first.ForeColor = Color.White;
                    return;
                }


                second = clickedLabel;
                second.ForeColor = Color.White;

                if (first.Text == second.Text)
                {
                    first = null;
                    second = null;
                    score++;
                    if (score == 8)
                    {
                        System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer(@"C:\Users\Ranee\source\repos\CardMatch\CardMatch\win.wav");
                        simpleSound.Play();
                        if (MessageBox.Show("Continue?", "You Won !!\nContinue?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            RandomFilling();
                        }
                    }
                }
                else 
                timer1.Start();
            }

        }
    }
}
