using System;

namespace Test
{
    public abstract class Product_
    {
        protected const string empty = "";
        protected const string space = " ";
        protected const string dummyName = "dummyTitle";

        protected readonly DateTime yesterday = DateTime.UtcNow.AddDays(-1);
        protected readonly DateTime tomorrow = DateTime.UtcNow.AddDays(+1);

        protected static class Message
        {
            public const string required_title = "The Name field is required.";
            public const string invalid_release_date = "ReleaseDate for Product needs to be a valid date in the past.";
        };
    }
}
