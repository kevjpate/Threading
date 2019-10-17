using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many throws should be used?");

            string throws = Console.ReadLine();
            int decision = Convert.ToInt32(throws);

            Console.WriteLine("How many threads should be run on?");

            string number = Console.ReadLine();
            int threads = Convert.ToInt32(number);

            List<Thread> threading = new List<Thread>();
            List<FindPiThread> FPT = new List<FindPiThread>();

            for(int i = 0; i < threads; i++)
            {
                FindPiThread PiT = new FindPiThread(decision);

                FPT.Add(PiT);

                Thread myThread = new Thread(new ThreadStart(PiT.throwDarts));

                threading.Add(myThread);

                myThread.Start();

                Thread.Sleep(16);
            }

            int totalIn = 0;

            for(int k = 0; k < threads; k++)
            {
                threading[k].Join();
            }

            Console.WriteLine("Darts thrown Inside for each thread:");
            for(int j = 0; j < threads; j++)
            {
                Console.WriteLine("Thread Number " + (j+1) + " " + FPT[j].DThrown);
                totalIn += FPT[j].DThrown;
            }


            Console.WriteLine((4 * ((double)totalIn / ((double)decision * (double)threads))));

            Console.ReadKey();
        }
    }
}
