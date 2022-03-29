using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Interfaces;

namespace CallCenter.Models
{
    public static class CallList
    {
        public static ConcurrentQueue<Call> Calls { get; private set; } = new ConcurrentQueue<Call>();

        public static void CreateNewCall(IWebLogger logger)
        {
            var newCall = new Call(logger);

            CallList.Calls.Enqueue(newCall);

            logger.Log($"Новое соединение {newCall.Id} было поставлено в очередь.\n" +
                        $"Количество соединений в очереди: {CallList.Calls.Count}");
        }
    }
}
