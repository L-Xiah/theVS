Module ModiInit
    Public Const const_i应用程序类型 As Int16 = 1

    Public Const g_Const_i工作表最大页数 As Int16 = 50
    Public g_cs第几页(0 To g_Const_i工作表最大页数) As String
    Public g_cs清单项目明细Array(0 To g_Const_i工作表最大页数, 0 To 9) As String

    Public g_PassWord As Byte

    Public g_cs输入文件路径名称Array() As String
    Public g_i输入文件路径名称Count As Integer
    Public g_cs输入文件全路径名称 As String

    Public gCad_App As AutoCAD.AcadApplication
    Public g_acadDocument As AutoCAD.AcadDocument
    Public g_obj标题栏BlockRef As AutoCAD.AcadBlockReference
    Public g_obj图框BlockDef As AutoCAD.AcadBlock
    Public g_cs图框BlockRefName As String

    Public g_cs标题栏块名 As String
    Public g_d标题栏插入点(0 To 2) As Double
    Public g_d标题栏比例 As Double
    Public g_cs图纸代号 As String

    Public g_d图框插入点(0 To 2) As Double
    Public g_d图框最小点(0 To 2) As Double
    Public g_d图框最大点(0 To 2) As Double

    Public g_iDebugFlag As Integer
    Public Const Const_dMyVersion As Double = 2

    Public g_cs共享目录名 As String
    Public g_cs图片共享目录名 As String
    Public Const const_cs本地共享目录名 As String = "E:\TEMP\sign\"
    Public Const const_cs网络共享目录名 As String = "\\10.32.1.20\01_部门共享\02_技术部\01_设计研究所\08_共享\软件\应用软件\sign"

    Public g_iSign_签名与打印Form_返回码 As Integer   ''=0--退出；=1--签名；=2--打印；=3--图层线宽
    Public g_cs签名者身份姓名数组(7, 6) As String
    Public g_csOptionButton签名者身份 As String
    Public g_cs签名者身份 As String
    Public g_cs签名者姓名 As String
    Public g_cs第二签名者姓名 As String

    Public g_iComboBox签名者姓名GotFocus As Integer
    Public g_iComboBox第二签名者姓名GotFocus As Integer
    Public g_iTextBox年GotFocus As Integer
    Public g_iTextBox月GotFocus As Integer
    Public g_iTextBox日GotFocus As Integer

    Public g_cs签名年 As String
    Public g_cs签名月 As String
    Public g_cs签名日 As String

    Public g_cs输入文件类型 As String
    Public Const Const_csDwg文件类型 As String = "Dwg"
    Public Const Const_csXls文件类型 As String = "Xls"
    Public Const Const_csDoc文件类型 As String = "Doc"

    Public g_i签名前检查图形与层的颜色是否一致Flag As Integer   '' =1 要检查

    Public g_dTimeOld As Double

    Public g_ExcelAppObj As Microsoft.Office.Interop.Excel.Application


    Public Function iInitialize() As Integer
        On Error Resume Next

        Dim i As Integer
        Dim j As Integer
        Dim csTemp As String

        i = iBanBenHao()
        If i < 0 Then
            iInitialize = -1
            Exit Function
        End If

        For i = 1 To g_Const_i工作表最大页数

            csTemp = ""

            If i >= 200 Then
                csTemp = csTemp + "二百"
            ElseIf i >= 100 Then
                csTemp = csTemp + "一百"
            End If

            j = i Mod 100
            If j >= 90 Then
                csTemp = csTemp + "九十"
            ElseIf j >= 80 Then
                csTemp = csTemp + "八十"
            ElseIf j >= 70 Then
                csTemp = csTemp + "七十"
            ElseIf j >= 60 Then
                csTemp = csTemp + "六十"
            ElseIf j >= 50 Then
                csTemp = csTemp + "五十"
            ElseIf j >= 40 Then
                csTemp = csTemp + "四十"
            ElseIf j >= 30 Then
                csTemp = csTemp + "三十"
            ElseIf j >= 20 Then
                csTemp = csTemp + "二十"
            ElseIf j >= 10 Then
                csTemp = csTemp + "十"
            ElseIf i > 100 And i < 200 Then
                csTemp = csTemp + "零"
            End If

            j = i Mod 10
            If j = 9 Then
                csTemp = csTemp + "九"
            ElseIf j = 8 Then
                csTemp = csTemp + "八"
            ElseIf j = 7 Then
                csTemp = csTemp + "七"
            ElseIf j = 6 Then
                csTemp = csTemp + "六"
            ElseIf j = 5 Then
                csTemp = csTemp + "五"
            ElseIf j = 4 Then
                csTemp = csTemp + "四"
            ElseIf j = 3 Then
                csTemp = csTemp + "三"
            ElseIf j = 2 Then
                csTemp = csTemp + "二"
            ElseIf j = 1 Then
                csTemp = csTemp + "一"
            End If

            g_cs第几页(i) = "第" + csTemp + "页"

        Next i

        If const_i应用程序类型 = 1 Then

        ElseIf const_i应用程序类型 = 2 Then

            i = i050整理清单()
            iInitialize = 0

            Exit Function
        End If

        If i < 0 Then
            iInitialize = -1

            Exit Function
        End If

        Dim sysVarName As String
        Dim sysVarData As Object
        Dim DataType As Integer
        Dim intData As Integer
        sysVarName = "CMDECHO" ' "FILEDIA"
        intData = 0
        sysVarData = intData    ' Integer data
Label_iInitialize_End:

        iInitialize = 0

    End Function

    Public Function iBanBenHao() As Integer

        Dim i As Integer
        Dim li As Long
        li = 100
        Dim csTemp As New String(" ", li)

        Call GetUserName(csTemp, li)
        For i = 1 To li
            If Asc(Mid(csTemp, i, 1)) = 0 Then
                Exit For
            End If
        Next i
        g_csUserName = UCase(Left(csTemp, i - 1)) ' 用户名
        '    g_csUserName = "12345678" ' 用户名

        li = 100
        csTemp = New String(" ", li)
        Call GetComputerName(csTemp, li)
        For i = 1 To li
            If Asc(Mid(csTemp, i, 1)) = 0 Then
                Exit For
            End If
        Next i
        g_csComputerName = UCase(Left(csTemp, i - 1)) ' 机器名

        '    MsgBox "用户名='" & g_csUserName & "'   长度=" & Format(Len(g_csUserName), "0") & vbCrLf & _
        '           "机器名='" & g_csComputerName & "'   长度=" & Format(Len(g_csComputerName), "0") ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

        If (g_csUserName = "10605819" And g_csComputerName = "106-DESI-XL-A") Then

            g_iDebugFlag = 1 ' ==1 本人机器调试标志
            g_cs共享目录名 = const_cs本地共享目录名
            g_cs图片共享目录名 = const_cs本地共享目录名

        ElseIf (g_csUserName = "ADMINISTRATOR" And g_csComputerName = "106-DESI-XL-A") Then

            g_iDebugFlag = 1 ' ==1 本人机器调试标志
            g_cs共享目录名 = const_cs本地共享目录名
            g_cs图片共享目录名 = const_cs本地共享目录名

            '    ElseIf (g_csUserName = "10605097" Or g_csUserName = "STGS") And g_csComputerName = "SPEC-DESI-STGS" Or _
            '        g_csUserName = "10605372" Or g_csUserName = "STGS" And g_csComputerName = "SPEC-DESI-LHL" Then
        Else
            g_iDebugFlag = 0 ' ==1 本人机器调试标志
            g_cs共享目录名 = const_cs网络共享目录名
            g_cs图片共享目录名 = const_cs网络共享目录名

        End If

        iBanBenHao = 0
        Exit Function
