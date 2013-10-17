#####                          #####
#                                  #
#    XConf Services Build File     #
#                                  #
#####                          #####


##########################
#      PROPERTIES
##########################

properties {
	$environment = GetEnvVariable GO_ENVIRONMENT ci
}

##########################
#        TASKS
##########################

Task default -depends compile


Task compile {
	exec { msbuild /p:configuration=$environment }
}

Task setupiis {
	CreateSite     xconf 90
	AddApplication xconf wcf-iis
	AddApplication xconf mvc-iis
	AddApplication xconf webapi-iis
}

##########################
#      FUNCTIONS
##########################

function GetEnvVariable([string]$variableName, [string]$defaultValue) {
	if(Test-Path env:$variableName) {
		return (Get-Item env:$variableName).Value
	}
	return $defaultValue
}

function CreateSite([string]$site, [int]$port) {
	$tempPath = "C:\Xconf"
	if (!(Test-Path "$tempPath")) {
		New-Item -ItemType directory -Path "$tempPath"
	} 
	& $Env:WinDir\system32\inetsrv\appcmd.exe add apppool /name:"$site" /managedRuntimeVersion:v4.0 /managedPipelineMode:Integrated
	& $Env:WinDir\system32\inetsrv\appcmd delete site "$site"
	& $Env:WinDir\system32\inetsrv\appcmd add site /name:"$site"   /bindings:http://*:$port /physicalpath:"$tempPath"
}

function AddApplication([string]$site, [string]$application) {
	& $Env:WinDir\system32\inetsrv\appcmd add app /site.name:"$site" /path:/$application /physicalPath:"$(get-location)\$application"
	& $Env:WinDir\system32\inetsrv\appcmd set app "$site/$application" /applicationpool:"$site"
}