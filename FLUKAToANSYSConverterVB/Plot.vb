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

Public Class Plot

    Dim SelectedZ As Integer
    Dim FirstTime As Boolean
    Dim LoadingComplete As Boolean = False
    Dim NumberOfSections As Integer
    'To block the text changing when the timers are enabled
    Dim BlockEvents As Boolean = False

    Dim BM As Bitmap
    Dim OldXStart, OldXEnd, OldYStart, OldYEnd As Integer

#Region "Initial Functions"

    'The sub sets the color of textBoxes and the values of the labels texts
    Private Sub InitializeLegend()
        Me.TBox100.BackColor = Color.FromArgb(255, 0, 0)
        Me.TBox80.BackColor = Color.FromArgb(255, 0.2 * 255, 0)
        Me.TBox60.BackColor = Color.FromArgb(255, 0.4 * 255, 0)
        Me.TBox40.BackColor = Color.FromArgb(255, 0.6 * 255, 0)
        Me.TBox20.BackColor = Color.FromArgb(255, 0.8 * 255, 0)
        Me.TBox10.BackColor = Color.FromArgb(255, 255, 0)
        Me.TBox8.BackColor = Color.FromArgb(255 * 0.8, 255, 0)
        Me.Tbox6.BackColor = Color.FromArgb(255 * 0.6, 255, 0)
        Me.TBox4.BackColor = Color.FromArgb(255 * 0.4, 255, 0)
        Me.TBox2.BackColor = Color.FromArgb(255 * 0.2, 255, 0)
        Me.TBox1.BackColor = Color.FromArgb(0, 255, 0)
        Me.TBox08.BackColor = Color.FromArgb(0, 0.8 * 255, 0.2 * 255)
        Me.TBox06.BackColor = Color.FromArgb(0, 0.6 * 255, 0.4 * 255)
        Me.TBox04.BackColor = Color.FromArgb(0, 0.4 * 255, 0.6 * 255)
        Me.TBox02.BackColor = Color.FromArgb(0, 0.2 * 255, 0.8 * 255)
        Me.TBox01.BackColor = Color.FromArgb(0, 0, 255)
        Me.TBox008.BackColor = Color.FromArgb(255 * 0.02, 0, 255 * 0.8)
        Me.TBox006.BackColor = Color.FromArgb(255 * 0.04, 0, 255 * 0.6)
        Me.TBox004.BackColor = Color.FromArgb(255 * 0.06, 0, 255 * 0.4)
        Me.TBox0.BackColor = Color.Black

        Dim Style As String = "Scientific"
        Dim MaximumEnergyValue As Double = MainForm.Util.AbsoluteMaximumValue
        Me.Lbl100.Text = Format(MaximumEnergyValue, Style) & " W/m3"
        Me.Lbl80.Text = Format(MaximumEnergyValue * 0.8, Style) & " W/m3"
        Me.Lbl60.Text = Format(MaximumEnergyValue * 0.6, Style) & " W/m3"
        Me.Lbl40.Text = Format(MaximumEnergyValue * 0.4, Style) & " W/m3"
        Me.Lbl20.Text = Format(MaximumEnergyValue * 0.2, Style) & " W/m3"
        Me.Lbl10.Text = Format(MaximumEnergyValue * 0.1, Style) & " W/m3"
        Me.Lbl8.Text = Format(MaximumEnergyValue * 0.08, Style) & " W/m3"
        Me.Lbl6.Text = Format(MaximumEnergyValue * 0.06, Style) & " W/m3"
        Me.Lbl4.Text = Format(MaximumEnergyValue * 0.04, Style) & " W/m3"
        Me.Lbl2.Text = Format(MaximumEnergyValue * 0.02, Style) & " W/m3"
        Me.Lbl1.Text = Format(MaximumEnergyValue * 0.01, Style) & " W/m3"
        Me.Lbl08.Text = Format(MaximumEnergyValue * 0.008, Style) & " W/m3"
        Me.Lbl06.Text = Format(MaximumEnergyValue * 0.006, Style) & " W/m3"
        Me.Lbl04.Text = Format(MaximumEnergyValue * 0.004, Style) & " W/m3"
        Me.Lbl02.Text = Format(MaximumEnergyValue * 0.002, Style) & " W/m3"
        Me.Lbl01.Text = Format(MaximumEnergyValue * 0.001, Style) & " W/m3"
        Me.Lbl008.Text = Format(MaximumEnergyValue * 0.0008, Style) & " W/m3"
        Me.Lbl006.Text = Format(MaximumEnergyValue * 0.0006, Style) & " W/m3"
        Me.Lbl004.Text = Format(MaximumEnergyValue * 0.0004, Style) & " W/m3"
        Me.Lbl0.Text = "< " & Format(MaximumEnergyValue * 0.0001, Style) & " W/m3"

    End Sub

    'It changes the size of the components on the form 
    Private Sub ReScaleControls()
        'The picture box size is changed following the size of the energy grid
        MainForm.Util.ResizeControl(Me.PictureBox)
        BM = New Bitmap(Me.PictureBox.Width, Me.PictureBox.Height)

        'Dim Width As Integer = Me.GroupBoxPlot.Width
        'Dim Height As Integer = Me.GroupBoxPlot.Height

        'The form size is changed and all the controls are replaced
        'Me.Size = New Size(Width + Me.GroupBoxLegend.Width + 30, Height + Me.GroupBoxCoordinates.Height + 60)
        'Me.GroupBoxLegend.Location = New Point(Width + 18, Me.GroupBoxLegend.Location.Y)
        'Me.GroupBoxFunctions.Location = New Point(Width + 18, Height + 18)
        'Me.GroupBoxCoordinates.Location = New Point(Me.GroupBoxCoordinates.Location.X, Height + 18)
        'Me.GroupBoxCoordinates.Size = New Size(Width, Me.GroupBoxCoordinates.Height)

    End Sub

    Private Sub Plot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SelectedZ = 0
        OldXStart = MainForm.Util.XStart
        OldXEnd = MainForm.Util.Xend
        OldYStart = MainForm.Util.Ystart
        OldYEnd = MainForm.Util.Yend

        NumberOfSections = MainForm.Util.ZCrossSections.Length
        Me.HScrollBar.Maximum = NumberOfSections + Me.HScrollBar.LargeChange - 2
        Me.HScrollBar.Value = 0
        Me.TBoxSelectedZ.Text = "1"

        Me.HScrollBarXStart.Maximum = MainForm.Util.NumberX + Me.HScrollBarXStart.LargeChange - 2
        Me.HScrollBarXStart.Value = MainForm.Util.XStart
        Me.TBoxXStart.Text = MainForm.Util.FirstX + MainForm.Util.XStart * MainForm.Util.StepX + MainForm.Util.StepX / 2
        Me.LblXStart.Text = "XStart (" & Me.UnityOfMeasurement(Me.TBoxXStart.Text) & ")"

        Me.HScrollBarXEnd.Maximum = MainForm.Util.NumberX + Me.HScrollBarXStart.LargeChange - 2
        Me.HScrollBarXEnd.Value = MainForm.Util.Xend
        Me.TBoxXEnd.Text = MainForm.Util.FirstX + MainForm.Util.Xend * MainForm.Util.StepX + MainForm.Util.StepX / 2
        Me.LblXEnd.Text = "XEnd (" & Me.UnityOfMeasurement(Me.TBoxXEnd.Text) & ")"

        Me.HScrollBarYStart.Maximum = MainForm.Util.Numbery + Me.HScrollBarYStart.LargeChange - 2
        Me.HScrollBarYStart.Value = MainForm.Util.Ystart
        Me.TBoxYStart.Text = MainForm.Util.FirstY + MainForm.Util.Ystart * MainForm.Util.Stepy + MainForm.Util.Stepy / 2
        Me.LblYStart.Text = "YStart (" & Me.UnityOfMeasurement(Me.TBoxYStart.Text) & ")"

        Me.HScrollBarYEnd.Maximum = MainForm.Util.Numbery + Me.HScrollBarYStart.LargeChange - 2
        Me.HScrollBarYEnd.Value = MainForm.Util.Yend
        Me.TBoxYEnd.Text = MainForm.Util.FirstY + MainForm.Util.Yend * MainForm.Util.Stepy + MainForm.Util.Stepy / 2
        Me.LblYEnd.Text = "YEnd (" & Me.UnityOfMeasurement(Me.TBoxYEnd.Text) & ")"

        FirstTime = True
        BM = New Bitmap(Me.PictureBox.Width, Me.PictureBox.Height)
        Timer.Start()
        InitializeLegend()


    End Sub

    Private Function UnityOfMeasurement(ByRef value As Double) As String

        If Math.Abs(value) >= 100 Then
            value /= 100
            Return "m"
        ElseIf Math.Abs(value) >= 0.01 Then
            Return "cm"
        ElseIf Math.Abs(value) >= 0.0001 Then
            value *= 10000
            Return "μm"
        ElseIf Math.Abs(value) >= 10 ^ -7 Then
            value *= 10 ^ 7
            Return "nm"
        ElseIf Math.Abs(value) >= 10 ^ -10 Then
            value *= 10 ^ 10
            Return "pm"
        ElseIf Math.Abs(value) >= 10 ^ -13 Then
            value *= 10 ^ 13
            Return "fm"
        End If

        Return ""

    End Function

