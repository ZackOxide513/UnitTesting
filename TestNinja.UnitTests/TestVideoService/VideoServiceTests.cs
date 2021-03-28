using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.TestVideoService
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IVideoQuery> _videoQuery;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _videoQuery = new Mock<IVideoQuery>();
            _videoService = new VideoService(_videoQuery.Object);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_ListHaveElements_ReturnsCsvOfVideoIds()
        {
            _videoQuery.Setup(vq => vq.GetUnprocessedVideos()).Returns(
                new List<Video> { new Video { Id = 1, IsProcessed = false, Title = "A"},
                                  new Video { Id = 3, IsProcessed = false, Title = "C"} }
                );

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,3"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_ListDoesntHaveElements_ReturnsEmptyString()
        {
            _videoQuery.Setup(vq => vq.GetUnprocessedVideos()).Returns(
                new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
