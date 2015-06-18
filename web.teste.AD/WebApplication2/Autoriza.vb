
Imports System.DirectoryServices

Public Class Autoriza
    Public Function Autentica(ByVal IpServer As String, ByVal User As String, ByVal Senha As String) As String

        Dim resutado As String = ""

        Try
            Dim oAD As DirectoryEntry = New DirectoryEntry("LDAP://" + IpServer, User, Senha)
            resutado = oAD.Name
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return resutado
    End Function
End Class

