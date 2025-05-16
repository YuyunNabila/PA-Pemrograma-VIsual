<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        lblTanggal = New Label()
        lblTotal = New Label()
        lblResi = New Label()
        lvDetail = New ListView()
        btnPrint = New Button()
        btnClose = New Button()
        Label1 = New Label()
        PictureBox3 = New PictureBox()
        PictureBox6 = New PictureBox()
        PictureBox5 = New PictureBox()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTanggal
        ' 
        lblTanggal.AutoSize = True
        lblTanggal.BackColor = Color.Transparent
        lblTanggal.Font = New Font("Bell MT", 10F)
        lblTanggal.Location = New Point(152, 116)
        lblTanggal.Margin = New Padding(4, 0, 4, 0)
        lblTanggal.Name = "lblTanggal"
        lblTanggal.Size = New Size(66, 23)
        lblTanggal.TabIndex = 0
        lblTanggal.Text = "Label1"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.Transparent
        lblTotal.Font = New Font("Bell MT", 10F)
        lblTotal.Location = New Point(152, 165)
        lblTotal.Margin = New Padding(4, 0, 4, 0)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(66, 23)
        lblTotal.TabIndex = 1
        lblTotal.Text = "Label2"
        ' 
        ' lblResi
        ' 
        lblResi.AutoSize = True
        lblResi.BackColor = Color.Transparent
        lblResi.Font = New Font("Bell MT", 10F)
        lblResi.Location = New Point(152, 220)
        lblResi.Margin = New Padding(4, 0, 4, 0)
        lblResi.Name = "lblResi"
        lblResi.Size = New Size(66, 23)
        lblResi.TabIndex = 2
        lblResi.Text = "Label3"
        ' 
        ' lvDetail
        ' 
        lvDetail.Font = New Font("Bell MT", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lvDetail.Location = New Point(15, 286)
        lvDetail.Margin = New Padding(4)
        lvDetail.Name = "lvDetail"
        lvDetail.Size = New Size(529, 328)
        lvDetail.TabIndex = 3
        lvDetail.UseCompatibleStateImageBehavior = False
        lvDetail.View = View.Details
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.FromArgb(CByte(228), CByte(228), CByte(210))
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Bell MT", 10F, FontStyle.Bold)
        btnPrint.Location = New Point(140, 622)
        btnPrint.Margin = New Padding(4)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(118, 48)
        btnPrint.TabIndex = 4
        btnPrint.Text = "Print"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.FromArgb(CByte(228), CByte(228), CByte(210))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Bell MT", 10F, FontStyle.Bold)
        btnClose.Location = New Point(15, 622)
        btnClose.Margin = New Padding(4)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(118, 48)
        btnClose.TabIndex = 5
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Edwardian Script ITC", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(119, 18)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(392, 86)
        Label1.TabIndex = 69
        Label1.Text = "Blossom Florist"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(15, 18)
        PictureBox3.Margin = New Padding(2)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(100, 90)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 71
        PictureBox3.TabStop = False
        ' 
        ' PictureBox6
        ' 
        PictureBox6.BackColor = Color.Transparent
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(-38, 112)
        PictureBox6.Margin = New Padding(2)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(153, 168)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 82
        PictureBox6.TabStop = False
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.Transparent
        PictureBox5.Image = My.Resources.Resources._4
        PictureBox5.Location = New Point(437, 91)
        PictureBox5.Margin = New Padding(2)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(158, 189)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 83
        PictureBox5.TabStop = False
        ' 
        ' Form7
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Beige_and_Green_Vintage_Flower_Store_Instagram_Story__Presentation_
        ClientSize = New Size(558, 691)
        Controls.Add(PictureBox5)
        Controls.Add(PictureBox6)
        Controls.Add(PictureBox3)
        Controls.Add(Label1)
        Controls.Add(btnClose)
        Controls.Add(btnPrint)
        Controls.Add(lvDetail)
        Controls.Add(lblResi)
        Controls.Add(lblTotal)
        Controls.Add(lblTanggal)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4)
        Name = "Form7"
        Text = "Form7"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTanggal As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblResi As Label
    Friend WithEvents lvDetail As ListView
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
End Class
