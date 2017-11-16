using System;

namespace MUnityLibrary.Math
{
    /// <summary>
    /// Box-Muller 法による乱数生成器(引用)
    /// http://truthfullscore.hatenablog.com/entry/2014/06/03/204446
    /// </summary>
    public class BoxMuller
    {
        private Random random;

        public BoxMuller()
        {
            random = new Random(Environment.TickCount);
        }

        public BoxMuller(int seed)
        {
            random = new Random(seed);
        }

        public double Next(double mu = 0.0, double sigma = 1.0, bool getCos = true)
        {
            if (getCos)
            {
                double rand = 0.0;
                while ((rand = random.NextDouble()) == 0.0) ;
                double rand2 = random.NextDouble();
                double normrand = System.Math.Sqrt(-2.0 * System.Math.Log(rand)) * System.Math.Cos(2.0 * System.Math.PI * rand2);
                normrand = normrand * sigma + mu;
                return normrand;
            }
            else
            {
                double rand;
                while ((rand = random.NextDouble()) == 0.0) ;
                double rand2 = random.NextDouble();
                double normrand = System.Math.Sqrt(-2.0 * System.Math.Log(rand)) * System.Math.Sin(2.0 * System.Math.PI * rand2);
                normrand = normrand * sigma + mu;
                return normrand;
            }
        }

        public double[] NextPair(double mu = 0.0, double sigma = 1.0)
        {
            double[] normrand = new double[2];
            double rand = 0.0;
            while ((rand = random.NextDouble()) == 0.0) ;
            double rand2 = random.NextDouble();
            normrand[0] = System.Math.Sqrt(-2.0 * System.Math.Log(rand)) * System.Math.Cos(2.0 * System.Math.PI * rand2);
            normrand[0] = normrand[0] * sigma + mu;
            normrand[1] = System.Math.Sqrt(-2.0 * System.Math.Log(rand)) * System.Math.Sin(2.0 * System.Math.PI * rand2);
            normrand[1] = normrand[1] * sigma + mu;
            return normrand;
        }
    }
}
