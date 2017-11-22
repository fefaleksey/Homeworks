namespace LocalNetWork
{
    /// <summary>
    /// The computer in the local network
    /// </summary>
    class Computer
    {
        /// <summary>
        /// flag that shows, the computer is infected or not
        /// </summary>
        public bool IsInfected { get; set; }
        
        /// <summary>
        /// Operation System of computer
        /// </summary>
        public OperationSystem OS { get; private set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="os">the concrete operation system</param>
        /// <param name="isInfected">computer is infected or not</param>
        public Computer(OperationSystem os, bool isInfected)
        {
            OS = os;
            IsInfected = isInfected;
        }
        
        /// <summary>
        /// Try to infect the computer
        /// </summary>
        /// <param name="value">probability of infection (obtained)</param>
        /// <returns>computer was infected or not</returns>
        public bool TryInfect(double value) => OS.ProbabilityOfInfection >= value;
    }
}