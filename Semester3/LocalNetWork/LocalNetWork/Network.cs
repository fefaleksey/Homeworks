namespace LocalNetWork
{
    /// <summary>
    /// Local network for using
    /// </summary>
    public class Network
    {
        private NetworkModel _network;
        private Computer[] _computers;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="infected">array where show comp is infested or not</param>
        /// <param name="operationSystemOfComps">array where show which OS the comp has</param>
        /// <param name="matrix">adjacency matrix where show computer connection</param>
        /// <param name="generator">used Generator</param>
        public Network(bool[] infected, string[] operationSystemOfComps, int[,] matrix, Generator generator)
        {
            var numberOfComps = infected.Length;
            _computers = new Computer[numberOfComps];
            for (var i = 0; i < numberOfComps; i++)
            {
                _computers[i] = new Computer(OSConversion.Convert(operationSystemOfComps[i]), infected[i]);
            }
            _network = new NetworkModel(_computers, matrix, generator);
        }

        /// <summary>
        /// moves to the next state of the network
        /// </summary>
        public void MakeStep()
        {
            _network.MakeStep();
        }

        /// <summary>
        /// show the next state of the network
        /// </summary>
        /// <returns></returns>
        public string NetworkState()
        {
            var state = "Infected: ";
            _computers = _network.NetworkState();
            for (var i = 0; i < _computers.Length; i++)
            {
                if (_computers[i].IsInfected)
                {
                    state += i + 1 + " ";
                }
            }
            return state;
        }
    }
}