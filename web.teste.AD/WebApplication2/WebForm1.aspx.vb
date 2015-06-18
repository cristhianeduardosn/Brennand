Imports System.Text
Imports System.DirectoryServices
Imports System.Collections

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim builder As New StringBuilder()
    '    ' obtem uma reerencia ao Active Directory Atual
    '    ' e exibe o nome do dominio

    '    Dim dominio As Domain = Domain.GetCurrentDomain()
    '    Dim nomeDominio As String = dominio.Name

    '    builder.Append("List of Active Directory Users for Domain '" + nomeDominio + "'" & Chr(10) & "")

    '    ' obtem a entrada raiz no AD para o dominio
    '    Using root As New DirectoryEntry("LDAP://" + nomeDominio)

    '        ' procura no AD por caminho filhos com o container CN=Users
    '        Using searcher As New DirectorySearcher(root, "CN=Users")
    '            ' retorna a primeira ocorrência
    '            Dim result As SearchResult = searcher.FindOne()

    '            If result Is Nothing Then
    '                builder.Append("No 'CN=Users' entry found.")
    '            Else
    '                ' obtem a entrada do diretorio para o caminho CN=Users
    '                Using entry As DirectoryEntry = result.GetDirectoryEntry()
    '                    ' percorre todos as entradas filhas

    '                    For Each child As DirectoryEntry In entry.Children
    '                        Dim userEntry As String = child.Name
    '                        ' remove "CN=" do nome retornado
    '                        builder.Append(userEntry.Substring(userEntry.IndexOf("=") + 1) + "" & Chr(10) & "")
    '                    Next
    '                End Using
    '            End If
    '        End Using
    '    End Using
    '    resultado = builder.ToString()
    '    ListBox1.Items.Add(resultado)
    '    Next
    'End Sub



    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Dim root As System.DirectoryServices.DirectoryEntry
    '    root = New System.DirectoryServices.DirectoryEntry("WinNT:")
    '    Dim dominio As System.DirectoryServices.DirectoryEntry

    '    For Each dom In root.Children
    '        Dim computadores As System.DirectoryServices.DirectoryEntry
    '        computadores = New System.DirectoryServices.DirectoryEntry("WinNT://" + dominio.Name)

    '        Dim comp As System.DirectoryServices.DirectoryEntry
    '        For Each comp In computadores.Children
    '            If comp.SchemaClassName = "computador" Then
    '                ListBox1.Items.Add((comp.Name))
    '            End If
    '        Next
    '    Next
    'End Sub
End Class