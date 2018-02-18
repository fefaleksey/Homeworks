using System.Collections.Generic;

namespace LocalNetWork
{
    /// <summary>
    /// Local network for using
    /// </summary>
    public class Network
    {
        private Computer[] _computers;
        private int[,] _compsMatrix;
        private IGenerator _generator;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="infected">Array where show comp is infested or not</param>
        /// <param name="operationSystemOfComps">Array where show which OS the comp has</param>
        /// <param name="matrix">Adjacency matrix where show computer connection</param>
        /// <param name="generator">Used Generator</param>
        public Network(bool[] infected, string[] operationSystemOfComps, int[,] matrix, IGenerator generator)
        {
            var numberOfComps = infected.Length;
            _computers = new Computer[numberOfComps];
            for (var i = 0; i < numberOfComps; i++)
            {
                _computers[i] = new Computer(OSConversion.Convert(operationSystemOfComps[i]), infected[i]);
            }
            _compsMatrix = matrix;
            _generator = generator;
        }

        /// <summary>
        /// Moves to the next state of the network
        /// </summary>
        public void MakeStep()
        {
            List<int> indexInfected = Algorithm.MakeInfection(_computers, _compsMatrix, _generator);
            foreach (var index in indexInfected)
            {
                _computers[index].IsInfected = true;
            }
        }

        /// <summary>
        /// Show the next state of the network
        /// </summary>
        /// <returns></returns>
        public string NetworkState()
        {
            var state = "Infected: ";
            //_computers = _network.NetworkState();
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