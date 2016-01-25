<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZCrossSectionSelection
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnDone = New System.Windows.Forms.Button
        Me.TBoxEvery = New System.Windows.Forms.TextBox
        Me.TBoxTo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TBoxFrom = New System.Windows.Forms.TextBox
        Me.RadioBtnEvery = New System.Windows.Forms.RadioButton
        Me.RadioBtnSelection = New System.Windows.Forms.RadioButton
        Me.RadioBtnFromTo = New System.Windows.Forms.RadioButton
        Me.RadioBtnAll = New System.Windows.Forms.RadioButton
        Me.DGVSelection = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnCancel)
        Me.GroupBox1.Controls.Add(Me.BtnDone)
        Me.GroupBox1.Controls.Add(Me.TBoxEvery)
        Me.GroupBox1.Controls.Add(Me.TBoxTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TBoxFrom)
        Me.GroupBox1.Controls.Add(Me.RadioBtnEvery)
        Me.GroupBox1.Controls.Add(Me.RadioBtnSelection)
        Me.GroupBox1.Controls.Add(Me.RadioBtnFromTo)
        Me.GroupBox1.Controls.Add(Me.RadioBtnAll)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 194)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choose the sections to save in the ANSYS File"
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(199, 157)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 9
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnDone
        '
        Me.BtnDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDone.Location = New System.Drawing.Point(280, 157)
        Me.BtnDone.Name = "BtnDone"
        Me.BtnDone.Size = New System.Drawing.Size(75, 23)
        Me.BtnDone.TabIndex = 8
        Me.BtnDone.Text = "Done"
        Me.BtnDone.UseVisualStyleBackColor = True
        '
        'TBoxEvery
        '
        Me.TBoxEvery.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxEvery.Location = New System.Drawing.Point(65, 119)
        Me.TBoxEvery.Name = "TBoxEvery"
        Me.TBoxEvery.Size = New System.Drawing.Size(52, 20)
        Me.TBoxEvery.TabIndex = 7
        Me.TBoxEvery.Text = "1"
        Me.TBoxEvery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBoxTo
        '
        Me.TBoxTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxTo.Location = New System.Drawing.Point(151, 79)
        Me.TBoxTo.Name = "TBoxTo"
        Me.TBoxTo.Size = New System.Drawing.Size(52, 20)
        Me.TBoxTo.TabIndex = 6
        Me.TBoxTo.Text = "400"
        Me.TBoxTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(123, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "To"
        '
        'TBoxFrom
        '
        Me.TBoxFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBoxFrom.Location = New System.Drawing.Point(65, 79)
        Me.TBoxFrom.Name = "TBoxFrom"
        Me.TBoxFrom.Size = New System.Drawing.Size(52, 20)
        Me.TBoxFrom.TabIndex = 4
        Me.TBoxFrom.Text = "1"
        Me.TBoxFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RadioBtnEvery
        '
        Me.RadioBtnEvery.AutoSize = True
        Me.RadioBtnEvery.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBtnEvery.Location = New System.Drawing.Point(7, 120)
        Me.RadioBtnEvery.Name = "RadioBtnEvery"
        Me.RadioBtnEvery.Size = New System.Drawing.Size(57, 17)
        Me.RadioBtnEvery.TabIndex = 3
        Me.RadioBtnEvery.Text = "Every"
        Me.RadioBtnEvery.UseVisualStyleBackColor = True
        '
        'RadioBtnSelection
        '
        Me.RadioBtnSelection.AutoSize = True
        Me.RadioBtnSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBtnSelection.Location = New System.Drawing.Point(6, 160)
        Me.RadioBtnSelection.Name = "RadioBtnSelection"
        Me.RadioBtnSelection.Size = New System.Drawing.Size(78, 17)
        Me.RadioBtnSelection.TabIndex = 2
        Me.RadioBtnSelection.Text = "Selection"
        Me.RadioBtnSelection.UseVisualStyleBackColor = True
        '
        'RadioBtnFromTo
        '
        Me.RadioBtnFromTo.AutoSize = True
        Me.RadioBtnFromTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBtnFromTo.Location = New System.Drawing.Point(7, 80)
        Me.RadioBtnFromTo.Name = "RadioBtnFromTo"
        Me.RadioBtnFromTo.Size = New System.Drawing.Size(52, 17)
        Me.RadioBtnFromTo.TabIndex = 1
        Me.RadioBtnFromTo.Text = "From"
        Me.RadioBtnFromTo.UseVisualStyleBackColor = True
        '
        'RadioBtnAll
        '
        Me.RadioBtnAll.AutoSize = True
        Me.RadioBtnAll.Checked = True
        Me.RadioBtnAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBtnAll.Location = New System.Drawing.Point(7, 40)
        Me.RadioBtnAll.Name = "RadioBtnAll"
        Me.RadioBtnAll.Size = New System.Drawing.Size(92, 17)
        Me.RadioBtnAll.TabIndex = 0
        Me.RadioBtnAll.TabStop = True
        Me.RadioBtnAll.Text = "All Sections"
        Me.RadioBtnAll.UseVisualStyleBackColor = True
        '
        'DGVSelection
        '
        Me.DGVSelection.AllowUserToAddRows = False
        Me.DGVSelection.AllowUserToDeleteRows = False
        Me.DGVSelection.AllowUserToResizeColumns = False
        Me.DGVSelection.AllowUserToResizeRows = False
        Me.DGVSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSelection.Location = New System.Drawing.Point(13, 229)
        Me.DGVSelection.Name = "DGVSelection"
        Me.DGVSelection.ReadOnly = True
        Me.DGVSelection.RowHeadersWidth = 20
        Me.DGVSelection.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGVSelection.Size = New System.Drawing.Size(360, 180)
        Me.DGVSelection.TabIndex = 1
        '
        'ZCrossSectionSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 432)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGVSelection)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ZCrossSectionSelection"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Z Cross Section Selection"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGVSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TBoxFrom As System.Windows.Forms.TextBox
    Friend WithEvents RadioBtnEvery As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnSelection As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnFromTo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnAll As System.Windows.Forms.RadioButton
    Friend WithEvents TBoxEvery As System.Windows.Forms.TextBox
    Friend WithEvents TBoxTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnDone As System.Windows.Forms.Button
    Friend WithEvents DGVSelection As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
