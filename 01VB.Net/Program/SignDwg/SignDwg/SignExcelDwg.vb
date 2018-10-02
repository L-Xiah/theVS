Public Class SignExcelDwg


    Private Sub SignExcelDwg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call iInitialize()
        Dim i As Integer

        '------------------------------------------------------------------------------------
        ' 把窗体放在最前面：
        Dim res As Long

        res = SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, 3)
        ' 如果res%=0, 就产生错误

        '    ' 使窗体恢复普通模式:
        '    res = SetWindowPos(FormXXX.hWnd, -2, 0, 0, 0, 0, Flags)

        '------------------------------------------------------------------------------------
        Txt_年.Text = Format(Now(), "yyyy")
        Txt_月.Text = Now.Month
        Txt_日.Text = Now.Day

        'Dim csTemp As String

        'csTemp = vbCrLf & "Sign.Form_Load(  ) 成功 At " + Format(Now(), "yyyy-mm-dd hh:mm:ss") & vbCrLf
        ''    g_acadDocument.Utility.Prompt csTemp + vbCrLf ' vbCrLf

        If g_iDebugFlag = 1 Then ' ==1 本人机器调试标志
            Me.Text = "签名与打印   调试版 V" + Format(Const_dMyVersion, "0.####")
        Else
            Me.Text = "签名(Excel/Dwg)   网络T版 V" + Microsoft.VisualBasic.Strings.Format(Const_dMyVersion, "0.0000")
        End If

        g_cs签名者身份姓名数组(1, 1) = "设计"
        g_cs签名者身份姓名数组(2, 1) = "校对"
        g_cs签名者身份姓名数组(3, 1) = "审核"
        g_cs签名者身份姓名数组(4, 1) = "标检"
        g_cs签名者身份姓名数组(5, 1) = "工艺"
        g_cs签名者身份姓名数组(6, 1) = "批准"
        g_cs签名者身份姓名数组(7, 1) = "竣工"

        For i = 1 To 7
            g_cs签名者身份姓名数组(i, 2) = "0000-无"
            g_cs签名者身份姓名数组(i, 3) = "0000-无"
            g_cs签名者身份姓名数组(i, 4) = Txt_年.Text
            g_cs签名者身份姓名数组(i, 5) = Txt_月.Text
            g_cs签名者身份姓名数组(i, 6) = Txt_日.Text
        Next i

        Cbo_第二签名者姓名.Enabled = False

        '------------------------------------------------------------------------------------
        '   初始化 ComboBox全路径文件名
        Cbo_全路径名.Items.Clear()

        '------------------------------------------------------------------------------------
        '   初始化 OptionButton设计
        Rdb_Excel.Checked = True
        Rdb_设计.Checked = True


        i = i初始化OptionButton文件类型()

        '------------------------------------------------------------------------------------
        If g_iDebugFlag = 1 Then  ' ==1 本人机器调试标志
            If Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5372" Or _
                 Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5097" Or _
                g_csUserName = "ADMINISTRATOR" Then

                Btn_打印.Visible = True
            Else

                Btn_打印.Visible = False
                Btn_打印.Visible = True
            End If
        End If



    End Sub



    Private Function i初始化OptionButton文件类型() As Integer


        If Cbo_全路径名.Items.Count > 0 Then
            Cbo_全路径名.Items.Clear()
            g_i输入文件路径名称Count = 0
        End If

        If Rdb_Dwg.Checked = True Then

            g_cs输入文件类型 = Const_csDwg文件类型

            ' ''Btn_打印.Enabled = True
            ' ''Btn_图层线宽.Enabled = True

            Rdb_设计.Text = " 设 计"

            Rdb_工艺.Enabled = True
            Rdb_批准.Enabled = True
            ' ''Rdb_竣工图.Enabled = True

            Txt_年.Enabled = True
            Txt_月.Enabled = True
            Txt_日.Enabled = True

        ElseIf Rdb_Excel.Checked = True Then

            g_cs输入文件类型 = Const_csXls文件类型

            Btn_打印.Enabled = False
            Btn_图层线宽.Enabled = False

            Rdb_设计.Text = "制 表"

            Rdb_工艺.Enabled = False
            Rdb_批准.Enabled = False
            Rdb_竣工图.Enabled = False

            If Rdb_工艺.Checked = True Or Rdb_批准.Checked = True Then
                Rdb_设计.Checked = True
            End If

            Txt_年.Enabled = False
            Txt_月.Enabled = False
            Txt_日.Enabled = False

        ElseIf Rdb_Word.Checked = True Then

            g_cs输入文件类型 = Const_csDoc文件类型

            Btn_打印.Enabled = False

            Rdb_设计.Text = "制 表"

            Rdb_工艺.Enabled = False
            Rdb_批准.Enabled = False

            Txt_年.Enabled = False
            Txt_月.Enabled = False
            Txt_日.Enabled = False

        End If
        Dim i As Integer
        '------------------------------------------------------------------------------------
        '   初始化 ComboBox签名者姓名
        i = i初始化ComboBox签名者姓名(Cbo_第二签名者姓名)
        i = i初始化ComboBox签名者姓名(Cbo_签名者姓名)

        Rdb_设计.Checked = True

        i初始化OptionButton文件类型 = 0

    End Function

    Private Sub Rdb_Excel_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Excel.CheckedChanged
     
        i初始化OptionButton文件类型()

    End Sub

    Private Sub Rdb_Dwg_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Dwg.CheckedChanged
        If Rdb_Dwg.Checked = False Then
            Exit Sub
        End If

        '------------------------------------------------------------------------------------
        ' 把窗体放在最前面：
        Dim res As Long

        'res = SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, 3)
        ' 如果res%=0, 就产生错误

        '    ' 使窗体恢复普通模式:
        res = SetWindowPos(Me.Handle, -2, 0, 0, 0, 0, 3)

        '------------------------------------------------------------------------------------
        PassWord.ShowDialog()
        res = SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, 3)
        If g_PassWord = 1 Then
            i初始化OptionButton文件类型()
        Else
            Rdb_Excel.Checked = True
        End If

    End Sub

    Private Sub Rdb_Word_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Word.CheckedChanged
        '' ''AutoCAD用, 待开发。
    End Sub

    Private Function i初始化ComboBox签名者姓名(ByVal SubComboBox签名者姓名 As ComboBox) As Integer

        Dim csTemp As String = Nothing
        Dim csUserNameTemp As String
        Dim i组长Flag As Integer

        If SubComboBox签名者姓名 Is Nothing Then
            Cbo_第二签名者姓名.Enabled = False

            Cbo_第二签名者姓名.SelectedIndex = 0

            i初始化ComboBox签名者姓名 = 0
            Exit Function

        ElseIf g_csOptionButton签名者身份 <> "竣工" And _
              (SubComboBox签名者姓名.SelectedText = "" Or SubComboBox签名者姓名.SelectedText = "0000-无") Then
            Cbo_第二签名者姓名.Enabled = False
        Else
            Cbo_第二签名者姓名.Enabled = True
        End If

        If Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "3002" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "3003" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5419" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5503" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "4912" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "4924" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5399" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "4923" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5239" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "3012" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5440" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5097" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "2664" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "2979" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "4682" Or _
             Microsoft.VisualBasic.Strings.Right(g_csUserName, 4) = "5199" Then
            i组长Flag = 1
        Else
            i组长Flag = 0
        End If

        '------------------------------------------------------------------------------------
        '   初始化 ComboBox签名者姓名
        If SubComboBox签名者姓名.Items.Count <> 0 Then
            SubComboBox签名者姓名.Items.Clear()
        End If

        '    If SubComboBox签名者姓名.Name = "ComboBox第二签名者姓名" Then
        '        SubComboBox签名者姓名.AddItem "0000-无"
        '    End If
        SubComboBox签名者姓名.Items.Add("0000-无")

        If Rdb_Dwg.Checked = True Then

            csTemp = Dir(g_cs图片共享目录名 + "\签名图片\*.DWG")

        ElseIf Rdb_Excel.Checked = True Then

            csTemp = Dir(g_cs图片共享目录名 + "\签名图片\*.jpg")

        ElseIf Rdb_Word.Checked = True Then

        End If
        csUserNameTemp = Microsoft.VisualBasic.Strings.Left(csTemp, 4)

        If csTemp = "" Then

            csTemp = vbCrLf & "Sign.Form_Load(  ) 失败 At " + Format(Now(), "yyyy-mm-dd hh:mm:ss") & vbCrLf
            '        g_acadDocument.Utility.Prompt cstemp + vbCrLf ' vbCrLf
            '        MsgBox cstemp + vbCrLf  ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

        Else

            '        If Right(g_csUserName, 4) = csUserNameTemp Or i组长Flag = 1 Then
            SubComboBox签名者姓名.Items.Add(Microsoft.VisualBasic.Strings.Left(csTemp, Len(csTemp) - 4))
            '        End If
        End If

