namespace LocalNetWork
{
    /// <summary>
    /// Interface for generation of numbers
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Method for obtaining a random number
        /// </summary>
        /// <returns>Probability</returns>
        double GetNumber();
    }
}