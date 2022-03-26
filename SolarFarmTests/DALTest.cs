using NUnit.Framework;
using SolarFarm.DAL;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.Collections.Generic;
using System;

namespace SolarFarmTests
{
    [TestFixture]
    public class Test
    {
        PanelRepository repo;
        private List<Panel> _panels;

        [SetUp]
        public void Setup()
        {
            repo = new PanelRepository();
            
            _panels = new List<Panel>();
            Panel bogus = new Panel();
            bogus.Section = "Upper Hill";
            bogus.Row = 2;
            bogus.Column = 3;
            bogus.Year = new DateTime(2020);
            bogus.IsTracking = "y";
            _panels.Add(bogus);

            Panel bogus2 = new Panel();
            bogus2.Section = "Lower Hill";
            bogus2.Row = 2;
            bogus2.Column = 3;
            bogus2.Year = new DateTime(2020);
            bogus2.IsTracking = "y";
            _panels.Add(bogus2);
        }

        [Test]
        public void Um(Result<List<Panel>> expected)
        {
            Result<List<Panel>> actual = repo.GetAll();
            //result.Data = new List<Panel>(_panels);

            Assert.AreEqual(expected, actual);
        }
    }
}
