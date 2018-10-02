Namespace BomTable
    Friend Class Class_MaterialsStandard

        Implements IDisposable

        Private gStr_DuXN As String   ''用于名称中加了镀锌
        Private Num As Integer ''第几列

        Public Property N As Integer
            Get
                Return Num
            End Get
            Set(value As Integer)
                Num = value
            End Set
        End Property


        ''对TempTable表中第N列信息进行字段分类规范 
        Public Sub Gui_字段规范()
            If g_Temptable.Cells(N, 2).value = Nothing Then
                Exit Sub
            End If

            Wcs当前父物料_Sub(N)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''///////////////////////////////////////////////////////////////////////////////////////''
            ''以下各字段规整
            ''质保核电等级/材料处理子程序
            Class_等级材料()

            ''''名称和规格处理子程序
            Name_名称规格()

            ''''图号标准号型号处理子程序
            Code_代号()

            ''备注处理子程序
            Comment_备注()
            ''以上各字段规整
            ''///////////////////////////////////////////////////////////////////////////////////////''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ''添加专用件物料号（有图号、按本图、G，D，B通用件）及描述
            Description_物料描述()



        End Sub

#Region "各字段规整"

        ''质保核电等级/材料
        Private Sub Class_等级材料()
            Dim strTemp As String
            ''''质保等级
            strTemp = Replace(Trim(g_Temptable.Cells(N, 9).value), "_", "-")
            If strTemp <> "" Then
                strTemp = Strings.Replace(strTemp, " ", "")
                strTemp = Strings.Replace(strTemp, "（", "(")
                strTemp = Strings.Replace(strTemp, "）", ")")
                g_Temptable.Cells(N, 19) = strTemp
            End If
            ''''核电等级
            strTemp = Replace(Trim(g_Temptable.Cells(N, 10).value), "_", "-")
            If strTemp <> "" Then
                strTemp = Strings.Replace(strTemp, " ", "")
                strTemp = Strings.Replace(strTemp, "（", "(")
                strTemp = Strings.Replace(strTemp, "）", ")")
                g_Temptable.Cells(N, 20) = strTemp
            End If
            ''''材料
            strTemp = Replace(Trim(g_Temptable.Cells(N, 6).value), "_", "-")
            If strTemp <> "" Then

                strTemp = Strings.Replace(strTemp, "（", "(")
                strTemp = Strings.Replace(strTemp, "）", ")")
                strTemp = Strings.Replace(strTemp, " ", "")
                With g_zzb正则表达式
                    .Pattern = "III"
                    If .Test(strTemp) = True Then
                        strTemp = .Replace(strTemp, "Ⅲ")
                    Else
                        With g_zzb正则表达式
                            .Pattern = "II"
                            If .Test(strTemp) = True Then
                                strTemp = .Replace(strTemp, "Ⅱ")
                            Else
                                With g_zzb正则表达式
                                    .Pattern = "20I"
                                    If .Test(strTemp) = True Then
                                        strTemp = .Replace(strTemp, "20Ⅰ")
                                    End If
                                End With
                            End If
                        End With

                    End If

                End With


                If Strings.Right(strTemp, 2) = "IV" Then
                    strTemp = Strings.Replace(strTemp, "IV", "Ⅳ")
                End If

                With g_zzb正则表达式
                    .Pattern = "(三元)?乙丙橡胶"
                    .IgnoreCase = True
                    .Global = False
                    If .Test(strTemp) = True Then
                        strTemp = .Replace(strTemp, "EPDM")
                    Else
                        With g_zzb正则表达式
                            .Pattern = "非石棉"
                            If .Test(strTemp) = True Then
                                strTemp = .Replace(strTemp, "无石棉")
                            Else
                                With g_zzb正则表达式
                                    .Pattern = "级"
                                    If .Test(strTemp) = True Then
                                        strTemp = .Replace(strTemp, "")
                                    End If
                                End With
                            End If
                        End With
                    End If
                End With

                With g_zzb正则表达式
                    .Pattern = "组合件"
                    If .Test(strTemp) = True Then
                        strTemp = ""
                    End If
                End With


            End If
            g_Temptable.Cells(N, 16) = strTemp

        End Sub

        ''名称规格
        Private Sub Name_名称规格()


            Dim i, nlen As Integer
            Dim charT As Char
            Dim strTemp As String
            Dim strName, strGuiGe As String
            strName = "" : strGuiGe = ""
            strTemp = Replace(Trim(g_Temptable.Cells(N, 4).value), "_", "-")
            If strTemp <> "" Then

                strTemp = Strings.Replace(strTemp, "（", "(")
                strTemp = Strings.Replace(strTemp, "）", ")")

                If g_csL类型 = 1 Then
                    ''0818-31-MS项目
                    With g_zzb正则表达式
                        .Pattern = "见图( )?(-)?( )?[0-9][0-9][0-9]"
                        .IgnoreCase = True
                        .Global = False
                        If .Test(strTemp) = True Then
                            strName = strTemp.Replace(" ", "")
                            GoTo lineOn001
                        End If
                    End With


                End If
                nlen = Strings.Len(strTemp)
                For i = nlen To 1 Step -1
                    charT = Strings.Mid(strTemp, i, 1)
                    If IncludeChinese(charT) = 1 Then
                        If i = Len(strTemp) Then
                            strName = Replace(strTemp, " ", "")
                            strGuiGe = ""
                        Else
                            strName = Strings.Left(strTemp, i)
                            strName = Replace(strName, " ", "")
                            strGuiGe = Strings.Right(strTemp, nlen - i)
                            strGuiGe = Strings.Trim(strGuiGe)
                        End If
                        GoTo lineON001
                    End If
                Next
                strName = ""
                strGuiGe = strTemp
            End If

lineOn001:
            If strName <> "" Then
                With g_zzb正则表达式
                    .Pattern = "镀[锌镍]"
                    If .Test(strName) = True Then
                        Dim duXN = .Execute(strName)
                        gStr_DuXN = duXN(0).value

                        strName = .Replace(strName, "")
                    End If
                End With

                With g_zzb正则表达式   ''U形管单位为kg
                    .Pattern = "(U[形型]管$)|(\π[形型]管$)|(换热管$)"
                    If .Test(strName) = True Then
                        g_Temptable.Cells(N, 5) = g_Temptable.Cells(N, 8) : g_Temptable.Cells(N, 7) = 1

                    End If
                End With

                With g_zzb正则表达式   ''U形管单位为kg
                    .Pattern = "(温度计)|(液位计)"
                    If .Test(strName) = True Then
                        .Pattern = "温度计"
                        If .Test(strName) = True Then
                            strName = "温度计"
                        Else
                            strName = "液位计"
                        End If

                    End If
                End With

                If strName = "压力表" Then
                    With g_zzb正则表达式   ''压力表M20*1.5删除
                        .Pattern = "M20[\×x*]1\.5"
                        .IgnoreCase = True
                        If .Test(strGuiGe) = True Then
                            strGuiGe = .Replace(strGuiGe, "")
                        End If
                    End With

                End If

                If strName = "锁扣" Then

                    With g_zzb正则表达式   ''压力表M20*1.5删除
                        .Pattern = "0\.9[\×x*]32[\×x*]50|50[\×x*]32[\×x*]0\.9"
                        .IgnoreCase = True
                        If .Test(strGuiGe) = True Then
                            strGuiGe = "0.9×32×50"
                        End If
                    End With

                End If


            End If



            If strGuiGe <> "" Then
                strGuiGe = Replace(strGuiGe, "\U+03B4", "δ")
                strGuiGe = Replace(strGuiGe, "%%dc", "℃")
                strGuiGe = Replace(strGuiGe, "∅", "Φ")
                strGuiGe = Replace(strGuiGe, "Ф", "Φ")
                strGuiGe = Replace(strGuiGe, "%%c", "Φ")
                strGuiGe = Replace(strGuiGe, "%%d", "°")
                strGuiGe = Replace(strGuiGe, "*", "×")
                strGuiGe = Replace(strGuiGe, "x", "×")
                strGuiGe = Replace(strGuiGe, "\", "/")
                strGuiGe = Replace(strGuiGe, "x", "×")

                strGuiGe = Replace(strGuiGe, "~", "-")
                strGuiGe = Replace(strGuiGe, "～", "-")

                strGuiGe = Replace(strGuiGe, ",", " ")
                strGuiGe = Replace(strGuiGe, ";", " ")
                strGuiGe = Replace(strGuiGe, "，", " ")
                strGuiGe = Replace(strGuiGe, "；", " ")
                strGuiGe = Replace(strGuiGe, "＝", "=")

                strGuiGe = Replace(strGuiGe, "σ=", "δ=")
                strGuiGe = Replace(strGuiGe, "T=", "δ=")
                strGuiGe = Replace(strGuiGe, "t=", "δ=")
                strGuiGe = Replace(strGuiGe, " δ", "δ")
                strGuiGe = Replace(strGuiGe, "δ", "δ=")
                strGuiGe = Replace(strGuiGe, "= ", "=")
                strGuiGe = Replace(strGuiGe, "==", "=")

                Dim ntemp As Integer
                Dim charI, charJ As Char
lineUp001:
                ntemp = Strings.InStr(strGuiGe, " ")
                If ntemp = 1 Then
                    strGuiGe = strGuiGe.Substring(1, strGuiGe.Length - 1)
                    GoTo lineUp001
                ElseIf ntemp > 1 Then
                    charI = Strings.Mid(strGuiGe, ntemp - 1, 1)
                    charJ = Strings.Mid(strGuiGe, ntemp + 1, 1)
                    If IncludeChinese(charI) <> IncludeChinese(charJ) OrElse IncludeChinese(charJ) <> 2 Then
                        strGuiGe = Strings.Left(strGuiGe, ntemp - 1) & Strings.Right(strGuiGe, Len(strGuiGe) - ntemp)
                    Else
                        strGuiGe = Strings.Left(strGuiGe, ntemp - 1) & "/AsA/" & Strings.Right(strGuiGe, Len(strGuiGe) - ntemp)
                    End If
                    GoTo lineUp001
                End If
                strGuiGe = strGuiGe.Replace("/AsA/", " ")
                strGuiGe = strGuiGe.ToUpper
                strGuiGe = Replace(strGuiGe, "Δ", "δ")
            End If


            g_Temptable.Cells(N, 15) = strName.ToUpper
            g_Temptable.Cells(N, 17) = strGuiGe


        End Sub

        ''代号（图号标准号型号）
        Private Sub Code_代号()
            Dim strTemp As String
            Dim iS无图号 As Boolean = False
            strTemp = Replace(g_Temptable.Cells(N, 3).value, " ", "")

            If g_csL类型 = 1 Then
                ''0818-31-MS项目
                Dim temp_Thh As String = Nothing
                With g_zzb正则表达式
                    .Pattern = "\b[0-9][0-9][0-9][0-9]-[0-9][0-9]-[a-z][a-z]([a-z][a-z])?"  ''0818-31-ms
                    .IgnoreCase = True                                                      ''忽略大小写
                    .Global = False
                    If .Test(strTemp) = True Then  '' (0000-00-MA)
                        For Each item In .Execute(strTemp) '遍历所有符合条件的对象
                            temp_Thh = item.value  ' 将所有符合条件的对象串连起来
                        Next item
                        g_Temptable.Cells(N, 18) = strTemp
                        If temp_Thh = g_MSRrep替换部分 Then

                            g_Temptable.Cells(N, 13) = .Replace(strTemp, g_rep替换成MSR)
                        Else
                            Dim NII As Integer
                            Dim NLENA As Integer
                            NLENA = temp_Thh.Length
                            For NII = 0 To shA.Length - 1
                                If Strings.Left(shA(NII), NLENA) = temp_Thh Then
                                    .Pattern = "M[A-Z][A-Z]([A-Z][A-Z])?[0-9][0-9][0-9][0-9]\b"
                                    .IgnoreCase = True
                                    .Global = False
                                    If .Test(shA(NII)) = True Then
                                        Dim shTemp = .Execute(shA(NII))
                                        g_Temptable.Cells(N, 13) = strTemp.Replace(temp_Thh, shTemp(0).value)
                                    End If
                                    Exit For
                                End If

                            Next

                        End If


                    Else           '' (000-00) 和其它
                        .Pattern = "\b[0-9][0-9][0-9]-[0-9][0-9]\b"
                        .IgnoreCase = True
                        .Global = False
                        If .Test(strTemp) = True Then

                            If g_rep替换成MSR = Strings.Left(g_Temptable.Cells(g_wcs当前父物料(1), 13).value, g_rep替换成MSR.Length) Then
                                ''父物料本图
                                g_Temptable.Cells(N, 13) = g_rep替换成MSR & "-" & strTemp
                                g_Temptable.Cells(N, 18) = g_MSRrep替换部分 & "-" & strTemp
                            Else
                                ''父物料借用
                                .Pattern = "\bM[A-Z][A-Z]([A-Z][A-Z])?[0-9][0-9][0-9][0-9]"
                                .IgnoreCase = True
                                .Global = False
                                If .Test(g_Temptable.Cells(g_wcs当前父物料(1), 13).value) = True Then
                                    Dim temppAA = .Execute(g_Temptable.Cells(g_wcs当前父物料(1), 13).value)
                                    g_Temptable.Cells(N, 13) = temppAA(0).value & "-" & strTemp
                                End If
                                .Pattern = "\b[0-9][0-9][0-9][0-9]-[0-9][0-9]-[a-z][a-z]([a-z][a-z])?"
                                .IgnoreCase = True
                                .Global = False
                                If .Test(g_Temptable.Cells(g_wcs当前父物料(1), 18).value) = True Then
                                    With g_zzb正则表达式
                                        .Pattern = "\bM[A-Z][A-Z]([A-Z][A-Z])?[0-9][0-9][0-9][0-9]"
                                        .IgnoreCase = True
                                        .Global = False
                                        If .Test(g_Temptable.Cells(g_wcs当前父物料(1), 13).value) = True Then
                                            Dim temppAA = .Execute(g_Temptable.Cells(g_wcs当前父物料(1), 13).value)
                                            g_Temptable.Cells(N, 18) = temppAA(0).value & "-" & strTemp
                                        End If
                                    End With

                                End If

                            End If
                        Else
                            ''无图号物料
                            iS无图号 = True
                        End If

                    End If
                End With

            End If



            If strTemp = "" Then
                If InStr(CStr(g_Temptable.Cells(N, 15).value), "垫片") <= 0 AndAlso InStr(CStr(g_Temptable.Cells(N, 15).value), "垫圈") <= 0 _
                    AndAlso InStr(CStr(g_Temptable.Cells(N, 15).value), "弯头") <= 0 AndAlso InStr(CStr(g_Temptable.Cells(N, 15).value), "锁扣") <= 0 _
                    AndAlso InStr(CStr(g_Temptable.Cells(N, 15).value), "填料") <= 0 Then

                    If g_wcs当前父物料(0) = 1 Then
                        g_Temptable.Cells(N, 18) = "N" & g_cs总图号 & "-" & Format(g_wcs当前父物料(3), "00")
                    Else
                        g_Temptable.Cells(N, 18) = "N" & g_Temptable.Cells(g_wcs当前父物料(1), 3).value & "-" & Format(g_wcs当前父物料(3), "00")
                    End If

                    If g_csL类型 = 1 Then
                        ''0818-31-MS项目
                        If g_wcs当前父物料(0) = 1 Then
                            g_Temptable.Cells(N, 18) = "N" & g_rep替换成MSR & "-" & Format(g_wcs当前父物料(3), "00")
                        Else
                            g_Temptable.Cells(N, 18) = "N" & g_Temptable.Cells(g_wcs当前父物料(1), 13).value & "-" & Format(g_wcs当前父物料(3), "00")
                        End If
                    End If

                    With g_zzb正则表达式
                        .Pattern = "NXT"
                        .IgnoreCase = True
                        .Global = False
                        If .Test(g_Temptable.Cells(N, 18).value) = True Then
                            g_Temptable.Cells(N, 18) = ""
                            .Pattern = "钢管"
                            If .Test(g_Temptable.Cells(N, 15).value) = True Then
                                g_Temptable.Cells(N, 18) = "SPECGG"
                            End If
                        End If

                    End With


                End If
            ElseIf strTemp = "按本图" Then
                'With g_zzb正则表达式
                '    .Pattern = "垫[片圈]"
                '    .Global = False
                '    If .Test(CStr(g_Temptable.Cells(N, 15).value)) = True Then
                '        If g_Temptable.Cells(N, 17).value <> Nothing Then
                '            GoTo lineNext456
                '        End If
                '    Else
                '        .Pattern = "(锁扣)|[0-9].弯头"
                '        .Global = False
                '        If .Test(CStr(g_Temptable.Cells(N, 15).value)) = True Then
                '            GoTo lineNext456
                '        End If
                '    End If
                'End With
                If g_wcs当前父物料(0) = 1 Then
                    g_Temptable.Cells(N, 18) = "N" & g_cs总图号 & "-" & Format(g_wcs当前父物料(3), "00")
                Else
                    g_Temptable.Cells(N, 18) = "N" & g_Temptable.Cells(g_wcs当前父物料(1), 3).value & "-" & Format(g_wcs当前父物料(3), "00")
                End If

                If g_csL类型 = 1 Then
                    ''0818-31-MS项目
                    If g_wcs当前父物料(0) = 1 Then
                        g_Temptable.Cells(N, 18) = "N" & g_rep替换成MSR & "-" & Format(g_wcs当前父物料(3), "00")
                    Else
                        g_Temptable.Cells(N, 18) = "N" & g_Temptable.Cells(g_wcs当前父物料(1), 13).value & "-" & Format(g_wcs当前父物料(3), "00")
                    End If
                End If

lineNext456:
            Else
                If g_csL类型 <> 1 Then
                    iS无图号 = True
                End If
            End If

            Dim strTwoL, strThrL As String
            strTwoL = Strings.Left(strTemp, 2).ToUpper
            strThrL = Strings.Left(strTemp, 3).ToUpper


            If strTwoL = "HP" OrElse strTwoL = "HH" OrElse strTwoL = "LP" OrElse _
               strTwoL = "DP" OrElse strTwoL = "DS" OrElse _
               strTwoL = "DE" OrElse (strTwoL = "ST" AndAlso Strings.Left(strTemp, 4).ToUpper <> "ST37") OrElse _
               strTwoL = "CD" OrElse strTwoL = "CF" OrElse _
               strTwoL = "WH" OrElse strTwoL = "DF" OrElse _
               strTwoL = "LF" OrElse strTwoL = "HN" OrElse _
               strTwoL = "DC" OrElse strTwoL = "DV" OrElse _
               strTwoL = "MS" OrElse strTwoL = "BP" OrElse _
               strTwoL = "QT" OrElse strThrL = "DFP" OrElse _
               strTwoL = "61" OrElse strTwoL = "62" OrElse _
               strTwoL = "63" OrElse strTwoL = "64" OrElse _
               strTwoL = "65" OrElse strTwoL = "66" Then
                g_Temptable.Cells(N, 18).value = strTemp
                iS无图号 = False


            End If



            If iS无图号 = True Then

                ''代号、型号、有图号（不包括MSR）
                strTemp = strTemp.ToUpper
                strTemp = Replace(strTemp, "_", "-")
                strTemp = Replace(strTemp, "\", "/")
                strTemp = Replace(strTemp, "/T", "")
                strTemp = Replace(strTemp, "'", Chr(34))
                strTemp = Replace(strTemp, "’", Chr(34))
                strTemp = Replace(strTemp, ChrW(8220), Chr(34))
                strTemp = Replace(strTemp, ChrW(8221), Chr(34))




                With g_zzb正则表达式
                    .Pattern = "(\bGB)|(\bHG)|(\bJB)"
                    .IgnoreCase = True
                    .Global = False
                    If .Test(strTemp) = True Then
                        Dim iNum As Integer

                        For iNum = 0 To conVersion.GetUpperBound(0)
                            If strTemp = conVersion(iNum, 0) Then
                                g_Temptable.Cells(N, 15) = conVersion(iNum, 1) ''名称替换
                                Exit For
                            End If
                        Next
                    End If
                End With

                If strTemp = "DTF-C0" Or strTemp = "DTF-CO" Then
                    strTemp = "DTF-CO"
                    Dim sTT As String
                    sTT = g_Temptable.Cells(N, 16).value
                    If sTT.ToUpper = "TP304" Or sTT.ToUpper = "06CR19NI10" Then
                        g_Temptable.Cells(N, 16) = "304"
                    End If
                ElseIf strTemp = "GB827" Then

                    If g_Temptable.Cells(N, 16).value = "铜" Then
                        g_Temptable.Cells(N, 16) = "H62"
                    End If
                ElseIf strTemp = "QKD-153G1/2""" Then
                    strTemp = "QKD-153_G1/2"""
                End If


                g_Temptable.Cells(N, 18).value = strTemp

            Else  ''有图号
                strTemp = g_Temptable.Cells(N, 18).value
                If IsNothing(strTemp) = False AndAlso strTemp.Length > 18 Then
                    g_Temptable.Cells(N, 18) = MaxSap(strTemp)
                    ''g_Temptable.Cells(N, 25) = 1
                End If

            End If
        End Sub

        ''备注字段
        Private Sub Comment_备注()
            ''''备注
            Dim strTemp As String
            strTemp = Trim(g_Temptable.Cells(N, 12).value)
            If strTemp <> "" Then
                strTemp = strTemp.ToUpper
                strTemp = Strings.Replace(strTemp, " ", "")
                strTemp = Strings.Replace(strTemp, "_", "-")
                strTemp = Strings.Replace(strTemp, "/T", "")

                Dim sTrPP_temp As String
                sTrPP_temp = ""
                With g_zzb正则表达式
                    .Pattern = "[待带代]定"
                    If .Test(strTemp) = True Then
                        g_Temptable.Cells(N, 21) = "待定" : gStr_DuXN = ""  ''该字段的镀锌赋值清除，不影响下一条物料
                        Exit Sub
                    End If
                End With
                With g_zzb正则表达式
                    .Pattern = "HDCJ-[0-9]([0-9])?"
                    .IgnoreCase = True
                    .Global = False
                    If .Test(strTemp) = True Then
                        Dim SHTR_STR = .Execute(strTemp)
                        sTrPP_temp = SHTR_STR(0).VALUE
                    End If
                End With
                With g_zzb正则表达式
                    .Pattern = "F5200"
                    .IgnoreCase = True
                    .Global = False
                    If .Test(strTemp) = True Then
                        Dim SHTR_STR = .Execute(strTemp)
                        sTrPP_temp = sTrPP_temp & SHTR_STR(0).VALUE
                    End If
                End With
                With g_zzb正则表达式
                    .Pattern = "氧化"
                    .IgnoreCase = True
                    .Global = False
                    If .Test(strTemp) = True Then
                        Dim SHTR_STR = .Execute(strTemp)
                        sTrPP_temp = sTrPP_temp & SHTR_STR(0).VALUE
                    End If
                End With

                With g_zzb正则表达式
                    .Pattern = "(温度计)|(液位计)"
                    If .Test(g_Temptable.Cells(N, 15).value) = True Then
                        .Pattern = "1级"
                        If .Test(strTemp) = True Then
                            sTrPP_temp = sTrPP_temp & "1级"
                        End If
                    End If
                End With
                'With g_zzb正则表达式
                '    .Pattern = "抽芯"
                '    If .Test(strTemp) = True Then
                '        sTrPP_temp = sTrPP_temp & "抽芯"
                '    End If
                'End With
                With g_zzb正则表达式
                    .Pattern = "(带套管)|(保护套)"
                    If .Test(strTemp) = True Then
                        sTrPP_temp = sTrPP_temp & "带套管"
                    End If
                End With
                'With g_zzb正则表达式
                '    .Pattern = "(防震)|(防振)"
                '    If .Test(strTemp) = True Then
                '        sTrPP_temp = sTrPP_temp & "防震"
                '    End If
                'End With
                With g_zzb正则表达式
                    .Pattern = "法兰及连接件"
                    If .Test(strTemp) = True Then
                        sTrPP_temp = sTrPP_temp & "配反法兰及连接件"
                    End If
                End With
                With g_zzb正则表达式
                    .Pattern = "排污阀"
                    If .Test(strTemp) = True Then
                        sTrPP_temp = sTrPP_temp & "排污阀"
                    End If
                End With
                With g_zzb正则表达式
                    .Pattern = "冷凝圈"
                    If .Test(strTemp) = True Then
                        sTrPP_temp = sTrPP_temp & "带冷凝圈"
                    End If
                End With


                If gStr_DuXN <> "" Then
                    g_Temptable.Cells(N, 21) = gStr_DuXN & " " & sTrPP_temp
                Else
                    g_Temptable.Cells(N, 21) = sTrPP_temp
                End If


            Else
                If gStr_DuXN <> "" Then
                    g_Temptable.Cells(N, 21) = gStr_DuXN
                End If

            End If
            gStr_DuXN = ""  ''该字段的镀锌赋值清除，不影响下一条物料
        End Sub

