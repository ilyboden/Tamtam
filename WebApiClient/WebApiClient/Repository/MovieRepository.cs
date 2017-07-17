using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using WebApiClient.Models;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;

namespace WebApiClient.Repository
{
    public class MovieRepository
    {
        string moviesApi_Url => ConfigurationManager.AppSettings["MoviesAppKey"];
                
        public List<Movies> GetMoviesList(string movieTitle)
        {

            using (var client = new System.Net.Http.HttpClient())
            {               
                var response = client.GetAsync(string.Format("{0}{1}", moviesApi_Url, movieTitle)).Result;

                using (HttpContent content = response.Content)
                {                
                    var json = content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<MoviesRootObject>(json.Result);
                    var r = result.results;
                    return result.results;                    
                }
            }
        }
                       

        }
    }