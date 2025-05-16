Imports MySql.Data.MySqlClient

Module Module1
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public da As MySqlDataAdapter
    Public dr As MySqlDataReader
    Public dt As DataTable

    Public connectionString As String = "server=localhost;user id=root;password=;database=bunga_db"

    Public Sub BukaKoneksi()
        conn = New MySqlConnection(connectionString)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal koneksi ke database: " & ex.Message)
        End Try
    End Sub

    Public Sub TutupKoneksi()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menutup koneksi: " & ex.Message)
        End Try
    End Sub
End Module
