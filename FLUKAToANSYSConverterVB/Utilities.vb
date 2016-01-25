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
Imports System.Drawing

Public Class Utilities

#Region "Private Variables"

    Dim ZVector() As Integer
    Dim vFLUKAFilePath, vANSYSFilePath, vScriptFilePath As String
    Dim vData() As Double
    Dim vFirstX, vFirstY, vFirstZ As Double
    Dim vStepX, vStepY, vStepZ As Double
    Dim vNumberX, vNumberY, vNumberZ As Double
    Dim vFLUKAInputCS As Integer
    Dim vTableName As String
    Dim Margin As Integer = 10
    Dim OriginalPowerGraphic, OriginalCrossSectionPlot As Bitmap
    Dim vImpactDuration, vDensity, vHeatCapacity, vYoungModulus, vThermalExpansion, vPoisson, vMelting As Double
    Dim vStartX, vStartY, vEndX, vEndY As Integer
    Dim vMaxWidth, vMaxHeight As Integer
    Dim vRoomTemperature As Double

#End Region


#Region "Properties"

#Region "Header Properties"

    'Data contained in the FLUKA header
    Property FirstX() As Double
        Get
            Return vFirstX
        End Get
        Set(ByVal value As Double)
            vFirstX = value
        End Set
    End Property

    Property FirstY() As Double
        Get
            Return vFirstY
        End Get
        Set(ByVal value As Double)
            vFirstY = value
        End Set
    End Property

    Property Firstz() As Double
        Get
            Return vFirstZ
        End Get
        Set(ByVal value As Double)
            vFirstZ = value
        End Set
    End Property

    Property StepX() As Double
        Get
            Return vStepX
        End Get
        Set(ByVal value As Double)
            vStepX = value
        End Set
    End Property

    Property Stepy() As Double
        Get
            Return vStepY
        End Get
        Set(ByVal value As Double)
            vStepY = value
        End Set
    End Property

    Property Stepz() As Double
        Get
            Return vStepZ
        End Get
        Set(ByVal value As Double)
            vStepZ = value
        End Set
    End Property

    Property NumberX() As Double
        Get
            Return vNumberX
        End Get
        Set(ByVal value As Double)
            vNumberX = value
            vStartX = 0
            vEndX = value - 1
        End Set
    End Property

    Property Numbery() As Double
        Get
            Return vNumberY
        End Get
        Set(ByVal value As Double)
            vNumberY = value
            vStartY = 0
            vEndY = value - 1
        End Set
    End Property

    Property Numberz() As Double
        Get
            Return vNumberZ
        End Get
        Set(ByVal value As Double)
            vNumberZ = value
        End Set
    End Property

#End Region

#Region "Cross Sections Properties"

    'The vector containing the selected Cross Sections
    Property ZCrossSections() As Integer()
        Get
            Return ZVector
        End Get
        Set(ByVal value() As Integer)
            ZVector = value
        End Set
    End Property

#End Region

