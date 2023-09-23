using log4net;
using log4net.Repository.Hierarchy;

namespace DenemeWebApi
{
    public class Log4NetManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        public void LogMessages()
        {
            Logger.Info("Testing information log");
            Logger.Debug("Testing Debug log");
            Logger.Fatal("Testing Fatal log");

            try
            {
                // Code that might throw an exception
                throw new Exception("This is a test exception");
            }
            catch (Exception ex)
            {
                Logger.Error("An error occurred:", ex);
            }
        }
    }
}
