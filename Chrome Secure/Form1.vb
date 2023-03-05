Imports Ionic.Zip

Public Class Form1
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If IO.Directory.Exists("bin\" & TextBox1.Text) Then
            System.IO.Directory.Delete("bin\" & TextBox1.Text, True) ' Удаляем папку
        Else
        End If

        Try
            Using zip As New ZipFile(TextBox1.Text)
                Dim ext As ZipEntry
                For Each ext In zip
                    If (ext.UsesEncryption) Then
                        ext.ExtractWithPassword("bin\" & TextBox1.Text, TextBox2.Text)
                    Else
                        ext.Extract("bin\" & TextBox1.Text)
                    End If
                Next
            End Using

            NotifyIcon1.Text = "Chrome is run! To disable, close Chrome!"
            NotifyIcon1.Visible = True
            Me.Hide()
            Try
                IO.Directory.CreateDirectory("bin\" & TextBox1.Text)
                Dim App As New Process
                App.StartInfo.UseShellExecute = False
                App.StartInfo.RedirectStandardOutput = True
                App.StartInfo.FileName = "bin/chrome"
                App.StartInfo.Arguments = "--user-data-dir=" & TextBox1.Text
                App.Start()
                App.WaitForExit()
            Catch
                Dim intReturnValue As Integer
                intReturnValue = MsgBox("Chrome not found! Please download the official installer (https://www.google.com/chrome) and move the downloaded files to the /bin folder! The program also supports Chromium, it is necessary that the executable file (chrome.exe) be in the /bin folder!", MessageBoxIcon.Stop)
                If (intReturnValue = MsgBoxResult.Ok) Then
                    Process.Start("https://www.google.com/chrome")
                End If
            End Try

            NotifyIcon1.Visible = False


            Try
                If Form3.CheckBox2.Checked = True Then


                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\Default\Service Worker\CacheStorage") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\Default\Service Worker\CacheStorage", True) ' Удаляем папку CacheStorage
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\Default\Cache") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\Default\Cache", True) ' Удаляем папку Cache
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\Default\Code Cache") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\Default\Code Cache", True) ' Удаляем папку Code Cache
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\Default\GPUCache") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\Default\GPUCache", True) ' Удаляем папку GPUCache
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\Default\DawnCache") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\Default\DawnCache", True) ' Удаляем папку DawnCache
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\BrowserMetrics") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\BrowserMetrics", True) ' Удаляем папку BrowserMetrics
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\pnacl") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\pnacl", True) ' Удаляем папку pnacl
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\GrShaderCache") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\GrShaderCache", True) ' Удаляем папку GrShaderCache
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\ShaderCache") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\ShaderCache", True) ' Удаляем папку ShaderCache
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\OnDeviceHeadSuggestModel") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\OnDeviceHeadSuggestModel", True) ' Удаляем папку OnDeviceHeadSuggestModel
                    Else
                    End If

                    If IO.Directory.Exists("bin\" & TextBox1.Text & "\Default\Storage") Then
                        System.IO.Directory.Delete("bin\" & TextBox1.Text & "\Default\Storage", True) ' Удаляем папку Storage
                    Else
                    End If

                End If
            Catch
            End Try

            Try
                Using zip As New ZipFile
                    If Form3.ComboBox1.Text = "WinZipAes128" Then zip.Encryption = EncryptionAlgorithm.WinZipAes128
                    If Form3.ComboBox1.Text = "WinZipAes256" Then zip.Encryption = EncryptionAlgorithm.WinZipAes256
                    zip.CompressionLevel = Form3.NumericUpDown1.Value
                    zip.Password = TextBox2.Text
                    zip.AddDirectory("bin\" & TextBox1.Text)
                    zip.Save(TextBox1.Text)
                End Using
            Catch
                If IO.Directory.Exists("bin\" & TextBox1.Text) Then
                    System.IO.Directory.Delete("bin\" & TextBox1.Text, True)
                Else
                End If

                MsgBox("It is not possible to process the archive, the process is busy! Data not saved!" & vbCrLf & "The program will be restarted...")
                Application.Restart()

            End Try

            If IO.Directory.Exists("bin\" & TextBox1.Text) Then
                System.IO.Directory.Delete("bin\" & TextBox1.Text, True) ' Удаляем папку
            Else
            End If


            If Form3.CheckBox1.Checked = True Then

                If IO.Directory.Exists("bin\" & TextBox1.Text) Then
                    System.IO.Directory.Delete("bin\" & TextBox1.Text, True)
                Else
                End If

                Me.Close()
            End If
            If Form3.CheckBox1.Checked = False Then

                If IO.Directory.Exists("bin\" & TextBox1.Text) Then
                    System.IO.Directory.Delete("bin\" & TextBox1.Text, True)
                Else
                End If

                Me.Show()
            End If

        Catch
            MsgBox("Wrong password!" & vbCrLf & TextBox4.Text & TextBox3.Text, vbCritical)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TextBox2.PasswordChar = "*"
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        TextBox2.PasswordChar = ""
        Timer1.Start()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        MessageBox.Show("Creating a new user occurs after entering a new account name!", "Chrome Secure", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form2.ShowDialog()
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Button2.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form3.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Hide()
        TextBox3.Hide()
        Button3.Hide()

        If IO.Directory.Exists("bin\" & TextBox1.Text) Then
            System.IO.Directory.Delete("bin\" & TextBox1.Text, True)
        Else
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        Process.Start(Application.StartupPath)
    End Sub

    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Label3.Show()
        TextBox3.Show()
        Button3.Show()
        Button2.Hide()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox4.Text = "Message: "
        Label3.Hide()
        TextBox3.Hide()
        Button3.Hide()
        Button2.Show()
    End Sub
End Class

