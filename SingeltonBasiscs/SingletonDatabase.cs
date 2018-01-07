using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MoreLinq;
using NUnit.Framework;
using static  System.Console;

namespace SingeltonBasics
{
    public class SingletonDatabase: IDatabase
    {
        private Dictionary<string, int> capitals;

        private SingletonDatabase()
        {
            WriteLine("Initializing database");

            capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );

        }

        private static Lazy<SingletonDatabase> lasyInstance => new Lazy<SingletonDatabase>(()=>
            new SingletonDatabase()
        );

        public static SingletonDatabase Instance => lasyInstance.Value;

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
