Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices

Public Class Form7
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=bunga_db")
    Dim isDragging As Boolean = False
    Dim offset As Point

    ' Constructor yang menerima data transaksi
    Public Sub New(transaksiID As Integer, totalHarga As Decimal, nomorResi As String)
        InitializeComponent()

        ' Simpan data yang diterima
        Me.TransaksiID = transaksiID
        Me.TotalAmount = totalHarga
        Me.ResiNumber = nomorResi
        Me.TransactionDate = DateTime.Now
    End Sub

    ' Properti untuk data transaksi
    Public Property TransaksiID As Integer
    Public Property ResiNumber As String
    Public Property TotalAmount As Decimal
    Public Property TransactionDate As DateTime

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set animasi form
        AnimateWindow(Me.Handle, 500, AW_ACTIVATE Or AW_BLEND)

        ' Tampilkan data transaksi
        lblResi.Text = "Nomor Resi: " & ResiNumber
        lblTotal.Text = "Total Pembayaran: Rp " & TotalAmount.ToString("N0")
        lblTanggal.Text = "Tanggal Transaksi: " & TransactionDate.ToString("dd MMMM yyyy HH:mm")

        ' Load detail transaksi
        LoadTransactionDetails()
    End Sub

    Private Sub LoadTransactionDetails()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Bersihkan listview terlebih dahulu
            lvDetail.Items.Clear()

            ' Set header listview
            lvDetail.Columns.Clear()
            lvDetail.Columns.Add("No", 40, HorizontalAlignment.Left)
            lvDetail.Columns.Add("Nama Bunga", 200, HorizontalAlignment.Left)
            lvDetail.Columns.Add("Jumlah", 80, HorizontalAlignment.Center)
            lvDetail.Columns.Add("Harga Satuan", 120, HorizontalAlignment.Right)
            lvDetail.Columns.Add("Subtotal", 120, HorizontalAlignment.Right)
            lvDetail.View = View.Details
            lvDetail.FullRowSelect = True

            ' Ambil detail transaksi
            Dim queryDetails As String = "SELECT b.nama, td.jumlah, td.harga_satuan, td.subtotal " &
                                     "FROM transaksi_detail td JOIN bunga b ON td.bunga_id = b.bunga_id " &
                                     "WHERE td.transaksi_id = @TransID"

            Using cmdDetails As New MySqlCommand(queryDetails, conn)
                cmdDetails.Parameters.AddWithValue("@TransID", TransaksiID)

                Using reader As MySqlDataReader = cmdDetails.ExecuteReader()
                    Dim nomor As Integer = 1

                    While reader.Read()
                        ' Tambahkan item ke listview
                        Dim item As New ListViewItem(nomor.ToString())
                        item.SubItems.Add(reader("nama").ToString())
                        item.SubItems.Add(reader("jumlah").ToString())
                        item.SubItems.Add("Rp " & Convert.ToInt32(reader("harga_satuan")).ToString("N0"))
                        item.SubItems.Add("Rp " & Convert.ToInt32(reader("subtotal")).ToString("N0"))

                        lvDetail.Items.Add(item)
                        nomor += 1
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat detail transaksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Fungsi untuk drag form


    ' Tombol cetak
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim printDoc As New Printing.PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf Me.PrintReceipt

            Dim printDialog As New PrintDialog()
            printDialog.Document = printDoc

            If printDialog.ShowDialog() = DialogResult.OK Then
                printDoc.Print()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal mencetak: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintReceipt(sender As Object, e As Printing.PrintPageEventArgs)
        Dim fontHeader As New Font("Bell MT", 16, FontStyle.Bold)
        Dim fontSubHeader As New Font("Bell MT", 12, FontStyle.Bold)
        Dim fontBody As New Font("Bell MT", 10)
        Dim yPos As Integer = 50
        Dim leftMargin As Integer = 50

        ' Judul
        e.Graphics.DrawString("BUKTI PEMBAYARAN", fontHeader, Brushes.Black, leftMargin, yPos)
        yPos += 30

        ' Info toko
        e.Graphics.DrawString("Bloom Florist", fontSubHeader, Brushes.Black, leftMargin, yPos)
        yPos += 20
        e.Graphics.DrawString("Jl. Bunga Indah No. 123", fontBody, Brushes.Black, leftMargin, yPos)
        yPos += 15
        e.Graphics.DrawString("Telp: (021) 12345678", fontBody, Brushes.Black, leftMargin, yPos)
        yPos += 30

        ' Garis
        e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, 750, yPos)
        yPos += 20

        ' Info transaksi
        e.Graphics.DrawString("Nomor Resi: " & ResiNumber, fontBody, Brushes.Black, leftMargin, yPos)
        yPos += 20
        e.Graphics.DrawString("Tanggal: " & TransactionDate.ToString("dd/MM/yyyy HH:mm"), fontBody, Brushes.Black, leftMargin, yPos)
        yPos += 30

        ' Header tabel
        e.Graphics.DrawString("No", fontSubHeader, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString("Nama Bunga", fontSubHeader, Brushes.Black, leftMargin + 50, yPos)
        e.Graphics.DrawString("Jumlah", fontSubHeader, Brushes.Black, leftMargin + 250, yPos)
        e.Graphics.DrawString("Harga", fontSubHeader, Brushes.Black, leftMargin + 350, yPos)
        e.Graphics.DrawString("Subtotal", fontSubHeader, Brushes.Black, leftMargin + 450, yPos)
        yPos += 20

        ' Garis
        e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, 750, yPos)
        yPos += 10

        ' Detail item
        For Each item As ListViewItem In lvDetail.Items
            e.Graphics.DrawString(item.SubItems(0).Text, fontBody, Brushes.Black, leftMargin, yPos)
            e.Graphics.DrawString(item.SubItems(1).Text, fontBody, Brushes.Black, leftMargin + 50, yPos)
            e.Graphics.DrawString(item.SubItems(2).Text, fontBody, Brushes.Black, leftMargin + 250, yPos)
            e.Graphics.DrawString(item.SubItems(3).Text, fontBody, Brushes.Black, leftMargin + 350, yPos)
            e.Graphics.DrawString(item.SubItems(4).Text, fontBody, Brushes.Black, leftMargin + 450, yPos)
            yPos += 20
        Next

        ' Garis
        yPos += 10
        e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, 750, yPos)
        yPos += 20

        ' Total
        e.Graphics.DrawString("TOTAL:", fontSubHeader, Brushes.Black, leftMargin + 350, yPos)
        e.Graphics.DrawString("Rp " & TotalAmount.ToString("N0"), fontSubHeader, Brushes.Black, leftMargin + 450, yPos)
        yPos += 30

        ' Footer
        e.Graphics.DrawString("Terima kasih telah berbelanja", fontSubHeader, Brushes.Black, leftMargin + 150, yPos)
        yPos += 20
        e.Graphics.DrawString("Barang yang sudah dibeli tidak dapat dikembalikan", fontBody, Brushes.Black, leftMargin + 100, yPos)
    End Sub

    ' Tombol tutup
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Windows API untuk animasi window
    <DllImport("user32.dll")>
    Private Shared Function AnimateWindow(ByVal hwnd As IntPtr, ByVal dwTime As Integer, ByVal dwFlags As Integer) As Boolean
    End Function

    Private Const AW_BLEND As Integer = &H80000
    Private Const AW_HIDE As Integer = &H10000
    Private Const AW_ACTIVATE As Integer = &H20000
End Class