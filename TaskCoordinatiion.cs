using System;
namespace ParallelProgramming
{
    public class TaskCoordinatiion : AbsSection, IProblem
    {
        public TaskCoordinatiion() : base("Task Coordination") => InitializeLessons();

        public override void InitializeLessons()
        {
            throw new NotImplementedException();
        }
    }
}
