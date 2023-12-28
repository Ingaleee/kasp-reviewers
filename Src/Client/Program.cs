using Client;
using Client.API;
using Client.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var allowedCommands = new[] {"create", "status"};
if (args.Length < 1)
{
    Console.WriteLine("Usage: reviewer_util [create/status] [taskId] [path] [rulesFile]");
    return;
}

var command = args[0].ToLower();
if (!allowedCommands.Contains(command))
{
    Console.WriteLine("Usage: reviewer_util [create/status] [taskId] [path] [rulesFile]");
    return;
}

var configuration = await Configurator.LoadWithAsync<JsonConfigurationLoader>();

var services = new ServiceCollection().AddOptions().Configure<AppSettings>(configuration);
services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
services.AddSingleton<ReviewersTaskAPI>();

var provider = services.BuildServiceProvider();

var mediator = provider.GetService<IMediator>();
if (command == "create")
{
    var query = new CreateTaskRequestCommand
    {
        Path = args[0],
        Rules = args[1]
    };
    await mediator.Send(query);
    return;
}

if (command == "status")
{
    var parsed = ulong.TryParse(args[1], out var id);
    if (!parsed)
    {
        Console.WriteLine("[taskId] must be a number");
        return;
    }
    var query = new GetTaskRequestQuery { Id = id };
    await mediator.Send(query);
}




