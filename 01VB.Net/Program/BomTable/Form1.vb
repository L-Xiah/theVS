Namespace BomTable
    Friend Class Form1

#Region "窗体事件"

        Private Sub Btn_浏览_Click(sender As Object, e As EventArgs) Handles Btn_浏览.Click
            Lst_文件.Items.Clear()
            With OpenFileDialog浏览
                .Multiselect = True     '' ''选取多个文件
                .FileName = ""
                .Filter = "Excel文件 (*.xls;*.xlsx)|*.xls;*.xlsx"
                .FilterIndex = 1
                .Title = "浏览文件"
            End With
            If OpenFileDialog浏览.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    g_cs输入文件路径名称Array = OpenFileDialog浏览.FileNames       '' ''选择的各文件路径。
                    g_cs输入文件名称List = OpenFileDialog浏览.SafeFileNames
                    g_w文件Count = OpenFileDialog浏览.FileNames.Length     '' ''选择的文件总数。


                    If g_w文件Count = 1 Then
                        ReDim Preserve g_cs输入文件路径名称Array(0 To 0)
                        ReDim Preserve g_cs输入文件名称List(0 To 0)
                        g_cs输入文件路径名称Array(0) = OpenFileDialog浏览.FileName    '' ''单个文件的路径。
                        g_cs输入文件名称List(0) = OpenFileDialog浏览.SafeFileName     '' ''文件名称
                        Lst_文件.Items.Add(OpenFileDialog浏览.SafeFileName)
                    Else
                        ReDim Preserve g_cs输入文件路径名称Array(0 To g_w文件Count - 1)
                        ReDim Preserve g_cs输入文件名称List(0 To g_w文件Count - 1)
                        For i = 0 To g_w文件Count - 1
                            Lst_文件.Items.Add(g_cs输入文件名称List(i))     '' ''将路径名增加到 cbo_全路径名。
                        Next i
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
            For Each Item In g_ExcelAppObj.Workbooks
                Item.Close()
            Next

            g_ExcelAppObj = Nothing
        End Sub

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            '将窗口置于最上面
            'SetWindowPos(Me.Handle, -1, 0, 0, 0, 0, 3)
            Ini_初始化()

        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            ErrorMsg = Nothing

            Dim i, j, k As Byte
            Dim nI, nSucc, nKK As Byte
            Dim nTemp As Integer
            Dim hz_WorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            nSucc = 0
            g_ExcelAppObj.Visible = True
            g_ExcelAppObj.DisplayAlerts = False
            Me.Text = "程序运行中……"
            For i = 0 To g_w文件Count - 1
                g_wcs当前父物料(0) = 0
                g_wcs当前父物料(1) = 0
                g_wcs当前父物料(2) = 0
                g_wcs当前父物料(3) = 0
                Try
                    g_zWorkbook = g_ExcelAppObj.Workbooks.Open(g_cs输入文件路径名称Array(i), [ReadOnly]:=False)
                Catch ex As Exception
                    'ErrorMsg = ex.Message
                    'MessageBox.Show(g_cs输入文件路径名称Array(i) & vbCrLf & "不能打开", "Error", MessageBoxButtons.OK)
                    GoTo lineNext
                End Try
                nKK = 0  ''清单下面连续空行，超过30行判断清单结束
                g_ExcelAppObj.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
                g_zWorkbook.Activate()    ''后面代码需要焦点
                ''MessageBox.Show(g_ExcelAppObj.ActiveWorkbook.Name, "123", MessageBoxButtons.OK)

                If Name_清单名称() = False Then  ''物料清单名称图号
                    GoTo lineNext
                End If

                InsertTempTable(g_zWorkbook)   ''插入三张物料表
                nTemp = 3
                Using Gui_字段 As New Class_MaterialsStandard
                    For j = 1 To c_Num清单Max
                        Try
                            hz_WorkSheet = g_zWorkbook.Worksheets("第" & g_hz(j) & "页")
                        Catch ex As Exception
                            ErrorMsg = ex.Message
                            'MessageBox.Show(g_cs输入文件名称List(i) & vbCrLf & "第" & g_hz(j) & "页" & "不能打开", "Error", MessageBoxButtons.OK)
                            GoTo lineERP001
                        End Try
                        For k = 5 To 34
                            If hz_WorkSheet.Cells(k, 2).value = Nothing And hz_WorkSheet.Cells(k, 3).value = Nothing Then
                                If Strings.Replace(CStr(hz_WorkSheet.Cells(k, 4).value), " ", "") = "总重" Then
                                    g_TableForERP.Cells(2, 8) = hz_WorkSheet.Cells(k, 8).value
                                    GoTo lineERP001
                                Else
                                    nKK = nKK + 1
                                    If nKK > 30 Then
                                        GoTo lineERP001
                                    End If
                                End If
                                GoTo lineForK001
                            Else
                                nKK = 0
                            End If

                            g_Temptable.Cells(nTemp, 1) = "p" & j & "-" & k
                            For nI = 2 To 12
                                g_Temptable.Cells(nTemp, nI) = hz_WorkSheet.Cells(k, nI).value
                            Next
                            Gui_字段.N = nTemp
                            Gui_字段.Gui_字段规范()
                            nTemp = nTemp + 1
lineForK001:
                        Next k
                    Next j
lineERP001:


                    ''物料数量,单重重新整理
                    If Kg_物料重量() = False Then
                        GoTo lineNext
                    End If
                    hz_WorkSheet = Nothing

                    With g_zzb正则表达式
                        .Pattern = "清单[AB]|[AB]产品"
                        .IgnoreCase = True
                        .Global = False
                        If .Test(g_cs输入文件名称List(i)) = True Then
                            Erp_物料清单AB(g_cs输入文件名称List(i))  ''生成产品物料清单
                        Else
                            Erp_物料清单()  ''生成零件物料清单
                        End If
                    End With



                    nSucc = nSucc + 1
                End Using

