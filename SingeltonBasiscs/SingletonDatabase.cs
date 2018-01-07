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

        private static int instanceCount;
        public static int Count => instanceCount;

        private SingletonDatabase()
        {

            WriteLine("Initializing database");

            capitals = File.ReadAllLines(Path.Combine(
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
                )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );

        }

        // laziness + thread safety
        private static Lazy<SingletonDatabase> lasyInstance = new Lazy<SingletonDatabase>(() =>
        {
            instanceCount++;
            return new SingletonDatabase();
        });

        //public static IDatabase Instance => instance.Value;


        //private static Lazy<SingletonDatabase> lasyInstance = new Lazy<SingletonDatabase>(()=>
        //    {
                
        //        return new SingletonDatabase();
        //    }
        //);

        public static SingletonDatabase Instance => lasyInstance.Value;

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
