using CallCenter;
using CallCenter.Core;
using CallCenter.Interfaces;

IWebLogger logger = new WebLogger();

var implementation = new Implementation(logger);

implementation.Start();

Console.ReadLine();