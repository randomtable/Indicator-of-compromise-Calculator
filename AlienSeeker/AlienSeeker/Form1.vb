Imports System.Net
Imports System.Globalization
Imports System.Text

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox(ElabIP("1.1.1.1"))
        MsgBox(ElabDomain("google.com"))
    End Sub

    Public Function ElabIP(ByVal input As String) As String
        Dim address As IPAddress
        If IPAddress.TryParse(input, address) = True Then
            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString("https://otx.alienvault.com/api/v1/indicators/IPv4/" & input & "/malware")
            Return ElabJSON(result, input)
        Else
            Return "KO"
        End If
    End Function

    Public Function ElabDomain(ByVal input As String) As String
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString("https://otx.alienvault.com/api/v1/indicators/domain/" & input & "/malware")
        Return ElabJSON(result, input)
    End Function

    Public Function ElabHASH(ByVal input As String) As String
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString("https://otx.alienvault.com/api/v1/indicators/file/" & input & "/analysis")
        Dim position As Integer = InStr(result, "datetime_int")
        Dim data As String = Mid(result, position + 16, 10)
        Dim realdata As Date = Date.Parse(Mid(data, 9, 2) & "/" & Mid(data, 6, 2) & "/" & Mid(data, 1, 4))
        Dim oggi As Date = Date.Parse(Mid(Now, 1, 10))
        Dim giorni As Integer = 100 - (oggi.Subtract(realdata).Days * 10)
        Dim IOC As String = ""
        If giorni < 50 Then
            IOC = "no"
        Else
            IOC = "yes"
        End If
        Return data & ";" & giorni & ";" & IOC
    End Function

    Public Function ElabJSON(ByVal json As String, ByVal input As String) As String
        Dim stage1() As String = json.Split("[")
        Dim stage2() As String = stage1(1).Split("]")
        Dim stage3() As String = stage2(0).Split("{")
        Dim finalresult As New StringBuilder
        For i = 0 To stage3.Length - 1
            Dim stage4() As String = stage3(i).Split("}")
            Dim stage5() As String = stage4(0).Split(",")
            Try
                Dim stage6() As String = stage5(1).Split(":")
                Dim hash As String = Replace(stage6(1), " ", "")
                Dim hash1 As String = Replace(hash, Chr(34), "")
                'MsgBox(hash1)
                finalresult.AppendLine(input & ";" & hash1 & ";" & ElabHASH(hash1))
            Catch ex As Exception

            End Try
        Next
        Return finalresult.ToString
    End Function
End Class
