using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using CodeWick.Models;

namespace CodeWick.Helpers {
    public class LogHelper : System.Web.UI.Page {
        public void LogException(Exception ex) {
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    LogException logException = new LogException();
                    logException.Source = ex.Source;
                    logException.StackTrace = ex.StackTrace;
                    logException.Message = ex.Message;
                    logException.ModuleName = ex.TargetSite.Module.Name;
                    logException.Exception = ex.ToString();
                    logException.Time = DateTime.Now;
                    context.LogExceptions.Add(logException);
                    context.SaveChanges();
                }
            } catch {
                LogToWindowsEventViewer(ex);
            }
        }

        public void LogMessage(string location, string message) {
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    LogMessage logMessage = new LogMessage();
                    logMessage.Location = location;
                    logMessage.Message = message;
                    logMessage.Time = DateTime.Now;
                    context.LogMessages.Add(logMessage);
                    context.SaveChanges();
                }
            } catch(Exception ex) { LogToWindowsEventViewer(ex); }
        }

        private void LogToWindowsEventViewer(Exception ex) {
            string logType = "Application";
            string log_location = "CodeWick";
            string log_descrition = ex.ToString() + " - " + ex.Message;
            EventLogEntryType entryType = EventLogEntryType.Error;
            try {
                if(!EventLog.SourceExists(log_location)) {
                    EventLog.CreateEventSource(log_location, logType);
                }

                EventLog eLog = new EventLog();
                eLog.Source = log_location;
                eLog.WriteEntry(log_descrition, entryType);
            } catch { }
        }
    }
}