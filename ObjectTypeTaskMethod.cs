using System;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ObjectTypeTaskMethod : AbsProblem, IProblem
    {
        public ObjectTypeTaskMethod() : base("Object Type Task Method")
        {
        }

        public override void Begin()
        {
            Task t = new Task(Write, "NewTask ");
            t.Start();

            Task.Factory.StartNew(Write, "FactoryTask ");
        }

        /// <summary>
        /// This Method will box the parameter and then will unpack when 
        /// Displaying the object. 
        /// </summary>
        /// <param name="obj">Object.</param>
        public static void Write(object obj)
        {
            //This is very expensive
            int i = 1000;
            while (i-- > 0)
            {
                //Unboxed
                Console.Write(obj);
            }
        }
    }
}
