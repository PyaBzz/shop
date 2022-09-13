using System;
using Core;
using Moq;
using Xunit;

namespace Test
{
    public static class Rand
    {
        public static Random rng = new Random();

        public static class Int
        {
            public static int Get() => rng.Next(1000);
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

            private static decimal GetNormal() =>
                rng.Next() / (decimal) int.MaxValue;
        }
    }
}