#End Region

        ''SAP号超过18字符
        Private Function MaxSap(ByVal tempStr As String) As String

            Dim i As Integer

            Do While tempStr.Length > 18
                i = tempStr.LastIndexOf("-0")
                If i < 0 Then
                    i = tempStr.LastIndexOf(".0")
                    If i < 0 Then
                        Exit Do
                    End If
                End If
                tempStr = tempStr.Substring(0, i + 1) & tempStr.Substring(i + 2)
            Loop

            Return tempStr
        End Function


        ''添加专用件物料号（有图号、按本图、G，D，B通用件）及描述
        Private Sub Description_物料描述()
            Dim strTemp As String
            strTemp = g_Temptable.Cells(N, 18).value
            If strTemp = Nothing OrElse strTemp.Length < 4 Then
                GoTo lineSAP描述up
            End If

            Dim strPP As String
            Dim strOneL, strTwoL, strThrL As String

            strOneL = Strings.Left(strTemp, 1).ToUpper
            strTwoL = Strings.Left(strTemp, 2).ToUpper
            strThrL = Strings.Left(strTemp, 3).ToUpper


            If strTwoL = "HP" OrElse strTwoL = "HH" OrElse strTwoL = "LP" OrElse _
               strTwoL = "DP" OrElse strTwoL = "DS" OrElse _
               strTwoL = "DE" OrElse (strTwoL = "ST" AndAlso Strings.Left(strTemp, 4).ToUpper <> "ST37") OrElse _
               strTwoL = "CD" OrElse strTwoL = "CF" OrElse _
               strTwoL = "WH" OrElse strTwoL = "DF" OrElse _
               strTwoL = "LF" OrElse strTwoL = "HN" OrElse _
               strTwoL = "DC" OrElse strTwoL = "DV" OrElse _
               strTwoL = "MS" OrElse strTwoL = "BP" OrElse _
               strTwoL = "QT" OrElse strThrL = "DFP" OrElse _
               strTwoL = "61" OrElse strTwoL = "62" OrElse _
               strTwoL = "63" OrElse strTwoL = "64" OrElse _
               strTwoL = "65" OrElse strTwoL = "66" Then
                g_Temptable.Cells(N, 13) = g_Temptable.Cells(N, 18).value
                strPP = g_Temptable.Cells(N, 15).value
                If g_Temptable.Cells(N, 16).value <> Nothing Then
                    strPP = strPP & "_" & g_Temptable.Cells(N, 16).value
                End If
                If g_Temptable.Cells(N, 17).value <> Nothing Then
                    strPP = strPP & "_" & g_Temptable.Cells(N, 17).value
                End If
                strPP = strPP & "_" & g_Temptable.Cells(N, 18).value
                If g_Temptable.Cells(N, 19).value <> Nothing Then
                    strPP = strPP & "_" & g_Temptable.Cells(N, 19).value
                End If
                If g_Temptable.Cells(N, 20).value <> Nothing Then
                    strPP = strPP & "_" & g_Temptable.Cells(N, 20).value
                End If
                If g_Temptable.Cells(N, 21).value <> Nothing Then
                    strPP = strPP & "_" & g_Temptable.Cells(N, 21).value
                End If

                g_Temptable.Cells(N, 14) = strPP     ''SAP描述
                GoTo lineSAP描述
            ElseIf strOneL = "G" OrElse strOneL = "B" OrElse strOneL = "D" Then
                With g_zzb正则表达式
                    .Pattern = "[GBD]([1-9])?[0-9][0-9]\.[0-9][0-9]"
                    .IgnoreCase = True : .Global = False
                    If .Test(strTemp) = True Then
                        g_Temptable.Cells(N, 13) = g_Temptable.Cells(N, 18).value
                        strPP = g_Temptable.Cells(N, 15).value
                        If g_Temptable.Cells(N, 16).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 16).value
                        End If
                        If g_Temptable.Cells(N, 17).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 17).value
                        End If
                        strPP = strPP & "_" & g_Temptable.Cells(N, 18).value
                        If g_Temptable.Cells(N, 19).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 19).value
                        End If
                        If g_Temptable.Cells(N, 20).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 20).value
                        End If
                        If g_Temptable.Cells(N, 21).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 21).value
                        End If

                        g_Temptable.Cells(N, 14) = strPP     ''SAP描述
                        GoTo lineSAP描述
                    End If
                End With

            ElseIf strOneL = "N" Then
                With g_zzb正则表达式
                    .Pattern = "N[(MMS)(MHP)(MLP)]?[A-Z][A-Z][0-9][0-9][0-9]|N[BDKG]([1-9])?[0-9][0-9]\.[0-9][0-9]|NDFP[0-9][0-9][0-9]"
                    .IgnoreCase = True : .Global = False
                    If .Test(strTemp) = True Then
                        g_Temptable.Cells(N, 13) = strTemp
                        strPP = g_Temptable.Cells(N, 15).value
                        If g_Temptable.Cells(N, 16).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 16).value
                        End If
                        If g_Temptable.Cells(N, 17).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 17).value
                        End If
                        strPP = strPP & "_" & g_Temptable.Cells(N, 18).value
                        If g_Temptable.Cells(N, 19).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 19).value
                        End If
                        If g_Temptable.Cells(N, 20).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 20).value
                        End If
                        If g_Temptable.Cells(N, 21).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 21).value
                        End If
                        g_Temptable.Cells(N, 14) = strPP     ''SAP描述
                        GoTo lineSAP描述
                    End If
                End With

            ElseIf strOneL = "K" OrElse strTwoL = "SP" Then
                With g_zzb正则表达式
                    .Pattern = "(K[0-9][0-9].[0-9][0-9](H)?\b)|(SPEC[0-9]{4})|SPECGG"
                    .IgnoreCase = True
                    .Global = False
                    If .Test(strTemp) = True Then

                        .Pattern = "K33.01|K33.02H"  ''单位为kg
                        If .Test(strTemp) = True Then
                            g_Temptable.Cells(N, 13) = strTemp : g_Temptable.Cells(N, 14) = "保温钩钉钢带_32×0.9_" & strTemp
                            If strTemp = "K33.02H" Then  ''含质保等级
                                strPP = "保温钩钉钢带_32×0.9_" & strTemp
                                If g_Temptable.Cells(N, 19).value <> Nothing Then
                                    strPP = strPP & "_" & g_Temptable.Cells(N, 19).value
                                End If
                                If g_Temptable.Cells(N, 20).value <> Nothing Then
                                    strPP = strPP & "_" & g_Temptable.Cells(N, 20).value
                                End If
                                If g_Temptable.Cells(N, 21).value <> Nothing Then
                                    strPP = strPP & "_" & g_Temptable.Cells(N, 21).value
                                End If
                                g_Temptable.Cells(N, 14) = strPP
                            End If
                            g_Temptable.Cells(N, 5) = g_Temptable.Cells(N, 8) : g_Temptable.Cells(N, 7) = 1
                            GoTo lineSAP描述
                        Else
                            .Pattern = "K18.[0-9][0-9]"  ''K18.**不需要材料
                            If .Test(strTemp) = True Then
                                g_Temptable.Cells(N, 13) = g_Temptable.Cells(N, 18).value
                                g_Temptable.Cells(N, 13).font.color = RGB(255, 0, 0)
                                strPP = g_Temptable.Cells(N, 15).value
                                GoTo lineNO材料
                            End If
                        End If
                        g_Temptable.Cells(N, 13) = g_Temptable.Cells(N, 18).value
                        g_Temptable.Cells(N, 13).font.color = RGB(255, 0, 0)
                        strPP = g_Temptable.Cells(N, 15).value
                        If g_Temptable.Cells(N, 16).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 16).value
                        End If
