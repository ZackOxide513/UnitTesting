using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IVideoQuery _videoQuery;
        public VideoService(IVideoQuery videoQuery)
        {
            _videoQuery = videoQuery;
        }

        public string ReadVideoTitle()
        {
            var str = File.ReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var unprocessedVideoIds = new List<int>();
            var unprocessedVideos = _videoQuery.GetUnprocessedVideos();

            foreach (var v in unprocessedVideos)
                unprocessedVideoIds.Add(v.Id);

            return String.Join(",", unprocessedVideoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}