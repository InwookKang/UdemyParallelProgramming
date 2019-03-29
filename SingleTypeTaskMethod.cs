using System;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class SingleTypeTaskMethod : AbsProblem, IProblem
    {
        public SingleTypeTaskMethod() : base("Single Type Task Method")
        {
            Description = "";
        }

        public override void Begin()
        {
            //StartNew takes in a method, Anonymous function, or Lamda. 
            //Writes '.' on a new thread 
            Task.Factory.StartNew(() => Write('.'));

            //Writes '?' on new thread
            var t = new Task(() => Write('?'));
            t.Start();

            //Writes '-' on the Main thread
            Write('-');
        }

        public static void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }
    }
}
