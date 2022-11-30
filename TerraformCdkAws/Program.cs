using HashiCorp.Cdktf;
using Microsoft.Extensions.Configuration;
using TerraformCdkAws;

public class Program
{
    public static void Main(string[] _)
    {
        var config = CreateConfiguration();
        var app = new App();
        var service = new StackService(config, app);
        service.Synthesize();
        Console.WriteLine("Akashic application synth complete!");
    }

    private static IConfiguration CreateConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        return configurationBuilder.Build();
    }
}