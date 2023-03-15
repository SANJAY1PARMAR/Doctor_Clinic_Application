Imports System.Data.SqlClient
Imports System.Data
Public Class Branded_Medicine

    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub Branded_Medicine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnsave.Enabled = False
        Delete.Enabled = False
        Update_record.Enabled = False

        txttt.Enabled = False
        txtmtid.Text = "2"
        txtname.Enabled = False
        txtdrug.Enabled = False
        txtcompany.Enabled = False
        GetData()
        fillDrug()
        fillTretmentType()
        Reset()
        auto()
    End Sub

    Sub auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(MedicineID) as CatID from medicinemaster"
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
        txttt.Text = ""
        txtname.Text = ""
        txtdrug.Text = ""
        txtcompany.Text = ""
        txtdatetime.Text = DateAndTime.Now.ToString
        auto()
    End Sub
    Private Sub Branded_Medicine_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Me.Hide()
        Home.Show()
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select MedicineID, MedicineName, BrandedDrugTypeID, CompunyName, ModifiedDateTime, MedicineTypeID, TreatmentTypeID from medicinemaster where MedicineTypeID ='" + txtmtid.Text + "'", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgw_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgw.CellFormatting
        dgw.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw.CellClick
        Try
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = dgw.Rows(dr)

            txtid.Text = selectRow.Cells(0).Value
            txtname.Text = selectRow.Cells(1).Value
            txtbdtid.Text = selectRow.Cells(2).Value
            txtcompany.Text = selectRow.Cells(3).Value
            txtdatetime.Text = selectRow.Cells(4).Value
            txtmtid.Text = selectRow.Cells(5).Value
            txtttid.Text = selectRow.Cells(6).Value

            Update_record.Enabled = True
            Delete.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub fillTretmentType()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(TreatmentType) FROM treatmrnttypemaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txttt.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txttt.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub fillDrug()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(BrandedDrugType) FROM brandeddrugtypemaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtdrug.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtdrug.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub NewRecord_Click(sender As Object, e As EventArgs) Handles NewRecord.Click
        auto()
        Reset()

        fillDrug()
        fillTretmentType()

        txttt.Enabled = True
        txtmtid.Text = "2"
        txtname.Enabled = True
        txtdrug.Enabled = True
        txtcompany.Enabled = True

        Update_record.Enabled = False
        btnsave.Enabled = True
        Delete.Enabled = False
    End Sub

    Private Sub DSE_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttt.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from treatmrnttypemaster where TreatmentType=@name"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "TreatmentType"))
            cmd.Parameters("@name").Value = Trim(txttt.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txtttid.Text = Trim(rdr.GetInt32(0))
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try

            If txtname.Text = "" Then
                MessageBox.Show("Please select Medicine Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtname.Text.Count > 0 Then
                If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    delete_records()
                    Delete.Enabled = False
                    Update_record.Enabled = False
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
            Dim cq As String = "delete from medicinemaster where MedicineName=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "MedicineName"))
            cmd.Parameters("@DELETE1").Value = Trim(txtname.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("sorry no record deleted")
                txtid.Text = ""
                txtname.Text = ""
                txtcompany.Text = ""
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
            txtcompany.Text = ""
            txtdatetime.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetDetails_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtdrug_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtdrug.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from brandeddrugtypemaster where BrandedDrugType=@name"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "BrandedDrugType"))
            cmd.Parameters("@name").Value = Trim(txtdrug.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txtbdtid.Text = Trim(rdr.GetInt32(0))
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If Len(Trim(txtname.Text)) = 0 Then
            MessageBox.Show("Please enter Medicine Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select MedicineName from medicinemaster where MedicineName=@find"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "MedicineName"))
            cmd.Parameters("@find").Value = txtname.Text
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Medicine Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtname.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else

                con = New SqlConnection(cs)
                con.Open()

                Dim cb As String = "insert into medicinemaster(MedicineID,MedicineName,BrandedDrugTypeID,CompunyName,ModifiedDateTime,MedicineTypeID,TreatmentTypeID) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineName"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "BrandedDrugTypeID"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "CompunyName"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "ModifiedDateTime"))
                cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "MedicineTypeID"))
                cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "TreatmentTypeID"))

                cmd.Parameters("@d1").Value = Trim(txtid.Text)
                cmd.Parameters("@d2").Value = Trim(txtname.Text)
                cmd.Parameters("@d3").Value = Trim(txtbdtid.Text)
                cmd.Parameters("@d4").Value = Trim(txtcompany.Text)
                cmd.Parameters("@d5").Value = Trim(txtdatetime.Text)
                cmd.Parameters("@d6").Value = Trim(txtmtid.Text)
                cmd.Parameters("@d7").Value = Trim(txtttid.Text)
                cmd.ExecuteReader()

                MessageBox.Show("Successfully Save", "Medicine Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnsave.Enabled = False
                Reset()
                GetData()
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Update_record_Click(sender As Object, e As EventArgs) Handles Update_record.Click
        Try

            If txtname.Text = "" Then
                MessageBox.Show("Please select Medicine Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtname.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update medicinemaster set MedicineID=@d1,MedicineName=@d2,BrandedDrugTypeID=@d3,CompunyName=@d4,ModifiedDateTime=@d5,MedicineTypeID=@d6,TreatmentTypeID=@d7 where MedicineID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineName"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "BrandedDrugTypeID"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "CompunyName"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "ModifiedDateTime"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "MedicineTypeID"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "TreatmentTypeID"))

            cmd.Parameters("@d1").Value = Trim(txtid.Text)
            cmd.Parameters("@d2").Value = Trim(txtname.Text)
            cmd.Parameters("@d3").Value = Trim(txtbdtid.Text)
            cmd.Parameters("@d4").Value = Trim(txtcompany.Text)
            cmd.Parameters("@d5").Value = Trim(txtdatetime.Text)
            cmd.Parameters("@d6").Value = Trim(txtmtid.Text)
            cmd.Parameters("@d7").Value = Trim(txtttid.Text)
            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            MessageBox.Show("Successfully Updated", "Medicine Details", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Update_record.Enabled = False
            Reset()
            GetData()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Hide()
        Home.Show()
    End Sub
End Class