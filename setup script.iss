;汉化:MonKeyDu 
;由 Inno Setup 脚本向导 生成的脚本,有关创建 INNO SETUP 脚本文件的详细信息，请参阅文档！!

#define MyAppName "WallpaperShuffle"
#define MyAppVersion "2.0.0"
#define MyAppPublisher "OguriCap"
#define MyAppURL "https://gitee.com/qijiugit/wallpaper-shuffle"
#define MyAppExeName "WallpaperShuffle.exe"
#define MyAppAssocName MyAppName + " 文件"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
;注意:AppId 的值唯一标识此应用程序。请勿在安装程序中对其他应用程序使用相同的 AppId 值。
;（若要生成新的 GUID，请单击“工具”|”在 IDE 中生成 GUID）。
AppId={{CFCE2EA4-637B-49E5-A016-A25215C7BC93}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
LicenseFile=D:\Quick access\Desktop\code\.net\WallpaperShuffle\LICENSE
;取消下行前面 ; 符号，在非管理安装模式下运行（仅为当前用户安装）.
;PrivilegesRequired=lowest
OutputDir=D:\Quick access\Desktop\setup
OutputBaseFilename=WallpaperShuffle-setup-v2.0.0
SetupIconFile=D:\Quick access\Desktop\code\.net\WallpaperShuffle\icon\logo.ico
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "chs"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkablealone

[Files]
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\Microsoft.Extensions.Logging.Abstractions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\Microsoft.Win32.TaskScheduler.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\Quartz.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\System.Buffers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\System.Diagnostics.DiagnosticSource.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\System.Memory.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\UsageGuide.md"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\WallpaperShuffle.application"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\WallpaperShuffle.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Quick access\Desktop\code\.net\WallpaperShuffle\publish\Application Files\WallpaperShuffle_2_0_0_1\WallpaperShuffle.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion

[code]
procedure InitializeWizard();
begin
WizardForm.LICENSEACCEPTEDRADIO.checked:= true;
end;

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

