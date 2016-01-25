<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Plot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.HScrollBar = New System.Windows.Forms.HScrollBar
        Me.TBoxSelectedZ = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBoxLegend = New System.Windows.Forms.GroupBox
        Me.Lbl0 = New System.Windows.Forms.Label
        Me.TBox0 = New System.Windows.Forms.TextBox
        Me.Lbl02 = New System.Windows.Forms.Label
        Me.TBox02 = New System.Windows.Forms.TextBox
        Me.Lbl2 = New System.Windows.Forms.Label
        Me.TBox2 = New System.Windows.Forms.TextBox
        Me.Lbl20 = New System.Windows.Forms.Label
        Me.TBox20 = New System.Windows.Forms.TextBox
        Me.Lbl004 = New System.Windows.Forms.Label
        Me.Lbl006 = New System.Windows.Forms.Label
        Me.Lbl008 = New System.Windows.Forms.Label
        Me.Lbl01 = New System.Windows.Forms.Label
        Me.TBox004 = New System.Windows.Forms.TextBox
        Me.TBox006 = New System.Windows.Forms.TextBox
        Me.TBox008 = New System.Windows.Forms.TextBox
        Me.TBox01 = New System.Windows.Forms.TextBox
        Me.Lbl04 = New System.Windows.Forms.Label
        Me.Lbl06 = New System.Windows.Forms.Label
        Me.Lbl08 = New System.Windows.Forms.Label
        Me.Lbl1 = New System.Windows.Forms.Label
        Me.TBox04 = New System.Windows.Forms.TextBox
        Me.TBox06 = New System.Windows.Forms.TextBox
        Me.TBox08 = New System.Windows.Forms.TextBox
        Me.TBox1 = New System.Windows.Forms.TextBox
        Me.Lbl4 = New System.Windows.Forms.Label
        Me.Lbl6 = New System.Windows.Forms.Label
        Me.Lbl8 = New System.Windows.Forms.Label
        Me.Lbl10 = New System.Windows.Forms.Label
        Me.Lbl40 = New System.Windows.Forms.Label
        Me.Lbl60 = New System.Windows.Forms.Label
        Me.Lbl80 = New System.Windows.Forms.Label
        Me.TBox4 = New System.Windows.Forms.TextBox
        Me.Tbox6 = New System.Windows.Forms.TextBox
        Me.TBox8 = New System.Windows.Forms.TextBox
        Me.TBox10 = New System.Windows.Forms.TextBox
        Me.TBox40 = New System.Windows.Forms.TextBox
        Me.TBox60 = New System.Windows.Forms.TextBox
        Me.TBox80 = New System.Windows.Forms.TextBox
        Me.Lbl100 = New System.Windows.Forms.Label
        Me.TBox100 = New System.Windows.Forms.TextBox
        Me.BtnSavePlot = New System.Windows.Forms.Button
        Me.GroupBoxFunctions = New System.Windows.Forms.GroupBox
        Me.BtnDefault = New System.Windows.Forms.Button
        Me.BtnSaveAnsys = New System.Windows.Forms.Button
        Me.BtnShow = New System.Windows.Forms.Button
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.TimerSequence = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBoxCoordinates = New System.Windows.Forms.GroupBox
        Me.TBoxYEnd = New System.Windows.Forms.TextBox
        Me.LblYEnd = New System.Windows.Forms.Label
        Me.HScrollBarYEnd = New System.Windows.Forms.HScrollBar
        Me.TBoxYStart = New System.Windows.Forms.TextBox
        Me.LblYStart = New System.Windows.Forms.Label
        Me.HScrollBarYStart = New System.Windows.Forms.HScrollBar
        Me.TBoxXEnd = New System.Windows.Forms.TextBox
        Me.LblXEnd = New System.Windows.Forms.Label
        Me.HScrollBarXEnd = New System.Windows.Forms.HScrollBar
        Me.TBoxXStart = New System.Windows.Forms.TextBox
        Me.LblXStart = New System.Windows.Forms.Label
        Me.HScrollBarXStart = New System.Windows.Forms.HScrollBar
        Me.GroupBoxPlot = New System.Windows.Forms.GroupBox
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxLegend.SuspendLayout()
        Me.GroupBoxFunctions.SuspendLayout()
        Me.GroupBoxCoordinates.SuspendLayout()
        Me.GroupBoxPlot.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PictureBox.Location = New System.Drawing.Point(15, 19)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(680, 380)
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'HScrollBar
        '
        Me.HScrollBar.Location = New System.Drawing.Point(12, 17)
        Me.HScrollBar.Maximum = 399
        Me.HScrollBar.Name = "HScrollBar"
        Me.HScrollBar.Size = New System.Drawing.Size(547, 20)
        Me.HScrollBar.TabIndex = 1
        '
        'TBoxSelectedZ
        '
        Me.TBoxSelectedZ.BackColor = System.Drawing.Color.White
        Me.TBoxSelectedZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxSelectedZ.Location = New System.Drawing.Point(562, 17)
        Me.TBoxSelectedZ.Name = "TBoxSelectedZ"
        Me.TBoxSelectedZ.Size = New System.Drawing.Size(51, 20)
        Me.TBoxSelectedZ.TabIndex = 2
        Me.TBoxSelectedZ.Text = "1"
        Me.TBoxSelectedZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(615, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Z Selected"
        '
        'Timer
        '
        Me.Timer.Interval = 1
        '
        'GroupBoxLegend
        '
        Me.GroupBoxLegend.Controls.Add(Me.Lbl0)
        Me.GroupBoxLegend.Controls.Add(Me.TBox0)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl02)
        Me.GroupBoxLegend.Controls.Add(Me.TBox02)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl2)
        Me.GroupBoxLegend.Controls.Add(Me.TBox2)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl20)
        Me.GroupBoxLegend.Controls.Add(Me.TBox20)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl004)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl006)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl008)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl01)
        Me.GroupBoxLegend.Controls.Add(Me.TBox004)
        Me.GroupBoxLegend.Controls.Add(Me.TBox006)
        Me.GroupBoxLegend.Controls.Add(Me.TBox008)
        Me.GroupBoxLegend.Controls.Add(Me.TBox01)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl04)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl06)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl08)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl1)
        Me.GroupBoxLegend.Controls.Add(Me.TBox04)
        Me.GroupBoxLegend.Controls.Add(Me.TBox06)
        Me.GroupBoxLegend.Controls.Add(Me.TBox08)
        Me.GroupBoxLegend.Controls.Add(Me.TBox1)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl4)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl6)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl8)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl10)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl40)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl60)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl80)
        Me.GroupBoxLegend.Controls.Add(Me.TBox4)
        Me.GroupBoxLegend.Controls.Add(Me.Tbox6)
        Me.GroupBoxLegend.Controls.Add(Me.TBox8)
        Me.GroupBoxLegend.Controls.Add(Me.TBox10)
        Me.GroupBoxLegend.Controls.Add(Me.TBox40)
        Me.GroupBoxLegend.Controls.Add(Me.TBox60)
        Me.GroupBoxLegend.Controls.Add(Me.TBox80)
        Me.GroupBoxLegend.Controls.Add(Me.Lbl100)
        Me.GroupBoxLegend.Controls.Add(Me.TBox100)
        Me.GroupBoxLegend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxLegend.Location = New System.Drawing.Point(718, 12)
        Me.GroupBoxLegend.Name = "GroupBoxLegend"
        Me.GroupBoxLegend.Size = New System.Drawing.Size(300, 400)
        Me.GroupBoxLegend.TabIndex = 4
        Me.GroupBoxLegend.TabStop = False
        Me.GroupBoxLegend.Text = "Color Legend"
        '
        'Lbl0
        '
        Me.Lbl0.AutoSize = True
        Me.Lbl0.Location = New System.Drawing.Point(190, 305)
        Me.Lbl0.Name = "Lbl0"
        Me.Lbl0.Size = New System.Drawing.Size(41, 13)
        Me.Lbl0.TabIndex = 40
        Me.Lbl0.Text = "W/m3"
        '
        'TBox0
        '
        Me.TBox0.Enabled = False
        Me.TBox0.Location = New System.Drawing.Point(150, 302)
        Me.TBox0.Name = "TBox0"
        Me.TBox0.Size = New System.Drawing.Size(34, 20)
        Me.TBox0.TabIndex = 39
        '
        'Lbl02
        '
        Me.Lbl02.AutoSize = True
        Me.Lbl02.Location = New System.Drawing.Point(46, 302)
        Me.Lbl02.Name = "Lbl02"
        Me.Lbl02.Size = New System.Drawing.Size(41, 13)
        Me.Lbl02.TabIndex = 38
        Me.Lbl02.Text = "W/m3"
        '
        'TBox02
        '
        Me.TBox02.Enabled = False
        Me.TBox02.Location = New System.Drawing.Point(6, 299)
        Me.TBox02.Name = "TBox02"
        Me.TBox02.Size = New System.Drawing.Size(34, 20)
        Me.TBox02.TabIndex = 37
        '
        'Lbl2
        '
        Me.Lbl2.AutoSize = True
        Me.Lbl2.Location = New System.Drawing.Point(189, 137)
        Me.Lbl2.Name = "Lbl2"
        Me.Lbl2.Size = New System.Drawing.Size(41, 13)
        Me.Lbl2.TabIndex = 36
        Me.Lbl2.Text = "W/m3"
        '
        'TBox2
        '
        Me.TBox2.Enabled = False
        Me.TBox2.Location = New System.Drawing.Point(149, 134)
        Me.TBox2.Name = "TBox2"
        Me.TBox2.Size = New System.Drawing.Size(34, 20)
        Me.TBox2.TabIndex = 35
        '
        'Lbl20
        '
        Me.Lbl20.AutoSize = True
        Me.Lbl20.Location = New System.Drawing.Point(46, 137)
        Me.Lbl20.Name = "Lbl20"
        Me.Lbl20.Size = New System.Drawing.Size(41, 13)
        Me.Lbl20.TabIndex = 34
        Me.Lbl20.Text = "W/m3"
        '
        'TBox20
        '
        Me.TBox20.Enabled = False
        Me.TBox20.Location = New System.Drawing.Point(6, 134)
        Me.TBox20.Name = "TBox20"
        Me.TBox20.Size = New System.Drawing.Size(34, 20)
        Me.TBox20.TabIndex = 33
        '
        'Lbl004
        '
        Me.Lbl004.AutoSize = True
        Me.Lbl004.Location = New System.Drawing.Point(190, 279)
        Me.Lbl004.Name = "Lbl004"
        Me.Lbl004.Size = New System.Drawing.Size(41, 13)
        Me.Lbl004.TabIndex = 32
        Me.Lbl004.Text = "W/m3"
        '
        'Lbl006
        '
        Me.Lbl006.AutoSize = True
        Me.Lbl006.Location = New System.Drawing.Point(190, 253)
        Me.Lbl006.Name = "Lbl006"
        Me.Lbl006.Size = New System.Drawing.Size(41, 13)
        Me.Lbl006.TabIndex = 31
        Me.Lbl006.Text = "W/m3"
        '
        'Lbl008
        '
        Me.Lbl008.AutoSize = True
        Me.Lbl008.Location = New System.Drawing.Point(190, 227)
        Me.Lbl008.Name = "Lbl008"
        Me.Lbl008.Size = New System.Drawing.Size(41, 13)
        Me.Lbl008.TabIndex = 30
        Me.Lbl008.Text = "W/m3"
        '
        'Lbl01
        '
        Me.Lbl01.AutoSize = True
        Me.Lbl01.Location = New System.Drawing.Point(190, 201)
        Me.Lbl01.Name = "Lbl01"
        Me.Lbl01.Size = New System.Drawing.Size(41, 13)
        Me.Lbl01.TabIndex = 29
        Me.Lbl01.Text = "W/m3"
        '
        'TBox004
        '
        Me.TBox004.Enabled = False
        Me.TBox004.Location = New System.Drawing.Point(150, 276)
        Me.TBox004.Name = "TBox004"
        Me.TBox004.Size = New System.Drawing.Size(34, 20)
        Me.TBox004.TabIndex = 28
        '
        'TBox006
        '
        Me.TBox006.Enabled = False
        Me.TBox006.Location = New System.Drawing.Point(150, 250)
        Me.TBox006.Name = "TBox006"
        Me.TBox006.Size = New System.Drawing.Size(34, 20)
        Me.TBox006.TabIndex = 27
        '
        'TBox008
        '
        Me.TBox008.Enabled = False
        Me.TBox008.Location = New System.Drawing.Point(150, 224)
        Me.TBox008.Name = "TBox008"
        Me.TBox008.Size = New System.Drawing.Size(34, 20)
        Me.TBox008.TabIndex = 26
        '
        'TBox01
        '
        Me.TBox01.Enabled = False
        Me.TBox01.Location = New System.Drawing.Point(150, 198)
        Me.TBox01.Name = "TBox01"
        Me.TBox01.Size = New System.Drawing.Size(34, 20)
        Me.TBox01.TabIndex = 25
        '
        'Lbl04
        '
        Me.Lbl04.AutoSize = True
        Me.Lbl04.Location = New System.Drawing.Point(46, 276)
        Me.Lbl04.Name = "Lbl04"
        Me.Lbl04.Size = New System.Drawing.Size(41, 13)
        Me.Lbl04.TabIndex = 24
        Me.Lbl04.Text = "W/m3"
        '
        'Lbl06
        '
        Me.Lbl06.AutoSize = True
        Me.Lbl06.Location = New System.Drawing.Point(46, 250)
        Me.Lbl06.Name = "Lbl06"
        Me.Lbl06.Size = New System.Drawing.Size(41, 13)
        Me.Lbl06.TabIndex = 23
        Me.Lbl06.Text = "W/m3"
        '
        'Lbl08
        '
        Me.Lbl08.AutoSize = True
        Me.Lbl08.Location = New System.Drawing.Point(46, 224)
        Me.Lbl08.Name = "Lbl08"
        Me.Lbl08.Size = New System.Drawing.Size(41, 13)
        Me.Lbl08.TabIndex = 22
        Me.Lbl08.Text = "W/m3"
        '
        'Lbl1
        '
        Me.Lbl1.AutoSize = True
        Me.Lbl1.Location = New System.Drawing.Point(46, 198)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(41, 13)
        Me.Lbl1.TabIndex = 21
        Me.Lbl1.Text = "W/m3"
        '
        'TBox04
        '
        Me.TBox04.Enabled = False
        Me.TBox04.Location = New System.Drawing.Point(6, 273)
        Me.TBox04.Name = "TBox04"
        Me.TBox04.Size = New System.Drawing.Size(34, 20)
        Me.TBox04.TabIndex = 20
        '
        'TBox06
        '
        Me.TBox06.Enabled = False
        Me.TBox06.Location = New System.Drawing.Point(6, 247)
        Me.TBox06.Name = "TBox06"
        Me.TBox06.Size = New System.Drawing.Size(34, 20)
        Me.TBox06.TabIndex = 19
        '
        'TBox08
        '
        Me.TBox08.Enabled = False
        Me.TBox08.Location = New System.Drawing.Point(6, 221)
        Me.TBox08.Name = "TBox08"
        Me.TBox08.Size = New System.Drawing.Size(34, 20)
        Me.TBox08.TabIndex = 18
        '
        'TBox1
        '
        Me.TBox1.Enabled = False
        Me.TBox1.Location = New System.Drawing.Point(6, 195)
        Me.TBox1.Name = "TBox1"
        Me.TBox1.Size = New System.Drawing.Size(34, 20)
        Me.TBox1.TabIndex = 17
        '
        'Lbl4
        '
        Me.Lbl4.AutoSize = True
        Me.Lbl4.Location = New System.Drawing.Point(189, 111)
        Me.Lbl4.Name = "Lbl4"
        Me.Lbl4.Size = New System.Drawing.Size(41, 13)
        Me.Lbl4.TabIndex = 16
        Me.Lbl4.Text = "W/m3"
        '
        'Lbl6
        '
        Me.Lbl6.AutoSize = True
        Me.Lbl6.Location = New System.Drawing.Point(189, 85)
        Me.Lbl6.Name = "Lbl6"
        Me.Lbl6.Size = New System.Drawing.Size(41, 13)
        Me.Lbl6.TabIndex = 15
        Me.Lbl6.Text = "W/m3"
        '
        'Lbl8
        '
        Me.Lbl8.AutoSize = True
        Me.Lbl8.Location = New System.Drawing.Point(189, 59)
        Me.Lbl8.Name = "Lbl8"
        Me.Lbl8.Size = New System.Drawing.Size(41, 13)
        Me.Lbl8.TabIndex = 14
        Me.Lbl8.Text = "W/m3"
        '
        'Lbl10
        '
        Me.Lbl10.AutoSize = True
        Me.Lbl10.Location = New System.Drawing.Point(189, 33)
        Me.Lbl10.Name = "Lbl10"
        Me.Lbl10.Size = New System.Drawing.Size(96, 13)
        Me.Lbl10.TabIndex = 13
        Me.Lbl10.Text = "5.62E-04 W/m3"
        '
        'Lbl40
        '
        Me.Lbl40.AutoSize = True
        Me.Lbl40.Location = New System.Drawing.Point(46, 111)
        Me.Lbl40.Name = "Lbl40"
        Me.Lbl40.Size = New System.Drawing.Size(41, 13)
        Me.Lbl40.TabIndex = 12
        Me.Lbl40.Text = "W/m3"
        '
        'Lbl60
        '
        Me.Lbl60.AutoSize = True
        Me.Lbl60.Location = New System.Drawing.Point(47, 85)
        Me.Lbl60.Name = "Lbl60"
        Me.Lbl60.Size = New System.Drawing.Size(41, 13)
        Me.Lbl60.TabIndex = 11
        Me.Lbl60.Text = "W/m3"
        '
        'Lbl80
        '
        Me.Lbl80.AutoSize = True
        Me.Lbl80.Location = New System.Drawing.Point(46, 59)
        Me.Lbl80.Name = "Lbl80"
        Me.Lbl80.Size = New System.Drawing.Size(41, 13)
        Me.Lbl80.TabIndex = 10
        Me.Lbl80.Text = "W/m3"
        '
        'TBox4
        '
        Me.TBox4.Enabled = False
        Me.TBox4.Location = New System.Drawing.Point(149, 108)
        Me.TBox4.Name = "TBox4"
        Me.TBox4.Size = New System.Drawing.Size(34, 20)
        Me.TBox4.TabIndex = 9
        '
        'Tbox6
        '
        Me.Tbox6.Enabled = False
        Me.Tbox6.Location = New System.Drawing.Point(149, 82)
        Me.Tbox6.Name = "Tbox6"
        Me.Tbox6.Size = New System.Drawing.Size(34, 20)
        Me.Tbox6.TabIndex = 8
        '
        'TBox8
        '
        Me.TBox8.Enabled = False
        Me.TBox8.Location = New System.Drawing.Point(149, 56)
        Me.TBox8.Name = "TBox8"
        Me.TBox8.Size = New System.Drawing.Size(34, 20)
        Me.TBox8.TabIndex = 7
        '
        'TBox10
        '
        Me.TBox10.Enabled = False
        Me.TBox10.Location = New System.Drawing.Point(149, 30)
        Me.TBox10.Name = "TBox10"
        Me.TBox10.Size = New System.Drawing.Size(34, 20)
        Me.TBox10.TabIndex = 6
        '
        'TBox40
        '
        Me.TBox40.Enabled = False
        Me.TBox40.Location = New System.Drawing.Point(6, 108)
        Me.TBox40.Name = "TBox40"
        Me.TBox40.Size = New System.Drawing.Size(34, 20)
        Me.TBox40.TabIndex = 4
        '
        'TBox60
        '
        Me.TBox60.Enabled = False
        Me.TBox60.Location = New System.Drawing.Point(6, 82)
        Me.TBox60.Name = "TBox60"
        Me.TBox60.Size = New System.Drawing.Size(34, 20)
        Me.TBox60.TabIndex = 3
        '
        'TBox80
        '
        Me.TBox80.Enabled = False
        Me.TBox80.Location = New System.Drawing.Point(6, 56)
        Me.TBox80.Name = "TBox80"
        Me.TBox80.Size = New System.Drawing.Size(34, 20)
        Me.TBox80.TabIndex = 2
        '
        'Lbl100
        '
        Me.Lbl100.AutoSize = True
        Me.Lbl100.Location = New System.Drawing.Point(47, 36)
        Me.Lbl100.Name = "Lbl100"
        Me.Lbl100.Size = New System.Drawing.Size(96, 13)
        Me.Lbl100.TabIndex = 1
        Me.Lbl100.Text = "4.56E-03 W/m3"
        '
        'TBox100
        '
        Me.TBox100.Enabled = False
        Me.TBox100.Location = New System.Drawing.Point(6, 30)
        Me.TBox100.Name = "TBox100"
        Me.TBox100.Size = New System.Drawing.Size(34, 20)
        Me.TBox100.TabIndex = 0
        '
        'BtnSavePlot
        '
        Me.BtnSavePlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSavePlot.Location = New System.Drawing.Point(20, 28)
        Me.BtnSavePlot.Name = "BtnSavePlot"
        Me.BtnSavePlot.Size = New System.Drawing.Size(123, 34)
        Me.BtnSavePlot.TabIndex = 5
        Me.BtnSavePlot.Text = "Save Plot"
        Me.BtnSavePlot.UseVisualStyleBackColor = True
        '
        'GroupBoxFunctions
        '
        Me.GroupBoxFunctions.Controls.Add(Me.BtnDefault)
        Me.GroupBoxFunctions.Controls.Add(Me.BtnSaveAnsys)
        Me.GroupBoxFunctions.Controls.Add(Me.BtnShow)
        Me.GroupBoxFunctions.Controls.Add(Me.BtnSavePlot)
        Me.GroupBoxFunctions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxFunctions.Location = New System.Drawing.Point(719, 418)
        Me.GroupBoxFunctions.Name = "GroupBoxFunctions"
        Me.GroupBoxFunctions.Size = New System.Drawing.Size(299, 119)
        Me.GroupBoxFunctions.TabIndex = 5
        Me.GroupBoxFunctions.TabStop = False
        Me.GroupBoxFunctions.Text = "Functions"
        '
        'BtnDefault
        '
        Me.BtnDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDefault.Location = New System.Drawing.Point(149, 65)
        Me.BtnDefault.Name = "BtnDefault"
        Me.BtnDefault.Size = New System.Drawing.Size(123, 34)
        Me.BtnDefault.TabIndex = 8
        Me.BtnDefault.Text = "Default view Plot"
        Me.BtnDefault.UseVisualStyleBackColor = True
        '
        'BtnSaveAnsys
        '
        Me.BtnSaveAnsys.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveAnsys.Location = New System.Drawing.Point(20, 65)
        Me.BtnSaveAnsys.Name = "BtnSaveAnsys"
        Me.BtnSaveAnsys.Size = New System.Drawing.Size(123, 34)
        Me.BtnSaveAnsys.TabIndex = 7
        Me.BtnSaveAnsys.Text = "Save on Ansys File"
        Me.BtnSaveAnsys.UseVisualStyleBackColor = True
        '
        'BtnShow
        '
        Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShow.Location = New System.Drawing.Point(149, 27)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(123, 34)
        Me.BtnShow.TabIndex = 6
        Me.BtnShow.Text = "Show all sections"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'TimerSequence
        '
        '
        'GroupBoxCoordinates
        '
        Me.GroupBoxCoordinates.Controls.Add(Me.TBoxYEnd)
        Me.GroupBoxCoordinates.Controls.Add(Me.LblYEnd)
        Me.GroupBoxCoordinates.Controls.Add(Me.HScrollBarYEnd)
        Me.GroupBoxCoordinates.Controls.Add(Me.TBoxYStart)
        Me.GroupBoxCoordinates.Controls.Add(Me.LblYStart)
        Me.GroupBoxCoordinates.Controls.Add(Me.HScrollBarYStart)
        Me.GroupBoxCoordinates.Controls.Add(Me.TBoxXEnd)
        Me.GroupBoxCoordinates.Controls.Add(Me.LblXEnd)
        Me.GroupBoxCoordinates.Controls.Add(Me.HScrollBarXEnd)
        Me.GroupBoxCoordinates.Controls.Add(Me.TBoxXStart)
        Me.GroupBoxCoordinates.Controls.Add(Me.LblXStart)
        Me.GroupBoxCoordinates.Controls.Add(Me.HScrollBarXStart)
        Me.GroupBoxCoordinates.Controls.Add(Me.TBoxSelectedZ)
        Me.GroupBoxCoordinates.Controls.Add(Me.Label1)
        Me.GroupBoxCoordinates.Controls.Add(Me.HScrollBar)
        Me.GroupBoxCoordinates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxCoordinates.Location = New System.Drawing.Point(12, 418)
        Me.GroupBoxCoordinates.Name = "GroupBoxCoordinates"
        Me.GroupBoxCoordinates.Size = New System.Drawing.Size(700, 119)
        Me.GroupBoxCoordinates.TabIndex = 6
        Me.GroupBoxCoordinates.TabStop = False
        Me.GroupBoxCoordinates.Text = "Coordinates Selection"
        '
        'TBoxYEnd
        '
        Me.TBoxYEnd.BackColor = System.Drawing.Color.White
        Me.TBoxYEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxYEnd.Location = New System.Drawing.Point(562, 83)
        Me.TBoxYEnd.Name = "TBoxYEnd"
        Me.TBoxYEnd.ReadOnly = True
        Me.TBoxYEnd.Size = New System.Drawing.Size(51, 20)
        Me.TBoxYEnd.TabIndex = 14
        Me.TBoxYEnd.Text = "1"
        Me.TBoxYEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblYEnd
        '
        Me.LblYEnd.AutoSize = True
        Me.LblYEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYEnd.Location = New System.Drawing.Point(619, 86)
        Me.LblYEnd.Name = "LblYEnd"
        Me.LblYEnd.Size = New System.Drawing.Size(41, 13)
        Me.LblYEnd.TabIndex = 15
        Me.LblYEnd.Text = "Y End"
        '
        'HScrollBarYEnd
        '
        Me.HScrollBarYEnd.Location = New System.Drawing.Point(359, 83)
        Me.HScrollBarYEnd.Maximum = 399
        Me.HScrollBarYEnd.Name = "HScrollBarYEnd"
        Me.HScrollBarYEnd.Size = New System.Drawing.Size(200, 20)
        Me.HScrollBarYEnd.TabIndex = 13
        '
        'TBoxYStart
        '
        Me.TBoxYStart.BackColor = System.Drawing.Color.White
        Me.TBoxYStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxYStart.Location = New System.Drawing.Point(215, 83)
        Me.TBoxYStart.Name = "TBoxYStart"
        Me.TBoxYStart.ReadOnly = True
        Me.TBoxYStart.Size = New System.Drawing.Size(51, 20)
        Me.TBoxYStart.TabIndex = 11
        Me.TBoxYStart.Text = "1"
        Me.TBoxYStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblYStart
        '
        Me.LblYStart.AutoSize = True
        Me.LblYStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYStart.Location = New System.Drawing.Point(272, 86)
        Me.LblYStart.Name = "LblYStart"
        Me.LblYStart.Size = New System.Drawing.Size(46, 13)
        Me.LblYStart.TabIndex = 12
        Me.LblYStart.Text = "Y Start"
        '
        'HScrollBarYStart
        '
        Me.HScrollBarYStart.Location = New System.Drawing.Point(12, 83)
        Me.HScrollBarYStart.Maximum = 399
        Me.HScrollBarYStart.Name = "HScrollBarYStart"
        Me.HScrollBarYStart.Size = New System.Drawing.Size(200, 20)
        Me.HScrollBarYStart.TabIndex = 10
        '
        'TBoxXEnd
        '
        Me.TBoxXEnd.BackColor = System.Drawing.Color.White
        Me.TBoxXEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxXEnd.Location = New System.Drawing.Point(562, 57)
        Me.TBoxXEnd.Name = "TBoxXEnd"
        Me.TBoxXEnd.ReadOnly = True
        Me.TBoxXEnd.Size = New System.Drawing.Size(51, 20)
        Me.TBoxXEnd.TabIndex = 8
        Me.TBoxXEnd.Text = "1"
        Me.TBoxXEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblXEnd
        '
        Me.LblXEnd.AutoSize = True
        Me.LblXEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblXEnd.Location = New System.Drawing.Point(619, 60)
        Me.LblXEnd.Name = "LblXEnd"
        Me.LblXEnd.Size = New System.Drawing.Size(41, 13)
        Me.LblXEnd.TabIndex = 9
        Me.LblXEnd.Text = "X End"
        '
        'HScrollBarXEnd
        '
        Me.HScrollBarXEnd.Location = New System.Drawing.Point(359, 57)
        Me.HScrollBarXEnd.Maximum = 399
        Me.HScrollBarXEnd.Name = "HScrollBarXEnd"
        Me.HScrollBarXEnd.Size = New System.Drawing.Size(200, 20)
        Me.HScrollBarXEnd.TabIndex = 7
        '
        'TBoxXStart
        '
        Me.TBoxXStart.BackColor = System.Drawing.Color.White
        Me.TBoxXStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxXStart.Location = New System.Drawing.Point(215, 57)
        Me.TBoxXStart.Name = "TBoxXStart"
        Me.TBoxXStart.ReadOnly = True
        Me.TBoxXStart.Size = New System.Drawing.Size(51, 20)
        Me.TBoxXStart.TabIndex = 5
        Me.TBoxXStart.Text = "1"
        Me.TBoxXStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblXStart
        '
        Me.LblXStart.AutoSize = True
        Me.LblXStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblXStart.Location = New System.Drawing.Point(272, 60)
        Me.LblXStart.Name = "LblXStart"
        Me.LblXStart.Size = New System.Drawing.Size(46, 13)
        Me.LblXStart.TabIndex = 6
        Me.LblXStart.Text = "X Start"
        '
        'HScrollBarXStart
        '
        Me.HScrollBarXStart.Location = New System.Drawing.Point(12, 57)
        Me.HScrollBarXStart.Maximum = 399
        Me.HScrollBarXStart.Name = "HScrollBarXStart"
        Me.HScrollBarXStart.Size = New System.Drawing.Size(200, 20)
        Me.HScrollBarXStart.TabIndex = 4
        '
        'GroupBoxPlot
        '
        Me.GroupBoxPlot.BackColor = System.Drawing.Color.White
        Me.GroupBoxPlot.Controls.Add(Me.PictureBox)
        Me.GroupBoxPlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxPlot.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxPlot.Name = "GroupBoxPlot"
        Me.GroupBoxPlot.Size = New System.Drawing.Size(700, 400)
        Me.GroupBoxPlot.TabIndex = 7
        Me.GroupBoxPlot.TabStop = False
        Me.GroupBoxPlot.Text = "Plot"
        '
        'Plot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 549)
        Me.Controls.Add(Me.GroupBoxPlot)
        Me.Controls.Add(Me.GroupBoxCoordinates)
        Me.Controls.Add(Me.GroupBoxFunctions)
        Me.Controls.Add(Me.GroupBoxLegend)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Plot"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plot"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxLegend.ResumeLayout(False)
        Me.GroupBoxLegend.PerformLayout()
        Me.GroupBoxFunctions.ResumeLayout(False)
        Me.GroupBoxCoordinates.ResumeLayout(False)
        Me.GroupBoxCoordinates.PerformLayout()
        Me.GroupBoxPlot.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents HScrollBar As System.Windows.Forms.HScrollBar
    Friend WithEvents TBoxSelectedZ As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents GroupBoxLegend As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl100 As System.Windows.Forms.Label
    Friend WithEvents TBox100 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl4 As System.Windows.Forms.Label
    Friend WithEvents Lbl6 As System.Windows.Forms.Label
    Friend WithEvents Lbl8 As System.Windows.Forms.Label
    Friend WithEvents Lbl10 As System.Windows.Forms.Label
    Friend WithEvents Lbl40 As System.Windows.Forms.Label
    Friend WithEvents Lbl60 As System.Windows.Forms.Label
    Friend WithEvents Lbl80 As System.Windows.Forms.Label
    Friend WithEvents TBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Tbox6 As System.Windows.Forms.TextBox
    Friend WithEvents TBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TBox40 As System.Windows.Forms.TextBox
    Friend WithEvents TBox60 As System.Windows.Forms.TextBox
    Friend WithEvents TBox80 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl004 As System.Windows.Forms.Label
    Friend WithEvents Lbl006 As System.Windows.Forms.Label
    Friend WithEvents Lbl008 As System.Windows.Forms.Label
    Friend WithEvents Lbl01 As System.Windows.Forms.Label
    Friend WithEvents TBox004 As System.Windows.Forms.TextBox
    Friend WithEvents TBox006 As System.Windows.Forms.TextBox
    Friend WithEvents TBox008 As System.Windows.Forms.TextBox
    Friend WithEvents TBox01 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl04 As System.Windows.Forms.Label
    Friend WithEvents Lbl06 As System.Windows.Forms.Label
    Friend WithEvents Lbl08 As System.Windows.Forms.Label
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents TBox04 As System.Windows.Forms.TextBox
    Friend WithEvents TBox06 As System.Windows.Forms.TextBox
    Friend WithEvents TBox08 As System.Windows.Forms.TextBox
    Friend WithEvents TBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl0 As System.Windows.Forms.Label
    Friend WithEvents TBox0 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl02 As System.Windows.Forms.Label
    Friend WithEvents TBox02 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl2 As System.Windows.Forms.Label
    Friend WithEvents TBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl20 As System.Windows.Forms.Label
    Friend WithEvents TBox20 As System.Windows.Forms.TextBox
    Friend WithEvents BtnSavePlot As System.Windows.Forms.Button
    Friend WithEvents GroupBoxFunctions As System.Windows.Forms.GroupBox
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents TimerSequence As System.Windows.Forms.Timer
    Friend WithEvents BtnSaveAnsys As System.Windows.Forms.Button
    Friend WithEvents BtnDefault As System.Windows.Forms.Button
    Friend WithEvents GroupBoxCoordinates As System.Windows.Forms.GroupBox
    Friend WithEvents TBoxYEnd As System.Windows.Forms.TextBox
    Friend WithEvents LblYEnd As System.Windows.Forms.Label
    Friend WithEvents HScrollBarYEnd As System.Windows.Forms.HScrollBar
    Friend WithEvents TBoxYStart As System.Windows.Forms.TextBox
    Friend WithEvents LblYStart As System.Windows.Forms.Label
    Friend WithEvents HScrollBarYStart As System.Windows.Forms.HScrollBar
    Friend WithEvents TBoxXEnd As System.Windows.Forms.TextBox
    Friend WithEvents LblXEnd As System.Windows.Forms.Label
    Friend WithEvents HScrollBarXEnd As System.Windows.Forms.HScrollBar
    Friend WithEvents TBoxXStart As System.Windows.Forms.TextBox
    Friend WithEvents LblXStart As System.Windows.Forms.Label
    Friend WithEvents HScrollBarXStart As System.Windows.Forms.HScrollBar
    Friend WithEvents GroupBoxPlot As System.Windows.Forms.GroupBox
End Class
