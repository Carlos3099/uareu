@echo off
rem Java sample

set LIB_OUT_DIR=%1
set JAR_NAME=%2

set CLASS_OUT_DIR=classes

if "%LIB_OUT_DIR%" == "" set LIB_OUT_DIR=..\..\lib\java

rem check java
set JAVA_BIN=%JAVA_HOME%\bin

if exist "%JAVA_BIN%\javac.exe" goto javac_ok
echo "Cannot find 'javac'. check your JAVA_HOME"
exit /B 1

:javac_ok

mkdir %CLASS_OUT_DIR%

set JAVAC=%JAVA_BIN%\javac.exe
set JAR=%JAVA_BIN%\jar.exe

if exist "%LIB_OUT_DIR%\jpos113.jar" (
set DP_JAVAPOS_SAMPLE_DIR=.
set DP_JAVAPOS_SERVICE_DIR=%LIB_OUT_DIR%\dpjavapos.jar
set DP_JAVAPOS_BIN_DIR=%LIB_OUT_DIR%
set CLASS_OUT_DIR=classes
if "%JAR_NAME%" == "" set JAR_NAME=..\Bin\JavaPOS\dpjavapos_app.jar
)

if not exist "%LIB_OUT_DIR%\jpos113.jar" (
set DP_JAVAPOS_SAMPLE_DIR=..\..\..\Source\Java\JavaPos\sample
set DP_JAVAPOS_SERVICE_DIR=..\..\..\Source\Java\JavaPos\service
set DP_JAVAPOS_BIN_DIR=..\..\..\Source\Java\JavaPos\third-party
if "%JAR_NAME%" == "" set JAR_NAME=dpjavapos_app.jar
)

set JAVA_POS_CONFIG_PATH=%DP_JAVAPOS_SAMPLE_DIR%\config

set CP="%DP_JAVAPOS_SAMPLE_DIR%";"%JAVA_POS_CONFIG_PATH%";"%LIB_OUT_DIR%\dpuareu.jar";"%LIB_OUT_DIR%\dpjavapos.jar";"%DP_JAVAPOS_BIN_DIR%\jpos113.jar";"%DP_JAVAPOS_BIN_DIR%\xercesImpl-2.6.2.jar";"%DP_JAVAPOS_BIN_DIR%\xmlParserAPIs.jar"


if exist "%LIB_OUT_DIR%\jpos113.jar" (
"%JAVAC%" -nowarn -d %CLASS_OUT_DIR% -cp %CP%  %DP_JAVAPOS_SAMPLE_DIR%\src\com\digitalpersona\javapos\sampleapp\biometrics\*.java 
)

if not exist "%LIB_OUT_DIR%\jpos113.jar" (
"%JAVAC%" -nowarn -d %CLASS_OUT_DIR% -cp %CP%  %DP_JAVAPOS_SAMPLE_DIR%\src\com\digitalpersona\javapos\sampleapp\biometrics\*.java %DP_JAVAPOS_SERVICE_DIR%\src\com\digitalpersona\javapos\utils\*.java
)

"%JAR%" -cvf %JAR_NAME% -C %CLASS_OUT_DIR% .\

pause