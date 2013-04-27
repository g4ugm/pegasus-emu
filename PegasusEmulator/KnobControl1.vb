Public Class KnobControl1

    Inherits System.Windows.Forms.UserControl

    Private CenterX As Int32
    Private CenterY As Int32
    Private Radius As Int32
    Private Pclicks As Int32


    Private xval As Int32

    Public Property Cliks() As Int32
        Get
            Return pCLicks
        End Get
        Set(ByVal value As Int32)
            Pclicks = value
        End Set
    End Property

    Public Property NoCliks() As Int32
        Get
            Return Pclicks
        End Get
        Set(ByVal value As Int32)
            Pclicks = value
        End Set
    End Property

    Public Sub ClickNo(ByVal value As Int32)
        Dim Angle As Double
        Angle = value * 2 * Math.PI / Pclicks
        Me.Pointer.X2 = Me.Pointer.X1 + (Me.Radius * Math.Sin(Angle))
        Me.Pointer.Y2 = Me.Pointer.Y1 - (Me.Radius * Math.Cos(Angle))
        Me.Grip.X2 = Me.Grip.X1 - ((Radius * 0.75) * Math.Sin(Angle))
        Me.Grip.Y2 = Me.Grip.Y1 + ((Radius * 0.75) * Math.Cos(Angle))
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        '
        ' Build the knob - first the pointer
        '

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub KnobControl1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Height < Me.Width Then
            Radius = Me.Height / 2.0
        Else
            Radius = Me.Width / 2.0
        End If

        Me.Pointer.X1 = Me.Radius
        Me.Pointer.Y1 = Me.Radius
        Me.Pointer.X2 = Me.Radius
        Me.Pointer.Y2 = Me.Pointer.Y1 - Me.Radius
        '
        ' Now the knobby bit
        '

        Me.Grip.X1 = Me.Radius
        Me.Grip.Y1 = Me.Radius
        Me.Grip.X2 = Me.Radius
        Me.Grip.BorderWidth = Me.Radius * 0.25
        Me.Grip.Y2 = Me.Pointer.Y1 + (Radius * 0.75)
        '
        ' now the center bit
        '
        Me.Boss.Height = Radius / 2.0
        Me.Boss.Width = Radius / 2.0
        Me.Boss.Top = (Me.Radius - (Me.Boss.Height / 2.0))
        Me.Boss.Left = (Me.Radius - (Me.Boss.Height / 2.0))
    End Sub


End Class
