using System;
using System.Collections.Generic;

namespace ParallelProgramming
{
    public abstract class AbsSection
    {
        private string sectionName;
        private Dictionary<int, AbsProblem> _lessons = new Dictionary<int, AbsProblem>();

        public AbsSection(string name)
        {
            sectionName = name;
        }

        protected void DisplayLessons()
        {
            for (int i = 1; i < _lessons.Count; i++)
            {
                Console.WriteLine($"{i}. {_lessons[i].GetDescription()}");
            }
        }

        protected AbsProblem GetLesson(int choice)
        {
            _lessons.TryGetValue(choice, out AbsProblem problem);

            return problem;
        }

        protected void AddLessons(int key, AbsProblem value)
        {
            _lessons.Add(key, value);
        }

        public string GetSectionName()
        {
            return sectionName;
        }

        public void Begin()
        {
            UserInput userInput = new UserInput();
            AbsProblem problem = null;

            Console.WriteLine("Which Lesson?: ");
            DisplayLessons();

            int choice = userInput.intUserInput();
            problem = GetLesson(choice);

            if (problem != null)
            {
                problem.Begin();
            }
        }

        //Abstract Methods
        public abstract void InitializeLessons();
    }
}
