using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    class OpenQuestion : IQuestion
    {
        public string Question { get; set;}
        public string Answer { get; set; }
        public int Difficulty { get; set; }
        public string Category { get; set; }
        public OpenQuestion(string question, string answer, string category, int difficulty)
        {
            Question = question;
            Answer = answer;
            Category = category;
            Difficulty = difficulty;
        }

        public bool CheckAnswer(string givenAnswer)
        {
            if (givenAnswer == Answer) return true;
            else return false;
        }

        public override string ToString()
        {
            return Question;
        }
    }
}
