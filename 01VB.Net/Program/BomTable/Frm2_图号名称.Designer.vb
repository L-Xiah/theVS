Namespace BomTable
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm2_图号名称
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
            Me.Txt_图号 = New System.Windows.Forms.TextBox()
            Me.Txt_名称 = New System.Windows.Forms.TextBox()
            Me.Btn_确定 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("宋体", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label1.Location = New System.Drawing.Point(35, 22)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(82, 24)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "图  号"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("宋体", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label2.Location = New System.Drawing.Point(245, 22)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(82, 24)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "名  称"
            '
            'Txt_图号
            '
            Me.Txt_图号.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Txt_图号.Location = New System.Drawing.Point(22, 58)
            Me.Txt_图号.Name = "Txt_图号"
            Me.Txt_图号.Size = New System.Drawing.Size(146, 30)
            Me.Txt_图号.TabIndex = 2
            '
            'Txt_名称
            '
            Me.Txt_名称.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Txt_名称.Location = New System.Drawing.Point(211, 58)
            Me.Txt_名称.Name = "Txt_名称"
            Me.Txt_名称.Size = New System.Drawing.Size(156, 30)
            Me.Txt_名称.TabIndex = 3
            '
            'Btn_确定
            '
            Me.Btn_确定.Location = New System.Drawing.Point(22, 94)
            Me.Btn_确定.Name = "Btn_确定"
            Me.Btn_确定.Size = New System.Drawing.Size(345, 35)
            Me.Btn_确定.TabIndex = 4
            Me.Btn_确定.Text = "确定"
            Me.Btn_确定.UseVisualStyleBackColor = True
            '
            'Frm2_图号名称
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.ClientSize = New System.Drawing.Size(389, 141)
            Me.Controls.Add(Me.Btn_确定)
            Me.Controls.Add(Me.Txt_名称)
            Me.Controls.Add(Me.Txt_图号)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Frm2_图号名称"
            Me.Text = "Form2"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Txt_图号 As System.Windows.Forms.TextBox
        Friend WithEvents Txt_名称 As System.Windows.Forms.TextBox
        Friend WithEvents Btn_确定 As System.Windows.Forms.Button
    End Class
End Namespace