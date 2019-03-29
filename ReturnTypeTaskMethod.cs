using System;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ReturnTypeTaskMethod : AbsProblem, IProblem
    {
        public ReturnTypeTaskMethod() : base("Return Type Task Method")
        {

        }

        public override void Begin()
        {
            string text1 = "testing", text2 = "this";

            int i = 0;
            while (i <= 100)
            {
                //Specify the Type 
                Task<int> task1 = new Task<int>(TextLength, text1);
                task1.Start();

                //Another method if starting task
                Task<int> task2 = Task.Factory.StartNew(TextLength, text2);

                //When Calling Task.Result, this will block the main thread until Task is complete. 
                Console.WriteLine($"Length of Text2 is {text1} is {task2.Result}");
                Console.WriteLine($"Length of Text1 is {text2} is {task1.Result}");

                i++;
            }
        }

        private static int TextLength(object obj)
        {
            Console.WriteLine($"\nTask with ID {Task.CurrentId} processing object {obj}...");
            return obj.ToString().Length;
        }
    }
}
