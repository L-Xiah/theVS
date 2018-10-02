<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignExcelDwg
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cbo_全路径名 = New System.Windows.Forms.ComboBox()
        Me.GroupB文件类型 = New System.Windows.Forms.GroupBox()
        Me.Rdb_Word = New System.Windows.Forms.RadioButton()
        Me.Rdb_Dwg = New System.Windows.Forms.RadioButton()
        Me.Rdb_Excel = New System.Windows.Forms.RadioButton()
        Me.GroupB签名者身份 = New System.Windows.Forms.GroupBox()
        Me.Rdb_标检 = New System.Windows.Forms.RadioButton()
        Me.Rdb_审核 = New System.Windows.Forms.RadioButton()
        Me.Rdb_批准 = New System.Windows.Forms.RadioButton()
        Me.Rdb_工艺 = New System.Windows.Forms.RadioButton()
        Me.Rdb_竣工图 = New System.Windows.Forms.RadioButton()
        Me.Rdb_校对 = New System.Windows.Forms.RadioButton()
        Me.Rdb_设计 = New System.Windows.Forms.RadioButton()
        Me.Lbl_签名者姓名 = New System.Windows.Forms.Label()
        Me.Cbo_签名者姓名 = New System.Windows.Forms.ComboBox()
        Me.Cbo_第二签名者姓名 = New System.Windows.Forms.ComboBox()
        Me.Lbl_第二签名者姓名 = New System.Windows.Forms.Label()
        Me.Lbl_签名日期 = New System.Windows.Forms.Label()
        Me.Txt_年 = New System.Windows.Forms.TextBox()
        Me.Txt_月 = New System.Windows.Forms.TextBox()
        Me.Txt_日 = New System.Windows.Forms.TextBox()
        Me.Lbl_年 = New System.Windows.Forms.Label()
        Me.Lbl_月 = New System.Windows.Forms.Label()
        Me.Lbl_日 = New System.Windows.Forms.Label()
        Me.Chk_竣工章许可编号 = New System.Windows.Forms.CheckBox()
        Me.Btn_浏览 = New System.Windows.Forms.Button()
        Me.Btn_删除 = New System.Windows.Forms.Button()
        Me.Btn_测试 = New System.Windows.Forms.Button()
        Me.Btn_清空 = New System.Windows.Forms.Button()
        Me.Btn_图层线宽 = New System.Windows.Forms.Button()
        Me.Btn_签名 = New System.Windows.Forms.Button()
        Me.Btn_打印 = New System.Windows.Forms.Button()
        Me.Btn_退出 = New System.Windows.Forms.Button()
        Me.OpenFileDialog浏览 = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupB文件类型.SuspendLayout()
        Me.GroupB签名者身份.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请输入文件的全路径名（允许多个文件）" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Cbo_全路径名
        '
        Me.Cbo_全路径名.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cbo_全路径名.FormattingEnabled = True
        Me.Cbo_全路径名.Location = New System.Drawing.Point(31, 37)
        Me.Cbo_全路径名.Name = "Cbo_全路径名"
        Me.Cbo_全路径名.Size = New System.Drawing.Size(466, 24)
        Me.Cbo_全路径名.TabIndex = 1
        '
        'GroupB文件类型
        '
        Me.GroupB文件类型.Controls.Add(Me.Rdb_Word)
        Me.GroupB文件类型.Controls.Add(Me.Rdb_Dwg)
        Me.GroupB文件类型.Controls.Add(Me.Rdb_Excel)
        Me.GroupB文件类型.Location = New System.Drawing.Point(31, 67)
        Me.GroupB文件类型.Name = "GroupB文件类型"
        Me.GroupB文件类型.Size = New System.Drawing.Size(394, 45)
        Me.GroupB文件类型.TabIndex = 2
        Me.GroupB文件类型.TabStop = False
        Me.GroupB文件类型.Text = "文件类型"
        '
        'Rdb_Word
        '
        Me.Rdb_Word.AutoSize = True
        Me.Rdb_Word.Location = New System.Drawing.Point(275, 18)
        Me.Rdb_Word.Name = "Rdb_Word"
        Me.Rdb_Word.Size = New System.Drawing.Size(47, 16)
        Me.Rdb_Word.TabIndex = 2
        Me.Rdb_Word.TabStop = True
        Me.Rdb_Word.Text = "Word"
        Me.Rdb_Word.UseVisualStyleBackColor = True
        Me.Rdb_Word.Visible = False
        '
        'Rdb_Dwg
        '
        Me.Rdb_Dwg.AutoSize = True
        Me.Rdb_Dwg.Location = New System.Drawing.Point(164, 18)
        Me.Rdb_Dwg.Name = "Rdb_Dwg"
        Me.Rdb_Dwg.Size = New System.Drawing.Size(65, 16)
        Me.Rdb_Dwg.TabIndex = 1
        Me.Rdb_Dwg.TabStop = True
        Me.Rdb_Dwg.Text = "图纸Dwg"
        Me.Rdb_Dwg.UseVisualStyleBackColor = True
        '
        'Rdb_Excel
        '
        Me.Rdb_Excel.AutoSize = True
        Me.Rdb_Excel.Location = New System.Drawing.Point(26, 18)
        Me.Rdb_Excel.Name = "Rdb_Excel"
        Me.Rdb_Excel.Size = New System.Drawing.Size(71, 16)
        Me.Rdb_Excel.TabIndex = 0
        Me.Rdb_Excel.TabStop = True
        Me.Rdb_Excel.Text = "零件清单"
        Me.Rdb_Excel.UseVisualStyleBackColor = True
        '
        'GroupB签名者身份
        '
        Me.GroupB签名者身份.Controls.Add(Me.Rdb_标检)
        Me.GroupB签名者身份.Controls.Add(Me.Rdb_审核)
        Me.GroupB签名者身份.Controls.Add(Me.Rdb_批准)
        Me.GroupB签名者身份.Controls.Add(Me.Rdb_工艺)
        Me.GroupB签名者身份.Controls.Add(Me.Rdb_竣工图)
        Me.GroupB签名者身份.Controls.Add(Me.Rdb_校对)
        Me.GroupB签名者身份.Controls.Add(Me.Rdb_设计)
        Me.GroupB签名者身份.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupB签名者身份.Location = New System.Drawing.Point(31, 140)
        Me.GroupB签名者身份.Name = "GroupB签名者身份"
        Me.GroupB签名者身份.Size = New System.Drawing.Size(143, 271)
        Me.GroupB签名者身份.TabIndex = 3
        Me.GroupB签名者身份.TabStop = False
        Me.GroupB签名者身份.Text = "签名者身份"
        '
        'Rdb_标检
        '
        Me.Rdb_标检.AutoSize = True
        Me.Rdb_标检.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rdb_标检.Location = New System.Drawing.Point(36, 130)
        Me.Rdb_标检.Name = "Rdb_标检"
        Me.Rdb_标检.Size = New System.Drawing.Size(77, 24)
        Me.Rdb_标检.TabIndex = 7
        Me.Rdb_标检.TabStop = True
        Me.Rdb_标检.Text = "标 检"
        Me.Rdb_标检.UseVisualStyleBackColor = True
        '
        'Rdb_审核
        '
        Me.Rdb_审核.AutoSize = True
        Me.Rdb_审核.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rdb_审核.Location = New System.Drawing.Point(36, 95)
        Me.Rdb_审核.Name = "Rdb_审核"
        Me.Rdb_审核.Size = New System.Drawing.Size(77, 24)
        Me.Rdb_审核.TabIndex = 6
        Me.Rdb_审核.TabStop = True
        Me.Rdb_审核.Text = "审 核"
        Me.Rdb_审核.UseVisualStyleBackColor = True
        '
        'Rdb_批准
        '
        Me.Rdb_批准.AutoSize = True
        Me.Rdb_批准.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rdb_批准.Location = New System.Drawing.Point(36, 200)
        Me.Rdb_批准.Name = "Rdb_批准"
        Me.Rdb_批准.Size = New System.Drawing.Size(77, 24)
        Me.Rdb_批准.TabIndex = 5
        Me.Rdb_批准.TabStop = True
        Me.Rdb_批准.Text = "批 准"
        Me.Rdb_批准.UseVisualStyleBackColor = True
        '
        'Rdb_工艺
        '
        Me.Rdb_工艺.AutoSize = True
        Me.Rdb_工艺.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rdb_工艺.Location = New System.Drawing.Point(36, 165)
        Me.Rdb_工艺.Name = "Rdb_工艺"
        Me.Rdb_工艺.Size = New System.Drawing.Size(77, 24)
        Me.Rdb_工艺.TabIndex = 4
        Me.Rdb_工艺.TabStop = True
        Me.Rdb_工艺.Text = "工 艺"
        Me.Rdb_工艺.UseVisualStyleBackColor = True
        '
        'Rdb_竣工图
        '
        Me.Rdb_竣工图.AutoSize = True
        Me.Rdb_竣工图.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rdb_竣工图.Location = New System.Drawing.Point(36, 235)
        Me.Rdb_竣工图.Name = "Rdb_竣工图"
        Me.Rdb_竣工图.Size = New System.Drawing.Size(107, 24)
        Me.Rdb_竣工图.TabIndex = 3
        Me.Rdb_竣工图.TabStop = True
        Me.Rdb_竣工图.Text = "竣 工 图"
        Me.Rdb_竣工图.UseVisualStyleBackColor = True
        '
        'Rdb_校对
        '
        Me.Rdb_校对.AutoSize = True
        Me.Rdb_校对.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rdb_校对.Location = New System.Drawing.Point(36, 60)
        Me.Rdb_校对.Name = "Rdb_校对"
        Me.Rdb_校对.Size = New System.Drawing.Size(77, 24)
        Me.Rdb_校对.TabIndex = 1
        Me.Rdb_校对.TabStop = True
        Me.Rdb_校对.Text = "校 对"
        Me.Rdb_校对.UseVisualStyleBackColor = True
        '
        'Rdb_设计
        '
        Me.Rdb_设计.AutoSize = True
        Me.Rdb_设计.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rdb_设计.Location = New System.Drawing.Point(36, 25)
        Me.Rdb_设计.Name = "Rdb_设计"
        Me.Rdb_设计.Size = New System.Drawing.Size(77, 24)
        Me.Rdb_设计.TabIndex = 0
        Me.Rdb_设计.TabStop = True
        Me.Rdb_设计.Text = "设 计"
        Me.Rdb_设计.UseVisualStyleBackColor = True
        '
        'Lbl_签名者姓名
        '
        Me.Lbl_签名者姓名.AutoSize = True
        Me.Lbl_签名者姓名.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_签名者姓名.Location = New System.Drawing.Point(248, 140)
        Me.Lbl_签名者姓名.Name = "Lbl_签名者姓名"
        Me.Lbl_签名者姓名.Size = New System.Drawing.Size(123, 19)
        Me.Lbl_签名者姓名.TabIndex = 4
        Me.Lbl_签名者姓名.Text = "签名者姓名："
        '
        'Cbo_签名者姓名
        '
        Me.Cbo_签名者姓名.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cbo_签名者姓名.FormattingEnabled = True
        Me.Cbo_签名者姓名.Location = New System.Drawing.Point(251, 162)
        Me.Cbo_签名者姓名.Name = "Cbo_签名者姓名"
        Me.Cbo_签名者姓名.Size = New System.Drawing.Size(218, 27)
        Me.Cbo_签名者姓名.TabIndex = 5
        Me.Cbo_签名者姓名.Text = "Cbo_签名者姓名"
        '
        'Cbo_第二签名者姓名
        '
        Me.Cbo_第二签名者姓名.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cbo_第二签名者姓名.FormattingEnabled = True
        Me.Cbo_第二签名者姓名.Location = New System.Drawing.Point(253, 236)
        Me.Cbo_第二签名者姓名.Name = "Cbo_第二签名者姓名"
        Me.Cbo_第二签名者姓名.Size = New System.Drawing.Size(216, 27)
        Me.Cbo_第二签名者姓名.TabIndex = 7
        Me.Cbo_第二签名者姓名.Text = "Cbo_第二签名者姓名"
        '
        'Lbl_第二签名者姓名
        '
        Me.Lbl_第二签名者姓名.AutoSize = True
        Me.Lbl_第二签名者姓名.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_第二签名者姓名.Location = New System.Drawing.Point(248, 214)
        Me.Lbl_第二签名者姓名.Name = "Lbl_第二签名者姓名"
        Me.Lbl_第二签名者姓名.Size = New System.Drawing.Size(161, 19)
        Me.Lbl_第二签名者姓名.TabIndex = 6
        Me.Lbl_第二签名者姓名.Text = "第二签名者姓名："
        '
        'Lbl_签名日期
        '
        Me.Lbl_签名日期.AutoSize = True
        Me.Lbl_签名日期.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_签名日期.Location = New System.Drawing.Point(249, 288)
        Me.Lbl_签名日期.Name = "Lbl_签名日期"
        Me.Lbl_签名日期.Size = New System.Drawing.Size(104, 19)
        Me.Lbl_签名日期.TabIndex = 8
        Me.Lbl_签名日期.Text = "签名日期："
        '
        'Txt_年
        '
        Me.Txt_年.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Txt_年.Location = New System.Drawing.Point(251, 310)
        Me.Txt_年.Name = "Txt_年"
        Me.Txt_年.Size = New System.Drawing.Size(54, 26)
        Me.Txt_年.TabIndex = 9
        '
        'Txt_月
        '
        Me.Txt_月.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Txt_月.Location = New System.Drawing.Point(341, 310)
        Me.Txt_月.Name = "Txt_月"
        Me.Txt_月.Size = New System.Drawing.Size(27, 26)
        Me.Txt_月.TabIndex = 10
        '
        'Txt_日
        '
        Me.Txt_日.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Txt_日.Location = New System.Drawing.Point(408, 309)
        Me.Txt_日.Name = "Txt_日"
        Me.Txt_日.Size = New System.Drawing.Size(27, 26)
        Me.Txt_日.TabIndex = 11
        '
        'Lbl_年
        '
        Me.Lbl_年.AutoSize = True
        Me.Lbl_年.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_年.Location = New System.Drawing.Point(307, 310)
        Me.Lbl_年.Name = "Lbl_年"
        Me.Lbl_年.Size = New System.Drawing.Size(28, 19)
        Me.Lbl_年.TabIndex = 12
        Me.Lbl_年.Text = "年"
        '
        'Lbl_月
        '
        Me.Lbl_月.AutoSize = True
        Me.Lbl_月.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_月.Location = New System.Drawing.Point(374, 311)
        Me.Lbl_月.Name = "Lbl_月"
        Me.Lbl_月.Size = New System.Drawing.Size(28, 19)
        Me.Lbl_月.TabIndex = 13
        Me.Lbl_月.Text = "月"
        '
        'Lbl_日
        '
        Me.Lbl_日.AutoSize = True
        Me.Lbl_日.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_日.Location = New System.Drawing.Point(441, 310)
        Me.Lbl_日.Name = "Lbl_日"
        Me.Lbl_日.Size = New System.Drawing.Size(28, 19)
        Me.Lbl_日.TabIndex = 14
        Me.Lbl_日.Text = "日"
        '
        'Chk_竣工章许可编号
        '
        Me.Chk_竣工章许可编号.AutoSize = True
        Me.Chk_竣工章许可编号.Checked = True
        Me.Chk_竣工章许可编号.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_竣工章许可编号.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Chk_竣工章许可编号.Location = New System.Drawing.Point(251, 362)
        Me.Chk_竣工章许可编号.Name = "Chk_竣工章许可编号"
        Me.Chk_竣工章许可编号.Size = New System.Drawing.Size(171, 20)
        Me.Chk_竣工章许可编号.TabIndex = 15
        Me.Chk_竣工章许可编号.Text = "竣工章带许可证编号"
        Me.Chk_竣工章许可编号.UseVisualStyleBackColor = True
        '
        'Btn_浏览
        '
        Me.Btn_浏览.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_浏览.Location = New System.Drawing.Point(542, 30)
        Me.Btn_浏览.Name = "Btn_浏览"
        Me.Btn_浏览.Size = New System.Drawing.Size(80, 30)
        Me.Btn_浏览.TabIndex = 17
        Me.Btn_浏览.Text = "浏 览"
        Me.Btn_浏览.UseVisualStyleBackColor = True
        '
        'Btn_删除
        '
        Me.Btn_删除.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_删除.Location = New System.Drawing.Point(542, 70)
        Me.Btn_删除.Name = "Btn_删除"
        Me.Btn_删除.Size = New System.Drawing.Size(80, 30)
        Me.Btn_删除.TabIndex = 18
        Me.Btn_删除.Text = "删 除"
        Me.Btn_删除.UseVisualStyleBackColor = True
        '
        'Btn_测试
        '
        Me.Btn_测试.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_测试.Location = New System.Drawing.Point(542, 165)
        Me.Btn_测试.Name = "Btn_测试"
        Me.Btn_测试.Size = New System.Drawing.Size(80, 30)
        Me.Btn_测试.TabIndex = 20
        Me.Btn_测试.Text = "测 试"
        Me.Btn_测试.UseVisualStyleBackColor = True
        '
        'Btn_清空
        '
        Me.Btn_清空.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_清空.Location = New System.Drawing.Point(542, 110)
        Me.Btn_清空.Name = "Btn_清空"
        Me.Btn_清空.Size = New System.Drawing.Size(80, 30)
        Me.Btn_清空.TabIndex = 19
        Me.Btn_清空.Text = "清 空"
        Me.Btn_清空.UseVisualStyleBackColor = True
        '
        'Btn_图层线宽
        '
        Me.Btn_图层线宽.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_图层线宽.Location = New System.Drawing.Point(542, 285)
        Me.Btn_图层线宽.Name = "Btn_图层线宽"
        Me.Btn_图层线宽.Size = New System.Drawing.Size(80, 30)
        Me.Btn_图层线宽.TabIndex = 23
        Me.Btn_图层线宽.Text = "图层线宽"
        Me.Btn_图层线宽.UseVisualStyleBackColor = True
        '
        'Btn_签名
        '
        Me.Btn_签名.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_签名.Location = New System.Drawing.Point(542, 245)
        Me.Btn_签名.Name = "Btn_签名"
        Me.Btn_签名.Size = New System.Drawing.Size(80, 30)
        Me.Btn_签名.TabIndex = 22
        Me.Btn_签名.Text = "签 名"
        Me.Btn_签名.UseVisualStyleBackColor = True
        '
        'Btn_打印
        '
        Me.Btn_打印.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_打印.Location = New System.Drawing.Point(542, 205)
        Me.Btn_打印.Name = "Btn_打印"
        Me.Btn_打印.Size = New System.Drawing.Size(80, 30)
        Me.Btn_打印.TabIndex = 21
        Me.Btn_打印.Text = "打 印"
        Me.Btn_打印.UseVisualStyleBackColor = True
        '
        'Btn_退出
        '
        Me.Btn_退出.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_退出.Location = New System.Drawing.Point(543, 352)
        Me.Btn_退出.Name = "Btn_退出"
        Me.Btn_退出.Size = New System.Drawing.Size(80, 30)
        Me.Btn_退出.TabIndex = 24
        Me.Btn_退出.Text = "退 出"
        Me.Btn_退出.UseVisualStyleBackColor = True
        '
        'OpenFileDialog浏览
        '
        Me.OpenFileDialog浏览.FileName = "OpenFileDialog1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(249, 391)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(248, 20)
        Me.ProgressBar1.TabIndex = 25
        '
        'SignExcelDwg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 435)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Btn_退出)
        Me.Controls.Add(Me.Btn_图层线宽)
        Me.Controls.Add(Me.Btn_签名)
        Me.Controls.Add(Me.Btn_打印)
        Me.Controls.Add(Me.Btn_测试)
        Me.Controls.Add(Me.Btn_清空)
        Me.Controls.Add(Me.Btn_删除)
        Me.Controls.Add(Me.Btn_浏览)
        Me.Controls.Add(Me.Chk_竣工章许可编号)
        Me.Controls.Add(Me.Lbl_日)
        Me.Controls.Add(Me.Lbl_月)
        Me.Controls.Add(Me.Lbl_年)
        Me.Controls.Add(Me.Txt_日)
        Me.Controls.Add(Me.Txt_月)
        Me.Controls.Add(Me.Txt_年)
        Me.Controls.Add(Me.Lbl_签名日期)
        Me.Controls.Add(Me.Cbo_第二签名者姓名)
        Me.Controls.Add(Me.Lbl_第二签名者姓名)
        Me.Controls.Add(Me.Cbo_签名者姓名)
        Me.Controls.Add(Me.Lbl_签名者姓名)
        Me.Controls.Add(Me.GroupB签名者身份)
        Me.Controls.Add(Me.GroupB文件类型)
        Me.Controls.Add(Me.Cbo_全路径名)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SignExcelDwg"
        Me.Text = "Form1"
        Me.GroupB文件类型.ResumeLayout(False)
        Me.GroupB文件类型.PerformLayout()
        Me.GroupB签名者身份.ResumeLayout(False)
        Me.GroupB签名者身份.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cbo_全路径名 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupB文件类型 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_Dwg As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Excel As System.Windows.Forms.RadioButton
    Friend WithEvents GroupB签名者身份 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_标检 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_审核 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_批准 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_工艺 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_竣工图 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_校对 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_设计 As System.Windows.Forms.RadioButton
    Friend WithEvents Lbl_签名者姓名 As System.Windows.Forms.Label
    Friend WithEvents Cbo_签名者姓名 As System.Windows.Forms.ComboBox
    Friend WithEvents Cbo_第二签名者姓名 As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_第二签名者姓名 As System.Windows.Forms.Label
    Friend WithEvents Lbl_签名日期 As System.Windows.Forms.Label
    Friend WithEvents Txt_年 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_月 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_日 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_年 As System.Windows.Forms.Label
    Friend WithEvents Lbl_月 As System.Windows.Forms.Label
    Friend WithEvents Lbl_日 As System.Windows.Forms.Label
    Friend WithEvents Chk_竣工章许可编号 As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_浏览 As System.Windows.Forms.Button
    Friend WithEvents Btn_删除 As System.Windows.Forms.Button
    Friend WithEvents Btn_测试 As System.Windows.Forms.Button
    Friend WithEvents Btn_清空 As System.Windows.Forms.Button
    Friend WithEvents Btn_图层线宽 As System.Windows.Forms.Button
    Friend WithEvents Btn_签名 As System.Windows.Forms.Button
    Friend WithEvents Btn_打印 As System.Windows.Forms.Button
    Friend WithEvents Btn_退出 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog浏览 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Rdb_Word As System.Windows.Forms.RadioButton
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
