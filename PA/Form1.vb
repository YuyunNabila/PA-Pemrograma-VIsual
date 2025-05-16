Imports System.Runtime.InteropServices

Public Class Form1
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

        
        AnimateWindow(Me.Handle, 300, AW_BLEND Or AW_HIDE)
        targetForm.Show()
        AnimateWindow(targetForm.Handle, 300, AW_BLEND Or AW_ACTIVATE)
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        StyleButton(btnLogin)
        StyleButton(btnRegister)
    End Sub

    Private Sub StyleButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(190, 204, 152) ' Hijau pastel
        btn.ForeColor = Color.Black
        btn.Font = New Font("Lucida Bright", 15, FontStyle.Regular)

        ' Atur ukuran tombol di sini
        btn.Width = 120
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

        AddHandler btn.MouseEnter, AddressOf Button_Hover
        AddHandler btn.MouseLeave, AddressOf Button_Normal
    End Sub


    Private Sub Button_Hover(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(167, 108, 95) ' Merah pastel
    End Sub

    Private Sub Button_Normal(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(190, 204, 152) ' Hijau pastel lagi
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        AnimateTransition(Form2)
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        AnimateTransition(Form3)
    End Sub
End Class
