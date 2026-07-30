using System;
using System.Management;
using System.ServiceProcess;
using System.IO;

namespace DefenderRemover.Logic
{
    /// <summary>
    /// Service-level Defender control.
    /// Covers: disable windows defender windows 11 permanently — full disable.
    /// </summary>
    public static class DefenderService
    {
        private static readonly string[] SERVICES = { "WinDefend", "Sense", "WdNisSvc", "WdNisDrv", "mpssvc" };

        public static void StopAll()
        {
            foreach (var name in SERVICES) {
                try {
                    var svc = new ServiceController(name);
                    if (svc.Status == ServiceControllerStatus.Running) {
                        svc.Stop();
                        svc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    }
                } catch { }
            }
        }

        public static bool CreateRestorePoint(string description)
        {
            try {
                using var wmi = new ManagementClass(@"\\.\root\default", "SystemRestore", null);
                var p = wmi.GetMethodParameters("CreateRestorePoint");
                p["Description"]    = description;
                p["RestorePointType"] = 12;
                p["EventType"]       = 100;
                wmi.InvokeMethod("CreateRestorePoint", p, null);
                return true;
            } catch { return false; }
        }
    }
}