@echo off
setlocal EnableDelayedExpansion
mkdir files
echo Welcome to Crypt mode.
echo What do you want?
echo.
choice /c 12 /n /m "[1] Encrypt [2] Decript:"

if errorlevel 1 (
  echo.
  echo Select a method:
  choice /c 12 /n /m "[1] File [2] Standalone text:"

  if errorlevel 1 (
    echo.
    set /p "fileway=Put the file way: "

    cd files
    echo(!fileway!>wayFile.txt
    echo null > textFile.txt
  ) 
  if errorlevel 2 (
    echo.
    set /p "filetext=Put the text: "

    cd files
    echo null > wayFile.txt
    echo(!filetext!>textFile.txt
  )
)

cd Source/Model
csc ExecuteCryptography.cs
pause