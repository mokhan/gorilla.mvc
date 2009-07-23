@echo off
cls
third.party\tools\nant\nant.exe -nologo -buildfile:build\project.build %*
@echo %time%
