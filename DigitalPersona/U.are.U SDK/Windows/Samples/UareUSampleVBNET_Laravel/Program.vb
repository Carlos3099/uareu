Imports System.Windows.Forms

Public Module Program
    Sub Main()
#If Not WindowsCE Then
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
#End If
        Application.Run(New Form_Main())
    End Sub
End Module