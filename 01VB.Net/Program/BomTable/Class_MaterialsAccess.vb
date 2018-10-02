Namespace BomTable
    Friend Class Class_MaterialsAccess

        Implements IDisposable

#Region "自定义结构"
        Public Structure PropertyMaterSAP
            Public Name As String
            Public Materials As String
            Public ArcSpecification As String
            Public FigureNum As String
            Public QualityAssuranceClass As String
            Public NuvlearSafetyClass As String
            Public Remarks As String


            Public FullDescribe As String
        End Structure

#End Region

        Private intClass As Integer ''0=无图号，15=有图号（包括D等通用件） 240=有图号其它（Ｋ通用件、ＳＰＥＣ通用件）

        Private WaitDescribe As String

        Private objMyArrlistSap As System.Collections.ArrayList

#Region "属性"
        '''ReadOnly属性
        Private mIsConn As Boolean  ''是否连接
        Public ReadOnly Property IsAdoConn As Boolean
            Get
                Return mIsConn
            End Get
        End Property

        Private mIsSap As Boolean  ''需要查询物料是否查到SAP号
        Public ReadOnly Property IsSAP As Boolean
            Get
                Return mIsSap
            End Get
        End Property

        Private mGetMaterSap As String    ''查到的SAP号
        Public ReadOnly Property GetMaterSAP As String
            Get
                With g_zzb正则表达式
                    .Pattern = "\已\生\成\_"
                    If .Test(mGetMaterSap) = True Then
                        Return (.Replace(mGetMaterSap, ""))
                    Else
                        Return mGetMaterSap
                    End If
                End With
            End Get
        End Property

        Private mIntSapSearch As Integer ''1=已有物料号，16=已有申请生成，32=本申请,64=本生成
        Public ReadOnly Property intSapSearch As Integer
            Get
                Return mIntSapSearch
            End Get
        End Property

        ''WriteOnly属性
        Private wProNo As String
        Public WriteOnly Property ProductNo As String
            Set(value As String)
                wProNo = value
            End Set
        End Property

        Private wMaterSap As String  ''提供的SAP号
        Public WriteOnly Property MaterSAP As String
            Set(value As String)
                wMaterSap = value
            End Set
        End Property

        Private wMaterSapDes As String  ''需要查询SAP号的描述
        Public WriteOnly Property MaterSAP描述 As String
            Set(value As String)
                wMaterSapDes = value
            End Set
        End Property

        Private wMaterialsStru As PropertyMaterSAP
        Public WriteOnly Property materialsStru() As PropertyMaterSAP
            Set(value As PropertyMaterSAP)
                wMaterialsStru = value
            End Set
        End Property

#End Region

        Public Sub New()
            sConnectString = "Provider=Microsoft.ace.OLEDB.12.0;Data Source=" & wTest & ";Persist Security Info=False;Jet OLEDB:Database Password=X753951"   ''*.accdb格式数据库（2007年以后）Jet OLEDB:Database 
            mIsConn = True
            objMyArrlistSap = New System.Collections.ArrayList
            Try
                adoConn = New OleDb.OleDbConnection(sConnectString)
                adoConn.Open()
            Catch ex As Exception
                mIsConn = False
                MessageBox.Show("不能连接数据库", "ErrorAccess")
            End Try
            adoConn.Close()
        End Sub


        Public Sub Matching_Sap()

            WaitDes()   ''待查询描述
            If WaitDescribe = "" Then
                mIsSap = False
                Exit Sub
            End If
            Dim coMstr As String
            If wMaterSap <> "" Then     ''有图号（含通用件及K通用件SPEC通用件）
                intClass = 15
                With g_zzb正则表达式
                    .Pattern = "(\bK[0-9][0-9].[0-9][0-9]\b)|(\bSPEC[0-9]{4})"
                    .IgnoreCase = True
                    .Global = False
                    If .Test(wMaterSap) = True Then
                        intClass = 240
                    Else
                        .Pattern = "已申请"
                        .IgnoreCase = True
                        .Global = False
                        If .Test(wMaterSap) = True Then
                            intClass = 0
                        End If
                    End If
                End With
            Else
                intClass = 0
            End If
            If intClass <> 15 Then

                coMstr = "select SAP物料号码,产品图号1 From 物料代码 where 备份物料描述 = '" & WaitDescribe & "'"

            Else
                coMstr = "select SAP物料号码,产品图号1 From 物料代码 where SAP物料号码 = '" & wMaterSap & "' or SAP物料号码 = '已生成_" & wMaterSap & "'"
            End If

            Dim adoComm As New System.Data.OleDb.OleDbCommand(coMstr, adoConn)
            Dim dr As System.Data.OleDb.OleDbDataReader

            adoConn.Open()
            dr = adoComm.ExecuteReader

            If dr.Read Then    ''是否存在物料号，存在的物料属于已有申请和已有生成
                mIntSapSearch = 1
                mIsSap = True
                mGetMaterSap = dr("SAP物料号码").ToString

                With g_zzb正则表达式
                    .Pattern = "(\已\生\成\_)|(\已\申\请)"
                    If .Test(mGetMaterSap) = True Then
                        mGetMaterSap = mGetMaterSap.Replace("已生成_", "")
                        If dr("产品图号1").ToString = wProNo Then
                            If intClass = 0 Then
                                mIntSapSearch = 32
                            Else
                                mIntSapSearch = 64
                            End If
                            AddMyArrList()
                        Else   ''已有申请生成
                            mIntSapSearch = 16
                        End If
                    End If
                End With
            Else
                If intClass = 0 Then
                    mIntSapSearch = 32
                Else
                    mIntSapSearch = 64
                End If
                mIsSap = False
                mGetMaterSap = ""
            End If
            adoConn.Close()

        End Sub

        Private Function iGet_申请号() As String

            Dim YiSap物料 As String
            Dim comstr As String
            Dim adoComm As System.Data.OleDb.OleDbCommand
            Dim dr As System.Data.OleDb.OleDbDataReader
            If intClass = 15 Then
                YiSap物料 = "已生成_" & wMaterSap
                Return YiSap物料
            ElseIf intClass = 240 Then
                comstr = "select SAP物料号码 From 物料代码 where SAP物料号码 like '" & wMaterSap & "%' Order By SAP物料号码 DESC"  ''ASC=升序；DESC=降序
                adoComm = New System.Data.OleDb.OleDbCommand(comstr, adoConn)
                Dim jInt, kInt As Integer
                adoConn.Open()
                dr = adoComm.ExecuteReader
                If dr.Read Then
                    jInt = CInt(Right(dr("SAP物料号码").ToString, 5)) + 1
                Else
                    jInt = 1
                End If
                comstr = "select SAP物料号码 From 物料代码 where SAP物料号码 like '已生成_" & wMaterSap & "%' Order By SAP物料号码 DESC"  ''ASC=升序；DESC=降序
                adoComm = New System.Data.OleDb.OleDbCommand(comstr, adoConn)
                dr = adoComm.ExecuteReader
                If dr.Read Then
                    kInt = CInt(Right(dr("SAP物料号码").ToString, 5)) + 1
                Else
                    kInt = 1
                End If
                adoConn.Close()
                If kInt > jInt Then
                    jInt = kInt
                End If
                YiSap物料 = "已生成_" & wMaterSap & "_" & Format(jInt, "00000")

            Else
                comstr = "select SAP物料号码 From 物料代码 where SAP物料号码 like '已申请%' Order By SAP物料号码 DESC"  ''ASC=升序；DESC=降序
                adoComm = New System.Data.OleDb.OleDbCommand(comstr, adoConn)
                adoConn.Open()
                dr = adoComm.ExecuteReader
                If dr.Read Then
                    YiSap物料 = "已申请_" & Format(Val(Right(dr("SAP物料号码").ToString, 5)) + 1, "00000")
                Else
                    YiSap物料 = "已申请_00001"
                End If
                adoConn.Close()

            End If

            Return YiSap物料

        End Function

        Public Sub AddSAP()

            Dim comstr As String
            mGetMaterSap = iGet_申请号()

            comstr = "INSERT INTO 物料代码(SAP物料号码,物料描述,备份物料描述,名称,材料级别,规格,代号,质保等级,核安全级别,备注,完整描述,产品图号1) VALUES('" _
                              & mGetMaterSap & "','" & wMaterSapDes & "','" & WaitDescribe & "','" & wMaterialsStru.Name & "','" & wMaterialsStru.Materials & "','" & wMaterialsStru.ArcSpecification & "','" & wMaterialsStru.FigureNum & "','" _
                              & wMaterialsStru.QualityAssuranceClass & "','" & wMaterialsStru.NuvlearSafetyClass & "','" & wMaterialsStru.Remarks & "','" & wMaterialsStru.FullDescribe & _
                               "','" & wProNo & "')"

            adoConn.Open()
            adoComm = New System.Data.OleDb.OleDbCommand(comstr, adoConn)
            adoRst = New System.Data.OleDb.OleDbDataAdapter(comstr, adoConn)
            adoRst.InsertCommand = adoComm
            adoRst.InsertCommand.ExecuteNonQuery()
            adoConn.Close()

            AddMyArrList()

        End Sub

        Public Function IsWriteSAP() As Integer
            ''是否有物料需要申请
            If objMyArrlistSap.Count <= 0 Then
                Return 0
            End If
            If MessageBox.Show("是否需要申请物料？？", "物料申请", MessageBoxButtons.YesNo) = 7 Then
                ''6=Yes;7=No
                DeleteSAP()
            Else
                OutputFile()
            End If

            Return 103
        End Function

#Region "内部子程序"

        Private Sub WaitDes()
            ''待查询描述
            WaitDescribe = wMaterSapDes

            WaitDescribe = WaitDescribe.ToUpper
            With g_zzb正则表达式
                .Pattern = "[\s\－\-\\\/\／\；\,\，\=\＝\（\）\(\)]"
                .IgnoreCase = True
                .Global = True
                If .Test(WaitDescribe) = True Then
                    WaitDescribe = .Replace(WaitDescribe, "")
                End If
            End With
            With g_zzb正则表达式
                .Pattern = "\_\_"
                .IgnoreCase = True
                .Global = True
                If .Test(WaitDescribe) = True Then
                    WaitDescribe = .Replace(WaitDescribe, "_")
                End If
            End With
            'With g_zzb正则表达式
            '    .Pattern = "(0-9)?X(1-9)?"
            '    .IgnoreCase = True
            '    .Global = True
            '    If .Test(WaitDescribe) = True Then
            '        WaitDescribe = WaitDescribe.Replace("X", "×")
            '    End If
            'End With
            With g_zzb正则表达式
                .Pattern = "[X\*\＊]"
                .IgnoreCase = True
                .Global = True
                If .Test(WaitDescribe) = True Then
                    WaitDescribe = .Replace(WaitDescribe, "×")
                End If
            End With

            With g_zzb正则表达式
                .Pattern = "\＋"
                .IgnoreCase = True
                .Global = True
                If .Test(WaitDescribe) = True Then
                    WaitDescribe = .Replace(WaitDescribe, "+")
                End If
            End With

            With g_zzb正则表达式
                .Pattern = "\•"
                .IgnoreCase = True
                .Global = True
                If .Test(WaitDescribe) = True Then
                    WaitDescribe = .Replace(WaitDescribe, ".")
                End If
            End With

            With g_zzb正则表达式
                .Pattern = "\" & ChrW(8220)
                .IgnoreCase = True
                .Global = True
                If .Test(WaitDescribe) = True Then
                    WaitDescribe = .Replace(WaitDescribe, Chr(34))
                End If
            End With

            With g_zzb正则表达式
                .Pattern = "\" & ChrW(8221)
                .IgnoreCase = True
                .Global = True
                If .Test(WaitDescribe) = True Then
                    WaitDescribe = .Replace(WaitDescribe, Chr(34))
                End If
            End With

            With g_zzb正则表达式
                .Pattern = "[\φ\Ф\￠]"
                .IgnoreCase = True
                .Global = True
                If .Test(WaitDescribe) = True Then
                    WaitDescribe = .Replace(WaitDescribe, "Φ")
                End If
            End With



        End Sub

        Private Sub AddMyArrList()
            ''增加添加物料的集合
            Dim MyArrList(0 To 3) As String
            MyArrList(0) = mGetMaterSap
            MyArrList(1) = wMaterSapDes
            MyArrList(2) = 456       '' 重量
            MyArrList(3) = 123   ''单位
            objMyArrlistSap.Add(MyArrList)
        End Sub

        Private Sub DeleteSAP()
            Dim coMstr As String
            For Each item In objMyArrlistSap
                Debug.Print(item(0).ToString & "//" & item(1).ToString & "//" & item(2).ToString)
                coMstr = "delete from 物料代码 where SAP物料号码='" & item(0).ToString & "'"
                adoConn.Open()
                adoComm = New System.Data.OleDb.OleDbCommand(coMstr, adoConn)
                adoRst.DeleteCommand = adoComm
                adoRst.DeleteCommand.ExecuteNonQuery()
                adoConn.Close()
            Next

        End Sub

        Private Sub OutputFile()

        End Sub

#End Region





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


        Protected Overrides Sub Finalize()
            MyBase.Finalize()

            adoConn.Close()
            adoComm = Nothing
            adoConn = Nothing
        End Sub

    End Class
End Namespace