using CallCenter.Interfaces;

namespace CallCenter.Models
{
    public class Call
    {
        private readonly IWebLogger _logger;
        public Guid Id { get; }
        public int DurationInSec { get; private set; }

        public Call(IWebLogger logger)
        {
            _logger = logger;
            Id = Guid.NewGuid();
            SetDuration();
        }

        public void Start(string agentName)
        {
            _logger.Log($"Оператор {agentName} начал разговор {Id}.");
        }

        public void End(string agentName)
        {
            _logger.Log($"Оператор {agentName} закончил разговор длиной {DurationInSec} секунд.");
        }
        private void SetDuration()
        {
            var r = new Random();
            DurationInSec = r.Next(15, 20);
        }
    }
}
