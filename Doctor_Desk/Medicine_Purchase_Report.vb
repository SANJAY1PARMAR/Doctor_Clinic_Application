Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Public Class Medicine_Purchase_Report

    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub Medicine_Purchase_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        ' Display the date as "22 Feb 2001".
        DateTimePicker1.CustomFormat = "dd-MMM-yyyy"

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        ' Display the date as "22 Feb 2001".
        DateTimePicker2.CustomFormat = "dd-MMM-yyyy"
        fillcombo()
        Reset()
    End Sub

    Sub Reset()
        txtname.Text = ""
        txtbilltype.Text = ""
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
    End Sub

    Sub fillcombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(MedicineSupplier) FROM medicinesuppliermaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtname.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtname.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(Size) FROM sizemaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtbilltype.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtbilltype.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NewRecord_Click(sender As Object, e As EventArgs) Handles NewRecord.Click
        If Len(Trim(txtname.Text)) = 0 Then
            MessageBox.Show("Please Select Medicine Supplier Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtname.Focus()
            Exit Sub
        End If

        Try

            Dim rpt As New Report_Medicine_Supplier 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select MedicineSupplier, PurchaseDt, Size, BillNo, MedicineName, Quntity, UnitRate, Price  from medicinesuppliermaster
                                     INNER JOIN medpurchase ON medicinesuppliermaster.ID = medpurchase.MedicineSupplierID
                                     INNER JOIN sizemaster ON sizemaster.SizeID = medpurchase.SizeId
                                     INNER JOIN medpurchasedtl ON medpurchasedtl.MedPurchaseID = medpurchase.MedPurchaseID
                                     INNER JOIN medicinemaster ON medicinemaster.MedicineID = medpurchasedtl.MedicineID
                                     where medicinesuppliermaster.ID between @d1 and @d2 order by PurchaseDt"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            MyCommand.CommandType = CommandType.Text

            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "MedicineSupplier")
            myDA.Fill(myDS, "PurchaseDt")
            myDA.Fill(myDS, "Size")
            myDA.Fill(myDS, "BillNo")
            myDA.Fill(myDS, "MedicineName")
            myDA.Fill(myDS, "Quntity")
            myDA.Fill(myDS, "UnitRate")
            myDA.Fill(myDS, "Price")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", DateTimePicker1.Value.Date)
            rpt.SetParameterValue("p2", DateTimePicker2.Value.Date)
            ReportView.CrystalReportViewer1.ReportSource = rpt
            ReportView.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Home.Show()
        Me.Close()
    End Sub

    Private Sub txtname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from medicinesuppliermaster where MedicineSupplier=@name"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "MedicineSupplier"))
            cmd.Parameters("@name").Value = Trim(txtname.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then

                txtmsid.Text = Trim(rdr.GetInt32(0))
                txtname.Text = Trim(rdr.GetString(1))
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtbilltype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtbilltype.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from sizemaster where Size=@name"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "Size"))
            cmd.Parameters("@name").Value = Trim(txtbilltype.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then

                txtbtid.Text = Trim(rdr.GetInt32(0))
                txtbilltype.Text = Trim(rdr.GetString(1))
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class