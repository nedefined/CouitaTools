Imports System
Imports System.IO
Imports System.Net
Imports System.Threading.Tasks
Imports System.Windows
Imports AdonisUI.Controls
Imports Microsoft.Win32

Public Class Tools
    Private Sub SyIn_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\GLGYXH\TXkCPVWYcYdHKdKy.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PrEx_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\prex.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SyMo_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\prmn.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCP_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\tcpv.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AURU_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\aur.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Expl_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\exp.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DoCo_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\WGSDUS\dc.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToRe_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\trg.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AVZ_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\LBZXNH\dbrriebght.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AULO_Click(sender As Object, e As RoutedEventArgs)
        Dim exePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\aulo.exe")
        Try
            Process.Start(exePath)
        Catch ex As Exception
        End Try
    End Sub
End Class
