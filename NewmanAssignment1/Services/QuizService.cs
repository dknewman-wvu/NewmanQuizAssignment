using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"c:\quiz.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                foreach (JProperty property in o2.Properties())
                {
                    Console.WriteLine(string.Format("Name: {0}, Value: {1}.", property.Name, property.Value));
                }
            }

           
        }



    }



}
