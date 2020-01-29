﻿using System;
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
                    using (var reader = new StreamReader(openFileDialog1.FileName))
                    {
                        _questions = new List<string>();
                        _answers = new List<string>();

                        var textInBetween = new List<string>();

                        bool startTagFound = false;

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if (String.IsNullOrEmpty(line))
                                continue;

                            if (!startTagFound)
                            {
                                startTagFound = line.StartsWith("@QUESTIONS");
                                continue;
                            }

                            bool endTagFound = line.StartsWith("@END");
                            if (endTagFound)
                            {
                                // Do stuff with the text you've read in between here
                                // ...
                                _questions.Add(line);
                                textInBetween.Clear();
                                continue;
                            }

                            textInBetween.Add(line);
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
