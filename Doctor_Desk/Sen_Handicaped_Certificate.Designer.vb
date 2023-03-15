<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sen_Handicaped_Certificate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sen_Handicaped_Certificate))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.NewRecord = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.txtquali = New System.Windows.Forms.TextBox()
        Me.txtmob = New System.Windows.Forms.TextBox()
        Me.txtreg = New System.Windows.Forms.TextBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdname = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtpname = New System.Windows.Forms.TextBox()
        Me.txtbankname = New System.Windows.Forms.TextBox()
        Me.txtrelation = New System.Windows.Forms.TextBox()
        Me.txtrname = New System.Windows.Forms.TextBox()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 19)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Relative Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 19)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Relation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 19)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Bank Name"
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(315, 214)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(94, 28)
        Me.btnclose.TabIndex = 68
        Me.btnclose.Text = "&Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'NewRecord
        '
        Me.NewRecord.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewRecord.Location = New System.Drawing.Point(170, 215)
        Me.NewRecord.Name = "NewRecord"
        Me.NewRecord.Size = New System.Drawing.Size(94, 27)
        Me.NewRecord.TabIndex = 67
        Me.NewRecord.Text = "&Generate"
        Me.NewRecord.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label11.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(12, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(314, 22)
        Me.Label11.TabIndex = 102
        Me.Label11.Text = "Senior Citizen / Handicapped  Certificate"
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.txtrname)
        Me.panel1.Controls.Add(Me.txtrelation)
        Me.panel1.Controls.Add(Me.txtbankname)
        Me.panel1.Controls.Add(Me.txtpname)
        Me.panel1.Controls.Add(Me.DateTimePicker1)
        Me.panel1.Controls.Add(Me.txtdname)
        Me.panel1.Controls.Add(Me.txtquali)
        Me.panel1.Controls.Add(Me.txtmob)
        Me.panel1.Controls.Add(Me.txtreg)
        Me.panel1.Controls.Add(Me.txtadd)
        Me.panel1.Controls.Add(Me.Label6)
        Me.panel1.Controls.Add(Me.Label5)
        Me.panel1.Controls.Add(Me.Label3)
        Me.panel1.Controls.Add(Me.Label4)
        Me.panel1.Controls.Add(Me.btnclose)
        Me.panel1.Controls.Add(Me.NewRecord)
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.Label1)
        Me.panel1.Location = New System.Drawing.Point(12, 47)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(456, 255)
        Me.panel1.TabIndex = 103
        '
        'txtquali
        '
        Me.txtquali.Enabled = False
        Me.txtquali.Location = New System.Drawing.Point(375, -14)
        Me.txtquali.Name = "txtquali"
        Me.txtquali.Size = New System.Drawing.Size(63, 20)
        Me.txtquali.TabIndex = 114
        Me.txtquali.Visible = False
        '
        'txtmob
        '
        Me.txtmob.Enabled = False
        Me.txtmob.Location = New System.Drawing.Point(306, -14)
        Me.txtmob.Name = "txtmob"
        Me.txtmob.Size = New System.Drawing.Size(63, 20)
        Me.txtmob.TabIndex = 113
        Me.txtmob.Visible = False
        '
        'txtreg
        '
        Me.txtreg.Enabled = False
        Me.txtreg.Location = New System.Drawing.Point(237, -14)
        Me.txtreg.Name = "txtreg"
        Me.txtreg.Size = New System.Drawing.Size(63, 20)
        Me.txtreg.TabIndex = 112
        Me.txtreg.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Enabled = False
        Me.txtadd.Location = New System.Drawing.Point(168, -14)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(63, 20)
        Me.txtadd.TabIndex = 111
        Me.txtadd.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 19)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Patient Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Doctor Name"
        '
        'txtdname
        '
        Me.txtdname.FormattingEnabled = True
        Me.txtdname.Location = New System.Drawing.Point(143, 15)
        Me.txtdname.Name = "txtdname"
        Me.txtdname.Size = New System.Drawing.Size(266, 21)
        Me.txtdname.TabIndex = 115
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(143, 43)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(182, 20)
        Me.DateTimePicker1.TabIndex = 116
        '
        'txtpname
        '
        Me.txtpname.Location = New System.Drawing.Point(143, 77)
        Me.txtpname.Name = "txtpname"
        Me.txtpname.Size = New System.Drawing.Size(266, 20)
        Me.txtpname.TabIndex = 117
        '
        'txtbankname
        '
        Me.txtbankname.Location = New System.Drawing.Point(143, 108)
        Me.txtbankname.Name = "txtbankname"
        Me.txtbankname.Size = New System.Drawing.Size(266, 20)
        Me.txtbankname.TabIndex = 118
        '
        'txtrelation
        '
        Me.txtrelation.Location = New System.Drawing.Point(143, 144)
        Me.txtrelation.Name = "txtrelation"
        Me.txtrelation.Size = New System.Drawing.Size(266, 20)
        Me.txtrelation.TabIndex = 119
        '
        'txtrname
        '
        Me.txtrname.Location = New System.Drawing.Point(143, 175)
        Me.txtrname.Name = "txtrname"
        Me.txtrname.Size = New System.Drawing.Size(266, 20)
        Me.txtrname.TabIndex = 120
        '
        'Sen_Handicaped_Certificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(487, 312)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Sen_Handicaped_Certificate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sen_Handicaped_Certificate"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Public WithEvents btnclose As Button
    Public WithEvents NewRecord As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtquali As TextBox
    Friend WithEvents txtmob As TextBox
    Friend WithEvents txtreg As TextBox
    Friend WithEvents txtadd As TextBox
    Friend WithEvents txtdname As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents txtpname As TextBox
    Friend WithEvents txtbankname As TextBox
    Friend WithEvents txtrelation As TextBox
    Friend WithEvents txtrname As TextBox
End Class
