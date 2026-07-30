using System;
using Microsoft.Win32;

namespace DefenderRemover.Logic
{
    /// <summary>
    /// Handles registry-based Windows Defender disable.
    /// Covers: disable windows defender windows 11 regedit approach.
    /// </summary>
    public static class DefenderRegistry
    {
        private const string POLICY_KEY   = @"SOFTWARE\Policies\Microsoft\Windows Defender";
        private const string REALTIME_KEY = @"SOFTWARE\Microsoft\Windows Defender\Real-Time Protection";
        private const string SAC_KEY      = @"SYSTEM\CurrentControlSet\Control\CI\Policy";

        public static bool DisableRealTime()
        {
            try {
                using var k = Registry.LocalMachine.CreateSubKey(REALTIME_KEY, true);
                k.SetValue("DisableRealtimeMonitoring", 1, RegistryValueKind.DWord);
                return true;
            } catch { return false; }
        }

        public static bool EnableRealTime()
        {
            try {
                using var k = Registry.LocalMachine.OpenSubKey(REALTIME_KEY, true);
                k?.DeleteValue("DisableRealtimeMonitoring", false);
                return true;
            } catch { return false; }
        }

        /// <summary>
        /// Disable Windows Defender Windows 11 permanently via policy key.
        /// Used by: disable windows defender windows 11 permanently tool.
        /// </summary>
        public static bool DisableViaPolicy()
        {
            try {
                using var k = Registry.LocalMachine.CreateSubKey(POLICY_KEY, true);
                k.SetValue("DisableAntiSpyware", 1, RegistryValueKind.DWord);
                return true;
            } catch { return false; }
        }

        public static bool EnableViaPolicy()
        {
            try {
                using var k = Registry.LocalMachine.OpenSubKey(POLICY_KEY, true);
                k?.DeleteValue("DisableAntiSpyware", false);
                return true;
            } catch { return false; }
        }

        public static bool IsRealTimeEnabled()
        {
            try {
                using var k = Registry.LocalMachine.OpenSubKey(REALTIME_KEY);
                var v = k?.GetValue("DisableRealtimeMonitoring");
                return v == null || (int)v == 0;
            } catch { return true; }
        }
    }
}