iBanBenHao_Err:
        iBanBenHao = -1

    End Function

    Public Function i050整理清单() As Integer

        Dim i As Integer
        Dim i循环 As Integer
        Dim j As Integer
        Dim li As Long
        Dim csTemp As String
        Dim i1循环 As Integer
        Dim j1循环 As Integer
        Dim cs清单项目文件全路径名称Temp As String = Nothing
        Dim MyActiveWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Dim m_Worksheet As Microsoft.Office.Interop.Excel.Worksheet

        Dim i总行数 As Integer
        Dim i每页行数 As Integer
        Dim i每行列数 As Integer

        On Error Resume Next

        i = i052Init整理清单()
        If i < 0 Then
            i050整理清单 = -1

            Exit Function
        End If

        i = i055浏览清单() ' 获取 g_cs输入文件路径名称Array(i循环)
        If i < 0 Then
            i050整理清单 = -1

            Exit Function
        End If

        ''g_dTimeOld = Now

        For i = 1 To g_Const_i工作表最大页数
            For j = 1 To 9
                g_cs清单项目明细Array(i, j) = ""
            Next j
        Next i

        For i循环 = 0 To g_i输入文件路径名称Count - 1

            g_cs输入文件全路径名称 = g_cs输入文件路径名称Array(i循环)

            Dim cs输入文件扩展名 As String = Nothing
            Dim cs输入文件名称_带扩展名 As String = Nothing

            '------------------------------------------------------------
            ' 求输入文件名称(带扩展名)
            i = InStrRev(g_cs输入文件全路径名称, "\", -1, vbTextCompare)
            If i > 0 Then
                ' 求 输入文件名称_带扩展名
                cs输入文件名称_带扩展名 = UCase(Mid(g_cs输入文件全路径名称, i + 1))
            Else

            End If

            '------------------------------------------------------------
            ' 求输入文件扩展名
            i = InStrRev(g_cs输入文件全路径名称, ".", -1, vbTextCompare)
            If i > 0 Then
                ' 求 输入文件名称_带扩展名
                cs输入文件扩展名 = UCase(Mid(g_cs输入文件全路径名称, i))
                If cs输入文件扩展名 <> ".XLS" And cs输入文件扩展名 <> ".XLSX" Then

                    csTemp = "警告: 文件扩展名错误! " + vbCrLf + vbCrLf + g_cs输入文件全路径名称

                    MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                End If
            Else

            End If

            '        Err.Clear
            '------------------------------------------------------------
            ' 关闭已经打开的输入文件
Label_i050整理清单_003:
            For i = 1 To g_ExcelAppObj.Workbooks.Count
                csTemp = UCase(g_ExcelAppObj.Workbooks(i).Name)
                If csTemp = cs输入文件名称_带扩展名 Then
                    g_ExcelAppObj.Workbooks(i).Close(True) ' 关闭 输入文件

                    GoTo Label_i050整理清单_003
                End If
            Next i

            If i循环 = 4 Then ' 第5个输入文件
                i = i
            End If

            If i循环 = 0 Then

                j = InStrRev(g_cs输入文件全路径名称, cs输入文件扩展名, Len(g_cs输入文件全路径名称), vbTextCompare)
                cs清单项目文件全路径名称Temp = Left(g_cs输入文件全路径名称, j - 1) + "-清单项目" + cs输入文件扩展名

            End If

            

            '        g_ExcelAppObj.Workbooks.Open FileName:=g_cs输入文件全路径名称
            g_ExcelAppObj.Workbooks.Open(Filename:=g_cs输入文件全路径名称)

            If Err.Number = 1004 Then
                MsgBox("打开指定的工作簿错误: " & vbCrLf & "工作簿路径名称 = '" & g_cs输入文件路径名称Array(i循环) & "'") ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i050整理清单 = -1

                g_ExcelAppObj.Visible = True
                Exit Function
            ElseIf Err.Number <> 0 Then
                MsgBox("打开指定的工作簿 '" & g_cs输入文件全路径名称 & "' 错误！" & _
                    vbCrLf & "Error Number = " & Format(i, "0") & _
                    vbCrLf & "错误描述: " & Microsoft.VisualBasic.VariantType.Error)

                i050整理清单 = -1

                g_ExcelAppObj.Visible = True
                Exit Function
            End If
            MyActiveWorkbook = g_ExcelAppObj.ActiveWorkbook

            If g_ExcelAppObj.ActiveWorkbook.ReadOnly = True Then
                csTemp = "打开工作簿错误: " & vbCrLf & _
                    "工作簿路径名称 = '" & g_cs输入文件全路径名称 & "' 是只读工作簿" & vbCrLf & _
                    "请关闭工作簿以后再运行本程序。"
                MsgBox(csTemp + vbCrLf) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i050整理清单 = -1

                g_ExcelAppObj.Visible = True
                Exit Function
            End If

            On Error Resume Next

            Dim i页 As Integer
            Dim i行 As Integer
            Dim j列 As Integer


            i总行数 = 0
            i每页行数 = 7
            i每行列数 = 8

            For Each m_Worksheet In g_ExcelAppObj.ActiveWorkbook.Worksheets

                csTemp = UCase(m_Worksheet.Name)

                For i页 = 1 To g_Const_i工作表最大页数

                    If csTemp = g_cs第几页(i页) Then

                        If i总行数 < i页 * i每页行数 Then i总行数 = i页 * i每页行数

                        For i行 = 1 To i每页行数

                            For j列 = 1 To i每行列数

                                j = j列
                                If j列 > 2 Then
                                    j = j列 + 1
                                End If

                                g_cs清单项目明细Array((i页 - 1) * i每页行数 + i行, j) = m_Worksheet.Cells((i行 - 1) * 2 + 1 + 4, j列).Value

                            Next j列

                            g_cs清单项目明细Array((i页 - 1) * i每页行数 + i行, 3) = m_Worksheet.Cells((i行 - 1) * 2 + 1 + 4 + 1, 2).Value

                        Next i行

                        Exit For ' i行

                    End If

                Next i页

            Next m_Worksheet

Label_i050整理清单_002:

        Next i循环

        '' ''csTemp = "共费时 " + Format((Now - g_dTimeOld) * 86400, "0.000") + " 秒" ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
        'MsgBox cstemp ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

        If Dir(cs清单项目文件全路径名称Temp) <> "" Then
            Kill(cs清单项目文件全路径名称Temp)
        End If

        MyActiveWorkbook = g_ExcelAppObj.Workbooks.Add
        MyActiveWorkbook.SaveAs(Filename:=cs清单项目文件全路径名称Temp)
        MyActiveWorkbook.Activate()

        m_Worksheet = MyActiveWorkbook.Worksheets.Add
        m_Worksheet.Name = "清单项目"

        For i行 = 1 To i总行数

            For j列 = 1 To i每行列数 + 1

                m_Worksheet.Cells(i行, j列).Value = g_cs清单项目明细Array(i行, j列)

            Next j列

        Next i行

        MyActiveWorkbook.Close(True)

        g_ExcelAppObj.Visible = True
        i050整理清单 = 0
    End Function

    Public Function i052Init整理清单() As Integer

        Dim i As Integer
        Dim li As Long
        Dim csTemp As String

        On Error Resume Next

        '    g_iCreateAutoCAD = 0 ' =0 获得已打开的 AutoCAD 程序, =1 创建 AutoCAD 程序
        g_ExcelAppObj = GetObject(, "Excel.Application")
        i = Err.Number
        If i <> 0 Then ' 若未打开 Excel 应用软件, 则 Err.Number==429

            i = MsgBox("请先打开 Excel 应用软件, 再运行本程序。") ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            i052Init整理清单 = -1

            Exit Function
        End If

        g_ExcelAppObj.DisplayAlerts = False

        On Error Resume Next

        i052Init整理清单 = 0

    End Function

    Private Function i055浏览清单() As Integer

        Dim i As Integer
        Dim j As Integer

        Dim cstem() As String
        Dim iT As Integer

        i055浏览清单 = 0
        '------------------------------------------------------
        ' 浏览，选择 XLS 文件路径名称
        SignExcelDwg.OpenFileDialog浏览.FileName = ""
        SignExcelDwg.OpenFileDialog浏览.Multiselect = True
        ' ''Flags =cdlOFNAllowMultiselect Or _
        '    '    'cdlOFNExplorer Or _
        '    '    'cdlOFNLongNames Or _
        '    '    'cdlOFNNoReadOnlyReturn Or _
        '    '    'cdlOFNPathMustExist Or _
        '    '    'cdlOFNFileMustExist

        SignExcelDwg.OpenFileDialog浏览.Filter = "Excel 97-2003 工作表(*.xls)|*.XLS|Excel 工作表(*.xlsx)|*.XLSX"

        SignExcelDwg.OpenFileDialog浏览.ShowDialog()

        '    MsgBox "DWG文件路径名称=@" & CommonDialog浏览.Filename & "@" ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

        If SignExcelDwg.OpenFileDialog浏览.FileName = "" Then ' 取消 '打开文件' 对话框
            MsgBox("请指定文件路径名称！") ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
            Exit Function ' 请指定DWG文件路径、名称！
        End If

        cstem = SignExcelDwg.OpenFileDialog浏览.FileNames       '' ''选择的各文件路径。
        iT = SignExcelDwg.OpenFileDialog浏览.FileNames.Count    '' ''选择的文件总数。
        g_i输入文件路径名称Count = iT

        If iT = 1 Then
            ReDim g_cs输入文件路径名称Array(0 To 0)
            ReDim cstem(0 To 0)
            cstem(0) = SignExcelDwg.OpenFileDialog浏览.FileName    '' ''单个文件的路径。
            SignExcelDwg.Cbo_全路径名.Items.Add(cstem(0))
        Else
            ReDim g_cs输入文件路径名称Array(0 To iT - 1)
            ReDim Preserve cstem(0 To iT - 1)
            For i = 0 To iT - 1
                SignExcelDwg.Cbo_全路径名.Items.Add(cstem(i))     '' ''将路径名增加到 cbo_全路径名。
                g_cs输入文件路径名称Array(i) = cstem(i)
            Next i
        End If



        '------------------------------------------------------------
        ' 对输入文件路径名称进行排序
        Dim iTempMin As Integer
        Dim csTempMin As String

        For i = 0 To g_i输入文件路径名称Count - 1
            csTempMin = g_cs输入文件路径名称Array(i)
            iTempMin = i
            For j = i + 1 To g_i输入文件路径名称Count - 1
                If StrComp(csTempMin, g_cs输入文件路径名称Array(j), vbTextCompare) > 0 Then
                    csTempMin = g_cs输入文件路径名称Array(j)
                    iTempMin = j
                End If
            Next j

            If iTempMin > i Then
                csTempMin = g_cs输入文件路径名称Array(i)
                g_cs输入文件路径名称Array(i) = g_cs输入文件路径名称Array(iTempMin)
                g_cs输入文件路径名称Array(iTempMin) = csTempMin
            End If
        Next i



    End Function

    Public Function i300Excel文件签名() As Integer

        Dim i As Integer
        Dim csTemp As String

        On Error Resume Next
        g_ExcelAppObj = GetObject(, "Excel.Application")
        i = Err.Number
        If i <> 0 Then ' 若未打开 Excel 应用软件, 则 Err.Number==429

            i = MsgBox("为缩短启动时间, 建议下次先打开 Excel 应用软件, 再运行本程序。" + vbCrLf + _
                        "要继续吗? (Yes/No)", vbYesNo) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
            If i = vbNo Then
                i300Excel文件签名 = -1

                Exit Function
            End If

            On Error Resume Next ' Err.Number 清零

            g_ExcelAppObj = CreateObject("Excel.Application")
            i = Err.Number
            If i <> 0 Then
                MsgBox("创建 Excel 应用程序错误!" & vbCrLf & _
                    "Error Number = " & Format(i, "0") & vbCrLf & _
                    "错误描述: " & Microsoft.VisualBasic.VariantType.Error) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i300Excel文件签名 = -1

                Exit Function
            End If
        End If

        g_ExcelAppObj.DisplayAlerts = False
        '    g_ExcelAppObj.Visible = False

        Dim i循环 As Integer
        Dim j循环 As Integer

        '    Dim MyActiveWorkbook As Object
        Dim MyActiveWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Dim m_Worksheet As Microsoft.Office.Interop.Excel.Worksheet

        For i循环 = 0 To g_i输入文件路径名称Count - 1

            '------------------------------------------------------
            ' 打开工作簿
            On Error Resume Next

            g_cs输入文件全路径名称 = g_cs输入文件路径名称Array(i循环)

            FileCopy(g_cs输入文件全路径名称, g_cs输入文件全路径名称 + ".bak")

            g_ExcelAppObj.Workbooks.Open(Filename:=g_cs输入文件全路径名称)


            '''''Test
            '' ''Dim s_NameT As String
            '' ''Dim s_Book As Microsoft.Office.Interop.Excel.Workbook
            '' ''s_NameT = g_ExcelAppObj.ActiveWorkbook.Name
            '' ''Debug.Print(g_ExcelAppObj.ActiveWorkbook.FullName)

            '' ''s_Book = g_ExcelAppObj.Workbooks(s_NameT)
            '' '' '' ''MsgBox(s_Book.Worksheets(1).Name)
            '''''Test


            If Err.Number = 1004 Then
                MsgBox("打开指定的工作簿错误: " & vbCrLf & "工作簿路径名称 = '" & g_cs输入文件路径名称Array(i循环) & "'") ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i300Excel文件签名 = -1

                Exit Function
            ElseIf Err.Number <> 0 Then
                MsgBox("打开指定的工作簿 '" & g_cs输入文件全路径名称 & "' 错误！" & _
                    vbCrLf & "Error Number = " & Format(i, "0") & _
                    vbCrLf & "错误描述: " & Microsoft.VisualBasic.VariantType.Error)

                i300Excel文件签名 = -1

                Exit Function
            End If
            MyActiveWorkbook = g_ExcelAppObj.ActiveWorkbook

            If g_ExcelAppObj.ActiveWorkbook.ReadOnly = True Then
                csTemp = "打开工作簿错误: " & vbCrLf & _
                    "工作簿路径名称 = '" & g_cs输入文件全路径名称 & "' 是只读工作簿" & vbCrLf & _
                    "请关闭工作簿以后再运行本程序。"
                MsgBox(csTemp + vbCrLf)  ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i300Excel文件签名 = -1

                Exit Function
            End If

            On Error Resume Next

            For j循环 = 1 To 7
                g_cs签名者身份 = g_cs签名者身份姓名数组(j循环, 1)
                g_cs签名者姓名 = g_cs签名者身份姓名数组(j循环, 2)
                g_cs第二签名者姓名 = g_cs签名者身份姓名数组(j循环, 3)
                g_cs签名年 = g_cs签名者身份姓名数组(j循环, 4)
                g_cs签名月 = g_cs签名者身份姓名数组(j循环, 5)
                g_cs签名日 = g_cs签名者身份姓名数组(j循环, 6)

                If g_cs签名者姓名 = "" Or g_cs签名者姓名 = "0000-无" Then
                    GoTo Label_i300Excel文件签名_001
                End If

                Dim imageName As String
                imageName = g_cs图片共享目录名 + "\签名图片\" + g_cs签名者姓名 + ".JPG"

                Dim imageName2 As String = Nothing
                If g_cs第二签名者姓名 <> "0000-无" Then
                    imageName2 = g_cs图片共享目录名 + "\签名图片\" + g_cs第二签名者姓名 + ".JPG"
                End If

                Dim d图片插入点X As Double
                Dim d图片插入点Y As Double

                '------------------------------------------------------
                ' 检查是否有名为 "第几页" 的清单工作表

                Dim dWidth As Double
                Dim dHight As Double

                For Each m_Worksheet In g_ExcelAppObj.ActiveWorkbook.Worksheets

                    csTemp = UCase(m_Worksheet.Name)

                    For i = 1 To g_Const_i工作表最大页数
                        If csTemp = g_cs第几页(i) Then

                            m_Worksheet.Activate()
                            '                        m_Worksheet.Visible = xlSheetVisible

                            If g_cs签名者身份 = "设计" Then
                                csTemp = "C40"
                            ElseIf g_cs签名者身份 = "校对" Then
                                csTemp = "C39"
                            ElseIf g_cs签名者身份 = "审核" Then
                                csTemp = "C38"
                            ElseIf g_cs签名者身份 = "标检" Then
                                csTemp = "C37"
                            End If

                            d图片插入点X = m_Worksheet.Range(csTemp).Left
                            d图片插入点Y = m_Worksheet.Range(csTemp).Top

                            '---------------------------------------------------------------------------------------------------
                            ' 清除第几页工作表原有签名

                            Dim MyShape As Microsoft.Office.Interop.Excel.Shape
                            Dim MyShapes As Microsoft.Office.Interop.Excel.Shapes

                            MyShapes = m_Worksheet.Shapes

                            For Each MyShape In MyShapes

                                ' VB 中调用 Excel 类型库时, Shape 没有 Type 属性与 Delete 方法！！！
                                If MyShape.Type = Microsoft.Office.Core.MsoShapeType.msoPicture _
                                    Or MyShape.Type = Microsoft.Office.Core.MsoShapeType.msoLinkedPicture Then ' VB 中没有 Type 属性！

                                    csTemp = m_Worksheet.Name + vbCrLf  '+ "Text: " + MyShape.TextFrame.Characters.Text + vbCrLf
                                    csTemp = csTemp + "图片左上角坐标位置: X" + Str(MyShape.Top) + "  Y: " + Str(MyShape.Left) + vbCrLf
                                    csTemp = csTemp + "图片高X宽: " + Str(MyShape.Height) + "X" + Str(MyShape.Width) + vbCrLf

                                    '                                MsgBox csTemp

                                    Dim dX As Double
                                    Dim dY As Double

                                    dX = MyShape.Left
                                    dY = MyShape.Top

                                    If dX > d图片插入点X And dX < d图片插入点X + m_Worksheet.Range("C40").Width And _
                                       dY > d图片插入点Y - m_Worksheet.Range("C40").Height / 2 And dY < d图片插入点Y + m_Worksheet.Range("C40").Height / 2 Then

                                        If UCase(MyShape.Parent.Name) = UCase(m_Worksheet.Name) Then
                                            MyShape.Delete()   ' VB 中没有 Delete 方法！
                                        End If

                                    End If

                                End If

                            Next MyShape

                            '---------------------------------------------------------------------------------------------------

                            Dim d图片插入点X2 As Double
                            Dim d图片宽度 As Double
                            Dim d图片高度 As Double

                            If g_cs第二签名者姓名 = "0000-无" Then ' 一人签名

                                d图片插入点X = d图片插入点X + 16
                                d图片插入点Y = d图片插入点Y + 1

                                d图片宽度 = 38
                                d图片高度 = 38 * 270 / 650

                            Else                                   ' 两人签名

                                d图片插入点X = d图片插入点X + 8
                                d图片插入点Y = d图片插入点Y + 2

                                d图片宽度 = 30
                                d图片高度 = 30 * 270 / 650

                                d图片插入点X2 = d图片插入点X + 30

                            End If

                            ' 第几页工作表写签名图片
                            ' 写入签名者姓名
                            MyShape = m_Worksheet.Shapes.AddPicture(imageName, True, True, d图片插入点X, d图片插入点Y, d图片宽度, d图片高度)
                            MyShape.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoSendToBack)

                            If g_cs第二签名者姓名 <> "0000-无" Then ' 两人签名

                                MyShape = m_Worksheet.Shapes.AddPicture(imageName2, True, True, d图片插入点X2, d图片插入点Y, d图片宽度, d图片高度)
                                MyShape.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoSendToBack)

                            End If

                            Exit For ' i

                        End If

                    Next i

                Next m_Worksheet

