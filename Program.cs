using Microsoft.Extensions.DependencyInjection;
using StringChanger.Application;
using StringChanger.Application.StringPreprocessor;

ServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.RegisterApplication();

ServiceProvider provider = serviceCollection.BuildServiceProvider();

var service = provider.GetService<IStringPreprocessor>();
service.Process("привет.мир$это приветствие.34цййцуй543!");
var result = service.GetProcessedString();
Console.WriteLine(result);
