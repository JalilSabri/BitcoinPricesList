using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading;
using System.Web.Http;

[ApiController]
[System.Web.Http.Route("[controller]")]
public class MyApiController : ApiController
{
    // Your API endpoint
    [System.Web.Http.HttpGet]
    public IHttpActionResult DoWork()
    {
        // Create and configure BackgroundWorker
        var backgroundWorker = new BackgroundWorker();
        backgroundWorker.DoWork += BackgroundWorker_DoWork;
        backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

        // Start the BackgroundWorker
        backgroundWorker.RunWorkerAsync();

        // Respond immediately to the API request
        return Ok("Background work started.");
    }

    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Background work goes here
        Console.WriteLine("Background work is in progress...");

        // Simulate some work
        Thread.Sleep(5000);

        Console.WriteLine("Background work is complete.");
    }

    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // This method is called when the background work is complete
        if (e.Error != null)
        {
            // Handle any errors that occurred during the background work
            Console.WriteLine($"Error: {e.Error.Message}");
        }
        else if (e.Cancelled)
        {
            // Handle cancellation if needed
            Console.WriteLine("Background work was cancelled.");
        }
        else
        {
            // Handle successful completion
            Console.WriteLine("Background work completed successfully.");
        }
    }
}