Label_i300Excel文件签名_001:

            Next j循环

            '        Set g_acadDocument = g_AutocadAppObj.ActiveDocument
            MyActiveWorkbook.Save()
            Kill(g_cs输入文件全路径名称 + ".bak")

        Next i循环

        g_ExcelAppObj.Visible = True

    End Function

    Public Function i200Dwg签名() As Integer

        Dim i As Integer
        Dim n循环, i循环 As Integer
        Dim csTemp As String

        For n循环 = 0 To g_i输入文件路径名称Count - 1
            '------------------------------------------------------
            ' 打开Dwg
            Try
                g_cs输入文件全路径名称 = g_cs输入文件路径名称Array(n循环)
                FileCopy(g_cs输入文件全路径名称, g_cs输入文件全路径名称 + ".bak")

                gCad_App.Documents.Open(g_cs输入文件全路径名称, [ReadOnly]:=False)
                g_acadDocument = gCad_App.ActiveDocument

            Catch ex As Exception
                MessageBox.Show(g_cs输入文件全路径名称 & vbCrLf & "未能正确的打开！！", "Error", MessageBoxButtons.OK)
                GoTo Label_i200签名_101
            End Try

            i = i100Get图框与标题栏信息()
            If i < 0 Then
                GoTo Label_i200签名_101
            End If

            For i循环 = 1 To 7
                g_cs签名者身份 = g_cs签名者身份姓名数组(i循环, 1)
                g_cs签名者姓名 = g_cs签名者身份姓名数组(i循环, 2)
                g_cs第二签名者姓名 = g_cs签名者身份姓名数组(i循环, 3)
                g_cs签名年 = g_cs签名者身份姓名数组(i循环, 4)
                g_cs签名月 = g_cs签名者身份姓名数组(i循环, 5)
                g_cs签名日 = g_cs签名者身份姓名数组(i循环, 6)

                If g_cs签名者姓名 = "0000-无" Then
                    GoTo Label_i200签名_001
                End If

                csTemp = "签名者身份 = " + g_cs签名者身份 + vbCrLf & "签名者图片 = " + g_cs签名者姓名

                g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
                '    MsgBox csTemp + vbCrLf  ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                Dim imageName As String = Nothing
                Dim imageName2 As String = Nothing
                Try
                    If g_cs签名者姓名 <> "0000-无" Then
                        imageName = g_cs图片共享目录名 + "\签名图片\" + g_cs签名者姓名 + ".DWG"
                    Else
                        imageName = ""
                    End If

                    If g_cs第二签名者姓名 <> "0000-无" Then
                        imageName2 = g_cs图片共享目录名 + "\签名图片\" + g_cs第二签名者姓名 + ".DWG"
                    Else
                        imageName2 = ""
                    End If
                Catch ex As Exception

                End Try

                i = i225插入一个签名块(imageName, imageName2)
                If i < 0 Then
                    Return -1
                End If


