<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        pnlSidebar = New Panel()
        PictureBox5 = New PictureBox()
        PictureBox1 = New PictureBox()
        btnRiwayat = New Button()
        btnLogout = New Button()
        btnDaftarPesanan = New Button()
        btnTambahBunga = New Button()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox3 = New PictureBox()
        btnTambah = New Button()
        btnBatal = New Button()
        btnHapus = New Button()
        btnUpdate = New Button()
        btnBrowseGambar = New Button()
        pbBunga = New PictureBox()
        lblGambar = New Label()
        txtStok = New TextBox()
        lblStok = New Label()
        txtNama = New TextBox()
        lblNama = New Label()
        dgvBungaAdmin = New DataGridView()
        OpenFileDialog1 = New OpenFileDialog()
        txtHarga = New TextBox()
        lblHarga = New Label()
        pnlSidebar.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbBunga, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvBungaAdmin, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.Controls.Add(PictureBox5)
        pnlSidebar.Controls.Add(PictureBox1)
        pnlSidebar.Controls.Add(btnRiwayat)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Controls.Add(btnDaftarPesanan)
        pnlSidebar.Controls.Add(btnTambahBunga)
        pnlSidebar.Controls.Add(Label2)
        pnlSidebar.Controls.Add(Label1)
        pnlSidebar.Controls.Add(PictureBox3)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(270, 696)
        pnlSidebar.TabIndex = 0
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.Transparent
        PictureBox5.Image = My.Resources.Resources._4
        PictureBox5.Location = New Point(126, 416)
        PictureBox5.Margin = New Padding(2)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(144, 211)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 81
        PictureBox5.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources._8
        PictureBox1.Location = New Point(-113, 300)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(296, 327)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 75
        PictureBox1.TabStop = False
        ' 
        ' btnRiwayat
        ' 
        btnRiwayat.Font = New Font("Bell MT", 14F)
        btnRiwayat.Location = New Point(0, 238)
        btnRiwayat.Name = "btnRiwayat"
        btnRiwayat.Size = New Size(253, 56)
        btnRiwayat.TabIndex = 74
        btnRiwayat.Text = "✦ Riwayat"
        btnRiwayat.TextAlign = ContentAlignment.MiddleLeft
        btnRiwayat.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.Font = New Font("Bell MT", 14F)
        btnLogout.Location = New Point(0, 637)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(253, 56)
        btnLogout.TabIndex = 73
        btnLogout.Text = "✦ Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnDaftarPesanan
        ' 
        btnDaftarPesanan.Font = New Font("Bell MT", 14F)
        btnDaftarPesanan.Location = New Point(0, 177)
        btnDaftarPesanan.Name = "btnDaftarPesanan"
        btnDaftarPesanan.Size = New Size(253, 56)
        btnDaftarPesanan.TabIndex = 71
        btnDaftarPesanan.Text = "✦ Daftar Pesanan"
        btnDaftarPesanan.TextAlign = ContentAlignment.MiddleLeft
        btnDaftarPesanan.UseVisualStyleBackColor = True
        ' 
        ' btnTambahBunga
        ' 
        btnTambahBunga.Font = New Font("Bell MT", 14F)
        btnTambahBunga.Location = New Point(0, 115)
        btnTambahBunga.Name = "btnTambahBunga"
        btnTambahBunga.Size = New Size(253, 56)
        btnTambahBunga.TabIndex = 70
        btnTambahBunga.Text = "✦ Tambah Bunga"
        btnTambahBunga.TextAlign = ContentAlignment.MiddleLeft
        btnTambahBunga.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Edwardian Script ITC", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(30, 51)
        Label2.Name = "Label2"
        Label2.Size = New Size(113, 52)
        Label2.TabIndex = 69
        Label2.Text = "Florist"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Edwardian Script ITC", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(24, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(145, 52)
        Label1.TabIndex = 68
        Label1.Text = "Blossom"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(165, 20)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(88, 70)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 67
        PictureBox3.TabStop = False
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(518, 617)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(188, 42)
        btnTambah.TabIndex = 105
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' btnBatal
        ' 
        btnBatal.Location = New Point(305, 617)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(188, 42)
        btnBatal.TabIndex = 104
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = True
        ' 
        ' btnHapus
        ' 
        btnHapus.Location = New Point(949, 617)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(188, 42)
        btnHapus.TabIndex = 103
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(734, 617)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(188, 42)
        btnUpdate.TabIndex = 102
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnBrowseGambar
        ' 
        btnBrowseGambar.Location = New Point(551, 458)
        btnBrowseGambar.Name = "btnBrowseGambar"
        btnBrowseGambar.Size = New Size(105, 42)
        btnBrowseGambar.TabIndex = 101
        btnBrowseGambar.Text = "Browse"
        btnBrowseGambar.UseVisualStyleBackColor = True
        ' 
        ' pbBunga
        ' 
        pbBunga.BackColor = SystemColors.Control
        pbBunga.Location = New Point(305, 367)
        pbBunga.Name = "pbBunga"
        pbBunga.Size = New Size(220, 212)
        pbBunga.SizeMode = PictureBoxSizeMode.Zoom
        pbBunga.TabIndex = 100
        pbBunga.TabStop = False
        ' 
        ' lblGambar
        ' 
        lblGambar.AutoSize = True
        lblGambar.BackColor = Color.Transparent
        lblGambar.Font = New Font("Goudy Old Style", 18F, FontStyle.Italic)
        lblGambar.ForeColor = Color.Black
        lblGambar.Location = New Point(305, 304)
        lblGambar.Name = "lblGambar"
        lblGambar.Size = New Size(218, 39)
        lblGambar.TabIndex = 99
        lblGambar.Text = "Gambar Bunga"
        ' 
        ' txtStok
        ' 
        txtStok.BackColor = Color.RosyBrown
        txtStok.BorderStyle = BorderStyle.None
        txtStok.Font = New Font("Goudy Old Style", 14F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        txtStok.ForeColor = Color.Black
        txtStok.Location = New Point(307, 159)
        txtStok.Name = "txtStok"
        txtStok.Size = New Size(349, 34)
        txtStok.TabIndex = 98
        ' 
        ' lblStok
        ' 
        lblStok.AutoSize = True
        lblStok.BackColor = Color.Transparent
        lblStok.Font = New Font("Goudy Old Style", 18F, FontStyle.Italic)
        lblStok.ForeColor = Color.Black
        lblStok.Location = New Point(307, 114)
        lblStok.Name = "lblStok"
        lblStok.Size = New Size(72, 39)
        lblStok.TabIndex = 97
        lblStok.Text = "Stok"
        ' 
        ' txtNama
        ' 
        txtNama.BackColor = Color.RosyBrown
        txtNama.BorderStyle = BorderStyle.None
        txtNama.Font = New Font("Goudy Old Style", 14F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        txtNama.ForeColor = Color.Black
        txtNama.Location = New Point(307, 73)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(349, 34)
        txtNama.TabIndex = 96
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.BackColor = Color.Transparent
        lblNama.Font = New Font("Goudy Old Style", 18F, FontStyle.Italic)
        lblNama.ForeColor = Color.Black
        lblNama.Location = New Point(305, 25)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(192, 39)
        lblNama.TabIndex = 95
        lblNama.Text = "Nama Bunga"
        ' 
        ' dgvBungaAdmin
        ' 
        dgvBungaAdmin.AllowUserToAddRows = False
        dgvBungaAdmin.BackgroundColor = SystemColors.Control
        dgvBungaAdmin.BorderStyle = BorderStyle.None
        dgvBungaAdmin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBungaAdmin.Location = New Point(697, 36)
        dgvBungaAdmin.Name = "dgvBungaAdmin"
        dgvBungaAdmin.RowHeadersWidth = 62
        dgvBungaAdmin.Size = New Size(433, 543)
        dgvBungaAdmin.TabIndex = 94
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' txtHarga
        ' 
        txtHarga.BackColor = Color.RosyBrown
        txtHarga.BorderStyle = BorderStyle.None
        txtHarga.Font = New Font("Goudy Old Style", 14F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        txtHarga.ForeColor = Color.Black
        txtHarga.Location = New Point(307, 250)
        txtHarga.Name = "txtHarga"
        txtHarga.Size = New Size(349, 34)
        txtHarga.TabIndex = 107
        ' 
        ' lblHarga
        ' 
        lblHarga.AutoSize = True
        lblHarga.BackColor = Color.Transparent
        lblHarga.Font = New Font("Goudy Old Style", 18F, FontStyle.Italic)
        lblHarga.ForeColor = Color.Black
        lblHarga.Location = New Point(307, 205)
        lblHarga.Name = "lblHarga"
        lblHarga.Size = New Size(100, 39)
        lblHarga.TabIndex = 106
        lblHarga.Text = "Harga"
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(10F, 22F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1165, 696)
        Controls.Add(txtHarga)
        Controls.Add(lblHarga)
        Controls.Add(btnTambah)
        Controls.Add(btnBatal)
        Controls.Add(btnHapus)
        Controls.Add(btnUpdate)
        Controls.Add(btnBrowseGambar)
        Controls.Add(pbBunga)
        Controls.Add(lblGambar)
        Controls.Add(txtStok)
        Controls.Add(lblStok)
        Controls.Add(txtNama)
        Controls.Add(lblNama)
        Controls.Add(dgvBungaAdmin)
        Controls.Add(pnlSidebar)
        Font = New Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        Name = "Form4"
        Text = "Form4"
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(pbBunga, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvBungaAdmin, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnDaftarPesanan As Button
    Friend WithEvents btnTambahBunga As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnRiwayat As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnBrowseGambar As Button
    Friend WithEvents pbBunga As PictureBox
    Friend WithEvents lblGambar As Label
    Friend WithEvents txtStok As TextBox
    Friend WithEvents lblStok As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents dgvBungaAdmin As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtHarga As TextBox
    Friend WithEvents lblHarga As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
End Class
