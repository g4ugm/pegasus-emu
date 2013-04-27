Public Class MainPanel
    Dim Knob1 As Double
    Dim Clicks1, Clicks2 As Int16
    Dim MiliSeconds As Int64
    Dim cXc, cYc As Int32
    Dim tslhson, tsrhson As Boolean
    Public MyCpu As CPU


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Knob1 = 0
        ' Dim MyKnob As New KnobControl1
        Dim line(11) As Microsoft.VisualBasic.PowerPacks.LineShape

        Dim angle As Double
        Dim ticklen As Int32

        Clicks1 = Clicks2 = 0
        MiliSeconds = 0
        tslhson = False
        tsrhson = False
        tsLHS.OnOff(tslhson)
        tsRHS.OnOff(tsrhson)
        '
        ' find the middle of the clock
        '
        cXc = ClkFace.Left + ClkFace.Width / 2
        cYc = ClkFace.Top + ClkFace.Width / 2
        '
        ' drawn the clock hands at 12 o'clock
        '
        ClkSecond.X1 = cXc
        ClkSecond.X2 = ClkSecond.X1
        ClkSecond.Y1 = cYc
        ClkSecond.Y2 = ClkSecond.Y1 - 60
        '
        ClkMinute.X1 = cXc
        ClkMinute.X2 = ClkMinute.X1
        ClkMinute.Y1 = cYc
        ClkMinute.Y2 = ClkMinute.Y1 - 55
        '
        ClkHour.X1 = cXc
        ClkHour.X2 = ClkHour.X1
        ClkHour.Y1 = cYc
        ClkHour.Y2 = ClkHour.Y1 - 40
        '
        ' put the qtr hours in place
        '
        For index As Integer = 0 To 11
            line(index) = New Microsoft.VisualBasic.PowerPacks.LineShape
            line(index).Parent = ClkMinute.Parent
            If (index Mod 3) = 0 Then
                ticklen = 20
            Else
                ticklen = 5
            End If
            angle = index * 2.0 * Math.PI / 12.0
            line(index).X1 = cXc + ((75 - ticklen) * Math.Sin(angle))
            line(index).Y1 = cYc + ((75 - ticklen) * Math.Cos(angle))
            line(index).X2 = cXc + (75 * Math.Sin(angle))
            line(index).Y2 = cYc + (75 * Math.Cos(angle))
            line(index).BringToFront()
        Next
        For Each Ctrl In Panel1.Controls

            Ctrl.ForeColor = Color.White
        Next
        Panel1.ForeColor = Color.Brown
        MyCpu = New CPU
    End Sub

    Private Sub MyCtlKnob1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyCtlKnob1.Click
        'MsgBox("clicked")
        Clicks1 = Clicks1 + 1
        MyCtlKnob1.ClickNo(Clicks1)
    End Sub


    Private Sub Knob2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Knob2.Click
        'MsgBox("clicked")
        Clicks2 = Clicks2 + 1
        Knob2.ClickNo(Clicks2)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MiliSeconds = MiliSeconds + 100
        Dim Angle As Double
        '
        ' Second Hand
        '
        Angle = Now.Second * 2 * Math.PI / 60
        Me.ClkSecond.X2 = cXc + (60 * Math.Sin(Angle))
        Me.ClkSecond.Y2 = cYc - (60 * Math.Cos(Angle))
        '
        Me.ClkSecond.X1 = cXc - (15 * Math.Sin(Angle))
        Me.ClkSecond.Y1 = cYc + (15 * Math.Cos(Angle))
        ClkSecond.BringToFront()
        '
        ' Minute Hand
        '
        Angle = ((Now.Minute * 60) + Now.Second) * 2 * Math.PI / 3600
        Me.ClkMinute.X2 = cXc + (55 * Math.Sin(Angle))
        Me.ClkMinute.Y2 = cYc - (55 * Math.Cos(Angle))
        '
        Me.ClkMinute.X1 = cXc - (10 * Math.Sin(Angle))
        Me.ClkMinute.Y1 = cYc + (10 * Math.Cos(Angle))
        ''
        ' Hour Hand
        '
        Angle = (((Now.Hour Mod 12) / 12.0) + (Now.Minute / (12 * 60)) + (Now.Second / (12 * 60 * 60))) * (2 * Math.PI)
        Me.ClkHour.X2 = cXc + (40 * Math.Sin(Angle))
        Me.ClkHour.Y2 = cYc - (40 * Math.Cos(Angle))
        '
        Me.ClkHour.X1 = cXc - (5 * Math.Sin(Angle))
        Me.ClkHour.Y1 = cYc + (5 * Math.Cos(Angle))

    End Sub


    
    Private Sub TSlhs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsLHS.Click
        tslhson = Not tslhson
        tsLHS.OnOff(tslhson)
    End Sub
    Private Sub TSrhs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsRHS.Click
        tsrhson = Not tsrhson
        tsRHS.OnOff(tsrhson)
        Label16.ForeColor = Color.White
    End Sub




    Private Sub Btntest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNTest.Click
        Dim MyCpu As New CPU
        'MyCpu.ExecuteInstruction()
    End Sub

    Private Sub BTNDemo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNDemo.Click
        CPUTest.Show()
    End Sub


End Class
