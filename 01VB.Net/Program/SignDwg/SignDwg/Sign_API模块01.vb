Module Sign_API模块01


    Public Const HWND_TOPMOST As Integer = -1   ''窗体置前。
    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hWnd As IntPtr, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFLAGS As Integer) As Integer
    Public g_csUserName As String ' 用户名
    Public Declare Function GetUserName Lib "advapi32.dll" Alias "GetUserNameA" (ByVal lpBuffer As String, ByRef nSize As Long) As Long
    Public g_csComputerName As String ' 机器名
    Public Declare Function GetComputerName Lib "kernel32" Alias "GetComputerNameA" (ByVal lpBuffer As String, ByRef nSize As Long) As Long



End Module
