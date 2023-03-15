Imports System.Data.SqlClient
Imports System.Data
Public Class Sen_Handicaped_Certificate
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Hide()
        Home.Show()
    End Sub

    Private Sub Sen_Handicaped_Certificate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillcombo()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        ' Display the date as "22 Feb 2001".
        DateTimePicker1.CustomFormat = "dd-MMM-yyyy"
    End Sub

    Sub fillcombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct  RTRIM(UserName) FROM usermaster", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtdname.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                txtdname.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub NewRecord_Click(sender As Object, e As EventArgs) Handles NewRecord.Click
        Dim rpt As New Report_SCH 'The report you created.
        rpt.SetParameterValue("p1", txtpname.Text)
        rpt.SetParameterValue("p2", txtbankname.Text)
        rpt.SetParameterValue("p3", txtrelation.Text)
        rpt.SetParameterValue("p4", txtrname.Text)
        rpt.SetParameterValue("p5", txtdname.Text)
        rpt.SetParameterValue("p6", txtquali.Text)
        rpt.SetParameterValue("p7", txtreg.Text)
        rpt.SetParameterValue("p8", txtadd.Text)
        rpt.SetParameterValue("p9", txtmob.Text)
        ReportView.CrystalReportViewer1.ReportSource = rpt
        ReportView.ShowDialog()
    End Sub

    Private Sub txtdname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtdname.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from usermaster where UserName=@name"

            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "UserName"))
            cmd.Parameters("@name").Value = Trim(txtdname.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                txtquali.Text = Trim(rdr.GetValue(2))
                txtreg.Text = Trim(rdr.GetValue(3))
                txtadd.Text = Trim(rdr.GetValue(4))
                txtmob.Text = Trim(rdr.GetValue(6))
            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class