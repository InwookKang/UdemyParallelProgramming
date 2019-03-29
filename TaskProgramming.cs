using System;
using System.Collections.Generic;
namespace ParallelProgramming
{
    public class TaskProgramming : AbsSection, IProblem
    {
        public TaskProgramming() : base("Task Programming") => InitializeLessons();

        public override void InitializeLessons()
        {
            AddLessons(1, new SingleTypeTaskMethod());
            AddLessons(2, new ObjectTypeTaskMethod());
            AddLessons(3, new ReturnTypeTaskMethod());
            AddLessons(4, new CancellingTaskMethod());
            AddLessons(5, new CancellingTaskWithLinkedSource());
            AddLessons(6, new WaitForTaskToFinish());
            AddLessons(7, new ExceptionHandling());
        }
    }
}
