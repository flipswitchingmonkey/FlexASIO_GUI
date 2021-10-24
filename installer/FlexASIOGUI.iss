#define MyAppName "FlexASIO GUI"
#define MyAppVersion "0.31"
#define MyAppPublisher "https://github.com/flipswitchingmonkey/FlexASIO_GUI"
#define MyAppURL ""
#define MyAppExeName "FlexASIOGUI.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{85A2342E-43B3-4527-A533-6F250F1E5765}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={commonpf64}\FlexASIOGUI
DisableProgramGroupPage=yes
;OutputDir=
OutputBaseFilename={#MyAppName}Installer_{#MyAppVersion}
SetupIconFile=flexasiogui.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
;Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\bin\x64\Release\netcoreapp3.1\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
;Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Registry]
Root: HKLM64; Subkey: "Software\Fabrikat"; Flags: uninsdeletekeyifempty
Root: HKLM64; Subkey: "Software\Fabrikat\FlexASIOGUI"; Flags: uninsdeletekey
Root: HKLM64; Subkey: "Software\Fabrikat\FlexASIOGUI\Install"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"