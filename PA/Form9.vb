Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient
Imports PA.Form2
Imports System.IO

Public Class Form9
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

    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=bunga_db;")

    Public Class Pesanan
        Public Property PesananId As Integer
        Public Property UserId As Integer
        Public Property BungaId As Integer
        Public Property NamaBunga As String
        Public Property Jumlah As Integer
        Public Property TotalHarga As Decimal
        Public Property TanggalPesan As DateTime
        Public Property Status As String
        Public Property GambarPath As String
    End Class

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)

        ' Cek session
        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AnimateTransition(Form1)
            Return
        End If

        ' Setup UI
        pnlSidebar.BackColor = Color.FromArgb(228, 228, 210)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Width = 200

        ' Styling tombol menu
        Dim tombolMenu() As Button = {btnTambahBunga, btnDaftarPesanan, btnRiwayat, btnLogout}
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

        ' Setup FlowLayoutPanel
        With flpPesanan
            .AutoScroll = True
            .WrapContents = True
        End With

        LoadDataPesanan()
    End Sub

    Private Sub txtPencarian_TextChanged(sender As Object, e As EventArgs) Handles txtPencarian.TextChanged
        FilterPesanan(txtPencarian.Text)
    End Sub

    Private Sub FilterPesanan(keyword As String)
        keyword = keyword.ToLower().Trim()
        Dim hasVisiblePanel As Boolean = False

        ' Loop hanya pada kontrol bertipe Panel
        For Each ctrl As Control In flpPesanan.Controls
            If TypeOf ctrl Is Panel Then
                Dim panel As Panel = DirectCast(ctrl, Panel)
                ' Cek apakah nama bunga di Tag panel mengandung keyword
                If panel.Tag IsNot Nothing Then
                    panel.Visible = panel.Tag.ToString().ToLower().Contains(keyword)
                    If panel.Visible Then hasVisiblePanel = True
                End If
            End If
        Next

        ' Kelola pesan "tidak ditemukan"
        Dim lblNotFound As Label = Nothing

        ' Cari label notifikasi yang sudah ada
        For Each ctrl As Control In flpPesanan.Controls
            If TypeOf ctrl Is Label AndAlso ctrl.Text.StartsWith("Tidak ditemukan") Then
                lblNotFound = DirectCast(ctrl, Label)
                Exit For
            End If
        Next

        If keyword <> "" AndAlso Not hasVisiblePanel Then
            If lblNotFound Is Nothing Then
                lblNotFound = New Label()
                lblNotFound.Text = $"Tidak ditemukan pesanan dengan nama bunga '{keyword}'"
                lblNotFound.Font = New Font("Arial", 12, FontStyle.Italic)
                lblNotFound.ForeColor = Color.Gray
                lblNotFound.AutoSize = True
                flpPesanan.Controls.Add(lblNotFound)
            End If
        ElseIf lblNotFound IsNot Nothing Then
            flpPesanan.Controls.Remove(lblNotFound)
            lblNotFound.Dispose()
        End If
    End Sub


    Private Sub LoadDataPesanan()
        flpPesanan.Controls.Clear()

        Try
            BukaKoneksi()

            Dim query As String = "SELECT td.transaksi_detail_id, t.user_id, u.nama AS nama_user, " &
                          "td.bunga_id, b.nama AS nama_bunga, td.jumlah, td.harga_satuan, " &
                          "td.subtotal, t.tanggal, td.status, b.gambar " &
                          "FROM transaksi_detail td " &
                          "JOIN bunga b ON td.bunga_id = b.bunga_id " &
                          "JOIN transaksi t ON td.transaksi_id = t.transaksi_id " &
                          "JOIN user u ON t.user_id = u.user_id " &
                          "WHERE td.status = 'Menunggu' " &
                          "ORDER BY t.tanggal DESC"

            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            Dim recordCount As Integer = 0

            While reader.Read()
                recordCount += 1

                Dim pesanan As New Pesanan With {
                .PesananId = reader.GetInt32("transaksi_detail_id"),
                .UserId = reader.GetInt32("user_id"),
                .BungaId = reader.GetInt32("bunga_id"),
                .NamaBunga = reader.GetString("nama_bunga"),
                .Jumlah = reader.GetInt32("jumlah"),
                .TotalHarga = reader.GetDecimal("subtotal"),
                .TanggalPesan = reader.GetDateTime("tanggal"),
                .Status = reader.GetString("status"),
                .GambarPath = If(reader.IsDBNull(reader.GetOrdinal("gambar")),
                               Path.Combine(Application.StartupPath, "default_flower.png"),
                               reader.GetString("gambar"))
            }

                Dim namaUser As String = reader.GetString("nama_user")
                CreatePesananCardAdmin(pesanan, namaUser)
            End While

            If recordCount = 0 Then
                Dim lblEmpty As New Label()
                lblEmpty.Text = "Tidak ada pesanan yang sedang menunggu persetujuan"
                lblEmpty.Font = New Font("Arial", 12, FontStyle.Italic)
                lblEmpty.ForeColor = Color.Gray
                lblEmpty.AutoSize = True
                flpPesanan.Controls.Add(lblEmpty)
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pesanan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try

        ' Terapkan filter jika ada teks di txtPencarian
        If txtPencarian.Text <> "" Then
            FilterPesanan(txtPencarian.Text)
        End If
    End Sub

    ' Versi CreatePesananCardAdmin tanpa parameter username
    Private Sub CreatePesananCardAdmin(pesanan As Pesanan, namaUser As String)
        Dim cardPanel As New Panel()
        With cardPanel
            .Width = 500
            .Height = 160
            .BackColor = Color.FromArgb(228, 228, 210)
            .Margin = New Padding(15)
            .Padding = New Padding(15)
            .BorderStyle = BorderStyle.FixedSingle
            .Tag = $"{namaUser.ToLower()} {pesanan.NamaBunga.ToLower()}"
        End With

        ' Gambar bunga
        Dim picBox As New PictureBox()
        With picBox
            .Width = 125
            .Height = 125
            .Top = 15
            .Left = 15
            .SizeMode = PictureBoxSizeMode.Zoom
            Try
                If File.Exists(pesanan.GambarPath) Then
                    .Image = Image.FromFile(pesanan.GambarPath)
                Else
                    .Image = Image.FromFile(Path.Combine(Application.StartupPath, "default_flower.png"))
                End If
            Catch ex As Exception
                .Image = CreateDefaultImage(120, 120)
            End Try
        End With

        ' Informasi pesanan
        Dim lblInfo As New Label()
        With lblInfo
            .Text = $"Pemesan: {namaUser}" & vbCrLf &
                $"ID Pesanan: {pesanan.PesananId}" & vbCrLf &
                $"Bunga: {pesanan.NamaBunga}" & vbCrLf &
                $"Jumlah: {pesanan.Jumlah}" & vbCrLf &
                $"Harga Satuan: Rp{pesanan.TotalHarga / pesanan.Jumlah:N0}" & vbCrLf &
                $"Total: Rp{pesanan.TotalHarga:N0}" & vbCrLf &
                $"Tanggal: {pesanan.TanggalPesan.ToString("dd/MM/yyyy HH:mm")}"
            .Font = New Font("Bell MT", 10)
            .Top = 15
            .Left = 150
            .AutoSize = True
            .ForeColor = Color.FromArgb(64, 64, 64)
            .MaximumSize = New Size(280, 0)
        End With

        ' Tombol Setujui
        Dim btnSetujui As New Button()
        With btnSetujui
            .Text = "Selesaikan"
            .Tag = pesanan.PesananId
            .BackColor = Color.FromArgb(76, 175, 80) ' Hijau
            .ForeColor = Color.White
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .Font = New Font("Bell MT", 10, FontStyle.Bold)
            .Width = 110
            .Height = 35
            .Top = 60
            .Left = 380
            .Cursor = Cursors.Hand
            AddHandler .Click, AddressOf btnSetujui_Click
        End With



        cardPanel.Controls.Add(picBox)
        cardPanel.Controls.Add(lblInfo)
        cardPanel.Controls.Add(btnSetujui)


        flpPesanan.Controls.Add(cardPanel)
    End Sub

    Private Sub btnSetujui_Click(sender As Object, e As EventArgs)
        Dim transaksiDetailId As Integer = CInt(CType(sender, Button).Tag)

        Try
            conn.Open()

            ' Update kedua tabel sekaligus
            Dim cmd As New MySqlCommand(
            "UPDATE transaksi_detail td " &
            "JOIN transaksi t ON td.transaksi_id = t.transaksi_id " &
            "SET td.status = 'Diselesaikan', t.status = 'Diselesaikan' " &
            "WHERE td.transaksi_detail_id = @id", conn)
            cmd.Parameters.AddWithValue("@id", transaksiDetailId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Pesanan disetujui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataPesanan() ' Refresh data
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function CreateDefaultImage(width As Integer, height As Integer) As Image
        Dim bmp As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.LightGray)
            Using font As New Font("Arial", 8)
                Dim yPos As Single = CSng(height / 2 - 10)
                g.DrawString("Gambar Tidak Tersedia", font, Brushes.DarkGray, 5, yPos)
            End Using
        End Using
        Return bmp
    End Function

    Private Sub BukaKoneksi()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                Debug.WriteLine("Koneksi database berhasil dibuka")
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal membuka koneksi: " & ex.Message)
            Debug.WriteLine("Error opening connection: " & ex.Message)
        End Try
    End Sub

    Private Sub TutupKoneksi()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
                Debug.WriteLine("Koneksi database berhasil ditutup")
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menutup koneksi: " & ex.Message)
            Debug.WriteLine("Error closing connection: " & ex.Message)
        End Try
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        SessionManager.UserID = 0
        SessionManager.Username = ""
        SessionManager.TipeUser = ""

        MessageBox.Show("Anda telah berhasil logout.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AnimateTransition(Form1)
    End Sub

    Private Sub btnTambahBunga_Click(sender As Object, e As EventArgs) Handles btnTambahBunga.Click
        AnimateTransition(Form4)
    End Sub

    Private Sub Button_Hover(sender As Object, e As EventArgs) Handles _
    btnTambahBunga.MouseEnter, btnDaftarPesanan.MouseEnter, btnRiwayat.MouseEnter, btnLogout.MouseEnter

        CType(sender, Button).BackColor = Color.FromArgb(192, 202, 164)
    End Sub

    Private Sub Button_Leave(sender As Object, e As EventArgs) Handles _
    btnTambahBunga.MouseLeave, btnDaftarPesanan.MouseLeave, btnRiwayat.MouseLeave, btnLogout.MouseLeave

        CType(sender, Button).BackColor = Color.Transparent
    End Sub

    Private Sub btnRiwayat_Click(sender As Object, e As EventArgs) Handles btnRiwayat.Click
        Dim formRiwayat As New Form10()
        formRiwayat.Show()
        Me.Hide()
    End Sub

End Class