Imports System.Data.SqlClient
Imports System.Data

Public Class Patient_Tretment

    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub Patient_Tretment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        ' Display the date as "22 Feb 2001".
        DateTimePicker2.CustomFormat = "dd/MMM/yyyy"



        auto()
        auto1()
        auto2()
        fillcombo()
        filltextbox()
        Reset()
        RadioButton4.Checked = True
        RadioButton8.Checked = True
        txttt.Text = "Allopathic"
        Session()
    End Sub

    Sub Session()
        If (Now.Hour < 16) Then
            lblsession.Text = "Morning Session"
            txtsession.Text = "M"
        ElseIf (Now.Hour > 16) Then
            lblsession.Text = "Evening Session"
            txtsession.Text = "E"
        End If
    End Sub
    Sub auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(PatientID) as PatID from patientinfomaster"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("PatID").ToString() <> "" Then
            txtpimasterid.Text = Integer.Parse(rdr("PatID").ToString()) + 1
        Else
            txtpimasterid.Text = 1
        End If
        con.Close()
        rdr.Close()
    End Sub
    Sub auto1()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(PatientTretmentID) as PatID from patienttritment"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("PatID").ToString() <> "" Then
            txtptid.Text = Integer.Parse(rdr("PatID").ToString()) + 1
        Else
            txtptid.Text = 1
        End If
        con.Close()
        rdr.Close()
    End Sub
    Sub auto2()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(PationtTritmentDtID) as PatID from patienttritmentdt"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("PatID").ToString() <> "" Then
            txtptdtlid.Text = Integer.Parse(rdr("PatID").ToString()) + 1
        Else
            txtptdtlid.Text = 1
        End If
        con.Close()
        rdr.Close()
    End Sub
    Sub Reset()
        auto()
        auto1()
        auto2()
        txtvisitid.Text = ""
        txtpnserch.Text = ""
        txtp_nameserch.Text = ""
        DateTimePicker2.Text = Today
        txtcoex.Text = ""
        txtimiv.Text = ""
        txtadvise.Text = ""
        txtreport.Text = ""

        txtpb.Text = ""
        txtcc.Text = ""
        txtra.Text = ""
        txtba.Text = ""
        txtpatientname.Text = ""
        dgw1.DataSource = Nothing
        dgw2.DataSource = Nothing
        dgw3.DataSource = Nothing
        txtage.Text = ""
        txtcontact.Text = ""
        txtknown.Text = ""
        txtallergy.Text = ""
        txttt.Text = ""
        txtdosetype.Text = ""
        txtmedicine.Text = ""
        txttype.Text = ""
        txtnoofdose.Text = ""
        txtnofoday.Text = ""
        txttbletid.Text = ""
        txtdtid.Text = ""
        txtttid.Text = ""
        txtmid.Text = ""
        txtmedicinetypemaster.Text = ""
        txtdatetime.Text = DateAndTime.Now.ToString
        btnremve.Enabled = False
    End Sub
    Sub fillcombo()

        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(PatientName) FROM patientinfomaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtp_nameserch.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtp_nameserch.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

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

        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(DoseType) FROM dosetypemaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtdosetype.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtdosetype.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(TabletType) FROM tablettypemaster", CN)
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
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(MedicineName) FROM medicinemaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtmedicine.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtmedicine.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub filltextbox()
        Try
            Dim conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30")
            Dim cmd As New SqlCommand("Select PatientName from patientinfomaster", conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataSet
            da.Fill(dt)
            Dim column1 As New AutoCompleteStringCollection
            For i As Integer = 0 To dt.Tables(0).Rows.Count - 1
                column1.Add(dt.Tables(0).Rows(i)("PatientName").ToString())
            Next
            txtpnserch.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtpnserch.AutoCompleteCustomSource = column1
            txtpnserch.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        auto()
        auto1()
        auto2()
        Reset()
        fillcombo()
        filltextbox()
    End Sub



    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
        Home.Show()
    End Sub


    Private Sub txtpnserch_Click(sender As Object, e As EventArgs) Handles txtpnserch.Click
        Try
            Dim cs As New SqlConnection
            cs.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"
            cs.Open()

            Dim ct As String = "select PatientID, PatientName, Address, ContactNo, Age, KnownCaseOf, Allergy, ModifiedDateTime from patientinfomaster where PatientName='" + txtpnserch.Text + "'"

            Dim cmd As New SqlCommand(ct, cs)
            Dim myreder As SqlDataReader
            myreder = cmd.ExecuteReader
            myreder.Read()

            txtpimasterid.Text = myreder("PatientID")
            txtp_nameserch.Text = myreder("PatientName")
            txtpatientname.Text = myreder("PatientName")
            txtaddress.Text = myreder("Address")
            txtcontact.Text = myreder("ContactNo")
            txtage.Text = myreder("Age")
            txtknown.Text = myreder("KnownCaseOf")
            txtallergy.Text = myreder("Allergy")
            txtdatetime.Text = myreder("ModifiedDateTime")
            cs.Close()
            GetPatientDetails()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GetPriviosBalance()
    End Sub

    Private Sub txtp_nameserch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtp_nameserch.SelectedIndexChanged
        Try
            btndelet.Enabled = True
            btnsave.Enabled = True
            btnupdate.Enabled = True

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from patientinfomaster where PatientName=@name"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "PatientName"))
            cmd.Parameters("@name").Value = Trim(txtp_nameserch.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then

                txtpimasterid.Text = Trim(rdr.GetInt32(0))
                txtp_nameserch.Text = Trim(rdr.GetString(1))
                txtpnserch.Text = Trim(rdr.GetString(1))
                txtpatientname.Text = Trim(rdr.GetString(1))
                txtaddress.Text = Trim(rdr.GetString(2))
                txtcontact.Text = Trim(rdr.GetString(3))
                txtage.Text = Trim(rdr.GetString(4))
                txtknown.Text = Trim(rdr.GetString(5))
                txtallergy.Text = Trim(rdr.GetString(6))
                txtdatetime.Text = Trim(rdr.GetDateTime(7))


            End If


            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtupdateinfo_Click(sender As Object, e As EventArgs) Handles txtupdateinfo.Click
        Try

            If txtpatientname.Text = "" Then
                MessageBox.Show("Please select Patient Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update patientinfomaster set PatientID=@d1,PatientName=@d2,Address=@d3,ContactNo=@d4,Age=@d5,KnownCaseOf=@d6,Allergy=@d7,ModifiedDateTime=@d8 where PatientID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "PatirntId"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "PatientName"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "ContactNo"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 100, "age"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "KnownCaseOf"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 100, "Allergy"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.VarChar, 50, "ModifiedDateTime"))

            cmd.Parameters("@d1").Value = Trim(txtpimasterid.Text)
            cmd.Parameters("@d2").Value = Trim(txtpatientname.Text)
            cmd.Parameters("@d3").Value = Trim(txtaddress.Text)
            cmd.Parameters("@d4").Value = Trim(txtcontact.Text)
            cmd.Parameters("@d5").Value = Trim(txtage.Text)
            cmd.Parameters("@d6").Value = Trim(txtknown.Text)
            cmd.Parameters("@d7").Value = Trim(txtallergy.Text)
            cmd.Parameters("@d8").Value = Trim(txtdatetime.Text)


            cmd.ExecuteReader()


            If con.State = ConnectionState.Open Then
                con.Close()
            End If


            MessageBox.Show("Successfully Updated", "User details", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Reset()
            fillcombo()
            filltextbox()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txttt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txttt.SelectedIndexChanged
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

    Private Sub txtdosetype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtdosetype.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from dosetypemaster where DoseType=@name"


            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "DoseType"))
            cmd.Parameters("@name").Value = Trim(txtdosetype.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txtdtid.Text = Trim(rdr.GetInt32(0))
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txttype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txttype.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from tablettypemaster where TabletType=@name"


            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "TabletType"))
            cmd.Parameters("@name").Value = Trim(txttype.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txttbletid.Text = Trim(rdr.GetInt32(0))
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtmedicine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtmedicine.SelectedIndexChanged
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
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub btnserch_Click(sender As Object, e As EventArgs) Handles btnserch.Click

        Try
            Dim cs As New SqlConnection
            cs.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"
            cs.Open()

            Dim ct As String = "select PatientID, PatientName, Address, ContactNo, Age, KnownCaseOf, Allergy, ModifiedDateTime from patientinfomaster where PatientName='" + txtpnserch.Text + "'"

            Dim cmd As New SqlCommand(ct, cs)
            Dim myreder As SqlDataReader
            myreder = cmd.ExecuteReader
            myreder.Read()

            txtpimasterid.Text = myreder("PatientID")
            txtp_nameserch.Text = myreder("PatientName")
            txtpatientname.Text = myreder("PatientName")
            txtaddress.Text = myreder("Address")
            txtcontact.Text = myreder("ContactNo")
            txtage.Text = myreder("Age")
            txtknown.Text = myreder("KnownCaseOf")
            txtallergy.Text = myreder("Allergy")
            txtdatetime.Text = myreder("ModifiedDateTime")
            cs.Close()
            GetPatientDetails()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GetPriviosBalance()
    End Sub
    Public Sub GetPatientDetails()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(PatientTretmentID), RTRIM(PatientID), RTRIM(CaseOf), RTRIM(IMIV), RTRIM(CD), RTRIM(Visit), RTRIM(Advise), RTRIM(Report), RTRIM(CurrCharge), RTRIM(RecvAmt), RTRIM(BalanceAmt), RTRIM(VisitDate), RTRIM(ModifiedDateTime), RTRIM(IsComplet), RTRIM(CSession), RTRIM(Massage), RTRIM(Steam) from patienttritment where PatientID ='" + txtpimasterid.Text + "'", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw1.Rows.Clear()
            While (rdr.Read() = True)
                dgw1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgw2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgw2.CellFormatting
        dgw2.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub dgw1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgw1.CellFormatting
        dgw1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub dgw2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw2.CellContentClick

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        'If Len(Trim(txtpnserch.Text)) = 0 Then
        '    MessageBox.Show("Please Select Medicine Suppliyer Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtpnserch.Focus()
        '    Exit Sub
        'End If
        If Len(Trim(txtdosetype.Text)) = 0 Then
            MessageBox.Show("Please Select Dose Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtdosetype.Focus()
            Exit Sub
        End If
        If Len(Trim(txtmedicine.Text)) = 0 Then
            MessageBox.Show("Please Select Medicine Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtmedicine.Focus()
            Exit Sub
        End If
        If Len(Trim(txttype.Text)) = 0 Then
            MessageBox.Show("Please Select Tablet Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txttype.Focus()
            Exit Sub
        End If
        If Len(Trim(txtnoofdose.Text)) = 0 Then
            MessageBox.Show("Please Select Number of Dose", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtnoofdose.Focus()
            Exit Sub
        End If
        If Len(Trim(txtnofoday.Text)) = 0 Then
            MessageBox.Show("Please Select Number of Day", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtnofoday.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into patienttritmentdt(PationtTritmentDtID,DoseTypeID,MedicineID,TabletTypeID,NoofDose,NoofDays,PatientTretmentID) 
                                VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "PationtTritmentDtID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "DoseTypeID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "TabletTypeID"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "NoofDose"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "NoofDays"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "PatientTretmentID"))

            cmd.Parameters("@d1").Value = Trim(txtptdtlid.Text)
            cmd.Parameters("@d2").Value = Trim(txtdtid.Text)
            cmd.Parameters("@d3").Value = Trim(txtmid.Text)
            cmd.Parameters("@d4").Value = Trim(txttbletid.Text)
            cmd.Parameters("@d5").Value = Trim(txtnoofdose.Text)
            cmd.Parameters("@d6").Value = Trim(txtnofoday.Text)
            cmd.Parameters("@d7").Value = Trim(txtptid.Text)
            cmd.ExecuteReader()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'dgw2.Rows.Add(txtptdtlid.Text, txtdtid.Text, txtdosetype.Text, txtmid.Text, txtmedicine.Text, txttbletid.Text, txttype.Text, txtnoofdose.Text, txtnofoday.Text, txtptid.Text)
        dgw2.Rows.Add(txtdosetype.Text, txtmedicine.Text, txttype.Text, txtnoofdose.Text, txtnofoday.Text)



        fillcombo()
        con.Close()

        auto2()
        txttbletid.Text = ""
        txtdosetype.Text = ""
        txttype.Text = ""
        txtmid.Text = ""
        txtmedicine.Text = ""
        txtnoofdose.Text = ""
        txtnofoday.Text = ""
        txtmedicinetypemaster.Text = ""
    End Sub


    Private Sub btnremve_Click(sender As Object, e As EventArgs) Handles btnremve.Click
        Try

            If txtptdtlid.Text = "" Then
                MessageBox.Show("Please Select Patient Detail", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtptdtlid.Focus()
                Exit Sub
            End If
            If txtptdtlid.Text.Count > 0 Then
                If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    Remove_records()
                End If
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Remove_records()
        Try

            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()


            Dim cq As String = "delete from patienttritmentdt where PationtTritmentDTID=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "PationtTritmentDTID"))


            cmd.Parameters("@DELETE1").Value = Trim(txtptdtlid.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        GetPatientTretmentDetails()
        txttt.Text = ""
        txtdosetype.Text = ""
        txtnofoday.Text = ""
        txttype.Text = ""
        txtmedicine.Text = ""
        txtnoofdose.Text = ""
        RadioButton7.Text = ""
        RadioButton8.Text = ""
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        txtmedicinetypemaster.Text = "1"
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        txtmedicinetypemaster.Text = "2"
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        If Len(Trim(txtpnserch.Text)) = 0 Then
            MessageBox.Show("Please Enter Details", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpnserch.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into patienttritment(PatientTretmentID,PatientID,CaseOf,IMIV,CD,Visit,Advise,Report,CurrCharge,RecvAmt,BalanceAmt,VisitDate,ModifiedDateTime,IsComplet,CSession) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "PatientTretmentID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "PatientID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "CaseOf"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "IMIV"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "CD"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "Visit"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "Advise"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.VarChar, 50, "Report"))
            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.VarChar, 50, "CurrCharge"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.VarChar, 50, "RecvAmt"))
            cmd.Parameters.Add(New SqlParameter("@d11", System.Data.SqlDbType.VarChar, 50, "BalanceAmt"))
            cmd.Parameters.Add(New SqlParameter("@d12", System.Data.SqlDbType.VarChar, 50, "VisitDate"))
            cmd.Parameters.Add(New SqlParameter("@d13", System.Data.SqlDbType.VarChar, 50, "ModifiedDateTime"))
            cmd.Parameters.Add(New SqlParameter("@d14", System.Data.SqlDbType.VarChar, 50, "IsComplet"))
            cmd.Parameters.Add(New SqlParameter("@d15", System.Data.SqlDbType.VarChar, 50, "CSession"))

            cmd.Parameters("@d1").Value = Trim(txtptid.Text)
            cmd.Parameters("@d2").Value = Trim(txtpimasterid.Text)
            cmd.Parameters("@d3").Value = Trim(txtcoex.Text)
            cmd.Parameters("@d4").Value = Trim(txtimiv.Text)
            cmd.Parameters("@d5").Value = Trim(txtcdid.Text)
            cmd.Parameters("@d6").Value = Trim(txtvisitid.Text)
            cmd.Parameters("@d7").Value = Trim(txtadvise.Text)
            cmd.Parameters("@d8").Value = Trim(txtreport.Text)
            cmd.Parameters("@d9").Value = Trim(txtcc.Text)
            cmd.Parameters("@d10").Value = Trim(txtra.Text)
            cmd.Parameters("@d11").Value = Trim(txtba.Text)
            cmd.Parameters("@d12").Value = Trim(DateTimePicker2.Text)
            cmd.Parameters("@d13").Value = Trim(DateTimePicker2.Text)
            cmd.Parameters("@d14").Value = "Yes"
            cmd.Parameters("@d15").Value = Trim(txtsession.Text)


            cmd.ExecuteReader()

            MessageBox.Show("Successfully Data Save", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            filltextbox()
            fillcombo()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        auto1()
        txtptid.Text = ""
        txtpimasterid.Text = ""
        txtcoex.Text = ""
        txtimiv.Text = ""
        txtadvise.Text = ""
        txtreport.Text = ""
        txtcc.Text = ""
        txtra.Text = ""
        txtba.Text = ""
        DateTimePicker2.Text = ""

        Reset()
    End Sub
    Sub GetPriviosBalance()
        Dim num1 As Decimal

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT BalanceAmt from patienttritment where PatientID=@d1"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtpimasterid.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num1 = rdr.GetValue(0)
            End If
            con.Close()
            txtpb.Text = num1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnpatientadd_Click(sender As Object, e As EventArgs) Handles btnpatientadd.Click
        If Len(Trim(txtpatientname.Text)) = 0 Then
            MessageBox.Show("Please Enter Patient Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpatientname.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into patientinfomaster(PatientID,PatientName,Address,ContactNo,Age,KnownCaseOf,Allergy,ModifiedDateTime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "PationtID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "PatientName"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "Address"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "Age"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "ContactNo"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "KnownCaseOf"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "Allergy"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.VarChar, 50, "ModifiedDateTime"))

            cmd.Parameters("@d1").Value = Trim(txtpimasterid.Text)
            cmd.Parameters("@d2").Value = Trim(txtpatientname.Text)
            cmd.Parameters("@d3").Value = Trim(txtaddress.Text)
            cmd.Parameters("@d4").Value = Trim(txtage.Text)
            cmd.Parameters("@d5").Value = Trim(txtcontact.Text)
            cmd.Parameters("@d6").Value = Trim(txtknown.Text)
            cmd.Parameters("@d7").Value = Trim(txtallergy.Text)
            cmd.Parameters("@d8").Value = Trim(txtdatetime.Text)
            cmd.ExecuteReader()

            MessageBox.Show("Successfully Data Save", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            filltextbox()
            fillcombo()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        auto()
        txtpatientname.Text = ""
        txtaddress.Text = ""
        txtcontact.Text = ""
        txtage.Text = ""
        txtknown.Text = ""
        txtallergy.Text = ""
        txtdatetime.Text = DateAndTime.Now.ToString
    End Sub

    Private Sub txtba_TextChanged(sender As Object, e As EventArgs) Handles txtba.TextChanged
        txtba.Text = Val(txtpb.Text) + Val(txtcc.Text) - Val(txtra.Text)
    End Sub

    Private Sub btnmupdate_Click(sender As Object, e As EventArgs) Handles btnmupdate.Click
        Try

            If txtptdtlid.Text = "" Then
                MessageBox.Show("Please select Select Details", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update patienttritmentdt set PationtTritmentDtID=@d1,DoseTypeID=@d2,MedicineID=@d3,TabletTypeID=@d4,NoofDose=@d5,NoofDays=@d6,PatientTretmentID=@d7 where PationtTritmentDtID=@d1"

            cmd = New SqlCommand(cb)
            cmd = New SqlCommand(cb)

            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "PationtTritmentDtID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "DoseTypeID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "TabletTypeID"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "NoofDose"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "NoofDays"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "PatientTretmentID"))

            cmd.Parameters("@d1").Value = Trim(txtptdtlid.Text)
            cmd.Parameters("@d2").Value = Trim(txtdtid.Text)
            cmd.Parameters("@d3").Value = Trim(txtmid.Text)
            cmd.Parameters("@d4").Value = Trim(txttbletid.Text)
            cmd.Parameters("@d5").Value = Trim(txtnoofdose.Text)
            cmd.Parameters("@d6").Value = Trim(txtnofoday.Text)
            cmd.Parameters("@d7").Value = Trim(txtptid.Text)
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

        dgw2.Rows.Add(txtptdtlid.Text, txttt.Text, txtdtid.Text, txtdosetype.Text, txtmid.Text, txtmedicine.Text, txttbletid.Text, txttype.Text, txtnoofdose.Text, txtnofoday.Text, txtptid.Text)
        GetPatientTretmentDetails()
        auto2()
        txttbletid.Text = ""
        txttt.Text = ""
        txtdtid.Text = ""
        txtdosetype.Text = ""
        txtttid.Text = ""
        txttype.Text = ""
        txtmid.Text = ""
        txtmedicine.Text = ""
        txtnoofdose.Text = ""
        txtnofoday.Text = ""
        txtmedicinetypemaster.Text = ""

    End Sub
    Private Sub dgw2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw2.CellClick
        Dim dr As Integer
        dr = e.RowIndex
        Dim selectRow As DataGridViewRow
        selectRow = dgw2.Rows(dr)

        txtptid.Text = selectRow.Cells(0).Value.ToString()
        txtdtid.Text = selectRow.Cells(1).Value.ToString()
        txtdosetype.Text = selectRow.Cells(2).Value.ToString()
        txtmid.Text = selectRow.Cells(3).Value.ToString()
        txtmedicine.Text = selectRow.Cells(4).Value.ToString()
        txttbletid.Text = selectRow.Cells(5).Value.ToString()
        txttype.Text = selectRow.Cells(6).Value.ToString()
        txtnofoday.Text = selectRow.Cells(7).Value.ToString()
        txtnoofdose.Text = selectRow.Cells(8).Value.ToString()
        txtptid.Text = selectRow.Cells(9).Value.ToString()


        'GetPatientTretmentDetails()

    End Sub
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try

            If txtpatientname.Text = "" Then
                MessageBox.Show("Please select Select Patient Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtpatientname.Focus()
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update patienttritment set PationtTritmentID=@d1,PatientID=@d2,CaseOf=@d3,IMIV=@d4,CD=@d5,Visit=@d6,Advise=@d7,Report=@d8,CurrCharge=@d9,RecvAmt=@d10,BalanceAmt=@d11,VisitDate=@d12,ModifiedDateTime=@d13,IsComplet=@d14,CSession=@d15,Massage=@d16,Steam=@d17 where PatientID=@d2"

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "PatientTretmentID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "PatientID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "CaseOf"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "IMIV"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "CD"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "Visit"))
            cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "Advise"))
            cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.VarChar, 50, "Report"))
            cmd.Parameters.Add(New SqlParameter("@d9", System.Data.SqlDbType.VarChar, 50, "CurrCharge"))
            cmd.Parameters.Add(New SqlParameter("@d10", System.Data.SqlDbType.VarChar, 50, "RecvAmt"))
            cmd.Parameters.Add(New SqlParameter("@d11", System.Data.SqlDbType.VarChar, 50, "BalanceAmt"))
            cmd.Parameters.Add(New SqlParameter("@d12", System.Data.SqlDbType.VarChar, 50, "VisitDate"))
            cmd.Parameters.Add(New SqlParameter("@d13", System.Data.SqlDbType.VarChar, 50, "ModifiedDateTime"))
            cmd.Parameters.Add(New SqlParameter("@d14", System.Data.SqlDbType.VarChar, 50, "IsComplet"))
            cmd.Parameters.Add(New SqlParameter("@d15", System.Data.SqlDbType.VarChar, 50, "CSession"))
            cmd.Parameters.Add(New SqlParameter("@d16", System.Data.SqlDbType.VarChar, 50, "Massage"))
            cmd.Parameters.Add(New SqlParameter("@d17", System.Data.SqlDbType.VarChar, 50, "Steam"))

            cmd.Parameters("@d1").Value = Trim(txtptid.Text)
            cmd.Parameters("@d2").Value = Trim(txtpimasterid.Text)
            cmd.Parameters("@d3").Value = Trim(txtcoex.Text)
            cmd.Parameters("@d4").Value = Trim(txtimiv.Text)
            cmd.Parameters("@d5").Value = Trim(RadioButton4.Text)
            cmd.Parameters("@d6").Value = Trim(CheckBox1.Text)
            cmd.Parameters("@d7").Value = Trim(txtadvise.Text)
            cmd.Parameters("@d8").Value = Trim(txtreport.Text)
            cmd.Parameters("@d9").Value = Trim(txtcc.Text)
            cmd.Parameters("@d10").Value = Trim(txtra.Text)
            cmd.Parameters("@d11").Value = Trim(txtba.Text)
            cmd.Parameters("@d12").Value = Trim(DateTimePicker2.Text)
            cmd.Parameters("@d13").Value = Trim(DateTimePicker2.Text)
            cmd.Parameters("@d14").Value = "1"
            cmd.Parameters("@d15").Value = "M"

            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            MessageBox.Show("Successfully Updated", "Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Information)

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dgw1.Rows.Add(txtptdtlid.Text, txttt.Text, txtdtid.Text, txtdosetype.Text, txtmid.Text, txtmedicine.Text, txttbletid.Text, txttype.Text, txtnoofdose.Text, txtnofoday.Text, txtptid.Text)
        filltextbox()
        fillcombo()
        auto1()
        txtptid.Text = ""
        txtpimasterid.Text = ""
        txtcoex.Text = ""
        txtimiv.Text = ""
        txtadvise.Text = ""
        txtreport.Text = ""
        txtcc.Text = ""
        txtra.Text = ""
        txtba.Text = ""
        DateTimePicker2.Text = ""

        Reset()
    End Sub

    Private Sub dgw1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgw1.DoubleClick
        Try
            Dim dr As DataGridViewRow = dgw1.SelectedRows(0)
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();

            txtptid.Text = dr.Cells(0).Value.ToString()
            txtpimasterid.Text = dr.Cells(1).Value.ToString()
            txtcoex.Text = dr.Cells(2).Value.ToString()
            txtimiv.Text = dr.Cells(3).Value.ToString()
            txtadvise.Text = dr.Cells(6).Value.ToString()
            txtreport.Text = dr.Cells(7).Value.ToString()
            txtcc.Text = dr.Cells(8).Value.ToString()
            txtra.Text = dr.Cells(9).Value.ToString()
            txtba.Text = dr.Cells(10).Value.ToString()
            DateTimePicker2.Text = dr.Cells(11).Value.ToString()
            txtdatetime.Text = dr.Cells(12).Value.ToString()


            btnupdate.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        For Each row As DataGridViewRow In dgw1.SelectedRows
            dgw1.Rows.Remove(row)
        Next

    End Sub

    Private Sub dgw1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw1.CellClick
        Dim dr As Integer
        dr = e.RowIndex
        Dim selectRow As DataGridViewRow
        selectRow = dgw1.Rows(dr)
        txtptid.Text = selectRow.Cells(0).Value

        GetPatientTretmentDetails()

    End Sub

    Public Sub GetPatientTretmentDetails()
        Try
            con = New SqlConnection(cs)
            con.Open()
            ' cmd = New SqlCommand("SELECT RTRIM(PationtTritmentDtID), RTRIM(DoseTypeID), RTRIM(dosetypemaster.DoseType), RTRIM(MedicineID), RTRIM(TabletTypeID), RTRIM(NoofDose), RTRIM(NoofDays), RTRIM(PatientTretmentID) from patienttritmentdt,dosetypemaster where PatientTretmentID ='" + txtptid.Text + "'", con)
            cmd = New SqlCommand("Select PationtTritmentDtID, DoseTypeID, RTRIM(dosetypemaster.DoseType), patienttritmentdt.MedicineID, RTRIM(medicinemaster.MedicineName), patienttritmentdt.TabletTypeID, RTRIM(tablettypemaster.TabletType), NoofDose, NoofDays, PatientTretmentID from patienttritmentdt INNER JOIN dosetypemaster ON patienttritmentdt.DoseTypeID = dosetypemaster.DoseID INNER JOIN medicinemaster ON patienttritmentdt.MedicineID = medicinemaster.MedicineID INNER JOIN tablettypemaster ON patienttritmentdt.TabletTypeID = tablettypemaster.TabletTypeID where PatientTretmentID ='" + txtptid.Text + "'", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw2.Rows.Clear()
            While (rdr.Read() = True)
                dgw2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Generic_Medicine_List.Show()
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        Generic_Medicine_List.Show()
    End Sub

    Private Sub btndelet_Click(sender As Object, e As EventArgs) Handles btndelet.Click
        Try

            If txtptid.Text = "" Then
                MessageBox.Show("Please Select Patient Detail", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtptdtlid.Focus()
                Exit Sub
            End If
            If txtptid.Text.Count > 0 Then
                If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    Delete_records()
                End If
            End If

            For Each row As DataGridViewRow In dgw1.SelectedRows
                dgw1.Rows.Remove(row)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Reset()
    End Sub

    Private Sub Delete_records()
        Try

            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()


            Dim cq As String = "delete from patienttritment where PatientTretmentID=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "PatientTretmentID"))


            cmd.Parameters("@DELETE1").Value = Trim(txtptid.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    End Sub

    Private Sub btnrefrese_Click(sender As Object, e As EventArgs) Handles btnrefrese.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        txtcdid.Text = "1"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        txtcdid.Text = "2"
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        txtcdid.Text = "3"
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        txtcdid.Text = "0"
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtvisitid.Text = "1"
        End If
        If CheckBox1.Checked = False Then
            txtvisitid.Text = "0"
        End If

    End Sub
End Class

