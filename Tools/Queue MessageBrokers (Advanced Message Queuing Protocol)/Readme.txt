 1. Download Docket Desktop - https://docs.docker.com/desktop/setup/install/windows-install/
 2. Fix issues with WSL (Windows Subsystem for Linux)
	- (Enable Virtual Machine feature) Before installing WSL 2, you must enable the "Virtual Machine Platform" optional feature. Open PowerShell as Administrator and run:
		"dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart"
	- (Download the Linux kernel update package) Open PowerShell as Administrator and run this command
		"wsl --update"
	- (Set WSL 2 as your default version) Open PowerShell as Administrator and run this command to set WSL 2 as the default version when installing a new Linux distribution:
		"wsl --set-default-version 2"
	- Turn on Windows Features
	  ".Net Framework 3.5"
	  "Hyper-V"
	  "Virtual Machine Platform"
	  "Windows Subsystem for Linux"