Label_i200签名_001:

            Next i循环

            Kill(g_cs输入文件全路径名称 + ".bak")
Label_i200签名_101:
            Try
                g_acadDocument.Close(SaveChanges:=True)
            Catch ex As Exception

            End Try

        Next n循环
        Return 0

    End Function

    Public Function i225插入一个签名块(ByVal cs签名块全路径文件名 As String, ByVal cs第二签名块全路径文件名 As String) As Integer

        Dim i As Integer
        Dim csTemp As String

        Dim objBlockRef As AutoCAD.AcadBlockReference
        Dim ptBase(0 To 2) As Double

        If (Left(g_cs标题栏块名, 9) <> "TITLE_1_1" And Left(g_cs标题栏块名, 8) <> "TITLE_0_") And g_cs签名者身份 = "批准" Then

            csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                "警告：标题栏 " + g_cs标题栏块名 + " 没有 '批准' 栏。" ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
            g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
            MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            i225插入一个签名块 = 1 ' i = 1 没有 '批准' 栏
            Exit Function

        End If

        ' 求得实际所需的插入点坐标
        Dim d插入点(0 To 2) As Double
        Dim d设计栏插入点(0 To 2) As Double
        Dim d设计栏高度 As Double
        Dim d插入块比例 As Double ' 插入块宽度默认 19

        ' 设计,校对,审核,标检,工艺,批准
        If (Left(g_cs标题栏块名, 9) = "TITLE_1_1" Or Left(g_cs标题栏块名, 8) = "TITLE_0_") Then

            d设计栏插入点(1) = g_d标题栏插入点(1) + 46.833 * g_d标题栏比例
            d设计栏高度 = 8.1667 * g_d标题栏比例
            d插入块比例 = 0.9

        ElseIf (Left(g_cs标题栏块名, 9) = "TITLE_1_2" Or Left(g_cs标题栏块名, 9) = "TITLE_1_3" Or Left(g_cs标题栏块名, 8) = "TITLE_3_") Then

            d设计栏插入点(1) = g_d标题栏插入点(1) + 46 * g_d标题栏比例
            d设计栏高度 = 9 * g_d标题栏比例
            d插入块比例 = 0.95

        ElseIf (Left(g_cs标题栏块名, 9) = "TITLE_1_4" Or Left(g_cs标题栏块名, 8) = "TITLE_4_") Then

            d设计栏插入点(1) = g_d标题栏插入点(1) + 30 * g_d标题栏比例
            d设计栏高度 = 6 * g_d标题栏比例
            d插入块比例 = 0.6666667

        Else

            csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                "错误：225-1读取标题栏信息失败。" & vbCrLf + _
                "标题栏名称 '" + g_cs标题栏块名 + "' 不正确" ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
            g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
            MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            i225插入一个签名块 = -1
            Exit Function

        End If

        d插入点(0) = g_d标题栏插入点(0) - 165 * g_d标题栏比例
        d插入点(2) = 0

        If g_cs签名者身份 = "设计" Then
            d插入点(1) = d设计栏插入点(1) - 0 * d设计栏高度 ' + (6 * g_d标题栏比例 - rasterObj.ImageHeight) / 2
        ElseIf g_cs签名者身份 = "校对" Then
            d插入点(1) = d设计栏插入点(1) - 1 * d设计栏高度 ' + (6 * g_d标题栏比例 - rasterObj.ImageHeight) / 2
        ElseIf g_cs签名者身份 = "审核" Then
            d插入点(1) = d设计栏插入点(1) - 2 * d设计栏高度 ' + (6 * g_d标题栏比例 - rasterObj.ImageHeight) / 2
        ElseIf g_cs签名者身份 = "标检" Then
            d插入点(1) = d设计栏插入点(1) - 3 * d设计栏高度 ' + (6 * g_d标题栏比例 - rasterObj.ImageHeight) / 2
        ElseIf g_cs签名者身份 = "工艺" Then
            d插入点(1) = d设计栏插入点(1) - 4 * d设计栏高度 ' + (6 * g_d标题栏比例 - rasterObj.ImageHeight) / 2
        ElseIf g_cs签名者身份 = "批准" Then
            d插入点(1) = d设计栏插入点(1) - 5 * d设计栏高度 ' + (8.1667 * g_d标题栏比例 - rasterObj.ImageHeight) / 2
        End If

        ' 至此,
        ' d插入点 表示签名栏的左下角,
        ' d设计栏高度 表示签名栏的高度(已按 g_d标题栏比例 放大),
        ' d插入块比例 表示对外部参照块进行缩放的比例

        On Error Resume Next

        Dim theSSet签名块 As AutoCAD.AcadSelectionSet

        theSSet签名块 = g_acadDocument.SelectionSets.Item("theSSet签名块")
        If Err.Number = 0 Then
            theSSet签名块.Clear()
        Else
            theSSet签名块 = g_acadDocument.SelectionSets.Add("theSSet签名块")
        End If

        '   删除原有的签名块
        Dim pt1(0 To 2) As Double
        Dim pt2(0 To 2) As Double

        pt1(0) = d插入点(0) - 1 * g_d标题栏比例 ' 因为各个图片高度(插入块比例)不一致, 所以插入点范围适当放宽.
        pt1(1) = d插入点(1) - 1 * g_d标题栏比例
        pt1(2) = d插入点(2)
        pt2(0) = d插入点(0) + 19 * 2 * g_d标题栏比例
        pt2(1) = d插入点(1) + d设计栏高度 - 1 * g_d标题栏比例
        pt2(2) = d插入点(2)

        Dim filterType As Object = Nothing
        Dim filterData As Object = Nothing

        i = iCreateSSetFilter(filterType, filterData, -4, "<OR", 0, "INSERT", 0, "TEXT", -4, "OR>", -4, ">,>,*", 10, pt1, -4, "<,<,*", 10, pt2) ' AcadRasterImage 对象的 DXF 图元名称是 "IMAGE", 而不是 "RASTER"
        If i < 0 Then
            ' 显示错误信息 ......

            i225插入一个签名块 = -1
            Exit Function
        End If

        On Error Resume Next

        '   读入签名块(acSelectionSetAll)
        theSSet签名块.Select(AutoCAD.AcSelect.acSelectionSetAll, , , filterType, filterData)
        If Err.Number <> 0 Then
            csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                "错误：读取图框与标题栏信息失败。" & vbCrLf & _
                vbCrLf & "错误代码 = " & Format(Err.Number, "0") & _
                vbCrLf & "错误描述: " & Err.Number ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
            g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
            MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            i225插入一个签名块 = -1
            Exit Function
        End If

        If theSSet签名块.Count > 0 Then
            Dim objEntity As AutoCAD.AcadEntity
            Dim objAAA As AutoCAD.AcadBlockReference
            Dim objBBB As SymBBAuto.McadPartReference
            Debug.Print(theSSet签名块.Count)
            For i = 0 To theSSet签名块.Count - 1
                objEntity = theSSet签名块.Item(i)
                If TypeOf (theSSet签名块.Item(i)) Is AutoCAD.AcadBlockReference Then
                    objAAA = theSSet签名块.Item(i)

                End If
                If TypeOf (theSSet签名块.Item(i)) Is SymBBAuto.McadPartReference Then
                    objbbb = theSSet签名块.Item(i)
                    Debug.Print(objEntity.ObjectName & "//" & objBBB.Origin(0) & "///" & objBBB.Layer)

                End If
                Debug.Print(objEntity.ObjectName)
                objEntity.Delete()
            Next i

        End If

        '   写入签名日期
        Dim cs签名日期 As String
        Dim objText As AutoCAD.AcadText

        pt1(0) = d插入点(0) + (19 + 2) * g_d标题栏比例
        pt1(1) = d插入点(1) + (d设计栏高度 - 3 * g_d标题栏比例) / 2
        pt1(2) = d插入点(2)

        pt2(0) = d插入点(0) + (19 + 19 - 2) * g_d标题栏比例
        pt2(1) = pt1(1)
        pt2(2) = pt1(2)

        cs签名日期 = Trim(g_cs签名年) + "-" + Trim(g_cs签名月) + "-" + Trim(g_cs签名日)
        objText = g_acadDocument.ModelSpace.AddText(cs签名日期, pt1, 3 * g_d标题栏比例)
        '    objText.Alignment = acAlignmentCenter
        objText.Alignment = AutoCAD.AcAlignment.acAlignmentFit
        objText.TextAlignmentPoint = pt2
        objText.color = AutoCAD.ACAD_COLOR.acGreen
        objText.Lineweight = AutoCAD.ACAD_LWEIGHT.acLnWt025

        '   写入签名者姓名
        If (g_cs签名者身份 = "设计" Or g_cs签名者身份 = "校对" Or g_cs签名者身份 = "审核") And _
            g_cs第二签名者姓名 <> "0000-无" Then
            '        d插入点(0) = g_d标题栏插入点(0) - (165 - 19 * (1 - d插入块比例) / 4) * g_d标题栏比例
            d插入点(0) = g_d标题栏插入点(0) - 165 * g_d标题栏比例
            d插入点(1) = d插入点(1) + d设计栏高度 / 6.5

            If (Left(g_cs标题栏块名, 9) = "TITLE_1_1" Or Left(g_cs标题栏块名, 8) = "TITLE_0_") Then

                '            d插入块比例 = 0.9
                d插入块比例 = 0.55

            ElseIf (Left(g_cs标题栏块名, 9) = "TITLE_1_2" Or Left(g_cs标题栏块名, 9) = "TITLE_1_3" Or Left(g_cs标题栏块名, 8) = "TITLE_3_") Then

                '            d插入块比例 = 0.95
                d插入块比例 = 0.55

            ElseIf (Left(g_cs标题栏块名, 9) = "TITLE_1_4" Or Left(g_cs标题栏块名, 8) = "TITLE_4_") Then

                '            d插入块比例 = 0.6666667
                d插入块比例 = 0.5

            Else

                csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                    "错误：225-2读取标题栏信息失败。" & vbCrLf + _
                    "标题栏名称 '" + g_cs标题栏块名 + "' 不正确" ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
                g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
                MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i225插入一个签名块 = -1
                Exit Function

            End If

            objBlockRef = g_acadDocument.ModelSpace.InsertBlock(d插入点, cs签名块全路径文件名, d插入块比例 * g_d标题栏比例, d插入块比例 * g_d标题栏比例, d插入块比例 * g_d标题栏比例, 0.0#)
            objBlockRef.color = AutoCAD.ACAD_COLOR.acYellow
            objBlockRef.Lineweight = AutoCAD.ACAD_LWEIGHT.acLnWt025

            d插入点(0) = d插入点(0) + (19 / 2) * g_d标题栏比例
            objBlockRef = g_acadDocument.ModelSpace.InsertBlock(d插入点, cs第二签名块全路径文件名, d插入块比例 * g_d标题栏比例, d插入块比例 * g_d标题栏比例, d插入块比例 * g_d标题栏比例, 0.0#)
            objBlockRef.color = AutoCAD.ACAD_COLOR.acYellow
            objBlockRef.Lineweight = AutoCAD.ACAD_LWEIGHT.acLnWt025

        Else

            Err.Clear()

            d插入点(0) = g_d标题栏插入点(0) - (165 - 19 * (1 - d插入块比例) / 2) * g_d标题栏比例 ' + (19 * g_d标题栏比例 - rasterObj.ImageWidth) / 2
            objBlockRef = g_acadDocument.ModelSpace.InsertBlock(d插入点, cs签名块全路径文件名, d插入块比例 * g_d标题栏比例, d插入块比例 * g_d标题栏比例, d插入块比例 * g_d标题栏比例, 0.0#)
            objBlockRef.color = AutoCAD.ACAD_COLOR.acYellow
            objBlockRef.Lineweight = AutoCAD.ACAD_LWEIGHT.acLnWt025

            If Err.Number <> 0 Then

                csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                    "插入签名块 " + cs签名块全路径文件名 + " 错误!" & vbCrLf & _
                    vbCrLf & "错误代码 = " & Format(Err.Number, "0") & _
                    vbCrLf & "错误描述: " & Err.Number ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
                g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
                MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            End If

        End If

        '------------------------------------------------------------------
        ' 写扩展数据
        '' ''Dim csAppName As String
        '' ''Dim li字节和 As Long

        '' ''csAppName = "SPEC_" + g_cs签名者身份 ' 例: "SPEC_设计"

        ' '' '' 求 li字节和
        '' ''li字节和 = &H12345678

        '' ''i = iSetXData(g_obj标题栏BlockRef, _
        '' ''    csAppName, _
        '' ''    g_cs签名者姓名, _
        '' ''    li字节和, _
        '' ''    g_cs图纸代号 _
        '' ''    )

        '' ''objBlockRef.Update()

    End Function

    Public Function i100Get图框与标题栏信息() As Integer

        Dim i As Integer
        Dim csTemp As String

        '    Dim theSSet图框与标题栏 As AcadSelectionSet
        Dim theSSet图框 As AutoCAD.AcadSelectionSet
        Dim theSSet标题栏 As AutoCAD.AcadSelectionSet = Nothing

        Try
            theSSet标题栏 = g_acadDocument.SelectionSets.Item("theSSet标题栏")
            theSSet标题栏.Clear()
        Catch ex As Exception
           
            Dim nI As Byte
            nI = 0
lineTry012:
            Try
                theSSet标题栏 = g_acadDocument.SelectionSets.Add("theSSet标题栏")
            Catch exsleep As Exception
                nI = nI + 1
                If nI > 2 Then

                    Return -1
                ElseIf nI = 1 Then
                    '' ''CAD未完全打开，
                    System.Threading.Thread.Sleep(5000)
                    GoTo lineTry012
                ElseIf nI = 2 Then
                    System.Threading.Thread.Sleep(10000)
                    GoTo lineTry012
                End If
            End Try



        End Try


        '   读入标题栏信息

        Dim filterType As Object = Nothing
        Dim filterData As Object = Nothing

        i = iCreateSSetFilter(filterType, filterData, _
            0, "*INSERT*", _
            2, "TITLE_*" _
            )
        If i < 0 Then
            ' 显示错误信息 ......

            i100Get图框与标题栏信息 = -1
            Exit Function
        End If

        Try
            theSSet标题栏.Select(AutoCAD.AcSelect.acSelectionSetAll, , , filterType, filterData)
            ' theSSet标题栏.Select(AutoCAD.AcSelect.acSelectionSetAll, )
        Catch ex As Exception
            csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                            "错误：100读取标题栏信息失败。" & vbCrLf & _
                            vbCrLf & "错误代码 = " & Format(Err.Number, "0") & _
                            vbCrLf & "错误描述: " & Err.Number ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
            g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
            MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            i100Get图框与标题栏信息 = -1
            Exit Function
        End Try


        If theSSet标题栏.Count < 1 Then
            csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                "错误：图纸中找不到标题栏" + vbCrLf
            g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
            MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            i100Get图框与标题栏信息 = -1
            Exit Function
            ''''                    ElseIf theSSet标题栏.Count > 1 Then
            ''''                        cstemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
            ''''                            "错误：图纸中存在多个标题栏" + vbCrLf
            ''''                        g_acadDocument.Utility.Prompt vbCrLf + cstemp + vbCrLf ' vbCrLf
            ''''                        MsgBox cstemp ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
            ''''
            ''''                        i100Get图框与标题栏信息 = -1
            ''''                        Exit Function
        End If

        '    Dim obj图框与标题栏BlockRef As AcadBlockReference
        Dim obj标题栏BlockRef As AutoCAD.AcadBlockReference
        Dim obj图框BlockRef As AutoCAD.AcadBlockReference

        Dim i标题栏循环 As Integer

Label_i100Get图框与标题栏信息_000:

        For i标题栏循环 = 0 To theSSet标题栏.Count - 1

            '        Set obj图框与标题栏BlockRef = theSSet图框与标题栏(0)
            obj标题栏BlockRef = theSSet标题栏(i标题栏循环)
            g_d标题栏插入点(0) = obj标题栏BlockRef.InsertionPoint(0)
            g_d标题栏插入点(1) = obj标题栏BlockRef.InsertionPoint(1) ' 选择图框、确定设计签名栏插入位置
            g_d标题栏插入点(2) = 0

            g_d标题栏比例 = obj标题栏BlockRef.XScaleFactor
            g_cs标题栏块名 = UCase(obj标题栏BlockRef.Name) ' 确定标题栏类型(有无批准栏)、设计签名栏的高度与插入位置

            '        Set g_obj标题栏BlockRef = theSSet图框与标题栏(0)
            g_obj标题栏BlockRef = theSSet标题栏(i标题栏循环)

            Dim attVars As Object
            attVars = obj标题栏BlockRef.GetAttributes

            g_cs图纸代号 = "ABCDEF"
            For i = 0 To UBound(attVars)

                csTemp = vbCrLf + "属性标签: " + attVars(i).TagString + vbCrLf + _
                    "属性值: " + attVars(i).TextString + vbCrLf   ' vbCrLf
                '            g_acadDocument.Utility.Prompt vbCrLf + cstemp + vbCrLf ' vbCrLf
                '            MsgBox cstemp ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                If Left(attVars(i).TagString, 12) = "GEN-TITLE-NR" Then
                    g_cs图纸代号 = attVars(i).TextString
                ElseIf Left(attVars(i).TagString, 13) = "GEN-TITLE-DAT" Then
                    attVars(i).TextString = ""
                End If

            Next i

            '       读入图框信息
            Try
                theSSet图框 = g_acadDocument.SelectionSets.Item("theSSet图框")
                theSSet图框.Clear()
            Catch ex As Exception
                theSSet图框 = g_acadDocument.SelectionSets.Add("theSSet图框")
            End Try

            '        i = iCreateSSetFilter(filterType, filterData, _
            '            0, "INSERT", _
            '            -4, "<OR", _
            '            2, "*_SHEET_A*", _
            '            2, "SHEET_A*", _
            '            -4, "OR>" _
            '            )
            i = iCreateSSetFilter(filterType, filterData, _
                0, "INSERT", _
                -4, "<OR", _
                2, "*SHEET_A*", _
                2, "CYQ_A0*", _
                2, "CYQTANK_A0*", _
                2, "JRQ_A0*", _
                2, "NQQ_A0*", _
                2, "PD_A*", _
                -4, "OR>" _
                )
            If i < 0 Then
                ' 显示错误信息 ......

                i100Get图框与标题栏信息 = -1
                Exit Function
            End If

            Try
                theSSet图框.Select(AutoCAD.AcSelect.acSelectionSetAll, , , filterType, filterData)
            Catch ex As Exception
                csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                    "错误：读取图框信息失败。" & vbCrLf & _
                    vbCrLf & "错误代码 = " & Format(Err.Number, "0") & _
                    vbCrLf & "错误描述: " & Err.Number ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
                g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
                MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i100Get图框与标题栏信息 = -1
                Exit Function
            End Try


            If theSSet图框.Count < 1 Then
                csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                    "错误：没有找到 '*SHEET_A*' 图框!" & vbCrLf
                '                vbCrLf & "错误代码 = " & Format(Err.Number, "0") & _
                '                vbCrLf & "错误描述: " & Error(Err.Number) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
                g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
                MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i100Get图框与标题栏信息 = -1
                Exit Function
                ''''                        ElseIf theSSet图框与标题栏.Count > 1 Then
                ''''                            cstemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                ''''                                "错误：图纸中存在多个图框" + vbCrLf
                ''''                            g_acadDocument.Utility.Prompt vbCrLf + cstemp + vbCrLf ' vbCrLf
                ''''                            MsgBox cstemp ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel
                ''''
                ''''                            i100Get图框与标题栏信息 = -1
                ''''                            Exit Function
            End If

            Dim i图框循环 As Integer

            For i图框循环 = 0 To theSSet图框.Count - 1

                '            Set obj图框BlockRef = theSSet图框与标题栏(0)
                obj图框BlockRef = theSSet图框(i图框循环)

                Dim minExt As Object = Nothing
                Dim maxExt As Object = Nothing

                obj图框BlockRef.GetBoundingBox(minExt, maxExt)

                If minExt(0) > g_d标题栏插入点(0) Or minExt(1) > g_d标题栏插入点(1) Or _
                   maxExt(0) < g_d标题栏插入点(0) Or maxExt(1) < g_d标题栏插入点(1) Then

                    ' 未包含标题栏的图框暂不处理
                    GoTo Label_i100Get图框与标题栏信息_001

                End If

                g_d图框插入点(0) = obj图框BlockRef.InsertionPoint(0)
                g_d图框插入点(1) = obj图框BlockRef.InsertionPoint(1)
                g_d图框插入点(2) = obj图框BlockRef.InsertionPoint(2)

                g_obj图框BlockDef = g_acadDocument.Blocks.Item(obj图框BlockRef.Name)

  
                g_d图框最小点(0) = minExt(0)
                g_d图框最小点(1) = minExt(1)
                g_d图框最小点(2) = 0

                g_d图框最大点(0) = maxExt(0)
                g_d图框最大点(1) = maxExt(1)
                g_d图框最大点(2) = 0

                g_cs图框BlockRefName = obj图框BlockRef.Name

                csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                    "图纸代号: " + g_cs图纸代号 + vbCrLf + vbCrLf + _
 _
                    "图框: " + g_cs图框BlockRefName + ":" + vbCrLf + _
                    "图框插入点: " + Format(g_d图框插入点(0), "0.####") + ", " + Format(g_d图框插入点(1), "0.####") + vbCrLf + _
                    "图框最小点: " + Format(g_d图框最小点(0), "0.####") + ", " + Format(g_d图框最小点(1), "0.####") + vbCrLf + _
                    "图框最大点: " + Format(g_d图框最大点(0), "0.####") + ", " + Format(g_d图框最大点(1), "0.####") + vbCrLf + vbCrLf + _
 _
                    "标题栏: " + g_cs标题栏块名 + ":" + vbCrLf + _
                    "标题栏插入点: " + Format(g_d标题栏插入点(0), "0.####") + ", " + Format(g_d标题栏插入点(1), "0.####") + vbCrLf + _
                    "标题栏比例: " + Format(g_d标题栏比例, "0.####") + vbCrLf
                '            g_acadDocument.Utility.Prompt vbCrLf + csTemp + vbCrLf ' vbCrLf
                '            MsgBox csTemp ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                Exit For ' i图框循环

Label_i100Get图框与标题栏信息_001:

            Next i图框循环

            If i图框循环 >= theSSet图框.Count Then
                csTemp = g_acadDocument.Path + "\" + g_acadDocument.Name + vbCrLf + _
                    "错误：图纸中没有找到与标题栏匹配的图框" + vbCrLf
                g_acadDocument.Utility.Prompt(vbCrLf + csTemp + vbCrLf) ' vbCrLf
                MsgBox(csTemp) ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

                i100Get图框与标题栏信息 = -1
                Exit Function
            End If

        Next i标题栏循环

        Return 0
    End Function

    Public Function iCreateSSetFilter(ByRef filterType As Object, ByRef filterData As Object, ByVal ParamArray filter() As Object)
        ''''过滤器//结构缓冲区
        ''''Dxf码--filterType中为（2字节）数字组，filterData中为String字符组。
        If UBound(filter) Mod 2 = 0 Then
            MsgBox("filter 参数无效!") ' vbCrLf vbOKOnly vbYesNo vbYesNoCancel

            iCreateSSetFilter = -1
            Exit Function
        End If

        Dim fType() As Int16
        Dim fData() As Object
        Dim iCount As Integer

        iCount = (UBound(filter) + 1) / 2
        ReDim fType(iCount - 1)
        ReDim fData(iCount - 1)

        Dim i As Integer
        For i = 0 To iCount - 1
            fType(i) = filter(2 * i)
            fData(i) = filter(2 * i + 1)
        Next i

        filterType = fType
        filterData = fData

        iCreateSSetFilter = 0

    End Function




End Module
