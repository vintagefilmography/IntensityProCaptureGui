Imports DirectX.Capture

Public Class CW
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        Dim Tamano As Size = CaptureInformation.CaptureInfo.FrameSize
        Dim Rate As Integer = CaptureInformation.CaptureInfo.FrameRate * 1000
        Dim list As ListBox
        Dim i As Integer
        Dim fAux As Filter
        Dim p As PropertyPage

        'Add available capture sizes
        Me.cmbTam.Items.Clear()
        Me.cmbTam.Items.Add("160x120")
        Me.cmbTam.Items.Add("176x144")
        Me.cmbTam.Items.Add("320x240")
        Me.cmbTam.Items.Add("352x288")
        Me.cmbTam.Items.Add("640x480")
        If (Tamano.Equals(New Size(160, 120))) Then
            Me.cmbTam.Text = "160x120"
        End If
        If (Tamano.Equals(New Size(176, 144))) Then
            Me.cmbTam.Text = "176x144"
        End If
        If (Tamano.Equals(New Size(320, 240))) Then
            Me.cmbTam.Text = "320x240"
        End If
        If (Tamano.Equals(New Size(352, 288))) Then
            Me.cmbTam.Text = "352x288"
        End If
        If (Tamano.Equals(New Size(640, 480))) Then
            Me.cmbTam.Text = "640x480"
        End If

        'Add available capture frames per second
        Me.cmbFPS.Items.Clear()
        Me.cmbFPS.Items.Add("5 fps")
        Me.cmbFPS.Items.Add("10 fps")
        Me.cmbFPS.Items.Add("15 fps")
        Me.cmbFPS.Items.Add("20 fps")
        Me.cmbFPS.Items.Add("25 fps (PAL)")
        Me.cmbFPS.Items.Add("30 fps")
        Me.cmbFPS.Items.Add("60 fps")
        If (Rate = 5000) Then
            Me.cmbFPS.Text = "5 fps"
        End If
        If (Rate = 10000) Then
            Me.cmbFPS.Text = "10 fps"
        End If
        If (Rate = 15000) Then
            Me.cmbFPS.Text = "15 fps"
        End If
        If (Rate = 20000) Then
            Me.cmbFPS.Text = "20 fps"
        End If
        If (Rate = 25000) Then
            Me.cmbFPS.Text = "25 fps (PAL)"
        End If
        If (Rate = 30000) Then
            Me.cmbFPS.Text = "30 fps"
        End If
        If (Rate = 60000) Then
            Me.cmbFPS.Text = "60 fps"
        End If

        'Add the possible compressors to use in capturing
        Me.cmbCompress.Items.Clear()
        Me.cmbCompress.Items.Add("Without Compressor")
        If (CaptureInformation.CaptureInfo.VideoCompressor Is Nothing) Then
            Me.cmbCompress.Text = "Without Compressor"
        End If
        For i = 0 To Dispositivos.VideoCompressors.Count - 1
            fAux = Dispositivos.VideoCompressors(i)
            Me.cmbCompress.Items.Add(fAux.Name)
            If (CaptureInformation.CaptureInfo.VideoCompressor Is fAux) Then
                Me.cmbCompress.Text = fAux.Name
            End If
        Next

        'Driver Configuration

        For i = 0 To CaptureInformation.CaptureInfo.PropertyPages.Count - 1
            p = CaptureInformation.CaptureInfo.PropertyPages(i)
            Me.lboxDriver.Items.Add(p.Name + "...")
        Next


    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents lblFPS As System.Windows.Forms.Label
    Friend WithEvents lblTam As System.Windows.Forms.Label
    Friend WithEvents lblCompress As System.Windows.Forms.Label
    Friend WithEvents cmbFPS As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTam As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCompress As System.Windows.Forms.ComboBox
    Public WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents lboxDriver As System.Windows.Forms.ListBox
    Friend WithEvents lblDriver As System.Windows.Forms.Label
    Public WithEvents CanButton As System.Windows.Forms.Button
    Friend WithEvents txtPathVideo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblFPS = New System.Windows.Forms.Label()
        Me.lblTam = New System.Windows.Forms.Label()
        Me.lblCompress = New System.Windows.Forms.Label()
        Me.cmbFPS = New System.Windows.Forms.ComboBox()
        Me.cmbTam = New System.Windows.Forms.ComboBox()
        Me.cmbCompress = New System.Windows.Forms.ComboBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CanButton = New System.Windows.Forms.Button()
        Me.lboxDriver = New System.Windows.Forms.ListBox()
        Me.lblDriver = New System.Windows.Forms.Label()
        Me.txtPathVideo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblFPS
        '
        Me.lblFPS.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblFPS.Location = New System.Drawing.Point(28, 16)
        Me.lblFPS.Name = "lblFPS"
        Me.lblFPS.Size = New System.Drawing.Size(124, 16)
        Me.lblFPS.TabIndex = 1
        Me.lblFPS.Text = "- Frames per second"
        '
        'lblTam
        '
        Me.lblTam.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTam.Location = New System.Drawing.Point(28, 75)
        Me.lblTam.Name = "lblTam"
        Me.lblTam.Size = New System.Drawing.Size(124, 16)
        Me.lblTam.TabIndex = 2
        Me.lblTam.Text = "- Image size"
        '
        'lblCompress
        '
        Me.lblCompress.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblCompress.Location = New System.Drawing.Point(28, 134)
        Me.lblCompress.Name = "lblCompress"
        Me.lblCompress.Size = New System.Drawing.Size(124, 16)
        Me.lblCompress.TabIndex = 3
        Me.lblCompress.Text = "- Compressors"
        '
        'cmbFPS
        '
        Me.cmbFPS.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.cmbFPS.Location = New System.Drawing.Point(56, 43)
        Me.cmbFPS.Name = "cmbFPS"
        Me.cmbFPS.Size = New System.Drawing.Size(212, 21)
        Me.cmbFPS.TabIndex = 4
        '
        'cmbTam
        '
        Me.cmbTam.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.cmbTam.Location = New System.Drawing.Point(56, 102)
        Me.cmbTam.Name = "cmbTam"
        Me.cmbTam.Size = New System.Drawing.Size(212, 21)
        Me.cmbTam.TabIndex = 5
        '
        'cmbCompress
        '
        Me.cmbCompress.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.cmbCompress.Location = New System.Drawing.Point(56, 161)
        Me.cmbCompress.Name = "cmbCompress"
        Me.cmbCompress.Size = New System.Drawing.Size(212, 21)
        Me.cmbCompress.TabIndex = 6
        '
        'OKButton
        '
        Me.OKButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OKButton.Location = New System.Drawing.Point(92, 356)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OKButton.Size = New System.Drawing.Size(81, 25)
        Me.OKButton.TabIndex = 7
        Me.OKButton.Text = "OK"
        '
        'CanButton
        '
        Me.CanButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.CanButton.BackColor = System.Drawing.SystemColors.Control
        Me.CanButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CanButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CanButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CanButton.Location = New System.Drawing.Point(192, 356)
        Me.CanButton.Name = "CanButton"
        Me.CanButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CanButton.Size = New System.Drawing.Size(81, 25)
        Me.CanButton.TabIndex = 8
        Me.CanButton.Text = "Cancel"
        '
        'lboxDriver
        '
        Me.lboxDriver.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.lboxDriver.Location = New System.Drawing.Point(56, 220)
        Me.lboxDriver.Name = "lboxDriver"
        Me.lboxDriver.Size = New System.Drawing.Size(212, 43)
        Me.lboxDriver.TabIndex = 9
        '
        'lblDriver
        '
        Me.lblDriver.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblDriver.Location = New System.Drawing.Point(28, 193)
        Me.lblDriver.Name = "lblDriver"
        Me.lblDriver.Size = New System.Drawing.Size(124, 16)
        Me.lblDriver.TabIndex = 10
        Me.lblDriver.Text = "- Driver configuration"
        '
        'txtPathVideo
        '
        Me.txtPathVideo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtPathVideo.Location = New System.Drawing.Point(56, 312)
        Me.txtPathVideo.Name = "txtPathVideo"
        Me.txtPathVideo.Size = New System.Drawing.Size(212, 20)
        Me.txtPathVideo.TabIndex = 12
        Me.txtPathVideo.Text = "C:\Capture\Capture.avi"
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.Location = New System.Drawing.Point(28, 280)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "- Captured File Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CW
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.CanButton
        Me.ClientSize = New System.Drawing.Size(292, 399)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtPathVideo, Me.Label1, Me.lblDriver, Me.lboxDriver, Me.CanButton, Me.OKButton, Me.cmbCompress, Me.cmbTam, Me.cmbFPS, Me.lblCompress, Me.lblTam, Me.lblFPS})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CW"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Camera configuration"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub lboxDriver_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lboxDriver.MouseDown

        CaptureInformation.CaptureInfo.PropertyPages(Me.lboxDriver.SelectedIndex).Show(CW.ActiveForm)

    End Sub

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OKButton.Click
        CaptureInformation.PathVideo = txtPathVideo.Text
        ConfParamCam()
        PrepareCam(CaptureInformation.PathVideo)
        Me.Hide()
        CaptureInformation.CaptureInfo.CaptureFrame()
    End Sub

    Private Sub CanButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CanButton.Click
        Me.Close()
    End Sub

End Class
