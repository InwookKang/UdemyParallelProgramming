using System;
namespace ParallelProgramming
{
    public class AsynchronousProgramming : AbsSection, IProblem
    {
        public AsynchronousProgramming() : base("Asynchronous Programming") => InitializeLessons();

        public override void InitializeLessons()
        {
            throw new NotImplementedException();
        }
    }
}
