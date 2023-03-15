Imports System.Data.SqlClient
Imports System.Data
Public Class Consultant_Master
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub Consultant_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save.Enabled = False
        Delete.Enabled = False
        Update_record.Enabled = False
        Reset()
        auto()
        GetData()
        fillcombo()
        txtname.Enabled = False
        txtspe.Enabled = False
        txtcontac.Enabled = False
        txtaddress.Enabled = False
    End Sub
    Private Sub Consultant_Master_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Me.Hide()
        Home.Show()
    End Sub

    Sub auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(CunsultantID) as CatID from cunsultantmaster"
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
        txtname.Enabled = True
        txtspe.Enabled = True
        txtcontac.Enabled = True
        txtaddress.Enabled = True
        txtname.Text = ""
        txtspe.Text = ""
        txtcontac.Text = ""
        txtaddress.Text = ""
        txtdatetime.Text = DateAndTime.Now.ToString
        auto()
    End Sub

    Sub fillcombo()

        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(DrName) FROM cunsultantmaster", CN)
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

    Private Sub NewRecord_Click(sender As Object, e As EventArgs) Handles NewRecord.Click
        auto()
        Reset()
        Update_record.Enabled = False
        Save.Enabled = True
        Delete.Enabled = False
        fillcombo()
    End Sub

    Private Sub DSE_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.SelectedIndexChanged
        Try
            Delete.Enabled = True
            Save.Enabled = True
            Update_record.Enabled = True

            con = New SqlConnection(cs)

            con.Open()


            Dim ct As String = "select * from cunsultantmaster where DrName=@name"


            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "DrName"))
            cmd.Parameters("@name").Value = Trim(txtname.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then

                txtid.Text = Trim(rdr.GetInt32(0))
                txtname.Text = Trim(rdr.GetString(1))
                txtspe.Text = Trim(rdr.GetString(2))
                txtcontac.Text = Trim(rdr.GetString(3))
                txtaddress.Text = Trim(rdr.GetString(4))
                txtdatetime.Text = Trim(rdr.GetDateTime(5))
            End If


            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If Len(Trim(txtname.Text)) = 0 Then
            MessageBox.Show("Please enter Doctor Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
            Exit Sub
        End If
        If Len(Trim(txtcontac.Text)) = 0 Then
            MessageBox.Show("Please enter Contact Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcontac.Focus()
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
            Dim ct As String = "select DrName from cunsultantmaster where DrName=@find"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "DrName"))
            cmd.Parameters("@find").Value = txtname.Text
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Doctor Name Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtname.Text = ""
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            Else

                con = New SqlConnection(cs)
                con.Open()

                Dim cb As String = "insert into cunsultantmaster(CunsultantId,DrName,Specialist,ContactNo,Address,ModifiedDateTime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"

                cmd = New SqlCommand(cb)

                cmd.Connection = con

                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "CunsultantId"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "DrName"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "Specialist"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "ContactNo"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 100, "Address"))
                cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "DateTime"))

                cmd.Parameters("@d1").Value = Trim(txtid.Text)
                cmd.Parameters("@d2").Value = Trim(txtname.Text)
                cmd.Parameters("@d3").Value = Trim(txtspe.Text)
                cmd.Parameters("@d4").Value = Trim(txtcontac.Text)
                cmd.Parameters("@d5").Value = Trim(txtaddress.Text)
                cmd.Parameters("@d6").Value = Trim(txtdatetime.Text)

                cmd.ExecuteReader()

                MessageBox.Show("Successfully registered", "Consultant", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Save.Enabled = False
                Reset()
                fillcombo()
                con.Close()
                GetData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try

            If txtname.Text = "" Then
                MessageBox.Show("Please select Consultant ", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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


            Dim cq As String = "delete from cunsultantmaster where DrName=@DELETE1;"


            cmd = New SqlCommand(cq)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "DrName"))


            cmd.Parameters("@DELETE1").Value = Trim(txtname.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then

                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MsgBox("sorry no record deleted")
                txtid.Text = ""
                txtname.Text = ""
                txtspe.Text = ""
                txtcontac.Text = ""
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
            txtspe.Text = ""
            txtcontac.Text = ""
            txtaddress.Text = ""
            txtdatetime.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Update_record_Click(sender As Object, e As EventArgs) Handles Update_record.Click
        Try

            If txtname.Text = "" Then
                MessageBox.Show("Please select Consultant Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update cunsultantmaster set CunsultantID=@d1,DrName=@d2,Specialist=@d3,ContactNo=@d4,Address=@d5,ModifiedDateTime=@d6 where CunsultantID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "CunsultantId"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "DrName"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "Specialist"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "ContactNo"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 100, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "ModifiedDateTime"))

            cmd.Parameters("@d1").Value = Trim(txtid.Text)
            cmd.Parameters("@d2").Value = Trim(txtname.Text)
            cmd.Parameters("@d3").Value = Trim(txtspe.Text)
            cmd.Parameters("@d4").Value = Trim(txtcontac.Text)
            cmd.Parameters("@d5").Value = Trim(txtaddress.Text)
            cmd.Parameters("@d6").Value = Trim(txtdatetime.Text)


            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If


            MessageBox.Show("Successfully Updated", "User details", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Update_record.Enabled = False
            Reset()
            fillcombo()
            con.Close()
            GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) 


    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(CunsultantID), RTRIM(DrName), RTRIM(Specialist), RTRIM(ContactNo), RTRIM(Address), RTRIM(ModifiedDateTime) from cunsultantmaster", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = DataGridView1.Rows(dr)

            txtid.Text = selectRow.Cells(0).Value
            txtname.Text = selectRow.Cells(1).Value
            txtspe.Text = selectRow.Cells(2).Value
            txtcontac.Text = selectRow.Cells(3).Value
            txtaddress.Text = selectRow.Cells(4).Value
            txtdatetime.Text = selectRow.Cells(5).Value

            Update_record.Enabled = True
            Delete.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Hide()
        Home.Show()
    End Sub
End Class