#End Region

#Region "Section Selection"

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        If (MainForm.Util.ZCrossSections(Me.HScrollBar.Value) <> SelectedZ) Or FirstTime Then
            BlockEvents = True
            SelectedZ = MainForm.Util.ZCrossSections(Me.HScrollBar.Value)
            Me.TBoxSelectedZ.Text = SelectedZ + 1
            If FirstTime Then
                ReScaleControls()
                FirstTime = False
                LoadingComplete = True
            End If
            MainForm.Util.DrawGraphic(BM, Me.HScrollBar.Value)
            Me.PictureBox.Image = BM
            BlockEvents = False
        End If
        Timer.Stop()

    End Sub

    Private Sub HScrollBar_MouseCaptureChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HScrollBar.MouseCaptureChanged
        Timer.Start()
    End Sub

    Private Sub TBoxSelectedZ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxSelectedZ.TextChanged

        If Not BlockEvents Then

            If sender.text <> "" Then
                If MainForm.Util.IsInTheZCrossSection(sender.text - 1) Then
                    Me.HScrollBar.Value = Me.TBoxSelectedZ.Text - 1
                    Timer.Start()
                    Me.TBoxSelectedZ.BackColor = Color.White
                Else
                    Me.TBoxSelectedZ.BackColor = Color.Red
                End If
            End If

        End If

    End Sub

    Private Sub TBoxSelectedZ_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBoxSelectedZ.KeyPress, TBoxYStart.KeyPress, TBoxYEnd.KeyPress, TBoxXStart.KeyPress, TBoxXEnd.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8)) Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(8) And sender.text.length() > 5 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBoxSelectedZ_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxSelectedZ.Leave

        If sender.text = "" Then
            sender.text = SelectedZ + 1
        End If

    End Sub

