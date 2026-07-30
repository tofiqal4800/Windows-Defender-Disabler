using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace DefenderRemover
{
    public static class DefenderService
    {
        private static readonly string[] DEFENDER_SERVICES = {
            "WinDefend", "Sense", "WdNisSvc", "WdNisDrv", "mpssvc"
        };

        public static void StopAll()
        {
            foreach (var name in DEFENDER_SERVICES)
            {
                try
                {
                    var svc = new ServiceController(name);
                    if (svc.Status == ServiceControllerStatus.Running)
                    {
                        svc.Stop();
                        svc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    }
                }
                catch { }
            }
        }

        public static void DisableTamperProtection()
        {
            try {
                using var key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(
                    @"SOFTWARE\Microsoft\Windows Defender\Features", true);
                key.SetValue("TamperProtection", 4, Microsoft.Win32.RegistryValueKind.DWord);
            } catch { }
        }

        public static bool CreateRestorePoint(string description)
        {
            try {
                using var wmi = new System.Management.ManagementClass(
                    @"\\.\root\default", "SystemRestore", null);
                var inParams = wmi.GetMethodParameters("CreateRestorePoint");
                inParams["Description"]  = description;
                inParams["RestorePointType"] = 12;
                inParams["EventType"]    = 100;
                wmi.InvokeMethod("CreateRestorePoint", inParams, null);
                return true;
            } catch { return false; }
        }
    }
}