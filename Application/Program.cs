using System.IO;
using Amazon;
using Amazon.Runtime.CredentialManagement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = new CredentialProfileOptions
            {
                AccessKey = args[3],
                SecretKey = args[5]
            };
            var profile = new CredentialProfile("shared_profile", options);
            profile.Region = RegionEndpoint.EUCentral1;
            var sharedFile = new SharedCredentialsFile();
            sharedFile.RegisterProfile(profile);
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls($"http://+:{args[1]}")
                .Build();

            host.Run();
        }
    }
}
