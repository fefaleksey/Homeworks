namespace LocalNetWork
{
    /// <summary>
    /// The computer in the local network
    /// </summary>
    class Computer
    {
        public bool IsInfected { get; set; }
        /// <summary>
        /// number of neihbors which is infected
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

        public bool TryInfect(double value) => OS.ProbabilityOfInfection >= value;
    }
}