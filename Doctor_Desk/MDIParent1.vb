Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New Generic_Medicine_List
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Generic Medicine List" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Generic_Medicine_List
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Generic Medicine List" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New User_Master
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "User Master" & m_ChildFormNumber

        ChildForm.Show()
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub


    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub GenericMedicineListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenericMedicineListToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Generic_Medicine_List
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Generic Medicine List" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Medicine_Supplier
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Medicine Supplier" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub PrintSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintSetupToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Consultant_Master
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Consultant Master" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub ExitMenu_Click(sender As Object, e As EventArgs) Handles ExitMenu.Click
        Me.Close()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Patient_Treatment_Main
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Patient Treatment Master" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub DailyVisitedPatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyVisitedPatientsToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Daily_Visited_Patient
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Daily Visited Patient" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub MedicinePurchaseDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicinePurchaseDetailsToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Medicine_Purchase_Details
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Medicine Purchase Details" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub BillPaymemtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillPaymemtToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Bill_Payment
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Bill Payment Details" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub MedicineSupplierReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicineSupplierReportToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Medicine_Purchase_Report
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Medicine Purchase Report" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub FitnessCertificateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FitnessCertificateToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Fitness_Certificate
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Fitness Certificate" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub UnFitCertificateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnFitCertificateToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New UnFIt_Certificate
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "UnFit Certificate" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub LeaveCertificateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeaveCertificateToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Leave_Certificate
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Leave Certificate" & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub SenCitizenHandicapCertificateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SenCitizenHandicapCertificateToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Sen_Handicaped_Certificate
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Sen / Handicaped Certificate" & m_ChildFormNumber

        ChildForm.Show()
    End Sub
End Class
