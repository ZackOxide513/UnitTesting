using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.TestEmployeeController
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            var storage = new Mock<IEmployeeStorage>();
            var employeeController = new EmployeeController(storage.Object);

            employeeController.DeleteEmployee(1);

            storage.Verify(s => s.Delete(1));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnsRedirectResult()
        {
            var storage = new Mock<IEmployeeStorage>();
            var employeeController = new EmployeeController(storage.Object);

            var result = employeeController.DeleteEmployee(1);

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
