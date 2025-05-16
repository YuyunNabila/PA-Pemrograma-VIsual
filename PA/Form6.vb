Imports MySql.Data.MySqlClient
Imports PA.Form2
Imports System.Runtime.InteropServices
Imports System.Text

Public Class Form6
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=bunga_db")
    Dim isDragging As Boolean = False
    Dim offset As Point
    Public Event PembayaranBerhasil As EventHandler
    <DllImport("user32.dll")>
    Private Shared Function AnimateWindow(ByVal hwnd As IntPtr, ByVal dwTime As Integer, ByVal dwFlags As Integer) As Boolean
    End Function

    Private Const AW_BLEND As Integer = &H80000
    Private Const AW_HIDE As Integer = &H10000
    Private Const AW_ACTIVATE As Integer = &H20000

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

    Private Sub AnimateTransition(targetForm As Form)
        targetForm.StartPosition = FormStartPosition.Manual
        targetForm.Location = New Point(
            (Screen.PrimaryScreen.WorkingArea.Width - targetForm.Width) \ 2,
            (Screen.PrimaryScreen.WorkingArea.Height - targetForm.Height) \ 2)

        AnimateWindow(Me.Handle, 300, AW_BLEND Or AW_HIDE)
        targetForm.Show()
        AnimateWindow(targetForm.Handle, 300, AW_BLEND Or AW_ACTIVATE)
        Me.Hide()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        StyleButton(btnBayar)

        pnlSidebar.BackColor = Color.FromArgb(228, 228, 210)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Width = 200

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

        flpKeranjang.AutoScroll = True
        flpKeranjang.WrapContents = False
        flpKeranjang.FlowDirection = FlowDirection.TopDown

        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AnimateTransition(Form1)
        Else
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                    LoadKeranjang()
                Catch ex As Exception
                    MessageBox.Show("Gagal terhubung ke database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                LoadKeranjang()
            End If
        End If
    End Sub

    Private Sub StyleButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(190, 204, 152)
        btn.ForeColor = Color.Black
        btn.Font = New Font("Lucida Bright", 13, FontStyle.Regular)
        btn.Width = 150
        btn.Height = 40

        Dim path As New Drawing2D.GraphicsPath()
        Dim radius As Integer = 20
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, btn.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()
        btn.Region = New Region(path)

        AddHandler btn.MouseEnter, AddressOf Button_Hover
        AddHandler btn.MouseLeave, AddressOf Button_Leave
    End Sub

    Private Sub Button_Hover(sender As Object, e As EventArgs) Handles _
        btnDaftarBunga.MouseEnter, btnKeranjang.MouseEnter, btnRiwayatUser.MouseEnter, btnLogout.MouseEnter
        CType(sender, Button).BackColor = Color.FromArgb(192, 202, 164)
    End Sub

    Private Sub Button_Leave(sender As Object, e As EventArgs) Handles _
        btnDaftarBunga.MouseLeave, btnKeranjang.MouseLeave, btnRiwayatUser.MouseLeave, btnLogout.MouseLeave
        CType(sender, Button).BackColor = Color.Transparent
    End Sub

    Public Sub LoadKeranjang()
        flpKeranjang.Controls.Clear()

        If SessionManager.UserID = 0 Then
            Dim lblKosong As New Label()
            lblKosong.Text = "Silakan login terlebih dahulu"
            lblKosong.ForeColor = Color.Gray
            lblKosong.Font = New Font("Bell MT", 12, FontStyle.Italic)
            lblKosong.AutoSize = True
            lblKosong.TextAlign = ContentAlignment.MiddleCenter
            flpKeranjang.Controls.Add(lblKosong)
            Return
        End If

        Try
            Dim query As String = "SELECT k.keranjang_id, b.gambar, b.nama as nama_bunga, k.jumlah, b.harga, " &
                                "(k.jumlah * b.harga) AS subtotal " &
                                "FROM keranjang k JOIN bunga b ON k.bunga_id = b.bunga_id " &
                                "WHERE k.user_id = @UserID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", SessionManager.UserID)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    Dim nomor As Integer = 1
                    Dim totalHarga As Integer = 0
                    Dim adaData As Boolean = False

                    While reader.Read()
                        adaData = True

                        Dim panelItem As New Panel()
                        panelItem.Width = flpKeranjang.Width - 25
                        panelItem.Height = 100
                        panelItem.Margin = New Padding(5)
                        panelItem.BackColor = Color.FromArgb(228, 228, 210)
                        panelItem.BorderStyle = BorderStyle.FixedSingle

                        Dim lblNomor As New Label()
                        lblNomor.Text = nomor.ToString()
                        lblNomor.Location = New Point(10, 40)
                        lblNomor.AutoSize = True
                        panelItem.Controls.Add(lblNomor)

                        Dim pbGambar As New PictureBox()
                        pbGambar.SizeMode = PictureBoxSizeMode.Zoom
                        pbGambar.Size = New Size(80, 80)
                        pbGambar.Location = New Point(40, 10)

                        Try
                            Dim pathGambar As String = reader("gambar").ToString()

                            If String.IsNullOrEmpty(pathGambar) Then
                                pbGambar.Image = My.Resources._1 ' Gambar default dari resources
                            Else
                                If Not IO.Path.IsPathRooted(pathGambar) Then
                                    pathGambar = IO.Path.Combine(Application.StartupPath, pathGambar)
                                End If

                                If IO.File.Exists(pathGambar) Then
                                    Using stream As New IO.FileStream(pathGambar, IO.FileMode.Open, IO.FileAccess.Read)
                                        pbGambar.Image = Image.FromStream(stream)
                                    End Using
                                Else
                                    pbGambar.Image = My.Resources._1 ' Fallback ke gambar default
                                End If
                            End If
                        Catch ex As Exception
                            pbGambar.Image = My.Resources._1
                            
                        Finally
                           
                            panelItem.Controls.Add(pbGambar)
                        End Try

                        Dim lblNama As New Label()
                        lblNama.Text = reader("nama_bunga").ToString()
                        lblNama.Location = New Point(130, 15)
                        lblNama.AutoSize = True
                        lblNama.Font = New Font("Bell MT", 10, FontStyle.Bold)
                        panelItem.Controls.Add(lblNama)

                        Dim lblJumlah As New Label()
                        lblJumlah.Text = "Jumlah: " & reader("jumlah").ToString()
                        lblJumlah.Location = New Point(130, 35)
                        lblJumlah.AutoSize = True
                        lblJumlah.Font = New Font("Bell MT", 10, FontStyle.Bold)
                        panelItem.Controls.Add(lblJumlah)

                        Dim lblHarga As New Label()
                        lblHarga.Text = "Harga: Rp " & Convert.ToInt32(reader("harga")).ToString("N0")
                        lblHarga.Location = New Point(130, 55)
                        lblHarga.AutoSize = True
                        lblHarga.Font = New Font("Bell MT", 10, FontStyle.Bold)
                        panelItem.Controls.Add(lblHarga)

                        Dim lblSubtotal As New Label()
                        lblSubtotal.Text = "Subtotal: Rp " & Convert.ToInt32(reader("subtotal")).ToString("N0")
                        lblSubtotal.Location = New Point(130, 75)
                        lblSubtotal.AutoSize = True
                        lblSubtotal.Font = New Font("Bell MT", 10, FontStyle.Bold)
                        panelItem.Controls.Add(lblSubtotal)

                        Dim btnHapus As New Button()
                        btnHapus.Text = "Hapus"
                        btnHapus.Size = New Size(80, 30)
                        btnHapus.Location = New Point(panelItem.Width - 90, 35)
                        btnHapus.Tag = reader("keranjang_id").ToString()
                        btnHapus.BackColor = Color.RosyBrown
                        btnHapus.FlatStyle = FlatStyle.Flat
                        btnHapus.Font = New Font("Bell MT", 12, FontStyle.Bold)
                        AddHandler btnHapus.Click, AddressOf HapusItem
                        panelItem.Controls.Add(btnHapus)

                        flpKeranjang.Controls.Add(panelItem)

                        totalHarga += Convert.ToInt32(reader("subtotal"))
                        nomor += 1
                    End While

                    If Not adaData Then
                        Dim lblKosong As New Label()
                        lblKosong.Text = "Keranjang belanja kosong"
                        lblKosong.ForeColor = Color.Gray
                        lblKosong.Font = New Font("Bell MT", 12, FontStyle.Italic)
                        lblKosong.AutoSize = True
                        lblKosong.TextAlign = ContentAlignment.MiddleCenter
                        flpKeranjang.Controls.Add(lblKosong)
                    End If

                    lblTotalHarga.Text = "Total: Rp " & totalHarga.ToString("N0")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat keranjang: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HapusItem(sender As Object, e As EventArgs)
        Dim btnHapus As Button = CType(sender, Button)
        Dim keranjangID As Integer = Convert.ToInt32(btnHapus.Tag)

        Try
            Dim query As String = "DELETE FROM keranjang WHERE keranjang_id = @KeranjangID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@KeranjangID", keranjangID)
                cmd.ExecuteNonQuery()
            End Using

            LoadKeranjang()
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click

        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                MessageBox.Show("Gagal terhubung ke database: " & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If

        Dim itemCount As Integer = 0
        Try
            Using cmdCount As New MySqlCommand("SELECT COUNT(*) FROM keranjang WHERE user_id = @UserID", conn)
                cmdCount.Parameters.AddWithValue("@UserID", SessionManager.UserID)
                itemCount = Convert.ToInt32(cmdCount.ExecuteScalar())
            End Using

            If itemCount = 0 Then
                MessageBox.Show(vbCrLf & vbCrLf & "         Keranjang belanja kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Return
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memeriksa keranjang: " & ex.Message,
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim transaksiID As Integer = 0
        Dim totalHarga As Integer = 0
        Dim nomorResi As String = GenerateResi()
        Dim transaction As MySqlTransaction = Nothing

        Try

            transaction = conn.BeginTransaction()

            Dim queryTransaksi As String = "INSERT INTO transaksi (user_id, tanggal, resi, total_harga, status) " &
                                "VALUES (@UserID, @Tanggal, @Resi, 0, 'Pending')"

            Using cmdTrans As New MySqlCommand(queryTransaksi, conn, transaction)
                cmdTrans.Parameters.AddWithValue("@UserID", SessionManager.UserID)
                cmdTrans.Parameters.AddWithValue("@Tanggal", DateTime.Now)
                cmdTrans.Parameters.AddWithValue("@Resi", nomorResi)
                cmdTrans.ExecuteNonQuery()
            End Using
            Using cmdLastID As New MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction)
                transaksiID = Convert.ToInt32(cmdLastID.ExecuteScalar())
            End Using

            Dim cartItems As New List(Of (bunga_id As Integer, jumlah As Integer, harga As Integer, stok As Integer))()

            Using cmdItems As New MySqlCommand("SELECT k.bunga_id, k.jumlah, b.harga, b.stok " &
                                      "FROM keranjang k JOIN bunga b ON k.bunga_id = b.bunga_id " &
                                      "WHERE k.user_id = @UserID", conn, transaction)
                cmdItems.Parameters.AddWithValue("@UserID", SessionManager.UserID)

                Using reader As MySqlDataReader = cmdItems.ExecuteReader()
                    While reader.Read()
                        ' Validasi stok sebelum memproses
                        Dim stokTersedia As Integer = reader.GetInt32("stok")
                        Dim jumlahBeli As Integer = reader.GetInt32("jumlah")

                        If jumlahBeli > stokTersedia Then
                            Throw New Exception($"Stok tidak mencukupi untuk bunga ID {reader.GetInt32("bunga_id")}. " &
                                         $"Stok tersedia: {stokTersedia}, jumlah beli: {jumlahBeli}")
                        End If

                        cartItems.Add((reader.GetInt32("bunga_id"),
                                 jumlahBeli,
                                 reader.GetInt32("harga"),
                                 stokTersedia))
                    End While
                End Using
            End Using

            For Each item In cartItems
                Dim subtotal As Integer = item.jumlah * item.harga

                Using cmdDetail As New MySqlCommand("INSERT INTO transaksi_detail " &
                  "(transaksi_id, bunga_id, jumlah, harga_satuan, subtotal, status) " &
                  "VALUES (@TransID, @BungaID, @Jumlah, @Harga, @Subtotal, @Status)",
                  conn, transaction)
                    cmdDetail.Parameters.AddWithValue("@TransID", transaksiID)
                    cmdDetail.Parameters.AddWithValue("@BungaID", item.bunga_id)
                    cmdDetail.Parameters.AddWithValue("@Jumlah", item.jumlah)
                    cmdDetail.Parameters.AddWithValue("@Harga", item.harga)
                    cmdDetail.Parameters.AddWithValue("@Subtotal", subtotal)
                    cmdDetail.Parameters.AddWithValue("@Status", "Menunggu")
                    cmdDetail.ExecuteNonQuery()
                End Using

                Using cmdUpdate As New MySqlCommand("UPDATE bunga SET stok = stok - @Jumlah " &
                                             "WHERE bunga_id = @BungaID AND stok >= @Jumlah",
                                             conn, transaction)
                    cmdUpdate.Parameters.AddWithValue("@Jumlah", item.jumlah)
                    cmdUpdate.Parameters.AddWithValue("@BungaID", item.bunga_id)

                    Dim rowsAffected As Integer = cmdUpdate.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Throw New Exception($"Gagal update stok untuk bunga ID {item.bunga_id}. Stok tidak mencukupi.")
                    End If
                End Using

                totalHarga += subtotal
            Next

            Using cmdUpdateTotal As New MySqlCommand("UPDATE transaksi SET total_harga = @Total " &
                                              "WHERE transaksi_id = @TransID",
                                              conn, transaction)
                cmdUpdateTotal.Parameters.AddWithValue("@Total", totalHarga)
                cmdUpdateTotal.Parameters.AddWithValue("@TransID", transaksiID)
                cmdUpdateTotal.ExecuteNonQuery()
            End Using

            Using cmdClear As New MySqlCommand("DELETE FROM keranjang WHERE user_id = @UserID",
                                         conn, transaction)
                cmdClear.Parameters.AddWithValue("@UserID", SessionManager.UserID)
                cmdClear.ExecuteNonQuery()
            End Using

            transaction.Commit()

            MessageBox.Show($"Pembayaran berhasil! No. Resi: {nomorResi}",
                      "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadKeranjang()
            RaiseEvent PembayaranBerhasil(Me, EventArgs.Empty)

            Dim formResi As New Form7(transaksiID, totalHarga, nomorResi)
            formResi.Show()

        Catch ex As Exception
   
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                Catch rollbackEx As Exception
                    Debug.WriteLine("Error saat rollback: " & rollbackEx.Message)
                End Try
            End If

            MessageBox.Show("Terjadi kesalahan saat proses pembayaran: " & ex.Message,
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If transaction IsNot Nothing Then
                transaction.Dispose()
            End If
        End Try
    End Sub

    Private Function GenerateResi() As String
        Dim prefix As String = "RS"
        Dim tanggal As String = DateTime.Now.ToString("yyyyMMdd")
        Dim random As New Random()
        Return prefix & tanggal & random.Next(100000, 999999).ToString()
    End Function

    Private Sub btnDaftarBunga_Click(sender As Object, e As EventArgs) Handles btnDaftarBunga.Click
        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AnimateTransition(Form1)
        Else
            AnimateTransition(Form5)
        End If
    End Sub

    Private Sub btnKeranjang_Click(sender As Object, e As EventArgs) Handles btnKeranjang.Click
        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AnimateTransition(Form1)
        Else
         
            LoadKeranjang()
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        SessionManager.UserID = 0
        SessionManager.Username = ""
        SessionManager.TipeUser = ""
        MessageBox.Show("Anda telah berhasil logout.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AnimateTransition(Form1)
    End Sub

    Private Sub btnRiwayatUser_Click(sender As Object, e As EventArgs) Handles btnRiwayatUser.Click
        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Form8.BukaFormRiwayat()

        Me.Close()
    End Sub

End Class
