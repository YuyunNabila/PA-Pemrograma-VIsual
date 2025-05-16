<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        pnlSidebar = New Panel()
        PictureBox1 = New PictureBox()
        btnRiwayatUser = New Button()
        btnLogout = New Button()
        btnKeranjang = New Button()
        btnDaftarBunga = New Button()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox3 = New PictureBox()
        flpKeranjang = New FlowLayoutPanel()
        lblTotalHarga = New Label()
        btnBayar = New Button()
        PictureBox5 = New PictureBox()
        pnlSidebar.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.Controls.Add(PictureBox5)
        pnlSidebar.Controls.Add(PictureBox1)
        pnlSidebar.Controls.Add(btnRiwayatUser)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Controls.Add(btnKeranjang)
        pnlSidebar.Controls.Add(btnDaftarBunga)
        pnlSidebar.Controls.Add(Label2)
        pnlSidebar.Controls.Add(Label1)
        pnlSidebar.Controls.Add(PictureBox3)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(270, 696)
        pnlSidebar.TabIndex = 2
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources._8
        PictureBox1.Location = New Point(-107, 321)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(315, 310)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 79
        PictureBox1.TabStop = False
        ' 
        ' btnRiwayatUser
        ' 
        btnRiwayatUser.Font = New Font("Bell MT", 14F)
        btnRiwayatUser.Location = New Point(0, 238)
        btnRiwayatUser.Name = "btnRiwayatUser"
        btnRiwayatUser.Size = New Size(253, 56)
        btnRiwayatUser.TabIndex = 74
        btnRiwayatUser.Text = "✦ Riwayat"
        btnRiwayatUser.TextAlign = ContentAlignment.MiddleLeft
        btnRiwayatUser.UseVisualStyleBackColor = True
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
        ' btnKeranjang
        ' 
        btnKeranjang.Font = New Font("Bell MT", 14F)
        btnKeranjang.Location = New Point(0, 177)
        btnKeranjang.Name = "btnKeranjang"
        btnKeranjang.Size = New Size(253, 56)
        btnKeranjang.TabIndex = 71
        btnKeranjang.Text = "✦ Keranjang"
        btnKeranjang.TextAlign = ContentAlignment.MiddleLeft
        btnKeranjang.UseVisualStyleBackColor = True
        ' 
        ' btnDaftarBunga
        ' 
        btnDaftarBunga.Font = New Font("Bell MT", 14F)
        btnDaftarBunga.Location = New Point(0, 115)
        btnDaftarBunga.Name = "btnDaftarBunga"
        btnDaftarBunga.Size = New Size(253, 56)
        btnDaftarBunga.TabIndex = 70
        btnDaftarBunga.Text = "✦ Daftar Bunga"
        btnDaftarBunga.TextAlign = ContentAlignment.MiddleLeft
        btnDaftarBunga.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Edwardian Script ITC", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label2.Location = New Point(30, 52)
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
        Label1.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label1.Location = New Point(24, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(145, 52)
        Label1.TabIndex = 68
        Label1.Text = "Blossom"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = My.Resources.Resources.Untitled_design__15_
        PictureBox3.Location = New Point(165, 20)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(88, 70)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 67
        PictureBox3.TabStop = False
        ' 
        ' flpKeranjang
        ' 
        flpKeranjang.AutoScroll = True
        flpKeranjang.BackColor = Color.Transparent
        flpKeranjang.FlowDirection = FlowDirection.TopDown
        flpKeranjang.Location = New Point(276, 0)
        flpKeranjang.Name = "flpKeranjang"
        flpKeranjang.Size = New Size(889, 553)
        flpKeranjang.TabIndex = 3
        flpKeranjang.WrapContents = False
        ' 
        ' lblTotalHarga
        ' 
        lblTotalHarga.AutoSize = True
        lblTotalHarga.BackColor = Color.Transparent
        lblTotalHarga.Font = New Font("Bell MT", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalHarga.ForeColor = Color.Black
        lblTotalHarga.Location = New Point(748, 562)
        lblTotalHarga.Name = "lblTotalHarga"
        lblTotalHarga.Size = New Size(168, 37)
        lblTotalHarga.TabIndex = 100
        lblTotalHarga.Text = "Total: Rp0"
        lblTotalHarga.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' btnBayar
        ' 
        btnBayar.Font = New Font("Lucida Bright", 14F)
        btnBayar.Location = New Point(748, 618)
        btnBayar.Name = "btnBayar"
        btnBayar.Size = New Size(231, 47)
        btnBayar.TabIndex = 101
        btnBayar.Text = "Bayar Sekarang"
        btnBayar.UseVisualStyleBackColor = True
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.Transparent
        PictureBox5.Image = My.Resources.Resources._4
        PictureBox5.Location = New Point(123, 443)
        PictureBox5.Margin = New Padding(2)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(158, 189)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 81
        PictureBox5.TabStop = False
        ' 
        ' Form6
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Beige_and_Green_Vintage_Flower_Store_Instagram_Story__Presentation_
        ClientSize = New Size(1165, 696)
        Controls.Add(btnBayar)
        Controls.Add(lblTotalHarga)
        Controls.Add(flpKeranjang)
        Controls.Add(pnlSidebar)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form6"
        Text = "Form6"
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnRiwayatUser As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnKeranjang As Button
    Friend WithEvents btnDaftarBunga As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents flpKeranjang As FlowLayoutPanel
    Friend WithEvents lblTotalHarga As Label
    Friend WithEvents btnBayar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
End Class
