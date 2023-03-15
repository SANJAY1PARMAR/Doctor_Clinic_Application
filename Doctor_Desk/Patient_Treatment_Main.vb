Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Windows.Forms

Public Class Patient_Treatment_Main

    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable

    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"
    Private Sub Patient_Treatment_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        ' Display the date as "22 Feb 2001".
        DateTimePicker1.CustomFormat = "dd/MMM/yyyy hh:mm:ss"

        txttt.Text = "Allopathic"
        txtdatetime.Text = Today

        RadioButton4.Checked = True
        RadioButton5.Checked = True

        Session()
        ' Page_Disble()
        visit()
        'FillTreatmentTypeID()

        GetPatientID()
        GetPatientTretmentID()
        GetPationtTritmentDtID()

        GetMedicineID()
        GetTabletTypeID()
        FillTreatmentTypeID()
        Page_Disble()
        fillcombo()
    End Sub

    'GET Page Session Details 
    Public Sub Session()
        If (Now.Hour < 15.55) Then
            lblsession.Text = "Morning Session"
            txtsession.Text = "M"
        ElseIf (Now.Hour > 15.56) Then
            lblsession.Text = "Evening Session"
            txtsession.Text = "E"
        End If
    End Sub

    ' GET ALL ID's
    Public Sub GetMedicineID()
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select Max(MedicineID) as CatID from medicinemaster"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("CatID").ToString() <> "" Then
            txtmid.Text = Integer.Parse(rdr("CatID").ToString()) + 1
        Else
            txtmid.Text = 1
        End If
        con.Close()
        rdr.Close()
    End Sub
    Public Sub GetTabletTypeID()

        con = New SqlConnection(cs)
        con.Open()
        Dim ctt As String = "select Max(TabletTypeID) as tabID from tablettypemaster"
        cmd = New SqlCommand(ctt)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("tabID").ToString() <> "" Then
            txttbletid.Text = Integer.Parse(rdr("tabID").ToString()) + 1
        Else
            txttbletid.Text = 1
        End If
        con.Close()
        rdr.Close()

    End Sub
    Public Sub GetPatientID()
        'Patient Master Id Generate 
        con = New SqlConnection(cs)
        con.Open()
        Dim pm As String = "select Max(PatientID) as PatID from patientinfomaster"
        cmd = New SqlCommand(pm)
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
    Sub GetPatientTretmentID()

        'Patient Treatment Id Generate

        con = New SqlConnection(cs)
        con.Open()
        Dim pt As String = "select Max(PatientTretmentID) as PTID from patienttritment"
        cmd = New SqlCommand(pt)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("PTID").ToString() <> "" Then
            txtptid.Text = Integer.Parse(rdr("PTID").ToString()) + 1
        Else
            txtptid.Text = 1
        End If
        con.Close()
        rdr.Close()

    End Sub
    Public Sub GetPationtTritmentDtID()
        'Patient Treatment Details Id Generate

        con = New SqlConnection(cs)
        con.Open()
        Dim ptd As String = "select Max(PationtTritmentDtID) as PtdID from patienttritmentdt"
        cmd = New SqlCommand(ptd)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        rdr.Read()
        If rdr("PtdID").ToString() <> "" Then
            txtptdtlid.Text = Integer.Parse(rdr("PtdID").ToString()) + 1
        Else
            txtptdtlid.Text = 1
        End If
        con.Close()
        rdr.Close()
    End Sub

    'FIll Id's
    Public Sub FillTreatmentTypeID()
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

    Sub fillcombo()

        Dim conn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30")

        Dim cmd As SqlCommand = New SqlCommand("Select PatientName from patientinfomaster where PatientName like '%" + txtpnserch.Text + "%'", con)
        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim MyCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        While reader.Read()
            MyCollection.Add(reader.GetString(0))
        End While
        txtpnserch.AutoCompleteCustomSource = MyCollection
        txtpnserch.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtpnserch.AutoCompleteMode = AutoCompleteMode.Suggest
        con.Close()


        'Fill Treatment Type'
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("Select distinct  RTRIM(TreatmentType) From treatmrnttypemaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txttt.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txttt.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'Fill Dose Type'
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
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'Fill Tablet Type'
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT TabletType FROM tablettypemaster order by TabletType", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txttype.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txttype.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'AutoFill Medicine Name'
        Try
            Dim conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30")
            Dim cmd1 As New SqlCommand("Select MedicineName from medicinemaster order by MedicineName", conn)
            Dim da As New SqlDataAdapter(cmd1)
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

        'Fill Medicine Name'
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

    'Serch Patient Details 
    Sub Serch()
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
        'GetPriviosBalance()
    End Sub

    Public Sub GetPatientDetails()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT PatientTretmentID, patienttritment.PatientID, RTRIM(patientinfomaster.PatientName), CaseOf, IMIV, CD, Visit, Advise, Report, CurrCharge, RecvAmt, BalanceAmt, VisitDate, patienttritment.ModifiedDateTime, IsComplet, CSession from patienttritment 
                                  INNER JOIN patientinfomaster ON patienttritment.PatientID = patientinfomaster.PatientID  
                                  where patienttritment.PatientID ='" + txtpimasterid.Text + "'
                                  order by (VisitDate)desc", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnserch_Click(sender As Object, e As EventArgs) Handles btnserch.Click
        Serch()
    End Sub

    'Add New Patient Details 
    Private Sub btnpatientadd_Click(sender As Object, e As EventArgs)
        lblbtn.Text = "New"
        'Page_Enable()
    End Sub

    'Update Patient Information 
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

            con.Close()
            fillcombo()

            txtpatientname.Text = ""
            txtaddress.Text = ""
            txtcontact.Text = ""
            txtage.Text = ""
            txtknown.Text = ""
            txtallergy.Text = ""
            txtdatetime.Text = DateAndTime.Now.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Button New
    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        lblbtn.Text = "New1"
        DataGridView1.Rows.Clear()
        GetPatientTretmentID()
        GetPationtTritmentDtID()
        Page_Enable()
    End Sub

    Sub Page_Enable()
        txtp_nameserch.Enabled = True
        txtpatientname.Enabled = True
        txtaddress.Enabled = True
        txtknown.Enabled = True
        txtallergy.Enabled = True
        txtage.Enabled = True
        txtcontact.Enabled = True
        txtupdateinfo.Enabled = True
        DateTimePicker1.Enabled = True
        CheckBox1.Enabled = True
        txtcoex.Enabled = True
        txtimiv.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
        RadioButton4.Enabled = True
        txtadvise.Enabled = True
        txtreport.Enabled = True
        txtpb.Enabled = True
        txtcc.Enabled = True
        txtra.Enabled = True
        txtba.Enabled = True
        btnsubmit.Enabled = True
        btnupdate.Enabled = True
        btndelet.Enabled = True
        txttt.Enabled = True
        txtdosetype.Enabled = True
        txttype.Enabled = True
        txtnofoday.Enabled = True
        txtnoofdose.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        txtmedicine.Enabled = True
        RadioButton5.Enabled = True
        RadioButton6.Enabled = True
        btnadd.Enabled = True
        btnmupdate.Enabled = True
        btnremve.Enabled = True
        btnrefrese.Enabled = True
        btnsave.Enabled = True
    End Sub
    Sub Page_Cleare()
        txtpnserch.Text = ""
        txtp_nameserch.Text = ""
        txtpatientname.Text = ""
        txtaddress.Text = ""
        txtknown.Text = ""
        txtallergy.Text = ""
        txtage.Text = ""
        txtcontact.Text = ""
        DateTimePicker1.Text = Today
        txtcoex.Text = ""
        txtimiv.Text = ""
        txtadvise.Text = ""
        txtreport.Text = ""
        txtpb.Text = ""
        txtcc.Text = ""
        txtra.Text = ""
        txtba.Text = ""
        txtdosetype.Text = ""
        txttype.Text = ""
        txtnofoday.Text = ""
        txtnoofdose.Text = ""
        txtmedicine.Text = ""
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        DataGridView3.Rows.Clear()
        txttt.Text = "Allopathic"
        txtdatetime.Text = Today
        RadioButton4.Checked = True
        RadioButton5.Checked = True
        visit()
    End Sub
    Sub Page_Disble()
        txtp_nameserch.Enabled = False
        txtpatientname.Enabled = False
        txtaddress.Enabled = False
        txtknown.Enabled = False
        txtallergy.Enabled = False
        txtage.Enabled = False
        txtcontact.Enabled = False
        txtupdateinfo.Enabled = False
        DateTimePicker1.Enabled = False
        CheckBox1.Enabled = False
        txtcoex.Enabled = False
        txtimiv.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        RadioButton4.Enabled = False
        txtadvise.Enabled = False
        txtreport.Enabled = False
        txtpb.Enabled = False
        txtcc.Enabled = False
        txtra.Enabled = False
        txtba.Enabled = False
        txttt.Enabled = False
        txtdosetype.Enabled = False
        txttype.Enabled = False
        txtnofoday.Enabled = False
        txtnoofdose.Enabled = False
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False
        txtmedicine.Enabled = False
        RadioButton5.Enabled = False
        RadioButton6.Enabled = False
    End Sub

    'Refrese Button 
    Sub Load_InComplet()
        Try
            con = New SqlConnection(cs)
            con.Open()
            'cmd = New SqlCommand("SELECT RTRIM(PatientTretmentID), RTRIM(PatientID), from patienttritment where PatientID ='" + txtpimasterid.Text + "'", con)
            cmd = New SqlCommand("Select PatientTretmentID, patienttritment.PatientID, RTRIM(patientinfomaster.PatientName) from patienttritment 
                                    INNER JOIN patientinfomaster ON patienttritment.PatientID = patientinfomaster.PatientID 
                                    where IsComplet ='No'", con)

            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView3.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView3.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnrefrese_Click(sender As Object, e As EventArgs) Handles btnrefrese.Click
        Load_InComplet()
    End Sub
    Public Sub GetPatientTretmentRefresh()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT PatientTretmentID, patienttritment.PatientID, RTRIM(patientinfomaster.PatientName), CaseOf, IMIV, CD, Visit, Advise, Report, CurrCharge, RecvAmt, BalanceAmt, VisitDate, patienttritment.ModifiedDateTime, IsComplet, CSession from patienttritment 
                                  INNER JOIN patientinfomaster ON patienttritment.PatientID = patientinfomaster.PatientID  
                                  where patienttritment.PatientID ='" + txtpimasterid.Text + "' order by (VisitDate)desc", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'Close Page 
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
        Home.Show()
    End Sub

    Sub G_and_B_Medicine()

        If txtmedicinetypemaster.Text = "2" Then
            RadioButton6.Checked = True
        End If
        If txtmedicinetypemaster.Text = "1" Then
            RadioButton5.Checked = True
        End If

    End Sub
    Sub C_and_D()

        If txtcdid.Text = "0" Then
            RadioButton4.Checked = True
        End If
        If txtcdid.Text = "1" Then
            RadioButton1.Checked = True
        End If
        If txtcdid.Text = "2" Then
            RadioButton2.Checked = True
        End If
        If txtcdid.Text = "3" Then
            RadioButton3.Checked = True
        End If
    End Sub

    Sub visit()
        If CheckBox1.Checked = True Then
            txtvisitid.Text = "1"
        End If
        If CheckBox1.Checked = False Then
            txtvisitid.Text = "0"
        End If

        If txtvisitid.Text = "1" Then
            CheckBox1.Checked = True
        End If
        If txtvisitid.Text = "2" Then
            CheckBox1.Checked = False
        End If
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        visit()
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

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        txtmedicinetypemaster.Text = "1"
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        txtmedicinetypemaster.Text = "2"
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        If lblbtn.Text = "Edit" Then
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into patienttritmentdt(DoseTypeID,MedicineID,TabletTypeID,NoofDose,NoofDays,PatientTretmentID) 
                                   VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            'cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "PationtTritmentDtID"))
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "DoseTypeID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
            cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "TabletTypeID"))
            cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "NoofDose"))
            cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "NoofDays"))
            cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "PatientTretmentID"))

            'cmd.Parameters("@d1").Value = Trim(txtptdtlid.Text)
            cmd.Parameters("@d1").Value = Trim(txtdtid.Text)
            cmd.Parameters("@d2").Value = Trim(txtmid.Text)
            cmd.Parameters("@d3").Value = Trim(txttbletid.Text)
            cmd.Parameters("@d4").Value = Trim(txtnoofdose.Text)
            cmd.Parameters("@d5").Value = Trim(txtnofoday.Text)
            cmd.Parameters("@d6").Value = Trim(txtptid.Text)
            cmd.ExecuteReader()
            con.Close()
            GetPatientTretmentDetails()
        Else
            DataGridView1.Rows.Add(txtptdtlid.Text, txtdtid.Text, txtdosetype.Text, txtmid.Text, txtmedicine.Text, txtttid.Text, txttype.Text, txtnoofdose.Text, txtnofoday.Text, txtptid.Text)
        End If
    End Sub

    Private Sub btnmupdate_Click(sender As Object, e As EventArgs) Handles btnmupdate.Click
        If lblbtn.Text = "Edit" Then
            con = New SqlConnection(cs)
            con.Open()
            ' Dim i As Integer
            'i = DataGridView1.SelectedRows(0).Cells(0).Value

            Dim cb As String = "update patienttritmentdt set DoseTypeID=@d2,MedicineID=@d3,TabletTypeID=@d4,NoofDose=@d5,NoofDays=@d6,PatientTretmentID=@d7 
                                       where PationtTritmentDtID=@d1"

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
            con.Close()
            GetPatientTretmentDetails()
        Else
            Dim i As Integer = DataGridView1.SelectedRows(0).Index
            Dim newDataRow As DataGridViewRow
            newDataRow = DataGridView1.Rows(i)
            newDataRow.Cells(0).Value = txtptdtlid.Text
            newDataRow.Cells(1).Value = txtdtid.Text
            newDataRow.Cells(2).Value = txtdosetype.Text
            newDataRow.Cells(3).Value = txtmid.Text
            newDataRow.Cells(4).Value = txtmedicine.Text
            newDataRow.Cells(5).Value = txtttid.Text
            newDataRow.Cells(6).Value = txttype.Text
            newDataRow.Cells(7).Value = txtnoofdose.Text
            newDataRow.Cells(8).Value = txtnofoday.Text
            newDataRow.Cells(9).Value = txtptid.Text
        End If
    End Sub

    Public Sub GetPatientTretmentDetails()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select PationtTritmentDtID, DoseTypeID, RTRIM(dosetypemaster.DoseType), patienttritmentdt.MedicineID, RTRIM(medicinemaster.MedicineName), patienttritmentdt.TabletTypeID, RTRIM(tablettypemaster.TabletType), NoofDose, NoofDays, PatientTretmentID 
                                  from patienttritmentdt 
                                  INNER JOIN dosetypemaster ON patienttritmentdt.DoseTypeID = dosetypemaster.DoseID INNER JOIN medicinemaster ON patienttritmentdt.MedicineID = medicinemaster.MedicineID INNER JOIN tablettypemaster ON patienttritmentdt.TabletTypeID = tablettypemaster.TabletTypeID 
                                  where PatientTretmentID ='" + txtptid.Text + "'", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnremve_Click(sender As Object, e As EventArgs) Handles btnremve.Click
        Dim i As Integer = DataGridView1.SelectedRows(0).Index
        DataGridView1.Rows.RemoveAt(i)
    End Sub

    Private Sub Remove_records()
        Try

            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()

            Dim cq As String = "delete from patienttritmentdt where PationtTritmentDtID=@DELETE1;"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 50, "PationtTritmentDtID"))

            cmd.Parameters("@DELETE1").Value = Trim(txtptdtlid.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                ' MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    End Sub

    'Data Grid View Setting 
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        DataGridView2.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DataGridView3_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView3.CellFormatting
        DataGridView3.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If lblbtn.Text = "Update" Then
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = DataGridView1.Rows(dr)
            txtptdtlid.Text = selectRow.Cells(0).Value
            txtdtid.Text = selectRow.Cells(1).Value.ToString()
            txtdosetype.Text = selectRow.Cells(2).Value.ToString()
            txtmid.Text = selectRow.Cells(3).Value.ToString()
            txtmedicine.Text = selectRow.Cells(4).Value.ToString()
            txttbletid.Text = selectRow.Cells(5).Value.ToString()
            txttt.Text = selectRow.Cells(6).Value.ToString()
            txtnofoday.Text = selectRow.Cells(7).Value.ToString()
            txtnoofdose.Text = selectRow.Cells(8).Value.ToString()
        Else
            Dim dr As Integer
            dr = e.RowIndex
            Dim selectRow As DataGridViewRow
            selectRow = DataGridView1.Rows(dr)
            txtptdtlid.Text = selectRow.Cells(0).Value
            txtdtid.Text = selectRow.Cells(1).Value.ToString()
            txtdosetype.Text = selectRow.Cells(2).Value.ToString()
            txtmid.Text = selectRow.Cells(3).Value.ToString()
            txtmedicine.Text = selectRow.Cells(4).Value.ToString()
            txttbletid.Text = selectRow.Cells(5).Value.ToString()
            txttt.Text = selectRow.Cells(6).Value.ToString()
            txtnofoday.Text = selectRow.Cells(7).Value.ToString()
            txtnoofdose.Text = selectRow.Cells(8).Value.ToString()
            txtptid.Text = selectRow.Cells(9).Value.ToString()
        End If
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick

        Dim dr As Integer
        dr = e.RowIndex
        Dim selectRow As DataGridViewRow
        selectRow = DataGridView2.Rows(dr)
        txtptid.Text = selectRow.Cells(0).Value
        txtpimasterid.Text = selectRow.Cells(1).Value.ToString()
        txtpatientname.Text = selectRow.Cells(2).Value.ToString()
        txtcoex.Text = selectRow.Cells(3).Value.ToString()
        txtimiv.Text = selectRow.Cells(4).Value.ToString()
        txtvisitid.Text = selectRow.Cells(6).Value.ToString()
        txtadvise.Text = selectRow.Cells(7).Value.ToString()
        txtreport.Text = selectRow.Cells(8).Value.ToString()
        txtcc.Text = selectRow.Cells(9).Value.ToString()
        txtra.Text = selectRow.Cells(10).Value.ToString()
        'txtba.Text = selectRow.Cells(11).Value.ToString()
        DateTimePicker1.Text = selectRow.Cells(12).Value.ToString()
        txtdatetime.Text = Today
        GetPatientTretmentDetails()
        GetPriviosBalance()
        visit()
        C_and_D()
    End Sub

    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Dim dr As Integer
        dr = e.RowIndex
        Dim selectRow As DataGridViewRow
        selectRow = DataGridView3.Rows(dr)
        txtpimasterid.Text = selectRow.Cells(1).Value
        'Serch()
        'GetPatientTretmentDetails()
        'GetPatientDetails()
        GetPatientTretmentRefresh()

    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        If lblbtn.Text = "Edit" Then
            Edit()
            lblbtn.Text = ""
        End If

        If lblbtn.Text = "Update" Then
            NewUpdate()
            lblbtn.Text = ""
            txtdatetime.Text = Today
        End If

        If lblbtn.Text = "New" Then
            NewPatient()
            lblbtn.Text = ""
            txtdatetime.Text = Today
        End If
        If lblbtn.Text = "New1" Then
            NewPatient1()
            lblbtn.Text = ""
            txtdatetime.Text = Today
        End If
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        lblbtn.Text = "Update"
        Page_Enable()
        GetPatientTretmentID()
        GetPationtTritmentDtID()
        Page_Enable()
    End Sub

    Public Sub Edit()
        Try

            If txtpatientname.Text = "" Then
                MessageBox.Show("Please select Select Patient Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtpatientname.Focus()
            End If

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update patienttritment 
                               set PatientTretmentID=@d1,PatientID=@d2,CaseOf=@d3,IMIV=@d4,CD=@d5,Visit=@d6,Advise=@d7,Report=@d8,CurrCharge=@d9,RecvAmt=@d10,BalanceAmt=@d11,VisitDate=@d12,ModifiedDateTime=@d13,IsComplet=@d14,CSession=@d15 
                               where PatientTretmentID=@d1"

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
            cmd.Parameters("@d12").Value = Trim(DateTimePicker1.Text)
            cmd.Parameters("@d13").Value = Trim(DateTimePicker1.Text)
            cmd.Parameters("@d14").Value = "No"
            cmd.Parameters("@d15").Value = Trim(txtsession.Text)
            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            'MessageBox.Show("Successfully Updated", "Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GetPatientDetails()
        fillcombo()
    End Sub

    Public Sub NewPatient()

        'Patient Detail Add
        con = New SqlConnection(cs)
        con.Open()
        Dim cb As String = "insert into patientinfomaster(PatientID,PatientName,Address,ContactNo,Age,KnownCaseOf,Allergy,ModifiedDateTime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
        cmd = New SqlCommand(cb)
        cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "PationtID"))
        cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "PatientName"))
        cmd.Parameters.Add(New SqlParameter("@d3", System.Data.SqlDbType.VarChar, 50, "Address"))
        cmd.Parameters.Add(New SqlParameter("@d4", System.Data.SqlDbType.VarChar, 50, "Age"))
        cmd.Parameters.Add(New SqlParameter("@d5", System.Data.SqlDbType.VarChar, 50, "ContactNo"))
        cmd.Parameters.Add(New SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "KnownCaseOf"))
        cmd.Parameters.Add(New SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "Allergy"))
        cmd.Parameters.Add(New SqlParameter("@d8", System.Data.SqlDbType.DateTime, 150, "ModifiedDateTime"))

        cmd.Parameters("@d1").Value = Trim(txtpimasterid.Text)
        cmd.Parameters("@d2").Value = Trim(txtpatientname.Text)
        cmd.Parameters("@d3").Value = Trim(txtaddress.Text)
        cmd.Parameters("@d4").Value = Trim(txtage.Text)
        cmd.Parameters("@d5").Value = Trim(txtcontact.Text)
        cmd.Parameters("@d6").Value = Trim(txtknown.Text)
        cmd.Parameters("@d7").Value = Trim(txtallergy.Text)
        cmd.Parameters("@d8").Value = Trim(txtdatetime.Text)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()

        'Patient Treitment Details Add
        Dim conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30")

        For j As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
            Dim cmd As New SqlCommand("insert into patienttritmentdt(DoseTypeID,MedicineID,TabletTypeID,NoofDose,NoofDays,PatientTretmentID) 
                                           VALUES ('" + DataGridView1.Rows(j).Cells(1).Value.ToString() + "', " + DataGridView1.Rows(j).Cells(3).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(5).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(7).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(8).Value.ToString() + ", " + txtptid.Text + ")", conn)
            conn.Open()
            cmd.ExecuteReader()
            conn.Close()
        Next
        cleareparamiter()

        'Patient Treatment Add

        con = New SqlConnection(cs)
        con.Open()
        Dim cb1 As String = "insert into patienttritment(PatientTretmentID,PatientID,CaseOf,IMIV,CD,Visit,Advise,Report,CurrCharge,RecvAmt,BalanceAmt,VisitDate,ModifiedDateTime,IsComplet,CSession) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
        cmd = New SqlCommand(cb1)

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
        cmd.Parameters("@d12").Value = Trim(DateTimePicker1.Text)
        cmd.Parameters("@d13").Value = Trim(DateTimePicker1.Text)
        cmd.Parameters("@d14").Value = "No"
        cmd.Parameters("@d15").Value = Trim(txtsession.Text)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()

        GetPatientDetails()
        fillcombo()
    End Sub

    Public Sub NewPatient1()

        'Patient Treitment Details Add
        Dim conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30")

        For j As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
            Dim cmd As New SqlCommand("insert into patienttritmentdt(DoseTypeID,MedicineID,TabletTypeID,NoofDose,NoofDays,PatientTretmentID) 
                                           VALUES ('" + DataGridView1.Rows(j).Cells(1).Value.ToString() + "', " + DataGridView1.Rows(j).Cells(3).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(5).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(7).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(8).Value.ToString() + ", " + txtptid.Text + ")", conn)
            conn.Open()
            cmd.ExecuteReader()
            conn.Close()
        Next
        cleareparamiter()


        'Patient Treatment Details Add'

        con = New SqlConnection(cs)
        con.Open()
        Dim cb1 As String = "insert into patienttritment(PatientTretmentID,PatientID,CaseOf,IMIV,CD,Visit,Advise,Report,CurrCharge,RecvAmt,BalanceAmt,VisitDate,ModifiedDateTime,IsComplet,CSession) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
        cmd = New SqlCommand(cb1)

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
        cmd.Parameters("@d12").Value = Trim(DateTimePicker1.Text)
        cmd.Parameters("@d13").Value = Trim(DateTimePicker1.Text)
        cmd.Parameters("@d14").Value = "No"
        cmd.Parameters("@d15").Value = Trim(txtsession.Text)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()

        GetPatientDetails()
    End Sub

    Public Sub NewUpdate()

        If txtpatientname.Text = "" Then
            MessageBox.Show("Please select Select Patient Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtpatientname.Focus()
        End If

        Try
            'Patient Treitment Details Add
            Dim conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30")

            For j As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                Dim cmd As New SqlCommand("insert into patienttritmentdt(DoseTypeID,MedicineID,TabletTypeID,NoofDose,NoofDays,PatientTretmentID) 
                                           VALUES ('" + DataGridView1.Rows(j).Cells(1).Value.ToString() + "', " + DataGridView1.Rows(j).Cells(3).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(5).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(7).Value.ToString() + ", " + DataGridView1.Rows(j).Cells(8).Value.ToString() + ", " + txtptid.Text + ")", conn)
                conn.Open()
                cmd.ExecuteReader()
                conn.Close()
            Next
            cleareparamiter()
        Catch ex As Exception

        End Try



        'Add Patient Tretment
        con = New SqlConnection(cs)
        con.Open()
        Dim cb1 As String = "insert into patienttritment(PatientTretmentID,PatientID,CaseOf,IMIV,CD,Visit,Advise,Report,CurrCharge,RecvAmt,BalanceAmt,VisitDate,ModifiedDateTime,IsComplet,CSession) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
        cmd = New SqlCommand(cb1)

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
        cmd.Parameters("@d12").Value = Trim(DateTimePicker1.Text)
        cmd.Parameters("@d13").Value = Trim(DateTimePicker1.Text)
        cmd.Parameters("@d14").Value = "No"
        cmd.Parameters("@d15").Value = Trim(txtsession.Text)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()

        GetPatientDetails()
    End Sub

    Private Sub btndelet_Click(sender As Object, e As EventArgs) Handles btndelet.Click
        Try

            If txtptid.Text = "" Then
                MessageBox.Show("Please Select Patient Detail", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtptdtlid.Focus()
                Exit Sub
            End If
            If txtptid.Text.Count > 0 Then
                If MsgBox("Do you really want To delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    Remove_records()
                    Delete_records()

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GetPatientDetails()
        fillcombo()

        txtcoex.Text = ""
        txtimiv.Text = ""
        txtadvise.Text = ""
        txtreport.Text = ""
        txtpb.Text = ""
        txtcc.Text = ""
        txtra.Text = ""
        txtba.Text = ""
        DateTimePicker1.Text = ""
        DataGridView1.Rows.Clear()

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

            Dim cc As String = "delete from patienttritmentdt where PatientTretmentID=@DELETE1;"
            cmd = New SqlCommand(cc)
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

    Private Sub txttt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txttt.SelectedIndexChanged
        FillTreatmentTypeID()
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

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

            If txtpatientname.Text = "" Then
                MessageBox.Show("Please select Select Patient Name", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtpatientname.Focus()
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "update patienttritment 
                                set PatientTretmentID=@d1,PatientID=@d2,CaseOf=@d3,IMIV=@d4,CD=@d5,Visit=@d6,Advise=@d7,Report=@d8,CurrCharge=@d9,RecvAmt=@d10,BalanceAmt=@d11,VisitDate=@d12,ModifiedDateTime=@d13,IsComplet=@d14,CSession=@d15 
                                where PatientTretmentID=@d1"

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
            cmd.Parameters("@d12").Value = Trim(DateTimePicker1.Text)
            cmd.Parameters("@d13").Value = Trim(DateTimePicker1.Text)
            cmd.Parameters("@d14").Value = "Yes"
            cmd.Parameters("@d15").Value = Trim(txtsession.Text)
            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If


            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GetPatientDetails()
        Load_InComplet()
        fillcombo()

    End Sub

    Private Sub txtvisitid_TextChanged(sender As Object, e As EventArgs) Handles txtvisitid.TextChanged

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox3.Checked = True Then

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select TabletType from tablettypemaster 
                                where TabletType=@find"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "TabletType"))
            cmd.Parameters("@find").Value = txtmedicine.Text
            rdr = cmd.ExecuteReader()
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into tablettypemaster(TabletTypeID,TabletType) 
                                VALUES (@d1,@d2)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineName"))
            cmd.Parameters("@d1").Value = Trim(txttbletid.Text)
            cmd.Parameters("@d2").Value = Trim(txttype.Text)
            cmd.ExecuteReader()

            MessageBox.Show("Successfully Save", "Medicine Details", MessageBoxButtons.OK, MessageBoxIcon.Information)

            fillcombo()
            con.Close()
        End If

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox2.Checked = True Then

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select MedicineName from medicinemaster 
                                where MedicineName=@find"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "MedicineName"))
            cmd.Parameters("@find").Value = txtmedicine.Text
            rdr = cmd.ExecuteReader()
            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into medicinemaster(MedicineID,MedicineName) 
                                VALUES (@d1,@d2)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@d1", System.Data.SqlDbType.VarChar, 50, "MedicineID"))
            cmd.Parameters.Add(New SqlParameter("@d2", System.Data.SqlDbType.VarChar, 50, "MedicineName"))
            cmd.Parameters("@d1").Value = Trim(txtmid.Text)
            cmd.Parameters("@d2").Value = Trim(txtmedicine.Text)
            cmd.ExecuteReader()

            MessageBox.Show("Successfully Save", "Medicine Details", MessageBoxButtons.OK, MessageBoxIcon.Information)


            fillcombo()
            con.Close()
        End If
    End Sub

    Private Sub txttype_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles txttype.SelectedIndexChanged

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

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Page_Disble()
        txtpnserch.Text = ""
        txtp_nameserch.Text = ""
        Page_Cleare()
        'DataGridView1.Rows.Clear()
        ' DataGridView2.Rows.Clear()
        ' DataGridView3.Rows.Clear()
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        lblbtn.Text = "Edit"
        Page_Enable()
    End Sub

    Private Sub btnpatientadd_Click_1(sender As Object, e As EventArgs) Handles btnpatientadd.Click
        lblbtn.Text = "New"
        GetPatientTretmentID()
        GetPationtTritmentDtID()
        GetPatientID()
        Page_Enable()
        Page_Enable()
        Page_Cleare()
    End Sub

    Private Sub txtra_TextChanged(sender As Object, e As EventArgs) Handles txtra.TextChanged
        txtba.Text = Val(txtpb.Text) + Val(txtcc.Text) - Val(txtra.Text)
    End Sub

    Private Sub txtpnserch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpnserch.TextChanged
        Dim cs As New SqlConnection
        cs.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"
        cs.Open()

        Dim ct As String = "select PatientID, PatientName, Address, ContactNo, Age, KnownCaseOf, Allergy, ModifiedDateTime from patientinfomaster where PatientName='" + txtpnserch.Text + "'"

        Dim cmd As New SqlCommand(ct, cs)
        Dim myreder As SqlDataReader
        myreder = cmd.ExecuteReader
        'myreder.Read()
        If myreder.Read Then
            txtpimasterid.Text = myreder("PatientID")
            txtp_nameserch.Text = myreder("PatientName")
            txtpatientname.Text = myreder("PatientName")
            txtaddress.Text = myreder("Address")
            txtcontact.Text = myreder("ContactNo")
            txtage.Text = myreder("Age")
            txtknown.Text = myreder("KnownCaseOf")
            txtallergy.Text = myreder("Allergy")
            txtdatetime.Text = myreder("ModifiedDateTime")
        End If
        cs.Close()
        GetPatientDetails()
        GetPriviosBalance()
    End Sub

    Sub cleareparamiter()
        txtptdtlid.Text = ""
        DataGridView1.Rows.Clear()
        txtptdtlid.Focus()

    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
        Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = (e.RowIndex + 1).ToString()
    End Sub

End Class