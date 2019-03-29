using System;
using System.Threading.Tasks;
using System.Threading;

namespace ParallelProgramming
{
    public class CancellingTaskMethod : AbsProblem, IProblem
    {
        public CancellingTaskMethod() : base("Cancelling Task Method")
        {
        }


        /// <summary>
        /// Demonstration of Task that is to cancelled by 
        /// pressing a key
        /// </summary>
        public override void Begin()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            CancellationTokenSource ctsa = new CancellationTokenSource();
            CancellationToken tokena = ctsa.Token;

            //Method 1: Handling Cancellation of Task event
            //With Registering Cancellation Event
            token.Register(() =>
            {
                Console.WriteLine("Cancellation has been requested");
            });

            //Task the will run forever
            Task task = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    //This is the proper syntatic sugar way of 
                    //doing the same operation as below. 
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");

                    //if (token.IsCancellationRequested)
                    //{
                    //    //This is recommended method of handling a cancelled thread. 
                    //    throw new OperationCanceledException();
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"{i++}\t");
                    //}
                }
            }, token);
            task.Start();

            //Start a new Task that will get cancelled using a different token
            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    if (tokena.IsCancellationRequested)
                    {
                        break;
                    }
                    Console.WriteLine($"{(i++ / 2 == 0 ? "even" : "odd") }\t");
                }

                //Blocking call that will wait until cancellation 
                //Event has occured. Any code below WaitOne()
                // Will not get executed. 
                tokena.WaitHandle.WaitOne();
                Console.WriteLine("Wait Handled has been released.");
            });

            Console.ReadKey();
            //Cancellation is done to the task
            cts.Cancel();
            ctsa.Cancel();
        }
    }
}
