using ConsoleApp1;
using Microsoft.Extensions.DependencyInjection;


var serviceProvider = new ServiceCollection()
       .AddTransient<IIoService, IoService>()
       .AddTransient<IDependenciesFinder, DependenciesFinder>()
       .BuildServiceProvider();

var ioService = serviceProvider.GetRequiredService<IIoService>();
var dependenciesFinder = serviceProvider.GetRequiredService<IDependenciesFinder>();


var inputDependencies = ioService.ReadDependencies("input.txt");

var distinctDependencies = dependenciesFinder.FindAllDistinctDependencies(inputDependencies);

ioService.PrintDistinctDependencies(distinctDependencies);

