# ClearDownloadsFolderService

A windows service that helps managing your files by clearing every 5 days your Downloads folder from files older that 1 month.

# What I Learned

* Create windows services
* Work with filesystem
* Use app.config for configuration

Usage
-----

1. Change directory path pointing to the folder you want to apply the service. At app.config change line 8 - 12 with your path

2. Compile the solution using Visual Studio

3. Inside yourPath\ClearDownloadsFolderService\bin\Debug you will find a file called ClearDownloadsFolderService.exe

4. Start the service with the following cmd command

```bash
  ClearDownloadsFolderService.exe install start
```
5. Unistall the service with the following cmd command

```bash
 ClearDownloadsFolderService.exe  uninstall
```
