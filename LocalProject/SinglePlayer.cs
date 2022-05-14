using System;
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
    public partial class Form3 : Form
    {
        // Introducing the Global Varibles which are required
        public int SecondFormGoal;
        public int activeuser;
        public string activeusername;
        public int RunningScore;
        public int CumulativeScoreFirstPlayer;
        public int CumulativeScoreSecondPlayer;


        public static int DiceRolling()
        {
            Random rand = new Random();
            int Dice = rand.Next(1, 6);
            return Dice;
        }




        public Form3()
        {
            SecondFormGoal = Form2.Goal;
            activeuser = Form2.FirstTrun;
            activeusername = "Human";
            if (activeuser == 1)
            {
                activeusername = "Computer";
            }
            
            InitializeComponent();
        }


        public void PlayGameByComputer()
        {
            int desicion;
            // This FUnction is for the implementation
            Random random = new Random();
            if (random.NextDouble() < 0.9)
            {
                desicion = 1;
            }
            else desicion = random.Next(0, 1);
            // Now Working With Descion 
            if (desicion == 1)
            {
                // Play the Game by computer
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
                            activeusername = "Human";
                            activeuser = 0;
                            textBox1.ResetText();
                            textBox1.Text = activeusername;
                            RunningScore = 0;
                            textBox1.Text = "Human";

                        }
                        if (activeuser == 0)
                        {
                            textBox1.ResetText();
                            activeusername = "Computer";
                            activeuser = 1;
                            textBox1.Text = activeusername;
                            RunningScore = 0;
                            textBox1.Text = "Computer";
                            PlayGameByComputer();

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
            else
            {
                textBox2.AppendText(">>> You have Rolled the Dice");
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText(">>> User Has been Chaneged to Other");
                textBox2.AppendText(Environment.NewLine);
                string activename1 = activeusername;
                if (activeuser == 1)
                {
                    activeusername = "Human";
                    activeuser = 0;
                    textBox1.ResetText();
                    textBox1.Text = "Human";
                    CumulativeScoreSecondPlayer += RunningScore;
                    RunningScore = 0;

                }
                if (activeuser == 0)
                {
                    textBox1.ResetText();
                    activeusername = "Computer";
                    activeuser = 1;
                    CumulativeScoreFirstPlayer += RunningScore;
                    textBox1.Text = "Computer";
                    RunningScore = 0;
                    PlayGameByComputer();
                }
                string[] Data = { activename1, "---", "---", RunningScore.ToString(), CumulativeScoreFirstPlayer.ToString(), CumulativeScoreSecondPlayer.ToString() };
                dataGridView1.Rows.Add(Data);
                if (CumulativeScoreFirstPlayer > 50 || CumulativeScoreSecondPlayer > 50)
                {
                    textBox2.Text = "Game has been Ended!";
                    if (CumulativeScoreFirstPlayer > 50)
                    {
                        textBox2.AppendText(Environment.NewLine);
                        textBox2.AppendText("Human Won");
                        textBox2.AppendText(Environment.NewLine);

                    }
                    if (CumulativeScoreSecondPlayer > 50)
                    {
                        textBox2.AppendText(Environment.NewLine);
                        textBox2.AppendText("Computer Won");
                        textBox2.AppendText(Environment.NewLine);

                    }
                    System.Threading.Thread.Sleep(500);
                }
            }
        }





        private void Form3_Load(object sender, EventArgs e)
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
            dataGridView1.Columns[4].Name = "Cum. Human Player";
            dataGridView1.Columns[5].Name = "Cum. Computer Player";
            RunningScore = 0;
            CumulativeScoreFirstPlayer = 0;
            CumulativeScoreSecondPlayer = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Game has been Ended!";
            if (CumulativeScoreFirstPlayer > CumulativeScoreSecondPlayer)
            {
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText("Human Won");
                textBox2.AppendText(Environment.NewLine);

            }
            if (CumulativeScoreSecondPlayer > CumulativeScoreFirstPlayer)
            {
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText("Computer Won");
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

        private void button3_Click(object sender, EventArgs e)
        {
            // This Button is to show that the Dice is  working or Not
            int DiceRoll = DiceRolling();
            string TextBoxAdding = ">>> Tested Dice Value: " + DiceRoll.ToString();
            textBox2.Text += TextBoxAdding;
            textBox2.AppendText(Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Pass the Dice
            textBox2.AppendText(">>> You have Passed the Dice");
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText(">>> User Has been Chaneged to Other");
            textBox2.AppendText(Environment.NewLine);
            string activename1 = activeusername;
            string[] Data = { activename1, "---", "---", RunningScore.ToString(), CumulativeScoreFirstPlayer.ToString(), CumulativeScoreSecondPlayer.ToString() };
            dataGridView1.Rows.Add(Data);
            if (activeuser == 1)
            {
                activeusername = "Human";
                activeuser = 0;
                textBox1.ResetText();
                textBox1.Text = "Human";
                CumulativeScoreSecondPlayer += RunningScore;
                RunningScore = 0;

            }
            if (activeuser == 0)
            {
                activeusername = "Computer";
                activeuser = 1;
                CumulativeScoreFirstPlayer += RunningScore;
                textBox1.Text = "Computer";
                RunningScore = 0;
                textBox1.ResetText();
                textBox1.Text = "Computer";
                PlayGameByComputer();
            }
            if (CumulativeScoreFirstPlayer > 50 || CumulativeScoreSecondPlayer > 50)
            {
                textBox2.Text = "Game has been Ended!";
                if (CumulativeScoreFirstPlayer > 50)
                {
                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText("Human Won");
                    textBox2.AppendText(Environment.NewLine);

                }
                if (CumulativeScoreSecondPlayer > 50)
                {
                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText("Computer Won");
                    textBox2.AppendText(Environment.NewLine);

                }
                System.Threading.Thread.Sleep(500);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                        activeusername = "Human";
                        activeuser = 0;
                        textBox1.ResetText();
                        textBox1.Text = activeusername;
                        RunningScore = 0;
                        textBox1.Text = "Human";
                    }
                    if (activeuser == 0)
                    {
                        activeusername = "Computer";
                        activeuser = 1;
                        textBox1.ResetText();
                        textBox1.Text = activeusername;
                        RunningScore = 0;
                        textBox1.Text = "Computer";
                        PlayGameByComputer();

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