#End Region

    Dim XStart, YStart, XEnd, YEnd As Integer
    Dim MousePressed As Boolean = False

#Region "Picture Box Functions"

    Private Sub UpdateCoordinates()

        Me.HScrollBarXStart.Value = MainForm.Util.XStart
        Me.TBoxXStart.Text = MainForm.Util.FirstX + MainForm.Util.XStart * MainForm.Util.StepX + MainForm.Util.StepX / 2
        Me.LblXStart.Text = "XStart (" & Me.UnityOfMeasurement(Me.TBoxXStart.Text) & ")"

        Me.HScrollBarXEnd.Value = MainForm.Util.Xend
        Me.TBoxXEnd.Text = MainForm.Util.FirstX + MainForm.Util.Xend * MainForm.Util.StepX + MainForm.Util.StepX / 2
        Me.LblXEnd.Text = "XEnd (" & Me.UnityOfMeasurement(Me.TBoxXEnd.Text) & ")"

        Me.HScrollBarYStart.Value = MainForm.Util.Ystart
        Me.TBoxYStart.Text = MainForm.Util.FirstY + MainForm.Util.Ystart * MainForm.Util.Stepy + MainForm.Util.Stepy / 2
        Me.LblYStart.Text = "YStart (" & Me.UnityOfMeasurement(Me.TBoxYStart.Text) & ")"

        Me.HScrollBarYEnd.Value = MainForm.Util.Yend
        Me.TBoxYEnd.Text = MainForm.Util.FirstY + MainForm.Util.Yend * MainForm.Util.Stepy + MainForm.Util.Stepy / 2
        Me.LblYEnd.Text = "YEnd (" & Me.UnityOfMeasurement(Me.TBoxYEnd.Text) & ")"

    End Sub

    'When the user presses the mouse button on the picture box the coordinates of the point are saved
    Private Sub PictureBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseDown

        XStart = e.Location.X
        YStart = e.Location.Y
        MousePressed = True

    End Sub

    'While the mouse is moved on the picture box (and the mouse button is presses) a red rectangle is drawn on it
    Private Sub PictureBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseMove

        Dim X, Y As Double

        If MousePressed Then

            X = e.Location.X
            Y = e.Location.Y
            If X >= Me.PictureBox.Width Then
                X = Me.PictureBox.Width - 1
            ElseIf X < 0 Then
                X = 0
            End If
            If Y >= Me.PictureBox.Height Then
                Y = Me.PictureBox.Height - 1
            ElseIf Y < 0 Then
                Y = 0
            End If

            MainForm.Util.HighLightArea(BM, XStart, YStart, X, Y)
            Me.PictureBox.Image = BM

        End If

    End Sub

    'When the mouse button is realeased there is a zoom on the selected region
    Private Sub PictureBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseUp

        XEnd = e.Location.X
        YEnd = e.Location.Y
        'If the final position is outside the picture box
        If XEnd >= Me.PictureBox.Width Then
            XEnd = Me.PictureBox.Width - 1
        ElseIf XEnd < 1 Then
            XEnd = 1
        End If
        If YEnd >= Me.PictureBox.Height Then
            YEnd = Me.PictureBox.Height - 1
        ElseIf YEnd < 1 Then
            YEnd = 1
        End If

        'the zoom is done only if the initial and final point are different
        If XEnd <> XStart And YEnd <> YStart Then
            Dim oldXend, oldXStart, oldYend, oldYStart As Integer
            oldXend = MainForm.Util.Xend
            oldXStart = MainForm.Util.XStart
            oldYend = MainForm.Util.Yend
            oldYStart = MainForm.Util.Ystart

            'Starting from the initial point the rectangle can be drawn following four different directions. 
            'We have to consider all the four possibilities in order to correctly do the zoom
            If XStart < XEnd Then
                MainForm.Util.XStart = oldXStart + Math.Floor((XStart / Me.PictureBox.Width) * (oldXend - oldXStart + 1))
                MainForm.Util.Xend = oldXStart + Math.Floor((XEnd / Me.PictureBox.Width) * (oldXend - oldXStart + 1))
            Else
                MainForm.Util.Xend = oldXStart + Math.Floor((XStart / Me.PictureBox.Width) * (oldXend - oldXStart + 1))
                MainForm.Util.XStart = oldXStart + Math.Floor((XEnd / Me.PictureBox.Width) * (oldXend - oldXStart + 1))
            End If
            If YStart < YEnd Then
                MainForm.Util.Ystart = oldYStart + Math.Floor(((Me.PictureBox.Height - YEnd) / Me.PictureBox.Height) * (oldYend - oldYStart + 1))
                MainForm.Util.Yend = oldYStart + Math.Floor(((Me.PictureBox.Height - YStart) / Me.PictureBox.Height) * (oldYend - oldYStart + 1))
            Else
                MainForm.Util.Yend = oldYStart + Math.Floor(((Me.PictureBox.Height - YEnd) / Me.PictureBox.Height) * (oldYend - oldYStart + 1))
                MainForm.Util.Ystart = oldYStart + Math.Floor(((Me.PictureBox.Height - YStart) / Me.PictureBox.Height) * (oldYend - oldYStart + 1))
            End If


            ReScaleControls()
            MainForm.Util.DrawGraphic(BM, Me.HScrollBar.Value)
            Me.PictureBox.Image = BM
            UpdateCoordinates()

            'Data on the data analysis tab is changed following the selection the user did
            MainForm.LoadDataAnalysisTab()
        End If

        MousePressed = False

    End Sub

