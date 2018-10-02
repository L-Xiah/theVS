Namespace BomTable
    Friend Class Frm2_图号名称

        Private Sub Btn_确定_Click(sender As Object, e As EventArgs) Handles Btn_确定.Click
            g_cs总图号 = Txt_图号.Text
            g_cs名称 = Txt_名称.Text
            Me.Close()
        End Sub

        Private Sub Txt_图号_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_图号.KeyDown

            If e.KeyCode = 13 Then
                Txt_名称.Focus()
            End If
        End Sub

        Private Sub Txt_名称_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_名称.KeyDown
            If e.KeyCode = 13 Then
                Btn_确定_Click(sender, e)
            End If
        End Sub


        Private Sub Txt_名称_TextChanged(sender As Object, e As EventArgs) Handles Txt_名称.TextChanged

        End Sub

        Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
            '将窗口恢复普通模式
            'SetWindowPos(Me.Handle, -2, 0, 0, 0, 0, 3)
        End Sub

        Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            '将窗口置于最上面
            'SetWindowPos(Me.Handle, -1, 0, 0, 0, 0, 3)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Txt_图号.Focus()
        End Sub

        Private Sub Txt_图号_TextChanged(sender As Object, e As EventArgs) Handles Txt_图号.TextChanged

        End Sub
    End Class
End Namespace