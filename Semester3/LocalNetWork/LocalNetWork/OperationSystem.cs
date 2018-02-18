namespace LocalNetWork
{
    /// <summary>
    /// Operation system for computer, have own probability of infection
    /// </summary>
    class OperationSystem
    {
        /// <summary>
        /// Probability of infection
        /// </summary>
        public double ProbabilityOfInfection { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationSystem"/> class
        /// </summary>
        /// <param name="probability">Probability of infection</param>
        public OperationSystem(double probability)
        {
            ProbabilityOfInfection = probability;
        }
    }
}