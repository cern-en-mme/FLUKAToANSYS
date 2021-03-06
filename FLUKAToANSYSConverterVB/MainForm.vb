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

Imports System.IO
Imports System.Threading
Imports System.Drawing
Public Class MainForm

#Region "Global Variables"

    'Object of type Utilities. It is used when functions that work on data are needed
    Public Util As New Utilities()
    'A thread is used to make the conversion while the label LblWaiting is changed by the main thread
    Dim ThrdConversion As Thread
    'This constant is used to make the conversion
    Const ElementaryCharge As Double = 1.602176487 * 1.0E-19

    'It is used to know how many sections the user has selected
    Public NumberOfSections As Integer

    'To know if it is the first time the program is loaded
    Dim FirstTime As Boolean = True

    'Variables needed for the conversion
    Dim ConversionIsOver As Boolean
    Dim ConversionWithSuccess As Boolean
    Dim Constant As Double

    'If 0 we are extracting data from the FLUKA file, if 1 we are writing the ANSYS file
    Dim ActualStage As Byte

    'To hide/show the tab pages
    Dim TabPageSingleImpact, TabPageContinuousFlow, TabPageScriptProperties As TabPage
    Dim TabPageDataAnalysis As TabPage

    'The bitmap which is used to draw graphics
    Dim BM As Bitmap

    'To know what cross section the user has selected on the graphic
    Dim SelectedZ As Integer = 0

    'To know if the user has selected the single impact case or the continuous flow
    Public SingleImpact As Boolean = True

    'To know if the material parameters are going to be charged
    Dim ChargingMaterialParameters As Boolean = False

    'To check if it is the first time clicking the Load File button 
    Dim NBtnLoadFirstClick As Boolean = True

#End Region

