namespace LocalNetWork
{
    /// <summary>
    /// Operation system for computer, have own probability of infection
    /// </summary>
    class OperationSystem
    {
        public double ProbabilityOfInfection { get; private set; }

        public OperationSystem(double probability)
        {
            ProbabilityOfInfection = probability;
        }
    }
}