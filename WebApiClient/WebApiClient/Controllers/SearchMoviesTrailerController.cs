using System.Collections.Generic;
using System.Web.Http;
using WebApiClient.Models;
using WebApiClient.Repository;

namespace WebApiClient.Controllers
{
    public class SearchMoviesTrailerController : ApiController
    {
        readonly Cache_1 cache = new Cache_1();

        //i'm only passing one search here that's movie name. 
        //you can change it into list and pass multiple searches e.g. year, genre, directed by, cast, actors 
        [HttpPost]
        public IHttpActionResult SearchMoviesTailers(string search)
        {
            cache.CacheMiscs(search);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<MoviesTrailers> GetAllMoviesTailers(string search)
        {
            return cache.CacheMiscs(search);        
        }
    }
}
