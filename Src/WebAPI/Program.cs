using Microsoft.AspNetCore.Hosting;
using Tasks;


var host = new WebHostBuilder()
    .UseKestrel()
    .UseStartup<Startup>()
    .UseUrls()
    .Build();   
    
host.Run();