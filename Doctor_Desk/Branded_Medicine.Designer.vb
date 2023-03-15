<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Branded_Medicine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Branded_Medicine))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.Delete = New System.Windows.Forms.Button()
        Me.Update_record = New System.Windows.Forms.Button()
        Me.NewRecord = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.txttt = New System.Windows.Forms.ComboBox()
        Me.txtdrug = New System.Windows.Forms.ComboBox()
        Me.txtdatetime = New System.Windows.Forms.TextBox()
        Me.txtcompany = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.txtttid = New System.Windows.Forms.TextBox()
        Me.txtbdtid = New System.Windows.Forms.TextBox()
        Me.txtmtid = New System.Windows.Forms.TextBox()
        Me.dgw = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnclose)
        Me.Panel2.Controls.Add(Me.btnsave)
        Me.Panel2.Controls.Add(Me.Delete)
        Me.Panel2.Controls.Add(Me.Update_record)
        Me.Panel2.Controls.Add(Me.NewRecord)
        Me.Panel2.Location = New System.Drawing.Point(430, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(123, 187)
        Me.Panel2.TabIndex = 73
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(13, 143)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(94, 28)
        Me.btnclose.TabIndex = 5
        Me.btnclose.Text = "&Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Enabled = False
        Me.btnsave.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(13, 44)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(94, 27)
        Me.btnsave.TabIndex = 3
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Delete
        '
        Me.Delete.Enabled = False
        Me.Delete.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Delete.Location = New System.Drawing.Point(13, 110)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(94, 27)
        Me.Delete.TabIndex = 2
        Me.Delete.Text = "&Delete"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'Update_record
        '
        Me.Update_record.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Update_record.Location = New System.Drawing.Point(13, 77)
        Me.Update_record.Name = "Update_record"
        Me.Update_record.Size = New System.Drawing.Size(94, 27)
        Me.Update_record.TabIndex = 1
        Me.Update_record.Text = "&Update"
        Me.Update_record.UseVisualStyleBackColor = True
        '
        'NewRecord
        '
        Me.NewRecord.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewRecord.Location = New System.Drawing.Point(13, 11)
        Me.NewRecord.Name = "NewRecord"
        Me.NewRecord.Size = New System.Drawing.Size(94, 27)
        Me.NewRecord.TabIndex = 0
        Me.NewRecord.Text = "&New"
        Me.NewRecord.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label11.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(12, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(179, 22)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "Branded Medicine List"
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.txtname)
        Me.panel1.Controls.Add(Me.txttt)
        Me.panel1.Controls.Add(Me.txtdrug)
        Me.panel1.Controls.Add(Me.txtdatetime)
        Me.panel1.Controls.Add(Me.txtcompany)
        Me.panel1.Controls.Add(Me.Label3)
        Me.panel1.Controls.Add(Me.Label4)
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.Label1)
        Me.panel1.Location = New System.Drawing.Point(12, 45)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(403, 187)
        Me.panel1.TabIndex = 72
        '
        'txtname
        '
        Me.txtname.Location = New System.Drawing.Point(157, 67)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(224, 20)
        Me.txtname.TabIndex = 75
        '
        'txttt
        '
        Me.txttt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txttt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txttt.FormattingEnabled = True
        Me.txttt.Location = New System.Drawing.Point(157, 30)
        Me.txttt.Name = "txttt"
        Me.txttt.Size = New System.Drawing.Size(224, 21)
        Me.txttt.TabIndex = 66
        '
        'txtdrug
        '
        Me.txtdrug.FormattingEnabled = True
        Me.txtdrug.Location = New System.Drawing.Point(157, 104)
        Me.txtdrug.Name = "txtdrug"
        Me.txtdrug.Size = New System.Drawing.Size(224, 21)
        Me.txtdrug.TabIndex = 65
        '
        'txtdatetime
        '
        Me.txtdatetime.Location = New System.Drawing.Point(264, 3)
        Me.txtdatetime.Name = "txtdatetime"
        Me.txtdatetime.Size = New System.Drawing.Size(117, 20)
        Me.txtdatetime.TabIndex = 74
        Me.txtdatetime.Visible = False
        '
        'txtcompany
        '
        Me.txtcompany.Location = New System.Drawing.Point(157, 143)
        Me.txtcompany.Name = "txtcompany"
        Me.txtcompany.Size = New System.Drawing.Size(224, 20)
        Me.txtcompany.TabIndex = 64
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 19)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Company Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 19)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Drug Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Medicine Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Treatment Type"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(197, 9)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(45, 20)
        Me.txtid.TabIndex = 67
        Me.txtid.Visible = False
        '
        'txtttid
        '
        Me.txtttid.Location = New System.Drawing.Point(248, 10)
        Me.txtttid.Name = "txtttid"
        Me.txtttid.Size = New System.Drawing.Size(45, 20)
        Me.txtttid.TabIndex = 75
        Me.txtttid.Visible = False
        '
        'txtbdtid
        '
        Me.txtbdtid.Location = New System.Drawing.Point(299, 11)
        Me.txtbdtid.Name = "txtbdtid"
        Me.txtbdtid.Size = New System.Drawing.Size(45, 20)
        Me.txtbdtid.TabIndex = 76
        Me.txtbdtid.Visible = False
        '
        'txtmtid
        '
        Me.txtmtid.Location = New System.Drawing.Point(349, 11)
        Me.txtmtid.Name = "txtmtid"
        Me.txtmtid.Size = New System.Drawing.Size(45, 20)
        Me.txtmtid.TabIndex = 77
        Me.txtmtid.Visible = False
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column10, Me.Column3, Me.Column6, Me.Column5, Me.Column8})
        Me.dgw.GridColor = System.Drawing.SystemColors.ButtonShadow
        Me.dgw.Location = New System.Drawing.Point(12, 238)
        Me.dgw.Name = "dgw"
        Me.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgw.Size = New System.Drawing.Size(541, 410)
        Me.dgw.TabIndex = 92
        '
        'Column1
        '
        Me.Column1.HeaderText = "Id"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Medicine Name"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 150
        '
        'Column10
        '
        Me.Column10.HeaderText = "Branded DrugType ID"
        Me.Column10.Name = "Column10"
        Me.Column10.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Company Name"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 150
        '
        'Column6
        '
        Me.Column6.HeaderText = "Date and Time"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 150
        '
        'Column5
        '
        Me.Column5.HeaderText = "Medicine Type ID"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "Treatment Type ID"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'Branded_Medicine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(558, 538)
        Me.Controls.Add(Me.dgw)
        Me.Controls.Add(Me.txtmtid)
        Me.Controls.Add(Me.txtbdtid)
        Me.Controls.Add(Me.txtttid)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Branded_Medicine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Branded_Medicine"
        Me.Panel2.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Public WithEvents btnsave As Button
    Public WithEvents Delete As Button
    Public WithEvents Update_record As Button
    Public WithEvents NewRecord As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents panel1 As Panel
    Friend WithEvents txtdrug As ComboBox
    Friend WithEvents txtcompany As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txttt As ComboBox
    Friend WithEvents txtid As TextBox
    Friend WithEvents txtdatetime As TextBox
    Friend WithEvents txtttid As TextBox
    Friend WithEvents txtbdtid As TextBox
    Friend WithEvents txtmtid As TextBox
    Friend WithEvents txtname As TextBox
    Friend WithEvents dgw As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Public WithEvents btnclose As Button
End Class
