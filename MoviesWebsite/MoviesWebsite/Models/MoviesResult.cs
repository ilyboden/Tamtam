using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesWebsite.Models
{
    public class MoviesResult
    {
        public string Title { get; set; }
        public int Vote_Count { get; set; }
        public string Overview { get; set; }
        public string Release_Date { get; set; }
        public string VideoUrl { get; set; }
    }
}