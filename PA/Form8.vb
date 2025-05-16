Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient
Imports PA.Form2

Public Class Form8
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=bunga_db")
    Dim isDragging As Boolean = False
    Dim offset As Point

    <DllImport("user32.dll")>
    Private Shared Function AnimateWindow(ByVal hwnd As IntPtr, ByVal dwTime As Integer, ByVal dwFlags As Integer) As Boolean
    End Function

    Private Const AW_BLEND As Integer = &H80000
    Private Const AW_HIDE As Integer = &H10000
    Private Const AW_ACTIVATE As Integer = &H20000

    Public Shared Sub BukaFormRiwayat()
        Dim formRiwayat As New Form8()
        formRiwayat.StartPosition = FormStartPosition.Manual
        formRiwayat.Location = New Point(
            (Screen.PrimaryScreen.WorkingArea.Width - formRiwayat.Width) \ 2,
            (Screen.PrimaryScreen.WorkingArea.Height - formRiwayat.Height) \ 2
        )
        formRiwayat.Show()
    End Sub

    Private Sub Form_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            offset = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Button_Hover(sender As Object, e As EventArgs) Handles _
        btnDaftarBunga.MouseEnter, btnKeranjang.MouseEnter, btnRiwayatUser.MouseEnter, btnLogout.MouseEnter
        CType(sender, Button).BackColor = Color.FromArgb(192, 202, 164)
    End Sub

    Private Sub Button_Leave(sender As Object, e As EventArgs) Handles _
        btnDaftarBunga.MouseLeave, btnKeranjang.MouseLeave, btnRiwayatUser.MouseLeave, btnLogout.MouseLeave
        CType(sender, Button).BackColor = Color.Transparent
    End Sub

    Private Sub Form_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If isDragging Then
            Me.Location = New Point(Me.Left + e.X - offset.X, Me.Top + e.Y - offset.Y)
        End If
    End Sub

    Private Sub Form_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        isDragging = False
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If

        pnlSidebar.BackColor = Color.FromArgb(228, 228, 210)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Width = 200

        With flpRiwayat
            .AutoScroll = True
            .BackColor = Color.FromArgb(228, 228, 210)
            .BorderStyle = BorderStyle.None
            .WrapContents = False
            .FlowDirection = FlowDirection.TopDown
        End With

        Dim tombolMenu() As Button = {btnDaftarBunga, btnKeranjang, btnRiwayatUser, btnLogout}
        For Each btn In tombolMenu
            btn.ForeColor = Color.FromArgb(40, 40, 40)
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.BackColor = Color.Transparent
            btn.TextAlign = ContentAlignment.MiddleLeft
            btn.Padding = New Padding(10, 5, 0, 5)
            btn.Width = pnlSidebar.Width
            btn.Height = 40
            btn.Cursor = Cursors.Hand
        Next

        LoadRiwayatTransaksi()
    End Sub

    Private Sub LoadRiwayatTransaksi()
        flpRiwayat.Controls.Clear()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT t.transaksi_id, t.tanggal, t.resi, t.total_harga, t.status " &
                                  "FROM transaksi t " &
                                  "WHERE t.user_id = @user_id " &
                                  "ORDER BY t.tanggal DESC"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@user_id", SessionManager.UserID)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim panel As New Panel With {
                        .Width = flpRiwayat.Width - 30,
                        .Height = 120, ' Diperkecil karena tidak ada tombol detail
                        .BackColor = Color.Transparent,
                        .Margin = New Padding(10),
                        .BorderStyle = BorderStyle.FixedSingle
                    }

                    Dim lblTanggal As New Label With {
                        .Text = "Tanggal: " & Convert.ToDateTime(reader("tanggal")).ToString("dd/MM/yyyy HH:mm"),
                        .Font = New Font("Bell MT", 10, FontStyle.Bold),
                        .Top = 10,
                        .Left = 10,
                        .AutoSize = True
                    }
                    panel.Controls.Add(lblTanggal)

                    Dim lblResi As New Label With {
                        .Text = "No. Resi: " & If(reader("resi") Is DBNull.Value, "-", reader("resi").ToString()),
                        .Font = New Font("Bell MT", 9),
                        .Top = lblTanggal.Bottom + 5,
                        .Left = 10,
                        .AutoSize = True
                    }
                    panel.Controls.Add(lblResi)

                    Dim lblTotal As New Label With {
                        .Text = "Total: Rp " & Convert.ToDecimal(reader("total_harga")).ToString("N2"),
                        .Font = New Font("Bell MT", 9),
                        .Top = lblResi.Bottom + 5,
                        .Left = 10,
                        .AutoSize = True
                    }
                    panel.Controls.Add(lblTotal)

                    Dim lblStatus As New Label With {
                        .Text = "Status: " & If(reader("status") Is DBNull.Value, "-", reader("status").ToString()),
                        .Font = New Font("Bell MT", 9, FontStyle.Bold),
                        .Top = lblTotal.Bottom + 5,
                        .Left = 10,
                        .AutoSize = True
                    }

                    If reader("status") IsNot DBNull.Value Then
                        Select Case reader("status").ToString().ToLower()
                            Case "pending"
                                lblStatus.ForeColor = Color.Orange
                            Case "completed", "dikirim"
                                lblStatus.ForeColor = Color.Green
                            Case "canceled", "dibatalkan"
                                lblStatus.ForeColor = Color.Red
                        End Select
                    End If

                    panel.Controls.Add(lblStatus)

                    flpRiwayat.Controls.Add(panel)
                End While
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat transaksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnKeranjang_Click(sender As Object, e As EventArgs) Handles btnKeranjang.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub btnDaftarBunga_Click(sender As Object, e As EventArgs) Handles btnDaftarBunga.Click
        Form5.Show()
        Me.Close()
    End Sub

    Private Sub AnimateTransition(targetForm As Form)
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

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        SessionManager.UserID = 0
        SessionManager.Username = ""
        SessionManager.TipeUser = ""

        MessageBox.Show("Anda telah berhasil logout.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AnimateTransition(Form1)
    End Sub
End Class
