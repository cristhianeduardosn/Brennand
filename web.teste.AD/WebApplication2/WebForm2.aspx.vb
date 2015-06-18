Imports System.DirectoryServices.ActiveDirectory
Imports System.DirectoryServices

Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim oAD As Autoriza = New Autoriza

        Try
            Response.Write(oAD.Autentica("Spi.local", txtUsuario.Text, txtSenha.Text) + "<br>")
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim builder As New StringBuilder()
        ' obtem uma reerencia ao Active Directory Atual
        ' e exibe o nome do dominio

        Dim dominio As Domain = Domain.GetCurrentDomain()
        Dim nomeDominio As String = dominio.Name

        builder.Append("List of Active Directory Users for Domain '" + nomeDominio + "'" & Chr(10) & "")

        ' obtem a entrada raiz no AD para o dominio
        Using root As New DirectoryEntry("LDAP://" + nomeDominio)

            ' procura no AD por caminho filhos com o container CN=Users
            Using searcher As New DirectorySearcher(root, "CN=Users")
                ' retorna a primeira ocorrência
                Dim result As SearchResult = searcher.FindOne()

                If result Is Nothing Then
                    builder.Append("No 'CN=Users' entry found.")
                Else
                    ' obtem a entrada do diretorio para o caminho CN=Users
                    Using entry As DirectoryEntry = result.GetDirectoryEntry()
                        ' percorre todos as entradas filhas

                        For Each child As DirectoryEntry In entry.Children
                            Dim userEntry As String = child.Name
                            ' remove "CN=" do nome retornado
                            builder.Append(userEntry.Substring(userEntry.IndexOf("=") + 1) + "" & Chr(10) & "")
                        Next
                    End Using
                End If
            End Using
        End Using
        ' resultado = builder.ToString()
        ' ListBox1.Items.Add(resultado)
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim root As System.DirectoryServices.DirectoryEntry
        root = New System.DirectoryServices.DirectoryEntry("WinNT:")

        Dim dominio As System.DirectoryServices.DirectoryEntry

        For Each dominio In root.Children
            ListBox1.Items.Add(dominio.Name)
        Next
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim root As System.DirectoryServices.DirectoryEntry
        root = New System.DirectoryServices.DirectoryEntry("WinNT:")
        Dim dominio As System.DirectoryServices.DirectoryEntry

        For Each dom In root.Children
            Dim computadores As System.DirectoryServices.DirectoryEntry
            computadores = New System.DirectoryServices.DirectoryEntry("WinNT://" + dominio.Name)

            Dim comp As System.DirectoryServices.DirectoryEntry
            For Each comp In computadores.Children
                If comp.SchemaClassName = "computador" Then
                    ListBox1.Items.Add((comp.Name))
                End If
            Next
        Next
    End Sub

    Public Function ListarTodosUsuariosAD() As DataTable
        Dim LDAP As String = "<ValorDoWebConfig>"
        Dim table As DataTable = New DataTable("Resultados")
        table.Columns.Add("Nome")
        table.Columns.Add("Usuario")
        table.Columns.Add("Email")
        Dim row As DataRow
        Dim deRoot As DirectoryEntry = New DirectoryEntry(LDAP)
        Dim deSrch As DirectorySearcher = New DirectorySearcher(deRoot, "(&(objectClass=user)(objectCategory=person))")
        deSrch.PropertiesToLoad.Add("cn")
        deSrch.PropertiesToLoad.Add("userPrincipalName")
        deSrch.PropertiesToLoad.Add("sAMAccountName")
        deSrch.PropertiesToLoad.Add("mail")
        deSrch.Sort.PropertyName = "sAMAccountName"
        Dim oRes As SearchResult
        For Each oRes In deSrch.FindAll()
            row = table.NewRow()
            row("Nome") = oRes.Properties("cn")(0).ToString()
            row("usuario") = oRes.Properties("sAMAccountName")(0).ToString()
            If oRes.Properties.Contains("mail") Then
                row("Email") = oRes.Properties("mail")(0).ToString()
            End If
            table.Rows.Add(row)
        Next
        Return table
    End Function

End Class