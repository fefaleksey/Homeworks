using System.Collections.Generic;

namespace LocalNetWork
{
    /// <summary>
    /// Network model
    /// </summary>
    class NetworkModel
    {
        private Computer[] _computers;
        private int[,] _compsMatrix;
        private Generator _generator;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="comps">the concrete computers</param>
        /// <param name="matrix">adjacency matrix where show computer connection</param>
        /// <param name="numberGenerator">used Generator</param>
        public NetworkModel(Computer[] comps, int[,] matrix, Generator numberGenerator)
        {
            this._computers = comps;
            this._compsMatrix = matrix;
            this._generator = numberGenerator;
        }

        /// <summary>
        /// show the next state of the network
        /// </summary>
        /// <returns></returns>
        public Computer[] NetworkState()
        {
            return _computers;
        }

        /// <summary>
        /// moves to the next state of the network
        /// </summary>
        public void MakeStep()
        {
            List<int> indexInfected = Algorithm.MakeInfection(_computers, _compsMatrix, _generator);
            foreach (var index in indexInfected)
            {
                _computers[index].IsInfected = true;
            }
        }
    }
}