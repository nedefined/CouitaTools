Class MainWindow
    Private Sub Tools_Click(sender As Object, e As RoutedEventArgs)
        Dim ToolsWindow As New Tools()
        ToolsWindow.Show()
    End Sub
    Private Sub Unlock_Click(sender As Object, e As RoutedEventArgs)
        Dim UnlockWindow As New Unlock()
        UnlockWindow.Show()
    End Sub
    Private Sub Downloader_Click(sender As Object, e As RoutedEventArgs)
        Dim DownloaderWindow As New Downloader()
        DownloaderWindow.Show()
    End Sub
    Private Sub About_Click(sender As Object, e As RoutedEventArgs)
        Dim AboutWindow As New About()
        AboutWindow.Show()
    End Sub
End Class
