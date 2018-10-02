Namespace BomTable
    Friend Class Frm4_OverShow

        Private Sub Frm4_OverShow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
            '将窗口恢复普通模式
            'SetWindowPos(Me.Handle, -2, 0, 0, 0, 0, 3)
        End Sub

        Private Sub Frm4_OverShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            '将窗口置于最上面
            'SetWindowPos(Me.Handle, -1, 0, 0, 0, 0, 3)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

        End Sub


        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Me.Close()
        End Sub

        Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
            If e.KeyCode = 13 Then
                Me.Close()
            End If
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End Sub
    End Class
End Namespace