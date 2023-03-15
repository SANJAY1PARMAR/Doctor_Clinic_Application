<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Generic_Medicine_List
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Generic_Medicine_List))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Save = New System.Windows.Forms.Button()
        Me.Delete = New System.Windows.Forms.Button()
        Me.Update_record = New System.Windows.Forms.Button()
        Me.NewRecord = New System.Windows.Forms.Button()
        Me.txtname = New System.Windows.Forms.ComboBox()
        Me.txtcom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdatetime = New System.Windows.Forms.TextBox()
        Me.txtmtid = New System.Windows.Forms.TextBox()
        Me.dgw = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnclose)
        Me.Panel2.Controls.Add(Me.Save)
        Me.Panel2.Controls.Add(Me.Delete)
        Me.Panel2.Controls.Add(Me.Update_record)
        Me.Panel2.Controls.Add(Me.NewRecord)
        Me.Panel2.Location = New System.Drawing.Point(19, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(423, 94)
        Me.Panel2.TabIndex = 84
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(12, 52)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(94, 28)
        Me.btnclose.TabIndex = 5
        Me.btnclose.Text = "&Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'Save
        '
        Me.Save.Enabled = False
        Me.Save.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save.Location = New System.Drawing.Point(112, 19)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(94, 27)
        Me.Save.TabIndex = 3
        Me.Save.Text = "&Save"
        Me.Save.UseVisualStyleBackColor = True
        '
        'Delete
        '
        Me.Delete.Enabled = False
        Me.Delete.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Delete.Location = New System.Drawing.Point(312, 19)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(94, 27)
        Me.Delete.TabIndex = 2
        Me.Delete.Text = "&Delete"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'Update_record
        '
        Me.Update_record.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Update_record.Location = New System.Drawing.Point(212, 19)
        Me.Update_record.Name = "Update_record"
        Me.Update_record.Size = New System.Drawing.Size(94, 27)
        Me.Update_record.TabIndex = 1
        Me.Update_record.Text = "&Update"
        Me.Update_record.UseVisualStyleBackColor = True
        '
        'NewRecord
        '
        Me.NewRecord.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewRecord.Location = New System.Drawing.Point(12, 19)
        Me.NewRecord.Name = "NewRecord"
        Me.NewRecord.Size = New System.Drawing.Size(94, 27)
        Me.NewRecord.TabIndex = 0
        Me.NewRecord.Text = "&New"
        Me.NewRecord.UseVisualStyleBackColor = True
        '
        'txtname
        '
        Me.txtname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtname.FormattingEnabled = True
        Me.txtname.Location = New System.Drawing.Point(157, 11)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(285, 21)
        Me.txtname.TabIndex = 66
        '
        'txtcom
        '
        Me.txtcom.Location = New System.Drawing.Point(157, 48)
        Me.txtcom.Name = "txtcom"
        Me.txtcom.Size = New System.Drawing.Size(285, 20)
        Me.txtcom.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company Name"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(191, 12)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(48, 20)
        Me.txtid.TabIndex = 81
        Me.txtid.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label11.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(12, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 22)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "Generic Medicine List"
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.txtname)
        Me.panel1.Controls.Add(Me.Panel2)
        Me.panel1.Controls.Add(Me.txtcom)
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.Label1)
        Me.panel1.Location = New System.Drawing.Point(12, 45)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(456, 195)
        Me.panel1.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Medicine Name"
        '
        'txtdatetime
        '
        Me.txtdatetime.Location = New System.Drawing.Point(245, 11)
        Me.txtdatetime.Name = "txtdatetime"
        Me.txtdatetime.Size = New System.Drawing.Size(94, 20)
        Me.txtdatetime.TabIndex = 87
        Me.txtdatetime.Visible = False
        '
        'txtmtid
        '
        Me.txtmtid.Location = New System.Drawing.Point(345, 12)
        Me.txtmtid.Name = "txtmtid"
        Me.txtmtid.Size = New System.Drawing.Size(52, 20)
        Me.txtmtid.TabIndex = 88
        Me.txtmtid.Visible = False
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column6})
        Me.dgw.GridColor = System.Drawing.SystemColors.ButtonShadow
        Me.dgw.Location = New System.Drawing.Point(12, 246)
        Me.dgw.Name = "dgw"
        Me.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgw.Size = New System.Drawing.Size(456, 410)
        Me.dgw.TabIndex = 89
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
        '
        'Generic_Medicine_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 663)
        Me.Controls.Add(Me.dgw)
        Me.Controls.Add(Me.txtmtid)
        Me.Controls.Add(Me.txtdatetime)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Generic_Medicine_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmmedicinemaster"
        Me.Panel2.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Public WithEvents Save As Button
    Public WithEvents Delete As Button
    Public WithEvents Update_record As Button
    Public WithEvents NewRecord As Button
    Friend WithEvents txtname As ComboBox
    Friend WithEvents txtcom As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtid As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtdatetime As TextBox
    Friend WithEvents txtmtid As TextBox
    Friend WithEvents dgw As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Public WithEvents btnclose As Button
End Class
