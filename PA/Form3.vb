Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Form3
    Private conn As New MySqlConnection("server=localhost;user id=root;password=;database=bunga_db")

    Dim isDragging As Boolean = False
    Dim offset As Point

    Private Sub Form_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            offset = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Form_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If isDragging Then
            Me.Location = New Point(Me.Left + e.X - offset.X, Me.Top + e.Y - offset.Y)
        End If
    End Sub

    Private Sub Form_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        isDragging = False
    End Sub

    <DllImport("user32.dll")>
    Private Shared Function AnimateWindow(ByVal hwnd As IntPtr, ByVal dwTime As Integer, ByVal dwFlags As Integer) As Boolean
    End Function

    Private Const AW_BLEND As Integer = &H80000
    Private Const AW_HIDE As Integer = &H10000
    Private Const AW_ACTIVATE As Integer = &H20000

    Private Sub AnimateTransition(targetForm As Form)
        ' Menentukan posisi tengah layar
        targetForm.StartPosition = FormStartPosition.Manual
        targetForm.Location = New Point(
        (Screen.PrimaryScreen.WorkingArea.Width - targetForm.Width) \ 2,
        (Screen.PrimaryScreen.WorkingArea.Height - targetForm.Height) \ 2
    )

        ' Animasi transisi
        AnimateWindow(Me.Handle, 300, AW_BLEND Or AW_HIDE)
        targetForm.Show()
        AnimateWindow(targetForm.Handle, 300, AW_BLEND Or AW_ACTIVATE)
        Me.Hide()
    End Sub


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        StyleButton(btnRegistrasi)
        StyleButton(btnBatal)
    End Sub

    Private Sub StyleButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(190, 204, 152)
        btn.ForeColor = Color.Black
        btn.Font = New Font("Lucida Bright", 15, FontStyle.Regular)
        btn.Width = 120
        btn.Height = 45

        Dim path As New Drawing2D.GraphicsPath()
        Dim radius As Integer = 20

        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddLine(radius, 0, btn.Width - radius, 0)
        path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90)
        path.AddLine(btn.Width, radius, btn.Width, btn.Height - radius)
        path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90)
        path.AddLine(btn.Width - radius, btn.Height, radius, btn.Height)
        path.AddArc(0, btn.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()

        btn.Region = New Region(path)

        AddHandler btn.MouseEnter, AddressOf Button_Hover
        AddHandler btn.MouseLeave, AddressOf Button_Normal
    End Sub

    Private Sub Button_Hover(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(167, 108, 95)
    End Sub

    Private Sub Button_Normal(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(190, 204, 152)
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        AnimateTransition(Form1)
    End Sub

    Private Sub btnRegistrasi_Click(sender As Object, e As EventArgs) Handles btnRegistrasi.Click
        Dim nama As String = txtNama.Text.Trim()
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim konfirmasi As String = txtKonfirmasi.Text.Trim()
        Dim alamat As String = txtAlamat.Text.Trim()
        Dim noTelp As String = txtNoTelpon.Text.Trim()

        If nama = "" Or username = "" Or password = "" Or konfirmasi = "" Or alamat = "" Or noTelp = "" Then
            MessageBox.Show("Semua field harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If password <> konfirmasi Then
            MessageBox.Show("Password dan konfirmasi tidak cocok.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM user WHERE username = @username", conn)
            checkCmd.Parameters.AddWithValue("@username", username)
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If count > 0 Then
                MessageBox.Show("Username sudah digunakan, pilih username lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New MySqlCommand("INSERT INTO user (nama, username, password, alamat, no_telpon) VALUES (@nama, @username, @password, @alamat, @noTelp)", conn)
            cmd.Parameters.AddWithValue("@nama", nama)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            cmd.Parameters.AddWithValue("@alamat", alamat)
            cmd.Parameters.AddWithValue("@noTelp", noTelp)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Registrasi berhasil! Silakan login.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            conn.Close()

            AnimateTransition(Form1)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat registrasi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

End Class
