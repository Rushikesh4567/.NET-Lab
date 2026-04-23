using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace exp10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Navigated to the Home Index action in Experiment 10.");

            string cacheKey = "TimeCacheKey";
            if (!_cache.TryGetValue(cacheKey, out string currentTime))
            {
                // Key not in cache, so get data
                currentTime = System.DateTime.Now.ToString("F");

                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(System.TimeSpan.FromSeconds(10));

                // Save data in cache
                _cache.Set(cacheKey, currentTime, cacheEntryOptions);

                _logger.LogWarning("Time added to cache: {Time}", currentTime);
                ViewBag.Message = "Generated new time and cached it: " + currentTime;
            }
            else
            {
                _logger.LogInformation("Time retrieved from cache: {Time}", currentTime);
                ViewBag.Message = "Retrieved time from cache: " + currentTime;
            }

            return View();
        }
    }
}
