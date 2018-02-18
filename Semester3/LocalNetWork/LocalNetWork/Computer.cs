namespace LocalNetWork
{
    /// <summary>
    /// The computer in the local network
    /// </summary>
    class Computer
    {
        /// <summary>
        /// Flag that shows, the computer is infected or not
        /// </summary>
        public bool IsInfected { get; set; }
        
        /// <summary>
        /// Operation System of computer
        /// </summary>
        public OperationSystem OS { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="os">The concrete operation system</param>
        /// <param name="isInfected">Computer is infected or not</param>
        public Computer(OperationSystem os, bool isInfected)
        {
            OS = os;
            IsInfected = isInfected;
        }
        
        /// <summary>
        /// Try to infect the computer
        /// </summary>
        /// <param name="value">Probability of infection (obtained)</param>
        /// <returns>Computer was infected or not</returns>
        public bool TryInfect(double value) => OS.ProbabilityOfInfection >= value;
    }
}