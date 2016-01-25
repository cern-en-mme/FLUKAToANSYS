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

Public Class ZCrossSectionSelection

    'These variables are used to save the choices the user has done and to reset the Radio buttons and the Text boxes
    Dim Choice As Byte = 0
    Dim FromValue As Integer = 1
    Dim ToValue As Integer = MainForm.NumberOfSections
    Dim EveryValue As Integer = 1

    Private Sub BtnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDone.Click

        Dim zVector() As Integer
        Dim NumberOfSections As Integer

        If Me.RadioBtnAll.Checked Then
            Choice = 0
            NumberOfSections = MainForm.NumberOfSections
            ReDim zVector(NumberOfSections - 1)
            For i As Integer = 0 To NumberOfSections - 1
                zVector(i) = i
            Next
        ElseIf Me.RadioBtnFromTo.Checked Then
            Choice = 1
            FromValue = Me.TBoxFrom.Text
            ToValue = Me.TBoxTo.Text
            NumberOfSections = Me.TBoxTo.Text - Me.TBoxFrom.Text + 1
            ReDim zVector(NumberOfSections - 1)
            For i As Integer = 0 To NumberOfSections - 1
                zVector(i) = Me.TBoxFrom.Text + i - 1
            Next
        ElseIf Me.RadioBtnEvery.Checked Then
            Choice = 2
            EveryValue = Me.TBoxEvery.Text
            NumberOfSections = MainForm.NumberOfSections / Me.TBoxEvery.Text
            ReDim zVector(NumberOfSections - 1)
            For i As Integer = 0 To NumberOfSections - 1
                zVector(i) = i * Me.TBoxEvery.Text
            Next
        ElseIf Me.RadioBtnSelection.Checked Then
            Choice = 3
            For i As Integer = 0 To Me.DGVSelection.SelectedCells.Count - 1
                If Convert.ToString(Me.DGVSelection.SelectedCells.Item(i).Value) <> "" Then NumberOfSections += 1
            Next
            ReDim zVector(NumberOfSections - 1)
            Dim aux As Integer
            For i As Integer = 0 To Me.DGVSelection.SelectedCells.Count - 1
                If Convert.ToString(Me.DGVSelection.SelectedCells.Item(i).Value) <> "" Then
                    zVector(aux) = Me.DGVSelection.SelectedCells.Item(i).Value - 1
                    aux += 1
                End If

            Next
            For i As Integer = 0 To zVector.Length - 2
                For j As Integer = i + 1 To zVector.Length - 1
                    If zVector(j) < zVector(i) Then
                        aux = zVector(j)
                        zVector(j) = zVector(i)
                        zVector(i) = aux
                    End If
                Next
            Next
        End If

        MainForm.Util.ZCrossSections = zVector

        Me.Visible = False
        MainForm.BtnShowPlot.Visible = False
        MainForm.Focus()
    End Sub

    Private Sub ZCrossSectionSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TBoxTo.Text = MainForm.NumberOfSections
        Me.Size = New System.Drawing.Size(Me.Size.Width, 250)

    End Sub

    Private Sub TBoxFrom_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxFrom.Leave

        If sender.text = "" Then
            sender.text = 1
        ElseIf Convert.ToInt32(Me.TBoxFrom.Text) > Convert.ToInt32(Me.TBoxTo.Text) Then
            sender.Text = Me.TBoxTo.Text
        End If

    End Sub

    Private Sub TBoxTo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxTo.Leave

        If sender.text = "" Then
            sender.text = MainForm.NumberOfSections
        ElseIf CInt(Me.TBoxTo.Text) > MainForm.NumberOfSections Then
            sender.text = MainForm.NumberOfSections
        ElseIf CInt(Me.TBoxFrom.Text) > CInt(Me.TBoxTo.Text) Then
            sender.Text = Me.TBoxFrom.Text
        End If

    End Sub

    Private Sub TBoxEvery_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxEvery.Leave

        If sender.text = "" Then
            sender.text = MainForm.NumberOfSections
        ElseIf CInt(Me.TBoxEvery.Text) > MainForm.NumberOfSections Then
            sender.text = MainForm.NumberOfSections
        End If

    End Sub

    Private Sub TBoxFrom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBoxFrom.KeyPress, TBoxTo.KeyPress, TBoxEvery.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8)) Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(8) And sender.text.length() > 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBoxFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxFrom.TextChanged, TBoxTo.TextChanged
        Me.RadioBtnFromTo.Checked = True
    End Sub

    Private Sub TBoxEvery_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxEvery.TextChanged
        Me.RadioBtnEvery.Checked = True
    End Sub

    Private Sub RadioBtnSelection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBtnSelection.CheckedChanged

        Dim ColumnNumber As Byte = 12

        If Me.RadioBtnSelection.Checked Then
            Me.Size = New System.Drawing.Size(Me.Size.Width, 450)
            If Me.DGVSelection.Rows.Count = 0 Then

                For i As Integer = 0 To ColumnNumber - 1
                    Me.DGVSelection.Columns.Add("", "")
                Next

                For i As Integer = 0 To (MainForm.NumberOfSections) / ColumnNumber
                    Me.DGVSelection.Rows.Add()
                    For j As Integer = 0 To ColumnNumber - 1
                        Me.DGVSelection.Item(j, i).Value = i * ColumnNumber + j + 1
                    Next
                Next
                'The values bigger than the number of sections are erased
                Dim aux As Integer = ColumnNumber - 1
                While Me.DGVSelection.Item(aux, Me.DGVSelection.Rows.Count - 1).Value > MainForm.NumberOfSections
                    Me.DGVSelection.Item(aux, Me.DGVSelection.Rows.Count - 1).Value = ""
                    aux -= 1
                End While

                Me.DGVSelection.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
        Else
            Me.Size = New System.Drawing.Size(Me.Size.Width, 250)
        End If

    End Sub

    Private Sub DGVSelection_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVSelection.SelectionChanged
        Try
            If Me.DGVSelection.SelectedCells.Item(Me.DGVSelection.SelectedCells.Count - 1).Value = "" Then Me.DGVSelection.SelectedCells.Item(Me.DGVSelection.SelectedCells.Count - 1).Selected = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Visible = False
        MainForm.Focus()
    End Sub

    Private Sub ZCrossSectionSelection_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        If Choice = 0 Then
            Me.RadioBtnAll.Checked = True
            Me.TBoxFrom.Text = 1
            Me.TBoxTo.Text = MainForm.NumberOfSections
            Me.TBoxEvery.Text = 1
            Me.Size = New System.Drawing.Size(Me.Size.Width, 250)
        ElseIf Choice = 1 Then
            Me.RadioBtnFromTo.Checked = True
            Me.TBoxFrom.Text = FromValue
            Me.TBoxTo.Text = ToValue
            Me.TBoxEvery.Text = 1
            Me.Size = New System.Drawing.Size(Me.Size.Width, 250)
        ElseIf Choice = 2 Then
            Me.RadioBtnEvery.Checked = True
            Me.TBoxEvery.Text = EveryValue
            Me.Size = New System.Drawing.Size(Me.Size.Width, 250)
        ElseIf Choice = 3 Then
            Me.RadioBtnSelection.Checked = True
            Me.Size = New System.Drawing.Size(Me.Size.Width, 450)
            For i As Integer = 0 To MainForm.Util.ZCrossSections.Length - 1
                For RowIndex As Integer = 0 To Me.DGVSelection.Rows.Count - 1
                    For ColumnIndex As Integer = 0 To Me.DGVSelection.Columns.Count - 1
                        If MainForm.Util.ZCrossSections(i) + 1 = Me.DGVSelection.Item(ColumnIndex, RowIndex).Value Then
                            Me.DGVSelection.Item(ColumnIndex, RowIndex).Selected = True
                            Exit For
                        End If
                    Next
                Next
            Next
        End If

    End Sub

End Class