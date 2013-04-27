Public Class MainStore
    Private Drum_Words(4096) As Int64
    Public Function ReadWord(ByVal StoreAddress As Int32) As Int64
        ReadWord = Drum_Words(StoreAddress)
    End Function
    Public Sub WriteWord(ByVal StoreAddress As Int32, ByVal StoreValue As Int64)
        Drum_Words(StoreAddress) = StoreValue
    End Sub
End Class
