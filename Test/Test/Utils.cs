using System;
using Core;
using Moq;
using Xunit;

namespace Test
{
    public static class Rand
    {
        public static int AnId => Int.Get();

        public static int AQuantity => Int.Get();

        public static decimal APrice => Decimal.Get(10, 20);

        // ==============================  Internal Logic  ==============================
        private static Random rng = new Random();

        private static class Int
        {
            public static int Get() => rng.Next(1000);
        }

        private static class Decimal
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
