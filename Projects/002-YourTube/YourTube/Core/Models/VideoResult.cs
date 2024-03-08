namespace YourTube.Core.Models
{
    public class VideoResult
    {
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTimeOffset? PublishTime { get; set; }
    }
}
