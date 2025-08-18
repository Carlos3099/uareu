@echo off

set JAVA="%JAVA_HOME%\bin\java.exe"

set CP="..\..\UareUSampleJavaPOS\config";"..\..\..\Lib\Java\dpuareu.jar";"dpjavapos_app.jar";"..\..\..\Lib\Java\dpjavapos.jar";"..\..\..\Lib\Java\jpos113.jar";"..\..\..\Lib\Java\xercesImpl-2.6.2.jar";"..\..\..\Lib\Java\xmlParserAPIs.jar" 

%JAVA% -cp %CP% com.digitalpersona.javapos.sampleapp.biometrics.SampleApp %1 %2 %3 %4 %5 %6 %7 %8 %9