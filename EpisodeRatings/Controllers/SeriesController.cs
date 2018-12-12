using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpisodeRatings.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpisodeRatings.Controllers
{
    [Route("api/[controller]")]
    public class SeriesController : Controller
    {
        OmdbService _omdbService;

        public SeriesController(OmdbService omdbService)
        {
            _omdbService = omdbService;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            return Ok(await _omdbService.SearchAsync(name));
        }

        [HttpGet("{id}/Seasons")]
        public async Task<IActionResult> Seasons(string id)
        {
            return Ok(await _omdbService.GetAllSeasonsAsync(id));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}