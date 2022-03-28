using CallCenter.Interfaces;
using CallCenter.Models;
using System.Collections.Concurrent;

namespace CallCenter
{
    internal class Implementation
    {
        private readonly IWebLogger _logger;
        public ConcurrentQueue<Call> Calls { get; set; } = new ConcurrentQueue<Call>();
        public AgentsList AgentsList { get; set; }


        public Implementation(IWebLogger logger)
        {
            _logger = logger;
            AgentsList = new AgentsList();
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(AddNewCall);
            ThreadPool.QueueUserWorkItem(HandleCalls);
        }

        private void AddNewCall(object? stateInfo)
        {
            while (true)
            {
                AddCallMethod();

                var rnd = new Random();
                var sleepTime = rnd.Next(3, 5) * 1000;
                Thread.Sleep(sleepTime);
            }
        }

        private void AddCallMethod()
        {
            var newCall = new Call(_logger);

            Calls.Enqueue(newCall);

            _logger.Log($"Новое соединение {newCall.Id} было поставлено в очередь.\n" +
                        $"Количество соединений в очереди: {Calls.Count}");
        }

        private void HandleCalls(object? stateInfo)
        {
            while (true)
            {
                Thread.Sleep(1 * 1000);
                ThreadPool.QueueUserWorkItem(HandleCall);
            }
        }

        private void HandleCall(object? stateInfo)
        {
            var agent = AgentsList!.Agents.FirstOrDefault(agent => !agent.IsBusy);
            if (agent == null) return;
            if (!Calls.TryDequeue(out var call)) return;
            lock (agent)
            {
                call.Start(agent.Name);
                agent.IsBusy = true;

                _logger.Log($"Количество соединений в очереди: {Calls.Count}.");
                Thread.Sleep(call.DurationInSec * 1000);
                call.End(agent.Name);
                agent.IsBusy = false;
            }
        }
    }
}
