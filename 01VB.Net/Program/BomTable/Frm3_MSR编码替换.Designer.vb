Namespace BomTable
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm3_MSR编码替换
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
            Me.Label2 = New System.Windows.Forms.Label()
            Me.ListBox1 = New System.Windows.Forms.ListBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.TextBox2 = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("宋体", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label1.Location = New System.Drawing.Point(139, 28)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(222, 28)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "MSR超长编码替换"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("宋体", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label2.Location = New System.Drawing.Point(26, 85)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(124, 28)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "已有编码"
            '
            'ListBox1
            '
            Me.ListBox1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.ListBox1.FormattingEnabled = True
            Me.ListBox1.ItemHeight = 20
            Me.ListBox1.Location = New System.Drawing.Point(31, 126)
            Me.ListBox1.Name = "ListBox1"
            Me.ListBox1.Size = New System.Drawing.Size(306, 344)
            Me.ListBox1.TabIndex = 2
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("宋体", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label3.Location = New System.Drawing.Point(360, 85)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(152, 28)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "待替换编码"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("宋体", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label4.Location = New System.Drawing.Point(360, 143)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(306, 28)
            Me.Label4.TabIndex = 4
            Me.Label4.Text = "                     "
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("宋体", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label5.Location = New System.Drawing.Point(360, 191)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(124, 28)
            Me.Label5.TabIndex = 5
            Me.Label5.Text = "替换部分"
            '
            'TextBox1
            '
            Me.TextBox1.Font = New System.Drawing.Font("宋体", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.TextBox1.Location = New System.Drawing.Point(364, 234)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(229, 34)
            Me.TextBox1.TabIndex = 6
            '
            'TextBox2
            '
            Me.TextBox2.Font = New System.Drawing.Font("宋体", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.TextBox2.Location = New System.Drawing.Point(363, 341)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(230, 34)
            Me.TextBox2.TabIndex = 8
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("宋体", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label6.Location = New System.Drawing.Point(359, 298)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(124, 28)
            Me.Label6.TabIndex = 7
            Me.Label6.Text = "替换成："
            '
            'Button1
            '
            Me.Button1.Font = New System.Drawing.Font("宋体", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Button1.Location = New System.Drawing.Point(360, 392)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(233, 68)
            Me.Button1.TabIndex = 9
            Me.Button1.Text = "确    定"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Frm3_MSR编码替换
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(612, 493)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.ListBox1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Name = "Frm3_MSR编码替换"
            Me.Text = "Frm3_MSR编码替换"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
    End Class
End Namespace