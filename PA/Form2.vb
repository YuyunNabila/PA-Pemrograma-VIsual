
Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Form2
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=bunga_db")

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




    Private Sub StyleButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(190, 204, 152) ' Hijau pastel
        btn.ForeColor = Color.Black
        btn.Font = New Font("Lucida Bright", 15, FontStyle.Regular)

        ' Atur ukuran tombol di sini
        btn.Width = 105
        btn.Height = 45

        ' Buat rounded rectangle
        Dim path As New Drawing2D.GraphicsPath()
        Dim radius As Integer = 20 ' Seberapa lengkung sudut

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

        ' Tambah event hover
        AddHandler btn.MouseEnter, AddressOf Button_Hover
        AddHandler btn.MouseLeave, AddressOf Button_Normal
    End Sub


    ' Saat hover (masuk)
    Private Sub Button_Hover(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(167, 108, 95) ' Merah pastel
    End Sub

    ' Saat hover keluar (normal lagi)
    Private Sub Button_Normal(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(190, 204, 152) ' Hijau pastel lagi
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        AnimateTransition(Form1)

    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            ' Tampilkan teks asli
            txtPassword.PasswordChar = ChrW(0)
        Else
            ' Sembunyikan dengan karakter bulat
            txtPassword.PasswordChar = "●"c
        End If
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If username = "" Or password = "" Then
            MessageBox.Show("Username dan Password tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Periksa apakah username dan password cocok, dan ambil user_id serta tipe pengguna
            Dim cmd As New MySqlCommand("SELECT user_id, tipe FROM user WHERE username = @username AND password = @password", conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then

                reader.Read()
                Dim user_id As Integer = reader.GetInt32("user_id")
                Dim tipeUser As String = reader.GetString("tipe")



                SessionManager.UserID = user_id ' Simpan user_id yang valid
                SessionManager.Username = username ' Simpan username
                SessionManager.TipeUser = tipeUser ' Simpan tipe user


                If tipeUser = "user" Then

                    AnimateTransition(Form5)
                ElseIf tipeUser = "admin" Then

                    AnimateTransition(Form4)
                Else
                    MessageBox.Show("Tipe pengguna tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Username atau Password salah.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat login: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        StyleButton(btnLogin)
        StyleButton(btnBatal)
    End Sub

    Public Class SessionManager
        Public Shared UserID As Integer
        Public Shared Username As String
        Public Shared TipeUser As String
    End Class



End Class