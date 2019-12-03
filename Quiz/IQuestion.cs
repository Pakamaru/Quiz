using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    interface IQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public int Difficulty { get; set; }

        public bool CheckAnswer(string givenAnswer);
    }
}
