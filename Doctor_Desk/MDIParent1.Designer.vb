<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.MasterMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenericMedicineListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreatmentMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DailyVisitedPatientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedicinePurchaseDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BillPaymemtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedicineSupplierReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CertificatesReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FitnessCertificateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnFitCertificateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeaveCertificateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SenCitizenHandicapCertificateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterMenu, Me.TreatmentMenu, Me.AdminMenu, Me.ToolsMenu, Me.ExitMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.ExitMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip.Size = New System.Drawing.Size(948, 25)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'MasterMenu
        '
        Me.MasterMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenericMedicineListToolStripMenuItem, Me.OpenToolStripMenuItem, Me.ToolStripSeparator3, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator4, Me.PrintSetupToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.MasterMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.MasterMenu.Name = "MasterMenu"
        Me.MasterMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.MasterMenu.Size = New System.Drawing.Size(91, 19)
        Me.MasterMenu.Text = "&Master Forms"
        '
        'GenericMedicineListToolStripMenuItem
        '
        Me.GenericMedicineListToolStripMenuItem.Name = "GenericMedicineListToolStripMenuItem"
        Me.GenericMedicineListToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GenericMedicineListToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.GenericMedicineListToolStripMenuItem.Text = "&Generic Medicine List"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.OpenToolStripMenuItem.Text = "&Branded Drug List"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(226, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.SaveToolStripMenuItem.Text = "&Medicine Supplier"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.SaveAsToolStripMenuItem.Text = "&User"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(226, 6)
        '
        'PrintSetupToolStripMenuItem
        '
        Me.PrintSetupToolStripMenuItem.Name = "PrintSetupToolStripMenuItem"
        Me.PrintSetupToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.PrintSetupToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.PrintSetupToolStripMenuItem.Text = "&Consultant Master"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(226, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'TreatmentMenu
        '
        Me.TreatmentMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator7, Me.SelectAllToolStripMenuItem, Me.DailyVisitedPatientsToolStripMenuItem})
        Me.TreatmentMenu.Name = "TreatmentMenu"
        Me.TreatmentMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.TreatmentMenu.Size = New System.Drawing.Size(72, 19)
        Me.TreatmentMenu.Text = "&Treatment"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(222, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SelectAllToolStripMenuItem.Text = "&Patient Tretment"
        '
        'AdminMenu
        '
        Me.AdminMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MedicinePurchaseDetailsToolStripMenuItem, Me.BillPaymemtToolStripMenuItem, Me.MedicineSupplierReportToolStripMenuItem, Me.CertificatesReportsToolStripMenuItem})
        Me.AdminMenu.Name = "AdminMenu"
        Me.AdminMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AdminMenu.Size = New System.Drawing.Size(55, 19)
        Me.AdminMenu.Text = "&Admin"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(46, 19)
        Me.ToolsMenu.Text = "&Tools"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'ExitMenu
        '
        Me.ExitMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseAllToolStripMenuItem})
        Me.ExitMenu.Name = "ExitMenu"
        Me.ExitMenu.Size = New System.Drawing.Size(38, 19)
        Me.ExitMenu.Text = "&Exit"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 19)
        Me.HelpMenu.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(165, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 640)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(948, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'DailyVisitedPatientsToolStripMenuItem
        '
        Me.DailyVisitedPatientsToolStripMenuItem.Name = "DailyVisitedPatientsToolStripMenuItem"
        Me.DailyVisitedPatientsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DailyVisitedPatientsToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.DailyVisitedPatientsToolStripMenuItem.Text = "&Daily Visited Patients"
        '
        'MedicinePurchaseDetailsToolStripMenuItem
        '
        Me.MedicinePurchaseDetailsToolStripMenuItem.Name = "MedicinePurchaseDetailsToolStripMenuItem"
        Me.MedicinePurchaseDetailsToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.MedicinePurchaseDetailsToolStripMenuItem.Text = "Medicine Purchase Details"
        '
        'BillPaymemtToolStripMenuItem
        '
        Me.BillPaymemtToolStripMenuItem.Name = "BillPaymemtToolStripMenuItem"
        Me.BillPaymemtToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.BillPaymemtToolStripMenuItem.Text = "Bill Paymemt"
        '
        'MedicineSupplierReportToolStripMenuItem
        '
        Me.MedicineSupplierReportToolStripMenuItem.Name = "MedicineSupplierReportToolStripMenuItem"
        Me.MedicineSupplierReportToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.MedicineSupplierReportToolStripMenuItem.Text = "Medicine Supplier Report"
        '
        'CertificatesReportsToolStripMenuItem
        '
        Me.CertificatesReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FitnessCertificateToolStripMenuItem, Me.UnFitCertificateToolStripMenuItem, Me.LeaveCertificateToolStripMenuItem, Me.SenCitizenHandicapCertificateToolStripMenuItem})
        Me.CertificatesReportsToolStripMenuItem.Name = "CertificatesReportsToolStripMenuItem"
        Me.CertificatesReportsToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.CertificatesReportsToolStripMenuItem.Text = "Certificates / Reports"
        '
        'FitnessCertificateToolStripMenuItem
        '
        Me.FitnessCertificateToolStripMenuItem.Name = "FitnessCertificateToolStripMenuItem"
        Me.FitnessCertificateToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.FitnessCertificateToolStripMenuItem.Text = "Fitness Certificate"
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
        'SenCitizenHandicapCertificateToolStripMenuItem
        '
        Me.SenCitizenHandicapCertificateToolStripMenuItem.Name = "SenCitizenHandicapCertificateToolStripMenuItem"
        Me.SenCitizenHandicapCertificateToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.SenCitizenHandicapCertificateToolStripMenuItem.Text = "Sen.Citizen / Handicap Certificate"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(948, 662)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MDIParent1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Doctor Desk"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents TreatmentMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenericMedicineListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DailyVisitedPatientsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MedicinePurchaseDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BillPaymemtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MedicineSupplierReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CertificatesReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FitnessCertificateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnFitCertificateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LeaveCertificateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SenCitizenHandicapCertificateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As ToolStripMenuItem
End Class
