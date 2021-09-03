using System;
using Newtonsoft.Json;

namespace Debug
{
    public static class Utils
    {
        private static string ToPrettyString(this object value) =>
            JsonConvert.SerializeObject(value, Formatting.Indented);

        public static T Dump<T>(this T value, string titre = "")
        {
            Console.WriteLine(titre);
            Console.WriteLine(value.ToPrettyString());
            return value;
        }
    }
}