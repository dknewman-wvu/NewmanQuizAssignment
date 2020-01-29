using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewmanAssignment1
{
    public partial class Form1 : Form
    {

        private OpenFileDialog openFileDialog1;
        private static List<string>  _questions;
        private static List<string> _answers;

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


        private void button3_Click(object sender, EventArgs e)
        {
            var res = string.Empty;
            

            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /*         var sr = new StreamReader(openFileDialog1.FileName);
                             SetText(sr.ReadToEnd());*/

                    using (var sr = new StreamReader(openFileDialog1.FileName, true))
                    {
                        _questions = new List<string>();
                        _answers = new List<string>();

                        var s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.StartsWith("@QUESTIONS"))
                            {
                                while (!s.StartsWith("@END"))
                                {
                                    while (!s.StartsWith("@ANSWERS"))
                                    {
                                        if (!s.StartsWith("@QUESTIONS") &&
                                         !s.StartsWith("@ANSWERS") &&
                                         !s.StartsWith("@END"))
                                        {
                                            res += s + System.Environment.NewLine;
                                        }
                                        if (!s.StartsWith("@QUESTIONS"))

                                            _questions.Add(s);
                                        s = sr.ReadLine();

                                    }
                                    res += s;
                                } 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

    }
}
