Imports System.Data.SqlClient
Imports System.Data


Public Class Medicine_Supplier

    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub Medicine_Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Update_record.Enabled = False
        Delete.Enabled = False
        Save.Enabled = False
        GetData()
        Reset()
        auto()
    End Sub
    Sub auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(Id) as CatID from medicinesuppliermaster"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("CatID").ToString() <> "" Then
            txtid.Text = Integer.Parse(rdr("CatID").ToString()) + 1
        Else
            txtid.Text = 1
        End If
        con.Close()
        rdr.Close()
    End Sub
    Sub Reset()
        txtname.Text = ""
        txtcontact.Text = ""
        txtaddress.Text = ""
        txtdatetime.Text = DateAndTime.Now.ToString()
        auto()
    End Sub
    Private Sub NewRecord_Click(sender As Object, e As EventArgs) Handles NewRecord.Click
        auto()
        Reset()
        Save.Enabled = True
        Update_record.Enabled = False
        Delete.Enabled = False
    End Sub
    Private Sub frmMedicine_Supplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcombo()
        Update_record.Enabled = False
        Delete.Enabled = False
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
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Id), RTRIM(MedicineSupplier), RTRIM(ContactNo), RTRIM(Address), RTRIM(DateTime) from medicinesuppliermaster", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = DataGridView1.Rows(dr)

            txtid.Text = selectRow.Cells(0).Value
            txtname.Text = selectRow.Cells(1).Value
            txtcontact.Text = selectRow.Cells(2).Value
            txtaddress.Text = selectRow.Cells(3).Value
            txtdatetime.Text = selectRow.Cells(4).Value

            Update_record.Enabled = True
            Delete.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DSE_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.SelectedIndexChanged
        Try
            Delete.Enabled = True
            Update_record.Enabled = True

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from medicinesuppliermaster where MedicineSupplier=@name"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "MedicineSupplier"))
            cmd.Parameters("@name").Value = Trim(txtname.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then

                txtid.Text = Trim(rdr.GetInt32(0))
                txtcontact.Text = Trim(rdr.GetString(2))
                txtaddress.Text = Trim(rdr.GetString(3))
                txtdatetime.Text = Trim(rdr.GetDateTime(4))

            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Medicine_Supplier_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Me.Hide()
        Home.Show()
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If Len(Trim(txtname.Text)) = 0 Then
            MessageBox.Show("Please enter Supplier Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
            Exit Sub
        End If
        If Len(Trim(txtcontact.Text)) = 0 Then
            MessageBox.Show("Please enter Contact Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcontact.Focus()
            Exit Sub
        End If
        If Len(Trim(txtaddress.Text)) = 0 Then
            MessageBox.Show("Please enter Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtaddress.Focus()
            Exit Sub
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select MedicineSupplier from medicinesuppliermaster where MedicineSupplier=@find"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "MedicineSupplier"))
            cmd.Parameters("@find").Value = txtname.Text
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Medicine Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtname.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else

                con = New SqlConnection(cs)
                con.Open()

                Dim cb As String = "insert into medicinesuppliermaster(Id,MedicineSupplier,ContactNo,Address,DateTime) VALUES (@d1,@d2,@d3,@d4,@d5)"

                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "Id"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineSupplier"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "ContactNo"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 100, "Address"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "DateTime"))

                cmd.Parameters("@d1").Value = Trim(txtid.Text)
                cmd.Parameters("@d2").Value = Trim(txtname.Text)
                cmd.Parameters("@d3").Value = Trim(txtcontact.Text)
                cmd.Parameters("@d4").Value = Trim(txtaddress.Text)
                cmd.Parameters("@d5").Value = Trim(txtdatetime.Text)
                cmd.ExecuteReader()

                MessageBox.Show("Successfully registered", "Medicine Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Save.Enabled = False
                GetData()
                Reset()
                fillcombo()
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try

            If txtname.Text = "" Then
                MessageBox.Show("Please select Medicine Supplier", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtname.Items.Count > 0 Then
                If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    delete_records()

                    Delete.Enabled = False
                    Update_record.Enabled = False
                    fillcombo()
                    GetData()
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


            Dim cq As String = "delete from medicinesuppliermaster where MedicineSupplier=@DELETE1;"


            cmd = New SqlCommand(cq)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "MedicineSupplier"))


            cmd.Parameters("@DELETE1").Value = Trim(txtname.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then

                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MsgBox("sorry no record deleted")
                txtid.Text = ""
                txtname.Text = ""
                txtcontact.Text = ""
                txtaddress.Text = ""
                txtdatetime.Text = ""

                cmd.ExecuteReader()
                If con.State = ConnectionState.Open Then

                    con.Close()
                End If

                con.Close()
            End If

            con.Close()
            txtid.Text = ""
            txtname.Text = ""
            txtcontact.Text = ""
            txtaddress.Text = ""
            txtdatetime.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Update_record_Click(sender As Object, e As EventArgs) Handles Update_record.Click
        Try
            If txtname.Text = "" Then
                MessageBox.Show("Please select Medicine Supplier Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update medicinesuppliermaster set Id=@d1,MedicineSupplier=@d2,ContactNo=@d3,Address=@d4,DateTime=@d5 where Id=@d1"

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "Id"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineSupplier"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "ContactNo"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 100, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "DateTime"))

            cmd.Parameters("@d1").Value = Trim(txtid.Text)
            cmd.Parameters("@d2").Value = Trim(txtname.Text)
            cmd.Parameters("@d3").Value = Trim(txtcontact.Text)
            cmd.Parameters("@d4").Value = Trim(txtaddress.Text)
            cmd.Parameters("@d5").Value = Trim(txtdatetime.Text)
            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            MessageBox.Show("Successfully Updated", "User details", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Update_record.Enabled = False
            GetData()
            Reset()
            fillcombo()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Home.Show()
    End Sub


End Class