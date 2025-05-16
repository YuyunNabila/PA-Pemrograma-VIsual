<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        pnlSidebar = New Panel()
        PictureBox6 = New PictureBox()
        btnRiwayatUser = New Button()
        btnLogout = New Button()
        btnKeranjang = New Button()
        btnDaftarBunga = New Button()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox3 = New PictureBox()
        PictureBox1 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox2 = New PictureBox()
        flpRiwayat = New FlowLayoutPanel()
        PictureBox5 = New PictureBox()
        pnlSidebar.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.Controls.Add(PictureBox5)
        pnlSidebar.Controls.Add(PictureBox6)
        pnlSidebar.Controls.Add(btnRiwayatUser)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Controls.Add(btnKeranjang)
        pnlSidebar.Controls.Add(btnDaftarBunga)
        pnlSidebar.Controls.Add(Label2)
        pnlSidebar.Controls.Add(Label1)
        pnlSidebar.Controls.Add(PictureBox3)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Margin = New Padding(2)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(276, 696)
        pnlSidebar.TabIndex = 82
        ' 
        ' PictureBox6
        ' 
        PictureBox6.BackColor = Color.Transparent
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(-101, 314)
        PictureBox6.Margin = New Padding(2)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(315, 310)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 79
        PictureBox6.TabStop = False
        ' 
        ' btnRiwayatUser
        ' 
        btnRiwayatUser.Font = New Font("Bell MT", 14F)
        btnRiwayatUser.Location = New Point(0, 239)
        btnRiwayatUser.Margin = New Padding(2)
        btnRiwayatUser.Name = "btnRiwayatUser"
        btnRiwayatUser.Size = New Size(252, 56)
        btnRiwayatUser.TabIndex = 74
        btnRiwayatUser.Text = "✦ Riwayat"
        btnRiwayatUser.TextAlign = ContentAlignment.MiddleLeft
        btnRiwayatUser.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.Font = New Font("Bell MT", 14F)
        btnLogout.Location = New Point(0, 638)
        btnLogout.Margin = New Padding(2)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(252, 56)
        btnLogout.TabIndex = 73
        btnLogout.Text = "✦ Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnKeranjang
        ' 
        btnKeranjang.Font = New Font("Bell MT", 14F)
        btnKeranjang.Location = New Point(0, 178)
        btnKeranjang.Margin = New Padding(2)
        btnKeranjang.Name = "btnKeranjang"
        btnKeranjang.Size = New Size(252, 56)
        btnKeranjang.TabIndex = 71
        btnKeranjang.Text = "✦ Keranjang"
        btnKeranjang.TextAlign = ContentAlignment.MiddleLeft
        btnKeranjang.UseVisualStyleBackColor = True
        ' 
        ' btnDaftarBunga
        ' 
        btnDaftarBunga.Font = New Font("Bell MT", 14F)
        btnDaftarBunga.Location = New Point(0, 115)
        btnDaftarBunga.Margin = New Padding(2)
        btnDaftarBunga.Name = "btnDaftarBunga"
        btnDaftarBunga.Size = New Size(252, 56)
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
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(30, 52)
        Label2.Margin = New Padding(2, 0, 2, 0)
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
        Label1.Margin = New Padding(2, 0, 2, 0)
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
        PictureBox3.Margin = New Padding(2)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(88, 70)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 67
        PictureBox3.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(934, -54)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(195, 300)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 87
        PictureBox1.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(862, 290)
        PictureBox4.Margin = New Padding(2)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(412, 448)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 84
        PictureBox4.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(194, 450)
        PictureBox2.Margin = New Padding(2)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(275, 300)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 83
        PictureBox2.TabStop = False
        ' 
        ' flpRiwayat
        ' 
        flpRiwayat.AutoScroll = True
        flpRiwayat.BackColor = Color.Transparent
        flpRiwayat.Location = New Point(293, 20)
        flpRiwayat.Margin = New Padding(2)
        flpRiwayat.Name = "flpRiwayat"
        flpRiwayat.Size = New Size(859, 662)
        flpRiwayat.TabIndex = 86
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.Transparent
        PictureBox5.Image = My.Resources.Resources._4
        PictureBox5.Location = New Point(155, 450)
        PictureBox5.Margin = New Padding(2)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(158, 189)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 80
        PictureBox5.TabStop = False
        ' 
        ' Form8
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Beige_and_Green_Vintage_Flower_Store_Instagram_Story__Presentation_
        ClientSize = New Size(1165, 696)
        Controls.Add(pnlSidebar)
        Controls.Add(flpRiwayat)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox2)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4)
        Name = "Form8"
        Text = "Form8"
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnRiwayatUser As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnKeranjang As Button
    Friend WithEvents btnDaftarBunga As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox

    Private Sub flpRiwayat_Paint(sender As Object, e As PaintEventArgs) Handles flpRiwayat.Paint

    End Sub

    Friend WithEvents flpRiwayat As FlowLayoutPanel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
End Class
