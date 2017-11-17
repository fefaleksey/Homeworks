using System;

namespace LocalNetWork
{
    /// <summary>
    /// Converse from string to operation system
    /// </summary>
    class OSConversion
    {
        public static OperationSystem Convert(string operationSystem)
        {
            switch (operationSystem)
            {
                case ("linux"):
                    return new OSLinux();
                case ("windows"):
                    return new OSWindows();
                case ("mac"):
                    return new OsMac();
                default:
                    throw new Exception("operation system is incorrect");
            }
        }
    }
}