using System;
using Xunit;
using Core;
using Moq;

namespace Test
{
    public class Rand
    {
        public static Random rng = new Random();
        public static class Int
        {
            public static int Get() => rng.Next();
        }

        public static class Decimal
        {
            public static decimal Get(decimal upper) => Get(0, upper);

            public static decimal Get(decimal lower, decimal upper)
            {
                var normalRandom = GetNormal();
                var scaledRandom = normalRandom * (upper - lower);
                return lower + scaledRandom;
            }

            private static decimal GetNormal() => rng.Next() / (decimal)int.MaxValue;
        }
    }
}
