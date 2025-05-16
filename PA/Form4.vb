Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient
Imports PA.Form2

Public Class Form4


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



    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=bunga_db;")


    Private Sub LoadDataBunga()
        daftarBunga.Clear()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM bunga", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim bunga As New Bunga With {
                .BungaId = CInt(reader("bunga_id")),
                .Nama = reader("nama").ToString(),
                .Stok = CInt(reader("stok")),
                .GambarPath = reader("gambar").ToString(),
                .Harga = CDec(reader("harga")) ' Tambahkan harga
            }
                daftarBunga.Add(bunga)
            End While
            reader.Close()
            conn.Close()

            RefreshGrid()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message)
        End Try
    End Sub



    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)

        Dim user_id As Integer = SessionManager.UserID
        Dim username As String = SessionManager.Username
        Dim tipeUser As String = SessionManager.TipeUser

        ' Cek apakah user_id valid
        If user_id = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AnimateTransition(Form1) ' Pindah ke halaman login
        End If

        pnlSidebar.BackColor = Color.FromArgb(228, 228, 210) ' Warna pastel hijau muda
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Width = 200


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

        ' Styling tombol form bunga
        Dim tombolForm() As Button = {btnTambah, btnHapus, btnUpdate, btnBrowseGambar, btnBatal}

        For Each btn In tombolForm
            btn.BackColor = Color.FromArgb(192, 202, 164) ' Hijau pastel
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.ForeColor = Color.Black

            btn.Font = New Font("Bell MT", 12)
            btn.Height = 35
            btn.Cursor = Cursors.Hand
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(162, 105, 96)

            BuatRoundedButton(btn, 8)
        Next

        With dgvBungaAdmin
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(111, 142, 114) ' Hijau lumut
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Bell MT", 10, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Bell MT", 10)
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 230)
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
            .BorderStyle = BorderStyle.None
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 240)
        End With


        LoadDataBunga()
    End Sub

    Private Sub BuatRoundedButton(btn As Button, radius As Integer)
        Dim path As New Drawing2D.GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddArc(New Rectangle(btn.Width - radius, 0, radius, radius), -90, 90)
        path.AddArc(New Rectangle(btn.Width - radius, btn.Height - radius, radius, radius), 0, 90)
        path.AddArc(New Rectangle(0, btn.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()
        btn.Region = New Region(path)
    End Sub


    Private Sub Button_Hover(sender As Object, e As EventArgs) Handles _
    btnTambahBunga.MouseEnter, btnDaftarPesanan.MouseEnter, btnRiwayat.MouseEnter, btnLogout.MouseEnter

        CType(sender, Button).BackColor = Color.FromArgb(192, 202, 164) ' warna hijau pastel tua
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

    Public Class Bunga
        Public Property BungaId As Integer
        Public Property Nama As String
        Public Property Stok As Integer
        Public Property GambarPath As String
        Public Property Harga As Decimal
    End Class



    Dim daftarBunga As New List(Of Bunga)

    Private Sub TampilDataBunga()
        Try
            BukaKoneksi()
            Dim query As String = "SELECT * FROM bunga"
            da = New MySqlDataAdapter(query, conn)
            dt = New DataTable()
            da.Fill(dt)
            dgvBungaAdmin.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan data: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub


    Private Sub FormAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvBungaAdmin.AutoGenerateColumns = True
        dgvBungaAdmin.DataSource = daftarBunga
    End Sub


    Private Sub btnBrowseGambar_Click(sender As Object, e As EventArgs) Handles btnBrowseGambar.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If ofd.ShowDialog = DialogResult.OK Then
            pbBunga.ImageLocation = ofd.FileName
        End If
    End Sub

    Private Sub BukaKoneksi()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal membuka koneksi: " & ex.Message)
        End Try
    End Sub

    Private Sub TutupKoneksi()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menutup koneksi: " & ex.Message)
        End Try
    End Sub


    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If String.IsNullOrWhiteSpace(txtNama.Text) OrElse String.IsNullOrWhiteSpace(txtStok.Text) OrElse String.IsNullOrWhiteSpace(txtHarga.Text) Then
            MessageBox.Show("Nama, stok, dan harga harus diisi!")
            Return
        End If

        Try
            BukaKoneksi()
            Dim query As String = "INSERT INTO bunga (nama, stok, gambar, harga) VALUES (@nama, @stok, @gambar, @harga)"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@nama", txtNama.Text)
            cmd.Parameters.AddWithValue("@stok", Integer.Parse(txtStok.Text))
            cmd.Parameters.AddWithValue("@gambar", pbBunga.ImageLocation)
            cmd.Parameters.AddWithValue("@harga", Decimal.Parse(txtHarga.Text)) ' Tambahkan harga
            cmd.ExecuteNonQuery()
            TampilDataBunga()
            ClearForm()
        Catch ex As Exception
            MessageBox.Show("Error saat tambah data: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        ' Pastikan ada data yang dipilih
        If dgvBungaAdmin.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih data yang ingin dihapus.")
            Return
        End If

        ' Konfirmasi penghapusan
        Dim konfirmasi As DialogResult = MessageBox.Show("Yakin ingin menghapus bunga ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If konfirmasi = DialogResult.No Then Exit Sub

        ' Ambil ID Bunga dari kolom "bunga_id"
        Dim idBunga As Integer
        Try
            idBunga = CInt(dgvBungaAdmin.CurrentRow.Cells("bunga_id").Value)
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil ID bunga: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Eksekusi penghapusan
        Try
            BukaKoneksi()
            Dim query As String = "DELETE FROM bunga WHERE bunga_id = @bunga_id"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@bunga_id", idBunga)
            Dim result As Integer = cmd.ExecuteNonQuery()

            If result > 0 Then
                MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TampilDataBunga()
                ClearForm()
            Else
                MessageBox.Show("Data tidak ditemukan atau gagal dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error saat menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvBungaAdmin.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih data yang ingin diupdate.")
            Return
        End If

        ' Ambil ID bunga dari baris yang dipilih
        Dim bungaId As Integer = CInt(dgvBungaAdmin.CurrentRow.Cells("bunga_id").Value)

        Try
            BukaKoneksi()

            ' Ambil nilai lama dari baris DataGridView jika ada textbox kosong
            Dim nama As String = If(String.IsNullOrWhiteSpace(txtNama.Text), dgvBungaAdmin.CurrentRow.Cells("nama").Value.ToString(), txtNama.Text)
            Dim stok As Integer = If(String.IsNullOrWhiteSpace(txtStok.Text), CInt(dgvBungaAdmin.CurrentRow.Cells("stok").Value), Integer.Parse(txtStok.Text))
            Dim harga As Decimal = If(String.IsNullOrWhiteSpace(txtHarga.Text), CDec(dgvBungaAdmin.CurrentRow.Cells("harga").Value), Decimal.Parse(txtHarga.Text))
            Dim gambar As String = If(String.IsNullOrEmpty(pbBunga.ImageLocation), dgvBungaAdmin.CurrentRow.Cells("gambar").Value.ToString(), pbBunga.ImageLocation)

            Dim query As String = "UPDATE bunga SET nama = @nama, stok = @stok, gambar = @gambar, harga = @harga WHERE bunga_id = @bunga_id"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@nama", nama)
            cmd.Parameters.AddWithValue("@stok", stok)
            cmd.Parameters.AddWithValue("@gambar", gambar)
            cmd.Parameters.AddWithValue("@harga", harga)
            cmd.Parameters.AddWithValue("@bunga_id", bungaId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data berhasil diperbarui.")
            TampilDataBunga()
            ClearForm()
        Catch ex As Exception
            MessageBox.Show("Error saat update data: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub



    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ClearForm()
    End Sub


    Private Sub RefreshGrid()
        dgvBungaAdmin.DataSource = Nothing
        dgvBungaAdmin.DataSource = daftarBunga

        dgvBungaAdmin.Columns.Clear()

        dgvBungaAdmin.Columns.Add("bunga_id", "ID")
        dgvBungaAdmin.Columns("bunga_id").DataPropertyName = "BungaId" ' Sesuaikan dengan Property di class Bunga
        dgvBungaAdmin.Columns("bunga_id").Width = 50

        dgvBungaAdmin.Columns.Add("Nama", "Nama")
        dgvBungaAdmin.Columns("Nama").DataPropertyName = "Nama"
        dgvBungaAdmin.Columns("Nama").Width = 150

        dgvBungaAdmin.Columns.Add("Stok", "Stok")
        dgvBungaAdmin.Columns("Stok").DataPropertyName = "Stok"
        dgvBungaAdmin.Columns("Stok").Width = 60

        dgvBungaAdmin.Columns.Add("Harga", "Harga")
        dgvBungaAdmin.Columns("Harga").DataPropertyName = "Harga"
        dgvBungaAdmin.Columns("Harga").Width = 100

        dgvBungaAdmin.Columns.Add("GambarPath", "Gambar")
        dgvBungaAdmin.Columns("GambarPath").DataPropertyName = "GambarPath"
        dgvBungaAdmin.Columns("GambarPath").Width = 150

    End Sub




    Private Sub ClearForm()
        txtNama.Clear()
        txtStok.Clear()
        txtHarga.Clear() ' Tambahkan ini
        pbBunga.ImageLocation = Nothing
    End Sub

    Private Sub dgvBungaAdmin_CellClick(Sender As Object, e As DataGridViewCellEventArgs) Handles dgvBungaAdmin.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBungaAdmin.Rows(e.RowIndex)

            txtNama.Text = row.Cells("Nama").Value.ToString()
            txtStok.Text = row.Cells("Stok").Value.ToString()
            txtHarga.Text = row.Cells("Harga").Value.ToString()

            'Cek apakah kolom GambarPath ada dan nilainya tidak null
            If dgvBungaAdmin.Columns.Contains("GambarPath") AndAlso Not IsDBNull(row.Cells("GambarPath").Value) Then
                pbBunga.ImageLocation = row.Cells("GambarPath").Value.ToString()
            Else
                pbBunga.Image = Nothing 'Atau set gambar default
            End If
        End If
    End Sub

    Private Sub btnDaftarPesanan_Click(sender As Object, e As EventArgs) Handles btnDaftarPesanan.Click
        Dim formPesanan As New Form9()
        AnimateTransition(formPesanan)
    End Sub


    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Reset session saat logout
        SessionManager.UserID = 0
        SessionManager.Username = ""
        SessionManager.TipeUser = ""

        MessageBox.Show("Anda telah berhasil logout.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AnimateTransition(Form1) ' Pindah ke halaman login
    End Sub


End Class