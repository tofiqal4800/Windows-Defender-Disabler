using System;
using System.Management;
using System.Collections.Generic;

namespace DefenderRemover
{
    public class DefenderStatus
    {
        public bool RealTimeProtection { get; set; }
        public bool TamperProtection   { get; set; }
        public bool SmartScreen        { get; set; }
        public bool CloudProtection    { get; set; }
        public string LastUpdate       { get; set; }
    }

    public static class DefenderQuery
    {
        public static DefenderStatus GetStatus()
        {
            var status = new DefenderStatus();
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    @"root\Microsoft\Windows\Defender",
                    "SELECT * FROM MSFT_MpPreference");

                foreach (ManagementObject obj in searcher.Get())
                {
                    status.RealTimeProtection = !(bool)(obj["DisableRealtimeMonitoring"] ?? false);
                    status.CloudProtection    = !(bool)(obj["MAPSReporting"] as bool? == false);
                }
            }
            catch { }
            return status;
        }

        public static string GetLastUpdateTime()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    @"root\Microsoft\Windows\Defender",
                    "SELECT * FROM MSFT_MpComputerStatus");
                foreach (ManagementObject obj in searcher.Get())
                    return obj["AntivirusSignatureLastUpdated"]?.ToString() ?? "Unknown";
            }
            catch { }
            return "Unknown";
        }
    }
}