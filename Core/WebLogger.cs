using CallCenter.Interfaces;
using System.Text;

namespace CallCenter.Core
{
    public class WebLogger : IWebLogger
    {
        private readonly StringBuilder _textHolder = new();
        private readonly object _syncObject = new();
        public string LogMessage { get; private set; } = string.Empty;

        public void Log(string message)
        {
            try
            {
                lock (_syncObject)
                {
                    _textHolder.Append(message);
                    _textHolder.AppendLine();
                    LogMessage = _textHolder.ToString();
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
        public string GetLogs()
        {
            return LogMessage;
        }
    }
}
