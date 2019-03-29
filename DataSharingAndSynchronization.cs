using System;
namespace ParallelProgramming
{
    public class DataSharingAndSynchronization : AbsSection, IProblem
    {
        public DataSharingAndSynchronization() : base("Data Sharing And Synchronization") => InitializeLessons();

        public override void InitializeLessons()
        {
            AddLessons(1, new CriticalSection());
        }
    }


}
