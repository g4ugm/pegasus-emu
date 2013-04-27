<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KnobControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Pointer = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Boss = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.Grip = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.SuspendLayout()
        '
        'Pointer
        '
        Me.Pointer.BorderWidth = 4
        Me.Pointer.Enabled = False
        Me.Pointer.Name = "Pointer"
        Me.Pointer.X1 = 96
        Me.Pointer.X2 = 96
        Me.Pointer.Y1 = 108
        Me.Pointer.Y2 = 8
        '
        'Boss
        '
        Me.Boss.BackColor = System.Drawing.Color.Black
        Me.Boss.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Boss.Enabled = False
        Me.Boss.Location = New System.Drawing.Point(70, 81)
        Me.Boss.Name = "Boss"
        Me.Boss.Size = New System.Drawing.Size(50, 50)
        '
        'Grip
        '
        Me.Grip.BorderWidth = 25
        Me.Grip.Enabled = False
        Me.Grip.Name = "Grip"
        Me.Grip.X1 = 95
        Me.Grip.X2 = 95
        Me.Grip.Y1 = 116
        Me.Grip.Y2 = 141
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Grip, Me.Boss, Me.Pointer})
        Me.ShapeContainer1.Size = New System.Drawing.Size(209, 237)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'KnobControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "KnobControl1"
        Me.Size = New System.Drawing.Size(209, 237)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pointer As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Boss As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents Grip As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer

End Class
