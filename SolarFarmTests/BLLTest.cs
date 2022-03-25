using NUnit.Framework;

namespace SolarFarmTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void SectionNameRequired(string name)
        {
            Assert.IsNotNull(name);
        }

        [Test]
        public void RowMustBeLessThanEqualTo250(int row)
        {
            Assert.LessOrEqual(row, 250);
        }
    }
}