lineNO材料:
                        If g_Temptable.Cells(N, 17).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 17).value
                        End If
                        strPP = strPP & "_" & g_Temptable.Cells(N, 18).value
                        If g_Temptable.Cells(N, 19).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 19).value
                        End If
                        If g_Temptable.Cells(N, 20).value <> Nothing Then
                            strPP = strPP & "_" & g_Temptable.Cells(N, 20).value
                        End If
                        strPP = "=""" & strPP & """&IF(U" & N & "<>"""",""_""&U" & N & ","""")"   ''SAP描述
                        g_Temptable.Cells(N, 14) = strPP
                        GoTo lineSAP描述
                    End If
                End With

            End If



lineSAP描述up:
            If g_Temptable.Cells(N, 21).value = "待定" Then
                With g_zzb正则表达式
                    .Pattern = "垫[圈片]|螺[栓柱母]|法兰(盖)?"
                    strTemp = g_Temptable.Cells(N, 15).value
                    If .Test(strTemp) = True Then
                        Dim SHTR_STR = .Execute(strTemp)
                        g_Temptable.Cells(N, 14) = SHTR_STR(0).VALUE & "_待定"
                        g_Temptable.Cells(N, 14).font.color = RGB(255, 0, 0)
                        GoTo lineSAP描述
                    End If
                End With
            End If
            g_Temptable.Cells(N, 14) = "=O" & N & "&IF(And(P" & N & "<>"""",P" & N & "<>""组合件""),""_""&P" & N & ","""")" & "&IF(Q" & N & "<>"""",""_""&Q" & N & ","""")" _
                                    & "&IF(R" & N & "<>"""",""_""&R" & N & ","""")" & "&IF(S" & N & "<>"""",""_""&S" & N & ","""")" _
                                    & "&IF(T" & N & "<>"""",""_""&T" & N & ","""")" & "&IF(U" & N & "<>"""",""_""&U" & N & ","""")" ''SAP描述

lineSAP描述:

            g_Temptable.Cells(N, 22) = g_wcs当前父物料(0)
            g_Temptable.Cells(N, 23) = "A" & g_wcs当前父物料(3) & "B" & g_wcs当前父物料(1)

        End Sub


        '判断当前父物料层级
        Private Sub Wcs当前父物料_Sub(ByVal nP As Integer)
            Dim tempStr As String
            Dim temph() As String
            Dim nI As Integer
            tempStr = "//" & g_Temptable.Cells(nP, 2).value & "//"
            temph = tempStr.Split("-")
            nI = temph.Length
            If nI = 1 Then
                g_wcs当前父物料(0) = 1
                g_wcs当前父物料(1) = 0
                g_wcs当前父物料(2) = 0
                tempStr = Strings.Right(tempStr, Len(tempStr) - 2)
                g_wcs当前父物料(3) = CInt(Val(tempStr))
                g_Temptable.Cells(nP, 24) = g_wcs当前父物料(3)

            ElseIf nI > g_wcs当前父物料(0) Then
                g_wcs当前父物料(0) = nI
                g_wcs当前父物料(1) = nP - 1
                g_wcs当前父物料(2) = CInt(Val(g_Temptable.Cells(nP - 1, 5).value))
                g_wcs当前父物料(3) = 1
                g_Temptable.Cells(nP, 24) = g_Temptable.Cells(g_wcs当前父物料(1), 24).value & "-" & g_wcs当前父物料(3)
                If nI > g_Max层级 Then
                    g_Max层级 = nI
                End If
            ElseIf nI = g_wcs当前父物料(0) Then
                g_wcs当前父物料(3) = CInt(Val(temph(temph.Length - 1)))
                g_Temptable.Cells(nP, 24) = g_Temptable.Cells(g_wcs当前父物料(1), 24).value & "-" & g_wcs当前父物料(3)
            Else
                Dim tempStr2 As String
                Dim temph2() As String
                Dim i, nJ As Integer
                g_wcs当前父物料(3) = CInt(Val(temph(temph.Length - 1)))
                For i = nP - 2 To 3 Step -1
                    tempStr2 = "//" & g_Temptable.Cells(i, 2).value & "//"
                    temph2 = tempStr2.Split("-")
                    nJ = temph2.Length
                    If nJ < nI Then
                        g_wcs当前父物料(0) = nI
                        g_wcs当前父物料(1) = i
                        g_wcs当前父物料(2) = CInt(Val(g_Temptable.Cells(i, 5).value))
                        Exit For
                    End If


                Next i
                g_Temptable.Cells(nP, 24) = g_Temptable.Cells(g_wcs当前父物料(1), 24).value & "-" & g_wcs当前父物料(3)

            End If



        End Sub

        '判断是否字符串中包含汉字、字母、数字
        Private Function IncludeChinese(ByVal schar As Char) As Byte
            ''1-汉字，2-数字，3-字母，4-字符

            If (AscW(schar) > -40870 And AscW(schar) < -19967) Or (AscW(schar) < 40870 And AscW(schar) > 19967) Then
                IncludeChinese = 1
            ElseIf AscW(schar) >= 48 And AscW(schar) <= 57 Then
                IncludeChinese = 2
            ElseIf (AscW(schar) >= 65 And AscW(schar) <= 90) Or (AscW(schar) >= 97 And AscW(schar) <= 122) Then
                IncludeChinese = 3
            Else
                IncludeChinese = 4
            End If

        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' 检测冗余的调用

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: 释放托管状态(托管对象)。
                End If

                ' TODO: 释放非托管资源(非托管对象)并重写下面的 Finalize()。
                ' TODO: 将大型字段设置为 null。
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: 仅当上面的 Dispose(ByVal disposing As Boolean)具有释放非托管资源的代码时重写 Finalize()。
        'Protected Overrides Sub Finalize()
        '    ' 不要更改此代码。请将清理代码放入上面的 Dispose(ByVal disposing As Boolean)中。
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Visual Basic 添加此代码是为了正确实现可处置模式。
        Public Sub Dispose() Implements IDisposable.Dispose
            ' 不要更改此代码。请将清理代码放入上面的 Dispose (disposing As Boolean)中。
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace