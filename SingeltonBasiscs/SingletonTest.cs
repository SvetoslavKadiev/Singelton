using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NUnit.Framework;

namespace SingeltonBasics
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            //Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        //[Test]
        public void SingletonTotalPopulationTest()
        {
            // testing on a live database
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.TotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 17400000));
        }

        [Test]
        public void DependantTotalPopulationTest()
        {
            var db = new DummyDatabase();
            var rf = new ConfigurableRecordFinder(db);
            Assert.That(
                rf.GetTotalPopulation(new[] { "alpha", "gamma" }),
                Is.EqualTo(4));
        }

        //[Test]
        public void DIPopulationTest()
        {
            var container = new ContainerBuilder();
            container.RegisterType<OrdinaryDatabase>()
                .As<IDatabase>()
                .SingleInstance();
            container.RegisterType<ConfigurableRecordFinder>();

            using (var cb = container.Build())
            {
                var rf = cb.Resolve<ConfigurableRecordFinder>();
            }
        }
    }
}
