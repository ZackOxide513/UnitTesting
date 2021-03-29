using System.Net;

namespace TestNinja.Mocking
{
    public interface IInstallerWebConnection
    {
        void DownloadFile(string url, string path);
    }

    public class InstallerWebConnection : IInstallerWebConnection
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
