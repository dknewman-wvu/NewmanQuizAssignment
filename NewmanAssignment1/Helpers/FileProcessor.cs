using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewmanAssignment1.Helpers
{
   public partial class FileProcessor
    {
    
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
                   
                    //Get Index of @Question
                    var questionIndex = Enumerable.Range(0, Form1._questions.Count)
                                 .Where(i => Form1._questions[i] == "@QUESTIONS")
                                 .ToList();
                    Console.WriteLine("questionIndex");

                    //Combined the string to get the answer
                    string result = string.Join(" ", Form1._questions.ToArray());
                    int pFrom = result.IndexOf("@QUESTIONS") + "@QUESTIONS".Length;
                    int pTo = result.IndexOf("@ANSWERS");

                    string pResult = result.Substring(pFrom, pTo - pFrom);

                    Console.WriteLine("");
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
