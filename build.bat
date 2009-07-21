@echo off
cls
thirdparty\tools\nant\nant.exe -nologo -buildfile:build\project.build %*
@echo %time%