#End Region

#Region "Buttons Functions"

    'It zooms in on the centre of the picture box
    Private Sub BtnSaveANSYS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveAnsys.Click

        'The properties of the SaveFileDialog window are set
        Me.SaveFileDialog.Title = "ANSYS File Path"
        Me.SaveFileDialog.DefaultExt = "txt"
        Me.SaveFileDialog.FileName = "ANSYS-" & MainForm.Util.FileName & ".txt"
        'It allows to choose only the text files
        Me.SaveFileDialog.Filter = "Txt files (*.txt) |*.txt"
        If Me.SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            MainForm.Util.ANSYSFilePath = Me.SaveFileDialog.FileName
            MainForm.Util.WriteANSYSFile()

            MsgBox("The ANSYS file has been successfully created!", MsgBoxStyle.Information, "End of process")
        End If

    End Sub

    'It comes back to the initial plot image
    Private Sub BtnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefault.Click

        'The start and end of the coordinates is set to the maximum interval
        MainForm.Util.XStart = 0
        MainForm.Util.Ystart = 0
        MainForm.Util.Xend = MainForm.Util.NumberX - 1
        MainForm.Util.Yend = MainForm.Util.Numbery - 1
        UpdateCoordinates()


        ReScaleControls()

        'The plot is reset
        MainForm.Util.DrawGraphic(BM, Me.HScrollBar.Value)
        Me.PictureBox.Image = BM
        'Data Analysis tab is reloades
        MainForm.LoadDataAnalysisTab()

    End Sub

    'It saves the plot in an image file
    Private Sub BtnSavePlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePlot.Click

        'The properties of the SaveFileDialog window are set
        Me.SaveFileDialog.Title = "Plot Path"
        Me.SaveFileDialog.DefaultExt = "jpg"
        Me.SaveFileDialog.FileName = MainForm.Util.FileName & " - Section " & (Me.HScrollBar.Value + 1) & ".jpg"
        'It allows to choose only the image files
        Me.SaveFileDialog.Filter = "Image File (*.jpg; *.bmp; *png; *gif ) |*.jpg;*bmp;*png;*gif"
        If Me.SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'Following the inserted extension the file is saved in the different formats
            Select Case Me.SaveFileDialog.FileName.Substring(Me.SaveFileDialog.FileName.LastIndexOf(".") + 1)
                Case "jpg"
                    Me.PictureBox.Image.Save(Me.SaveFileDialog.FileName, Drawing.Imaging.ImageFormat.Jpeg)
                Case "bmp"
                    Me.PictureBox.Image.Save(Me.SaveFileDialog.FileName, Drawing.Imaging.ImageFormat.Bmp)
                Case "png"
                    Me.PictureBox.Image.Save(Me.SaveFileDialog.FileName, Drawing.Imaging.ImageFormat.Png)
                Case "gif"
                    Me.PictureBox.Image.Save(Me.SaveFileDialog.FileName, Drawing.Imaging.ImageFormat.Gif)
            End Select

        End If


    End Sub

    'It shows the sections one after the other
    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click

        If Not TimerSequence.Enabled Then
            Me.BtnShow.Text = "Stop Sequence"
            Me.TimerSequence.Start()
        Else
            Me.BtnShow.Text = "Show all sections"
            Me.TimerSequence.Stop()
        End If

    End Sub

    'The timer is used in order to have a little delay between the charging of consecutives sections
    Private Sub TimerSequence_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSequence.Tick

        BlockEvents = True
        SelectedZ = MainForm.Util.ZCrossSections(Me.HScrollBar.Value)
        Me.TBoxSelectedZ.Text = SelectedZ + 1
        MainForm.Util.DrawGraphic(BM, Me.HScrollBar.Value)
        Me.PictureBox.Image = BM
        If Me.HScrollBar.Value < Me.HScrollBar.Maximum - 9 Then
            Me.HScrollBar.Value += 1
        Else
            Me.BtnShow.Text = "Show all sections"
            TimerSequence.Stop()
        End If
        BlockEvents = False

    End Sub

