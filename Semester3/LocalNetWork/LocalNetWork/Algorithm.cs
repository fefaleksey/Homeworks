using System.Collections.Generic;

namespace LocalNetWork
{
    /// <summary>
    /// The algorithm where state of the local network change
    /// </summary>
    static class Algorithm
    {
        /// <summary>
        /// Infection of computers
        /// </summary>
        /// <param name="computers">the concrete computers</param>
        /// <param name="adjacencyMatrix">matrix with computers</param>
        /// <param name="numberGenerator">used Generator</param>
        /// <returns>index of computers which will be infected</returns>
        public static List<int> MakeInfection(Computer[] computers, int[,] adjacencyMatrix, IGenerator numberGenerator)
        {
            var indexInfected = new List<int>();
            var number = numberGenerator.GetNumber();
            for (var i = 0; i < computers.Length; i++)
            {
                if (computers[i].IsInfected)
                {
                    for (var j = 0; j < computers.Length; j++)
                    {
                        if (adjacencyMatrix[i, j] == 1 && computers[j].TryInfect(number))
                        {
                            indexInfected.Add(j);
                        }
                    }
                }
            }

            return indexInfected;
        }
    }
}