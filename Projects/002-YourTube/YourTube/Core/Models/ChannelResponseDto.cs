namespace YourTube.Core.Models
{
    public class ChannelResponseDto
    {
        public List<VideoResult> Videos { get; set; } = new List<VideoResult>();
        public List<PlaylistResult> Playlists { get; set; } = new List<PlaylistResult>();
    }
}
