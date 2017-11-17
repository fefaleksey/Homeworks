namespace LocalNetWork
{
    /// <summary>
    /// Not randomly number generator for tests
    /// </summary>
    public class DefinedGenerator : Generator
    {
        private double[] _arrayOfRandom;
        private int _pointer = -1;

        public DefinedGenerator(double[] array)
        {
            _arrayOfRandom = array;
        }

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