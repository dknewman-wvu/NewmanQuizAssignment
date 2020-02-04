using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static List<string> answerBank;
        public static List<string> answerBlock;
        public static List<string> answerKey;




        public static void ReadFile()
        {
            try
            {
                using (var reader = new StreamReader(Form1.openFileDialog1.FileName))
                {
                    Form1._quiz = new List<string>();
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
                            Form1._quiz.Add(line);

                            continue;

                        }


                        bool endTagFound = line.StartsWith("@END");
                        if (endTagFound)
                        {
                            textInBetween.Clear();
                            Form1._quiz.Add(line);
                            continue;
                        }

                        textInBetween.Add(line);
                        Form1._quiz.Add(line);

                    }


                    PopulateQuestions();
                    PopulateAnswers();



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
            string result = string.Join(" ", Form1._quiz.ToArray());

            MatchCollection questionMatchIndex = Regex.Matches(result, "@QUESTIONS");

            foreach (Match m in questionMatchIndex)
            {
                questionIndex.Add(m.Index.ToString());
                Debug.WriteLine(m.Index);


            }

            MatchCollection answerMatchIndex = Regex.Matches(result, "@ANSWERS");

            foreach (Match m in answerMatchIndex)
            {
                Console.WriteLine(m.Index);
                answerIndex.Add(m.Index.ToString());

            }

            for (var i = 0; i < questionIndex.Count; i++)
            {
                var start = questionIndex[i];
                int iStart = Int32.Parse(start.ToString());
                Debug.WriteLine("iStart = " + iStart);

                var end = answerIndex[i];
                int iEnd = Int32.Parse(end.ToString());

                //Combined the string to get the answer
                int pFrom = result.IndexOf("@QUESTIONS", iStart) + "@QUESTIONS".Length;
                int pTo = result.IndexOf("@ANSWERS", iEnd);
                string pResult = result.Substring(pFrom, pTo - pFrom);
                questionBank.Add(result.Substring(pFrom, pTo - pFrom));
                Debug.WriteLine("");

            }
            Debug.WriteLine("");
        }

        public static void PopulateAnswers()
        {
            // Populate the Answer Bank
            // var endIndex = new List<string>();
            //var answerIndex = new List<string>();
            answerKey = new List<string>();

            answerBank = Form1._quiz;
            // string result = string.Join(" ", Form1._quiz.ToArray());

            var answerIndex = Enumerable.Range(0, answerBank.Count)
             .Where(i => answerBank[i] == "@ANSWERS")
             .ToList();

            var endIndex = Enumerable.Range(0, answerBank.Count)
            .Where(i => answerBank[i] == "@END")
            .ToList();


            for (var i = 0; i < answerIndex.Count; i++)

            {
                var addAnswer = answerBank.Skip(answerIndex[i] + 1).Take(endIndex[i] - (answerIndex[i] + 1));
                answerBlock = new List<string>();

                //answerBlock.Add("@ANSWERSTART" + i);




                foreach (string item in addAnswer)
                {

                    answerBlock.Add(item);


                }
                // answerBlock.Add("@ANSWEREND" + i);
                answerKey.Add(answerBlock[0]);

                Debug.WriteLine("");

            }


        /*    var firstIndex = answerBank.FindIndex(r => r.Contains("@ANSWERS"));
            var secondIndex = answerBank.FindIndex(r => r.Contains("@END"));
            var result = answerBank.Skip(firstIndex + 1).Take(secondIndex - (firstIndex + 1));
            Debug.WriteLine("");
*/
        }




    }

}
