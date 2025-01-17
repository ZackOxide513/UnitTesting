﻿using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IInstallerWebConnection _installerWebConnection;

        public InstallerHelper(IInstallerWebConnection installerWebConnection)
        {
            _installerWebConnection = installerWebConnection;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _installerWebConnection.DownloadFile(string.Format("http://example.com/{0}/{1}", customerName, installerName), _setupDestinationFile);

                return true;
            }
            catch(WebException)
            {
                return false;
            }
        }
    }
}