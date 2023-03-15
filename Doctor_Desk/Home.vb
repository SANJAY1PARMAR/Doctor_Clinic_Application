Public Class Home

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub



    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Hide()
        Medicine_Supplier.Show()
    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Branded_Medicine.Show()
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Bill_Payment.Show()
    End Sub

    Private Sub DesignationMasterToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub CashVouchaerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashVouchaerToolStripMenuItem.Click
        'Me.Hide()
        Patient_Treatment_Main.Show()
    End Sub

    Private Sub COunsultantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COunsultantToolStripMenuItem.Click
        Me.Hide()
        Consultant_Master.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SalesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem1.Click
        Me.Hide()
        Daily_Visited_Patient.Show()
    End Sub



    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Home_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        End
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Medicine_Purchase_Details.Show()
    End Sub

    Private Sub ManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem.Click

    End Sub

    Private Sub MedicinePurchaseReportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Medicine_Purchase_Report.Show()
    End Sub

    Private Sub MedicineMasterToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ExitToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        End
    End Sub

    Private Sub UnitToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GeneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneToolStripMenuItem.Click
        Me.Hide()
        Generic_Medicine_List.Show()
    End Sub

    Private Sub BrandedDrugListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrandedDrugListToolStripMenuItem.Click
        Me.Hide()
        Branded_Medicine.Show()
    End Sub

    Private Sub GenericMedicineLidtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenericMedicineLidtToolStripMenuItem.Click
        Me.Hide()
        User_Master.Show()
    End Sub

    Private Sub MedicinePurchaseReportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MedicinePurchaseReportToolStripMenuItem1.Click

        Me.Hide()
        Medicine_Purchase_Details.Reset()
        Medicine_Purchase_Details.ShowDialog()
    End Sub

    Private Sub BillPaymemtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillPaymemtToolStripMenuItem.Click
        Me.Hide()
        Bill_Payment.Show()
    End Sub

    Private Sub CertificatesReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CertificatesReportsToolStripMenuItem.Click

    End Sub

    Private Sub FitnessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FitnessToolStripMenuItem.Click
        Me.Hide()
        Fitness_Certificate.Show()
    End Sub

    Private Sub MedicineSupplierBillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicineSupplierBillToolStripMenuItem.Click
        Me.Hide()
        Medicine_Purchase_Report.Show()
    End Sub

    Private Sub PTMToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Hide()
        Patient_Treatment_Main.Show()
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        'Me.Hide()
        'MDIParent1.Show()

    End Sub

    Private Sub UnFitCertificateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnFitCertificateToolStripMenuItem.Click
        Me.Hide()
        UnFIt_Certificate.Show()
    End Sub

    Private Sub LeaveCertificateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeaveCertificateToolStripMenuItem.Click
        Me.Hide()
        Leave_Certificate.Show()
    End Sub

    Private Sub SnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SnToolStripMenuItem.Click
        Me.Hide()
        Sen_Handicaped_Certificate.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Hide()
        frmAbout.Show()
    End Sub

    Private Sub VouchaerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VouchaerToolStripMenuItem.Click

    End Sub
End Class