lineNext:
                g_zWorkbook.Close(True)

                g_Temptable = Nothing
                g_TableForERP = Nothing
                g_Table借用 = Nothing
                g_zWorkbook = Nothing

            Next i



            If nSucc > 0 Then
                '将窗口恢复普通模式
                'SetWindowPos(Me.Handle, -2, 0, 0, 0, 0, 3)

                Using Frm4_OverShow = New Frm4_OverShow
                    Frm4_OverShow.Text = "物料清单生成"
                    Frm4_OverShow.Label1.Text = "共有" & nSucc & "张物料清单生成完毕！！"
                    Frm4_OverShow.ShowDialog()
                End Using

                '将窗口置于最上面
                'SetWindowPos(Me.Handle, -1, 0, 0, 0, 0, 3)

            End If
            g_ExcelAppObj.DisplayAlerts = True
            'g_ExcelAppObj.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
            ''g_ExcelAppObj = Nothing
            Me.Text = "物料编码集成程序V" & Format(cVer, "0.00")



        End Sub

        Private Sub Btn_查物料_Click(sender As Object, e As EventArgs) Handles Btn_查物料.Click

            'Me.WindowState = FormWindowState.Minimized
            Try
                System.IO.File.Copy(g_winApp物料代码, g_DwinApp, True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK)
                Exit Sub
            End Try
            Dim i As Integer = 0
            If i = 0 Then
                Shell(g_DwinApp, AppWinStyle.NormalFocus)
                Exit Sub
            End If


            Dim nK As Integer
            Dim table_Temp As Microsoft.Office.Interop.Excel.Worksheet = Nothing
            For i = 0 To g_w文件Count - 1


                Try
                    g_zWorkbook = g_ExcelAppObj.Workbooks(g_cs输入文件名称List(i))

                Catch ex As Exception
                    Try
                        g_zWorkbook = g_ExcelAppObj.Workbooks.Open(g_cs输入文件路径名称Array(i), [ReadOnly]:=False)
                    Catch ex2 As Exception
                        MessageBox.Show(g_cs输入文件路径名称Array(i) & vbCrLf & "不能打开", "Error", MessageBoxButtons.OK)
                        GoTo lineNext_查物料
                    End Try

                End Try
                Me.Text = g_zWorkbook.Name & "……查物料"
                Using sapMatch As New Class_MaterialsAccess
                    If sapMatch.IsAdoConn = False Then
                        GoTo LineError_查物料
                    End If
                    Dim shd As Class_MaterialsAccess.PropertyMaterSAP

                    ''借用表查询
                    If dirSheet(strSheetName2, g_zWorkbook) = False Then
                        GoTo lineNext_查物料
                    End If
                    table_Temp = g_zWorkbook.Worksheets(strSheetName2)
                    nK = 2  ''借用表第二行开始
                    Do While table_Temp.Cells(nK, 10).value <> Nothing OrElse table_Temp.Cells(nK + 1, 10).value <> Nothing OrElse table_Temp.Cells(nK + 2, 10).value <> Nothing
                        If table_Temp.Cells(nK, 10).value = Nothing Then
                            GoTo lineWhile001_查物料
                        End If
                        sapMatch.MaterSAP = table_Temp.Cells(nK, 5).value
                        sapMatch.MaterSAP描述 = table_Temp.Cells(nK, 6).value
                        sapMatch.Matching_Sap()
                        If sapMatch.IsSAP = True Then
                            table_Temp.Cells(nK, 5) = sapMatch.GetMaterSAP
                        End If
lineWhile001_查物料:
                        nK = nK + 1
                    Loop

                    ''TableForERP表查询申请
                    If dirSheet(strSheetName1, g_zWorkbook) = False Then
                        GoTo lineNext_查物料
                    End If
                    table_Temp = g_zWorkbook.Worksheets(strSheetName1)
                    nK = 2  ''TableForERP表第二行开始
                    If table_Temp.Cells(2, 5).value = "" Then
                        MessageBox.Show("缺少头物料", "Error")
                        GoTo lineNext_查物料
                    End If
                    sapMatch.ProductNo = table_Temp.Cells(2, 5).value
                    Do While table_Temp.Cells(nK, 10).value <> Nothing OrElse table_Temp.Cells(nK + 1, 10).value <> Nothing OrElse table_Temp.Cells(nK + 2, 10).value <> Nothing
                        If table_Temp.Cells(nK, 6).value = Nothing Then
                            GoTo lineWhile002_查物料
                        End If
                        sapMatch.MaterSAP = table_Temp.Cells(nK, 5).value
                        sapMatch.MaterSAP描述 = table_Temp.Cells(nK, 6).value
                        sapMatch.Matching_Sap()
                        If sapMatch.IsSAP = True Then
                            table_Temp.Cells(nK, 5) = sapMatch.GetMaterSAP

                            If sapMatch.intSapSearch = 1 Then   ''原有图号
                                table_Temp.Cells(nK, 5).Font.ColorIndex = 3         ' 字体颜色
                                table_Temp.Cells(nK, 5).Interior.ColorIndex = 34    ' 图案底纹(背景)颜色
                                ' ''rangeObj.Interior.Pattern = i图案样式Sub ' xlVertical 图案样式垂直条纹
                                ' ''rangeObj.Interior.PatternColorIndex = i图案颜色Sub ' xlAutomatic ' 图案前景颜色
                            ElseIf sapMatch.intSapSearch = 16 Then  ''已有申请生成
                                table_Temp.Cells(nK, 5).Font.ColorIndex = 4         ' 字体颜色
                                table_Temp.Cells(nK, 5).Interior.ColorIndex = 34    ' 图案底纹(背景)颜色
                            ElseIf sapMatch.intSapSearch = 32 Then   ''本申请
                                table_Temp.Cells(nK, 5).Font.ColorIndex = 5         ' 字体颜色
                                table_Temp.Cells(nK, 5).Interior.ColorIndex = 36    ' 图案底纹(背景)颜色
                            ElseIf sapMatch.intSapSearch = 64 Then  ''本生成
                                table_Temp.Cells(nK, 5).Font.ColorIndex = 5         ' 字体颜色
                                table_Temp.Cells(nK, 5).Interior.ColorIndex = 34    ' 图案底纹(背景)颜色

                            End If
                        Else
                            shd.Name = table_Temp.Cells(nK, 35).value
                            shd.Materials = table_Temp.Cells(nK, 36).value
                            shd.ArcSpecification = table_Temp.Cells(nK, 37).value
                            shd.FigureNum = table_Temp.Cells(nK, 38).value
                            shd.QualityAssuranceClass = table_Temp.Cells(nK, 39).value
                            shd.NuvlearSafetyClass = table_Temp.Cells(nK, 40).value
                            shd.Remarks = table_Temp.Cells(nK, 41).value
                            shd.FullDescribe = table_Temp.Cells(nK, 34).value
                            sapMatch.materialsStru = shd
                            sapMatch.AddSAP()
                            table_Temp.Cells(nK, 5) = sapMatch.GetMaterSAP
                        End If
lineWhile002_查物料:
                        nK = nK + 1
                    Loop


                    'sapMatch.IsWriteSAP()
                End Using
lineNext_查物料:
            Next

