Public Class RoundKnob
    Private Radius As Int16
    Private DotRadius As Int16

    Private Sub RoundKnob_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Height < Me.Width Then
            Radius = Me.Height \ 2
        Else
            Radius = Me.Width \ 2
        End If
        Radius = Radius - 3
        Me.shpBody.Height = Radius * 2.0
        Me.shpBody.Width = Radius * 2.0
        Me.shpBody.Top = 0
        Me.shpBody.Left = 0
        '
        ' place the dot
        '
        DotRadius = (Radius * 0.2) + 2
        Me.shpDot.Height = DotRadius
        Me.shpDot.Width = DotRadius
        Me.shpDot.Top = DotRadius \ 2
        Me.shpDot.Left = (Radius - DotRadius / 2) + 0.5
    End Sub
End Class
