using System;

namespace LocalNetWork
{
    public class RandomGenerator : IGenerator
    {
        private Random _random = new Random();

        public double GetNumber() => _random.NextDouble();
    }
}