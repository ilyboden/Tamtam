using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApiClient.Models;

namespace WebApiClient.Repository
{
    public class VideoRepository
    {
        string videosApi_Url => ConfigurationManager.AppSettings["VideosAppKey"];

        // search youtube api and get videos trailers
        // for some reason youtube service throwing error so i'm using in memory list for videos to carry on work
        public void GetVideosList1(string videoTitle)
        {            
            YouTubeService yt = new YouTubeService
                (new BaseClientService.Initializer() { ApiKey = videosApi_Url });

            var searchListRequest = yt.Search.List("contentDetails");
            searchListRequest.ChannelId = "movieclipsTRAILERS";
            var searchListResult = searchListRequest.Execute();
            List<string> videos = new List<string>();

            foreach (var item in searchListResult.Items)
            {                
                videos.Add(String.Format("{0} ({1})", item.Snippet.Title, item.Id.VideoId));                
            }
        }

        //using in memory list for videos as unable to retrieve videos trailers from youtube webapi
        public List<Videos> GetVideosList(string search)
        {
            return new List<Videos>
        {
            new Videos { Title = "Unavailable", Vote_Count = 10,Overview="yes",Release_Date="12-09-2010", VideoUrl = "Url Unavailable"}
        };

        }

    }
}