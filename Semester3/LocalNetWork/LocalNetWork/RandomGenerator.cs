using System;

namespace LocalNetWork
{
    /// <summary>
    /// Random number generator
    /// </summary>
    public class RandomGenerator : IGenerator
    {
        private Random _random = new Random();   
        
        /// <summary>
        /// Get new random number
        /// </summary>
        /// <returns>New random number</returns>
        public double GetNumber() => _random.NextDouble();
    }
}