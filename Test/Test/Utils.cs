using System;
using Xunit;
using Core;
using Moq;

namespace Test
{
    public class Utils
    {
        static Random rng = new Random();

        public static decimal GetRandom(decimal lower, decimal upper)
        {
            var normalRandom = GetNormalRandom();
            var scaledRandom = normalRandom * (upper - lower);
            return lower + scaledRandom;
        }

        public static decimal GetNormalRandom() => rng.Next() / (decimal)int.MaxValue;
    }
}
