Imports DPUruNet

Public Class Capabilities

    Private _sender As ReaderSelect
    Public Property Sender() As ReaderSelect
        Get
            Return _sender
        End Get
        Set(ByVal value As ReaderSelect)
            _sender = value
        End Set
    End Property

    ''' <summary>
    ''' Open a device in cooperative mode.  Display capabilities of the reader.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Capabilities_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Clear capabilities display.
        lstCaps.BeginUpdate()
        lstCaps.Items.Clear()
        lstCaps.EndUpdate()

        Dim result As Constants.ResultCode = Constants.ResultCode.DP_DEVICE_FAILURE

        result = _sender.CurrentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)

        If result <> Constants.ResultCode.DP_SUCCESS Then
            MessageBox.Show("Error:  " & result.ToString())
            If _sender.CurrentReader IsNot Nothing Then
                _sender.CurrentReader.Dispose()
                _sender.CurrentReader = Nothing
            End If
            Return
        End If

        ' Update display.

        txtName.Text = _sender.CurrentReader.Description.Name
        txtReaderSelected.Text = _sender.CurrentReader.Description.Name

        lstCaps.BeginUpdate()

        lstCaps.Items.Add("Can Capture:  " + _sender.CurrentReader.Capabilities.CanCapture.ToString())
        lstCaps.Items.Add("Can Stream:  " + _sender.CurrentReader.Capabilities.CanStream.ToString())
        lstCaps.Items.Add("Extract Features:  " + _sender.CurrentReader.Capabilities.ExtractFeatures.ToString())
        lstCaps.Items.Add("Can Match:  " + _sender.CurrentReader.Capabilities.CanMatch.ToString())
        lstCaps.Items.Add("Can Identify:  " + _sender.CurrentReader.Capabilities.CanIdentify.ToString())
        lstCaps.Items.Add("Has Fingerprint Storage:  " + _sender.CurrentReader.Capabilities.HasFingerprintStorage.ToString())
        lstCaps.Items.Add("Has Power Management:  " + _sender.CurrentReader.Capabilities.HasPowerManagement.ToString())
        lstCaps.Items.Add("PIV Compliant:  " + _sender.CurrentReader.Capabilities.PIVCompliant.ToString())
        lstCaps.Items.Add("Indicator Type:  0x" + _sender.CurrentReader.Capabilities.IndicatorType.ToString("X"))

        For Each resolution As Integer In _sender.CurrentReader.Capabilities.Resolutions
            If Not resolution = 0 Then
                lstCaps.Items.Add("Resolution:  " + resolution.ToString())
            End If
        Next

        lstCaps.EndUpdate()

        _sender.CurrentReader.Dispose()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Me.Close()
    End Sub
End Class