Label_i初始化ComboBox签名者姓名_001:
        csTemp = Dir()
        csUserNameTemp = Microsoft.VisualBasic.Strings.Left(csTemp, 4)
        If csTemp <> "" Then
            '        If Right(g_csUserName, 4) = csUserNameTemp Or i组长Flag = 1 Then
            SubComboBox签名者姓名.Items.Add(Microsoft.VisualBasic.Strings.Left(csTemp, Len(csTemp) - 4))
            '        End If

            GoTo Label_i初始化ComboBox签名者姓名_001
        End If

        '    ComboBox签名者姓名.Text = ComboBox签名者姓名.ListIndex(0)
        If SubComboBox签名者姓名.Items.Count > 0 And SubComboBox签名者姓名.SelectedIndex < 0 Then
            SubComboBox签名者姓名.SelectedIndex = 0
        End If

        i初始化ComboBox签名者姓名 = 0

    End Function

    Private Function i打印与签名按钮() As Integer
        ' 把 ComboBox全路径文件名 中的文件路径名保存到 g_cs输入文件路径名称Array(i) 数组

        Dim i As Integer
        Dim csTemp As String

        csTemp = vbCrLf & "g_iSign_签名与打印Form_返回码 = " + _
                Format(g_iSign_签名与打印Form_返回码, "0 ") + " At " + _
                Format(Now(), "yyyy-mm-dd hh:mm:ss") & vbCrLf
        '    g_acadDocument.Utility.Prompt csTemp + vbCrLf ' vbCrLf
        '    MsgBox csTemp + vbCrLf  ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

        '    g_cs签名者姓名 = ComboBox签名者姓名.Text
        '    g_cs第二签名者姓名 = ComboBox第二签名者姓名.Text

        If Cbo_全路径名.Items.Count = 0 Then
            csTemp = vbCrLf & "请选择 DWG 或 XLS 文件路径与名称!" & vbCrLf
            '        g_acadDocument.Utility.Prompt cstemp + vbCrLf ' vbCrLf
            MsgBox(csTemp + vbCrLf)  ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            g_i输入文件路径名称Count = 0
            i打印与签名按钮 = -1

            Exit Function
        End If

        For i = 0 To Cbo_全路径名.Items.Count - 1

            csTemp = UCase(Microsoft.VisualBasic.Strings.Right(Cbo_全路径名.Items(i), 4))

            If Rdb_Dwg.Checked = True And csTemp <> ".DWG" Or _
                Rdb_Excel.Checked = True And (csTemp <> ".XLS" And csTemp <> "XLSX") Or _
                Rdb_Word.Checked = True And csTemp <> ".DOC" Then

                MsgBox("文件 ‘" + g_cs输入文件路径名称Array(i) + "' 与要处理的类型不一致" + vbCrLf + _
                "请重新选择文件！")  ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                g_i输入文件路径名称Count = i - 1
                If g_i输入文件路径名称Count < 0 Then g_i输入文件路径名称Count = 0

                i打印与签名按钮 = -1

                Exit Function

            End If

            g_cs输入文件路径名称Array(i) = Cbo_全路径名.Items(i)
        Next i

        g_i输入文件路径名称Count = i

        i打印与签名按钮 = 0

    End Function

    Private Sub Btn_浏览_Click(sender As Object, e As EventArgs) Handles Btn_浏览.Click
        Dim i As Integer
        Dim iT As Integer
        Dim cstEm() As String

        With OpenFileDialog浏览
            .Multiselect = True     '' ''选取多个文件
            .FileName = ""

            .FilterIndex = 1
            .Title = "浏览文件"
        End With
        If g_cs输入文件类型 = Const_csXls文件类型 Then
            OpenFileDialog浏览.Filter = "Excel文件 (*.xls;*.xlsx)|*.xls;*.xlsx"
        ElseIf g_cs输入文件类型 = Const_csDwg文件类型 Then
            Try
                gCad_App = GetObject(, "autocad.Application")

            Catch ex As Exception
                MessageBox.Show("请先启动CAD程序" & vbCrLf & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            OpenFileDialog浏览.Filter = "Dwg文件 (*.Dwg)|*.dwg"
        End If

        If OpenFileDialog浏览.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                cstEm = OpenFileDialog浏览.FileNames       '' ''选择的各文件路径。
                iT = OpenFileDialog浏览.FileNames.Count    '' ''选择的文件总数。
                g_i输入文件路径名称Count = iT

                If iT = 1 Then
                    ReDim g_cs输入文件路径名称Array(0 To 0)
                    ReDim cstEm(0 To 0)
                    cstEm(0) = OpenFileDialog浏览.FileName    '' ''单个文件的路径。
                    Cbo_全路径名.Items.Add(cstEm(0))
                Else
                    ReDim g_cs输入文件路径名称Array(0 To iT - 1)
                    ReDim Preserve cstEm(0 To iT - 1)
                    For i = 0 To iT - 1
                        Cbo_全路径名.Items.Add(cstEm(i))     '' ''将路径名增加到 cbo_全路径名。
                        g_cs输入文件路径名称Array(i) = cstEm(i)
                    Next i
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Btn_删除_Click(sender As Object, e As EventArgs) Handles Btn_删除.Click
        Dim i As Integer

        i = Cbo_全路径名.SelectedIndex ' ComboBox 中无项目时 i=-1

        If i >= 0 Then ' ComboBox 中无项目时 i=-1
            Cbo_全路径名.Items.Remove(i)
        End If

        If Cbo_全路径名.Items.Count <= 0 Then
        ElseIf Cbo_全路径名.Items.Count > i Then
            Cbo_全路径名.SelectedIndex = i
        Else
            Cbo_全路径名.SelectedIndex = i - 1
        End If

    End Sub

    Private Sub Btn_清空_Click(sender As Object, e As EventArgs) Handles Btn_清空.Click
        Cbo_全路径名.Items.Clear()
    End Sub

    Private Sub Btn_测试_Click(sender As Object, e As EventArgs) Handles Btn_测试.Click
        '' ''AutoCAD用, 待开发。
    End Sub

    Private Sub Btn_打印_Click(sender As Object, e As EventArgs) Handles Btn_打印.Click
        '' ''AutoCAD用, 待开发。
    End Sub

    Private Sub Btn_签名_Click(sender As Object, e As EventArgs) Handles Btn_签名.Click
        Dim i As Integer

        g_iSign_签名与打印Form_返回码 = 1 ' =0---退出, =1---签名, =2---打印, =3---图层线宽

        ' 把 ComboBox全路径文件名 中的文件路径名保存到 g_cs输入文件路径名称Array(i) 数组
        i = i打印与签名按钮()
        If i = -1 Then
            ''没有路径
            Exit Sub
        End If

        If Rdb_Dwg.Checked = True Then

            '' ''csTemp = vbCrLf & "签名之前将检查图形与所在层的颜色是否一致!" + vbCrLf + vbCrLf + _
            '' ''        "确认要检查吗? (Yes/No)"
            ' '' ''    g_acadDocument.Utility.Prompt csTemp + vbCrLf ' vbCrLf
            '' ''i = MsgBox(csTemp, vbYesNo) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            '' ''If i = vbYes Then
            '' ''    g_i签名前检查图形与层的颜色是否一致Flag = 1
            '' ''Else
            '' ''    g_i签名前检查图形与层的颜色是否一致Flag = 0
            '' ''End If
            Call i200Dwg签名()

        ElseIf Rdb_Excel.Checked = True Then
            Call i300Excel文件签名()
        End If


        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub Btn_图层线宽_Click(sender As Object, e As EventArgs) Handles Btn_图层线宽.Click
        '' ''AutoCAD用, 待开发。
    End Sub

    Private Sub Btn_退出_Click(sender As Object, e As EventArgs) Handles Btn_退出.Click
        Me.Close()
    End Sub


    Private Sub csOptionButton设计校对审核标检工艺批准_Click()
        Dim i As Integer

        Lbl_签名者姓名.Text = "签名者姓名:"
        Lbl_第二签名者姓名.Text = "第二签名者姓名:"
        Lbl_签名日期.Text = "签名日期:"
        Lbl_年.Visible = True
        Lbl_月.Visible = True
        Lbl_日.Visible = True
        Txt_年.Width = 54
        Txt_月.Visible = True
        Txt_日.Visible = True

        Chk_竣工章许可编号.Visible = False

        If g_csOptionButton签名者身份 = "设计" Then
            Cbo_签名者姓名.Text = g_cs签名者身份姓名数组(1, 2)
            Cbo_第二签名者姓名.Text = g_cs签名者身份姓名数组(1, 3)
            Txt_年.Text = g_cs签名者身份姓名数组(1, 4)
            Txt_月.Text = g_cs签名者身份姓名数组(1, 5)
            Txt_日.Text = g_cs签名者身份姓名数组(1, 6)
        End If

        If g_csOptionButton签名者身份 = "校对" Then
            Cbo_签名者姓名.Text = g_cs签名者身份姓名数组(2, 2)
            Cbo_第二签名者姓名.Text = g_cs签名者身份姓名数组(2, 3)
            Txt_年.Text = g_cs签名者身份姓名数组(2, 4)
            Txt_月.Text = g_cs签名者身份姓名数组(2, 5)
            Txt_日.Text = g_cs签名者身份姓名数组(2, 6)
        End If

        If g_csOptionButton签名者身份 = "审核" Then
            Cbo_签名者姓名.Text = g_cs签名者身份姓名数组(3, 2)
            Cbo_第二签名者姓名.Text = g_cs签名者身份姓名数组(3, 3)
            Txt_年.Text = g_cs签名者身份姓名数组(3, 4)
            Txt_月.Text = g_cs签名者身份姓名数组(3, 5)
            Txt_日.Text = g_cs签名者身份姓名数组(3, 6)
        End If

        If g_csOptionButton签名者身份 = "标检" Then
            Cbo_签名者姓名.Text = g_cs签名者身份姓名数组(4, 2)
            Cbo_第二签名者姓名.Text = g_cs签名者身份姓名数组(4, 3)
            Txt_年.Text = g_cs签名者身份姓名数组(4, 4)
            Txt_月.Text = g_cs签名者身份姓名数组(4, 5)
            Txt_日.Text = g_cs签名者身份姓名数组(4, 6)
        End If

        If g_csOptionButton签名者身份 = "工艺" Then
            Cbo_签名者姓名.Text = g_cs签名者身份姓名数组(5, 2)
            Cbo_第二签名者姓名.Text = g_cs签名者身份姓名数组(5, 3)
            Txt_年.Text = g_cs签名者身份姓名数组(5, 4)
            Txt_月.Text = g_cs签名者身份姓名数组(5, 5)
            Txt_日.Text = g_cs签名者身份姓名数组(5, 6)
        End If

        If g_csOptionButton签名者身份 = "批准" Then
            Cbo_签名者姓名.Text = g_cs签名者身份姓名数组(6, 2)
            Cbo_第二签名者姓名.Text = g_cs签名者身份姓名数组(6, 3)
            Txt_年.Text = g_cs签名者身份姓名数组(6, 4)
            Txt_月.Text = g_cs签名者身份姓名数组(6, 5)
            Txt_日.Text = g_cs签名者身份姓名数组(6, 6)
        End If

        If g_csOptionButton签名者身份 = "竣工" Then
            Cbo_签名者姓名.Text = g_cs签名者身份姓名数组(7, 2)
            Cbo_第二签名者姓名.Text = g_cs签名者身份姓名数组(7, 3)
            Txt_年.Text = g_cs签名者身份姓名数组(7, 4)
            Txt_月.Text = g_cs签名者身份姓名数组(7, 5)
            Txt_日.Text = g_cs签名者身份姓名数组(7, 6)

            Lbl_签名者姓名.Text = "修改人姓名:"
            Lbl_第二签名者姓名.Text = "技术审核人姓名:"
            Lbl_签名日期.Text = "产品令号:"
            Lbl_年.Visible = False
            Lbl_月.Visible = False
            Lbl_日.Visible = False
            Txt_年.Width = Cbo_第二签名者姓名.Width
            Txt_月.Visible = False
            Txt_日.Visible = False
            Chk_竣工章许可编号.Visible = True
            If Txt_年.Text = Format(Now(), "yyyy") Then
                Txt_年.Text = ""
            End If

        End If

        If g_csOptionButton签名者身份 = "竣工" Then

            For i = 1 To 6
                g_cs签名者身份姓名数组(i, 2) = "0000-无"
                g_cs签名者身份姓名数组(i, 3) = "0000-无"
            Next i

        Else

            g_cs签名者身份姓名数组(7, 2) = "0000-无"
            g_cs签名者身份姓名数组(7, 3) = "0000-无"

        End If

        If (Cbo_签名者姓名.Text = "0000-无" Or _
            Rdb_标检.Checked = True Or _
            Rdb_工艺.Checked = True Or _
            Rdb_批准.Checked = True) And _
            g_csOptionButton签名者身份 <> "竣工" _
            Then

            Cbo_第二签名者姓名.Text = "0000-无"
            Cbo_第二签名者姓名.Enabled = False
        Else
            Cbo_第二签名者姓名.Enabled = True
        End If

    End Sub

    Private Sub Rdb_设计_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_设计.CheckedChanged
        Dim i As Integer
        i = i初始化ComboBox签名者姓名(Cbo_第二签名者姓名)
        i = i初始化ComboBox签名者姓名(Cbo_签名者姓名)

        g_csOptionButton签名者身份 = "设计"

        '    g_cs签名者身份 = g_csOptionButton签名者身份 ' 多重签名可注释掉

        Call csOptionButton设计校对审核标检工艺批准_Click()
    End Sub

    Private Sub Rdb_校对_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_校对.CheckedChanged
        Dim i As Integer
        i = i初始化ComboBox签名者姓名(Cbo_第二签名者姓名)
        i = i初始化ComboBox签名者姓名(Cbo_签名者姓名)

        g_csOptionButton签名者身份 = "校对"

        '    g_cs签名者身份 = g_csOptionButton签名者身份 ' 多重签名可注释掉

        Call csOptionButton设计校对审核标检工艺批准_Click()

    End Sub

    Private Sub Rdb_审核_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_审核.CheckedChanged
        Dim i As Integer
        i = i初始化ComboBox签名者姓名(Cbo_第二签名者姓名)
        i = i初始化ComboBox签名者姓名(Cbo_签名者姓名)

        g_csOptionButton签名者身份 = "审核"

        '    g_cs签名者身份 = g_csOptionButton签名者身份 ' 多重签名可注释掉

        Call csOptionButton设计校对审核标检工艺批准_Click()

    End Sub

    Private Sub Rdb_标检_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_标检.CheckedChanged
        Dim i As Integer
        i = i初始化ComboBox签名者姓名(Cbo_签名者姓名)

        g_csOptionButton签名者身份 = "标检"

        '    g_cs签名者身份 = g_csOptionButton签名者身份 ' 多重签名可注释掉

        Call csOptionButton设计校对审核标检工艺批准_Click()

    End Sub

    Private Sub Rdb_工艺_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_工艺.CheckedChanged
        Dim i As Integer

        i = i初始化ComboBox签名者姓名(Cbo_签名者姓名)

        g_csOptionButton签名者身份 = "工艺"

        '    g_cs签名者身份 = g_csOptionButton签名者身份 ' 多重签名可注释掉

        Call csOptionButton设计校对审核标检工艺批准_Click()

    End Sub

    Private Sub Rdb_批准_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_批准.CheckedChanged
        Dim i As Integer
        i = i初始化ComboBox签名者姓名(Cbo_签名者姓名)

        g_csOptionButton签名者身份 = "批准"

        '    g_cs签名者身份 = g_csOptionButton签名者身份 ' 多重签名可注释掉

        Call csOptionButton设计校对审核标检工艺批准_Click()

    End Sub

    Private Sub Rdb_竣工图_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_竣工图.CheckedChanged
        Dim i As Integer
        i = i初始化ComboBox签名者姓名(Cbo_第二签名者姓名)
        i = i初始化ComboBox签名者姓名(Cbo_签名者姓名)

        g_csOptionButton签名者身份 = "竣工"

        '    g_cs签名者身份 = g_csOptionButton签名者身份 ' 多重签名可注释掉

        Call csOptionButton设计校对审核标检工艺批准_Click()

    End Sub


    Private Sub cs签名者姓名_Click()

        If g_csOptionButton签名者身份 = "设计" Then
            '        g_cs签名者身份姓名数组(1, 1) = g_csOptionButton签名者身份
            g_cs签名者身份姓名数组(1, 2) = Cbo_签名者姓名.Text
            g_cs签名者身份姓名数组(1, 3) = Cbo_第二签名者姓名.Text
            g_cs签名者身份姓名数组(1, 4) = Txt_年.Text
            g_cs签名者身份姓名数组(1, 5) = Txt_月.Text
            g_cs签名者身份姓名数组(1, 6) = Txt_日.Text

        ElseIf g_csOptionButton签名者身份 = "校对" Then
            '        g_cs签名者身份姓名数组(2, 1) = g_csOptionButton签名者身份
            g_cs签名者身份姓名数组(2, 2) = Cbo_签名者姓名.Text
            g_cs签名者身份姓名数组(2, 3) = Cbo_第二签名者姓名.Text
            g_cs签名者身份姓名数组(2, 4) = Txt_年.Text
            g_cs签名者身份姓名数组(2, 5) = Txt_月.Text
            g_cs签名者身份姓名数组(2, 6) = Txt_日.Text

        ElseIf g_csOptionButton签名者身份 = "审核" Then
            '        g_cs签名者身份姓名数组(3, 1) = g_csOptionButton签名者身份
            g_cs签名者身份姓名数组(3, 2) = Cbo_签名者姓名.Text
            g_cs签名者身份姓名数组(3, 3) = Cbo_第二签名者姓名.Text
            g_cs签名者身份姓名数组(3, 4) = Txt_年.Text
            g_cs签名者身份姓名数组(3, 5) = Txt_月.Text
            g_cs签名者身份姓名数组(3, 6) = Txt_日.Text

        ElseIf g_csOptionButton签名者身份 = "标检" Then
            '        g_cs签名者身份姓名数组(4, 1) = g_csOptionButton签名者身份
            g_cs签名者身份姓名数组(4, 2) = Cbo_签名者姓名.Text
            g_cs签名者身份姓名数组(4, 3) = Cbo_第二签名者姓名.Text
            g_cs签名者身份姓名数组(4, 4) = Txt_年.Text
            g_cs签名者身份姓名数组(4, 5) = Txt_月.Text
            g_cs签名者身份姓名数组(4, 6) = Txt_日.Text

        ElseIf g_csOptionButton签名者身份 = "工艺" Then
            '        g_cs签名者身份姓名数组(5, 1) = g_csOptionButton签名者身份
            g_cs签名者身份姓名数组(5, 2) = Cbo_签名者姓名.Text
            g_cs签名者身份姓名数组(5, 3) = Cbo_第二签名者姓名.Text
            g_cs签名者身份姓名数组(5, 4) = Txt_年.Text
            g_cs签名者身份姓名数组(5, 5) = Txt_月.Text
            g_cs签名者身份姓名数组(5, 6) = Txt_日.Text

        ElseIf g_csOptionButton签名者身份 = "批准" Then
            '        g_cs签名者身份姓名数组(6, 1) = g_csOptionButton签名者身份
            g_cs签名者身份姓名数组(6, 2) = Cbo_签名者姓名.Text
            g_cs签名者身份姓名数组(6, 3) = Cbo_第二签名者姓名.Text
            g_cs签名者身份姓名数组(6, 4) = Txt_年.Text
            g_cs签名者身份姓名数组(6, 5) = Txt_月.Text
            g_cs签名者身份姓名数组(6, 6) = Txt_日.Text

        ElseIf g_csOptionButton签名者身份 = "竣工" Then
            '        g_cs签名者身份姓名数组(7, 1) = g_csOptionButton签名者身份
            g_cs签名者身份姓名数组(7, 2) = Cbo_签名者姓名.Text
            g_cs签名者身份姓名数组(7, 3) = Cbo_第二签名者姓名.Text
            g_cs签名者身份姓名数组(7, 4) = Txt_年.Text
            g_cs签名者身份姓名数组(7, 5) = Txt_月.Text
            g_cs签名者身份姓名数组(7, 6) = Txt_日.Text

        End If

    End Sub

    Private Sub Cbo_签名者姓名_GotFocus(sender As Object, e As EventArgs) Handles Cbo_签名者姓名.GotFocus
        g_iComboBox签名者姓名GotFocus = 1
    End Sub

    Private Sub Cbo_签名者姓名_LostFocus(sender As Object, e As EventArgs) Handles Cbo_签名者姓名.LostFocus
        g_iComboBox签名者姓名GotFocus = 0
    End Sub

    Private Sub Cbo_签名者姓名_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_签名者姓名.SelectedIndexChanged
        If (Cbo_签名者姓名.Text = "0000-无" Or _
            Rdb_标检.Checked = True Or _
            Rdb_工艺.Checked = True Or _
            Rdb_批准.Checked = True) And _
            g_csOptionButton签名者身份 <> "竣工" _
            Then

            Cbo_第二签名者姓名.Text = "0000-无"
            Cbo_第二签名者姓名.Enabled = False
        Else
            Cbo_第二签名者姓名.Enabled = True
        End If

        If g_iComboBox签名者姓名GotFocus = 1 Then
            Call cs签名者姓名_Click()
        End If

    End Sub

    Private Sub Cbo_第二签名者姓名_GotFocus(sender As Object, e As EventArgs) Handles Cbo_第二签名者姓名.GotFocus
        g_iComboBox第二签名者姓名GotFocus = 1
    End Sub

    Private Sub Cbo_第二签名者姓名_LostFocus(sender As Object, e As EventArgs) Handles Cbo_第二签名者姓名.LostFocus
        g_iComboBox第二签名者姓名GotFocus = 0
    End Sub

    Private Sub Cbo_第二签名者姓名_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_第二签名者姓名.SelectedIndexChanged
        If g_iComboBox第二签名者姓名GotFocus = 1 Then
            Call cs签名者姓名_Click()
        End If
    End Sub

    Private Sub Txt_年_GotFocus(sender As Object, e As EventArgs) Handles Txt_年.GotFocus
        g_iTextBox年GotFocus = 1
    End Sub

    Private Sub Txt_年_LostFocus(sender As Object, e As EventArgs) Handles Txt_年.LostFocus
        g_iTextBox年GotFocus = 0
    End Sub

    Private Sub Txt_年_TextChanged(sender As Object, e As EventArgs) Handles Txt_年.TextChanged
        If g_iTextBox年GotFocus = 1 Then
            Call cs签名者姓名_Click()
        End If
    End Sub

    Private Sub Txt_月_GotFocus(sender As Object, e As EventArgs) Handles Txt_月.GotFocus
        g_iTextBox月GotFocus = 1
    End Sub

    Private Sub Txt_月_LostFocus(sender As Object, e As EventArgs) Handles Txt_月.LostFocus
        g_iTextBox月GotFocus = 0
    End Sub

    Private Sub Txt_月_TextChanged(sender As Object, e As EventArgs) Handles Txt_月.TextChanged
        If g_iTextBox月GotFocus = 1 Then
            Call cs签名者姓名_Click()
        End If
    End Sub

    Private Sub Txt_日_GotFocus(sender As Object, e As EventArgs) Handles Txt_日.GotFocus
        g_iTextBox日GotFocus = 1
    End Sub

    Private Sub Txt_日_LostFocus(sender As Object, e As EventArgs) Handles Txt_日.LostFocus
        g_iTextBox日GotFocus = 0
    End Sub

    Private Sub Txt_日_TextChanged(sender As Object, e As EventArgs) Handles Txt_日.TextChanged
        If g_iTextBox日GotFocus = 1 Then
            Call cs签名者姓名_Click()
        End If
    End Sub



End Class
