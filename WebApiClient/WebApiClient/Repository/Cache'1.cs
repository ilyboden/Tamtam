using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using WebApiClient.Models;
using System.Collections;

namespace WebApiClient.Repository
{
    public class Cache_1
    {
        private const string CacheKey = "moviesResult";
        ObjectCache cache = MemoryCache.Default;

        readonly MovieRepository movieRepository = new MovieRepository();

        readonly VideoRepository videoRepository = new VideoRepository();

        // search string in both api's, merge them and return the results for caching 
        public List<MoviesTrailers> SearchWebApis(string search)
        {
            
            var videosList = videoRepository.GetVideosList(search);
            var moviesList = movieRepository.GetMoviesList(search);
            
            // do the merges here and return merged list
            return moviesList.Select(x => new MoviesTrailers()
            { Title = x.title, Vote_Count = x.vote_count, Overview = x.overview, Release_Date = x.release_date}).ToList();
            
        }

        //cache searched results
        public List<MoviesTrailers> CacheMiscs(string search)
        {
            //check if cache key don't exists add it into cache
            if (!cache.Contains(CacheKey))
            {                
                return AddIntoCache(search);
            }
            else // if cachekey exist retreive cachekey and check if search string already exist in cached list
            {
                var cachedList = GetCachedList().ToList();

                if (cachedList.Any(str => str.Title.Contains(search)))
                {
                    return cachedList;
                }
                else
                {
                    cache.Remove(CacheKey);
                    return AddIntoCache(search);
                }                
            }

        }

        // add into cache
        public List<MoviesTrailers> AddIntoCache(string search)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);

            var searchedResults = SearchWebApis(search);

            cache.Add(CacheKey, searchedResults, cacheItemPolicy);

            return searchedResults;
        }

        // get items from cache
        public IEnumerable<MoviesTrailers> GetCachedList()
        {
            if (cache.Contains(CacheKey))
                return (IEnumerable<MoviesTrailers>)cache.Get(CacheKey);
            else
                return Enumerable.Empty<MoviesTrailers>();
        }

    }
}

