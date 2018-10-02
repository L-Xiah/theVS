Public Class PassWord

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If TextBox1.Text.Length = 6 And e.KeyCode = Keys.Enter Then
            If TextBox1.Text = "123456" Then
                g_PassWord = 1
                Me.Close()
            Else
                MessageBox.Show("口令错误！", "Password", MessageBoxButtons.OK)
            End If
        End If

    End Sub

    
  
    Private Sub PassWord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "说明：警告Dwg图纸不能使用电子签名！！！" & vbCrLf & "要使用该功能，输入6位口令按回车。"
        TextBox1.Text = ""
        g_PassWord = 0
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class