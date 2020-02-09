using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewmanAssignment1.Services
{
    class QuizService
    {
        public static List<QuizData.DataQuiz> quizItems;
        public static int count = 0;
        public static int randomNumber;
        public static string question { get; set; }
        public static string answerKey;
        public static List<string> answer;


        public static void SetQuizQuestions()
        {
            using (StreamReader r = new StreamReader(@"c:\quiz.json"))
            {
                string json = r.ReadToEnd();
                quizItems = JsonConvert.DeserializeObject<List<QuizData.DataQuiz>>(json);
                count = GetCount();
                Random rnd = new Random();
                randomNumber = rnd.Next(count);
                question = GetQuestion();
                Debug.WriteLine(randomNumber);



            }

        }


        public static string GetQuestion()
        {
            var pollQuestion = quizItems[randomNumber].Question;
            return pollQuestion;

        }

        public static string GetAnswer()
        {
            var pollAnswer = quizItems[randomNumber].Answers.ToString();
            return pollAnswer;

        }

        public static string GetAnswerKey()
        {
            var pollAnswerKey = quizItems[randomNumber].AnswerKey;
            return pollAnswerKey;

        }

        private static int GetCount ()
        {
            count = quizItems.Count();
            return count;
        }


    }



}
