Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient
Imports PA.Form2

Public Class Form5
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=bunga_db")
    Dim isDragging As Boolean = False
    Dim offset As Point
    Private originalFlowerData As DataTable
    Private currentFlowerData As DataTable
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
            (Screen.PrimaryScreen.WorkingArea.Height - targetForm.Height) \ 2
        )

        AnimateWindow(Me.Handle, 300, AW_BLEND Or AW_HIDE)
        targetForm.Show()
        AnimateWindow(targetForm.Handle, 300, AW_BLEND Or AW_ACTIVATE)
        Me.Hide()
    End Sub

    Private Sub Button_Hover(sender As Object, e As EventArgs) Handles _
        btnDaftarBunga.MouseEnter, btnKeranjang.MouseEnter, btnRiwayatUser.MouseEnter, btnLogout.MouseEnter
        CType(sender, Button).BackColor = Color.FromArgb(192, 202, 164)
    End Sub

    Private Sub Button_Leave(sender As Object, e As EventArgs) Handles _
        btnDaftarBunga.MouseLeave, btnKeranjang.MouseLeave, btnRiwayatUser.MouseLeave, btnLogout.MouseLeave
        CType(sender, Button).BackColor = Color.Transparent
    End Sub

    Private Sub LoadDataBunga()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        flpBunga.Controls.Clear()

        Try
            Dim query As String = "SELECT bunga_id, nama, harga, stok, gambar FROM bunga"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                
                        ' ... [kode untuk menampilkan bunga] ...
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data bunga: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReloadDataBunga(sender As Object, e As EventArgs)
        LoadDataBunga()
    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AnimateTransition(Form1)
            Return
        End If

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

        RefreshDaftarBunga()
        AddHandler Form6.PembayaranBerhasil, AddressOf ReloadDataBunga
    End Sub

    Public Sub RefreshDaftarBunga()
        TampilDaftarBunga()
    End Sub

    Sub TampilDaftarBunga()
        flpBunga.Controls.Clear()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM bunga", conn)
            Dim adapter As New MySqlDataAdapter(cmd)

            originalFlowerData = New DataTable()
            adapter.Fill(originalFlowerData)

            currentFlowerData = originalFlowerData.Copy()
            conn.Close()

            TampilkanDataBunga(currentFlowerData)

        Catch ex As Exception
            MessageBox.Show("Error saat menampilkan bunga: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub TampilkanDataBunga(data As DataTable)
        flpBunga.Controls.Clear()

        
        For Each row As DataRow In data.Rows
            Dim bungaId As Integer = Convert.ToInt32(row("bunga_id"))
            Dim panel As New Panel With {
                .Width = 180,
                .Height = 320,
                .BackColor = Color.Transparent,
                .BorderStyle = BorderStyle.None,
                .Tag = bungaId
            }

            Dim lblNama As New Label With {
                .Text = row("nama").ToString(),
                .Top = 10,
                .Width = 165,
                .Height = 25,
                .Left = 7,
                .Font = New Font("Bell MT", 13),
                .ForeColor = Color.Black,
                .BackColor = Color.FromArgb(162, 105, 96),
                .TextAlign = ContentAlignment.MiddleCenter
            }
            panel.Controls.Add(lblNama)

            Dim pic As New PictureBox With {
                .Width = 140,
                .Height = 140,
                .Top = 40,
                .Left = 20,
                .SizeMode = PictureBoxSizeMode.Zoom,
                .BackColor = Color.Transparent
            }

            Try
                Dim path As String = row("gambar").ToString()
                If IO.File.Exists(path) Then
                    pic.Image = Image.FromFile(path)
                End If
            Catch ex As Exception
                MessageBox.Show("Gagal memuat gambar: " & ex.Message)
            End Try
            panel.Controls.Add(pic)

            Dim lblHarga As New Label With {
                    .Text = "Rp " & Convert.ToInt32(row("harga")).ToString("N0"),
                    .Top = 185,
                    .Width = 165,
                    .Height = 25,
                    .Left = 7,
                    .Font = New Font("Bell MT", 11),
                    .ForeColor = Color.Black,
                    .BackColor = Color.FromArgb(192, 202, 164),
                    .TextAlign = ContentAlignment.MiddleCenter
                }
            panel.Controls.Add(lblHarga)

            Dim lblStok As New Label With {
                .Text = "Stok: " & row("stok").ToString(),
                .Top = 215,
                .Width = 160,
                .Height = 20,
                .Left = 12,
                .Font = New Font("Bell MT", 11),
                .ForeColor = Color.Black,
                .TextAlign = ContentAlignment.MiddleCenter
            }
            panel.Controls.Add(lblStok)

            ' Quantity controls
            Dim pnlQty As New Panel With {
                .Top = 240,
                .Width = 180,
                .Height = 30,
                .BackColor = Color.Transparent
            }

            Dim btnMin As New Button With {
                .Text = "-",
                .Width = 40,
                .Height = 30,
                .Left = 25,
                .Font = New Font("Bell MT", 11),
                .BackColor = Color.FromArgb(192, 202, 164),
                .FlatStyle = FlatStyle.Flat,
                .Tag = bungaId ' Store flower ID
            }
            btnMin.FlatAppearance.BorderSize = 0
            AddHandler btnMin.Click, AddressOf KurangiJumlah

            Dim lblJumlah As New Label With {
                .Text = "0",
                .Width = 30,
                .Height = 30,
                .Left = 78,
                .Font = New Font("Bell MT", 11),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Tag = bungaId ' Store flower ID
            }

            Dim btnPlus As New Button With {
                .Text = "+",
                .Width = 40,
                .Height = 30,
                .Left = 118,
                .Font = New Font("Bell MT", 11),
                .BackColor = Color.FromArgb(192, 202, 164),
                .FlatStyle = FlatStyle.Flat,
                .Tag = bungaId ' Store flower ID
            }
            btnPlus.FlatAppearance.BorderSize = 0
            AddHandler btnPlus.Click, AddressOf TambahJumlah

            pnlQty.Controls.AddRange({btnMin, lblJumlah, btnPlus})
            panel.Controls.Add(pnlQty)

            ' Add to cart button
            Dim btnCart As New Button With {
                .Text = "🛒",
                .Width = 40,
                .Height = 30,
                .Top = 275,
                .Left = 72,
                .Font = New Font("Bell MT", 11),
                .BackColor = Color.FromArgb(192, 202, 164),
                .FlatStyle = FlatStyle.Flat,
                .Tag = bungaId ' Store flower ID
            }
            btnCart.FlatAppearance.BorderSize = 0
            AddHandler btnCart.Click, AddressOf btnCart_Click
            panel.Controls.Add(btnCart)

            flpBunga.Controls.Add(panel)
        Next
    End Sub

    Private Sub TambahJumlah(sender As Object, e As EventArgs)
        Dim btnPlus As Button = CType(sender, Button)
        Dim pnlQty As Panel = CType(btnPlus.Parent, Panel)
        Dim lblJumlah As Label = pnlQty.Controls.OfType(Of Label).FirstOrDefault()

        Dim currentJumlah As Integer = Integer.Parse(lblJumlah.Text)
        lblJumlah.Text = (currentJumlah + 1).ToString()
    End Sub

    Private Sub KurangiJumlah(sender As Object, e As EventArgs)
        Dim btnMin As Button = CType(sender, Button)
        Dim pnlQty As Panel = CType(btnMin.Parent, Panel)
        Dim lblJumlah As Label = pnlQty.Controls.OfType(Of Label).FirstOrDefault()

        Dim currentJumlah As Integer = Integer.Parse(lblJumlah.Text)
        If currentJumlah > 0 Then
            lblJumlah.Text = (currentJumlah - 1).ToString()
        End If
    End Sub

    Private Sub btnCart_Click(sender As Object, e As EventArgs)
        Dim user_id As Integer = SessionManager.UserID

        If user_id = 0 Then
            MessageBox.Show("Anda harus login terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim btnCart As Button = CType(sender, Button)
        Dim bunga_id As Integer = CInt(btnCart.Tag)

        Dim panelBunga As Panel = CType(btnCart.Parent, Panel)

        Dim pnlQty As Panel = panelBunga.Controls.OfType(Of Panel)().FirstOrDefault(
        Function(p) p.Controls.OfType(Of Button)().Any())

        If pnlQty Is Nothing Then
            MessageBox.Show("Tidak dapat menemukan kontrol jumlah.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim lblJumlah As Label = pnlQty.Controls.OfType(Of Label)().FirstOrDefault()

        If lblJumlah Is Nothing Then
            MessageBox.Show("Tidak dapat menemukan label jumlah.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim jumlah As Integer
        If Not Integer.TryParse(lblJumlah.Text, jumlah) Then
            MessageBox.Show("Jumlah tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If jumlah <= 0 Then
            MessageBox.Show("Jumlah tidak boleh 0 atau kurang.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim stok As Integer = 0
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT stok FROM bunga WHERE bunga_id = @bunga_id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@bunga_id", bunga_id)
                stok = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            If jumlah > stok Then
                MessageBox.Show($"Jumlah melebihi stok yang tersedia. Stok tersisa: {stok}",
                          "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show("Error saat mengambil data stok: " & ex.Message,
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim queryCheck As String = "SELECT jumlah FROM keranjang WHERE user_id = @user_id AND bunga_id = @bunga_id"
            Dim existingJumlah As Integer = 0

            Using cmdCheck As New MySqlCommand(queryCheck, conn)
                cmdCheck.Parameters.AddWithValue("@user_id", user_id)
                cmdCheck.Parameters.AddWithValue("@bunga_id", bunga_id)

                Using reader As MySqlDataReader = cmdCheck.ExecuteReader()
                    If reader.Read() Then
                        existingJumlah = Convert.ToInt32(reader("jumlah"))
                    End If
                End Using
            End Using

            If existingJumlah > 0 Then
                Dim updateQuery As String = "UPDATE keranjang SET jumlah = jumlah + @jumlah " &
                                      "WHERE user_id = @user_id AND bunga_id = @bunga_id"
                Using updateCmd As New MySqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@jumlah", jumlah)
                    updateCmd.Parameters.AddWithValue("@user_id", user_id)
                    updateCmd.Parameters.AddWithValue("@bunga_id", bunga_id)
                    updateCmd.ExecuteNonQuery()
                End Using
            Else
                Dim insertQuery As String = "INSERT INTO keranjang (user_id, bunga_id, jumlah) " &
                                      "VALUES (@user_id, @bunga_id, @jumlah)"
                Using insertCmd As New MySqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@user_id", user_id)
                    insertCmd.Parameters.AddWithValue("@bunga_id", bunga_id)
                    insertCmd.Parameters.AddWithValue("@jumlah", jumlah)
                    insertCmd.ExecuteNonQuery()
                End Using
            End If

            lblJumlah.Text = "0"
            MessageBox.Show("Item berhasil ditambahkan ke keranjang.", "Sukses",
                      MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error saat menambahkan ke keranjang: " & ex.Message,
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnKeranjang_Click(sender As Object, e As EventArgs) Handles btnKeranjang.Click
        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AnimateTransition(Form1)
        Else
            Dim form6 As New Form6()
            AnimateTransition(form6)
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        SessionManager.UserID = 0
        SessionManager.Username = ""
        SessionManager.TipeUser = ""

        MessageBox.Show("Anda telah berhasil logout.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AnimateTransition(Form1)
    End Sub

    Private Sub btnDaftarBunga_Click(sender As Object, e As EventArgs) Handles btnDaftarBunga.Click
        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login atau sesi telah berakhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AnimateTransition(Form1)
        Else
            RefreshDaftarBunga()
        End If
    End Sub

    Private Sub btnCari_TextChanged(sender As Object, e As EventArgs) Handles btnCari.TextChanged
        If originalFlowerData Is Nothing Then Return

        Dim searchText As String = btnCari.Text.Trim().ToLower()

        Try
            If String.IsNullOrEmpty(searchText) Then
                currentFlowerData = originalFlowerData.Copy()
            Else
                Dim filterExpression As String = $"nama LIKE '%{searchText}%'"

                If originalFlowerData.Columns.Contains("deskripsi") Then
                    filterExpression &= $" OR deskripsi LIKE '%{searchText}%'"
                End If

                Dim filteredRows As DataRow() = originalFlowerData.Select(filterExpression)
                currentFlowerData = originalFlowerData.Clone()
                For Each row As DataRow In filteredRows
                    currentFlowerData.ImportRow(row)
                Next
            End If

            TampilkanDataBunga(currentFlowerData)
        Catch ex As Exception
            MessageBox.Show("Error saat mencari: " & ex.Message)
        End Try
    End Sub
    Private Sub btnRiwayatUser_Click(sender As Object, e As EventArgs) Handles btnRiwayatUser.Click
        If SessionManager.UserID = 0 Then
            MessageBox.Show("Anda belum login", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Form8.BukaFormRiwayat()

       Me.Close()
    End Sub

    Private Sub Form5_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RefreshDaftarBunga()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub
End Class