LineError_查物料:
            Me.Text = "物料编码集成程序V" & Format(cVer, "0.00")

        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

            Dim nSucc As Byte
            Dim i, j, nK As Integer

            Dim table_Temp As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            Me.Text = "程序运行中……"
            nSucc = 0
            g_ExcelAppObj.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            For i = 0 To g_w文件Count - 1


                Try
                    g_zWorkbook = g_ExcelAppObj.Workbooks(g_cs输入文件名称List(i))

                Catch ex As Exception
                    Try
                        g_zWorkbook = g_ExcelAppObj.Workbooks.Open(g_cs输入文件路径名称Array(i), [ReadOnly]:=False)
                    Catch ex2 As Exception
                        ErrorMsg = ex.Message
                        'MessageBox.Show(g_cs输入文件路径名称Array(i) & vbCrLf & "不能打开", "Error", MessageBoxButtons.OK)
                        GoTo lineNext
                    End Try

                End Try

                For j = 1 To 2
                    If j = 1 Then  ''tableForERP表返回编码
                        If dirSheet(strSheetName1, g_zWorkbook) = False Then
                            GoTo lineNext
                        End If
                        table_Temp = g_zWorkbook.Worksheets(strSheetName1)
                        nK = 3
                    ElseIf j = 2 Then  ''借用表返回编码
                        If dirSheet(strSheetName2, g_zWorkbook) = False Then
                            GoTo lineNext
                        End If
                        table_Temp = g_zWorkbook.Worksheets(strSheetName2)
                        nK = 2
                    End If


                    Dim nP, npL As Integer
                    Dim nP_str As String
                    Dim npTempstr() As String
                    Dim table_Range As Microsoft.Office.Interop.Excel.Range
                    Do While table_Temp.Cells(nK, 10).value <> Nothing OrElse table_Temp.Cells(nK + 1, 10).value <> Nothing OrElse table_Temp.Cells(nK + 2, 10).value <> Nothing
                        If table_Temp.Cells(nK, 10).value = Nothing Then
                            GoTo lineWhile001
                        ElseIf CStr(table_Temp.Cells(nK, 10).value).Substring(0, 1).ToUpper <> "P" Then
                            GoTo lineNext
                        End If
                        nP = CInt(Val(CStr(table_Temp.Cells(nK, 10).value).Substring(1)))
                        npTempstr = CStr(table_Temp.Cells(nK, 10).value).Split("-")
                        nP_str = "第" & g_hz(nP) & "页"
                        Try
                            npL = CInt(Val(npTempstr(1)))
                            g_zWorkbook.Worksheets(nP_str).cells(npL, 13) = "'" & table_Temp.Cells(nK, 5).value
                            table_Range = g_zWorkbook.Worksheets(nP_str).cells(npL, 13)
                            table_Range.ShrinkToFit = True
                            g_zWorkbook.Worksheets(nP_str).cells(npL, 27) = table_Temp.Cells(nK, 10).value
                        Catch ex As Exception
                            MessageBox.Show(table_Temp.Name & "中第" & nK & "行，所对应的清单页有问题！" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK)
                            GoTo lineNext
                        End Try

lineWhile001:
                        nK = nK + 1
                    Loop
                Next j

                g_zWorkbook.Save()

                nSucc = nSucc + 1
lineNext:
                table_Temp = Nothing
                g_zWorkbook = Nothing
            Next i

            If nSucc > 0 Then

                '将窗口恢复普通模式
                'SetWindowPos(Me.Handle, -2, 0, 0, 0, 0, 3)

                Using Frm4_OverShow = New Frm4_OverShow
                    Frm4_OverShow.Text = "物料清单生成"
                    Frm4_OverShow.Label1.Text = "共有" & nSucc & "张清单返回编码完毕！！"
                    Frm4_OverShow.ShowDialog()
                End Using

                '将窗口置于最上面
                'SetWindowPos(Me.Handle, -1, 0, 0, 0, 0, 3)

            End If
            'g_ExcelAppObj.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized

            Me.Text = "物料编码集成程序V" & Format(cVer, "0.00")

        End Sub


#End Region


