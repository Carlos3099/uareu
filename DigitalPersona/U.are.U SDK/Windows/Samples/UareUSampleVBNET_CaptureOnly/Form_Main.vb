Imports System.Threading
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports DPUruNet
Imports DPUruNet.Constants

Public Class Form_Main
    ''' <summary>
    ''' Holds fmds enrolled by the enrollment GUI.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Fmds() As Dictionary(Of Int16, Fmd)
        Get
            Return _fmds
        End Get
        Set(ByVal value As Dictionary(Of Int16, Fmd))
            _fmds = value
        End Set
    End Property
    Private _fmds As Dictionary(Of Int16, Fmd) = New Dictionary(Of Int16, Fmd)

    ''' <summary>
    ''' Reset the UI causing the user to reselect a reader.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Reset() As Boolean
        Get
            Return _reset
        End Get
        Set(ByVal value As Boolean)
            _reset = value
        End Set
    End Property
    Private _reset As Boolean

    Private Sub Form_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    ' When set by child forms, shows s/n and enables buttons.
    Public Property CurrentReader() As Reader
        Get
            Return _currentReader
        End Get
        Set(ByVal value As Reader)
            _currentReader = value
            SendMessage(Action.UpdateReaderState, value)
        End Set
    End Property
    Private _currentReader As Reader

#Region "Click Event Handler"
    Private _readerSelect As ReaderSelect
    Private Sub btnReaderSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReaderSelect.Click
        If _readerSelect Is Nothing Then
            _readerSelect = New ReaderSelect
            _readerSelect.Sender = Me
        End If

        _readerSelect.ShowDialog()

        _readerSelect.Dispose()
        _readerSelect = Nothing
    End Sub
    Private _capture As Capture
    Private Sub btnCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapture.Click
        If _capture Is Nothing Then
            _capture = New Capture
            _capture._sender = Me
        End If

        _capture.ShowDialog()

        _capture.Dispose()
        _capture = Nothing
    End Sub
#End Region

    ''' <summary>
    ''' Open a device and check result for errors.
    ''' </summary>
    ''' <returns>Returns true if successful; false if unsuccessful</returns>
    Public Function OpenReader() As Boolean
        Dim result As Constants.ResultCode = Constants.ResultCode.DP_DEVICE_FAILURE

        _reset = False
        result = _currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)

        If result <> Constants.ResultCode.DP_SUCCESS Then
            MessageBox.Show("Error:  " & result.ToString())
            _reset = True
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Hookup capture handler and start capture.
    ''' </summary>
    ''' <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
    ''' <returns>Returns true if successful; false if unsuccessful</returns>
    Public Function StartCaptureAsync(ByVal OnCaptured As Reader.CaptureCallback) As Boolean
        AddHandler _currentReader.On_Captured, OnCaptured

        If Not CaptureFingerAsync() Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Cancel the capture and then close the reader.
    ''' </summary>
    ''' <param name="OnCaptured">Delegate to unhook as handler of the On_Captured event </param>
    Public Sub CancelCaptureAndCloseReader(ByVal OnCaptured As Reader.CaptureCallback)
        If _currentReader IsNot Nothing Then
            CurrentReader.CancelCapture()

            ' Dispose of reader handle and unhook reader events.
            CurrentReader.Dispose()

            If _reset Then
                CurrentReader = Nothing
            End If
        End If

    End Sub

    ''' <summary>
    ''' Check the device status before starting capture.
    ''' </summary>
    ''' <returns></returns>
    Public Sub GetStatus()
        Dim result = _currentReader.GetStatus()

        If (result <> ResultCode.DP_SUCCESS) Then
            If CurrentReader IsNot Nothing Then
                _reset = True
                Throw New Exception("" & result.ToString())
            End If
        End If

        If (_currentReader.Status.Status = ReaderStatuses.DP_STATUS_BUSY) Then
            Thread.Sleep(50)
        ElseIf (_currentReader.Status.Status = ReaderStatuses.DP_STATUS_NEED_CALIBRATION) Then
            _currentReader.Calibrate()
        ElseIf (_currentReader.Status.Status <> ReaderStatuses.DP_STATUS_READY) Then
            Throw New Exception("Reader Status - " & CurrentReader.Status.Status.ToString())
        End If
    End Sub

    ''' <summary>
    ''' Check quality of the resulting capture.
    ''' </summary>
    Public Function CheckCaptureResult(ByVal captureResult As CaptureResult) As Boolean
        If captureResult.Data Is Nothing Or captureResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
            If captureResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                _reset = True
                Throw New Exception("" & captureResult.ResultCode.ToString())
            End If

            If captureResult.Quality <> Constants.CaptureQuality.DP_QUALITY_CANCELED Then
                Throw New Exception("Quality - " + captureResult.Quality.ToString())
            End If
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Function to capture a finger. Always get status first and calibrate or wait if necessary.  Always check status and capture errors.
    ''' </summary>
    ''' <param name="fid"></param>
    ''' <returns></returns>
    Public Function CaptureFingerAsync() As Boolean
        Try
            GetStatus()

            Dim captureResult = _currentReader.CaptureAsync(Formats.Fid.ANSI, _
                                                   CaptureProcessing.DP_IMG_PROC_DEFAULT, _
                                                    _currentReader.Capabilities.Resolutions(0))

            If captureResult <> ResultCode.DP_SUCCESS Then
                _reset = True
                Throw New Exception("" + captureResult.ToString())
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show("Error:  " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Create a bitmap from raw data in row/column format.
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateBitmap(ByVal bytes As [Byte](), ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim rgbBytes As Byte() = New Byte(bytes.Length * 3 - 1) {}

        For i As Integer = 0 To bytes.Length - 1
            rgbBytes((i * 3)) = bytes(i)
            rgbBytes((i * 3) + 1) = bytes(i)
            rgbBytes((i * 3) + 2) = bytes(i)
        Next
        Dim bmp As New Bitmap(width, height, PixelFormat.Format24bppRgb)

        Dim data As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.[WriteOnly], PixelFormat.Format24bppRgb)

        For i As Integer = 0 To bmp.Height - 1
            Dim p As New IntPtr(data.Scan0.ToInt64() + data.Stride * i)
            System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3)
        Next

        bmp.UnlockBits(data)

        Return bmp
    End Function

#Region "SendMessage"
    Private Enum Action
        UpdateReaderState
    End Enum
    Private Delegate Sub SendMessageCallback(ByVal state As Action, ByVal payload As Object)
    Private Sub SendMessage(ByVal state As Action, ByVal payload As Object)
        On Error Resume Next

        If Me.txtReaderSelected.InvokeRequired Then
            Dim d As New SendMessageCallback(AddressOf SendMessage)
            Me.Invoke(d, New Object() {state, payload})
        Else

            Select Case state
                Case Action.UpdateReaderState
                    Dim _reader As Reader = (DirectCast(payload, Reader))
                    If (_reader IsNot Nothing) Then
                        txtReaderSelected.Text = _reader.Description.Name
                        btnCapture.Enabled = True
                    ElseIf (_reader Is Nothing) Then
                        txtReaderSelected.Text = String.Empty
                        btnCapture.Enabled = False
                    End If
            End Select

        End If
    End Sub
#End Region
End Class


