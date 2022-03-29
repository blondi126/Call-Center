using CallCenter;
using CallCenter.Core;
using CallCenter.Interfaces;

IWebLogger logger = new WebLogger();

var implementation = new Implementation(logger);

implementation.Start();

while (true)
{
    var input = Console.ReadLine();
    var tokens = SplitIntoTokens(input).ToList();
    var command = tokens.FirstOrDefault();

    if (command == null)
        continue;

    //foreach (var item in tokens)
    //    Console.Write(item + ' ');

    if (DictionaryCommands.Commands.ContainsKey(command))
    {
        try
        {
            DictionaryCommands.Commands[command](tokens.Skip(1).ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine("Не удалось выполнить: " + e.Message);
        }
    }
    else
    {
        Console.WriteLine("Неизвестная команда: " + command);
    }
}

static IEnumerable<string> SplitIntoTokens(string? s)
{
    return s == null ? Array.Empty<string>() : s.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
}