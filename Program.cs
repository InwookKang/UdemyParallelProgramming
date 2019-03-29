using System;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using System.Collections.Generic;

namespace ParallelProgramming
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SectionManager sectionManager = new SectionManager();

            Console.WriteLine("Choose Section to Run:");
            sectionManager.DisplaySectionNames();

            UserInput userInput = new UserInput();

            IProblem problem = sectionManager.GetProblem(userInput.intUserInput());

            if (problem != null)
            {
                problem.Begin();
            }

            Console.WriteLine("Main Program Done.");
        }
    }
}
