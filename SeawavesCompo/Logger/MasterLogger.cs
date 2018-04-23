using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SeawavesCompo.Logger
{
    public enum LogSeverity
    {
        ISSUE = 0,
        WARNING = 1,
        SECURITYWARNING = 2,
        EXCPETION = 3
    }

    public static class MasterLogger
    {
        
        public static void LogIssue(string message, string issueLocation, DateTime issueTime, LogSeverity severity)
        {
            //TODO: update this to use a config file path
            string path = "~/logs/issue_log" + DateTime.Now.ToString("dd-MM-yyyy") + ".log";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(issueTime.ToString("hh:mm:ss") + " [" + severity.ToString() + "] @" + issueLocation + " : " + message);
            }
        }
    }
}