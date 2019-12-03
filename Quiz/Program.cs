using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz
{
    class Program
    {
        static List<IQuestion> questions = new List<IQuestion>();
        static void Main(string[] args)
        {
            int dif = 0;
            string cat = "";
            InitQuiz();
            var OrderedQuestions = questions.OrderBy(x => x.Category).ThenBy(x => x.Difficulty);
            while (OrderedQuestions.Where(x => x.Category == cat).Count() == 0) {
                while (dif != 1 && dif != 2 && dif != 3)
                {
                    Console.WriteLine("Give a difficulty: (1, 2, 3)");
                    int.TryParse(Console.ReadLine(), out dif);
                }
                Console.WriteLine($"Give a category:");
                OrderedQuestions.Where(x => x.Difficulty == dif).GroupBy(x => x.Category).ToList().ForEach(x =>
                    Console.WriteLine(x.Key)
                );
                cat = Console.ReadLine().ToLower();
            }
            List<IQuestion> ActualQuestions = OrderedQuestions.Where(x => x.Difficulty == dif && x.Category == cat).ToList();

            foreach(IQuestion q in ActualQuestions)
            {
                Console.WriteLine(q.Question);
                if (q.CheckAnswer(Console.ReadLine()))
                    Console.WriteLine("This is the right answer!");
                else
                    Console.WriteLine($"This is a wrong answer, the right answer is: {q.Answer}");
            }
        }

        static void InitQuiz()
        {
            questions.Add(new OpenQuestion("Wat is de hoofdstad van Nederland", "amsterdam", "geografie", 3));
            questions.Add(new OpenQuestion("Wat is de hoofdstad van België", "brussel", "geografie", 1));
            questions.Add(new OpenQuestion("Uit hoeveel delen bestaat Lord of the Rings", "3", "films", 2));
            questions.Add(new OpenQuestion("Wat is de hoofdstad van Oostenrijk", "wenen", "geografie", 2));
            questions.Add(new OpenQuestion("Wat is de hoofdstad van Guyana", "georgetown", "geografie", 3));
        }
    }
}
