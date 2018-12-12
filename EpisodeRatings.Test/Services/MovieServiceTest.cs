using EpisodeRatings.Models;
using EpisodeRatings.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace EpisodeRatings.Test
{
    [TestClass]
    public class MovieServiceTest
    {
        [TestMethod]
        public async Task Search_Returns_Show()
        {
            var movieService = new OmdbService();
            var result = await movieService.SearchAsync("westworld").ConfigureAwait(false);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Top_Search_Result()
        {
            var movieService = new OmdbService();
            var result = await movieService.FirstSearchResultAsync("westworld").ConfigureAwait(false);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Get_Show_By_Id()
        {
            var movieService = new OmdbService();
            var result = await movieService.GetShowByIdAsync("tt0475784").ConfigureAwait(false);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Get_Season()
        {
            var movieService = new OmdbService();
            var result = await movieService.GetSeasonAsync("tt0475784", "1").ConfigureAwait(false);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Get_All_Seasons()
        {
            var movieService = new OmdbService();
            var result = await movieService.GetAllSeasonsAsync("tt0475784").ConfigureAwait(false);
            Assert.IsNotNull(result);
        }
    }
}
