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
    public partial class Form2 : Form
    {
        public static int playernmber;
        public static int FirstTrun;
        public static int Goal;
        public Form2()
        {
            InitializeComponent();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Getting Required Data Form Making Public Varibles 
            foreach (object item in checkedListBox1.CheckedItems)
            {
                if (item.ToString() == "Player 2")
                {
                    FirstTrun = 1;
                }
                else
                {
                    FirstTrun = 0;
                }
            }
            foreach (object item in checkedListBox2.CheckedItems)
            {
                    if (item.ToString() == "75")
                    {
                        Goal = 75;

                    }
                    if (item.ToString() == "100")
                    {
                        Goal = 100;

                    }
                    else Goal = 50;
            }
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Getting Required Data Form Making Public Varibles 
            foreach (object item in checkedListBox1.CheckedItems)
            {
                if (item.ToString() == "Player 2")
                {
                    FirstTrun = 1;
                }
                else
                {
                    FirstTrun = 0;
                }
            }
            foreach (object item in checkedListBox2.CheckedItems)
            {
                if (item.ToString() == "75")
                {
                    Goal = 75;

                }
                if (item.ToString() == "100")
                {
                    Goal = 100;

                }
                else Goal = 50;
            }
            playernmber = 1;
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Getting Required Data Form Making Public Varibles 
            foreach (object item in checkedListBox1.CheckedItems)
            {
                if (item.ToString() == "Player 2")
                {
                    FirstTrun = 1;
                }
                else
                {
                    FirstTrun = 0;
                }
            }
            foreach (object item in checkedListBox2.CheckedItems)
            {
                if (item.ToString() == "75")
                {
                    Goal = 75;

                }
                if (item.ToString() == "100")
                {
                    Goal = 100;

                }
                else Goal = 50;
            }
            playernmber = 2;
            Form1 f2 = new Form1();
            f2.ShowDialog();
        }
    }
}
