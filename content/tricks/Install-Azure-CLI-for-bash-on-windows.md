---
layout: post
---

#  Installing Azure CLI for bash on Windows 

##  Introduction

This short guide explains how you get the Azure CLI to show up properly with the Bash shell in Windows.


## Checking if you have Azure CLI installed

You might have the Azure CLI installed even if it doesn't show up in your bash shell.  Check first using either Cmd or Powershell, by running e.g. 

```
az --version
```

You can run this from the bash shell, but using the full name of the cmd file:

```
az.cmd --version
```
![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-25_17-55-16.jpg)



If you have Git installed you will have bash installed as part of that.  If you don't have a Linux subsystem, you can use that bash shell, but some Linux commands will not be present.  For most use the Git Bash shell will be sufficient.

The following guide assumes you have this situation.  If you have a Linux subsystem installed, jump further down for links to other instructions.

## Installing Azure CLI

Azure CLI is a Python program, so you can install it as that using pip (if you're familiar with Python), or you can install it from Chocolatey, or as most do, install it using the MSI.

Download and run the [MSI Installer](https://aka.ms/installazurecliwindows) from [this place.](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest)

The full installation instructions can be found [here](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)

## Setup Azure CLI for bash from Git for Windows install without Linux subsystem

1. If not installed, install [the MSI](https://aka.ms/installazurecliwindows)
2. Check where it is installed by using the command :

```cmd
where az.cmd
```

The response should be something like:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-25_11-05-35.jpg)


3. Create an alias for use with git bash

Go to your %userprofile% directory

Edit the file .bashrc to include

```bash
alias az='az.cmd'
```
Note 1:   No spaces between the alias and the command!

Note 2:   Sometimes you need to use ', and sometimes " works.  If it fails, try the other. 

Note 3:   This command will run from a command line, but it will not consume parameters from a script.

If all you want to do is to run some Azure CLI commands, this should be sufficient. 

4. Azure CLI for batch use

If you want to use the Azure CLI from scripts, you can add a small script for that.  My script is named 'azb', but you could also just override the 'az' itself.  Place the file (without any extension) somewhere which can be reached through the defined Path.  You could place it in the same folder as the az.cmd itself, which you find using the Where command as described above.
The file should look like:

```
#!/bin/bash
"C:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\wbin\az.cmd" $1 $2 $3 $4 $5 $6 $7 $8 $9 ${10} ${11} ${12} ${13} ${14} ${15}
```

Given the path I have on my computer.  Change if you have another one shown in #2 above.  

This last trick is due to [these StackOverflow answers](https://stackoverflow.com/questions/42972086/azure-cli-in-git-bash). 

## Setup Azure CLI for bash with Linux subsystem

There is a very good instruction for how to enable the azure CLI on bash when you have a full Linux subsystem, or is on a Linux machine.  Follow [these guidelines.](https://www.michaelcrump.net/azure-cli-with-win10-bash/)

