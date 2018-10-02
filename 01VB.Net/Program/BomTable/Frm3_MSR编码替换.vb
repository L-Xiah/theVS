Namespace BomTable
    Friend Class Frm3_MSR编码替换

        Dim IsNewP As Boolean
        Dim msr_Workbook As Microsoft.Office.Interop.Excel.Workbook = Nothing

        Private Sub Frm3_MSR编码替换_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

            '将窗口恢复普通模式
            'SetWindowPos(Me.Handle, -2, 0, 0, 0, 0, 3)
        End Sub

        Private Sub Frm3_MSR编码替换_Load(sender As Object, e As EventArgs) Handles MyBase.Load


            IsNewP = False
            g_csL类型 = 100
            ''TEST
            'g_cs总图号 = "0928-31-HPDT-010D"
            'g_MSRrep替换部分 = "0928-31-HPDT"
            'Try
            '    g_ExcelAppObj = GetObject(, "Excel.Application")
            'Catch ex As Exception
            '    g_ExcelAppObj = CreateObject("Excel.Application")
            'End Try


            ''以上为测试
            '将窗口置于最上面
            'SetWindowPos(Me.Handle, -1, 0, 0, 0, 0, 3)

            Label4.Text = g_cs总图号
            TextBox1.Text = g_MSRrep替换部分

            Try
                msr_Workbook = g_ExcelAppObj.Workbooks.Open(g_MSR编码替换Path, [ReadOnly]:=False)
            Catch ex As Exception
                g_csL类型 = 101
                MessageBox.Show(g_MSR编码替换Path & vbCrLf & "不能打开", "Error", MessageBoxButtons.OK)
                Me.Close()
            End Try

            ListBox1.Items.Add("原编码         替换方案")

            Dim i As Integer

            i = 2
            Do While msr_Workbook.Worksheets(1).cells(i, 1).value <> Nothing
                If g_MSRrep替换部分.ToUpper = CStr(msr_Workbook.Worksheets(1).cells(i, 1).value).ToUpper Then
                    g_rep替换成MSR = msr_Workbook.Worksheets(1).cells(i, 2).value
                    IsNewP = False
                End If
                shA(i - 2) = msr_Workbook.Worksheets(1).cells(i, 1).value & Chr(9) & msr_Workbook.Worksheets(1).cells(i, 2).value

                i = i + 1
                If i = 43 Then
                    ReDim Preserve shA(0 To 80)
                ElseIf i = 83 Then
                    ReDim Preserve shA(0 To 150)
                End If


            Loop
            ReDim Preserve shA(0 To i - 3)

            For i = shA.Length - 1 To 0 Step -1


                ListBox1.Items.Add(shA(i))
            Next i

            If IsNewP = True Then
                With g_zzb正则表达式
                    .Pattern = "[a-z][a-z]([a-z][a-z])?"
                    .IgnoreCase = True
                    .Global = False
                    If .Test(g_MSRrep替换部分) = True Then
                        For Each item In .Execute(g_MSRrep替换部分) '遍历所有符合条件的对象
                            g_rep替换成MSR = "M" & item.value  ' 将所有符合条件的对象串连起来

                        Next item

                        g_rep替换成MSR = g_rep替换成MSR & Format(shA.Length + 1, "0000")
                        IsNewP = True

                    End If

                End With
            End If

            TextBox2.Text = g_rep替换成MSR

            Button1.Focus()

        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            If IsNewP = True Then
                g_rep替换成MSR = TextBox2.Text
                If g_rep替换成MSR <> "" Then
                    g_csL类型 = 1
                End If
                Dim i As Integer = shA.Length
                msr_Workbook.Worksheets(1).cells(i + 2, 1).value = g_MSRrep替换部分
                msr_Workbook.Worksheets(1).cells(i + 2, 2).value = g_rep替换成MSR
                msr_Workbook.Worksheets(1).cells(i + 2, 3).value = g_cs总图号
                msr_Workbook.Worksheets(1).cells(i + 2, 4).value = g_cs总图号.Replace(g_MSRrep替换部分, g_rep替换成MSR)
            Else
                g_csL类型 = 1
            End If

            msr_Workbook.Close(True)

            Me.Close()
        End Sub

        Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
            If e.KeyCode = 13 Then
                Button1_Click(sender, e)
            End If
        End Sub
    End Class
End Namespace