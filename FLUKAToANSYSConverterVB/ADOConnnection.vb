'© Copyright CERN 2010-2015
' This file is part of FLUKA To ANSYS Converter.
'FLUKA To ANSYS Converter is free software: you can redistribute it
'and/or modify it under the terms of the GNU Lesser General Public Licence
'as published by the Free Software Foundation, either version 3 of the
'Licence.
'FLUKA To ANSYS Converter is distributed in the hope that it will be
'useful,but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser
'General Public Licence for more details.
'You should have received a copy of the GNU Lesser General Public
'License along with [Name of your software package]. If not, see
'<http://www.gnu.org/licenses/>.

Imports Microsoft.VisualBasic
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb

Public Class ADOconnection

    Private pathName As String
    Private strProvider As String
    Private conn As OleDbConnection
    Private cmd As OleDbCommand
    Private ada As OleDbDataAdapter
    Public table As New DataTable
    Public numRecordModifyed As Integer
    Public parameters As ArrayList
    Private params As OleDbParameter

    Public Sub New(ByVal provider As String, ByVal path As String)

        pathName = path
        strProvider = provider
        parameters = New ArrayList

    End Sub

    Public Sub CreateConnection()

        If (conn Is Nothing) Then
            conn = New OleDbConnection()
            conn.ConnectionString = "provider=" & strProvider & ";data source=" & pathName
        End If

    End Sub

    Private Sub OpenConnection()

        Try
            If (conn.State = Data.ConnectionState.Closed) Then conn.Open()
        Catch ex As Exception
            MsgBox("Errore nella connessione iniziale al DB, " & ex.Message)
        End Try

    End Sub

    Private Sub CloseConnection()

        Try
            If (conn.State = Data.ConnectionState.Open) Then conn.Close()
        Catch ex As Exception
            MsgBox("Errore nella chiusura del DB, " & ex.Message)
        End Try

    End Sub

    Public Sub ExecuteQuery(ByVal sql As String)

        Me.OpenConnection()
        Me.table.Clear()
        Me.table.Rows.Clear()
        Me.table.Columns.Clear()
        cmd = New OleDbCommand
        cmd.CommandText = sql
        cmd.Connection = conn
        If Not parameters Is Nothing Then
            For i As Integer = 0 To parameters.Count - 1
                cmd.Parameters.Add(New OleDbParameter(i.ToString, parameters(i)))
            Next
        End If
        ada = New OleDbDataAdapter
        ada.SelectCommand = cmd
        Try
            ada.Fill(Me.table)
        Catch ex As Exception
            MsgBox("Error in SQL string, " & ex.Message)
        End Try
        Me.CloseConnection()

    End Sub

    Public Sub ExecuteNoQuery(ByVal sql As String)

        Me.OpenConnection()
        Me.table.Clear()
        Me.table.Rows.Clear()
        Me.table.Columns.Clear()
        cmd = New OleDbCommand
        cmd.CommandText = sql
        cmd.Connection = conn
        If Not parameters Is Nothing Then
            For i As Integer = 0 To parameters.Count - 1
                cmd.Parameters.Add(New OleDbParameter(i.ToString, parameters(i)))
            Next
        End If
        Try
            numRecordModifyed = cmd.ExecuteNonQuery
        Catch ex As Exception
            MsgBox("Error in SQL string, " & ex.Message)
        End Try
        Me.CloseConnection()

    End Sub

    Public Sub ExecuteAllTypeQuery(ByVal sql As String)

        If control(sql) Then
            Me.ExecuteQuery(sql)
        Else
            Me.ExecuteNoQuery(sql)
        End If

    End Sub

    Public Sub ExecuteStoredQuery(ByVal sql As String)

        Me.OpenConnection()
        Me.table.Clear()
        Me.table.Rows.Clear()
        Me.table.Columns.Clear()
        cmd = New OleDbCommand
        cmd.CommandText = sql
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        If Not parameters Is Nothing Then
            For i As Integer = 0 To parameters.Count - 1
                cmd.Parameters.Add(New OleDbParameter(i.ToString, parameters(i)))
            Next
        End If
        ada = New OleDbDataAdapter
        ada.SelectCommand = cmd
        'Try
        ada.Fill(Me.table)
        'Catch
        'MsgBox("Error in SQL string")
        'End Try
        Me.CloseConnection()

    End Sub

    Private Function control(ByVal str As String) As Boolean

        str = str.ToLower
        Dim s() As String = str.Split(" ")
        If s(0) = "select" Then
            Return True
        End If
        Return False

    End Function

End Class
