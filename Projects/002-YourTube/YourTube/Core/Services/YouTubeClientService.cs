using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Options;
using YourTube.Core.IServices;
using YourTube.Core.Models;

namespace YourTube.Core.Services
{
    public class YouTubeClientService : IYouTubeClientService
    {
        #region DI & Ctor
        private readonly YouTubeService _youTubeService;
        public YouTubeClientService(IOptions<YouTubeKeys> youTubeKeys)
        {
            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = youTubeKeys.Value.ApiKey,
                ApplicationName = youTubeKeys.Value.ApplicationName
            });
        }
        #endregion

        public async Task<SearchResponseDto> SearchAsync(string q, int maxResult)
        {
            var searchRequest = _youTubeService.Search.List("snippet");
            searchRequest.Q = q;
            searchRequest.MaxResults = maxResult;

            var searchResponse = await searchRequest.ExecuteAsync();

            SearchResponseDto searchResponseDto = new SearchResponseDto();

            foreach (var searchItem in searchResponse.Items)
            {
                switch (searchItem.Id.Kind)
                {
                    case "youtube#video":
                        searchResponseDto.Videos.Add(new VideoResult()
                        {
                            Id = searchItem.Id.VideoId,
                            Thumbnail = searchItem.Snippet.Thumbnails.Medium.Url,
                            Title = searchItem.Snippet.Title,
                            Url = $"https://www.youtube.com/watch?v={searchItem.Id.VideoId}",
                            PublishTime = searchItem.Snippet.PublishedAtDateTimeOffset
                        });
                        break;

                    case "youtube#channel":
                        searchResponseDto.Channels.Add(new ChannelResult()
                        {
                            Id = searchItem.Id.ChannelId,
                            Title = searchItem.Snippet.Title,
                            Url = $"https://www.youtube.com/channel/{searchItem.Id.ChannelId}",
                        });
                        break;

                    case "youtube#playlist":
                        searchResponseDto.Playlists.Add(new PlaylistResult()
                        {
                            Id = searchItem.Id.PlaylistId,
                            Thumbnail = searchItem.Snippet.Thumbnails.Medium.Url,
                            Title = searchItem.Snippet.Title,
                            Url = $"https://www.youtube.com/playlist?list={searchItem.Id.PlaylistId}",
                        });
                        break;
                }
            }

            return searchResponseDto;
        }

        public async Task<ChannelResponseDto> SearchChannelAsync(string channelName, int maxResult)
        {
            var searchRequest = _youTubeService.Search.List("snippet");
            searchRequest.ChannelId = channelName;
            searchRequest.MaxResults = maxResult;
            searchRequest.Order = SearchResource.ListRequest.OrderEnum.Date;

            var searchResponse = await searchRequest.ExecuteAsync();

            ChannelResponseDto channelResponseDto = new ChannelResponseDto();

            foreach (var searchItem in searchResponse.Items)
            {
                switch (searchItem.Id.Kind)
                {
                    case "youtube#video":
                        channelResponseDto.Videos.Add(new VideoResult()
                        {
                            Id = searchItem.Id.VideoId,
                            Thumbnail = searchItem.Snippet.Thumbnails.Medium.Url,
                            Title = searchItem.Snippet.Title,
                            Url = $"https://www.youtube.com/watch?v={searchItem.Id.VideoId}",
                            PublishTime = searchItem.Snippet.PublishedAtDateTimeOffset
                        });
                        break;

                    case "youtube#playlist":
                        channelResponseDto.Playlists.Add(new PlaylistResult()
                        {
                            Id = searchItem.Id.PlaylistId,
                            Thumbnail = searchItem.Snippet.Thumbnails.Medium.Url,
                            Title = searchItem.Snippet.Title,
                            Url = $"https://www.youtube.com/playlist?list={searchItem.Id.PlaylistId}",
                        });
                        break;
                }
            }

            return channelResponseDto;
        }
    }
}
