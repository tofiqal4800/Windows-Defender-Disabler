using System;
using System.Management;

namespace DefenderRemover.Logic
{
    /// <summary>
    /// WMI-based Defender status and tamper protection management.
    /// Covers: disable tamper protection windows 11 powershell equivalent.
    /// </summary>
    public static class DefenderQuery
    {
        public static bool IsRealTimeEnabled()
        {
            try {
                using var s = new ManagementObjectSearcher(@"root\Microsoft\Windows\Defender", "SELECT DisableRealtimeMonitoring FROM MSFT_MpPreference");
                foreach (ManagementObject o in s.Get())
                    return !(bool)(o["DisableRealtimeMonitoring"] ?? false);
            } catch { }
            return true;
        }

        public static string GetLastDefinitionUpdate()
        {
            try {
                using var s = new ManagementObjectSearcher(@"root\Microsoft\Windows\Defender", "SELECT AntivirusSignatureLastUpdated FROM MSFT_MpComputerStatus");
                foreach (ManagementObject o in s.Get())
                    return o["AntivirusSignatureLastUpdated"]?.ToString() ?? "Unknown";
            } catch { }
            return "Unknown";
        }

        public static void DisableTamperProtection()
        {
            // Sets registry preference for when tamper protection is turned off via Security Center
            try {
                using var k = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(
                    @"SOFTWARE\Microsoft\Windows Defender\Features", true);
                k.SetValue("TamperProtection", 4, Microsoft.Win32.RegistryValueKind.DWord);
            } catch { }
        }
    }
}