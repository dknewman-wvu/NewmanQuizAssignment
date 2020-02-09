using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewmanAssignment1.Helpers;
using NewmanAssignment1.Services;

namespace NewmanAssignment1
{
    public partial class Form1 : Form
    {

        public static OpenFileDialog openFileDialog1;
        public static List<string>  _quiz;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void SetText(string text)
        {
            textBox2.Text = text;
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
            questionBox.Text = QuizService.question;
        }

        public void questionBox_TextChanged(object sender, EventArgs e)
        {
            
        }

       
    }
}
