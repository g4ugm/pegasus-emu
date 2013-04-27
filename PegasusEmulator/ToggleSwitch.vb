Public Class ToggleSwitch

    Inherits System.Windows.Forms.UserControl

    Private SwtchOn As Boolean

    Public Sub OnOff(ByVal value As Boolean)
        SwtchOn = value
        Me.ToggleOff.Visible = Not SwtchOn
        Me.ToggleON.Visible = SwtchOn
    End Sub

    Private Sub ToggleSwitch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SwtchOn = False
        Me.ToggleOff.Visible = Not SwtchOn
        Me.ToggleON.Visible = SwtchOn

    '
    ' Go round anti-clockwise
    '
        lsH1.Y1 = 0
        lsH1.Y2 = 0
        lsH1.X1 = Me.Width * 0.25
        lsH1.X2 = Me.Width * 0.75
    '
        LSH2.Y1 = 0
        LSH2.Y2 = Me.Height * 0.5
        LSH2.X1 = Me.Width * 0.75
        LSH2.X2 = Me.Width - 1
    '
        LSH3.Y1 = Me.Height * 0.5
        LSH3.Y2 = Me.Height - 1
        LSH3.X1 = Me.Width - 1
        LSH3.X2 = Me.Width * 0.75
    '
        LSH4.Y1 = Me.Height - 1
        LSH4.Y2 = Me.Height - 1
        LSH4.X1 = Me.Width * 0.25
        LSH4.X2 = Me.Width * 0.75
    '
        LSH5.Y1 = Me.Height - 1
        LSH5.Y2 = Me.Height * 0.5
        LSH5.X1 = Me.Width * 0.25
        LSH5.X2 = 0
    '
        LSH6.Y1 = Me.Height * 0.5
        LSH6.Y2 = 0
        LSH6.X1 = 0
        LSH6.X2 = Me.Width * 0.25
    '
    ' now the threaded shaft
    '
        OSin.Width = Me.Width * 0.75
        OSin.Height = Me.Height * 0.75
        OSin.Top = Me.Height * 0.125
        OSin.Left = Me.Width * 0.125
    '
        OSin2.Width = OSin.Width - 10
        OSin2.Height = OSin.Height - 10
        OSin2.Top = OSin.Top + 5
        OSin2.Left = OSin.Left + 5
    '
        ToggleON.Width = OSin.Width * 0.5
        ToggleON.Height = OSin.Height * 0.5
        ToggleON.Left = (Me.Width - ToggleON.Width) * 0.5
        ToggleON.Top = 5
    '
        ToggleOff.Width = OSin.Width * 0.5
        ToggleOff.Height = OSin.Height * 0.5
        ToggleOff.Left = (Me.Width - ToggleON.Width) * 0.5
        ToggleOff.Top = (Me.Height - ToggleON.Height) - 5

    End Sub


End Class
