using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
    class FindPiThread
    {
        private int dNeeded;
        public int DNeeded
        {
            get
            {
                return dNeeded;

            }
        }

        private int dThrownIn;
        public int DThrown
        {
            get
            {
                return dThrownIn;

            }
        }
        

        Random g;

        public FindPiThread(int dToThrow)
        {
            dThrownIn = 0;
            g = new Random();
            dNeeded = dToThrow;

        }

        public void throwDarts()
        {
            for(int i = 0; i < dNeeded; i++)
            {
                double choice1 = g.NextDouble();
                double choice2 = g.NextDouble();

                if (Math.Sqrt((Math.Pow(choice1, 2) + Math.Pow(choice2, 2))) <= 1)
                {
                    dThrownIn++;
                }
                
            }


        }
    }
}

