<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Medicine_Purchase_Report
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Medicine_Purchase_Report))
        Me.NewRecord = New System.Windows.Forms.Button()
        Me.txtname = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtbilltype = New System.Windows.Forms.ComboBox()
        Me.txtmsid = New System.Windows.Forms.TextBox()
        Me.txtbtid = New System.Windows.Forms.TextBox()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NewRecord
        '
        Me.NewRecord.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewRecord.Location = New System.Drawing.Point(168, 183)
        Me.NewRecord.Name = "NewRecord"
        Me.NewRecord.Size = New System.Drawing.Size(85, 27)
        Me.NewRecord.TabIndex = 0
        Me.NewRecord.Text = "&Generate"
        Me.NewRecord.UseVisualStyleBackColor = True
        '
        'txtname
        '
        Me.txtname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtname.FormattingEnabled = True
        Me.txtname.Location = New System.Drawing.Point(168, 28)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(202, 21)
        Me.txtname.TabIndex = 66
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "To Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 19)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "From Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bill Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Medicine Supplier"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label11.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(21, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(205, 22)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "Medicine Purchase Report"
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.btnclose)
        Me.panel1.Controls.Add(Me.DateTimePicker2)
        Me.panel1.Controls.Add(Me.DateTimePicker1)
        Me.panel1.Controls.Add(Me.txtbilltype)
        Me.panel1.Controls.Add(Me.txtname)
        Me.panel1.Controls.Add(Me.NewRecord)
        Me.panel1.Controls.Add(Me.Label3)
        Me.panel1.Controls.Add(Me.Label4)
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.Label1)
        Me.panel1.Location = New System.Drawing.Point(21, 50)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(403, 229)
        Me.panel1.TabIndex = 82
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(274, 182)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(94, 28)
        Me.btnclose.TabIndex = 70
        Me.btnclose.Text = "&Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(168, 142)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 69
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = ""
        Me.DateTimePicker1.Location = New System.Drawing.Point(168, 103)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 69
        '
        'txtbilltype
        '
        Me.txtbilltype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtbilltype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtbilltype.FormattingEnabled = True
        Me.txtbilltype.Location = New System.Drawing.Point(168, 68)
        Me.txtbilltype.Name = "txtbilltype"
        Me.txtbilltype.Size = New System.Drawing.Size(202, 21)
        Me.txtbilltype.TabIndex = 68
        '
        'txtmsid
        '
        Me.txtmsid.Location = New System.Drawing.Point(245, 14)
        Me.txtmsid.Name = "txtmsid"
        Me.txtmsid.Size = New System.Drawing.Size(48, 20)
        Me.txtmsid.TabIndex = 83
        '
        'txtbtid
        '
        Me.txtbtid.Location = New System.Drawing.Point(296, 14)
        Me.txtbtid.Name = "txtbtid"
        Me.txtbtid.Size = New System.Drawing.Size(48, 20)
        Me.txtbtid.TabIndex = 84
        '
        'Medicine_Purchase_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(447, 295)
        Me.Controls.Add(Me.txtbtid)
        Me.Controls.Add(Me.txtmsid)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Medicine_Purchase_Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Medicine_Purchase_Report"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents NewRecord As Button
    Friend WithEvents txtname As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents panel1 As Panel
    Friend WithEvents txtbilltype As ComboBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Public WithEvents btnclose As Button
    Friend WithEvents txtmsid As TextBox
    Friend WithEvents txtbtid As TextBox
End Class
