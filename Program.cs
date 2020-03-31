using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace VismaCarRental.net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // static void Main(string[] args)
        // {
        //     RunAsync().GetAwaiter().GetResult();
        // }

        // static async Task RunAsync()
        // {
        //     var vismaSign = new VismaSign(
        //         "https://sign.visma.net",
        //         identifier: "", // uuid
        //         secret: "" // in base64
        //     );

        //     var documentUri = await vismaSign.DocumentCreate(
        //         "{\"document\":{\"name\":\"C# Test document\"}}"
        //     );
        //     Console.WriteLine("Created document: " + documentUri);

        //     WebClient client = new WebClient();
        //     byte[] fileContent = client.DownloadData("https://sign.visma.net/empty.pdf");
        //     await vismaSign.DocumentAddFile(documentUri, fileContent);
        //     Console.WriteLine("Added file to document");

        //     var invitations = await vismaSign.DocumentAddInvitations(
        //         documentUri,
        //         "[{\"email\":\"petri.koivula@fraktio.fi\"}]"
        //     );
        //     Console.WriteLine("Created invitations: " + invitations);

        //     var documents = await vismaSign.DocumentSearch("offset=0");
        //     Console.WriteLine(documents);
        // }

    }
}
