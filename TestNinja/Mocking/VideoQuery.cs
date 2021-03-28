using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoQuery
    {
        List<Video> GetUnprocessedVideos();
    }

    public class VideoQuery : IVideoQuery
    {
        public List<Video> GetUnprocessedVideos()
        {
            using (var context = new VideoContext())
            {
                var videos = (from video in context.Videos
                              where !video.IsProcessed
                              select video);
                return videos.ToList();
            }
        }
    }
}
