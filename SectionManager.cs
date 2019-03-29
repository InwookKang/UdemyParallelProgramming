using System.Collections.Generic;
using System;

namespace ParallelProgramming
{
    public class SectionManager
    {
        private Dictionary<int, AbsSection> _sections = new Dictionary<int, AbsSection>();

        public SectionManager()
        {
            InitializeSections();
        }

        private void InitializeSections()
        {
            _sections.Add(1, new TaskProgramming());
            _sections.Add(2, new DataSharingAndSynchronization());
            _sections.Add(3, new ConcurrentCollections());
            _sections.Add(4, new CancellingTaskMethod());
            _sections.Add(5, new TaskCoordinatiion());
            _sections.Add(6, new ParallelLoops());
            _sections.Add(7, new ParallelLINQ());
            _sections.Add(8, new AsynchronousProgramming());
        }

        public void DisplaySectionNames()
        {
            for (int i = 0; i < _sections.Count; i++)
            {
                Console.WriteLine($"{i}. {_sections[i].GetSectionName()}");
            }
        }

        public IProblem GetProblem(int choice)
        {
            IProblem problem;

            if (_sections.TryGetValue(choice, out problem))
            {
                return problem;
            }

            return null;
        }
    }
}
