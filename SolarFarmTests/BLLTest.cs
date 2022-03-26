using NUnit.Framework;
using SolarFarm.BLL;
using System;

namespace SolarFarmTests
{
    [TestFixture]
    public class ValidationTests    //renamed
    {
        ValidationID vID;
        
        [SetUp]
        public void SetUp()
        {
            vID = new ValidationID();
            
        }

        [Test]
        [TestCase ("", false)]
        [TestCase ("Any Name", true)]
        public void SectionNameRequired(string name, bool expected)
        {
            bool result = vID.CheckSectionIsNotNull(name);
            Assert.That(result == expected);
        }

        [Test]
        [TestCase (250, true)]
        [TestCase(251, false)]
        [TestCase(1, true)]
        [TestCase(0, false)]

        public void RowMustBeLessThanEqualTo250(int row, bool expected)
        {
            bool result = vID.CheckRow(row);
            Assert.That(result == expected);
        }

        //CheckColumn is the same, so either will refactor or...

        [Test]
        [TestCase ("1/1/2021", true)]               //smart enough to convert from string to DateTime
        [TestCase ("1/1/2023", false)]            
        //could see up to the month?
        public void YearMustBeInThePast(DateTime year, bool expected)
        {
            bool result = vID.CheckYear(year);
            Assert.That(result == expected);
        }

        //CheckForMaterial
    }
}