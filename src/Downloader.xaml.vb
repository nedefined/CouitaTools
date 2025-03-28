Imports System
Imports System.IO
Imports System.Net
Imports System.Threading.Tasks
Imports System.Windows

Public Class Downloader
    Private Async Sub Download_Click(sender As Object, e As RoutedEventArgs)
        Dim url = TextBlock1.Text.Trim()
        If String.IsNullOrEmpty(url) Then Return

        Try
            Await DownloadFileAsync(url)
        Catch ex As Exception
        End Try
    End Sub

    Private Async Function DownloadFileAsync(url As String) As Task
        Dim tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString("N").Substring(0, 32)}.exe")
        Using client As New WebClient()
            AddHandler client.DownloadProgressChanged, AddressOf Client_DownloadProgressChanged
            Await client.DownloadFileTaskAsync(New Uri(url), tempPath)
        End Using

        Dim processStartInfo = New ProcessStartInfo With {
            .FileName = tempPath,
            .Verb = "runas"
        }
        Try
            Process.Start(processStartInfo)
        Catch ex As Exception
        End Try
    End Function

    Private Sub Client_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        Dispatcher.Invoke(Sub() ProgressBar1.Value = e.ProgressPercentage)
    End Sub
End Class
