@echo off

set Environment=%GO_ENVIRONMENT%
if "%Environment%" == "" set Environment=CI

powershell -ExecutionPolicy RemoteSigned -command "%~dp0go.ps1" %*
echo WILL EXIT WITH RCODE %ERRORLEVEL%
exit /b %ERRORLEVEL%