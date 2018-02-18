using System;

namespace LocalNetWork
{
    /// <summary>
    /// Converse from string to operation system
    /// </summary>
    static class OSConversion
    {
        /// <summary>
        /// Create a new computer with the specified OS
        /// </summary>
        /// <param name="operationSystem">A string which contain the name of OS</param>
        /// <returns>new OS</returns>
        /// <exception cref="Exception">name of OS is incorrect</exception>
        public static OperationSystem Convert(string operationSystem)
        {
            switch (operationSystem)
            {
                case "linux":
                    return new OSLinux();
                case "windows":
                    return new OSWindows();
                case "mac":
                    return new OsMac();
                default:
                    throw new Exception("operation system is incorrect");
            }
        }
    }
}