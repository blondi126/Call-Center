using System.Collections.ObjectModel;
using CallCenter.Core;
using CallCenter.Interfaces;

namespace CallCenter.Models
{
    public class AgentsList
    {
        private static IWebLogger _logger = new WebLogger();
        public static ObservableCollection<Agent> Agents { get; set; } = new ObservableCollection<Agent>();
        public AgentsList(IWebLogger logger)
        {
            _logger = logger;
            
            Agents.Add(new Agent() { Name = "Максим" });
            Agents.Add(new Agent() { Name = "Иван" });
            Agents.Add(new Agent() { Name = "Алексей" });
        }


        public static void AddAgent(string name)
        {
            Agents.Add(new Agent() { Name = name });
            _logger.Log($"Оператор {name} добавлен.");
        }

        public static void RemoveAgent(string name)
        {
            foreach (var agent in Agents)
            {
                if (agent.Name != name) continue;
                Agents.Remove(agent);
                _logger.Log($"Оператор {name} будет удален после окончания разговора.");
                break;
            }
        }
    }
}
