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
        public static void SetQuizQuestions()
        {
            using (StreamReader r = new StreamReader(@"c:\quiz.json"))
            {
                string json = r.ReadToEnd();
                List<QuizData.DataQuiz> items = JsonConvert.DeserializeObject<List<QuizData.DataQuiz>>(json);

                Debug.WriteLine(items[0].Question);
            }


        }



    }



}