#Region "File Path Properties"

    'The paths of all files
    Property FLUKAFilePath() As String
        Get
            Return vFLUKAFilePath
        End Get
        Set(ByVal value As String)
            vFLUKAFilePath = value
            vANSYSFilePath = vFLUKAFilePath.Remove(vFLUKAFilePath.LastIndexOf("\") + 1) & "ANSYS-" & FileName & ".txt"
            vScriptFilePath = vFLUKAFilePath.Remove(vFLUKAFilePath.LastIndexOf("\") + 1) & "Script-" & FileName & ".txt"
        End Set
    End Property

    Property ANSYSFilePath() As String
        Get
            Return vANSYSFilePath
        End Get
        Set(ByVal value As String)
            vANSYSFilePath = value
            vScriptFilePath = vANSYSFilePath.Remove(vANSYSFilePath.LastIndexOf("\") + 1) & "Script-" & FileName & ".txt"
        End Set
    End Property

    ReadOnly Property ScriptFilePath() As String
        Get
            Return vScriptFilePath
        End Get
    End Property

    ReadOnly Property FileName() As String
        Get
            Dim aux As String
            aux = vFLUKAFilePath.Substring(vFLUKAFilePath.LastIndexOf("\") + 1)
            aux = aux.Remove(aux.LastIndexOf("."))
            Return aux
        End Get
    End Property

#End Region

#Region "Script Preview Properties"

    'Properties used for the Script preview
    Property FLUKAInputCS()
        Get
            Return vFLUKAInputCS
        End Get
        Set(ByVal value)
            vFLUKAInputCS = value
        End Set
    End Property

    Property TableName()
        Get
            Return vTableName
        End Get
        Set(ByVal value)
            vTableName = value
        End Set
    End Property

#End Region

#Region "Data Properties"

    'The Data Extracted from FLUKA file
    ReadOnly Property Data() As Double()
        Get
            Return vData
        End Get
    End Property

#End Region

#Region "Data Analysis Properties"

    'Properties used for the data analysis
    Property ImpactDuration() As Double
        Get
            Return vImpactDuration
        End Get
        Set(ByVal value As Double)
            vImpactDuration = value
        End Set
    End Property

    Property Density() As Double
        Get
            Return vDensity
        End Get
        Set(ByVal value As Double)
            vDensity = value
        End Set
    End Property

    Property HeatCapacity()
        Get
            Return vHeatCapacity
        End Get
        Set(ByVal value)
            vHeatCapacity = value
        End Set
    End Property

    Property YoungModulus() As Double
        Get
            Return vYoungModulus
        End Get
        Set(ByVal value As Double)
            vYoungModulus = value
        End Set
    End Property

    Property CoefficientOfThermalExpansion() As Double
        Get
            Return vThermalExpansion
        End Get
        Set(ByVal value As Double)
            vThermalExpansion = value
        End Set
    End Property

    Property PoissonRatio() As Double
        Get
            Return vPoisson
        End Get
        Set(ByVal value As Double)
            vPoisson = value
        End Set
    End Property

    Property MeltingPoint() As Double
        Get
            Return vMelting
        End Get
        Set(ByVal value As Double)
            vMelting = value
        End Set
    End Property

    Property RoomTemperature() As Double
        Get
            Return vRoomTemperature
        End Get
        Set(ByVal value As Double)
            vRoomTemperature = value
        End Set
    End Property

#End Region

#Region "Maximum Plot Size Properties"

    'The maximum size of the Plot pictureBox
    Property MaxWidth() As Integer
        Get
            Return vMaxWidth
        End Get
        Set(ByVal value As Integer)
            vMaxWidth = value
        End Set
    End Property

    Property MaxHeight() As Integer
        Get
            Return vMaxHeight
        End Get
        Set(ByVal value As Integer)
            vMaxHeight = value
        End Set
    End Property

#End Region

#Region "Selection Properties"

    'To make a selection on the plot
    Property XStart() As Double
        Get
            Return vStartX
        End Get
        Set(ByVal value As Double)
            vStartX = value
        End Set
    End Property

    Property Ystart() As Double
        Get
            Return vStartY
        End Get
        Set(ByVal value As Double)
            vStartY = value
        End Set
    End Property

    Property Xend() As Double
        Get
            Return vEndX
        End Get
        Set(ByVal value As Double)
            vEndX = value
        End Set
    End Property

    Property Yend() As Double
        Get
            Return vEndY
        End Get
        Set(ByVal value As Double)
            vEndY = value
        End Set
    End Property

#End Region

#End Region


#Region "Methods"

#Region "Conversion Methods"

    'Function that receives a line and extracts the three numbers corresponding to the beginning and the end of the sample and to the number of elements
    Public Function ExtractNumbers(ByVal line As String) As System.Collections.ArrayList

        If line = "" Then Return Nothing
        'Variable associated to the position in the string
        Dim i As Integer = 0
        'Return variable. It is an array of double
        Dim numbers As New System.Collections.ArrayList

        'Variable that keeps the count of numbers already extracted
        Dim NumbersExtracted As Byte = 0

        'Auxiliary variable where to keep the number who is going to raise
        Dim aux As String

        'The cycle continues until the three numbers are extracted or until it reaches the end of the line
        Do
            'Boolean variables to know if a number has been encountered and if it is finished
            Dim EndOfNumber As Boolean = False
            Dim NumberHasBegun As Boolean = False
            Dim EndOfLine As Boolean = False


            aux = ""

            'The cycle scans the line looking for a symbol associated to a number (0-9,.,+,-,E) and if it founds it saves it in the aux variable
            Do
                If line(i) = "-" Or line(i) = "+" Or line(i) = "." Or line(i) = "E" Or ((line(i) >= "0") And (line(i) <= "9")) Then
                    NumberHasBegun = True
                    aux &= line(i)
                ElseIf NumberHasBegun Then
                    EndOfNumber = True
                End If
                'It checks if the end of the line has been reached
                If i = (line.Length - 1) Then
                    If NumberHasBegun Then
                        EndOfNumber = True
                        i += 1
                    Else
                        EndOfLine = True
                    End If
                End If
                i += 1
            Loop Until EndOfNumber Or EndOfLine

            'Before saving the number it is necessary to verify that it is really a good one (not a '+' isolated for example)
            'To do that it is enough to verify that the character before the number is a blank
            If Not EndOfLine Then
                If (i - aux.Length - 2) < 0 Then
                    'The number extracted is saved into the array
                    numbers.Add(aux)
                    NumbersExtracted += 1
                ElseIf line(i - aux.Length - 2) = " " Then
                    'The number extracted is saved into the array
                    numbers.Add(aux)
                    NumbersExtracted += 1
                End If
            End If


        Loop Until i >= line.Length

        Return numbers

    End Function

    'The function works as the previous, but it is faster than it (it uses arrays and not arraylists, there are a less controls)
    Public Function ExtractNumbersFast(ByVal line As String, ByVal Count As Integer) As Double()

        'Variable associated to the position in the string
        Dim i As Integer = 0
        'Return variable. It is an array of double
        Dim numbers As Double()
        ReDim numbers(Count - 1)

        Dim NumbersExtracted As Integer = 0

        'Auxiliary variable where to keep the number who is going to raise
        Dim aux As String

        'Boolean variables to know if a number has been encountered and if it is finished
        Dim EndOfNumber As Boolean
        Dim NumberHasBegun As Boolean


        'The cycle continues until the three numbers are extracted or until it reaches the end of the line
        Do

            EndOfNumber = False
            NumberHasBegun = False

            aux = ""

            'The cycle scans the line looking for a symbol associated to a number (0-9,.,+,-,E) and if it founds it saves it in the aux variable
            Do
                If line(i) <> " " Then
                    NumberHasBegun = True
                    aux &= line(i)
                ElseIf NumberHasBegun Then
                    EndOfNumber = True
                End If
                'It checks if the end of the line has been reached
                If i = (line.Length - 1) Then
                    EndOfNumber = True
                End If
                i += 1
            Loop Until EndOfNumber


            numbers(NumbersExtracted) = aux
            NumbersExtracted += 1



        Loop Until NumbersExtracted = Count

        Return numbers


    End Function

    'Function that receives a line and returns the number of double numbers founded into the line
    Public Function AmountOfNumbersPerLine(ByVal line As String) As Byte

        If line = "" Then Return 0
        'Return variable
        Dim NumbersExtracted As Byte = 0
        'Variable used to scan the characters in the line
        Dim i As Integer = 0
        'Auxiliary variable where to keep the number
        Dim aux As String

        Do
            'Boolean variables to know if a number has been encountered and if it is finished
            Dim EndOfNumber As Boolean = False
            Dim NumberHasBegun As Boolean = False


            aux = ""

            'The cycle scans the line looking for a symbol associated to a number (0-9,.,+,-,E) and if it founds it saves it in the aux variable
            Do
                If line(i) = "-" Or line(i) = "+" Or line(i) = "." Or line(i) = "E" Or ((line(i) >= "0") And (line(i) <= "9")) Then
                    NumberHasBegun = True
                    aux &= line(i)
                ElseIf NumberHasBegun Then
                    EndOfNumber = True
                End If
                'It checks if the end of the line has been reached
                If i = (line.Length - 1) Then
                    EndOfNumber = True
                    i += 1
                End If
                i += 1
            Loop Until EndOfNumber

            'Before saving the number it is necessary to verify that it is really a good one (not a '+' isolated for example)
            'To do that it is enough to verify that the character before the number is a blank or the number is at the beginning of the line
            If NumberHasBegun Then
                If (i - aux.Length - 2) < 0 Then
                    NumbersExtracted += 1
                ElseIf line(i - aux.Length - 2) = " " Then
                    NumbersExtracted += 1
                End If
            End If

        Loop Until i >= line.Length
        Return NumbersExtracted

    End Function

    'The function reads data from a FLUKA file and puts it in an array of double
    Public Sub ExtractData()

        'StreamReader for reading from the file
        Dim sr As StreamReader = New StreamReader(Me.FLUKAFilePath)
        'String variable where every line is stored
        Dim line As String
        'Boolean variable that says if we are in the position where data starts (after the header)
        Dim StartToRead As Boolean = False


        Do
            'To decide if the end of the header has reached the program searches a row with at least 5 numbers
            line = sr.ReadLine
            If AmountOfNumbersPerLine(line) > 4 Then
                StartToRead = True
            End If

        Loop Until StartToRead Or line Is Nothing


        Dim NumberOfLines As Long = 0
        Dim NumberOfDataPerLine As Integer
        Dim NumberOfDataLastLine As Integer

        'If a row with five numbers has been founded the program starts to read data, otherwise an error message is shown
        If StartToRead Then
            'The amount of numbers per line is set
            NumberOfDataPerLine = AmountOfNumbersPerLine(line)
            'This cycle scans all the lines in order to count how many lines there are on the txt file
            While line <> Nothing
                NumberOfLines += 1
                line = sr.ReadLine()
                If line <> Nothing Then
                    If (line(0) <= "Z" And line(0) >= "A") Or (line(0) >= "a" And line(0) <= "z") Then
                        Exit While
                    End If
                End If
            End While

            sr.Close()

            'The vector containing data is redimensioned
            ReDim vData(NumberOfLines * NumberOfDataPerLine - 1)

            'Another cycle in order to avoid the header
            sr = New StreamReader(Me.FLUKAFilePath)
            StartToRead = False
            Do
                line = sr.ReadLine
                If AmountOfNumbersPerLine(line) > 4 Then
                    StartToRead = True
                End If

            Loop Until StartToRead Or line Is Nothing

            'Counter variable that contains the line number
            Dim LineNumber As Integer = 0

            'Auxiliary variable that keeps the numbers of one line
            Dim aux As Double()
            ReDim aux(NumberOfDataPerLine - 1)

            Dim startIndex As Long = 0
            'The loop scans all the lines, reads the numbers and saves it in the data vector
            While line <> Nothing
                If LineNumber < (NumberOfLines - 1) Then
                    aux = ExtractNumbersFast(line, NumberOfDataPerLine)
                    startIndex = LineNumber * NumberOfDataPerLine
                    For k As Integer = 0 To NumberOfDataPerLine - 1
                        vData(startIndex + k) = aux(k)
                    Next
                    line = sr.ReadLine
                    LineNumber += 1
                Else
                    Dim aux2() As Double
                    NumberOfDataLastLine = AmountOfNumbersPerLine(line)
                    ReDim aux2(NumberOfDataLastLine)
                    aux2 = ExtractNumbersFast(line, NumberOfDataLastLine)
                    startIndex = LineNumber * NumberOfDataPerLine
                    For k As Integer = 0 To NumberOfDataLastLine - 1
                        vData(startIndex + k) = aux2(k)
                    Next
                    line = sr.ReadLine
                    LineNumber += 1
                    Exit While
                End If
            End While

        End If

        sr.Close()

    End Sub

    'The function modifies the array passed as first parametre, multipling every value for the constant passed as second parametre
    Public Sub ConvertsData(ByVal constant As Double)

        For i As Integer = 0 To vData.Length - 1
            vData(i) = vData(i) * constant
        Next

    End Sub

    'It returns a boolean value telling if the Cross Section number passed as parameter is in the Z Cross Section vector or not
    Public Function IsInTheZCrossSection(ByVal Z As Integer) As Boolean

        Dim i As Integer = 0
        While (i < Me.ZCrossSections.Length)
            If Me.ZCrossSections(i) = Z Then
                Return True
            Else
                i += 1
            End If

        End While

        Return False

    End Function

    'The function produces the ANSYS file in the correct format
    Public Sub WriteANSYSFile()

        'These are the indexes of the loops
        Dim x, y, z As Integer
        'Auxiliary variable where I put the line in construction
        Dim line As String = ""
        'Number of data that I have at Z fixed
        Dim ValuesPerSection As Integer = NumberX * Numbery
        'Arrays where I put the coordinate values
        Dim XValues(), YValues(), ZValues() As Double
        Dim x0, y0 As Double
        ReDim XValues(Xend - XStart)
        ReDim YValues(Yend - Ystart)
        ReDim ZValues(Numberz - 1)
        '3 loops to fill the 3 coordinate arrays (N.B. there is a step/2 that allows to go in the middle of the square)
        x0 = (FirstX + XStart * StepX)
        For i As Integer = XStart To Xend
            XValues(i - XStart) = (x0 + (i - XStart) * StepX + StepX / 2) / 100
        Next
        y0 = (FirstY + Ystart * Stepy)
        'MsgBox(FirstY)
        'MsgBox(Ystart)
        'MsgBox(Stepy)
        'MsgBox(y0)
        For i As Integer = Ystart To Yend
            YValues(i - Ystart) = (y0 + (i - Ystart) * Stepy + Stepy / 2) / 100
        Next
        'MsgBox(YValues(0))
        For i As Integer = 0 To Numberz - 1
            ZValues(i) = (Firstz + i * Stepz + Stepz / 2) / 100
        Next

        'Object streamWriter, for writing on the ANSYS file
        Dim sw As New StreamWriter(vANSYSFilePath)

        'First loop: on Z
        For z = 0 To Numberz - 1

            ''If the section has to be converted the function do it, otherwise we pass to the following section
            'If Me.IsInTheZCrossSection(z) Then
            '    'For each Z the first line is only coordinates
            '    line = Format(ZValues(z), "##0.000000") & "  "
            '    For y = 0 To Yend - Ystart
            '        line &= Format(YValues(y), "##0.000000") & "      "
            '    Next
            '    sw.WriteLine(line)
            '    line = ""

            '    For x = 0 To Xend - XStart
            '        Dim FirstPosition As Long = z * ValuesPerSection
            '        line = Format(XValues(x), "##0.000000") & " "
            '        For y = 0 To Yend - Ystart
            '            line = line & Format(Data(FirstPosition + y * NumberX + x), "E") & " "
            '        Next
            '        sw.WriteLine(line)
            '        line = ""
            '    Next
            'End If

            'If the section has to be converted the function do it, otherwise we pass to the following section
            If Me.IsInTheZCrossSection(z) Then
                'For each Z the first line is only coordinates
                line = Format(ZValues(z), "##0.000000") & "  "
                For y = Ystart To Yend
                    line &= Format(YValues(y - Ystart), "##0.000000") & "      "
                Next
                sw.WriteLine(line)
                line = ""

                For x = XStart To Xend
                    Dim FirstPosition As Long = z * ValuesPerSection
                    line = Format(XValues(x - XStart), "##0.000000") & " "
                    For y = Ystart To Yend
                        line = line & Format(Data(FirstPosition + y * NumberX + x), "E") & " "
                    Next
                    sw.WriteLine(line)
                    line = ""
                Next
            End If

        Next

        sw.Close()

    End Sub

    'The function produces the Script file
    Public Sub WriteScript()

        Dim sw As New StreamWriter(Me.ScriptFilePath)
        sw.WriteLine("CSYS," & Me.FLUKAInputCS)
        sw.WriteLine("*DIM," & Me.TableName & ",TABLE," & Xend - XStart + 1 & "," & Yend - Ystart + 1 & "," & Numberz & ",X,Y,Z," & Me.FLUKAInputCS)
        sw.WriteLine("*TREAD,EnergyDep," & ANSYSFilePath & ",txt,,0")
        sw.WriteLine("BFE,ALL,HGEN,,%" & Me.TableName & "%,,,")
        sw.WriteLine("CSYS, 0")
        sw.Close()

    End Sub

    'The function produces the Parameter file
    Public Sub WriteParam()

        If MainForm.SingleImpact Then

            Dim ParamFilePath As String
            ParamFilePath = vFLUKAFilePath.Remove(vFLUKAFilePath.LastIndexOf("\") + 1) & "Param-SI-" & FileName & ".txt"

            Dim sw As New StreamWriter(ParamFilePath)
            If MainForm.CheckBoxConstant.Checked Then

                sw.WriteLine("Impact duration: " & Val(MainForm.TBoxImpactDuration.Text & "μs"))
                sw.WriteLine("Conversion Constant: " & Val(MainForm.TBoxConstant.Text) * 10 ^ Val(MainForm.TBoxExp3.Text))
                sw.WriteLine("Room temperature: " & Val(MainForm.TBoxRoomTemperature.Text) & "°C")

            Else

                sw.WriteLine("Number of bunches: " & Val(MainForm.TBoxNBunches.Text))
                sw.WriteLine("Number of particles per bunch: " & Val(MainForm.TBoxPxBunch.Text) * 10 ^ Val(MainForm.TBoxExp.Text))
                sw.WriteLine("Impact duration: " & Val(MainForm.TBoxImpactDuration.Text & "μs"))
                sw.WriteLine("Probability factor: " & Val(MainForm.TBoxProbabilityFactor.Text & "%"))
                sw.WriteLine("Room temperature: " & Val(MainForm.TBoxRoomTemperature.Text) & "°C")

            End If
            sw.Close()

        Else

            Dim ParamFilePath As String
            ParamFilePath = vFLUKAFilePath.Remove(vFLUKAFilePath.LastIndexOf("\") + 1) & "Param-CF-" & FileName & ".txt"

            Dim sw As New StreamWriter(ParamFilePath)
            If MainForm.CheckBoxConstant2.Checked Then

                sw.WriteLine("Conversion Constant: " & Val(MainForm.TBoxConstant2.Text) * 10 ^ Val(MainForm.TBoxExp4.Text))

            Else

                sw.WriteLine("Total number of particles per second: " & Val(MainForm.TboxParticlesxSecond.Text) * 10 ^ Val(MainForm.TBoxExp2.Text))
                sw.WriteLine("Probability factor: " & Val(MainForm.TBoxProbabilityFactor2.Text & "%"))

            End If

            sw.Close()

        End If


    End Sub

    'It acts like the previous sub, but it doesn't write on a file: it returns the script string
    Public Function GetScript() As String

        Dim Text As String = ""
        Text = "CSYS," & Me.FLUKAInputCS & Chr(13)
        Text &= "*DIM," & Me.TableName & ",TABLE," & NumberX & "," & Numbery & "," & Numberz & ",X,Y,Z," & Me.FLUKAInputCS & Chr(13)
        Text &= "*TREAD,EnergyDep," & ANSYSFilePath & ",txt,,0" & Chr(13)
        Text &= "BFE,ALL,HGEN,,%" & Me.TableName & "%,,," & Chr(13)
        Text &= "CSYS, 0"

        Return Text

    End Function

#End Region

#Region "Data Analysis Methods"

    'It returns the biggest Energy value founded in the vdata Vector (W/m3)
    'The function has to be called only after the vData has been filled (with the ExtractData sub)
    Public Function MaximumValue() As Double

        Dim Maximum As Double = 0
        Dim i As Integer
        Dim startOfSection, StartOfLine As Double

        For z As Integer = 0 To Numberz - 1
            startOfSection = z * (NumberX * Numbery)
            For y As Integer = Ystart To Yend
                StartOfLine = y * NumberX
                For x As Integer = XStart To Xend
                    i = startOfSection + StartOfLine + x
                    If vData(i) > Maximum Then
                        Maximum = vData(i)
                    End If
                Next
            Next
        Next

        Return Maximum

    End Function

    Public Function AbsoluteMaximumValue() As Double

        Dim Maximum As Double = 0
        For i As Long = 0 To vData.Length - 1
            If vData(i) > Maximum Then
                Maximum = vData(i)
            End If
        Next

        Return Maximum

    End Function

    Public Function MaximumPowerValue() As Double
        Return Me.MaximumValue * Me.UnityOfVolume
    End Function

    'The function sums all the values contained in the vData vector (It returns a W/m3 value)
    Public Function TotalDepositedPowerPerM3() As Double

        Dim result As Double = 0
        Dim i As Integer
        Dim StartOfSection, StartOfLine As Long

        For z As Integer = 0 To Numberz - 1
            StartOfSection = z * (NumberX * Numbery)
            For y As Integer = Ystart To Yend
                StartOfLine = y * NumberX
                For x As Integer = XStart To Xend
                    i = StartOfSection + StartOfLine + x
                    result += vData(i)
                Next
            Next
        Next

        Return result
    End Function

    'As the function before, but we multiply for the volume in order to obtain the power (W)
    Public Function TotalDepositedPower() As Double

        Return Me.TotalDepositedPowerPerM3 * Me.UnityOfVolume

    End Function

    'It returns the sum of the deposited power for the section specified as parameter
    Public Function TotalDepositedPowerPerSection(ByVal Z As Integer) As Double

        Dim result As Double = 0

        Dim i As Integer

        Dim StartOfSection As Long = Me.ZVector(Z) * NumberX * Numbery
        Dim StartOfLine As Long
        For y As Integer = Ystart To Yend
            StartOfLine = y * NumberX
            For x As Integer = XStart To Xend
                i = StartOfSection + StartOfLine + x
                result += vData(i)
            Next
        Next

        result *= Me.UnityOfVolume
        Return result

    End Function

    'It returns the deposited power of the section with the biggest value of it
    Public Function MaximumDepositedPowerOnASection() As Double

        Dim Maximum As Double = 0

        For i As Integer = 0 To Me.ZVector.Length - 1
            If Me.TotalDepositedPowerPerSection(i) > Maximum Then
                Maximum = Me.TotalDepositedPowerPerSection(i)
            End If
        Next

        Return Maximum

    End Function

    'It returns the volume of the xyz parallelepiped
    Public Function Volume() As Double
        'Volume of a Parallelepiped. It has to be divided by 100^3 to be converted from cm3 to m3
        Return (Me.StepX * (Me.Xend - Me.XStart + 1) * Me.vStepY * (Me.Yend - Me.Ystart + 1) * Me.vStepZ * Me.Numberz) / (100 ^ 3)
    End Function

    Public Function UnityOfVolume() As Double
        Return (StepX * Stepy * Stepz) * Math.Pow(10, -6)
    End Function

    Public Function MaximumTemperature() As Double

        Return Me.RoomTemperature + Me.MaximumValue * ImpactDuration / HeatCapacity / Density

    End Function

    Public Function MaximumStress() As Double

        Return YoungModulus * CoefficientOfThermalExpansion * (Me.MaximumTemperature - Me.RoomTemperature) / (1 - 2 * PoissonRatio) / 1000

    End Function

#End Region

#Region "Graphics Methods"

    'It resizes the PictureBox passed as parameter in order to use all the surface
    Public Sub ResizeControl(ByRef PictureBox As PictureBox)

        'These variables contain the number of pixels in X and Y directions that corresponds to the width of cells on the grid 
        Dim stepX As Integer = 1
        Dim stepY As Integer = 1
        Dim Width, Height As Integer
        Dim XWidth As Integer = (vEndX - vStartX)
        Dim YWidth As Integer = (vEndY - vStartY)
        Width = XWidth
        Height = YWidth
        Dim i As Integer = 2
        While XWidth * i < MaxWidth And YWidth * i < MaxHeight
            Width = XWidth * i
            Height = YWidth * i
            i += 1
        End While

        'The Panel size is modified
        PictureBox.Size = New Size(Width, Height)

    End Sub

    'It is used to draw the section selected as second parameter in the panel chosen as first parameter
    Public Sub DrawGraphic(ByRef Panel As Bitmap, ByVal Z As Double)

        'The Graphics variables is declared and associated to the bitMap
        Dim DrawArea As Graphics = Graphics.FromImage(Panel)
        'The pen is used to establish the color of the pixel
        Dim Pen As New Pen(Color.Black)

        'These variables contain the number of pixels in X and Y directions that corresponds to the width of cells on the grid 
        Dim stepX As Integer = Math.Ceiling(Panel.Size.Width / (Xend - XStart + 1))
        Dim stepY As Integer = Math.Ceiling(Panel.Size.Height / (Yend - Ystart + 1))

        'The graphics variable is associated to the PictureBox and initialized

        DrawArea.Clear(Color.White)

        Dim PanelHeight As Integer = Panel.Size.Height

        Dim StartOfSection As Long = 0

        Dim Maximum As Double = Me.AbsoluteMaximumValue()

        StartOfSection = Me.ZVector(Z) * NumberX * Numbery

        For x As Integer = vStartX To vEndX - 1
            For y As Integer = vStartY To vEndY - 1
                'The ratio of energy compared with the maximum value
                Dim Number As Double = vData(StartOfSection + y * NumberX + x)
                Dim Percentage As Double = Number / Maximum
                Dim color As New Color
                'The percentage is more than 10%. Colors from Red to Yellow
                If Percentage > 0.1 Then
                    color = Drawing.Color.FromArgb(255, (1 - Percentage) * 255, 0)
                    'The percentage is between 1% and 10%. Colors from Yellow to Green
                ElseIf Percentage > 0.01 Then
                    color = Drawing.Color.FromArgb((Percentage * 10) * 255, 255, 0)
                    'The percentage is between 0.1% and 1%. Colors from Green to Blue
                ElseIf Percentage > 0.001 Then
                    color = Drawing.Color.FromArgb(0, 255 * (Percentage * 100), (0.01 - Percentage) * 255 * 100)
                    'The percentage is between 0.01% and 0.1%. Colors from Blue to Violet
                ElseIf Percentage > 0.0001 Then
                    color = Drawing.Color.FromArgb((0.001 - Percentage) * 255 * 100, 0, (Percentage * 1000) * 255)
                    'The percentage is less than the 0.01%. Black color
                Else
                    color = Drawing.Color.Black
                End If
                Pen.Color = color
                'These commands draw a rectangle with the selected color
                DrawArea.DrawRectangle(Pen, (x - vStartX) * stepX, PanelHeight - (y - vStartY + 1) * stepY, stepX, stepY)
                Dim Brush As New SolidBrush(color)
                DrawArea.FillRectangle(Brush, (x - vStartX) * stepX, PanelHeight - (y - vStartY + 1) * stepY, stepX, stepY)
            Next
        Next

        OriginalCrossSectionPlot = Panel.Clone

    End Sub

    Public Sub HighLightArea(ByRef Panel As Bitmap, ByVal Xstart As Integer, ByVal Ystart As Integer, ByVal Xend As Integer, ByVal Yend As Integer)

        Panel = OriginalCrossSectionPlot.Clone

        'The Graphics variables is declared and associated to the bitMap
        Dim DrawArea As Graphics = Graphics.FromImage(Panel)
        'The pen is used to establish the color of the pixel
        Dim Pen As New Pen(Color.Red)

        If (Xend >= Xstart) And (Yend >= Ystart) Then
            DrawArea.DrawRectangle(Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart)
        ElseIf (Xend < Xstart) And (Yend >= Ystart) Then
            DrawArea.DrawRectangle(Pen, Xend, Ystart, Xstart - Xend, Yend - Ystart)
        ElseIf (Xend >= Xstart) And (Yend < Ystart) Then
            DrawArea.DrawRectangle(Pen, Xstart, Yend, Xend - Xstart, Ystart - Yend)
        ElseIf (Xend < Xstart) And (Yend < Ystart) Then
            DrawArea.DrawRectangle(Pen, Xend, Yend, Xstart - Xend, Ystart - Yend)
        End If


    End Sub

    Public Sub DrawPowerGraphic(ByRef Panel As Bitmap)

        'The Graphics variables is declared and associated to the bitMap
        Dim DrawArea As Graphics = Graphics.FromImage(Panel)
        'The pen is used to establish the color of the pixel
        Dim Pen As New Pen(Color.Black)

        Dim Totwidth As Integer = Panel.Width
        Dim TotHeight As Integer = Panel.Height
        'How much place leave from the border



        'We draw the axis
        Pen.EndCap = Drawing2D.LineCap.ArrowAnchor
        DrawArea.DrawLine(Pen, Margin, TotHeight - Margin, Margin, Margin)
        DrawArea.DrawLine(Pen, Margin, TotHeight - Margin, Totwidth - Margin, TotHeight - Margin)
        Pen.EndCap = Drawing2D.LineCap.Flat

        Dim MaximumValue As Double = Me.MaximumDepositedPowerOnASection
        Dim Value As Double
        Dim X, Y, X0, Y0 As Integer
        Pen.Color = Color.Blue
        X0 = Margin
        Y0 = TotHeight - Margin
        Dim VectorEnd As Integer = Me.ZVector.Length
        For i As Integer = 0 To VectorEnd - 1
            Value = Me.TotalDepositedPowerPerSection(i)
            X = Margin + ((Totwidth - 2 * Margin) / VectorEnd) * i
            If MaximumValue = 0 Then
                Y = TotHeight - Margin
            Else
                Y = (TotHeight - Margin) - ((TotHeight - 2 * Margin) / MaximumValue) * Value
            End If

            DrawArea.DrawLine(Pen, X0, Y0, X, Y)
            X0 = X
            Y0 = Y
        Next

        OriginalPowerGraphic = Panel.Clone

    End Sub

    Public Sub HighLightPoint(ByRef Panel As Bitmap, ByVal Z As Integer)

        Panel = OriginalPowerGraphic.Clone

        Dim Totwidth As Integer = Panel.Width
        Dim TotHeight As Integer = Panel.Height

        'The Graphics variables is declared and associated to the bitMap
        Dim DrawArea As Graphics = Graphics.FromImage(Panel)
        'The pen is used to establish the color of the pixel
        Dim Pen As New Pen(Color.Red)
        Pen.DashStyle = Drawing2D.DashStyle.Dash

        Dim MaximumValue As Double = Me.MaximumDepositedPowerOnASection
        Dim Value As Double = Me.TotalDepositedPowerPerSection(Z)

        Dim Xp As Integer = Margin + Z / Me.ZVector.Length * (Totwidth - 2 * Margin)
        Dim yp As Integer = (TotHeight - Margin) - ((TotHeight - 2 * Margin) / MaximumValue) * Value

        DrawArea.DrawLine(Pen, Xp, TotHeight - Margin, Xp, yp)
        DrawArea.DrawLine(Pen, Margin, yp, Xp, yp)


    End Sub

#End Region


#End Region

End Class
