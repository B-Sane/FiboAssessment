using FiboApp.Computation.Models;
using FiboApp.Computation.Services;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace FiboApp.Computation.Tests.Services
{
    [TestFixture]
    public class ComputationServiceTest
    {
        [TestCase((uint)1, (uint)2)]
        [TestCase((uint)15, (uint)3002)]
        [TestCase((uint)0, (uint)56894)]
        [TestCase(uint.MinValue, uint.MaxValue)]
        [TestCase((uint) 11, (uint)102)]
        public void Should_Retrieve_A_Fibonacci_Sequence(uint start, uint end)
        {
            //Arrange
            var boundaries = new Boundaries();
            boundaries.End = end;
            boundaries.Start = start;
            var computationService = Substitute.For<IComputationService>();

            //Act
            var result = computationService.GetFibonacciSequence(boundaries);

            //Assert
            Check.That(result).IsNotNull();
        }
    }
}
