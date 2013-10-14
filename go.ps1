param([string]$target)

function ExitWithCode([string]$exitCode)
{
	$host.SetShouldExit($exitcode)
	exit 
}

Try 
{
	Set-ExecutionPolicy RemoteSigned
	Import-Module .\psake.psm1
	Invoke-Psake -framework 4.0 .\build.ps1 $target
	ExitWithCode($LastExitCode)
}
Catch 
{
	Write-Error $_
	Write-Host "GO.PS1 EXITS WITH ERROR"
	ExitWithCode 9
}
