﻿Namespace BomTable
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm4_OverShow
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
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("宋体", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.Label1.Location = New System.Drawing.Point(14, 27)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(82, 24)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Label1"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(69, 81)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(185, 36)
            Me.Button1.TabIndex = 1
            Me.Button1.Text = "确定"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(574, 81)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(75, 35)
            Me.Button2.TabIndex = 2
            Me.Button2.Text = "Button2"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(574, 27)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(75, 35)
            Me.Button3.TabIndex = 3
            Me.Button3.Text = "Button3"
            Me.Button3.UseVisualStyleBackColor = True
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(574, 131)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(75, 35)
            Me.Button4.TabIndex = 4
            Me.Button4.Text = "Button4"
            Me.Button4.UseVisualStyleBackColor = True
            '
            'Frm4_OverShow
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(325, 139)
            Me.Controls.Add(Me.Button4)
            Me.Controls.Add(Me.Button3)
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Frm4_OverShow"
            Me.Text = "Frm4_OverShow"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents Button4 As System.Windows.Forms.Button
    End Class
End Namespace