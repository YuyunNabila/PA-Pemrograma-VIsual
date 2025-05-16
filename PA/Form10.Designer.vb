<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
        btnRiwayatPesanan = New Button()
        btnLogout = New Button()
        btnDaftarPesanan = New Button()
        btnTambahBunga = New Button()
        Label1 = New Label()
        PictureBox3 = New PictureBox()
        pnlSidebar = New Panel()
        PictureBox5 = New PictureBox()
        Label2 = New Label()
        flpRiwayat = New FlowLayoutPanel()
        Label3 = New Label()
        txtPencarian = New TextBox()
        PictureBox1 = New PictureBox()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        pnlSidebar.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnRiwayatPesanan
        ' 
        btnRiwayatPesanan.Font = New Font("Bell MT", 14F)
        btnRiwayatPesanan.Location = New Point(0, 278)
        btnRiwayatPesanan.Margin = New Padding(4)
        btnRiwayatPesanan.Name = "btnRiwayatPesanan"
        btnRiwayatPesanan.Size = New Size(316, 70)
        btnRiwayatPesanan.TabIndex = 74
        btnRiwayatPesanan.Text = "✦ Riwayat"
        btnRiwayatPesanan.TextAlign = ContentAlignment.MiddleLeft
        btnRiwayatPesanan.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.Font = New Font("Bell MT", 14F)
        btnLogout.Location = New Point(0, 626)
        btnLogout.Margin = New Padding(4)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(316, 70)
        btnLogout.TabIndex = 73
        btnLogout.Text = "✦ Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnDaftarPesanan
        ' 
        btnDaftarPesanan.Font = New Font("Bell MT", 14F)
        btnDaftarPesanan.Location = New Point(0, 206)
        btnDaftarPesanan.Margin = New Padding(4)
        btnDaftarPesanan.Name = "btnDaftarPesanan"
        btnDaftarPesanan.Size = New Size(316, 70)
        btnDaftarPesanan.TabIndex = 71
        btnDaftarPesanan.Text = "✦ Daftar Pesanan"
        btnDaftarPesanan.TextAlign = ContentAlignment.MiddleLeft
        btnDaftarPesanan.UseVisualStyleBackColor = True
        ' 
        ' btnTambahBunga
        ' 
        btnTambahBunga.Font = New Font("Bell MT", 14F)
        btnTambahBunga.Location = New Point(0, 135)
        btnTambahBunga.Margin = New Padding(4)
        btnTambahBunga.Name = "btnTambahBunga"
        btnTambahBunga.Size = New Size(316, 70)
        btnTambahBunga.TabIndex = 70
        btnTambahBunga.Text = "✦ Tambah Bunga"
        btnTambahBunga.TextAlign = ContentAlignment.MiddleLeft
        btnTambahBunga.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Edwardian Script ITC", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(30, 10)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(145, 52)
        Label1.TabIndex = 68
        Label1.Text = "Blossom"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(183, 28)
        PictureBox3.Margin = New Padding(4)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(110, 88)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 67
        PictureBox3.TabStop = False
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.Controls.Add(PictureBox1)
        pnlSidebar.Controls.Add(PictureBox5)
        pnlSidebar.Controls.Add(btnRiwayatPesanan)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Controls.Add(btnDaftarPesanan)
        pnlSidebar.Controls.Add(btnTambahBunga)
        pnlSidebar.Controls.Add(Label2)
        pnlSidebar.Controls.Add(Label1)
        pnlSidebar.Controls.Add(PictureBox3)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Margin = New Padding(4)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(338, 696)
        pnlSidebar.TabIndex = 122
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.Transparent
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(-98, 354)
        PictureBox5.Margin = New Padding(2)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(295, 266)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 79
        PictureBox5.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Edwardian Script ITC", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(38, 64)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(113, 52)
        Label2.TabIndex = 69
        Label2.Text = "Florist"
        ' 
        ' flpRiwayat
        ' 
        flpRiwayat.BackColor = Color.Transparent
        flpRiwayat.Location = New Point(324, 77)
        flpRiwayat.Margin = New Padding(4)
        flpRiwayat.Name = "flpRiwayat"
        flpRiwayat.Size = New Size(817, 589)
        flpRiwayat.TabIndex = 125
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Arial Rounded MT Bold", 22F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label3.Location = New Point(344, 9)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 51)
        Label3.TabIndex = 123
        Label3.Text = "🔍︎"
        ' 
        ' txtPencarian
        ' 
        txtPencarian.BackColor = Color.RosyBrown
        txtPencarian.BorderStyle = BorderStyle.None
        txtPencarian.Font = New Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPencarian.Location = New Point(422, 17)
        txtPencarian.Margin = New Padding(2)
        txtPencarian.Name = "txtPencarian"
        txtPencarian.Size = New Size(719, 41)
        txtPencarian.TabIndex = 124
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources._4
        PictureBox1.Location = New Point(178, 431)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(158, 189)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 81
        PictureBox1.TabStop = False
        ' 
        ' Form10
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Beige_and_Green_Vintage_Flower_Store_Instagram_Story__Presentation_
        ClientSize = New Size(1165, 696)
        Controls.Add(pnlSidebar)
        Controls.Add(flpRiwayat)
        Controls.Add(Label3)
        Controls.Add(txtPencarian)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4)
        Name = "Form10"
        Text = "Form10"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnRiwayatPesanan As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnDaftarPesanan As Button
    Friend WithEvents btnTambahBunga As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents flpRiwayat As FlowLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPencarian As TextBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
