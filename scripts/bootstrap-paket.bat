@echo off

.paket\paket.exe restore
if errorlevel 1 (
	exit \b %errorlevel%
)