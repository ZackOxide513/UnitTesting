using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _customerController;

        [SetUp]
        public void SetUp()
        {
            _customerController = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnsNotFound()
        {
            var result = _customerController.GetCustomer(0);

            // For verifying NotFound Object specifically
            Assert.That(result, Is.TypeOf<NotFound>());

            // For verifying NotFound or its derivatives (more general)
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnsOK()
        {
            var result = _customerController.GetCustomer(2);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
