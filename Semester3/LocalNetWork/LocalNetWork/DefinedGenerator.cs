namespace LocalNetWork
{
    /// <summary>
    /// Not randomly number generator for tests
    /// </summary>
    public class DefinedGenerator : IGenerator
    {
        private double[] _arrayOfRandom;
        private int _pointer = -1;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">array which contain probabilites</param>
        public DefinedGenerator(double[] array)
        {
            _arrayOfRandom = array;
        }

        /// <summary>
        /// Get curent probability
        /// </summary>
        /// <returns>curent probability</returns>
        public double GetNumber()
        {
            _pointer++;

            if (_pointer == _arrayOfRandom.Length)
            {
                _pointer = 0;
            }
            
            return _arrayOfRandom[_pointer];
        }
    }
}