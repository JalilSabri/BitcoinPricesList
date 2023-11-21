using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTeknoloji.Infrastructure.Utilities;

public class GTHelper

{
    public static Microsoft.Extensions.Logging.ILogger Logger { get; set; } // Jalil

    public GTHelper()
    {

    }

    public GTHelper(Exception ex)
    {

    }

    public GTHelper SendMessage(string message)
    {
        //Send Message to Development Team
        return this;
    }

    public GTHelper DoLog(string message)
    {
        try
        {
            Logger.LogWarning(message);//: jalil
        }
        catch (Exception ex)
        {
            SendMessage(ex.Message);
            throw;
        }

        return this;
    }
}
