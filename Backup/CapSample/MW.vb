Imports DirectX.Capture

Public Class MW
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Call to AddCam to select an available camera
        Dim AddCamera As New AddCam()
        AddCamera.ShowDialog(Me)

        CaptureInformation.CaptureInfo.PreviewWindow = Me.videoBoard

        'Define RefreshImage as event handler of FrameCaptureComplete
        AddHandler CaptureInformation.CaptureInfo.FrameCaptureComplete, AddressOf RefreshImage

        CaptureInformation.Counter = 1
        CaptureInformation.CounterFrames = 1


        Me.Show()

        'Initialization of ConfWindow
        CaptureInformation.ConfWindow = New CW()
        CaptureInformation.ConfWindow.Refresh()
        CaptureInformation.ConfWindow.Show()

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
    Friend WithEvents videoBoard As System.Windows.Forms.Panel
    Friend WithEvents cmdFrame As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents pcbFrame As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.videoBoard = New System.Windows.Forms.Panel()
        Me.cmdFrame = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.pcbFrame = New System.Windows.Forms.PictureBox()
        Me.SuspendLayout()
        '
        'videoBoard
        '
        Me.videoBoard.Location = New System.Drawing.Point(2, 0)
        Me.videoBoard.Name = "videoBoard"
        Me.videoBoard.Size = New System.Drawing.Size(320, 240)
        Me.videoBoard.TabIndex = 0
        '
        'cmdFrame
        '
        Me.cmdFrame.Location = New System.Drawing.Point(432, 256)
        Me.cmdFrame.Name = "cmdFrame"
        Me.cmdFrame.TabIndex = 1
        Me.cmdFrame.Text = "Frame"
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(56, 256)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.TabIndex = 2
        Me.cmdStart.Text = "Start"
        '
        'cmdStop
        '
        Me.cmdStop.Enabled = False
        Me.cmdStop.Location = New System.Drawing.Point(184, 256)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.TabIndex = 3
        Me.cmdStop.Text = "Stop"
        '
        'pcbFrame
        '
        Me.pcbFrame.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.pcbFrame.Location = New System.Drawing.Point(334, 0)
        Me.pcbFrame.Name = "pcbFrame"
        Me.pcbFrame.Size = New System.Drawing.Size(320, 240)
        Me.pcbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbFrame.TabIndex = 4
        Me.pcbFrame.TabStop = False
        '
        'MW
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(656, 289)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pcbFrame, Me.cmdStop, Me.cmdStart, Me.cmdFrame, Me.videoBoard})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MW"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Window"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub RefreshImage(ByVal Frame As System.Windows.Forms.PictureBox)
        Dim s() As String
        s = CaptureInformation.PathVideo.Split(".")
        Me.pcbFrame.Image = Frame.Image
        Me.pcbFrame.Image.Save(s(0) + CStr(CaptureInformation.CounterFrames) + ".png")
        CaptureInformation.CounterFrames += 1
        Me.pcbFrame.Refresh()
    End Sub

    Private Sub cmdFrame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFrame.Click
        CaptureInformation.CaptureInfo.CaptureFrame()
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        CaptureInformation.CaptureInfo.Start()
        cmdStart.Enabled = False
        cmdStop.Enabled = True
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        CaptureInformation.CaptureInfo.Stop()
        ConfParamCam()
        PrepareCam(CaptureInformation.PathVideo)
        cmdStart.Enabled = True
        cmdStop.Enabled = False
    End Sub

End Class
