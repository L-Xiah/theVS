Module ModuleMain

    Const Cver As Double = 1.1
    Const cpStrVer As String = "Const_csMyVersion=1.10$"

    Const cNetDirectory As String = "\\10.32.1.20\01_部门共享\02_技术部\01_设计研究所\08_共享\软件\工作工具集\WinApp\AutoCAD"
    Const cLocalDebugDirectory As String = "E:\TEMP\sign"
    Public constDirectory As String
    Public IsDebug As Boolean



    Sub main(Args() As String)



        Application.EnableVisualStyles()  '’视觉效果
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then Return ''单个程序运行
        'Application.SaveMySettingsOnExit = True  ''退出时保存设置
        
        IsDebug = True
        constDirectory = cNetDirectory
        'MessageBox.Show(My.Application.Info.DirectoryPath & "\" & Process.GetCurrentProcess.ProcessName & ".exe")
        Dim ss As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(My.Application.Info.DirectoryPath & "\" & Process.GetCurrentProcess.ProcessName & ".exe")
        Dim temp() As DebuggableAttribute = ss.GetCustomAttributes(GetType(DebuggableAttribute), True)
        If temp(0).IsJITOptimizerDisabled = True AndAlso temp(0).IsJITTrackingEnabled = True Then
            If MessageBox.Show("需要测试吗？", "测试", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                IsDebug = True
                constDirectory = cLocalDebugDirectory
            End If
        ElseIf temp(0).IsJITOptimizerDisabled = False AndAlso temp(0).IsJITTrackingEnabled = False Then
            If MessageBox.Show("需要测试吗？", "测试", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                IsDebug = True
                constDirectory = cLocalDebugDirectory
            End If
        End If
        Dim cNetPath As String = constDirectory & "\WinAppCAD.exe"
        Dim cThePath As String = "D:\面板工具\WinAppCAD.exe"

        If IsDebug = False Then
            If System.IO.File.Exists(cNetPath) = False OrElse CommonFunctionSub.moduleCommonFunctionSub.VerTestCopy(cThePath, cNetPath, Cver, , , "法兰程序") = False Then
                MessageBox.Show("未授权，请联系管理员！","Error",MessageBoxButtons.OK,MessageBoxIcon.Error)
                Exit Sub
            End If
        End If


        Dim tempForm1 As New Form1
        If IsDebug = True Then
            tempForm1.Text = "AutoCAD程序……Local版V" & Format(Cver, ".00")
        Else
            tempForm1.Text = "AutoCAD程序……网络版V" & Format(Cver, ".00")
        End If

        Application.Run(tempForm1) ''直到窗体卸载了



    End Sub



End Module


Module ModuleABC

    Public g_cs输入文件类型 As String
    Public Const Const_csDwg文件类型 As String = "Dwg"
    Public Const Const_csXls文件类型 As String = "Xls"
    Public Const Const_csDoc文件类型 As String = "Doc"

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


    Public g_cs输入文件路径名称Array() As String
    Public g_i输入文件路径名称Count As Integer
    Public g_cs输入文件全路径名称 As String

End Module







Namespace CommonFunctionSub

    Module moduleCommonFunctionSub

#Region "版本检测//桌面快捷方式"

        ''检测版本号是否是最新的，自动复制最新的程序到本地目录
        Public Function VerTestCopy(ByVal temp_localAppPath As String, ByVal temp_NetAppPath As String, ByVal temp_myVerDouble As Double, Optional ByVal temp_Patten As String = "Const_csMyVersion\=[1-9]([0-9]+)?(\.[0-9]+)?\$",
                                Optional ByVal temp_cVerdllPath As String = "\\10.32.1.20\01_部门共享\02_技术部\01_设计研究所\08_共享\软件\工作工具集\01Other\Verdll.dll", Optional ByVal temp_ink As String = "") As Boolean
            ''temp_localAppPath--本地程序路径，temp_NetAppPath--网络路径,temp_myVerDouble--本文件版本号
            ''temp_Patten--版本号格式，temp_cVerdllPath--Dll路径
            Const CopyStr As String = "\\10.32.1.20\01_部门共享\02_技术部\01_设计研究所\08_共享\软件\工作工具集\01Other\WinAppCopyDesktop.exe"
            Dim tempDriveInfo As System.IO.DriveInfo = Nothing
            Try
                tempDriveInfo = New System.IO.DriveInfo(My.Application.Info.DirectoryPath.ToString.Substring(0, 1))
            Catch ex As Exception
            End Try
            If tempDriveInfo Is Nothing OrElse tempDriveInfo.DriveType <> IO.DriveType.Fixed Then
                Application.Exit()
                Shell(CopyStr & " " & temp_NetAppPath & " " & temp_localAppPath & " " & temp_ink)
                Return False
            End If


            Dim theVer As Double
            Dim dAssembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(temp_cVerdllPath)
            Using objItem As Object = dAssembly.CreateInstance("VerDll.ClassVer")
                objItem.PathVer = temp_NetAppPath
                objItem.PatternReg = temp_Patten
                theVer = objItem.Ver_Get()
            End Using

            If theVer <> temp_myVerDouble Then
                MessageBox.Show("版本号错误！" & vbCrLf & "最新版：V" & Format(theVer, ".00"), "Ver" & temp_myVerDouble, MessageBoxButtons.OK)
                Application.Exit()
                Shell(CopyStr & " " & temp_NetAppPath & " " & temp_localAppPath & " " & temp_ink)
                Return False
            End If

            Return True
        End Function


#End Region



    End Module


End Namespace