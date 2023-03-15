Imports System.Data.SqlClient
Imports System.Data


Public Class Daily_Visited_Patient
    Dim rdr As SqlDataReader = Nothing
    Dim dtable As DataTable
    Dim con As SqlConnection = Nothing
    Dim adp As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30"
    Private dgw As Object

    Private Sub Daily_Visited_Patient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSession()
    End Sub

    Sub Reset()
        DateFrom.Text = Today
        DateTo.Text = Today
        txtsession.Text = ""
        txtra.Text = ""
        txtba.Text = ""
    End Sub
    Public Sub GetSession()
        If txtsession.Text = "Morning" Then
            txtsid.Text = "M"
        ElseIf txtsession.Text = "Evening" Then
            txtsid.Text = "E"
        ElseIf txtsession.Text = "All" Then
            txtsid.Text = ""
        End If
    End Sub

    Public Sub Getdata()
        '    Try
        '        con = New SqlConnection(cs)
        '        con.Open()
        '        cmd = New SqlCommand("SELECT RTRIM(PatientTretmentID),RTRIM(patientinfomaster.PatientID),RTRIM(PatientName),RTRIM(CurrCharge),RTRIM(RecvAmt),RTRIM(BalanceAmt),RTRIM(VisitDate) from patienttritment, patientinfomaster where patienttritment.PatientID=patientinfomaster.PatientID, CSession ='" + txtsid.Text + "' and VisitDate between @date1 and @date2 order by PatientName", con)
        '        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '        dwg.Rows.Clear()
        '        While (rdr.Read() = True)
        '            dwg.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
        '        End While
        '        con.Close()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
    End Sub
    Public Function GrandTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.dwg.Rows
                sum = sum + r.Cells(4).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Public Function TotalAmount() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.dwg.Rows
                sum = sum + r.Cells(5).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Private Sub NewRecord_Click(sender As Object, e As EventArgs) Handles NewRecord.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(PatientTretmentID),RTRIM(patientinfomaster.PatientID),RTRIM(PatientName),RTRIM(CurrCharge),RTRIM(RecvAmt),RTRIM(BalanceAmt),RTRIM(VisitDate) from patienttritment, patientinfomaster where patienttritment.PatientID=patientinfomaster.PatientID and VisitDate between @date1 and @date2 and CSession ='" + txtsid.Text + "' order by PatientName", con)
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "VisitDate").Value = DateFrom.Value.Date
            cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "VisitDate").Value = DateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dwg.Rows.Clear()
            While (rdr.Read() = True)
                dwg.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            con.Close()

            Dim j As Double = 0
            j = GrandTotal()
            j = Math.Round(j, 2)
            txtra.Text = j

            Dim i As Double = 0
            i = TotalAmount()
            i = Math.Round(i, 2)
            txtba.Text = i

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Home.Show()
    End Sub

    Private Sub dwg_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dwg.CellFormatting
        dwg.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub txtsession_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtsession.SelectedIndexChanged
        GetSession()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(PatientTretmentID),RTRIM(patientinfomaster.PatientID),RTRIM(PatientName),RTRIM(CurrCharge),RTRIM(RecvAmt),RTRIM(BalanceAmt),RTRIM(VisitDate),RTRIM(CSession) 
                                 from patienttritment, patientinfomaster 
                                 where patienttritment.PatientID=patientinfomaster.PatientID and VisitDate 
                                 between @date1 and @date2 order by PatientName", con)
            cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "VisitDate").Value = DateFrom.Value.Date
            cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "VisitDate").Value = DateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dwg.Rows.Clear()
            While (rdr.Read() = True)
                dwg.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            con.Close()

            Dim j As Double = 0
            j = GrandTotal()
            j = Math.Round(j, 2)
            txtra.Text = j

            Dim i As Double = 0
            i = TotalAmount()
            i = Math.Round(i, 2)
            txtba.Text = i

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class