using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoQuery
    {
        List<int> GetVideoIds();
    }

    public class VideoQuery : IVideoQuery
    {
        public List<int> GetVideoIds()
        {
            using (var context = new VideoContext())
            {
                var videoIds = (from video in context.Videos
                              where !video.IsProcessed
                              select video.Id);
                return videoIds.ToList();
            }
        }
    }
}
