namespace Robots
{
    /// <summary>
    /// Class which realised algorithm, which checked teleportations,
    /// destroying all robots exist or not
    /// </summary>
    public class GraphWithRobots
    {
        private int _numberOfVertices;
        private bool[,] _matrix;
        private bool[] _robotsPosition;
        private bool[] _wasVisited;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphWithRobots"/> class
        /// </summary>
        /// <param name="numberOfVertices">Number Of Vertices</param>
        /// <param name="positions">Positions, where robots are there</param>
        public GraphWithRobots(int numberOfVertices, int[] positions)
        {
            _numberOfVertices = numberOfVertices;
            _matrix = new bool[numberOfVertices, numberOfVertices];

            for (var i = 0; i < numberOfVertices; i++)
            {
                for (var j = 0; j < numberOfVertices; j++)
                {
                    _matrix[i, j] = false;
                }
            }

            _robotsPosition = new bool[numberOfVertices];

            for (var j = 0; j < positions.Length; j++)
            {
                _robotsPosition[positions[j]] = true;
            }
            _wasVisited = new bool[numberOfVertices];
            for (var i = 0; i < numberOfVertices; i++)
            {
                _wasVisited[i] = false;
            }
        }

        /// <summary>
        /// Connect two verteces
        /// </summary>
        public void ConnectVerteces(int first, int second)
        {
            _matrix[first, second] = true;
            _matrix[second, first] = true;
        }

        /// <summary>
        /// If this method finds the robot, which doesn't face other robot at teleportations,
        ///  return false
        /// </summary>
        public bool CheckExistOrNot()
        {
            for (var i = 0; i < _numberOfVertices; i++)
            {
                if (!_wasVisited[i] && _robotsPosition[i])
                {
                    var numberConected = 0;
                    FindConnectedRobots(i, ref numberConected);
                    if (numberConected == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void FindConnectedRobots(int vertex, ref int connected)
        {
            if (_wasVisited[vertex])
            {
                return;
            }

            if (_robotsPosition[vertex])
            {
                connected++;
            }
            _wasVisited[vertex] = true;
            for (var i = 0; i < _numberOfVertices; i++)
            {
                if (_matrix[vertex, i])
                {
                    for (var j = 0; j < _numberOfVertices; j++)
                    {
                        if (_matrix[i, j])
                        {
                            FindConnectedRobots(j, ref connected);
                        }
                    }
                }
            }
        }
    }
}