#Region "初始化"

        Private Sub Ini_初始化()

            Me.Text = "物料编码集成程序V" & Format(cVer, "0.00")
            Dim i As Integer
            For i = 1 To c_Num清单Max
                NumToUp(i, g_hz(i))   ''''一、二、三
            Next

            'Try
            '    g_ExcelAppObj = GetObject(, "Excel.Application")
            'Catch ex As Exception
            '    g_ExcelAppObj = CreateObject("Excel.Application")
            'End Try

            g_ExcelAppObj = CreateObject("Excel.Application")
            g_zzb正则表达式 = CreateObject("VBScript.RegExp")

            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.Width = Me.Button1.Right + 30
            Me.Height = Me.Lst_文件.Bottom + 50


            ReDim Conversion(0 To My.Settings.Properties.Count + 9, 0 To 1)
            Dim tempStr(0 To 1) As String  ''0-9常用的紧固件
            Conversion(0, 0) = "GB827" : Conversion(0, 1) = "标牌铆钉"
            Conversion(1, 0) = "GB97.2" : Conversion(1, 1) = "钢平垫圈"
            Conversion(2, 0) = "GB91" : Conversion(2, 1) = "开口销"
            Conversion(3, 0) = "GB799" : Conversion(3, 1) = "地脚螺栓"
            Conversion(4, 0) = "GB5780" : Conversion(4, 1) = "钢六角螺栓"
            Conversion(5, 0) = "GB5781" : Conversion(5, 1) = "钢六角螺栓"
            Conversion(6, 0) = "GB5782" : Conversion(6, 1) = "钢六角螺栓"
            Conversion(7, 0) = "GB5783" : Conversion(7, 1) = "钢六角螺栓"
            Conversion(8, 0) = "GB5785" : Conversion(8, 1) = "钢六角螺栓"
            Conversion(9, 0) = "GB6170" : Conversion(9, 1) = "钢六角螺母"
            i = 10
            For Each item As System.Configuration.SettingsProperty In My.Settings.Properties
                tempStr = item.DefaultValue.ToString.Split("$")
                Conversion(i, 0) = tempStr(0) : Conversion(i, 1) = tempStr(1) : i = i + 1
                'Debug.Print(i & "--" & item.Name & item.DefaultValue)
            Next


        End Sub

        ''数字转换成汉字标识（一、一十五）
        Private Sub NumToUp(ByVal i As Integer, ByRef upStr As String)
            Dim j, k, h As Byte
            If i > 1000 Then
                Exit Sub

            End If
            j = Int(i / 100)
            k = Int((i Mod 100) / 10)
            h = Int((i Mod 100) Mod 10)

            Dim upBstr, upSstr, upGstr As String
            upBstr = "" : upSstr = "" : upGstr = ""
            If j > 0 Then
                Select Case j
                    Case 9 : upBstr = "九百"
                    Case 8 : upBstr = "八百"
                    Case 7 : upBstr = "七百"
                    Case 6 : upBstr = "六百"
                    Case 5 : upBstr = "五百"
                    Case 4 : upBstr = "四百"
                    Case 3 : upBstr = "三百"
                    Case 2 : upBstr = "二百"
                    Case 1 : upBstr = "一百"
                End Select
                If k = 0 And h > 0 Then
                    upSstr = "零"
                End If
            End If
            If k > 0 Then
                Select Case k
                    Case 9 : upSstr = "九十"
                    Case 8 : upSstr = "八十"
                    Case 7 : upSstr = "七十"
                    Case 6 : upSstr = "六十"
                    Case 5 : upSstr = "五十"
                    Case 4 : upSstr = "四十"
                    Case 3 : upSstr = "三十"
                    Case 2 : upSstr = "二十"
                    Case 1 : upSstr = "十"
                        If j > 0 Then
                            upSstr = "一十"
                        End If
                End Select
            End If
            If h > 0 Then
                Select Case h
                    Case 9 : upGstr = "九"
                    Case 8 : upGstr = "八"
                    Case 7 : upGstr = "七"
                    Case 6 : upGstr = "六"
                    Case 5 : upGstr = "五"
                    Case 4 : upGstr = "四"
                    Case 3 : upGstr = "三"
                    Case 2 : upGstr = "二"
                    Case 1 : upGstr = "一"
                End Select
            End If

            upStr = upBstr & upSstr & upGstr



        End Sub

#End Region


#Region "子程序"

        ''确定物料清单名称图号
        Private Function Name_清单名称() As Boolean
            Name_清单名称 = False

            Dim hName_WorkSheet As Microsoft.Office.Interop.Excel.Worksheet

            Try
                hName_WorkSheet = g_zWorkbook.Worksheets("标题")
                If hName_WorkSheet.Cells(2, 6).value <> Nothing Then
                    g_cs总图号 = g_zWorkbook.Worksheets("标题").cells(2, 6).value
                    g_cs名称 = g_zWorkbook.Worksheets("标题").cells(2, 2).value
                    GoTo lineTo继续
                ElseIf hName_WorkSheet.Cells(1, 6).value <> Nothing Then
                    g_cs总图号 = g_zWorkbook.Worksheets("标题").cells(1, 6).value
                    g_cs名称 = g_zWorkbook.Worksheets("标题").cells(1, 2).value
                    GoTo lineTo继续

                End If
            Catch ex As Exception

            End Try

            Try
                hName_WorkSheet = g_zWorkbook.Worksheets("第" & g_hz(1) & "页")
                If g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(3, 10).value <> Nothing Then
                    g_cs总图号 = g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(3, 10).value
                    g_cs名称 = g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(3, 6).value
                    GoTo lineTo继续
                ElseIf g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(2, 6).value <> Nothing OrElse g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(2, 7).value <> Nothing Then
                    g_cs总图号 = g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(2, 10).value & g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(2, 11).value & g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(2, 12).value
                    g_cs名称 = g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(2, 6).value & g_zWorkbook.Worksheets("第" & g_hz(1) & "页").cells(2, 7).value
                    GoTo lineTo继续

                End If
            Catch ex As Exception
                MessageBox.Show(g_zWorkbook.Name & vbCrLf & "第" & g_hz(1) & "页" & "不能打开", "Error", MessageBoxButtons.OK)
                Return False
            End Try


lineTo继续:

            '将窗口恢复普通模式
            'SetWindowPos(Me.Handle, -2, 0, 0, 0, 0, 3)

            Using Frm2_图号名称 = New Frm2_图号名称
                Frm2_图号名称.Txt_图号.Text = g_cs总图号
                Frm2_图号名称.Txt_名称.Text = g_cs名称
                Frm2_图号名称.ShowDialog()
            End Using

            '将窗口置于最上面
            'SetWindowPos(Me.Handle, -1, 0, 0, 0, 0, 3)
            If g_cs总图号 = "" Then
                MessageBox.Show("缺少总图号！", "Error", MessageBoxButtons.OK)
                Return False
            ElseIf g_cs名称 = "" Then
                MessageBox.Show("缺少名称！", "Error", MessageBoxButtons.OK)
                Return False
            End If

            With g_zzb正则表达式
                .Pattern = "\b[0-9][0-9][0-9][0-9]-[0-9][0-9]-[a-z][a-z]([a-z][a-z])?"  ''0818-31-ms
                .IgnoreCase = True                                                      ''忽略大小写
                .Global = False
                If .Test(g_cs总图号) = True Then
                    g_csL类型 = 1   ''MSR项目
                    Dim SHmsr = .Execute(g_cs总图号)
                    g_MSRrep替换部分 = SHmsr(0).VALUE
                    '将窗口恢复普通模式
                    'SetWindowPos(Me.Handle, -2, 0, 0, 0, 0, 3)

                    Using Frm3_MSR编码替换 = New Frm3_MSR编码替换
                        Frm3_MSR编码替换.ShowDialog()
                    End Using

                    '将窗口置于最上面
                    'SetWindowPos(Me.Handle, -1, 0, 0, 0, 0, 3)

                    If g_csL类型 <> 1 Then
                        Return False
                    End If
                End If
            End With

            Return True
        End Function

        ''''物料数量,单重重新整理
        Private Function Kg_物料重量() As Boolean

            Kg_物料重量 = True
            Dim nj, nY, nAInt_物料系数 As Integer
            nj = 4
            nAInt_物料系数 = CInt(g_Temptable.Cells(3, 5).value)
            If Val(g_Temptable.Cells(3, 7).value) <= 0 AndAlso Val(g_Temptable.Cells(3, 8).value) > 0 Then
                g_Temptable.Cells(3, 7) = Val(g_Temptable.Cells(3, 8).value)

            End If

            Do While g_Temptable.Cells(nj, 2).value <> Nothing

                If Val(g_Temptable.Cells(nj, 7).value) <= 0 AndAlso Val(g_Temptable.Cells(nj, 8).value) > 0 Then
                    g_Temptable.Cells(nj, 7) = Val(g_Temptable.Cells(nj, 8).value)

                End If


                If CInt(g_Temptable.Cells(nj, 22).value) > CInt(g_Temptable.Cells(nj - 1, 22).value) AndAlso nAInt_物料系数 > 1 Then
                    nY = nj
                    Do While CInt(g_Temptable.Cells(nY, 22).value) > CInt(g_Temptable.Cells(nj - 1, 22).value) AndAlso g_Temptable.Cells(nj, 2).value <> Nothing
                        Dim nTempE As Integer
                        nTempE = CInt(g_Temptable.Cells(nY, 5).value) Mod nAInt_物料系数
                        g_Temptable.Cells(nY, 5) = CInt(g_Temptable.Cells(nY, 5).value) / nAInt_物料系数
                        If nTempE = 1 OrElse CInt(g_Temptable.Cells(nY, 5).value) <= 0 Then
                            MessageBox.Show(g_zWorkbook.Name & "的" & g_Temptable.Name & "表第" & nY & "行，数量有问题！", "Error", MessageBoxButtons.OK)
                            Return False
                        End If

                        nY = nY + 1
                    Loop

                End If


                nAInt_物料系数 = CInt(g_Temptable.Cells(nj, 5).value)
                nj = nj + 1
            Loop


        End Function

        ''生成物料产品清单AB
        Private Sub Erp_物料清单AB(ByVal qName As String)
            Dim nff_strCs As String     '总图号
            Dim nff_strMs As String     '总图号描述
            Dim isA As Boolean = False  'True =清单A
            Dim isBZ As Boolean = False 'true=包装
            Dim str_GD As String        '高低加
            Dim str_BZ As String = Nothing  '
            Dim str_BT As String = Nothing
            With g_zzb正则表达式
                .Pattern = "清单B|B产品"
                .IgnoreCase = True
                .Global = False
                If .Test(qName) = True Then
                    isBZ = True
                    nff_strCs = g_cs总图号 & "BZ"
                    .Pattern = "[低高]"
                    If .Test(g_cs名称) = True Then
                        .Pattern = "低"
                        If .Test(g_cs名称) = True Then
                            str_GD = "低加"
                            nff_strMs = "低压加热器系统发包装件_" & nff_strCs
                        Else
                            str_GD = "高加"
                            nff_strMs = "高压加热器系统发包装件_" & nff_strCs
                        End If
                    Else
                        str_GD = g_cs名称
                        nff_strMs = g_cs名称 & "发包装件_" & nff_strCs
                    End If
                Else
                    isA = True
                    nff_strCs = g_cs总图号
                    .Pattern = "[低高]"
                    If .Test(g_cs名称) = True Then
                        .Pattern = "低"
                        If .Test(g_cs名称) = True Then
                            str_GD = "低加"
                            nff_strMs = "低压加热器系统_" & nff_strCs
                            str_BZ = "低压加热器系统发包装件"
                            str_BT = "低压加热器系统包装装置"
                        Else
                            str_GD = "高加"
                            nff_strMs = "高压加热器系统_" & nff_strCs
                            str_BZ = "高压加热器系统发包装件"
                            str_BT = "高压加热器系统包装装置"
                        End If
                    Else
                        str_GD = g_cs名称
                        nff_strMs = g_cs名称 & "_" & nff_strCs
                        str_BZ = g_cs名称 & "发包装件"
                        str_BT = g_cs名称 & "包装装置"
                    End If
                End If

            End With

            g_TableForERP.Cells(2, 5) = nff_strCs
            g_TableForERP.Cells(2, 6) = nff_strMs

            Dim nff_tempstrCs, nff_tempstrMs As String   '总图号及描述
            nff_tempstrCs = nff_strCs : nff_tempstrMs = nff_strMs
            Dim nJ, nN, nErp As Integer
            Dim isXT As Boolean = False

            nN = 1 ''序号‘’10、20 ***110等
            nErp = 3 : nJ = 3
            Do While g_Temptable.Cells(nJ, 2).value <> Nothing OrElse g_Temptable.Cells(nJ, 3).value <> Nothing
                If g_Temptable.Cells(nJ, 2).value = Nothing Then

                    If isA = True Then  ''清单A
                        If isXT = False Then
                            g_TableForERP.Cells(nErp, 1) = nff_strCs
                            g_TableForERP.Cells(nErp, 2) = nff_strMs
                            g_TableForERP.Cells(nErp, 3) = 1
                            g_TableForERP.Cells(nErp, 4) = nN & "0" : nN = nN + 1
                            g_TableForERP.Cells(nErp, 5) = nff_strCs & "HC"
                            g_TableForERP.Cells(nErp, 6) = str_GD & "焊材_" & nff_strCs & "HC"
                            g_TableForERP.Cells(nErp, 7) = 1
                            nErp = nErp + 1
                            g_TableForERP.Cells(nErp, 1) = nff_strCs
                            g_TableForERP.Cells(nErp, 2) = nff_strMs
                            g_TableForERP.Cells(nErp, 3) = 1
                            g_TableForERP.Cells(nErp, 4) = nN & "0" : nN = nN + 1
                            g_TableForERP.Cells(nErp, 5) = nff_strCs & "GL"
                            g_TableForERP.Cells(nErp, 6) = str_GD & "工艺用料_" & nff_strCs & "GL"
                            g_TableForERP.Cells(nErp, 7) = 1
                            nErp = nErp + 1
                            g_TableForERP.Cells(nErp, 1) = nff_strCs
                            g_TableForERP.Cells(nErp, 2) = nff_strMs
                            g_TableForERP.Cells(nErp, 3) = 1
                            g_TableForERP.Cells(nErp, 4) = nN & "0" : nN = nN + 1
                            g_TableForERP.Cells(nErp, 5) = nff_strCs & "BZ"
                            g_TableForERP.Cells(nErp, 6) = str_BZ & "_" & nff_strCs & "BZ"
                            g_TableForERP.Cells(nErp, 7) = 1
                            nErp = nErp + 1
                            g_TableForERP.Cells(nErp, 1) = nff_strCs
                            g_TableForERP.Cells(nErp, 2) = nff_strMs
                            g_TableForERP.Cells(nErp, 3) = 1
                            g_TableForERP.Cells(nErp, 4) = nN & "0" : nN = nN + 1
                            g_TableForERP.Cells(nErp, 5) = nff_strCs & "BT"
                            g_TableForERP.Cells(nErp, 6) = str_BT & "_" & nff_strCs & "BT"
                            g_TableForERP.Cells(nErp, 7) = 1
                            nErp = nErp + 1
                            isXT = True
                        End If
                        With g_zzb正则表达式
                            .Pattern = "包装(运输)?装置"
                            If .Test(g_Temptable.Cells(nJ, 3).value) = True Then
                                nN = 1 : isBZ = False : nErp = nErp + 1
                                nff_tempstrCs = nff_strCs & "BT"
                                nff_tempstrMs = str_BT & "_" & nff_strCs & "BT"
                            Else
                                If isBZ = False Then
                                    nErp = nErp + 1
                                    nN = 1 : isBZ = True
                                    nff_tempstrCs = nff_strCs & "BZ"
                                    nff_tempstrMs = str_BZ & "_" & nff_strCs & "BZ"
                                End If
                            End If
                        End With
                    End If
                    nJ = nJ + 1 : Continue Do
                End If


                ''复制数据到TableForErp/借用表
                Call CopyTableForErp(nErp, nJ, g_TableForERP)

                g_TableForERP.Cells(nErp, 1) = nff_tempstrCs
                g_TableForERP.Cells(nErp, 2) = nff_tempstrMs
                g_TableForERP.Cells(nErp, 4) = nN & "0" : nN = nN + 1
                If isBZ = True Then
                    g_TableForERP.Cells(nErp, 11) = "包装"
                    g_TableForERP.Cells(nErp, 18) = "Z"
                End If
                ''装箱备注
                With g_zzb正则表达式
                    .Pattern = "针阀|截止阀"
                    If .Test(g_Temptable.Cells(nJ, 15).value) = True Then
                        g_TableForERP.Cells(nErp, 17) = g_Temptable.Cells(nJ, 12).value
                    End If
                End With

                nErp = nErp + 1
                nJ = nJ + 1
            Loop


            '自动排列
            Call AutoArrange()

        End Sub

        ''生成物料零件清单
        Private Sub Erp_物料清单()

            If g_csL类型 = 1 Then
                ''0818-31-MS项目
                g_TableForERP.Cells(2, 5) = g_cs总图号.Replace(g_MSRrep替换部分, g_rep替换成MSR)
            Else
                g_TableForERP.Cells(2, 5) = g_cs总图号
            End If
            g_TableForERP.Cells(2, 6) = g_cs名称 & "_" & g_cs总图号


            Dim p As Integer
            Dim nCj, nErp As Integer
            Dim panTF, panJY, panffX As Integer
            Dim table_temp As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            panffX = 0
            g_tf层级物料序号 = 3
            panTF = 3   ''tableforerp表序号增加空行用
            g_jy层级物料序号 = 2
            panJY = 2  ''借用表序号增加空行用

            Dim nJ As Integer
            Dim nff As Integer          '父物料序号
            Dim nff_strTemp As String  ''临时物料
            Dim nff_strCs As String     '判断借用物料的字符串'
            Dim slen As Integer = 7    ''判断借用物料的长度
            nff_strCs = g_cs总图号
            If g_csL类型 = 1 Then
                ''0818-31-MS项目
                slen = g_rep替换成MSR.Length
                nff_strCs = g_rep替换成MSR
            End If

            For p = 1 To g_Max层级
                nJ = 3

                Do While g_Temptable.Cells(nJ, 2).value <> Nothing
                    nCj = CInt(g_Temptable.Cells(nJ, 22).value)
                    If nCj <> p Then
                        nJ = nJ + 1 : Continue Do
                    End If

                    If nCj = 1 Then
                        nErp = g_tf层级物料序号
                        g_TableForERP.Cells(nErp, 1) = g_TableForERP.Cells(2, 5).value
                        g_TableForERP.Cells(nErp, 2) = g_TableForERP.Cells(2, 6).value
                        g_TableForERP.Cells(nErp, 3) = 1
                        g_TableForERP.Cells(nErp, 12) = Val(Strings.Right(g_Temptable.Cells(nJ, 23).value, Len(g_Temptable.Cells(nJ, 23).value) - 1))
                        g_tf层级物料序号 = g_tf层级物料序号 + 1
                        table_temp = g_TableForERP
                    Else

                        nff = InStr(CStr(g_Temptable.Cells(nJ, 23).value()), "B")
                        nff = CInt((CStr(g_Temptable.Cells(nJ, 23).value()).Substring(nff)))
                        nff_strTemp = g_Temptable.Cells(nff, 13).value


                        If Strings.Left(nff_strTemp, slen).ToUpper = Strings.Left(nff_strCs, slen).ToUpper Then ''TableForERP表物料
                            If nff <> panffX Then
                                g_tf层级物料序号 = g_tf层级物料序号 + 1
                                panTF = g_tf层级物料序号
                                panffX = nff
                            End If
                            nErp = g_tf层级物料序号
                            table_temp = g_TableForERP
                            g_tf层级物料序号 = g_tf层级物料序号 + 1
                            table_temp.Cells(nErp, 12) = g_Temptable.Cells(nJ, 24).value  ''12-序号（物料清单）
                        Else   ''借用表物料
                            If nff <> panffX And panJY > 2 Then
                                g_jy层级物料序号 = g_jy层级物料序号 + 1
                                panJY = g_jy层级物料序号
                                panffX = nff
                            End If
                            nErp = g_jy层级物料序号
                            table_temp = g_Table借用
                            g_jy层级物料序号 = g_jy层级物料序号 + 1
                            table_temp.Cells(nErp, 12) = g_Temptable.Cells(nJ, 2).value   ''12-序号（物料清单）
                        End If
                        table_temp.Cells(nErp, 1) = g_Temptable.Cells(nff, 13).value
                        table_temp.Cells(nErp, 2) = g_Temptable.Cells(nff, 14).value
                    End If

                    ''复制数据到TableForErp/借用表
                    Call CopyTableForErp(nErp, nJ, table_temp)

                    nJ = nJ + 1
                Loop

            Next p

            '自动排列
            Call AutoArrange()

        End Sub

        ''复制数据到TableForErp/借用表
        Private Sub CopyTableForErp(ByVal nErp As Integer, ByVal nJ As Integer, ByRef table_temp As Microsoft.Office.Interop.Excel.Worksheet)
            ''nErp——table_temp表的序号///nJ——g_Temptable表的序号///table_temp——TableForErp/借用表

            '到End With添加18、40字符长度的限制条件。
            Dim sel_Temp As Microsoft.Office.Interop.Excel.Range
            sel_Temp = table_temp.Cells(nErp, 6)
            sel_Temp.FormatConditions.Add(Microsoft.Office.Interop.Excel.XlFormatConditionType.xlExpression, , Formula1:="=LEN($F$" & nErp & ")>40")
            sel_Temp.FormatConditions(sel_Temp.FormatConditions.Count).SetFirstPriority()
            With sel_Temp.FormatConditions(1).Interior
                .PatternColorIndex = Microsoft.Office.Interop.Excel.Constants.xlAutomatic
                .Color = 255
                .TintAndShade = 0
            End With
            sel_Temp.FormatConditions(1).StopIfTrue = False
            sel_Temp = table_temp.Cells(nErp, 5)
            sel_Temp.FormatConditions.Add(Microsoft.Office.Interop.Excel.XlFormatConditionType.xlExpression, , Formula1:="=LEN($E$" & nErp & ")>18")
            sel_Temp.FormatConditions(sel_Temp.FormatConditions.Count).SetFirstPriority()
            With sel_Temp.FormatConditions(1).Interior
                .PatternColorIndex = Microsoft.Office.Interop.Excel.Constants.xlAutomatic
                .Color = 255
                .TintAndShade = 0
            End With
            sel_Temp.FormatConditions(1).StopIfTrue = False

            'If g_Temptable.Cells(nJ, 25).value = "1" Then
            '    table_temp.Cells(nErp, 1).font.color = RGB(255, 0, 0)
            'End If

            table_temp.Cells(nErp, 3) = 1
            table_temp.Cells(nErp, 4) = Val(Strings.Right(g_Temptable.Cells(nJ, 23).value, Len(g_Temptable.Cells(nJ, 23).value) - 1)) & "0"

            table_temp.Cells(nErp, 5) = g_Temptable.Cells(nJ, 13) : table_temp.Cells(nErp, 5).font.color = g_Temptable.Cells(nJ, 13).font.color
            table_temp.Cells(nErp, 6) = g_Temptable.Cells(nJ, 14) : table_temp.Cells(nErp, 6).font.color = g_Temptable.Cells(nJ, 14).font.color
            table_temp.Cells(nErp, 7) = g_Temptable.Cells(nJ, 5).value
            table_temp.Cells(nErp, 8) = g_Temptable.Cells(nJ, 7).value
            table_temp.Cells(nErp, 9) = g_Temptable.Cells(nJ, 6).value
            table_temp.Cells(nErp, 10) = g_Temptable.Cells(nJ, 1).value
            table_temp.Cells(nErp, 15) = g_Temptable.Cells(nJ, 11).value

            '标准物料数据库字段内容
            table_temp.Cells(nErp, 34) = g_Temptable.Cells(nJ, 14).value
            table_temp.Cells(nErp, 35) = g_Temptable.Cells(nJ, 15).value
            table_temp.Cells(nErp, 36) = g_Temptable.Cells(nJ, 16).value
            table_temp.Cells(nErp, 37) = g_Temptable.Cells(nJ, 17).value
            table_temp.Cells(nErp, 38) = g_Temptable.Cells(nJ, 18).value
            table_temp.Cells(nErp, 39) = g_Temptable.Cells(nJ, 19).value
            table_temp.Cells(nErp, 40) = g_Temptable.Cells(nJ, 20).value
            table_temp.Cells(nErp, 41) = g_Temptable.Cells(nJ, 21).value
            table_temp.Cells(nErp, 42) = g_Temptable.Cells(nJ, 22).value
            table_temp.Cells(nErp, 43) = g_Temptable.Cells(nJ, 23).value
            'table_temp.Cells(nErp, 44) = g_Temptable.Cells(nj, 24).value


        End Sub

        '自动排列
        Private Sub AutoArrange()
            Dim range_temp As Microsoft.Office.Interop.Excel.Range
            range_temp = g_TableForERP.Columns("A:L")
            range_temp.EntireColumn.AutoFit()
            range_temp = g_Table借用.Columns("A:L")
            range_temp.EntireColumn.AutoFit()
            '保存文件
            ''Dim strPath As String
            ''strPath = const_DeskTop & g_zWorkbook.Name
            ''If System.IO.File.Exists(strPath) = True Then
            ''    Kill(strPath)
            ''End If
            g_TableForERP.Activate()
            g_TableForERP.Cells(2, 2) = "_"
            g_ExcelAppObj.ActiveWindow.LargeScroll(ToRight:=-5) ''向右滚动翻页
            g_zWorkbook.Save()
            range_temp = Nothing
        End Sub


        ''查找标准物料
        Private Sub SAP_物料号()

            Dim j, nK As Integer
            Dim table_Temp As Microsoft.Office.Interop.Excel.Worksheet = Nothing
            For j = 1 To 2
                If j = 1 Then  ''tableForERP表返回编码
                    table_Temp = g_TableForERP
                    nK = 3
                ElseIf j = 2 Then  ''借用表返回编码
                    table_Temp = g_Table借用
                    nK = 2
                End If


                Do While table_Temp.Cells(nK, 10).value <> Nothing OrElse table_Temp.Cells(nK + 1, 10).value <> Nothing OrElse table_Temp.Cells(nK + 2, 10).value <> Nothing
                    If table_Temp.Cells(nK, 10).value = Nothing Then
                        GoTo lineWhile001
                    End If


