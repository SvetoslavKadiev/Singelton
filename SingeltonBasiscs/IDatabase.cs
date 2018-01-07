using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeltonBasics
{
    interface IDatabase
    {
        int GetPopulation(string name);
    }
}
