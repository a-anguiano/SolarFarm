using NUnit.Framework;
using SolarFarm.BLL;
using System;

namespace SolarFarmTests
{
    [TestFixture]
    public class ValidationTests
    {
        ValidationID vID;

        [SetUp]
        public void SetUp()
        {
            vID = new ValidationID();

        }

        //    //existence testing here???

        [Test]
        [TestCase("", false)]
        [TestCase("Any Name", true)]
        public void SectionNameRequired(string name, bool expected)
        {
            bool result = vID.CheckSectionIsNotNull(name);
            Assert.That(result == expected);
        }

        [Test]
        [TestCase(250, true)]
        [TestCase(251, false)]
        [TestCase(1, true)]
        [TestCase(0, false)]

        public void RowMustBeLessThanEqualTo250(int row, bool expected)
        {
            bool result = vID.CheckRowOrColumn(row).Success;
            Assert.That(result == expected);
        }


        [Test]
        [TestCase("1/1/2021", true)]
        [TestCase("1/1/2023", false)]
        //could see up to the month?
        public void YearMustBeInThePast(DateTime year, bool expected)
        {
            bool result = vID.CheckYear(year).Success;
            Assert.That(result == expected);
        }

        [Test]
        [TestCase("y", true)]
        [TestCase("n", true)]
        [TestCase("Y", true)]
        [TestCase("N", true)]
        [TestCase("", false)]
        [TestCase("notYOrN", false)]
        public void UserEntersTrackingYesOrNo(string response, bool expected)
        {
            bool result = vID.CheckIsTracking(response).Success;
            Assert.That(result == expected);
        }

        [Test]
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, true)]
        [TestCase(5, false)]
        [TestCase(-1, false)]
        public void CheckForValidMaterial(int materialType, bool expected)
        {
            bool result = vID.CheckMaterial(materialType).Success;
            Assert.That(result == expected);
        }
    }
}