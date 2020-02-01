using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewmanAssignment1.Helpers
{
    public partial class FileProcessor
    {
        public static List<string> questionBank;

        public static void ReadFile()
        {
            try
            {
                using (var reader = new StreamReader(Form1.openFileDialog1.FileName))
                {
                    Form1._questions = new List<string>();
                    var textInBetween = new List<string>();
                    bool startTagFound = false;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (String.IsNullOrEmpty(line))
                        {
                            continue;
                        }
                        if (!startTagFound)
                        {
                            startTagFound = line.StartsWith("@QUESTIONS");
                            Form1._questions.Add(line);

                            continue;

                        }


                        bool endTagFound = line.StartsWith("@END");
                        if (endTagFound)
                        {
                            // Do stuff with the text you've read in between here
                            // ...

                            textInBetween.Clear();
                            continue;
                        }

                        textInBetween.Add(line);
                        Form1._questions.Add(line);

                    }


                    PopulateQuestions();



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }

        public static void PopulateQuestions()
        {
            // Populate the Question Bank
            var questionIndex = new List<string>();
            var answerIndex = new List<string>();
            questionBank = new List<string>();
            int j = 0;
            string result = string.Join(" ", Form1._questions.ToArray());

            MatchCollection questionMatchIndex = Regex.Matches(result, "@QUESTIONS");

            foreach (Match m in questionMatchIndex)
            {
                Console.WriteLine(m.Index);
                questionIndex.Add(m.Index.ToString());

            }
            Console.WriteLine("");

            MatchCollection answerMatchIndex = Regex.Matches(result, "@ANSWERS");

            foreach (Match m in answerMatchIndex)
            {
                Console.WriteLine(m.Index);
                answerIndex.Add(m.Index.ToString());

            }
            Console.WriteLine("");

            // NEED TO FIX THIS LOGIC
            for (var i = 0; i < questionIndex.Count; i++)
            {
                int start = questionIndex.ToString()[i];
                int end = answerIndex.ToString()[i];
                //Combined the string to get the answer
                int pFrom = result.IndexOf("@QUESTIONS", start) + "@QUESTIONS".Length;
                int pTo = result.IndexOf("@ANSWERS", end);
                string pResult = result.Substring(pFrom, pTo - pFrom);
                questionBank.Add(result.Substring(pFrom, pTo - pFrom));
                Console.WriteLine("");
                j++;

            }
            Console.WriteLine("");
            j = 0;
        }



    }

}
