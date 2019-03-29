using System;
namespace ParallelProgramming
{
    public class CriticalSection : AbsProblem, IProblem
    {
        public CriticalSection() : base("Critial Section")
        {
        }

        public override void Begin()
        {

        }
    }

    public class BankAccount
    {
        public int Balance
        {
            get;
            private set;
        }


    }
}
