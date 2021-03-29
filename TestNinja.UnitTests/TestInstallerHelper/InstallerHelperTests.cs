using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.TestInstallerHelper
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;
        private Mock<IInstallerWebConnection> _installerWebConnection;
        [SetUp]
        public void SetUp()
        {
            _installerWebConnection = new Mock<IInstallerWebConnection>();
            _installerHelper = new InstallerHelper(_installerWebConnection.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _installerWebConnection.Setup(wc => wc.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadSucceeds_ReturnsTrue()
        {
            _installerWebConnection.Setup(wc => wc.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }
    }
}
