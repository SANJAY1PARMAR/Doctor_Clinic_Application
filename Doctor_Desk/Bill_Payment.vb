Imports System.Data.SqlClient
Imports System.Data

Public Class Bill_Payment
    Dim str As String
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub Bill_Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnsave.Enabled = False
        btndelet.Enabled = False
        btnupdate.Enabled = False
        Reset()
        auto()
        fillcombo()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        ' Display the date as "Feb 2001".
        DateTimePicker1.CustomFormat = "MMM yyyy"

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        ' Display the date as "Feb 2001".
        DateTimePicker2.CustomFormat = "dd-MM-yyyy"

    End Sub

    Private Sub Bill_Payment_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Me.Hide()
        Home.Show()
    End Sub
    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        auto()
        Reset()
        btnupdate.Enabled = False
        btnsave.Enabled = True
        btndelet.Enabled = False
        fillcombo()
    End Sub
    Sub auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(BillPaymentID) as BillID from billpaymentdtl"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("BillID").ToString() <> "" Then
            txtbpid.Text = Integer.Parse(rdr("BillID").ToString()) + 1
        Else
            txtbpid.Text = 1
        End If
        con.Close()
        rdr.Close()
    End Sub
    Sub Reset()
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        txtamt.Text = ""
        txtpm.Text = ""
        txtpb.Text = ""
        txtbill.Text = ""
        txtpaidbll.Text = ""
        txtsmallbill.Text = ""
        txtbigbill.Text = ""
        txttotalbalance.Text = ""
        txtchque.Enabled = False
        txtbank.Enabled = False
        txtmsid.Text = ""
        txtbpid.Text = ""
        txtmdicinesupplier.Text = ""
        DataGridView1.Rows.Clear()
        auto()
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
            txtmdicinesupplier.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtmdicinesupplier.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Pymentmode()
        If txtpm.Text = "Cash" Then
            txtchque.Enabled = False
            txtbank.Enabled = False
        End If

        If txtpm.Text = "Cheque" Then
            txtchque.Enabled = True
            txtbank.Enabled = True
        End If

        If txtpm.Text = "Online" Then
            txtchque.Enabled = True
            txtbank.Enabled = True
        End If

    End Sub
    Sub GetBillPaymentBalance()

        Dim num1 As Decimal

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT Sum(PayAmount) from billpaymentdtl where billpaymentdtl.MedicineSupplierID=@d1 group By billpaymentdtl.MedicineSupplierID"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtmsid.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num1 = rdr.GetValue(0)
            End If
            con.Close()
            txtbpv.Text = num1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Sub GetMedPurchaseBalance()

        Dim num1 As Decimal
        Dim num2 As Decimal
        Dim num3 As Decimal

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT Sum(Totalcost) from medpurchase where medpurchase.MedicineSupplierID=@d1 group By medpurchase.MedicineSupplierID"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtmsid.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num1 = rdr.GetValue(0)
            End If
            con.Close()
            txtmpv.Text = num1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try


        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT Sum(Totalcost) from medpurchase where medpurchase.MedicineSupplierID=@d1 and Month(PurchaseDt) = Month('" + Convert.ToDateTime(DateTimePicker1.Value) + "') and medpurchase.SizeID=@d2 group By medpurchase.MedicineSupplierID"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtmsid.Text))
            cmd.Parameters.AddWithValue("@d2", "1")
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num2 = rdr.GetValue(0)
            End If
            con.Close()
            txtsmallbill.Text = num2
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT Sum(Totalcost) from medpurchase where medpurchase.MedicineSupplierID=@d1 and Month(PurchaseDt) = Month('" + Convert.ToDateTime(DateTimePicker1.Value) + "') and medpurchase.SizeID=@d2 group By medpurchase.MedicineSupplierID"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtmsid.Text))
            cmd.Parameters.AddWithValue("@d2", "2")
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num3 = rdr.GetValue(0)
            End If
            con.Close()
            txtbigbill.Text = num3

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Sub GetPriviousBalance()
        Dim A As Decimal
        Dim B As Decimal

        A = Val(txtmpv.Text - txtbpv.Text)
        B = (Val(txtbill.Text) + Val(txtsmallbill.Text) + Val(txtbigbill.Text).ToString)
        txtpb.Text = A - B
        txttotalbalance.Text = (Val(txtpb.Text).ToString) + B
    End Sub

    Sub GetCurrMonthBillPayment()

        Dim num1 As Decimal

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT Sum(PayAmount) from billpaymentdtl where billpaymentdtl.MedicineSupplierID=@d1 and Month(PaymentDt) = Month('" + Convert.ToDateTime(DateTimePicker1.Value) + "') group By billpaymentdtl.MedicineSupplierID"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtmsid.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num1 = rdr.GetValue(0)
            End If
            con.Close()
            txtpaidbll.Text = num1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    '   Sub GetMedPurchaseBalanceBig()
    '
    '       Dim num1 As Decimal
    '
    '       Try
    '           con = New SqlConnection(cs)
    '           con.Open()
    '           Dim sql As String = "SELECT Sum(Totalcost) from medpurchase where medpurchase.MedicineSupplierID=@d1 and Month(PurchaseDt) = Month('" + Convert.ToDateTime(DateTimePicker1.Value) + "') and medpurchase.SizeID=@d2 group By medpurchase.MedicineSupplierID"
    '           cmd = New SqlCommand(sql, con)
    '           cmd.Parameters.AddWithValue("@d1", Val(txtmsid.Text))
    '           cmd.Parameters.AddWithValue("@d2", "1")
    '           rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '           If (rdr.Read() = True) Then
    '               num1 = rdr.GetValue(0)
    '           End If
    '           con.Close()
    '           txtsmallbill.Text = num1
    '
    '       Catch ex As Exception
    '           MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '       End Try
    '   End Sub
    '
    ' Sub GetBillPurchaseBalanceSmall()
    '
    '     Dim num1 As Decimal
    '
    '     Try
    '         con = New SqlConnection(cs)
    '         con.Open()
    '         Dim sql As String = "SELECT Sum(Totalcost) from medpurchase where medpurchase.MedicineSupplierID=@d1 and Month(PurchaseDt) = Month('" + Convert.ToDateTime(DateTimePicker1.Value) + "') and medpurchase.SizeID=@d2 group By medpurchase.MedicineSupplierID"
    '         cmd = New SqlCommand(sql, con)
    '         cmd.Parameters.AddWithValue("@d1", Val(txtmsid.Text))
    '         cmd.Parameters.AddWithValue("@d2", "2")
    '         rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '         If (rdr.Read() = True) Then
    '             num1 = rdr.GetValue(0)
    '         End If
    '         con.Close()
    '         txtbigbill.Text = num1
    '
    '     Catch ex As Exception
    '         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '     End Try
    ' End Sub

    'Sub GetCBalance()
    '    txtcurrmonth.Text = (Val(txtbill.Text) + Val(txtsmallbill.Text) + Val(txtbigbill.Text).ToString)
    'End Sub

    Private Sub DSE_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmdicinesupplier.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from medicinesuppliermaster where MedicineSupplier=@name"


            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "MedicineSupplier"))
            cmd.Parameters("@name").Value = Trim(txtmdicinesupplier.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txtmsid.Text = Trim(rdr.GetInt32(0))
                txtmdicinesupplier.Text = Trim(rdr.GetString(1))
            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        Filter()
        GetBillPaymentBalance()
        GetMedPurchaseBalance()
        GetPriviousBalance()
        ' GetMedPurchaseBalanceBig()
        ' GetBillPurchaseBalanceSmall()
        GetCurrMonthBillPayment()
        '  GetCBalance()
    End Sub

    Sub Filter()
        Try
            If txtmdicinesupplier.Text = "" Then
                MessageBox.Show("Please select Medicine Supplier", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtmdicinesupplier.Focus()
                Exit Sub
            End If

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select BillPaymentID, MedicineSupplierID, RTRIM(medicinesuppliermaster.MedicineSupplier), PaymentDt, PaymentMode, BankName, ChequeNumber, PayAmount, BillMounth from billpaymentdtl 
                                    INNER JOIN medicinesuppliermaster ON billpaymentdtl.MedicineSupplierID = medicinesuppliermaster.Id  
                                    where MedicineSupplierID ='" + txtmsid.Text + "' and Month(PaymentDt) = Month('" + Convert.ToDateTime(DateTimePicker1.Value) + "') and Year(PaymentDt) = Year('" + Convert.ToDateTime(DateTimePicker1.Value) + "')", con)

            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If Len(Trim(txtmdicinesupplier.Text)) = 0 Then
            MessageBox.Show("Please enter Select Medicine Supplier Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtmdicinesupplier.Focus()
            Exit Sub
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into billpaymentdtl(BillPaymentID,PaymentDt,PaymentMode,BankName,ChequeNumber,PayAmount,MedicineSupplierID,BillMounth) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "BillPaymentID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 100, "PaymentDt"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "PaymentMode"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "BankName"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 100, "ChequNumber"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "PayAmount"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 100, "MedicineSupplierID"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.VarChar, 100, "BillMounth"))

            cmd.Parameters("@d1").Value = Trim(txtbpid.Text)
            cmd.Parameters("@d2").Value = Trim(DateTimePicker2.Text)
            cmd.Parameters("@d3").Value = Trim(txtpm.Text)
            cmd.Parameters("@d4").Value = Trim(txtbank.Text)
            cmd.Parameters("@d5").Value = Trim(txtchque.Text)
            cmd.Parameters("@d6").Value = Trim(txtamt.Text)
            cmd.Parameters("@d7").Value = Trim(txtmsid.Text)
            cmd.Parameters("@d8").Value = Trim(DateTimePicker1.Text)

            cmd.ExecuteReader()
            MessageBox.Show("Successfully registered", "Consultant", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnsave.Enabled = False
            fillcombo()

            con.Close()

            DataGridView1.Rows.Add(txtbpid.Text, txtmsid.Text, txtmdicinesupplier.Text, DateTimePicker2.Text, txtpm.Text, txtbank.Text, txtchque.Text, txtamt.Text, DateTimePicker1.Text)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        GetBillPaymentBalance()
        GetMedPurchaseBalance()
        GetPriviousBalance()
        GetCurrMonthBillPayment()

        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        txtamt.Text = ""
        txtpm.Text = ""
        txtchque.Text = ""
        txtbank.Text = ""
        txtmsid.Text = ""
        txtbpid.Text = ""
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
        Home.Show()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update billpaymentdtl set PaymentDt=@d2,PaymentMode=@d3,BankName=@d4,ChequeNumber=@d5,PayAMount=@d6,MedicineSupplierID=@d7,BillMounth=@d8 where BillPaymentID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "BillPaymentID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 100, "PaymentDt"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "PaymentMode"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "BankName"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 100, "ChequNumber"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "PayAmount"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 100, "MedicineSupplierID"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.VarChar, 100, "BillMounth"))

            cmd.Parameters("@d1").Value = Trim(txtbpid.Text)
            cmd.Parameters("@d2").Value = Trim(DateTimePicker2.Text)
            cmd.Parameters("@d3").Value = Trim(txtpm.Text)
            cmd.Parameters("@d4").Value = Trim(txtbank.Text)
            cmd.Parameters("@d5").Value = Trim(txtchque.Text)
            cmd.Parameters("@d6").Value = Trim(txtamt.Text)
            cmd.Parameters("@d7").Value = Trim(txtmsid.Text)
            cmd.Parameters("@d8").Value = Trim(DateTimePicker1.Text)

            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            MessageBox.Show("Successfully Updated", "User details", MessageBoxButtons.OK, MessageBoxIcon.Information)

            btnupdate.Enabled = False

            fillcombo()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Get_Bill_Details()
        GetBillPaymentBalance()
        GetMedPurchaseBalance()
        GetPriviousBalance()
        GetCurrMonthBillPayment()

        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        txtamt.Text = ""
        txtpm.Text = ""
        txtchque.Text = ""
        txtbank.Text = ""
        txtbpid.Text = ""

    End Sub

    Private Sub btndelet_Click(sender As Object, e As EventArgs) Handles btndelet.Click
        Try

            If txtbpid.Text = "" Then
                MessageBox.Show("Please select Bill Details ", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtbpid.Text.Count > 0 Then
                If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    delete_records()

                    btndelet.Enabled = False
                    btnupdate.Enabled = False
                    fillcombo()

                    GetBillPaymentBalance()
                    GetMedPurchaseBalance()
                    GetPriviousBalance()
                    GetCurrMonthBillPayment()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub delete_records()
        Try

            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()

            Dim cq As String = "delete from billpaymentdtl where BillPaymentID=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "BillPaymentID"))
            cmd.Parameters("@DELETE1").Value = Trim(txtbpid.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("sorry no record deleted")
                Reset()
                cmd.ExecuteReader()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Get_Bill_Details()

        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        txtamt.Text = ""
        txtpm.Text = ""
        txtchque.Text = ""
        txtbank.Text = ""
        txtbpid.Text = ""

    End Sub


    Private Sub DataGridView1_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = DataGridView1.Rows(dr)
            txtbpid.Text = selectRow.Cells(0).Value
            txtmsid.Text = selectRow.Cells(1).Value
            txtmdicinesupplier.Text = selectRow.Cells(2).Value
            DateTimePicker2.Text = selectRow.Cells(3).Value
            txtpm.Text = selectRow.Cells(4).Value
            txtbank.Text = selectRow.Cells(5).Value
            txtchque.Text = selectRow.Cells(6).Value
            txtamt.Text = selectRow.Cells(7).Value
            DateTimePicker1.Text = selectRow.Cells(8).Value
            btnupdate.Enabled = True
            btndelet.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtpaidbll_TextChanged(sender As Object, e As EventArgs) Handles txtpaidbll.TextChanged

    End Sub

    Private Sub txtcurrmonth_TextChanged(sender As Object, e As EventArgs) Handles txtcurrmonth.TextChanged

    End Sub

    Private Sub txtpm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtpm.SelectedIndexChanged
        Pymentmode()
    End Sub
End Class