using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static  System.Console;

namespace SingeltonBasics
{
    class Program
    {
        static void Main(string[] args)
        {
                     
            var db = SingletonDatabase.Instance;

            // works just fine while you're working with a real database.
            var city = "Tokyo";
            WriteLine($"{city} has population {db.GetPopulation(city)}");
            ReadLine();

            // now some tests
        }
    }
}
