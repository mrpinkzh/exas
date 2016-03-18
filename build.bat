@echo off
cls

call .\scripts\bootstrap-paket.bat

call .\scripts\fake-build.bat %*