lineWhile001:
                    nK = nK + 1
                Loop
            Next j

        End Sub





        'TableforErp表插入、插入一个临时空表,准备从其它sheet中复制数据。插入一个数据表
        Private Sub InsertTempTable(ByRef workBook As Microsoft.Office.Interop.Excel.Workbook)

            g_Temptable = Nothing
            If dirSheet(strsheetName, workBook) = False Then
                g_Temptable = workBook.Worksheets.Add
                g_Temptable.Name = strsheetName
                If g_Temptable.Name <> workBook.Sheets(workBook.Sheets.Count).name Then
                    Try
                        g_Temptable.Move(After:=workBook.Sheets(workBook.Sheets.Count))  ''需要焦点，否则会出错
                    Catch ex As Exception

                    End Try

                End If

            Else
                g_Temptable = workBook.Worksheets(strsheetName)

                '' ''g_Temptable.Select()
                g_Temptable.Cells.Clear()
                '' ''g_ExcelAppObj.Selection.ClearContents()
                ''g_Temptable.Range("A1").Select()
            End If
            g_TableForERP = Nothing


            For i = 1 To 25
                g_Temptable.Cells(2, i) = i
            Next

            ''清单项内容
            g_Temptable.Range("B1").Value = "序号"
            g_Temptable.Range("C1").Value = "代号"
            g_Temptable.Range("D1").Value = "名称"
            g_Temptable.Range("E1").Value = "数量"
            g_Temptable.Range("F1").Value = "材料"
            g_Temptable.Range("G1").Value = "单重"
            g_Temptable.Range("H1").Value = "总重"
            g_Temptable.Range("I1").Value = "QL"
            g_Temptable.Range("J1").Value = "核电等级"
            g_Temptable.Range("K1").Value = "检验"
            g_Temptable.Range("L1").Value = "备注"

            ''标准物料数据库各字段
            g_Temptable.Range("M1").Value = "SAP编码"
            g_Temptable.Range("N1").Value = "完整描述"
            g_Temptable.Range("O1").Value = "名称"
            g_Temptable.Range("P1").Value = "材料/级别"
            g_Temptable.Range("Q1").Value = "规格"
            g_Temptable.Range("R1").Value = "图号/标准号/型号"
            g_Temptable.Range("S1").Value = "质保等级"
            g_Temptable.Range("T1").Value = "核电等级"
            g_Temptable.Range("U1").Value = "备注"
            g_Temptable.Range("V1").Value = "层级"
            g_Temptable.Range("W1").Value = "序号1"
            g_Temptable.Range("X1").Value = "序号2"
            Dim range_Temp As Microsoft.Office.Interop.Excel.Range
            range_Temp = g_Temptable.Columns(24) ''24-X列
            range_Temp.NumberFormatLocal = "@"   ''设置成文本

            g_TableForERP = Nothing
            If dirSheet(strSheetName1, workBook) = False Then
                g_TableForERP = workBook.Worksheets.Add
                g_TableForERP.Name = strSheetName1

                Try
                    g_TableForERP.Move(After:=g_Temptable)
                Catch ex As Exception

                End Try


            Else
                g_TableForERP = workBook.Worksheets(strSheetName1)

                '' ''g_Temptable.Select()
                g_TableForERP.Cells.Clear()
                '' ''g_ExcelAppObj.Selection.ClearContents()
                ''g_Temptable.Range("A1").Select()
            End If

            g_Table借用 = Nothing
            If dirSheet(strSheetName2, workBook) = False Then
                g_Table借用 = workBook.Worksheets.Add
                g_Table借用.Name = strSheetName2

                Try
                    g_Table借用.Move(After:=g_TableForERP)
                Catch ex As Exception

                End Try


            Else
                g_Table借用 = workBook.Worksheets(strSheetName2)

                '' ''g_Temptable.Select()
                g_Table借用.Cells.Clear()
                '' ''g_ExcelAppObj.Selection.ClearContents()
                ''g_Temptable.Range("A1").Select()
            End If

            Dim sheet_temp As Microsoft.Office.Interop.Excel.Worksheet
            Dim i_temp As Byte
            i_temp = 0
            sheet_temp = g_TableForERP

