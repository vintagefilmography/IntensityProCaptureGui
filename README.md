# IntensityProCaptureGui

Based on this sw:  
https://www.codeproject.com/Articles/4740/Capture-Sample-with-DirectX-and-NET  
This SampleCap produces images from a video with the mouse click.
The default images are jpeg but this can be easily changed to add other formats in MW.vb file:

        If String.Compare(fmt, "tiff") = 0 Then
            Me.pcbFrame.Image.Save(s(0) + CStr(CaptureInformation.CounterFrames) + "." + fmt, System.Drawing.Imaging.ImageFormat.Tiff)
        End If
        If String.Compare(fmt, "jpg") = 0 Then
            Me.pcbFrame.Image.Save(s(0) + CStr(CaptureInformation.CounterFrames) + "." + fmt, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
        If String.Compare(fmt, "bmp") = 0 Then
            Me.pcbFrame.Image.Save(s(0) + CStr(CaptureInformation.CounterFrames) + "." + fmt, System.Drawing.Imaging.ImageFormat.Bmp)
        End If
        If String.Compare(fmt, "png") = 0 Then
            Me.pcbFrame.Image.Save(s(0) + CStr(CaptureInformation.CounterFrames) + "." + fmt, System.Drawing.Imaging.ImageFormat.Png)
        End If

For IntensityPro the frame rate is hardcoded to 59.94FPS in MOdCap.vb file:
      ' Change the number of frames per second
        s = CaptureInformation.ConfWindow.cmbFPS.Text.Split(" ")
        'Rate = Val(s(0))
        Rate = 59.94
        
     
Another sw written in C# was used for writing of the images to teh video file.
See discussion here and SOLUTION or just search for videofile writer on this web page.:
https://stackoverflow.com/questions/9744026/image-sequence-to-video-stream
It uses the AFORGE libs andd the instructions are provided. 
Basically download the aforge framewwork to your repository and then in Visual Studio 
add the references to the DLLs.
There are some issues with the build andd some fixes are outilned here:
Fix aForge.video.FFMPEG exception:
https://stackoverflow.com/questions/41368176/could-not-load-file-or-assembly-aforge-video-ffmpeg-dll-or-one-of-its-dependen
https://stackoverflow.com/questions/32365144/signed-clickonce-app-throwing-unknown-publisher-with-windows-10

These two programs were used to create the combined software stored in this repo. 
There were quite a few issues combining the software.
Here is the summary.
After adding VideoFileWriter from AviVideoV1_fast_mpeg to CapSample
the following build issues popped up:

The reference assemblies for .NETFramework, Version=v4.0 were not found. To resolve this, 
install the Developer Pack (SDK/Targeing Pack) for this framework version or retarget your appliation. 
You can download .NET Framework Developer Packs at https://aka.ms/msbuild/developpacks

That did not help.
Had to add the following line to the project file on the bottom:
  <PropertyGroup>
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
    <TargetFrameworkMoniker>.NETFramework,Version=$(TargetFrameworkVersion)</TargetFrameworkMoniker>
  </PropertyGroup>

AForge VideoFileWritter info:
http://www.aforgenet.com/framework/docs/html/4ee1742c-44d3-b250-d6aa-90cd2d606611.htm
https://github.com/cureos/aforge/blob/master/Sources/Video.FFMPEG/VideoFileWriter.h
Codec info:
http://www.aforgenet.com/framework/docs/html/975f81c7-c67f-baec-cd43-3daaaf8023b3.htm
example VB project:
https://www.codeproject.com/Questions/535124/connectingplusapluswebcamplususingplusaforge-netpl

Aforge.Video.Ffmpeg dll error:
Make sure your project’s target is x86, the assembly will not work in x64.
Mark sure all FFMPEG ddls are put into the same folder as your application.
There include the DLLs from here
C:\Users\stan\source\repos\AForge.NET Framework-2.2.5\Release
and
C:\Users\stan\source\repos\AForge.NET Framework-2.2.5\Externals\ffmpeg\bin

Mixed mode assembly is built against version 'v2.0.50727' 
of the runtime and cannot be loaded in the 4.0 runtime without 
additional configuration information #1037

This is a runtime error. 
Fix:
Create app.config file in your build CamSample project.
Add the following lines to it:
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup useLegacyV2RuntimeActivationPolicy="true">
    <supportedRuntime version="v4.0"/>
  </startup>
</configuration>

See:
https://github.com/xunit/xunit/issues/1037










        
