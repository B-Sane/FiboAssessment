using FiboApp.Computation.Models;
using System.Collections.Generic;

namespace FiboApp.Computation.Services
{
    /// <summary>
    /// ComputationService
    /// </summary>
    public class ComputationService : IComputationService
    {
        /// <summary>
        /// Computes the sequence of fibonacci given boundaries.
        /// </summary>
        /// <param name="boundaries"></param>
        /// <returns>IEnumerable<int>.</returns>
        public IEnumerable<int> GetFibonacciSequence(Boundaries boundaries)
        {
            var iteration0 = 0;
            var iteration1 = 1;
            var iteration2 = 1;
            
            yield return iteration0;
            yield return iteration1;
            yield return iteration2;

            var intermediaire = iteration0;
            do
            {
                intermediaire = iteration1 + iteration2;
                iteration1 = iteration2;
                iteration2 = intermediaire;

                yield return intermediaire;
            } while (intermediaire < boundaries.End);

        }

    }
}
