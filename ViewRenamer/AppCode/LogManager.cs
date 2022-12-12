﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Carfup.XTBPlugins.AppCode
{
    public class LogUsageManager
    {

        private TelemetryClient telemetry = null;
        private bool forceLog { get; set; } = false;

        private ViewRenamer.ViewRenamer vr = null;
        public LogUsageManager(ViewRenamer.ViewRenamer vr)
        {
            this.vr = vr;

            TelemetryConfiguration.Active.InstrumentationKey = CustomParameter.INSIGHTS_INTRUMENTATIONKEY;
            this.telemetry = new TelemetryClient();
            this.telemetry.Context.Component.Version = ViewRenamer.ViewRenamer.CurrentVersion;
            this.telemetry.Context.Device.Id = this.vr.GetType().Name;
            this.telemetry.Context.User.Id = Guid.NewGuid().ToString();
        }

        public void UpdateForceLog()
        {
            forceLog = true;
        }

        public void LogData(string type, string action, Exception exception = null)
        {
            if (vr.settings.AllowLogUsage == true || forceLog)
            {
                switch (type)
                {
                    case EventType.Event:
                        telemetry.TrackEvent(action, CompleteLog(action));
                        break;
                    case EventType.Dependency:
                        //this.telemetry.TrackDependency(todo);
                        break;
                    case EventType.Exception:
                        telemetry.TrackException(exception, CompleteLog(action));
                        break;
                    case EventType.Trace:
                        telemetry.TrackTrace(action, CompleteLog(action));
                        break;
                }
            }

            if (forceLog)
                forceLog = false;
        }

        public void Flush()
        {
            telemetry.Flush();
        }


        public Dictionary<string, string> CompleteLog(string action = null)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "plugin", telemetry.Context.Device.Id },
                { "xtbversion", Assembly.GetEntryAssembly().GetName().Version.ToString() },
                { "pluginversion", ViewRenamer.ViewRenamer.CurrentVersion }
            };

            if (action != null)
                dictionary.Add("action", action);

            return dictionary;
        }

        internal void PromptToLog()
        {
            var msg = "Anonymous statistics will be collected to improve plugin functionalities.\n\n" +
                      "You can change this setting in plugin's options anytime.\n\n" +
                      "Thanks!";

            
            MessageBoxResult box = MessageBox.Show(msg, "Anonymous statistics", MessageBoxButton.YesNo);
            vr.settings.AllowLogUsage = box == MessageBoxResult.Yes;
        }
    }
}
