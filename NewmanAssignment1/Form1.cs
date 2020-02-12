using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewmanAssignment1.Helpers;
using NewmanAssignment1.Services;

namespace NewmanAssignment1
{
    public partial class Form1 : Form
    {

        public static OpenFileDialog openFileDialog1;
        public static List<string> _quiz;
        public static RadioButton answerButton;
        public static List<RadioButton> answerButtonList;
        public static string getAnswerKey;
        public static string answserChosen;
        public static bool isQuizStarted;


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


        private void SetText(string text)
        {
            questionBox.Text = text;
        }


        public void button3_Click(object sender, EventArgs e)
        {
            var res = string.Empty;
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileProcessor.ReadFile();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuizService.SetQuizQuestions();
            GenerateAnswers();
            string newQuestion = QuizService.question.Trim();
            questionBox.Text = Regex.Replace(newQuestion, "^[0-9]+", string.Empty);

            answerButton.Visible = true;
            isQuizStarted = true;
            button1.Text = "Next Question";
            SubmitButton.Visible = true;
        }

        public void questionBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void GenerateAnswers()
        {

            if (answerButton != null)
            {
                List<RadioButton> buttons = this.Controls.OfType<RadioButton>().ToList();
                foreach (RadioButton btn in buttons)
                {
                    btn.Dispose();
                }
            }
            else
            {
                Console.WriteLine("");
            }

            var location = new Point(225, 185);
            answerButtonList = new List<RadioButton>();
            int num = 1;

            foreach (string answer in QuizService.answer.Skip(1))
            {


                answerButton = new RadioButton();
                answerButton.Name = "answerButton";
                answerButton.Enabled = true;
                answerButton.AutoSize = true;
                answerButton.Text = answer;
                answerButton.Location = location;
                answerButton.Font = new Font("Berlin Sans FB", 12);
                answerButton.Visible = true;
                location.Y = location.Y + answerButton.Height;

                this.Controls.Add(answerButton);
                answerButtonList.Add(answerButton);
                num = num + 1;
                answerButton.CheckedChanged += new EventHandler(answerButton_CheckedChanged);
                Debug.WriteLine("ANSWER CHOSEN: " + answserChosen);

            }

            getAnswerKey = QuizService.answerKey.ToString();
            Debug.WriteLine("ANSWER KEY: " + getAnswerKey);
            var answerPick = new object();

        }

        public void answerButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked!");

        }

        public static void answerButton_CheckedChanged(object sender, EventArgs e)
        {
            //Handles Chosen Answer and passes data for compare
            answserChosen = (sender as RadioButton).Text;

            Console.WriteLine(answserChosen);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (QuizService.correctAnswer == answserChosen)
            {
                MessageBox.Show("CORRECT!");

            }
            else
            {
                MessageBox.Show("SORRY TRY AGAIN!");

            }

        }
    }
}
