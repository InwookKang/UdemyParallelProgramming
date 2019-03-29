using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class WaitForTaskToFinish : AbsProblem, IProblem
    {
        public WaitForTaskToFinish() : base("Waiting for Task to Finish Method")
        {
        }

        public override void Begin()
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();

            Task t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task That Takes long to complete");

                //5 Seconds
                for (int i = 0; i < 5; i++)
                {
                    cancellationToken.Token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Task Done.");
            }, cancellationToken.Token);

            //Wait for Task to finish or cancellation event to be raised
            //t1.Wait(cancellationToken.Token);

            //Task that will take 3 seconds to complete
            Task t2 = new Task(() =>
            {
                Thread.Sleep(3000);
            }, cancellationToken.Token);
            t2.Start();

            //Wait for all Task to complete
            Task.WaitAll(t1, t2);

            //Wait for ANY Task to complete
            //Task.WaitAny(t1, t2);

            //Providing Cancellation Token Will result in Task.WaitAll method
            //to throw the exception. This will be bad
            //This method will timeout in 4 seconds
            //Task.WaitAll(new[] { t1, t2 }, 4000, cancellationToken.Token);

            Console.ReadKey();
        }
    }
}
