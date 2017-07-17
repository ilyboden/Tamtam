using NUnit.Framework;
using WebApiClient.Repository;

namespace WebApiClient.Tests
{
    [TestFixture]
    public class WebApiFixtures
    {
        [Test]
        public void DoMovieApiReturnsListofMovies()
        {

            //arrange
            MovieRepository movieRepository = new MovieRepository();

            //act
            var moviesList = movieRepository.GetMoviesList("Matrix");

            //assert
            Assert.IsTrue(moviesList.Count>1);
        }

        [Test]
        public void DoVideoApiReturnsListofVideos()
        {

            //arrange
            VideoRepository videoRepository = new VideoRepository();

            //act
            var videosList = videoRepository.GetVideosList("Matrix");

            //assert
            Assert.IsTrue(videosList.Count > 1);
        }

        [Test]
        public void DoCachingReturnsListofMovies()
        {
            //arrange
            Cache_1 cache = new Cache_1();

            //act
            var moviesList = cache.AddIntoCache("Matrix");

            //assert
            Assert.IsTrue(moviesList.Count>1);
        }

        [Test]
        public void DoesItAddListofMoviesIntoCaching()
        {
            //arrange
            Cache_1 cache = new Cache_1();

            //act
            var moviesList = cache.AddIntoCache("Matrix");

            //assert
            Assert.IsTrue(moviesList.Count > 1);
        }
    }
}
