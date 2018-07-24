using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
	class Exponential
	{
		private double Theta { get; set; }
		public double MinValue { get; set; }
		Random random;

        /// <summary>
        /// basic no arg constructor
        /// </summary>
        public Exponential()
        {
            random = new Random();
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Exponential"/> class.
        /// </summary>
        /// <param name="theta">The theta.</param>
        public Exponential (double theta)
		{
			MinValue = 1.5;
			random = new Random ( );
			Theta = theta;
		}//End Exponential (double)

		/// <summary>
		/// Nexts this instance.
		/// </summary>
		/// <returns></returns>
		public double Next ( )
		{
			double next = random.NextDouble ( );
			while (Math.Log (1 - next) * (-Theta) < MinValue)
			{
				next = random.NextDouble ( );
			}//End while loop
			return Math.Log (1 - next) * (-Theta);
		}

        /// <summary>
        /// method to get a negative exponential value based on the input passed
        /// </summary>
        /// <param name="value">value that is expected</param>
        /// <returns>the value obtained from the distribution</returns>
        public double NegExp(double value)
        {
            return -value * Math.Log(random.NextDouble(), Math.E);
        }

        public int Next(double distribution)
        {
            double dLimit = -distribution;
            double dSum = Math.Log(random.NextDouble());

            int Count;
            for(Count = 0; dSum > dLimit; Count++)
            {
                dSum += Math.Log(random.NextDouble());
               
            }
            return Count;
        }
    }
}