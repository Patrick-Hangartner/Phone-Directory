using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PhoneDirectory.Data;
using PhoneDirectory;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<EmployeeContext>();
            DbInitializer.Seed(context);
        }
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
          });
}


