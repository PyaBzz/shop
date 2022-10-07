using System;

namespace Test
{
    public abstract class Product_Test
    {
        protected const string empty = "";
        protected const string space = " ";
        protected const string dummyName = "dummyTitle";
        protected const string dummyAuthor = "dummyAuthor";

        protected readonly DateTime yesterday = DateTime.UtcNow.AddDays(-1);
        protected readonly DateTime tomorrow = DateTime.UtcNow.AddDays(+1);

        protected static class Message
        {
            public const string required_title = "The Title field is required.";
            public const string invalid_release_date = "ReleaseDate for Product needs to be a valid date in the past.";
        };
    }
}
