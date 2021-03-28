using NUnit.Framework;
using TestNinja.Fundamentals;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(55,0)]
        [TestCase(65,0)]
        [TestCase(68,0)]
        [TestCase(79,2)]
        [TestCase(101,7)]
        public void CalculateDemeritPoints_WhenCalled_ReturnsDemeritPoints(int speed, int demeritPoints)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(demeritPoints));
        }

        [Test]
        [TestCase(-5)]
        [TestCase(325)]
        public void CalculateDemeritPoints_SpeedOutOfRange_ThrowsArgOutOfRangeException(int speed)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
