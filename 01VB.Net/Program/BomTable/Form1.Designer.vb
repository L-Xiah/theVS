Namespace BomTable
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Form1
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
            Me.Btn_浏览 = New System.Windows.Forms.Button()
            Me.OpenFileDialog浏览 = New System.Windows.Forms.OpenFileDialog()
            Me.Lst_文件 = New System.Windows.Forms.ListBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Btn_查物料 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Btn_浏览
            '
            Me.Btn_浏览.Font = New System.Drawing.Font("宋体", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Btn_浏览.Location = New System.Drawing.Point(12, 12)
            Me.Btn_浏览.Name = "Btn_浏览"
            Me.Btn_浏览.Size = New System.Drawing.Size(466, 60)
            Me.Btn_浏览.TabIndex = 0
            Me.Btn_浏览.Text = "浏  览"
            Me.Btn_浏览.UseVisualStyleBackColor = True
            '
            'OpenFileDialog浏览
            '
            Me.OpenFileDialog浏览.FileName = "OpenFileDialog1"
            '
            'Lst_文件
            '
            Me.Lst_文件.FormattingEnabled = True
            Me.Lst_文件.ItemHeight = 15
            Me.Lst_文件.Location = New System.Drawing.Point(12, 87)
            Me.Lst_文件.Name = "Lst_文件"
            Me.Lst_文件.Size = New System.Drawing.Size(466, 259)
            Me.Lst_文件.TabIndex = 3
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(515, 31)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(111, 83)
            Me.Button1.TabIndex = 4
            Me.Button1.Text = "生成物料清单"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(515, 261)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(111, 83)
            Me.Button2.TabIndex = 5
            Me.Button2.Text = "返回ERP"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'Btn_查物料
            '
            Me.Btn_查物料.Location = New System.Drawing.Point(515, 146)
            Me.Btn_查物料.Name = "Btn_查物料"
            Me.Btn_查物料.Size = New System.Drawing.Size(111, 83)
            Me.Btn_查物料.TabIndex = 6
            Me.Btn_查物料.Text = "查找物料"
            Me.Btn_查物料.UseVisualStyleBackColor = True
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(638, 356)
            Me.Controls.Add(Me.Btn_查物料)
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.Lst_文件)
            Me.Controls.Add(Me.Btn_浏览)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Btn_浏览 As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog浏览 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents Lst_文件 As System.Windows.Forms.ListBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Btn_查物料 As System.Windows.Forms.Button

    End Class
End Namespace