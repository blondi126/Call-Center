using CallCenter.Core;
using CallCenter.Models;

namespace CallCenter
{
    public static class DictionaryCommands
    {
        internal static Dictionary<string, Action<List<string>>> Commands =
            new()
            {
                { "add", AddCommand((string name) => { 
                        if (name == "new call")
                            CallList.CreateNewCall(new WebLogger());
                        else 
                            AgentsList.AddAgent(name);
                    })
                },
                { "remove", RemoveCommand(AgentsList.RemoveAgent) }
            };

        private static Action <List<string>> AddCommand(Action<string> a)
        {
            return args =>
            {
                switch (args.Count)
                {
                    case 2 when args.First() == "agent":
                        a(args.ElementAt(1));
                        break;
                    case 1 when args.First() == "call":
                        a("new call");
                        break;
                    default:
                        throw new ArgumentException("Некорректная команда. Используйте add agent [name] или add call.");
                }
            };
        }
        private static Action<List<string>> RemoveCommand(Action<string> a)
        {
            return args =>
            {
                if (args.Count == 2 && args.First() == "agent")
                    a(args.ElementAt(1));
                else 
                    throw new ArgumentException("Некорректная команда. Используйте remove agent [name].");
            };
        }
    }
}
