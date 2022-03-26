using Microsoft.AspNetCore.Mvc;
using SolarPanels.Core.Algorithms;
using SolarPanels.Core.Algorithms.Models;

namespace SolarPanels.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolarPanelController : Controller
    {
        [HttpPost]
        public IEnumerable<EstimatedQuote> GetEstimatedQuotes(HouseSpecifications specs)
        {
            var quotes = QuoteEstimator.GetQuotes(specs);

            return quotes;
        }
    }
}
