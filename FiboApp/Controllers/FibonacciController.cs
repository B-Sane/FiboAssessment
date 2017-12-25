using FiboApp.Computation.Models;
using FiboApp.Computation.Services;
using FiboApp.Configuration;
using System.Linq;
using System.Web.Http;

namespace FibonacciApp.Controllers
{
    /// <summary>
    /// FibonacciController
    /// </summary>
    [RoutePrefix(FibonacciRoutesDefinition.RootApiV1)]
    public class FibonacciController : ApiController
    {
        /// <summary>
        /// IComputationService.
        /// </summary>
        public readonly IComputationService _computationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciController"/> class.
        /// </summary>
        /// <param name="computationService"></param>        
        public FibonacciController(IComputationService computationService)
        {
            _computationService = computationService;
        }


        /// <summary>
        /// Returns the sequence of fibonacci between the specified boundaries.
        /// </summary>
        /// <param name="boundaries"></param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        [Route(FibonacciRoutesDefinition.GetFibonacciSequence)]
        public IHttpActionResult GetSequenceBetween(Boundaries boundaries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (boundaries.End < boundaries.Start)
                return BadRequest("End boundary shouldn't be greater than Start one! Please checkout your entries");

            else
                return Ok(_computationService.GetFibonacciSequence(boundaries)
                            .ToList()
                            .Where(x => x >= boundaries.Start && x <= boundaries.End));
        }
    }
}
