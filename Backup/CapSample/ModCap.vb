Option Strict Off
Option Explicit On 

Imports DirectX.Capture
Imports System
Imports System.IO

Module ModCap

    'Main structure

    Public Structure Active
        Dim Camera As Filter
        Dim CaptureInfo As Capture
        Dim ConfWindow As CW
        Dim Counter As Integer
        Dim CounterFrames As Integer
        Dim PathVideo As String
    End Structure

    'Global variables definition

    Public CaptureInformation As Active
    Public Dispositivos As New Filters()

    Public Sub PrepareCam(ByVal PathVideo As String)
        Dim s() As String

        s = PathVideo.Split(".")
        ConfParamCam()
        CaptureInformation.CaptureInfo.Filename = s(0) + CStr(CaptureInformation.Counter) + ".avi"
        CaptureInformation.Counter += 1
        CaptureInformation.CaptureInfo.RenderPreview()

    End Sub

    Public Sub ConfParamCam()

        Dim s() As String
        Dim size As Size
        Dim Rate As Double

        CaptureInformation.CaptureInfo.Stop()

        ' Change the compressor
        CaptureInformation.CaptureInfo.VideoCompressor = Dispositivos.VideoCompressors(CaptureInformation.ConfWindow.cmbCompress.Items.IndexOf(CaptureInformation.ConfWindow.cmbCompress.Text))

        ' Change the image size
        s = CaptureInformation.ConfWindow.cmbTam.Text.Split("x")
        size = New Size(Val(s(0)), Val(s(1)))
        CaptureInformation.CaptureInfo.FrameSize = size

        ' Change the number of frames per second
        s = CaptureInformation.ConfWindow.cmbFPS.Text.Split(" ")
        Rate = Val(s(0))
        CaptureInformation.CaptureInfo.FrameRate = Rate

    End Sub


End Module