Public Class Form1

    Private Sub Btn_浏览_Click(sender As Object, e As EventArgs) Handles Btn_浏览.Click
        Dim i As Integer
        Dim iT As Integer

        With OpenFileDialog浏览
            .Multiselect = True     '' ''选取多个文件
            .FileName = ""

            .FilterIndex = 1
            .Title = "浏览文件"
        End With
        
            Try
                gCad_App = GetObject(, "autocad.Application")

            Catch ex As Exception
                MessageBox.Show("请先启动CAD程序" & vbCrLf & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        OpenFileDialog浏览.Filter = "Dwg文件 (*.Dwg)|*.dwg"


        If OpenFileDialog浏览.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                'cstEm = OpenFileDialog浏览.FileNames       '' ''选择的各文件路径。
                iT = OpenFileDialog浏览.FileNames.Count    '' ''选择的文件总数。
                g_i输入文件路径名称Count = iT

                If iT = 1 Then
                    ReDim g_cs输入文件路径名称Array(0 To 0)

                    g_cs输入文件路径名称Array(0) = OpenFileDialog浏览.FileName    '' ''单个文件的路径。
                    ListBox1.Items.Add(g_cs输入文件路径名称Array(0))
                Else
                    ReDim g_cs输入文件路径名称Array(0 To iT - 1)
                    ReDim Preserve g_cs输入文件路径名称Array(0 To iT - 1)
                    For i = 0 To iT - 1
                        ListBox1.Items.Add(g_cs输入文件路径名称Array(i))     '' ''将路径名增加到 cbo_全路径名。
                        g_cs输入文件路径名称Array(i) = g_cs输入文件路径名称Array(i)
                    Next i
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If



    End Sub
End Class
