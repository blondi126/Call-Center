namespace CallCenter.Interfaces
{
    public interface IWebLogger
    {
        void Log(string message);
        string GetLogs();
    }
}
