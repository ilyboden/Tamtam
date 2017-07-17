using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiClient.Models;

namespace WebApiClient.Models
{
    public class MoviesRootObject
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Movies> results { get; set; }
    }
}