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
    public class ErrorLoggerTests
    {
        private ErrorLogger _errorLogger;

        [SetUp]
        public void SetUp()
        {
            _errorLogger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetLastErrorProperty()
        {
            _errorLogger.Log("a");

            Assert.That(_errorLogger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgNullException(string error)
        {
            Assert.That(() => _errorLogger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;
            _errorLogger.ErrorLogged += (sender, args) =>
            {
                id = args;
            };
            _errorLogger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
