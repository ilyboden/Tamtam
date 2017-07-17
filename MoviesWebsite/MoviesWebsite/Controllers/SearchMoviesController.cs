using MoviesWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoviesWebsite.Controllers
{
    public class SearchMoviesController : Controller
    {
        string moviesTrailers_Url => ConfigurationManager.AppSettings["MoviesTrailersApi"];
        public ActionResult Index()
        {
            return View();
        }
        
        //I'm only passing movie name in search. You can pass here list to webapi to do multiple searches e.g. year, genre, directed by, cast etc
        [HttpPost]
        public async Task<ActionResult> Index(SearchMovies sm)
        {
            var client = new HttpClient();

            var response = await client.PostAsJsonAsync(moviesTrailers_Url, sm.MovieName);
            if (response.IsSuccessStatusCode)
            {
               var moviesResults = JsonConvert.DeserializeObject<List<SearchMovies>>(
                   await client.GetStringAsync(moviesTrailers_Url));

                return PartialView(@"~/Views/Shared/_Results.cshtml", moviesResults);                
            }
            ViewData["message"] = "something went wrong can't access search list";
            return View();            
        }
        
    }
}