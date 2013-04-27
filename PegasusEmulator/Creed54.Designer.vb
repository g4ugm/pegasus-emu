<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Creed54
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtPrint = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtPrint
        '
        Me.txtPrint.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrint.Location = New System.Drawing.Point(30, 36)
        Me.txtPrint.Multiline = True
        Me.txtPrint.Name = "txtPrint"
        Me.txtPrint.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPrint.Size = New System.Drawing.Size(802, 389)
        Me.txtPrint.TabIndex = 0
        '
        'Creed54
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 450)
        Me.Controls.Add(Me.txtPrint)
        Me.Name = "Creed54"
        Me.Text = "Creed54"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrint As System.Windows.Forms.TextBox
End Class
