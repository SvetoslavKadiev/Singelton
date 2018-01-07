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
using static System.Console;

namespace SingeltonBasics
{
    class OrdinaryDatabase
    {

        private Dictionary<string, int> capitals;

        public OrdinaryDatabase()
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


        public int GetPopulation(string name)
        {
            return capitals[name];
        }

    }
}
