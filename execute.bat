@echo off

:START
cls

setlocal EnableDelayedExpansion
mkdir files
mkdir crypted
echo Welcome to Crypt mode.
echo What do you want?
echo.
choice /c 12 /n /m "[1] Encrypt [2] Decript:"

if errorlevel 2 (
  cd files
  echo RunModeTwo > mode.txt
  echo.

  echo.
  set /p "fileway=Put the local file: "

  echo(!fileway! > wayFile.txt
  echo nullArId277068 > textFile.txt
) else if errorlevel 1 (
  cd files
  echo RunModeOne > mode.txt
  echo.
  echo Select a method:
  choice /c 12 /n /m "[1] File [2] Standalone text:"

  if errorlevel 2 (
    echo.
    set /p "filetext=Put the text: "

    echo nullArId277068 > wayFile.txt
    echo(!filetext!>textFile.txt
  ) else if errorlevel 1 (
    echo.
    set /p "fileway=Put the file way: "

    echo(!fileway!>wayFile.txt
    echo nullArId277068 > textFile.txt
  )
)

set /p "key=Put your password: "
echo(!key!>key.txt

cd ..
dotnet run

choice /c YN /n /m "Do you wanna execute again? [Y] yes or [N] no: "

if errorlevel 2 exit
if errorlevel 1 goto START