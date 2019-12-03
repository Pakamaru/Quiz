using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    class MultipleChoiceQuestion : IQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public int Difficulty { get; set; }

        public bool CheckAnswer(string givenAnswer)
        {
            if (givenAnswer == Answer) return true;
            else return false;
        }

        private static Random rng = new Random();
        private List<string> Answers;

        public MultipleChoiceQuestion(string question, string answer, string fAnswer1, string fAnswer2, string fAnswer3, string category, int difficulty)
        {
            Question = question;
            Answer = answer;
            Category = category;
            Difficulty = difficulty;
            Answers = new List<string>()
            {
                fAnswer1, fAnswer2, fAnswer3, Answer
            };
        }

        private string RandomizeAnswers()
        {
            string answers = "";
            int n = Answers.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = Answers[k];
                Answers[k] = Answers[n];
                Answers[n] = value;
            }
            foreach(string s in Answers) { answers+="\n"+s; }
            return answers;
        }
        
        public override string ToString()
        {
            return $"{Question}{RandomizeAnswers()}";
        }
    }
}
