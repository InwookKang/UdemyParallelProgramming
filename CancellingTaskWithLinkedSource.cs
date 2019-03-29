using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class CancellingTaskWithLinkedSource : AbsProblem, IProblem
    {
        public CancellingTaskWithLinkedSource() : base("Multi-Cancelling Task with Token Source")
        {
        }

        /// <summary>
        /// Cancellings the task with linked source.
        /// This method will utilize Composite Cancellation Tokens
        /// Which are Multiple Cancellation Tokens that can be 
        /// used to trigger cancellation event
        /// </summary>
        public override void Begin()
        {
            CancellationTokenSource planned = new CancellationTokenSource();
            CancellationTokenSource emergency = new CancellationTokenSource();
            CancellationTokenSource preventative = new CancellationTokenSource();

            //Any Cancellation Source can be used to trigger Cancellation event
            CancellationTokenSource tokenLinks = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, emergency.Token, preventative.Token);

            //Spawn a new thread that will be running forever
            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    tokenLinks.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                    Thread.Sleep(500);
                }
            }, tokenLinks.Token);

            //Main Thread
            //After Pressing any key, Cancellation event will be raised
            Console.ReadKey();
            //Can be any CancellationTokenSource
            planned.Cancel();
        }
    }
}
