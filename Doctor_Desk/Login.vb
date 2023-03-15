Imports System.Data.SqlClient
Public Class Login


    Private Sub Login_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub



    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 

    End Sub

    Private Sub txtPwd_TextChanged(sender As Object, e As EventArgs) Handles txtPwd.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btncancel_Click_1(sender As Object, e As EventArgs) Handles btncancel.Click
        End
    End Sub

    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Len(Trim(txtUser.Text)) = 0 Then
            MessageBox.Show("Please enter User Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUser.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPwd.Text)) = 0 Then
            MessageBox.Show("Please enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPwd.Focus()
            Exit Sub
        End If
        Try
            Dim myConnection As SqlConnection
            myConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Doctor_Desk\doctors_desk.mdf;Integrated Security=True;Connect Timeout=30")

            Dim myCommand As SqlCommand

            myCommand = New SqlCommand("SELECT LoginName, Password FROM loginmaster WHERE LoginName = @User AND Password = @Password", myConnection)

            Dim uName As New SqlParameter("@User", SqlDbType.NChar)

            Dim uPassword As New SqlParameter("@Password", SqlDbType.NChar)

            uName.Value = txtUser.Text

            uPassword.Value = txtPwd.Text

            myCommand.Parameters.Add(uName)

            myCommand.Parameters.Add(uPassword)

            myCommand.Connection.Open()

            Dim myReader As SqlDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            Dim Login As Object = 0

            If myReader.HasRows Then

                myReader.Read()

                Login = myReader(Login)

            End If

            If Login = Nothing Then

                MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
                txtUser.Clear()
                txtPwd.Clear()
                txtUser.Focus()

            Else
                Me.Hide()
                Home.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
