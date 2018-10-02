Namespace BomTable
    Friend Module ModCommon

        Public Const cVer As Single = 1.4 ''''版本号
        ''1.09增加对D55.19-0组件的编码
        ''1.10增加对物料号的查询,调整物料规范程序结构（使用类）
        ''增加产品清单的生成
        ''1.22--k33.01一个物料对应一个编码
        ''1.23 ND100.00Bug修复，MySettings的描述修改
        ''1.25 "Class_MaterialsStandard"类结构调整，"Description_物料描述"的判断修正
        ''1.26 U形管。K33.01/K33.02H单位Kg代码结构调整
        ''1.27''“第十一页”bug//K18。**不需要重量
        ''1.28装箱备注字段(产品清单B中)
        ''1.29配套件备注规范；生成物料零件清单结构优化
        ''1.31按本图弯头是无图号
        ''1.32待定物料
        ''1.35按本图物料 
        ''1.36锁扣
        ''1.37 有图号质保等级
        ''1.38 海淡DFP、DV、DC图号
        ''1.39 返回编码单元格格式设置
        ''1.40 SAP号18个字符限制


        Public g_w文件Count As Integer      ''''文件数量
        Public const_DeskTop As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)  ''''桌面路径

        Public g_zzb正则表达式 As Object 'New VBScript_RegExp_55.RegExp

        Public g_csL类型 As Byte  ''0--常规图号HPLP等，1--MSR，100--MSR项目编码不能保存
        Public g_cs总图号 As String
        Public g_cs名称 As String
        Public g_wcs当前父物料(0 To 3) As Integer ''0……父物料层级；1……父物料序号；2……父物料数量；3……当前物料序号
        Public g_Max层级 As Integer = 1 ''最大层级
        Public g_tf层级物料序号 As Integer ''TableForERP表序号
        Public g_jy层级物料序号 As Integer ''借用表序号

        Public g_MSRrep替换部分 As String
        Public g_rep替换成MSR As String
        Public shA(40) As String    ''MSR编码替换
        'Public Const g_MSR编码替换Path As String = "\\10.32.1.20\01_部门共享\02_技术部\04_技术部共享\01_ERP数据\工具\MSR编码替换.xlsx"
        Public Const g_MSR编码替换Path As String = "D:\MSR编码替换.xlsx"
        Public Const g_winApp物料代码 As String = "\\10.32.1.20\01_部门共享\02_技术部\01_设计研究所\08_共享\软件\工作工具集\05清单生成\WinApp物料代码.exe"
        Public Const g_DwinApp As String = "D:\面板工具\WinApp物料代码.exe"
        Public g_cs输入文件路径名称Array() As String
        Public g_cs输入文件名称List() As String

        Public Const c_Num清单Max As Byte = 15    ''''清单数量
        Public g_hz(0 To c_Num清单Max) As String  ''''“一、二、三……”


        Public g_ExcelAppObj As Microsoft.Office.Interop.Excel.Application
        ''Public g_ActiveWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Public g_zWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Public g_Temptable As Microsoft.Office.Interop.Excel.Worksheet
        Public g_TableForERP As Microsoft.Office.Interop.Excel.Worksheet
        Public g_Table借用 As Microsoft.Office.Interop.Excel.Worksheet

        Public Const strsheetName As String = "TempTable"
        Public Const strSheetName1 As String = "TableForERP"
        Public Const strSheetName2 As String = "借用"

        Public conVersion(,) As String

        ''数据库参数
        Public adoConn As System.Data.OleDb.OleDbConnection
        Public adoComm As System.Data.OleDb.OleDbCommand
        Public adoRst As System.Data.OleDb.OleDbDataAdapter
        Public adoset As System.Data.DataSet
        Public sConnectString As String
        Public Const wTest As String = "E:\物料数据库\物料代码.accdb"



        'Public Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer



    End Module
End Namespace