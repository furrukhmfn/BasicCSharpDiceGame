﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalProject
{
    public partial class Form1 : Form
    {
        int SecondFormGoal;
        int activeuser;
        string activeusername;
        int RunningScore;
        int CumulativeScoreFirstPlayer;
        int CumulativeScoreSecondPlayer;

        public static int DiceRolling()
        {
            Random rand = new Random();
            int Dice = rand.Next(1, 6);
            return Dice;
        }
        public static void UserTurn(int user)
        {

        }
        public Form1()
        {
            SecondFormGoal = Form2.Goal;
            activeuser = Form2.FirstTrun;
            activeusername = "Player 1";
            if (activeuser == 1)
            {
                activeusername = "Player 2";
            }
            RunningScore = 0;
            CumulativeScoreFirstPlayer = 0;
            CumulativeScoreSecondPlayer = 0;
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = activeusername;
            // Labeling Columns of Data Grid
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 125;
            dataGridView1.Columns[5].Width = 125;

            dataGridView1.Columns[0].Name = "Active Player";
            dataGridView1.Columns[1].Name = "Dice 1";
            dataGridView1.Columns[2].Name = "Dice 2";
            dataGridView1.Columns[3].Name = "Running Score";
            dataGridView1.Columns[4].Name = "Cum. Player 1";
            dataGridView1.Columns[5].Name = "Cum. Player 2";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            // This Button is to show that the Dice is  working or Not
            int DiceRoll = DiceRolling();
            string TextBoxAdding = ">>> Tested Dice Value: " + DiceRoll.ToString();
            textBox2.Text += TextBoxAdding;
            textBox2.AppendText(Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This code is for the animation of dice.
            System.Threading.Thread.Sleep(1000);
            // This Code is for the Rolling of Two Dices
            try
            {
                int ScoreofDiceFirst = DiceRolling();
                int ScoreofDiceSecond = DiceRolling();
                RunningScore += ScoreofDiceFirst;
                RunningScore += ScoreofDiceSecond;

                string[] Data = { activeusername, ScoreofDiceFirst.ToString(), ScoreofDiceSecond.ToString(), RunningScore.ToString(), CumulativeScoreFirstPlayer.ToString(), CumulativeScoreSecondPlayer.ToString() };
                dataGridView1.Rows.Add(Data);
                if ((ScoreofDiceFirst == 1) || (ScoreofDiceSecond == 1))
                {
                    textBox2.AppendText(">>> You have Lost Turn");
                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText(">>> User Has been Chaneged to Other");
                    if (activeuser == 1)
                    {
                        activeusername = "Player 1";
                        activeuser = 0;
                        textBox1.Text = activeusername;
                        RunningScore = 0;
                        textBox1.Text = "Player 1";
                    }
                    if (activeuser == 0)
                    {
                        activeusername = "Player 2";
                        activeuser = 1;
                        textBox1.Text = activeusername;
                        RunningScore = 0;
                        textBox1.Text = "Player 2";
                    }
                }
                System.Threading.Thread.Sleep(500);
                // This is For showing Data to the Data Grid
            }
            catch (Exception ex)
            {
                // This Code is For Exception;
                string SomeText = ">>> Found A Problem";
                string SomeText1 = ex.ToString();
                textBox2.AppendText(SomeText);
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText(SomeText1);
                textBox2.AppendText(Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Pass the Dice
            textBox2.AppendText(">>> You have Rolled the Dice");
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText(">>> User Has been Chaneged to Other");
            textBox2.AppendText(Environment.NewLine);
            string activename1 = activeusername;
            if (activeuser == 1)
            {
                activeusername = "Player 1";
                activeuser = 0;
                textBox1.Text = "Player 1";
                CumulativeScoreSecondPlayer += RunningScore;
                RunningScore = 0;

            }
            if (activeuser == 0)
            {
                activeusername = "Player 2";
                activeuser = 1;
                CumulativeScoreFirstPlayer += RunningScore;
                textBox1.Text = "Player 2";
                RunningScore = 0;

            }
            string[] Data = { activename1, "---", "---", RunningScore.ToString(), CumulativeScoreFirstPlayer.ToString(), CumulativeScoreSecondPlayer.ToString() };
            dataGridView1.Rows.Add(Data);
            if (CumulativeScoreFirstPlayer > 50 || CumulativeScoreSecondPlayer > 50)
            {
                textBox2.Text = "Game has been Ended!";
                if (CumulativeScoreFirstPlayer > 50)
                {
                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText("Player 1 Won");
                    textBox2.AppendText(Environment.NewLine);

                }
                if (CumulativeScoreSecondPlayer > 50)
                {
                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText("Player 2 Won");
                    textBox2.AppendText(Environment.NewLine);

                }
                System.Threading.Thread.Sleep(500);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Nothing should be written here. 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Game has been Ended!";
            if (CumulativeScoreFirstPlayer > CumulativeScoreSecondPlayer)
            {
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText("Player 1 Won");
                textBox2.AppendText(Environment.NewLine);

            }
            if (CumulativeScoreSecondPlayer > CumulativeScoreFirstPlayer)
            {
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText("Player 2 Won");
                textBox2.AppendText(Environment.NewLine);

            }
            if (CumulativeScoreFirstPlayer == CumulativeScoreSecondPlayer)
            {
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText("No One Won. Game has been Tied! ");
                textBox2.AppendText(Environment.NewLine);
            }
            System.Threading.Thread.Sleep(500);

        }
    }
}