line借用001:
            sheet_temp.Range("A1").Value = "物料号"
            sheet_temp.Range("B1").Value = "BOM物料描述"
            sheet_temp.Range("C1").Value = "基本数量"
            sheet_temp.Range("D1").Value = "BOM项目号"
            sheet_temp.Range("E1").Value = "BOM组件"
            sheet_temp.Range("F1").Value = "BOM项目描述"
            sheet_temp.Range("G1").Value = "组件数量"
            sheet_temp.Range("H1").Value = "单重"
            sheet_temp.Range("I1").Value = "材料"
            sheet_temp.Range("K1").Value = "排序字符串"
            sheet_temp.Range("L1").Value = "序号"
            sheet_temp.Range("M1").Value = "文本1"
            sheet_temp.Range("N1").Value = "文本2"
            sheet_temp.Range("O1").Value = "关键件"
            sheet_temp.Range("P1").Value = "长文本"
            sheet_temp.Range("Q1").Value = "装箱备注"
            sheet_temp.Range("R1").Value = "物料供应标识符"


            sheet_temp.Range("AH1").Value = "完整描述"
            sheet_temp.Range("AI1").Value = "名称"
            sheet_temp.Range("AJ1").Value = "材料/级别"
            sheet_temp.Range("AK1").Value = "规格"
            sheet_temp.Range("AL1").Value = "图号/标准号/型号"
            sheet_temp.Range("AM1").Value = "质保等级"
            sheet_temp.Range("AN1").Value = "核电等级"
            sheet_temp.Range("AO1").Value = "备注"
            sheet_temp.Range("AP1").Value = "层级"
            sheet_temp.Range("AQ1").Value = "序号1"
            sheet_temp.Range("AR1").Value = "序号2"

            range_Temp = sheet_temp.Columns(12)  ''12-L列
            range_Temp.NumberFormatLocal = "@"   ''设置成文本
            range_Temp = Nothing
            '' ''sheet_temp.Activate()
            '' ''range_Temp.Select()  ''select()必须是所选内容的表格处于当前状态
            ''g_ExcelAppObj.Selection.NumberFormatLocal = "@"   ''设置成文本
            If i_temp = 0 Then
                i_temp = 1
                sheet_temp = g_Table借用
                GoTo line借用001
            End If



        End Sub

        '判断临时表是否已经存在。
        Private Function dirSheet(SheetName As String, ByRef workBook As Microsoft.Office.Interop.Excel.Workbook) As Boolean
            dirSheet = False
            Dim i As Integer
            For i = 1 To workBook.Sheets.Count
                If workBook.Sheets(i).Name = SheetName Then
                    dirSheet = True
                    Exit Function
                End If
            Next i
        End Function