#Region "Procedures"

    'This is the function that works in background to doing the FLUKA-ANSYS conversion
    Public Sub ThreadTask()

        'Try
        'Matrix where data extracted from FLUKA file is saved
        Util.ExtractData()

        If Util.Data Is Nothing Then

            MsgBox("Data in the selected file is not in the correct format", MsgBoxStyle.Critical, "No Data Found")
            ConversionWithSuccess = False
        Else

            'Data saved in the data array is in Gev/cm3*p. It is converted in W/m3
            Util.ConvertsData(Constant)

            'We pass to the second stage (writing the ANSYS file)
            ActualStage = 1

            Util.WriteANSYSFile()
            Util.WriteScript()
            Util.WriteParam()
            ConversionWithSuccess = True

        End If
        'Catch ex As Exception
        'MsgBox("An error has occured during the conversion", MsgBoxStyle.Critical, "Conversion Aborted")
        'ConversionWithSuccess = False
        'End Try


        'This global variable says to the main thread to stop showing the work in progress label
        ConversionIsOver = True

    End Sub

    'This sub allows the user to choose a txt file, it controls that the file is a FLUKA file and then it reads the header and sets the parametres (Coordinates, number of elements,...)
    Private Sub LoadFromFLUKAFile()

        'This variable is used to read from the txt file
        Dim sr As StreamReader
        'The program selected by the user is checked and if it is a txt or a FLUKA file these variables are changed
        Dim SelectedProgramIsText As Boolean = True
        Dim SelectedProgramIsFLUKA As Boolean = False

        Do
            Do
                Try
                    Me.OpenFileDialog1.Title = "FLUKA File Path"
                    Me.OpenFileDialog1.DefaultExt = ".dat"
                    Me.OpenFileDialog1.FileName = ""
                    Me.OpenFileDialog1.Filter = "Text Files (*.txt, *.dat) |*.txt;*.dat"
                    Me.OpenFileDialog1.ShowDialog()
                    If Me.OpenFileDialog1.FileName = "" Then
                        If FirstTime Then
                            End
                        Else
                            Me.Focus()
                            Exit Sub
                        End If
                    Else
                        Util.FlukaFilePath = Me.OpenFileDialog1.FileName
                    End If
                    sr = New StreamReader(Util.FlukaFilePath)
                Catch ex As Exception
                    MsgBox("The selected file is not a .txt file", MsgBoxStyle.Critical, "Error")
                    SelectedProgramIsText = False
                End Try
            Loop Until SelectedProgramIsText


            Dim XData, YData, ZData As System.Collections.ArrayList

            Dim line As String
            Dim numberLine As Long = 0


            'It keeps the number of lines from which a set of number has been extracted (if the x,y,z data have been extracted this number is three)
            Dim DataExtracted As Byte = 0

            Do
                line = sr.ReadLine()

                If Util.AmountOfNumbersPerLine(line) > 2 And Util.AmountOfNumbersPerLine(line) < 5 Then

                    If DataExtracted = 0 Then
                        XData = Util.ExtractNumbers(line)
                        Me.TBoxXBeginning.Text = Format(Convert.ToDouble(XData(0)), "##0.000000")
                        Me.TBoxXBeginning2.Text = Format(Convert.ToDouble(XData(0)), "##0.000000")
                        Me.TBoxXEnd.Text = Format(Convert.ToDouble(XData(1)), "##0.000000")
                        Me.TBoxXEnd2.Text = Format(Convert.ToDouble(XData(1)), "##0.000000")
                        Me.TBoxXElements.Text = Format(Convert.ToDouble(XData(2)), "##0.000000")
                        Me.TBoxXElements2.Text = Format(Convert.ToDouble(XData(2)), "##0.000000")
                        Me.TBoxXLength.Text = Format(XData(1) - XData(0), "##0.000000")
                        Me.TBoxXLength2.Text = Format(XData(1) - XData(0), "##0.000000")
                        Me.TBoxXStep.Text = Format((XData(1) - XData(0)) / XData(2), "##0.000000")
                        Me.TBoxXStep2.Text = Format((XData(1) - XData(0)) / XData(2), "##0.000000")

                    ElseIf DataExtracted = 1 Then
                        YData = Util.ExtractNumbers(line)
                        Me.TBoxYBeginning.Text = Format(Convert.ToDouble(YData(0)), "##0.000000")
                        Me.TBoxYBeginning2.Text = Format(Convert.ToDouble(YData(0)), "##0.000000")
                        Me.TBoxYEnd.Text = Format(Convert.ToDouble(YData(1)), "##0.000000")
                        Me.TBoxYEnd2.Text = Format(Convert.ToDouble(YData(1)), "##0.000000")
                        Me.TBoxYElements.Text = Format(Convert.ToDouble(YData(2)), "##0.000000")
                        Me.TBoxYElements2.Text = Format(Convert.ToDouble(YData(2)), "##0.000000")
                        Me.TBoxYLength.Text = Format(YData(1) - YData(0), "##0.000000")
                        Me.TBoxYLength2.Text = Format(YData(1) - YData(0), "##0.000000")
                        Me.TBoxYStep.Text = Format((YData(1) - YData(0)) / YData(2), "##0.000000")
                        Me.TBoxYStep2.Text = Format((YData(1) - YData(0)) / YData(2), "##0.000000")

                    ElseIf DataExtracted = 2 Then
                        ZData = Util.ExtractNumbers(line)
                        Me.TBoxZBeginning.Text = Format(Convert.ToDouble(ZData(0)), "##0.000000")
                        Me.TBoxZBeginning2.Text = Format(Convert.ToDouble(ZData(0)), "##0.000000")
                        Me.TBoxZEnd.Text = Format(Convert.ToDouble(ZData(1)), "##0.000000")
                        Me.TBoxZEnd2.Text = Format(Convert.ToDouble(ZData(1)), "##0.000000")
                        Me.TBoxZElements.Text = Format(Convert.ToDouble(ZData(2)), "##0.000000")
                        Me.TBoxZElements2.Text = Format(Convert.ToDouble(ZData(2)), "##0.000000")
                        NumberOfSections = ZData(2)
                        Me.TBoxZLength.Text = Format(ZData(1) - ZData(0), "##0.000000")
                        Me.TBoxZLength2.Text = Format(ZData(1) - ZData(0), "##0.000000")
                        Me.TBoxZStep.Text = Format((ZData(1) - ZData(0)) / ZData(2), "##0.000000")
                        Me.TBoxZStep2.Text = Format((ZData(1) - ZData(0)) / ZData(2), "##0.000000")

                    End If

                    DataExtracted += 1

                End If

                numberLine += 1

            Loop Until DataExtracted = 3 Or line Is Nothing Or numberLine > 50

            sr.Close()

            If DataExtracted = 3 Then
                'Variables used for the conversion
                Util.FirstX = Me.TBoxXBeginning.Text
                Util.StepX = Me.TBoxXStep.Text
                Util.NumberX = Me.TBoxXElements.Text
                Util.FirstY = Me.TBoxYBeginning.Text
                Util.Stepy = Me.TBoxYStep.Text
                Util.Numbery = Me.TBoxYElements.Text
                Util.Firstz = Me.TBoxZBeginning.Text
                Util.Stepz = Me.TBoxZStep.Text
                Util.Numberz = Me.TBoxZElements.Text
                SelectedProgramIsFLUKA = True
                Me.Text = "FLUKAToANSYSConverter - Current File Name: " & Util.FlukaFilePath.Substring(Util.FlukaFilePath.LastIndexOf("\") + 1)
                If (Not FirstTime And Not Me.BtnZCrossSections.Enabled) Then
                    TabPageDataAnalysis = Me.tabControl.TabPages.Item(1)
                    Me.tabControl.TabPages.RemoveAt(0)
                    Me.tabControl.TabPages.RemoveAt(0)
                    Me.tabControl.TabPages.Add(TabPageSingleImpact)
                    Me.tabControl.TabPages.Add(TabPageContinuousFlow)
                    Me.tabControl.TabPages.Add(TabPageScriptProperties)
                    If SingleImpact Then
                        Me.TBoxNBunches.ReadOnly = False
                        Me.TBoxPxBunch.ReadOnly = False
                        Me.TBoxExp.ReadOnly = False
                        Me.TBoxImpactDuration.ReadOnly = False
                        Me.TBoxProbabilityFactor.ReadOnly = False
                        Me.TBoxRoomTemperature.ReadOnly = False
                        Me.CheckBoxConstant.Enabled = True
                        Me.TBoxConstant.ReadOnly = False
                        Me.TBoxExp3.ReadOnly = False
                    Else
                        Me.TboxParticlesxSecond.ReadOnly = False
                        Me.TBoxExp2.ReadOnly = False
                        Me.TBoxProbabilityFactor2.ReadOnly = False
                        Me.CheckBoxConstant2.Enabled = True
                        Me.TBoxConstant2.ReadOnly = False
                        Me.TBoxExp4.ReadOnly = False
                    End If
                End If
                Me.BtnConvert.Enabled = True
                Me.BtnZCrossSections.Enabled = True
                Me.RichTextBox.Text = Util.GetScript
                Me.tabControl.Size = New Size(Me.tabControl.Width, 410)
                Me.GroupBoxActions.Location = New Point(Me.GroupBoxActions.Location.X, Me.tabControl.Height)
                Me.Size = New Size(Me.Size.Width, 515)
            Else
                SelectedProgramIsFLUKA = False
                MsgBox("The selected file is not a FLUKA File", MsgBoxStyle.Critical, "Error")
            End If

        Loop Until SelectedProgramIsFLUKA

        FirstTime = False
        Me.BtnShowPlot.Visible = False

    End Sub

    'It reads all the material named from the database and fills the combo box with them
    Private Sub ChargeMaterials()

        Dim ado As New ADOconnection("Microsoft.ACE.OLEDB.12.0", Application.StartupPath & "\MaterialsData.accdb")
        ado.CreateConnection()
        ado.ExecuteQuery("SELECT MaterialName FROM Data ORDER BY MaterialName")

        Me.ComboBoxMaterial.Items.Clear()
        For i As Integer = 0 To ado.table.Rows.Count - 1
            Me.ComboBoxMaterial.Items.Add(ado.table.Rows(i).Item(0))
        Next
        'This gives the possibility to insert a new material
        Me.ComboBoxMaterial.Items.Add("Other")

    End Sub

    'It fills all the textboxes contained the material properties
    Private Sub ChargeMaterialParameters(ByVal MaterialName As String)

        ChargingMaterialParameters = True

        'We can load the parameters only if the combo box material text is different from "Other"
        If Me.ComboBoxMaterial.Text <> "Other" Then
            'We open the link to the database and we read the information
            Dim ado As New ADOconnection("Microsoft.ACE.OLEDB.12.0", Application.StartupPath & "\MaterialsData.accdb")
            ado.CreateConnection()
            ado.ExecuteQuery("SELECT * FROM Data WHERE MaterialName = '" & MaterialName & "'")

            'We set the text boxes. It is necessary to verify that the value is not empty before to insert it into the utilities object in order to avoid casting problems
            Try
                Me.TBoxDensity.Text = ado.table.Rows(0).Item(1)
            Catch ex As Exception
                Me.TBoxDensity.Text = ""
            End Try
            If Me.TBoxDensity.Text <> "" Then Util.Density = ado.table.Rows(0).Item(1)
            Try
                Me.TBoxHeatCapacity.Text = ado.table.Rows(0).Item(2)
            Catch ex As Exception
                Me.TBoxHeatCapacity.Text = ""
            End Try
            If Me.TBoxHeatCapacity.Text <> "" Then Util.HeatCapacity = ado.table.Rows(0).Item(2)
            Try
                Me.TBoxYoungModulus.Text = ado.table.Rows(0).Item(3)
            Catch ex As Exception
                Me.TBoxYoungModulus.Text = ""
            End Try
            If Me.TBoxYoungModulus.Text <> "" Then Util.YoungModulus = ado.table.Rows(0).Item(3)
            Try
                Me.TBoxPoissonRatio.Text = ado.table.Rows(0).Item(4)
            Catch ex As Exception
                Me.TBoxPoissonRatio.Text = ""
            End Try
            If Me.TBoxPoissonRatio.Text <> "" Then Util.PoissonRatio = ado.table.Rows(0).Item(4)
            Try
                Me.TBoxCoefficientOfThermalExpansion.Text = ado.table.Rows(0).Item(5)
            Catch ex As Exception
                Me.TBoxCoefficientOfThermalExpansion.Text = ""
            End Try
            If Me.TBoxCoefficientOfThermalExpansion.Text <> "" Then Util.CoefficientOfThermalExpansion = ado.table.Rows(0).Item(5)
            Try
                Me.TBoxProofStrength.Text = ado.table.Rows(0).Item(6)
            Catch ex As Exception
                Me.TBoxProofStrength.Text = ""
            End Try
            Try
                Me.TBoxMeltingPoint.Text = ado.table.Rows(0).Item(7)
            Catch ex As Exception
                Me.TBoxMeltingPoint.Text = ""
            End Try
            'All the text boxes are emptied
        Else
            Me.TBoxDensity.Text = ""
            Me.TBoxHeatCapacity.Text = ""
            Me.TBoxYoungModulus.Text = ""
            Me.TBoxPoissonRatio.Text = ""
            Me.TBoxCoefficientOfThermalExpansion.Text = ""
            Me.TBoxMeltingPoint.Text = ""
            Me.TBoxProofStrength.Text = ""
        End If

        ChargingMaterialParameters = False

    End Sub

    'The function returns a boolean value saying if all data necessary to calculate the maximum temperature are available
    'In the case it is not possible the Error message string is filled with the explanation
    Private Function IsPossibleToChargeMaximumTemperature(Optional ByRef ErrorMessage As String = "") As Boolean

        If Me.TBoxDensity.Text = "" Or Me.TBoxDensity.Text = "." Then
            ErrorMessage = "Cannot calculate Max Temperature. Density value is required!"
            Return False
        ElseIf Me.TBoxHeatCapacity.Text = "" Or Me.TBoxHeatCapacity.Text = "." Then
            ErrorMessage = "Cannot calculate Max Temperature. Heat Capacity value is required!"
            Return False
        ElseIf Me.TBoxMeltingPoint.Text = "" Or Me.TBoxMeltingPoint.Text = "." Then
            ErrorMessage = "Cannot calculate Max Temperature. Melting point value is required!"
            Return False
        ElseIf Me.TBoxDensity.Text = "0" Then
            ErrorMessage = "Cannot calculate Max Temperature. Density has to be different than zero!"
            Return False
        ElseIf Me.TBoxHeatCapacity.Text = "0" Then
            ErrorMessage = "Cannot calculate Max Temperature. Heat Capacity has to be different than zero!"
            Return False
        End If

        Return True

    End Function

    'The function returns a boolean value saying if all data necessary to calculate the maximum stress are available
    'In the case it is not possible the Error message string is filled with the explanation
    Private Function IsPossibleToChargeMaximumStress(Optional ByRef ErrorMessage As String = "") As Boolean

        If Me.TBoxTemperature.Text = "" Then
            ErrorMessage = "Cannot calculate Max Stress. Max Temperature value is required!"
            Return False
        ElseIf Me.TBoxYoungModulus.Text = "" Or Me.TBoxYoungModulus.Text = "." Then
            ErrorMessage = "Cannot calculate Max Stress. Young's Modulus value is required!"
            Return False
        ElseIf Me.TBoxCoefficientOfThermalExpansion.Text = "" Or Me.TBoxCoefficientOfThermalExpansion.Text = "." Then
            ErrorMessage = "Cannot calculate Max Stress. CTE value is required!"
            Return False
        ElseIf Me.TBoxProofStrength.Text = "" Or Me.TBoxProofStrength.Text = "." Then
            ErrorMessage = "Cannot calculate Max Stress. Proof Strength value is required!"
            Return False
        End If

        Return True

    End Function

    'It fills the text boxes containing the maximum temperature and stress inside the system and the associated labels
    Private Sub ChargeCriticalPoints()

        Dim ErrorMessage As String = ""

        If Me.IsPossibleToChargeMaximumTemperature(ErrorMessage) Then
            Me.TBoxTemperature.Text = Format(Util.MaximumTemperature, "######0.00")
            If Convert.ToDouble(Me.TBoxTemperature.Text) > Convert.ToDouble(Me.TBoxMeltingPoint.Text) Then
                Me.LblTemperature.Text = "Temperature greater than the melting point!"
                Me.LblTemperature.ForeColor = Color.Red
            Else
                Me.LblTemperature.Text = ""
            End If
        Else
            Me.LblTemperature.Text = ErrorMessage
            Me.LblTemperature.ForeColor = Color.DarkRed
            Me.TBoxTemperature.Text = ""
        End If

        If Me.IsPossibleToChargeMaximumStress(ErrorMessage) Then
            Me.TBoxStress.Text = Format(Util.MaximumStress, "######0.00")
            If Convert.ToDouble(Me.TBoxStress.Text) > Convert.ToDouble(Me.TBoxProofStrength.Text) Then
                Me.LblStress.Text = "Stress greater than the Yield Point!"
                Me.LblStress.ForeColor = Color.Red
            Else
                Me.LblStress.Text = ""
            End If
        Else
            Me.LblStress.Text = ErrorMessage
            Me.LblStress.ForeColor = Color.DarkRed
            Me.TBoxStress.Text = ""
        End If

    End Sub

    'It sets the power value for the section whose number is passed as parameter and correctly sets the unit of measurement
    Private Sub SetPower(ByVal SelectedZ As Integer)

        Dim totalDepositedPowerPerSection As Double = Util.TotalDepositedPowerPerSection(SelectedZ)
        If totalDepositedPowerPerSection > 10 ^ 24 Then
            totalDepositedPowerPerSection /= 10 ^ 24
            Me.LblWatt.Text = "YW"
        ElseIf totalDepositedPowerPerSection > 10 ^ 21 Then
            totalDepositedPowerPerSection /= 10 ^ 21
            Me.LblWatt.Text = "ZW"
        ElseIf totalDepositedPowerPerSection > 10 ^ 18 Then
            totalDepositedPowerPerSection /= 10 ^ 18
            Me.LblWatt.Text = "EW"
        ElseIf totalDepositedPowerPerSection > 10 ^ 15 Then
            totalDepositedPowerPerSection /= 10 ^ 15
            Me.LblWatt.Text = "PW"
        ElseIf totalDepositedPowerPerSection > 10 ^ 12 Then
            totalDepositedPowerPerSection /= 10 ^ 12
            Me.LblWatt.Text = "TW"
        ElseIf totalDepositedPowerPerSection > 10 ^ 9 Then
            totalDepositedPowerPerSection /= 10 ^ 9
            Me.LblWatt.Text = "GW"
        ElseIf totalDepositedPowerPerSection > 10 ^ 6 Then
            totalDepositedPowerPerSection /= 10 ^ 6
            Me.LblWatt.Text = "MW"
        ElseIf totalDepositedPowerPerSection > 10 ^ 3 Then
            totalDepositedPowerPerSection /= 10 ^ 3
            Me.LblWatt.Text = "KW"
        ElseIf totalDepositedPowerPerSection > 0 Then
            Me.LblWatt.Text = "W"
        ElseIf totalDepositedPowerPerSection > 10 ^ -3 Then
            totalDepositedPowerPerSection /= 10 ^ -3
            Me.LblWatt.Text = "mW"
        ElseIf totalDepositedPowerPerSection > 10 ^ -6 Then
            totalDepositedPowerPerSection /= 10 ^ -6
            Me.LblWatt.Text = "μW"
        ElseIf totalDepositedPowerPerSection > 10 ^ -9 Then
            totalDepositedPowerPerSection /= 10 ^ -9
            Me.LblWatt.Text = "nW"
        ElseIf totalDepositedPowerPerSection > 10 ^ -12 Then
            totalDepositedPowerPerSection /= 10 ^ -12
            Me.LblWatt.Text = "pW"
        ElseIf totalDepositedPowerPerSection > 10 ^ -15 Then
            totalDepositedPowerPerSection /= 10 ^ -15
            Me.LblWatt.Text = "fW"
        ElseIf totalDepositedPowerPerSection > 10 ^ -18 Then
            totalDepositedPowerPerSection /= 10 ^ -18
            Me.LblWatt.Text = "aW"
        ElseIf totalDepositedPowerPerSection > 10 ^ -21 Then
            totalDepositedPowerPerSection /= 10 ^ -21
            Me.LblWatt.Text = "zW"
        ElseIf totalDepositedPowerPerSection > 10 ^ -24 Then
            totalDepositedPowerPerSection /= 10 ^ -24
            Me.LblWatt.Text = "yW"
        Else
            Me.TBoxPower.Text = Format(totalDepositedPowerPerSection, "E")
            Me.LblWatt.Text = "W"
            Exit Sub
        End If
        Me.TBoxPower.Text = Format(totalDepositedPowerPerSection, "##0.000000")

    End Sub

    'It sets the label below the graphic which indicates the distance from the origin
    Private Sub SetDistance()
        Dim Distance As Double = Util.Firstz + Util.Stepz * (Me.TBoxSection.Text - 1) + Util.Stepz / 2

        If Math.Abs(Distance) >= 100 Then
            Distance /= 100
            Me.LblCm.Text = "(" & Distance & " m)"
        ElseIf Math.Abs(Distance) >= 1 Then
            Me.LblCm.Text = "(" & Distance & " cm)"
        ElseIf Math.Abs(Distance) >= 0.01 Then
            Distance *= 10
            Me.LblCm.Text = "(" & Distance & " mm)"
        ElseIf Math.Abs(Distance) >= 0.0001 Then
            Distance *= 10000
            Me.LblCm.Text = "(" & Distance & " μm)"
        ElseIf Math.Abs(Distance) >= 10 ^ -7 Then
            Distance *= 10 ^ 7
            Me.LblCm.Text = "(" & Distance & " nm)"
        ElseIf Math.Abs(Distance) >= 10 ^ -10 Then
            Distance *= 10 ^ 10
            Me.LblCm.Text = "(" & Distance & " pm)"
        ElseIf Math.Abs(Distance) = 0 Then
            Me.LblCm.Text = "Origin"
        Else
            Distance *= 10 ^ 13
            Me.LblCm.Text = "(" & Distance & " fm)"
        End If

    End Sub

    'The sub fills the text boxes and the plot on the DataAnalysis TabPage
    Public Sub LoadDataAnalysisTab()

        Dim TotalDepositedPowerPerM3 As Double = Util.TotalDepositedPowerPerM3
        Dim MaximumDepositedPowerPerM3 As Double = Util.MaximumValue
        Dim TotalDepositedPower As Double = Util.TotalDepositedPower
        Dim MaximumDepositedPower As Double = Util.MaximumPowerValue
        Dim MaximumDepositedEnergyPerCm3 As Double = MaximumDepositedPowerPerM3 * Util.ImpactDuration * 10 ^ -6
        Dim Volume As Double = Util.Volume
        Dim UnityOfVolume As Double = Util.UnityOfVolume

        Dim exp As Integer
        Dim Value As String

        'We set the total deposited power per m3 text box
        If TotalDepositedPowerPerM3 <> 0 Then
            exp = Math.Floor(Math.Log10(TotalDepositedPowerPerM3))
        Else
            exp = 0
        End If
        Value = Convert.ToString(TotalDepositedPowerPerM3 / Math.Pow(10, exp))
        If Value.Length > 9 Then
            Me.TBoxTotDepPowm3.Text = Value.Substring(0, 10)
        Else
            Me.TBoxTotDepPowm3.Text = Value
        End If
        Me.TBoxTotDepPowm3Exp.Text = exp

        'We set the total deposited power textbox
        If TotalDepositedPower <> 0 Then
            exp = Math.Floor(Math.Log10(TotalDepositedPower))
        Else
            exp = 0
        End If
        Value = Convert.ToString(TotalDepositedPower / Math.Pow(10, exp))
        If Value.Length > 9 Then
            Me.TBoxTotDepPow.Text = Value.Substring(0, 10)
        Else
            Me.TBoxTotDepPow.Text = Value
        End If
        Me.TBoxTotDepPowExp.Text = exp

        'We set the Maximum deposited power per m3 textbox
        If MaximumDepositedPowerPerM3 <> 0 Then
            exp = Math.Floor(Math.Log10(MaximumDepositedPowerPerM3))
        Else
            exp = 0
        End If
        Value = Convert.ToString(MaximumDepositedPowerPerM3 / Math.Pow(10, exp))
        If Value.Length > 9 Then
            Me.TBoxMaxDepPowm3.Text = Value.Substring(0, 10)
        Else
            Me.TBoxMaxDepPowm3.Text = Value
        End If
        Me.TBoxMaxDepPowm3Exp.Text = exp

        'We set the Maximum deposited power textbox
        If MaximumDepositedPowerPerM3 <> 0 Then
            exp = Math.Floor(Math.Log10(MaximumDepositedPower))
        Else
            exp = 0
        End If
        Value = Convert.ToString(MaximumDepositedPower / Math.Pow(10, exp))
        If Value.Length > 9 Then
            Me.TBoxMaxDepPow.Text = Value.Substring(0, 10)
        Else
            Me.TBoxMaxDepPow.Text = Value
        End If
        Me.TBoxMaxDepPowExp.Text = exp

        'We set the Maximum deposited energy textbox
        If SingleImpact Then
            Me.TBoxMaxDepEn.Visible = True
            Me.TBoxMaxDepEnExp.Visible = True
            Me.Label74.Visible = True
            Me.Label75.Visible = True
            Me.Label76.Visible = True
            If MaximumDepositedEnergyPerCm3 <> 0 Then
                exp = Math.Floor(Math.Log10(MaximumDepositedEnergyPerCm3))
            Else
                exp = 0
            End If
            Value = Convert.ToString(MaximumDepositedEnergyPerCm3 / Math.Pow(10, exp))
            If Value.Length > 9 Then
                Me.TBoxMaxDepEn.Text = Value.Substring(0, 10)
            Else
                Me.TBoxMaxDepEn.Text = Value
            End If
            Me.TBoxMaxDepEnExp.Text = exp
        Else
            Me.TBoxMaxDepEn.Visible = False
            Me.TBoxMaxDepEnExp.Visible = False
            Me.Label74.Visible = False
            Me.Label75.Visible = False
            Me.Label76.Visible = False
        End If

        'We set the element volume text box
        exp = Math.Floor(Math.Log10(UnityOfVolume))
        Value = Convert.ToString(UnityOfVolume / Math.Pow(10, exp))
        If Value.Length > 9 Then
            Me.TBoxVolume.Text = Value.Substring(0, 10)
        Else
            Me.TBoxVolume.Text = Value
        End If
        Me.TBoxvolumeExp.Text = exp

        'We set the total volume text box
        exp = Math.Floor(Math.Log10(Volume))
        Value = Convert.ToString(Volume / Math.Pow(10, exp))
        If Value.Length > 9 Then
            Me.TBoxTotalVolume.Text = Value.Substring(0, 10)
        Else
            Me.TBoxTotalVolume.Text = Value
        End If
        Me.TBoxTotalVolumeExp.Text = exp



        BM = New Bitmap(Me.PictureBox.Width, Me.PictureBox.Height)

        'The plot with deposited power per section is drawn
        Util.DrawPowerGraphic(BM)
        Me.PictureBox.Image = BM

        'We set the maximum value of the scrollbar and we initialize the properties linked to it
        Me.HScrollBar.Maximum = Util.ZCrossSections.Length + Me.HScrollBar.LargeChange - 2
        Me.HScrollBar.Value = 0
        Me.TBoxSection.Text = 1
        Me.SetDistance()
        SelectedZ = 0
        SetPower(SelectedZ)

        If SingleImpact Then
            ChargeMaterials()
            Me.ComboBoxMaterial.SelectedIndex = 0
            ChargeMaterialParameters(Me.ComboBoxMaterial.Items(0))
            ChargeCriticalPoints()
            Me.GroupBoxMaterial.Visible = True
            Me.GroupBoxCriticalPoints.Visible = True
            Me.GroupBoxPower.Location = New Point(7, Me.GroupBoxPower.Location.Y)
            Me.GroupBoxGraphic.Location = New Point(7, Me.GroupBoxGraphic.Location.Y)
        Else
            Me.GroupBoxMaterial.Visible = False
            Me.GroupBoxCriticalPoints.Visible = False
            Me.GroupBoxPower.Location = New Point(200, Me.GroupBoxPower.Location.Y)
            Me.GroupBoxGraphic.Location = New Point(200, Me.GroupBoxGraphic.Location.Y)
        End If

        'It resizes the form and its components
        Me.tabControl.Size = New Size(Me.tabControl.Width, 550)
        Me.GroupBoxActions.Location = New Point(Me.GroupBoxActions.Location.X, Me.tabControl.Height + 1)
        Me.Size = New Size(Me.Size.Width, 660)



    End Sub


#End Region

#Region "Event Handlers"

    'During the Form Load the header of the file is read to get data necessary for the conversion (XBeginning, Xend, XElements, ..... )
    'Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    LoadFromFLUKAFile()
    '    'The Z Cross Section property is set by default to contain all sections
    '    Dim DefaultZVector() As Integer
    '    ReDim DefaultZVector(NumberOfSections - 1)
    '    For i As Integer = 0 To NumberOfSections - 1
    '        DefaultZVector(i) = i
    '    Next
    '    Util.ZCrossSections = DefaultZVector

    '    'The parametres for the Script File are automatically set and the RichTextBox in the ScriptProperties TabPage is initialized
    '    Util.TableName = "EnergyDep"
    '    Util.FlukaInputCS = 14
    '    Me.RichTextBox.Text = Util.GetScript

    '    'The limits for the Plot PictureBox
    '    Util.MaxWidth = 680
    '    Util.MaxHeight = 380

    '    'The Tab Pages are saved and the ones which don't have to be shown (the last) are erased
    '    TabPageSingleImpact = Me.tabPage1
    '    TabPageContinuousFlow = Me.tabPage2
    '    TabPageScriptProperties = Me.TabPage3
    '    TabPageDataAnalysis = Me.TabPage4
    '    Me.tabControl.TabPages.RemoveAt(3)

    'End Sub

    'The sub calls the secondary thread that makes the ANSYS file and manages the Waiting Label
    Private Sub BtnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConvert.Click

        'The properties of the SaveFileDialog window are set
        Me.SaveFileDialog.Title = "ANSYS File Path"
        Me.SaveFileDialog.DefaultExt = "txt"
        Me.SaveFileDialog.FileName = "ANSYS-" & Util.FileName & ".txt"
        'It allows to choose only the text files
        Me.SaveFileDialog.Filter = "Txt files (*.txt) |*.txt"

        If Me.SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Util.ANSYSFilePath = Me.SaveFileDialog.FileName

            'Set the start time
            Dim inizio As New Date
            inizio = Date.Now

            'These variables say that the conversion is in progress (so the label Waiting is shown) and that the actual step is 0 (reading from FLUKA file)
            ConversionIsOver = False
            ActualStage = 0

            'The conversion Constant is calculated

            If Me.tabControl.SelectedIndex = 0 Then

                'Single Impact case
                SingleImpact = True

                If Me.CheckBoxConstant.Checked Then
                    Constant = Me.TBoxConstant.Text * Math.Pow(10, Me.TBoxExp3.Text)
                    Util.ImpactDuration = Me.TBoxImpactDuration.Text * Math.Pow(10, -6)
                    Util.RoomTemperature = Me.TBoxRoomTemperature.Text
                Else
                    Dim NumberOfBunches As Integer = Me.TBoxNBunches.Text
                    Dim NumberOfParticlesPerBunch As Long = Me.TBoxPxBunch.Text * Math.Pow(10, Me.TBoxExp.Text)
                    Dim InteractionTime As Double = Me.TBoxImpactDuration.Text * Math.Pow(10, -6)
                    Util.ImpactDuration = InteractionTime
                    Util.RoomTemperature = Me.TBoxRoomTemperature.Text
                    Dim ProbabilityFactor As Double = Me.TBoxProbabilityFactor.Text / 100
                    Dim NumberOfParticlesPerSecond As Long = Me.TBoxPxBunch.Text * Math.Pow(10, Me.TBoxExp.Text)
                    Constant = ElementaryCharge * Math.Pow(10, 6) * Math.Pow(10, 9) * NumberOfBunches * NumberOfParticlesPerBunch * ProbabilityFactor / InteractionTime
                End If

            Else

                'Continuous Flow case
                SingleImpact = False

                If Me.CheckBoxConstant2.Checked Then
                    Constant = Me.TBoxConstant2.Text * Math.Pow(10, Me.TBoxExp4.Text)
                Else
                    Dim NumberOfParticlesPerSecond As Long = Me.TboxParticlesxSecond.Text * Math.Pow(10, Me.TBoxExp2.Text)
                    Dim ProbabilityFactor As Double = Me.TBoxProbabilityFactor2.Text / 100
                    Constant = ElementaryCharge * Math.Pow(10, 6) * Math.Pow(10, 9) * NumberOfParticlesPerSecond * ProbabilityFactor
                End If

            End If

            'The thread who manages the conversion starts
            Me.ThrdConversion = New Thread(AddressOf ThreadTask)
            Me.ThrdConversion.IsBackground = True
            Me.ThrdConversion.Start()

            Dim NumberOfdots As Byte = 0
            Dim LabelHasChanged As Boolean = False

            LblWaiting.Text = "Extracting data from FLUKA File"
            BtnShowPlot.Visible = False
            LblWaiting.Visible = True

            'To avoid graphic problems
            Me.Refresh()

            'To avoid that the user press a button while the conversion is in progress
            Me.BtnConvert.Enabled = False
            Me.BtnZCrossSections.Enabled = False
            Me.BtnLoad.Enabled = False

            'This loop changes the Label Waiting text and the number of dots
            Do

                'The loop checks the number of dots
                For i As Integer = 0 To LblWaiting.Text.Length - 1
                    If LblWaiting.Text(i) = "." Then
                        NumberOfdots += 1
                    End If
                Next

                'If the dots are five they are erased, otherwise another dot is added
                If NumberOfdots = 5 Then
                    LblWaiting.Text = LblWaiting.Text.Remove(LblWaiting.Text.Length - 5)
                    GroupBoxActions.Refresh()
                Else
                    LblWaiting.Text &= "."
                End If

                NumberOfdots = 0

                'This "If" block checks if the secondary thread has started to write the ANSYS file and in that case changes the label
                If Not LabelHasChanged Then
                    If ActualStage = 1 Then
                        LblWaiting.Text = "Creating the ANSYS File"
                        GroupBoxActions.Refresh()
                        LabelHasChanged = True
                    End If
                End If

                LblWaiting.Refresh()

                'This loop is repeated every 300ms
                Thread.Sleep(300)

            Loop Until ConversionIsOver

            If ConversionWithSuccess Then

                BtnShowPlot.Visible = True
                Me.BtnZCrossSections.Enabled = False
                Me.BtnConvert.Enabled = False
                TabPageSingleImpact = Me.tabControl.TabPages.Item(0)
                TabPageContinuousFlow = Me.tabControl.TabPages.Item(1)
                TabPageScriptProperties = Me.tabControl.TabPages.Item(2)
                Me.tabControl.TabPages.RemoveAt(2)

                If SingleImpact Then
                    Me.tabControl.TabPages.RemoveAt(1)
                    Me.TBoxNBunches.ReadOnly = True
                    Me.TBoxPxBunch.ReadOnly = True
                    Me.TBoxExp.ReadOnly = True
                    Me.TBoxImpactDuration.ReadOnly = True
                    Me.TBoxProbabilityFactor.ReadOnly = True
                    Me.TBoxConstant.ReadOnly = True
                    Me.TBoxExp3.ReadOnly = True
                    Me.TBoxRoomTemperature.ReadOnly = True
                    Me.CheckBoxConstant.Enabled = False
                Else
                    Me.TboxParticlesxSecond.ReadOnly = True
                    Me.TBoxExp2.ReadOnly = True
                    Me.TBoxProbabilityFactor2.ReadOnly = True
                    Me.TBoxConstant2.ReadOnly = True
                    Me.TBoxExp4.ReadOnly = True
                    Me.CheckBoxConstant2.Enabled = False
                    Me.tabControl.TabPages.RemoveAt(0)
                End If

                Me.tabControl.TabPages.Add(TabPageDataAnalysis)
                Me.LoadDataAnalysisTab()
                Me.tabControl.SelectedIndex = 1

                'The Waiting Label is hidden
                LblWaiting.Visible = False
                Me.BtnLoad.Enabled = True

                'Set the finish time
                Dim fine As New Date
                fine = Date.Now
                Dim ElapsedTime As Decimal = ((fine.Hour - inizio.Hour) * 3600000 + (fine.Minute - inizio.Minute) * 60000 + (fine.Second - inizio.Second) * 1000 + (fine.Millisecond - inizio.Millisecond)) / 1000
                MsgBox("The conversion has been successfully completed (" & ElapsedTime & " s)", MsgBoxStyle.Information, "End of conversion")

            Else

                Me.BtnConvert.Enabled = True
                Me.BtnZCrossSections.Enabled = True

            End If

        End If

    End Sub

    'This sub acts exactly like the FormLoad
    Private Sub BtnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLoad.Click

        If NBtnLoadFirstClick Then

            LoadFromFLUKAFile()

            'The Z Cross Section property is set by default to contain all sections
            Dim DefaultZVector() As Integer
            ReDim DefaultZVector(NumberOfSections - 1)
            For i As Integer = 0 To NumberOfSections - 1
                DefaultZVector(i) = i
            Next
            Util.ZCrossSections = DefaultZVector

            'The parametres for the Script File are automatically set and the RichTextBox in the ScriptProperties TabPage is initialized
            Util.TableName = "EnergyDep"
            Util.FLUKAInputCS = 14
            Me.RichTextBox.Text = Util.GetScript

            'The limits for the Plot PictureBox
            Util.MaxWidth = 680
            Util.MaxHeight = 380

            'The Tab Pages are saved and the ones which don't have to be shown (the last) are erased
            TabPageSingleImpact = Me.tabPage1
            TabPageContinuousFlow = Me.tabPage2
            TabPageScriptProperties = Me.TabPage3
            TabPageDataAnalysis = Me.TabPage4
            Me.tabControl.TabPages.RemoveAt(3)

            NBtnLoadFirstClick = False

        Else

            Plot.Close()

            LoadFromFLUKAFile()

            'The Z Cross Section property is set by default to contain all sections
            Dim DefaultZVector() As Integer
            ReDim DefaultZVector(NumberOfSections - 1)
            For i As Integer = 0 To NumberOfSections - 1
                DefaultZVector(i) = i
            Next
            Util.ZCrossSections = DefaultZVector
            ZCrossSectionSelection.Close()

        End If


    End Sub

    'It opens the form used to choose what Z Cross Sections save in the ANSYS File
    Private Sub BtnZCrossSections_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZCrossSections.Click
        ZCrossSectionSelection.ShowDialog()
    End Sub

    'It opens the Form that draws the plot of the ANSYS file
    Private Sub BtnShowPlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowPlot.Click
        Plot.Show()
    End Sub

    'The 2 subs hides and shows the various textboxes when the CheckBox "Conversion Constant" is checked
    Private Sub CheckBoxConstant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxConstant.CheckedChanged
        If Me.CheckBoxConstant.Checked Then
            Me.TBoxExp.Enabled = False
            Me.TBoxProbabilityFactor.Enabled = False
            Me.TBoxPxBunch.Enabled = False
            Me.TBoxNBunches.Enabled = False
            Me.TBoxConstant.Enabled = True
            Me.TBoxExp3.Enabled = True
        Else
            Me.TBoxExp.Enabled = True
            Me.TBoxProbabilityFactor.Enabled = True
            Me.TBoxPxBunch.Enabled = True
            Me.TBoxNBunches.Enabled = True
            Me.TBoxConstant.Enabled = False
            Me.TBoxExp3.Enabled = False
        End If
    End Sub

    'When the checkBox Conversion is checked the textBoxes above have to be hidden
    Private Sub CheckBoxConversion2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxConstant2.CheckedChanged

        If Me.CheckBoxConstant2.Checked Then
            Me.TBoxProbabilityFactor2.Enabled = False
            Me.TboxParticlesxSecond.Enabled = False
            Me.TBoxExp2.Enabled = False
            Me.TBoxConstant2.Enabled = True
            Me.TBoxExp4.Enabled = True
        Else
            Me.TBoxProbabilityFactor2.Enabled = True
            Me.TboxParticlesxSecond.Enabled = True
            Me.TBoxExp2.Enabled = True
            Me.TBoxConstant2.Enabled = False
            Me.TBoxExp4.Enabled = False
        End If
    End Sub

#Region "Data Analysis"

    'It changes the values of textboxes below the graphic when the scroll bar is used
    Private Sub HScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar.Scroll

        If Me.HScrollBar.Value <> SelectedZ Then
            SelectedZ = Me.HScrollBar.Value
            Me.TBoxSection.Text = Util.ZCrossSections(SelectedZ) + 1
            Me.SetDistance()
            Me.SetPower(SelectedZ)
            BM = New Bitmap(Me.PictureBox.Width, Me.PictureBox.Height)
            Util.HighLightPoint(BM, SelectedZ)
            Me.PictureBox.Image = BM
        End If

    End Sub

    'It highlights a certain point on the graphic when the user clicks on it
    Private Sub PictureBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseDown
        If e.Location.X >= Me.PictureBox.Width - 10 Then
            SelectedZ = Util.ZCrossSections.Length - 1
        ElseIf e.Location.X < 10 Then
            SelectedZ = 0
        Else
            SelectedZ = (e.Location.X - 10) / (Me.PictureBox.Width - 20) * Util.ZCrossSections.Length
        End If
        Me.HScrollBar.Value = SelectedZ
        Me.TBoxSection.Text = Util.ZCrossSections(SelectedZ) + 1
        Me.SetDistance()
        Me.SetPower(SelectedZ)
        BM = New Bitmap(Me.PictureBox.Width, Me.PictureBox.Height)
        Util.HighLightPoint(BM, SelectedZ)
        Me.PictureBox.Image = BM

    End Sub

    'It charges the material properties every time the user chooses a new material from the combo box
    Private Sub ComboBoxMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMaterial.SelectedIndexChanged
        If Not FirstTime Then
            Me.ChargeMaterialParameters(sender.text)
            Me.ChargeCriticalPoints()
        End If
    End Sub

    'To save changes to material properties in the database
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Dim MaterialName As String = ""
        Dim SqlString As String = ""
        Dim AlreadyInserted As Boolean = False

        'If there is a new material we have to insert a new record in the database
        If Me.ComboBoxMaterial.Text = "Other" Then
            MaterialName = InputBox("Insert the new material name: ", "New Material")
            If MaterialName = "" Then
                Exit Sub
            Else
                SqlString = "INSERT INTO Data (MaterialName,Density,HeatCapacity,YoungModulus,PoissonRatio,CoefficientOfThermalExpansion,ProofStrength,MeltingPoint) VALUES ('" & MaterialName & "','" & Me.TBoxDensity.Text & "','" & Me.TBoxHeatCapacity.Text & "','" & Me.TBoxYoungModulus.Text & "','" & Me.TBoxPoissonRatio.Text & "','" & Me.TBoxCoefficientOfThermalExpansion.Text & "','" & Me.TBoxProofStrength.Text & "','" & Me.TBoxMeltingPoint.Text & "')"
            End If

            'We insert the New material in the combo box
            Dim i As Integer = 0
            While MaterialName > Me.ComboBoxMaterial.Items(i)
                i += 1
                'The new material is alphabetically after all the others
                If i = Me.ComboBoxMaterial.Items.Count Then
                    Me.ComboBoxMaterial.Items.Add(MaterialName)
                    AlreadyInserted = True
                End If
            End While

            'The new material has to be inserted in the middle of the combo box
            If Not AlreadyInserted Then
                Me.ComboBoxMaterial.Text = MaterialName
                Me.ComboBoxMaterial.Items.Insert(i, MaterialName)
            End If

            'The material is already in the database. We update it
        Else
            If MsgBox("Are you really sure you want to change the " & Me.ComboBoxMaterial.Text & " parametres?", MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                MaterialName = Me.ComboBoxMaterial.Text
                SqlString = "UPDATE Data SET Density = '" & Me.TBoxDensity.Text & "', HeatCapacity = '" & Me.TBoxHeatCapacity.Text & "', YoungModulus = '" & Me.TBoxYoungModulus.Text & "', PoissonRatio = '" & Me.TBoxPoissonRatio.Text & "', CoefficientOfthermalExpansion = '" & Me.TBoxCoefficientOfThermalExpansion.Text & "',ProofStrength = '" & Me.TBoxProofStrength.Text & "', MeltingPoint = '" & Me.TBoxMeltingPoint.Text & "' WHERE MaterialName = '" & MaterialName & "'"
            Else
                Exit Sub
            End If

        End If

        'We open the connection to the database
        Dim ado As New ADOconnection("Microsoft.ACE.OLEDB.12.0", Application.StartupPath & "\MaterialsData.accdb")
        ado.CreateConnection()

        'We actually add/modify the record
        ado.ExecuteNoQuery(SqlString)

        Me.ComboBoxMaterial.Text = MaterialName

    End Sub

    'It removes the selected material from the database
    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click

        If Me.ComboBoxMaterial.Text <> "Other" Then
            If MsgBox("Are you really sure you want to remove " & Me.ComboBoxMaterial.Text & " from the database?", MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                'We open the connection to the database
                Dim ado As New ADOconnection("Microsoft.ACE.OLEDB.12.0", Application.StartupPath & "\MaterialsData.accdb")
                ado.CreateConnection()

                'We actually remove the record
                ado.ExecuteNoQuery("DELETE * FROM Data WHERE MaterialName = '" & Me.ComboBoxMaterial.Text & "'")

                'We remove the material name from the list and we set the selected item as the first
                Me.ComboBoxMaterial.Items.RemoveAt(Me.ComboBoxMaterial.SelectedIndex)
                Me.ComboBoxMaterial.SelectedIndex = 0


            End If
        End If



    End Sub

    Private Sub TBoxDensity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxDensity.TextChanged, TBoxYoungModulus.TextChanged, TBoxProofStrength.TextChanged, TBoxPoissonRatio.TextChanged, TBoxMeltingPoint.TextChanged, TBoxHeatCapacity.TextChanged, TBoxCoefficientOfThermalExpansion.TextChanged

        If Not ChargingMaterialParameters Then

            If sender.text <> "" Then
                Select Case sender.name
                    Case "TboxDensity"
                        Util.Density = sender.text
                    Case "TBoxHeatCapacity"
                        Util.HeatCapacity = sender.text
                    Case "TBoxCoefficientOfThermalExpansion"
                        Util.CoefficientOfThermalExpansion = sender.text
                    Case "TBoxYoungModulus"
                        Util.YoungModulus = sender.text
                    Case "TBoxPoissonRatio"
                        Util.PoissonRatio = sender.text
                End Select
            End If
            Me.ChargeCriticalPoints()

        End If

    End Sub

#End Region

#End Region

#Region "TextBox Controls"
    'These sub are to avoid that the user inserts letters or numbers not in the correct format

    Private Sub TBoxNBunches_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBoxNBunches.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8)) Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(8) And sender.text.length() > 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBoxExp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBoxExp.KeyPress, TBoxExp2.KeyPress, TBoxExp4.KeyPress, TBoxExp3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8) Or e.KeyChar = "-") Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(8) And sender.text.length() > 2 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBoxPxBunch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBoxPxBunch.KeyPress, TboxParticlesxSecond.KeyPress, TBoxConstant2.KeyPress, TBoxConstant.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(46)) Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(8) And sender.text.length() > 10 Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(46) And e.KeyChar <> Chr(8) And Not sender.text.contains(".") And sender.text.length() = 1 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            If sender.text.indexof(".") <> -1 Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub TBoxImpactDuration_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBoxImpactDuration.KeyPress, TBoxRoomTemperature.KeyPress, TBoxYoungModulus.KeyPress, TBoxProofStrength.KeyPress, TBoxPoissonRatio.KeyPress, TBoxMeltingPoint.KeyPress, TBoxHeatCapacity.KeyPress, TBoxDensity.KeyPress, TBoxCoefficientOfThermalExpansion.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(46)) Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(8) And sender.text.length() > 10 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            If sender.text.indexof(".") <> -1 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TBoxProbabilityFactor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBoxProbabilityFactor.KeyPress, TBoxProbabilityFactor2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8)) Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(8) And sender.text.length() > 2 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBoxExp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxExp.TextChanged, TBoxExp2.TextChanged
        If sender.text.lastindexof("-") <> 0 And sender.text.lastindexof("-") <> -1 Then
            sender.text = sender.text.remove(sender.text.lastindexof("-"), 1)
        End If
    End Sub

    Private Sub TBoxNBunches_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxNBunches.Leave, TBoxPxBunch.Leave, TBoxProbabilityFactor.Leave, TBoxExp.Leave, TBoxProbabilityFactor2.Leave, TboxParticlesxSecond.Leave, TBoxExp2.Leave, TBoxExp4.Leave, TBoxExp3.Leave, TBoxConstant2.Leave, TBoxConstant.Leave
        If sender.text = "" Then sender.text = "0"
    End Sub

    Private Sub TBoxImpactDuration_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxImpactDuration.Leave
        If sender.text = "" Then sender.text = "1"
    End Sub

    Private Sub TBoxFLUKACS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBoxFlukaCS.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8)) Then
            e.Handled = True
        ElseIf e.KeyChar <> Chr(8) And sender.text.length() > 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBoxFLUKACS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxFlukaCS.TextChanged
        If sender.text <> "" Then
            Util.FlukaInputCS = sender.text
            Me.RichTextBox.Text = Util.GetScript
        End If
    End Sub

    Private Sub TBoxTableName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxTableName.TextChanged

        Util.TableName = sender.text
        Me.RichTextBox.Text = Util.GetScript

    End Sub

    Private Sub TBoxFLUKACS_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBoxFlukaCS.Leave
        If sender.text = "" Then
            sender.text = 1
            Util.FlukaInputCS = 1
            Me.RichTextBox.Text = Util.GetScript
        End If
    End Sub

#End Region

End Class
