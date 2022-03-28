using System.Collections.ObjectModel;

namespace CallCenter.Models
{
    public class AgentsList
    {
        public ObservableCollection<Agent> Agents { get; set; } = new ObservableCollection<Agent>();
        public AgentsList()
        {
            Agents.Add(new Agent() { Name = "Максим" });
            Agents.Add(new Agent() { Name = "Иван" });
            Agents.Add(new Agent() { Name = "Алексей" });
        }
    }
}
