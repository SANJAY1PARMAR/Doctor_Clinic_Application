<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrandedDrugListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenericMedicineLidtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COunsultantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.VouchaerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashVouchaerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedicinePurchaseReportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BillPaymemtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedicineSupplierBillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CertificatesReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FitnessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnFitCertificateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeaveCertificateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblEmployeeNo = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ManageToolStripMenuItem
        '
        Me.ManageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneToolStripMenuItem, Me.BrandedDrugListToolStripMenuItem, Me.ToolStripMenuItem1, Me.GenericMedicineLidtToolStripMenuItem, Me.COunsultantToolStripMenuItem})
        Me.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem"
        Me.ManageToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.ManageToolStripMenuItem.Text = "Master Forms"
        '
        'GeneToolStripMenuItem
        '
        Me.GeneToolStripMenuItem.Name = "GeneToolStripMenuItem"
        Me.GeneToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GeneToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.GeneToolStripMenuItem.Text = "Generic Medicine List"
        '
        'BrandedDrugListToolStripMenuItem
        '
        Me.BrandedDrugListToolStripMenuItem.Name = "BrandedDrugListToolStripMenuItem"
        Me.BrandedDrugListToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BrandedDrugListToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.BrandedDrugListToolStripMenuItem.Text = "Branded Drug List"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(229, 22)
        Me.ToolStripMenuItem1.Text = "Medicine Suplier"
        '
        'GenericMedicineLidtToolStripMenuItem
        '
        Me.GenericMedicineLidtToolStripMenuItem.Name = "GenericMedicineLidtToolStripMenuItem"
        Me.GenericMedicineLidtToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.GenericMedicineLidtToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.GenericMedicineLidtToolStripMenuItem.Text = "User"
        '
        'COunsultantToolStripMenuItem
        '
        Me.COunsultantToolStripMenuItem.Name = "COunsultantToolStripMenuItem"
        Me.COunsultantToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.COunsultantToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.COunsultantToolStripMenuItem.Text = "Consultant Master"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageToolStripMenuItem, Me.VouchaerToolStripMenuItem, Me.TransaToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ExitToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1069, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'VouchaerToolStripMenuItem
        '
        Me.VouchaerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CashVouchaerToolStripMenuItem, Me.SalesToolStripMenuItem1})
        Me.VouchaerToolStripMenuItem.Name = "VouchaerToolStripMenuItem"
        Me.VouchaerToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.VouchaerToolStripMenuItem.Text = "Treatment"
        '
        'CashVouchaerToolStripMenuItem
        '
        Me.CashVouchaerToolStripMenuItem.Name = "CashVouchaerToolStripMenuItem"
        Me.CashVouchaerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.CashVouchaerToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CashVouchaerToolStripMenuItem.Text = "Patient Tretment"
        '
        'SalesToolStripMenuItem1
        '
        Me.SalesToolStripMenuItem1.Name = "SalesToolStripMenuItem1"
        Me.SalesToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.SalesToolStripMenuItem1.Size = New System.Drawing.Size(225, 22)
        Me.SalesToolStripMenuItem1.Text = "Daily Visited Patients"
        '
        'TransaToolStripMenuItem
        '
        Me.TransaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MedicinePurchaseReportToolStripMenuItem1, Me.BillPaymemtToolStripMenuItem, Me.MedicineSupplierBillToolStripMenuItem, Me.CertificatesReportsToolStripMenuItem})
        Me.TransaToolStripMenuItem.Name = "TransaToolStripMenuItem"
        Me.TransaToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.TransaToolStripMenuItem.Text = "Admin"
        '
        'MedicinePurchaseReportToolStripMenuItem1
        '
        Me.MedicinePurchaseReportToolStripMenuItem1.Name = "MedicinePurchaseReportToolStripMenuItem1"
        Me.MedicinePurchaseReportToolStripMenuItem1.Size = New System.Drawing.Size(212, 22)
        Me.MedicinePurchaseReportToolStripMenuItem1.Text = "Medicine Purchase Details"
        '
        'BillPaymemtToolStripMenuItem
        '
        Me.BillPaymemtToolStripMenuItem.Name = "BillPaymemtToolStripMenuItem"
        Me.BillPaymemtToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.BillPaymemtToolStripMenuItem.Text = "Bill Paymemt"
        '
        'MedicineSupplierBillToolStripMenuItem
        '
        Me.MedicineSupplierBillToolStripMenuItem.Name = "MedicineSupplierBillToolStripMenuItem"
        Me.MedicineSupplierBillToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.MedicineSupplierBillToolStripMenuItem.Text = "Medicine Supplier Report"
        '
        'CertificatesReportsToolStripMenuItem
        '
        Me.CertificatesReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FitnessToolStripMenuItem, Me.UnFitCertificateToolStripMenuItem, Me.LeaveCertificateToolStripMenuItem, Me.SnToolStripMenuItem})
        Me.CertificatesReportsToolStripMenuItem.Name = "CertificatesReportsToolStripMenuItem"
        Me.CertificatesReportsToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.CertificatesReportsToolStripMenuItem.Text = "Certificates / Reports"
        '
        'FitnessToolStripMenuItem
        '
        Me.FitnessToolStripMenuItem.Name = "FitnessToolStripMenuItem"
        Me.FitnessToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FitnessToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.FitnessToolStripMenuItem.Text = "Fitness Certificate"
        '
        'UnFitCertificateToolStripMenuItem
        '
        Me.UnFitCertificateToolStripMenuItem.Name = "UnFitCertificateToolStripMenuItem"
        Me.UnFitCertificateToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.UnFitCertificateToolStripMenuItem.Text = "UnFit Certificate"
        '
        'LeaveCertificateToolStripMenuItem
        '
        Me.LeaveCertificateToolStripMenuItem.Name = "LeaveCertificateToolStripMenuItem"
        Me.LeaveCertificateToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.LeaveCertificateToolStripMenuItem.Text = "Leave Certificate"
        '
        'SnToolStripMenuItem
        '
        Me.SnToolStripMenuItem.Name = "SnToolStripMenuItem"
        Me.SnToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.SnToolStripMenuItem.Text = "Sen.Citizen / Handicap Certificate"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PropertyPage
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.ReportToolStripMenuItem.Text = "Active Forms"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(38, 20)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'lblEmployeeNo
        '
        Me.lblEmployeeNo.AutoSize = True
        Me.lblEmployeeNo.Location = New System.Drawing.Point(569, 11)
        Me.lblEmployeeNo.Name = "lblEmployeeNo"
        Me.lblEmployeeNo.Size = New System.Drawing.Size(77, 13)
        Me.lblEmployeeNo.TabIndex = 15
        Me.lblEmployeeNo.Text = "lblEmployeeNo"
        Me.lblEmployeeNo.Visible = False
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1069, 506)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lblEmployeeNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ManageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents VouchaerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashVouchaerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblEmployeeNo As System.Windows.Forms.Label
    Friend WithEvents CertificatesReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BrandedDrugListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents COunsultantToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MedicineSupplierBillToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MedicinePurchaseReportToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FitnessToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnFitCertificateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LeaveCertificateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BillPaymemtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GenericMedicineLidtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class
