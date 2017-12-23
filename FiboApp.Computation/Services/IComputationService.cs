using FiboApp.Computation.Models;
using System.Collections.Generic;

namespace FiboApp.Computation.Services
{
    public interface IComputationService
    {
        IEnumerable<int> GetFibonacciSequence(Boundaries boundaries);
    }
}
