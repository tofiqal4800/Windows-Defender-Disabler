using System;
using Microsoft.Win32;

namespace DefenderRemover
{
    public static class DefenderRegistry
    {
        private const string POLICY_KEY    = @"SOFTWARE\Policies\Microsoft\Windows Defender";
        private const string REALTIME_KEY  = @"SOFTWARE\Microsoft\Windows Defender\Real-Time Protection";

        public static bool DisableRealTimeProtection()
        {
            try {
                using var key = Registry.LocalMachine.CreateSubKey(REALTIME_KEY, true);
                key.SetValue("DisableRealtimeMonitoring", 1, RegistryValueKind.DWord);
                return true;
            } catch { return false; }
        }

        public static bool EnableRealTimeProtection()
        {
            try {
                using var key = Registry.LocalMachine.OpenSubKey(REALTIME_KEY, true);
                key?.DeleteValue("DisableRealtimeMonitoring", false);
                return true;
            } catch { return false; }
        }

        public static bool DisableViaPolicy()
        {
            try {
                using var key = Registry.LocalMachine.CreateSubKey(POLICY_KEY, true);
                key.SetValue("DisableAntiSpyware", 1, RegistryValueKind.DWord);
                return true;
            } catch { return false; }
        }

        public static bool EnableViaPolicy()
        {
            try {
                using var key = Registry.LocalMachine.OpenSubKey(POLICY_KEY, true);
                key?.DeleteValue("DisableAntiSpyware", false);
                return true;
            } catch { return false; }
        }

        public static bool IsRealTimeEnabled()
        {
            try {
                using var key = Registry.LocalMachine.OpenSubKey(REALTIME_KEY);
                var val = key?.GetValue("DisableRealtimeMonitoring");
                return val == null || (int)val == 0;
            } catch { return true; }
        }
    }
}