using YourTube.Core.Models;

namespace YourTube.Core.IServices
{
    public interface IYouTubeClientService
    {
        Task<SearchResponseDto> SearchAsync(string q, int maxResult);
        Task<ChannelResponseDto> SearchChannelAsync(string channelName, int maxResult);
    }
}