#End Region


    Private Sub HScrollBarXStart_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBarXStart.Scroll

        If Not BlockEvents Then
            BlockEvents = True
            If e.NewValue <> OldXStart Then
                If e.NewValue < MainForm.Util.Xend Then
                    MainForm.Util.XStart = Me.HScrollBarXStart.Value
                    OldXStart = MainForm.Util.XStart
                    Me.TBoxXStart.Text = MainForm.Util.FirstX + MainForm.Util.XStart * MainForm.Util.StepX + MainForm.Util.StepX / 2
                    Me.LblXStart.Text = "XStart (" & Me.UnityOfMeasurement(Me.TBoxXStart.Text) & ")"
                    ReScaleControls()
                    MainForm.Util.DrawGraphic(BM, Me.HScrollBar.Value)
                    Me.PictureBox.Image = BM
                    'Data on the data analysis tab is changed following the selection the user did
                    'MainForm.LoadDataAnalysisTab()
                Else
                    e.NewValue = e.OldValue
                End If
            End If
            BlockEvents = False
        End If

    End Sub

    Private Sub HScrollBarXEnd_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBarXEnd.Scroll

        If Not BlockEvents Then
            BlockEvents = True
            If e.NewValue <> OldXEnd Then
                If e.NewValue > MainForm.Util.XStart Then
                    MainForm.Util.Xend = Me.HScrollBarXEnd.Value
                    OldXEnd = MainForm.Util.Xend
                    Me.TBoxXEnd.Text = MainForm.Util.FirstX + MainForm.Util.Xend * MainForm.Util.StepX + MainForm.Util.StepX / 2
                    Me.LblXEnd.Text = "XEnd (" & Me.UnityOfMeasurement(Me.TBoxXEnd.Text) & ")"
                    ReScaleControls()
                    MainForm.Util.DrawGraphic(BM, Me.HScrollBar.Value)
                    Me.PictureBox.Image = BM
                    'Data on the data analysis tab is changed following the selection the user did
                    'MainForm.LoadDataAnalysisTab()
                Else
                    e.NewValue = e.OldValue
                End If
            End If
            BlockEvents = False
        End If

    End Sub

    Private Sub HScrollBarYStart_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBarYStart.Scroll

        If Not BlockEvents Then
            BlockEvents = True
            If e.NewValue <> OldYStart Then
                If e.NewValue < MainForm.Util.Yend Then
                    MainForm.Util.Ystart = Me.HScrollBarYStart.Value
                    OldYStart = MainForm.Util.Ystart
                    Me.TBoxYStart.Text = MainForm.Util.FirstY + MainForm.Util.Ystart * MainForm.Util.Stepy + MainForm.Util.Stepy / 2
                    Me.LblYStart.Text = "YStart (" & Me.UnityOfMeasurement(Me.TBoxYStart.Text) & ")"
                    ReScaleControls()
                    MainForm.Util.DrawGraphic(BM, Me.HScrollBar.Value)
                    Me.PictureBox.Image = BM
                    'Data on the data analysis tab is changed following the selection the user did
                    'MainForm.LoadDataAnalysisTab()
                Else
                    e.NewValue = e.OldValue
                End If
            End If
            BlockEvents = False
        End If

    End Sub

    Private Sub HScrollBarYEnd_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBarYEnd.Scroll

        If Not BlockEvents Then
            BlockEvents = True
            If e.NewValue <> OldYEnd Then
                If e.NewValue > MainForm.Util.Ystart Then
                    MainForm.Util.Yend = Me.HScrollBarYEnd.Value
                    OldYEnd = MainForm.Util.Yend
                    Me.TBoxYEnd.Text = MainForm.Util.FirstY + MainForm.Util.Yend * MainForm.Util.Stepy + MainForm.Util.Stepy / 2
                    Me.LblYEnd.Text = "XEnd (" & Me.UnityOfMeasurement(Me.TBoxYEnd.Text) & ")"
                    ReScaleControls()
                    MainForm.Util.DrawGraphic(BM, Me.HScrollBar.Value)
                    Me.PictureBox.Image = BM
                    'Data on the data analysis tab is changed following the selection the user did
                    'MainForm.LoadDataAnalysisTab()
                Else
                    e.NewValue = e.OldValue
                End If
            End If
            BlockEvents = False
        End If

    End Sub

    Private Sub HScrollBarXStart_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HScrollBarXStart.MouseLeave, HScrollBarYStart.MouseLeave, HScrollBarYEnd.MouseLeave, HScrollBarXEnd.MouseLeave
        MainForm.LoadDataAnalysisTab()
    End Sub



End Class