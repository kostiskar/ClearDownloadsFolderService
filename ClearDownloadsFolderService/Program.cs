using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ClearDownloadsFolderService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start the service, run until it stops and then grab exitCode
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<ClearDownloadsFolder>(s =>
                {
                    s.ConstructUsing(clearDownLoadsFolder => new ClearDownloadsFolder());
                    s.WhenStarted(clearDownLoadsFolder => clearDownLoadsFolder.Start());
                    s.WhenStopped(clearDownLoadsFolder => clearDownLoadsFolder.Stop());
                });

                x.RunAsLocalSystem();

                // Configure the 'machine-friendly' name
                x.SetServiceName("ClearDownloadsFolderService");

                // Configure the description
                x.SetDisplayName("This is a service that clears the Downloads folder" +
                                 "every 1 minute");
            });

            // Convert from enum to integer and passing it out
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
