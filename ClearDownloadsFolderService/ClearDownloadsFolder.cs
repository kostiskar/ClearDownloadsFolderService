using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ClearDownloadsFolderService
{
    public class ClearDownloadsFolder
    {
        private readonly Timer _timer;

        // Get the path from the config file
        string folderPath = ConfigurationManager.AppSettings["FolderPath"].ToString();

        public ClearDownloadsFolder()
        {
            // The Service runs in a loop every 5 days
            _timer = new Timer(432000*1000) { AutoReset = true };

            // Create the event
            _timer.Elapsed += HandleTimerElapsed;
        }

        // Specify what you want to happen when the Elapsed event is  
        // raised.
        private void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            DirectoryInfo folderWithFilesToBeDeleted = new DirectoryInfo(folderPath);

            // Delete all files at that directory
            foreach(FileInfo file in folderWithFilesToBeDeleted.GetFiles())
            {
                file.Delete();
            }
        }

        // Start() should be implemented in a service
        public void Start()
        {
            _timer.Start();
        }

        // Stop() should be implemented in a service
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