#End Region


#Region "无用代码"

        '判断产品名称
        'Private Function NameofProduct(ByVal nPstr As String) As String
        '    If Len(nPstr) < 2 Then
        '        Return ""
        '        Exit Function
        '    End If
        '    Return ""
        '    Select Case Strings.Left(nPstr, 2).ToUpper
        '        Case "HP" : NameofProduct = "高压加热器"

        '    End Select


        'End Function

        '层级物料序号
        'Private Sub Cj_物料序号(ByVal nP As Integer)
        '    If nP < 0 Then
        '        Exit Sub
        '    End If

        '    Dim nLe As Integer
        '    nLe = g_cj层级物料序号.Length - 1
        '    If nP > nLe Then
        '        ReDim Preserve g_cj层级物料序号(0 To 10)
        '        nLe = 10
        '        Exit Sub
        '    Else
        '        Dim i As Integer
        '        For i = nP To nLe
        '            g_cj层级物料序号(i) = g_cj层级物料序号(i) + 1

        '        Next
        '    End If


        'End Sub

#End Region


#Region "集成需要添加的代码"
        Private FilePath As String, Flag As Integer
        Public ErrorMsg As String

        Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            If String.IsNullOrEmpty(Me.FilePath) = True AndAlso Me.Flag = 0 Then
                Return
            End If

            Dim FileName = My.Computer.FileSystem.GetFileInfo(FilePath).Name

            g_cs输入文件路径名称Array = {FilePath}       '' ''选择的各文件路径。
            g_cs输入文件名称List = {FileName}
            g_w文件Count = 1   '' ''选择的文件总数。

            If g_w文件Count = 1 Then
                ReDim Preserve g_cs输入文件路径名称Array(0 To 0)
                ReDim Preserve g_cs输入文件名称List(0 To 0)

                g_cs输入文件路径名称Array(0) = FilePath    '' ''单个文件的路径。
                g_cs输入文件名称List(0) = FileName     '' ''文件名称
                Lst_文件.Items.Add(FileName)
            Else
                ReDim Preserve g_cs输入文件路径名称Array(0 To g_w文件Count - 1)
                ReDim Preserve g_cs输入文件名称List(0 To g_w文件Count - 1)

                For i = 0 To g_w文件Count - 1
                    Lst_文件.Items.Add(g_cs输入文件名称List(i))     '' ''将路径名增加到 cbo_全路径名。
                Next i
            End If

            If Me.Flag = 0 Then
                Button1_Click(sender, e)
            Else
                Button2_Click(sender, e)
            End If

            Me.Close()
        End Sub

        Sub New(FilePath As String, Flag As Integer)
            Application.EnableVisualStyles()

            Me.FilePath = FilePath
            Me.Flag = Flag

            InitializeComponent()
        End Sub

        Sub New()
            InitializeComponent()
        End Sub
#End Region
    End Class
End Namespace
