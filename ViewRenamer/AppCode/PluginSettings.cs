﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carfup.XTBPlugins.AppCode
{
    public class PluginSettings
    {
        public bool? AllowLogUsage { get; set; }
        public string CurrentVersion { get; set; } = ViewRenamer.ViewRenamer.CurrentVersion;
        public SortOrder? SortOrderPref { get; set; } = SortOrder.Ascending;
    }

    // EventType to qualify which type of telemetry we send
    static class EventType
    {
        public const string Event = "event";
        public const string Trace = "trace";
        public const string Dependency = "dependency";
        public const string Exception = "exception";
    }

    public static class CustomParameter
    {
        public static string INSIGHTS_INTRUMENTATIONKEY = $"InstrumentationKey=INSIGHTS_INTRUMENTATIONKEY_TOREPLACE;IngestionEndpoint=https://westeurope-2.in.applicationinsights.azure.com/;LiveEndpoint=https://westeurope.livediagnostics.monitor.azure.com/";
    }

    static class UserDataType
    {
        public const string Views = "view";
        public const string Dashboards = "dashboard";
        public const string Charts = "chart";
        public const string ViewLogicalName = "userquery";
        public const string DashboardLogicalName = "userform";
        public const string ChartLogicalName = "userqueryvisualization";
    }

    public class UserInfo
    {
        public Guid? userId { get; set; }
        public string userEntity { get; set; }
    }

    // EventType to qualify which action was performed by the plugin
    static class LogAction
    {
        public const string PluginClosed = "PluginClosed";
        public const string StatsAccepted = "StatsAccepted";
        public const string StatsDenied = "StatsDenied";
        public const string SettingsSaved = "SettingsSaved";
        public const string SettingsSavedWhenClosing = "SettingsSavedWhenClosing";
        public const string SettingLoaded = "SettingLoaded";
        public const string PublishCustomizations = "PublishCustomizations";
        public const string SaveViews = "SaveViews";
        public const string LoadEntities = "LoadEntities";
        public const string LoadViewsForEntity = "LoadViewsForEntity";
        public const string UserDashboardsLoaded = "UserDashboardsLoaded";
        public const string ViewsCopied = "ViewsCopied";
        public const string ViewsDeleted = "ViewsDeleted";
        public const string ViewsReAssigned = "ViewsReAssigned";
        public const string ChartsCopied = "ChartsCopied";
        public const string ChartsDeleted = "ChartsDeleted";
        public const string ChartsReAssigned = "ChartsReAssigned";
        public const string DashboardsCopied = "DashboardsCopied";
        public const string DashboardsDeleted = "DashboardsDeleted";
        public const string DashboardsReAssigned = "DashboardsReAssigned";
        public const string ShowHelpScreen = "ShowHelpScreen";
        public const string SharingsLoaded = "SharingsLoaded";
        public const string SharingsRevoked = "SharingsRevoked";
        public const string SharingsToListViewLoaded = "SharingsToListViewLoaded";
        public const string Personal2SystemView = "Personal2SystemView";
        public const string Personal2SystemDashboard = "Personal2SystemDashboard";
        public const string Personal2SystemChart = "Personal2SystemChart";
        public const string SharingsUpdated = "SharingsUpdated";
    }
}
