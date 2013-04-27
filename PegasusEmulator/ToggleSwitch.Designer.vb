<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToggleSwitch
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.ToggleOff = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.ToggleON = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.LSH6 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LSH5 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LSH3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LSH2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LSH4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.lsH1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.OSin = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.OSin2 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.ToggleOff, Me.ToggleON, Me.OSin2, Me.LSH6, Me.LSH5, Me.LSH3, Me.LSH2, Me.LSH4, Me.lsH1, Me.OSin})
        Me.ShapeContainer1.Size = New System.Drawing.Size(117, 96)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'ToggleOff
        '
        Me.ToggleOff.BackColor = System.Drawing.SystemColors.Control
        Me.ToggleOff.Cursor = System.Windows.Forms.Cursors.Default
        Me.ToggleOff.Enabled = False
        Me.ToggleOff.FillColor = System.Drawing.Color.Silver
        Me.ToggleOff.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.ToggleOff.Location = New System.Drawing.Point(35, 6)
        Me.ToggleOff.Name = "ToggleOff"
        Me.ToggleOff.Size = New System.Drawing.Size(50, 48)
        '
        'ToggleON
        '
        Me.ToggleON.BackColor = System.Drawing.SystemColors.Control
        Me.ToggleON.Cursor = System.Windows.Forms.Cursors.Default
        Me.ToggleON.Enabled = False
        Me.ToggleON.FillColor = System.Drawing.Color.Silver
        Me.ToggleON.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.ToggleON.Location = New System.Drawing.Point(34, 42)
        Me.ToggleON.Name = "ToggleON"
        Me.ToggleON.Size = New System.Drawing.Size(50, 48)
        '
        'LSH6
        '
        Me.LSH6.Cursor = System.Windows.Forms.Cursors.Default
        Me.LSH6.Enabled = False
        Me.LSH6.Name = "LSH6"
        Me.LSH6.X1 = 1
        Me.LSH6.X2 = 19
        Me.LSH6.Y1 = 47
        Me.LSH6.Y2 = 1
        '
        'LSH5
        '
        Me.LSH5.Cursor = System.Windows.Forms.Cursors.Default
        Me.LSH5.Enabled = False
        Me.LSH5.Name = "LineShape1"
        Me.LSH5.X1 = 19
        Me.LSH5.X2 = 2
        Me.LSH5.Y1 = 94
        Me.LSH5.Y2 = 47
        '
        'LSH3
        '
        Me.LSH3.Cursor = System.Windows.Forms.Cursors.Default
        Me.LSH3.Enabled = False
        Me.LSH3.Name = "LSH3"
        Me.LSH3.X1 = 95
        Me.LSH3.X2 = 113
        Me.LSH3.Y1 = 94
        Me.LSH3.Y2 = 48
        '
        'LSH2
        '
        Me.LSH2.Cursor = System.Windows.Forms.Cursors.Default
        Me.LSH2.Enabled = False
        Me.LSH2.Name = "LSH2"
        Me.LSH2.X1 = 112
        Me.LSH2.X2 = 95
        Me.LSH2.Y1 = 48
        Me.LSH2.Y2 = 1
        '
        'LSH4
        '
        Me.LSH4.Cursor = System.Windows.Forms.Cursors.Default
        Me.LSH4.Enabled = False
        Me.LSH4.Name = "LSH4"
        Me.LSH4.X1 = 18
        Me.LSH4.X2 = 95
        Me.LSH4.Y1 = 94
        Me.LSH4.Y2 = 94
        '
        'lsH1
        '
        Me.lsH1.Enabled = False
        Me.lsH1.Name = "lsH1"
        Me.lsH1.X1 = 17
        Me.lsH1.X2 = 94
        Me.lsH1.Y1 = 1
        Me.lsH1.Y2 = 1
        '
        'OSin
        '
        Me.OSin.Enabled = False
        Me.OSin.Location = New System.Drawing.Point(19, 8)
        Me.OSin.Name = "OSin"
        Me.OSin.Size = New System.Drawing.Size(78, 78)
        '
        'OSin2
        '
        Me.OSin2.BackColor = System.Drawing.SystemColors.Control
        Me.OSin2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.OSin2.BorderColor = System.Drawing.Color.Black
        Me.OSin2.BorderWidth = 4
        Me.OSin2.Cursor = System.Windows.Forms.Cursors.Default
        Me.OSin2.Enabled = False
        Me.OSin2.FillColor = System.Drawing.Color.DarkGray
        Me.OSin2.FillGradientColor = System.Drawing.Color.Silver
        Me.OSin2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central
        Me.OSin2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Sphere
        Me.OSin2.Location = New System.Drawing.Point(26, 16)
        Me.OSin2.Name = "OSin2"
        Me.OSin2.Size = New System.Drawing.Size(65, 63)
        '
        'ToggleSwitch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "ToggleSwitch"
        Me.Size = New System.Drawing.Size(117, 96)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents OSin As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents ToggleON As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents LSH6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LSH5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LSH3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LSH2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LSH4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lsH1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ToggleOff As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents OSin2 As Microsoft.VisualBasic.PowerPacks.OvalShape

End Class
