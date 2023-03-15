Imports System.Data.SqlClient
Imports System.Data

Public Class Medicine_Purchase_Details

    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub Medicine_Purchase_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        ' Display the date as "Feb 2001".
        DateTimePicker1.CustomFormat = "MMM yyyy"

        btnsave.Enabled = False
        btnadd.Enabled = False
        btnremove.Enabled = False
        btnupdate.Enabled = False

        RadioButton1.Checked = True
        Enable()
        Reset()
        reset1()
        auto()
        auto1()
        fillcombo()
    End Sub

    Private Sub Medicine_Purchase_Details_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Me.Hide()
        Home.Show()
    End Sub

    Sub Enable()
        txttotalcost.Enabled = False
        txtqty.Enabled = False
        txtprice.Enabled = False
        txttype.Enabled = False
        txtbilltype.Enabled = False
        txtbillno.Enabled = False
        txtmedicine.Enabled = False
        txtmid.Enabled = False
        txtsizeid.Enabled = False
        txtmsid.Enabled = False
        DateTimePicker2.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
    End Sub

    Sub Enable1()
        txttotalcost.Enabled = True
        txtqty.Enabled = True
        txtprice.Enabled = True
        txttype.Enabled = True
        txtbilltype.Enabled = True
        txtbillno.Enabled = True
        txtmedicine.Enabled = True
        txtmid.Enabled = True
        txtsizeid.Enabled = True
        txtmsid.Enabled = True
        DateTimePicker2.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
    End Sub

    Sub auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(MedPurchaseDtlID) as BillID from medpurchasedtl"

        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("BillID").ToString() <> "" Then
            txtmpdtlid.Text = Integer.Parse(rdr("BillID").ToString()) + 1
        Else
            txtmpdtlid.Text = 1

        End If
        con.Close()
        rdr.Close()

    End Sub
    Sub auto1()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(MedPurchaseID) as BillID from medpurchase"

        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("BillID").ToString() <> "" Then
            txtmpid.Text = Integer.Parse(rdr("BillID").ToString()) + 1
        Else
            txtmpid.Text = 1

        End If
        con.Close()
        rdr.Close()

    End Sub

    Sub Reset()
        txtmedicinesupplier.Text = ""
        DateTimePicker1.Text = Today
        txttotalcost.Text = ""
        txtqty.Text = ""
        txtprice.Text = ""
        txttype.Text = "Allopathic"
        txtbilltype.Text = ""
        txtbillno.Text = ""
        txtmedicine.Text = ""
        txtmid.Text = ""
        txtsizeid.Text = ""
        txtmsid.Text = ""
        DateTimePicker2.Text = Today
        RadioButton1.Checked = True
        auto()
        auto1()

    End Sub
    Sub reset1()
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
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
            txtmedicinesupplier.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtmedicinesupplier.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'Try
        '    Dim CN As New SqlConnection(cs)
        '    CN.Open()
        '    adp = New SqlDataAdapter()
        '    adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(MedicineName) FROM medicinemaster", CN)
        '    ds = New DataSet("ds")
        '    adp.Fill(ds)
        '    dtable = ds.Tables(0)
        '    txtmedicine.Items.Clear()
        '    For Each drow As DataRow In dtable.Rows
        '        txtmedicine.Items.Add(drow(0).ToString())
        '        'DocName.SelectedIndex = -1
        '    Next
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Try
            Dim conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30")
            Dim cmd As New SqlCommand("Select MedicineName from medicinemaster", conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataSet
            da.Fill(dt)
            Dim column1 As New AutoCompleteStringCollection
            For i As Integer = 0 To dt.Tables(0).Rows.Count - 1
                column1.Add(dt.Tables(0).Rows(i)("MedicineName").ToString())
            Next
            txtmedicine.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtmedicine.AutoCompleteCustomSource = column1
            txtmedicine.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(TreatmentType) FROM treatmrnttypemaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txttype.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txttype.Items.Add(drow(0).ToString())
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

    Private Sub DSE_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmedicine.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from medicinemaster where MedicineName=@name"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "MedicineName"))
            cmd.Parameters("@name").Value = Trim(txtmedicine.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txtmid.Text = Trim(rdr.GetInt32(0))
                txtmedicine.Text = Trim(rdr.GetString(1))
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MED_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmedicinesupplier.SelectedIndexChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from medicinesuppliermaster where MedicineSupplier=@name"


            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "MedicineSupplier"))
            cmd.Parameters("@name").Value = Trim(txtmedicinesupplier.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txtmsid.Text = Trim(rdr.GetInt32(0))
                txtmedicinesupplier.Text = Trim(rdr.GetString(1))
            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SIZ_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbilltype.SelectedIndexChanged
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
                txtsizeid.Text = Trim(rdr.GetInt32(0))
                txtbilltype.Text = Trim(rdr.GetString(1))
            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
        Home.Show()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub txtmsid_TextChanged(sender As Object, e As EventArgs) Handles txtmsid.TextChanged

    End Sub

    Private Sub txtprice_TextChanged(sender As Object, e As EventArgs) Handles txtprice.TextChanged

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        If Len(Trim(txtmedicinesupplier.Text)) = 0 Then
            MessageBox.Show("Please enter Medicine Supplier Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txttype.Focus()
            Exit Sub
        End If
        If Len(Trim(txtmedicine.Text)) = 0 Then
            MessageBox.Show("Please enter Medicine Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtmedicine.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into medpurchasedtl(MedPurchaseDtlID,MedPurchaseID,MedicineID,Quntity,Price) VALUES (@d1,@d2,@d3,@d4,@d5)"

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "MedPurchaseDtlID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedPurchaseID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "Quntity"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "Price"))

            cmd.Parameters("@d1").Value = Trim(txtmpdtlid.Text)
            cmd.Parameters("@d2").Value = Trim(txtmpid.Text)
            cmd.Parameters("@d3").Value = Trim(txtmid.Text)
            cmd.Parameters("@d4").Value = Trim(txtqty.Text)
            cmd.Parameters("@d5").Value = Trim(txtprice.Text)
            cmd.ExecuteReader()

            fillcombo()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        DataGridView1.Rows.Add(txtmpdtlid.Text, txtmpid.Text, txtmid.Text, txtmedicine.Text, txtqty.Text, txtprice.Text)

        Dim j As Double = 0
        j = TotalCost()
        j = Math.Round(j, 2)
        txttotalcost.Text = j

        txtqty.Text = ""
        txtprice.Text = ""
        txttype.Text = ""
        txtmedicine.Text = ""
        txtmid.Text = ""
        auto()

    End Sub

    Private Sub btnremove_Click(sender As Object, e As EventArgs) Handles btnremove.Click
        Try

            If txtmpdtlid.Text = "" Then
                MessageBox.Show("Please select Medicine Supplier", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtmpdtlid.Text.Count > 0 Then
                If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    Remove_records()
                End If
            End If

            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim j As Double = 0
        j = TotalCost()
        j = Math.Round(j, 2)
        txttotalcost.Text = j
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into medpurchase(MedPurchaseID,MedicineSupplierID,SizeID,BillNo,PurchaseDt,Totalcost) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"

            cmd = New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "MedPurchaseID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineSupplierID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "SizeID"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "BillNo"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.DateTime, 100, "PurchaseDt"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "Totalcost"))

            cmd.Parameters("@d1").Value = Trim(txtmpid.Text)
            cmd.Parameters("@d2").Value = Trim(txtmsid.Text)
            cmd.Parameters("@d3").Value = Trim(txtsizeid.Text)
            cmd.Parameters("@d4").Value = Trim(txtbillno.Text)
            cmd.Parameters("@d5").Value = Trim(DateTimePicker2.Text)
            cmd.Parameters("@d6").Value = Trim(txttotalcost.Text)

            cmd.ExecuteReader()

            MessageBox.Show("Successfully registered", "Consultant", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.Rows.Clear()
            btnsave.Enabled = False

            fillcombo()
            con.Close()
            DataGridView2.Rows.Add(txtmpid.Text, txtmsid.Text, txtsizeid.Text, txtmedicinesupplier.Text, txtbillno.Text, txtbilltype.Text, txttotalcost.Text, DateTimePicker2.Text)

            Reset()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function TotalCost() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(5).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        btnsave.Enabled = True
        btnadd.Enabled = True
        Enable1()
        Reset()
        reset1()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Generic_Medicine_List.Show()
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        DataGridView2.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Remove_records()
        Try

            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()


            Dim cq As String = "delete from medpurchasedtl where MedPurchaseDtlID=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "MedPurchaseDtlID"))


            cmd.Parameters("@DELETE1").Value = Trim(txtmpdtlid.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then

                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MsgBox("sorry no record deleted")
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

        txtqty.Text = ""
        txtprice.Text = ""
        txttype.Text = ""
        txtmedicine.Text = ""
        txtmid.Text = ""
    End Sub

    Private Sub DataGridView1_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = DataGridView1.Rows(dr)
            txtmpdtlid.Text = selectRow.Cells(0).Value
            txtmpid.Text = selectRow.Cells(1).Value
            txtmid.Text = selectRow.Cells(2).Value
            txtmedicine.Text = selectRow.Cells(3).Value
            txtqty.Text = selectRow.Cells(4).Value
            txtprice.Text = selectRow.Cells(5).Value


            btnupdate.Enabled = True
            btnremove.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            If txtmpdtlid.Text = "" Then
                MessageBox.Show("Please select Select Madicine Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update medpurchasedtl set MedPurchaseDtlID=@d1,MedPurchaseID=@d2,MedicineID=@d3,Quntity=@d4,Price=@d5 where MedPurchaseDtlID=@d1"

            cmd = New SqlCommand(cb)
            cmd = New SqlCommand(cb)

            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "MedPurchaseDtlID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedPurchaseID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "Quntity"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "Price"))

            cmd.Parameters("@d1").Value = Trim(txtmpdtlid.Text)
            cmd.Parameters("@d2").Value = Trim(txtmpid.Text)
            cmd.Parameters("@d3").Value = Trim(txtmid.Text)
            cmd.Parameters("@d4").Value = Trim(txtqty.Text)
            cmd.Parameters("@d5").Value = Trim(txtprice.Text)
            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            MessageBox.Show("Successfully Updated", "User details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            fillcombo()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GetMedicineDetails()
        'DataGridView1.Rows.Add(txtmpdtlid.Text, txtmpid.Text, txtmid.Text, txtmedicine.Text, txtqty.Text, txtprice.Text)

        Dim j As Double = 0
        j = TotalCost()
        j = Math.Round(j, 2)
        txttotalcost.Text = j
        auto()
    End Sub

    Public Sub Filtre()
        Try
            If txtmedicinesupplier.Text = "" Then
                MessageBox.Show("Please select Medicine Supplier", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtmedicinesupplier.Focus()
                Exit Sub
            End If

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select MedPurchaseID, MedicineSupplierID, Medpurchase.SizeID, RTRIM(medicinesuppliermaster.MedicineSupplier), BillNo, RTRIM(sizemaster.Size), Totalcost, PurchaseDt from medpurchase 
                                    INNER JOIN medicinesuppliermaster ON medpurchase.MedicineSupplierID = medicinesuppliermaster.Id INNER JOIN sizemaster ON medpurchase.SIzeId = sizemaster.SizeID 
                                    where MedicineSupplierID ='" + txtmsid.Text + "' and Month(PurchaseDt) = Month('" + DateTimePicker1.Text + "') and Year(PurchaseDt) = Year('" + Convert.ToDateTime(DateTimePicker1.Text) + "')", con)

            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = DataGridView2.Rows(dr)
            txtmpid.Text = selectRow.Cells(0).Value
            txtmsid.Text = selectRow.Cells(1).Value
            txtsizeid.Text = selectRow.Cells(2).Value
            txtmedicinesupplier.Text = selectRow.Cells(3).Value
            txtbillno.Text = selectRow.Cells(4).Value
            txtbilltype.Text = selectRow.Cells(5).Value
            txttotalcost.Text = selectRow.Cells(6).Value
            DateTimePicker2.Text = selectRow.Cells(7).Value

            GetMedicineDetails()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView2.DoubleClick
        '  Try
        '      Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
        '      ' or simply use column name instead of index
        '      'dr.Cells["id"].Value.ToString();
        '      txtmpid.Text = dr.Cells(0).Value.ToString()
        '      txtmsid.Text = dr.Cells(1).Value.ToString()
        '      txtsizeid.Text = dr.Cells(2).Value.ToString()
        '      txtmedicinesupplier.Text = dr.Cells(3).Value.ToString()
        '      txtbillno.Text = dr.Cells(4).Value.ToString()
        '      txtbilltype.Text = dr.Cells(5).Value.ToString()
        '      txttotalcost.Text = dr.Cells(6).Value.ToString()
        '      DateTimePicker2.Text = dr.Cells(7).Value.ToString()
        '
        '      txtedit.Enabled = True
        '      txtdelet.Enabled = True
        '      btnadd.Enabled = True
        '      btnremove.Enabled = True
        '      btnupdate.Enabled = True
        '  Catch ex As Exception
        '      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '  End Try
        '  For Each row As DataGridViewRow In DataGridView2.SelectedRows
        '      DataGridView2.Rows.Remove(row)
        '  Next

    End Sub
    Public Sub GetMedicineDetails()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select MedPurchaseDtlID, MedPurchaseID, medpurchasedtl.MedicineID, RTRIM(medicinemaster.MedicineName), Quntity, Price  from medpurchasedtl 
                                    INNER JOIN medicinemaster ON medpurchasedtl.MedicineID = medicinemaster.MedicineID  
                                    where MedPurchaseID ='" + txtmpid.Text + "'", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        TotalCost()
    End Sub

    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        Filtre()
    End Sub

    Private Sub txtedit_Click(sender As Object, e As EventArgs) Handles txtedit.Click
        Try

            If txtmedicinesupplier.Text = "" Then
                MessageBox.Show("Please select Select Madicine SUpplier Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtmedicinesupplier.Text = Focus()
                Exit Sub
            End If

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update medpurchase 
                                set MedPurchaseID=@d1,MedicineSupplierID=@d2,SizeID=@d3,BillNo=@d4,PurchaseDt=@d5,Totalcost=@d6 
                                where MedPurchaseID=@d1"
            cmd = New SqlCommand(cb)
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "MedPurchaseID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineSupplierID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "SizeID"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "BillNo"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.DateTime, 100, "PurchaseDt"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "Totalcost"))

            cmd.Parameters("@d1").Value = Trim(txtmpid.Text)
            cmd.Parameters("@d2").Value = Trim(txtmsid.Text)
            cmd.Parameters("@d3").Value = Trim(txtsizeid.Text)
            cmd.Parameters("@d4").Value = Trim(txtbillno.Text)
            cmd.Parameters("@d5").Value = Trim(DateTimePicker2.Text)
            cmd.Parameters("@d6").Value = Trim(txttotalcost.Text)
            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            MessageBox.Show("Successfully Updated", "Medicine Bill Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            fillcombo()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' DataGridView2.Rows.Add(txtmpid.Text, txtmsid.Text, txtsizeid.Text, txtmedicinesupplier.Text, txtbillno.Text, txtbilltype.Text, txttotalcost.Text, DateTimePicker2.Text)
        Filtre()

    End Sub

    Private Sub Delet_records()
        Try

            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from medpurchase where MedPurchaseID=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "MedPurchaseID"))
            cmd.Parameters("@DELETE1").Value = Trim(txtmpid.Text)
            RowsAffected = cmd.ExecuteNonQuery()

            Dim cc As String = "delete from medpurchasedtl where MedPurchaseID=@DELETE1;"
            cmd = New SqlCommand(cc)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "MedPurchaseID"))
            cmd.Parameters("@DELETE1").Value = Trim(txtmpid.Text)
            RowsAffected = cmd.ExecuteNonQuery()

            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                MsgBox("sorry no record deleted")
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
        Reset()
        reset1()
    End Sub
    Private Sub txtdelet_Click(sender As Object, e As EventArgs) Handles txtdelet.Click
        Try

            If txtmpid.Text = "" Then
                MessageBox.Show("Please select Medicine Supplier", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtmedicinesupplier.Focus()
                Exit Sub
            End If
            If txtmpid.Text.Count > 0 Then
                If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    delet_records()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class