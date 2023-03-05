Imports Ionic.Zip

Public Class Form2
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TextBox1.PasswordChar = "*"
        TextBox2.PasswordChar = "*"
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        TextBox1.PasswordChar = ""
        TextBox2.PasswordChar = ""
        Timer1.Start()
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Using zip As New ZipFile(Form1.TextBox1.Text)
                Dim ext As ZipEntry
                For Each ext In zip
                    If (ext.UsesEncryption) Then
                        ext.ExtractWithPassword("cache\" & Form1.TextBox1.Text, TextBox1.Text)
                    Else
                        ext.Extract("cache\" & Form1.TextBox1.Text)
                    End If
                Next
            End Using

            Try
                Using zip As New ZipFile
                    If Form3.ComboBox1.Text = "WinZipAes128" Then zip.Encryption = EncryptionAlgorithm.WinZipAes128
                    If Form3.ComboBox1.Text = "WinZipAes256" Then zip.Encryption = EncryptionAlgorithm.WinZipAes256
                    zip.CompressionLevel = Form3.NumericUpDown1.Value

                    zip.Password = TextBox2.Text
                    zip.AddDirectory("cache\" & Form1.TextBox1.Text)
                    zip.Save(Form1.TextBox1.Text)
                End Using
        Catch
                MsgBox("Account does not exist! Try another name!")
            End Try

            If IO.Directory.Exists("cache") Then
                System.IO.Directory.Delete("cache", True) ' Удаляем папку
            Else
            End If

            MsgBox("Password changed successfully!")
        Catch
            MsgBox("Wrong password!")
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class

