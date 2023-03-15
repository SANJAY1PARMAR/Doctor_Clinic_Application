Imports System.Data.SqlClient
Imports System.Data

Public Class User_Master
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub User_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save.Enabled = False
        Delete.Enabled = False
        Update_record.Enabled = False
        Reset()
        auto()
        GetData()
        fillcombo()
        txtname.Enabled = False
        txtid.Enabled = False
        txtmo.Enabled = False
        txtdesig.Enabled = False
        txtquali.Enabled = False
        txtreg.Enabled = False
        txtaddress.Enabled = False
        txtdatetime.Enabled = False
        txtdatetime.Text = DateAndTime.Now.ToString

    End Sub
    Private Sub User_Master_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Me.Hide()
        Home.Show()
    End Sub

    Sub auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(UserID) as CatID from usermaster"
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

    Sub fillcombo()

        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(Designation) FROM designationmaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtdesig.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtdesig.Items.Add(drow(0).ToString())
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
            cmd = New SqlCommand("SELECT RTRIM(UserID), RTRIM(UserName), RTRIM(Qualification), RTRIM(designationmaster.Designation), RTRIM(RegNo), RTRIM(Address), RTRIM(Mobile), RTRIM(usermaster.DesignationID), RTRIM(ModifiedDateTime) from usermaster INNER JOIN designationmaster ON usermaster.DesignationID = designationmaster.DesignationID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Reset()
        auto()
        txtname.Text = ""

        txtmo.Text = ""
        txtdesig.Text = ""
        txtquali.Text = ""
        txtreg.Text = ""
        txtaddress.Text = ""
        txtdatetime.Text = DateAndTime.Now.ToString
    End Sub

    Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw.CellClick
        Try
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = dgw.Rows(dr)

            txtid.Text = selectRow.Cells(0).Value
            txtname.Text = selectRow.Cells(1).Value
            txtdesig.Text = selectRow.Cells(2).Value
            txtquali.Text = selectRow.Cells(3).Value
            txtreg.Text = selectRow.Cells(4).Value
            txtaddress.Text = selectRow.Cells(5).Value
            txtmo.Text = selectRow.Cells(6).Value
            txtdid.Text = selectRow.Cells(7).Value
            ' txtdatetime.Text = selectRow.Cells(6).Value

            Update_record.Enabled = True
            Delete.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NewRecord_Click(sender As Object, e As EventArgs) Handles NewRecord.Click
        Save.Enabled = True
        Delete.Enabled = True
        Update_record.Enabled = True
        txtname.Enabled = True
        txtid.Enabled = True
        txtmo.Enabled = True
        txtdesig.Enabled = True
        txtquali.Enabled = True
        txtreg.Enabled = True
        txtaddress.Enabled = True
        txtdatetime.Enabled = True
        Reset()
    End Sub

    Private Sub GetDetails_Click(sender As Object, e As EventArgs) Handles GetDetails.Click
        Me.Hide()
        Home.Show()
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If Len(Trim(txtname.Text)) = 0 Then
            MessageBox.Show("Please enter Doctor Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
            Exit Sub
        End If
        If Len(Trim(txtdesig.Text)) = 0 Then
            MessageBox.Show("Please enter Designation", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtdesig.Focus()
            Exit Sub
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select UserName from usermaster where UserName=@find"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "UserName"))
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

                Dim cb As String = "insert into usermaster(UserID, UserName, Qualification, RegNo, Address, Mobile, DesignationID, ModifiedDateTime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"

                cmd = New SqlCommand(cb)

                cmd.Connection = con

                cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "UserID"))
                cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "UserName"))
                cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "Qualification"))
                cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "RegNo"))
                cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 100, "Address"))
                cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "Mobile"))
                cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 100, "DesignationID"))
                cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.VarChar, 50, "ModifiedDateTime"))

                cmd.Parameters("@d1").Value = Trim(txtid.Text)
                cmd.Parameters("@d2").Value = Trim(txtname.Text)
                cmd.Parameters("@d3").Value = Trim(txtquali.Text)
                cmd.Parameters("@d4").Value = Trim(txtreg.Text)
                cmd.Parameters("@d5").Value = Trim(txtaddress.Text)
                cmd.Parameters("@d6").Value = Trim(txtmo.Text)
                cmd.Parameters("@d7").Value = Trim(txtdid.Text)
                cmd.Parameters("@d8").Value = Trim(txtdatetime.Text)
                cmd.ExecuteReader()

                MessageBox.Show("Successfully Registered", "Consultant", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Save.Enabled = False
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Reset()
        GetData()
    End Sub

    Private Sub txtdesig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtdesig.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from designationmaster where Designation=@name"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "Designation"))
            cmd.Parameters("@name").Value = Trim(txtdesig.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txtdid.Text = Trim(rdr.GetInt32(0))
            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Update_record_Click(sender As Object, e As EventArgs) Handles Update_record.Click
        Try

            If txtname.Text = "" Then
                MessageBox.Show("Please select Doctor Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update usermaster set UserID=@d1, UserName=@d2, Qualification=@d3, RegNo=@d4, Address=@d5, Mobile=@d6, DesignationID=@d7, ModifiedDateTime=@d8 where UserID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "UserID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "UserName"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "Qualification"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "RegNo"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 100, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "Mobile"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 100, "DesignationID"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.DateTime, 100, "ModifiedDateTime"))

            cmd.Parameters("@d1").Value = Trim(txtid.Text)
            cmd.Parameters("@d2").Value = Trim(txtname.Text)
            cmd.Parameters("@d3").Value = Trim(txtquali.Text)
            cmd.Parameters("@d4").Value = Trim(txtreg.Text)
            cmd.Parameters("@d5").Value = Trim(txtaddress.Text)
            cmd.Parameters("@d6").Value = Trim(txtmo.Text)
            cmd.Parameters("@d7").Value = Trim(txtdid.Text)
            cmd.Parameters("@d8").Value = Trim(txtdatetime.Text)

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

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try

            If txtname.Text = "" Then
                MessageBox.Show("Please select User Name ", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtname.Text.Count > 0 Then
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

            Dim cq As String = "delete from usermaster where UserName=@DELETE1;"

            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "UserName"))

            cmd.Parameters("@DELETE1").Value = Trim(txtname.Text)
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
            Reset()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgw_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgw.CellFormatting
        dgw.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

End Class