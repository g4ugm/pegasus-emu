Public Class CPUTest

    Dim chrfigs() As String = {"figs", "1", "2", "*", "4", "(", ")", "7", "8", "", "=", "-", "v", vbLf, " ", ",", "0", ">", "", "3", "", "5", "6", "/", "x", "9", "+", "LTRS", ".", "n", vbCr, "X"}
    Dim chrltrs() As String = {"figs", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "LTRS", ".", "?", "£", "X"}
    Dim figs As Boolean = True

    Private Sub CPUTest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        displayreg()
    End Sub


    Private Sub udA1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles udA1.Click, udA3.Click, udA2.Click, udN3.Click, udN2.Click, udN1.Click, udX.Click, udM.Click, udF2.Click, udF1.Click, udOVR.Click
        'Dim RegValue As Int64

        ' MsgBox(" Address is " & udA1.Value & udA2.Value & udA3.Value)


        ' MsgBox(" Value is " & Oct(RegValue))
        displayreg()
    End Sub
    Private Sub displayreg()
        '
        ' refresh the control panel
        '
        Dim regvalue As Int64
        regvalue = MainPanel.MyCpu.ReadN(udA3.Value + 8 * (udA2.Value + 8 * udA1.Value))
        udreg13.Value = regvalue And &O7
        udreg12.Value = (regvalue >> 3) And &O7
        udreg11.Value = (regvalue >> 6) And &O7
        udreg10.Value = (regvalue >> 9) And &O7
        udreg9.Value = (regvalue >> 12) And &O7
        udreg8.Value = (regvalue >> 15) And &O7
        udreg7.Value = (regvalue >> 18) And &O7
        udreg6.Value = (regvalue >> 21) And &O7
        udreg5.Value = (regvalue >> 24) And &O7
        udreg4.Value = (regvalue >> 27) And &O7
        udreg3.Value = (regvalue >> 30) And &O7
        udreg2.Value = (regvalue >> 33) And &O7
        udreg1.Value = (regvalue >> 36) And &O7
        '
        ' overflow
        '
        If MainPanel.MyCpu.ReadOVR Then
            udOVR.Value = 1
        Else
            udOVR.Value = 0
        End If
        '
        ' Order number reg
        '
        regvalue = MainPanel.MyCpu.ReadOrdNum
        udO3.Value = regvalue And &O7
        udO2.Value = regvalue >> 3 And &O7
        udO1.Value = regvalue >> 6 And &O1
        Me.Refresh()
    End Sub
    Private Sub storereg()
        Dim RegValue As Int64
        Dim RegAddress As Int16
        RegAddress = udA3.Value + 8 * (udA2.Value + 8 * udA1.Value)
        If udreg1.Value >= 4 Then
            RegValue = &HFFFFFFFFFFFFFFF8 Or udreg1.Value
        Else
            RegValue = udreg1.Value
        End If
        RegValue = RegValue << 3 Or udreg2.Value
        RegValue = RegValue << 3 Or udreg3.Value
        RegValue = RegValue << 3 Or udreg4.Value
        RegValue = RegValue << 3 Or udreg5.Value
        RegValue = RegValue << 3 Or udreg6.Value
        RegValue = RegValue << 3 Or udreg7.Value
        RegValue = RegValue << 3 Or udreg8.Value
        RegValue = RegValue << 3 Or udreg9.Value
        RegValue = RegValue << 3 Or udreg10.Value
        RegValue = RegValue << 3 Or udreg11.Value
        RegValue = RegValue << 3 Or udreg12.Value
        RegValue = RegValue << 3 Or udreg13.Value
        MsgBox("Address is " & RegAddress & " Value is " & Oct(RegValue))
        MainPanel.MyCpu.WriteN(RegAddress, RegValue)
    End Sub


    Private Sub btnStore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStore.Click
        Call storereg()
    End Sub

    Private Sub btnExecute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        '
        ' Execute an instruction from the panel
        '
        Dim Instruction As Int64
        '
        Instruction = udN3.Value + (8 * (udN2.Value + 8 * udN1.Value))
        Instruction = (Instruction << 3) + udX.Value
        Instruction = (Instruction << 6) + (udF2.Value + 8 * udF1.Value)
        Instruction = (Instruction << 3) + udM.Value
        '
        ' MsgBox("Executing Instruction " & Oct(Instruction))
        MainPanel.MyCpu.ExecuteInstruction(Instruction)
        '
        ' update the display
        '
        displayreg()
    End Sub

    Private Sub udO1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles udO1.Click, udO3.Click, udO2.Click
        '
        ' The ordnumber register has been updated. Fetch the operand and display
        '
        '
        MainPanel.MyCpu.WriteOrdNum(udO3.Value + (8 * (udO2.Value + 8 * udO1.Value)))
        '
        MsgBox(" Ord Number reg = " + Oct(MainPanel.MyCpu.ReadOrdNum))
        '
        ' Now get the conent of the location
        '
        Dim word As Int32
        word = MainPanel.MyCpu.ReadOrd()
        MsgBox("Order = " & Oct(word))
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udOVR.ValueChanged
        MainPanel.MyCpu.ReadOVR()
    End Sub

    Private Sub btnStoreInst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStoreInst.Click
        Dim Instruction As Int64, OrdNum As Int32
        '
        Instruction = udN3.Value + (8 * (udN2.Value + 8 * udN1.Value))
        Instruction = (Instruction << 3) + udX.Value
        Instruction = (Instruction << 6) + (udF2.Value + 8 * udF1.Value)
        Instruction = (Instruction << 3) + udM.Value
        '
        ' now store in memory
        '
        OrdNum = MainPanel.MyCpu.ReadOrdNum
        If (OrdNum And &O100) = 0 Then
            MainPanel.MyCpu.WriteN(OrdNum + 64, (MainPanel.MyCpu.ReadN(OrdNum + 64) And &O3777776000000) Or Instruction)
        Else
            MainPanel.MyCpu.WriteN(OrdNum, (MainPanel.MyCpu.ReadN(OrdNum) And &O1777777) Or (Instruction << 19))
        End If
        displayreg()
    End Sub


    Private Sub btnRUN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRUN.Click

        MainPanel.MyCpu.running = True
        While (MainPanel.MyCpu.running = True)
            MainPanel.MyCpu.ExecuteInstruction(MainPanel.MyCpu.ReadOrd)
            displayreg()
        End While
    End Sub


    Private Sub btnLoadProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadProgram.Click
        Dim chrByte As Byte
        Dim chrChar As String
        Dim LoadAddress As Integer
        Dim Order As Int64
        Dim TmpString As String
        Dim N, X, F, M As Integer

        openProgram.Filter = "Tape files (*.tap)|*.tap|All files (*.*)|*.*"

        If openProgram.ShowDialog() = DialogResult.OK Then

            Dim strTapeFile As String = openProgram.FileName

            Using SourceStream As FileStream = File.Open(strTapeFile, FileMode.Open)

                While SourceStream.Position <> SourceStream.Length

                    chrByte = SourceStream.ReadByte()
                    If chrByte = -1 Then Exit While

                    Select Case Chr(chrByte)
                        Case "S" ' This is a an address in the computing store
                            '
                            ' Read the block number
                            '
                            chrByte = SourceStream.ReadByte
                            Select Case Chr(chrByte)
                                Case "0" To "7"
                                    LoadAddress = 64 + Val(Chr(chrByte)) * 8
                                Case Else
                                    MsgBox("Invalid Blocknumber " & Chr(chrByte))
                                    Exit While
                            End Select
                            '
                            ' Now there should be a decimal point
                            '
                            chrByte = SourceStream.ReadByte
                            If Chr(chrByte) <> "." Then
                                MsgBox("Found <" & Chr(chrByte) & "> When expecting '.'")
                            End If
                            '
                            ' Now another block number
                            '
                            chrByte = SourceStream.ReadByte
                            Select Case Chr(chrByte)
                                Case "0" To "7"
                                    LoadAddress = LoadAddress + Val(Chr(chrByte))
                                Case Else
                                    MsgBox("Invalid Blocknumber " & Chr(chrByte))
                                    Exit While
                            End Select
                            MsgBox("Load Address = " & Oct(LoadAddress))

                        Case "+" ' This is a full word constant
                            TmpString = ""
                            chrChar = Chr(SourceStream.ReadByte())
                            While chrChar >= "0" And chrChar <= "9"
                                TmpString = TmpString & chrChar
                                chrByte = SourceStream.ReadByte()
                                If chrByte <> -1 Then
                                    chrChar = Chr(chrByte)
                                Else
                                    chrChar = vbCr
                                End If
                            End While
                            If LoadAddress < 64 Then LoadAddress = LoadAddress + 64
                            MainPanel.MyCpu.WriteN(LoadAddress, Val(TmpString))
                            MsgBox("Memory Address = " & Oct(LoadAddress) & " Value = " & Val(TmpString))
                            LoadAddress = LoadAddress + 1
                        Case "0" To "9" ' This is an instruction
                            '
                            ' Get the "N" address.
                            '
                            ' Could be of the format
                            '
                            ' n.n - Implies a main store address 
                            ' nn  - Is the address of a special register 
                            ' nn  - Is the number of bits to move in a shift
                            '
                            TmpString = Chr(chrByte)
                            If SourceStream.Position <> SourceStream.Length Then
                                chrByte = SourceStream.ReadByte()
                                chrChar = Chr(chrByte)
                                If chrChar = "." Then
                                    '
                                    ' this is a main store address
                                    '
                                    chrByte = SourceStream.ReadByte()
                                    N = 64 + Val(TmpString) * 7 + Val(Chr(chrByte))
                                    '
                                    ' now read terminating space
                                    '
                                    chrByte = SourceStream.ReadByte()
                                ElseIf chrChar = " " Then
                                    '
                                    ' this is a register address
                                    '
                                    N = Val(TmpString)
                                ElseIf chrChar >= 0 And chrChar <= 9 Then ' Should be an integer for in immediate or shift
                                    TmpString = TmpString & chrChar
                                    While True
                                        chrByte = SourceStream.ReadByte()
                                        chrChar = Chr(chrByte)
                                        If chrChar < "0" Or chrChar > "9" Then Exit While
                                    End While
                                    N = Val(TmpString)
                                Else
                                    MsgBox("Illegal Character <" & chrChar & "> Found reading program")
                                End If

                            Else

                            End If

                            '
                            ' Now there should be an "X" address
                            '
                            If SourceStream.Position <> SourceStream.Length Then
                                chrByte = SourceStream.ReadByte()
                                chrChar = Chr(chrByte)
                                If chrChar < "0" Or chrChar > "7" Then
                                    MsgBox("Foundr <" & chrChar & "> Expecting Register Number between 0 and 7 ")
                                Else
                                    X = Val(chrChar)
                                End If
                            Else
                                MsgBox("Partial Instruction found")
                                Exit While
                            End If
                            '
                            ' Should be a space to skip
                            '
                            If SourceStream.Position <> SourceStream.Length Then
                                chrByte = SourceStream.ReadByte()
                                chrChar = Chr(chrByte)
                            Else
                                MsgBox("Partial Instruction found")
                                Exit While
                            End If                            '
                            '
                            ' Now a two digit instruction code
                            '
                            If SourceStream.Position <> SourceStream.Length Then
                                chrByte = SourceStream.ReadByte()
                                chrChar = Chr(chrByte)
                                If chrChar < "0" Or chrChar > "7" Then
                                    MsgBox("Foundr <" & chrChar & "> Expecting Instruction Group")
                                Else
                                    F = Val(chrChar) * 8
                                End If
                            Else
                                MsgBox("Partial Instruction found")
                                Exit While
                            End If
                            If SourceStream.Position <> SourceStream.Length Then
                                chrByte = SourceStream.ReadByte()
                                chrChar = Chr(chrByte)
                                If chrChar < "0" Or chrChar > "7" Then
                                    MsgBox("Foundr <" & chrChar & "> Expecting Instruction Group")
                                Else
                                    F = F + Val(chrChar)
                                End If
                            Else
                                MsgBox("Partial Instruction found")
                                Exit While
                            End If
                            MsgBox("Instruction = " & Oct(N) & " " & Oct(X) & " " & Oct(F))
                            Order = (N << 12) Or (X << 9) Or (F << 3)
                            MsgBox("Order = " & Oct(Order))
                            '
                            ' Now store the instruction
                            '
                            If LoadAddress > 63 Then
                                '
                                ' This is the "A" order
                                '
                                MainPanel.MyCpu.WriteN(LoadAddress, (Order << 19) Or (MainPanel.MyCpu.ReadN(LoadAddress) And &O1777777))
                                LoadAddress = LoadAddress - 64
                            Else
                                '
                                ' This is the "B" order.
                                '
                                MainPanel.MyCpu.WriteN(LoadAddress + 64, Order Or (MainPanel.MyCpu.ReadN(LoadAddress + 64) And (&O1777777 << 19)))
                                LoadAddress = LoadAddress + 65
                            End If
                        Case "N"
                            Dim figcount As Integer
                            figcount = 0
                            While SourceStream.Position <> SourceStream.Length
                                chrByte = SourceStream.ReadByte()
                                chrChar = Chr(chrByte)
                                If chrChar = "|" Then
                                    figcount = figcount + 1
                                    If figcount > 1 Then Exit While
                                Else
                                    figcount = 0
                                    MainPanel.MyCpu.PrintChrs(chrChar)
                                End If
                            End While
                        Case Else

                    End Select

                End While

            End Using
        Else
            MsgBox("Please Enter a filename", MsgBoxStyle.Exclamation)
        End If
        MsgBox("Program Loaded")
    End Sub
    ' If Asc(chrByte) <> 51 Then MsgBox("Character =" & Hex(chrByte))
    '                    If (chrByte >= 32) Then chrByte = chrByte - 32
    '                   If chrByte = 0 Then
    'If Not figs Then
    'figs = True
    'e() 'lse
    'tx() 'tTape.Text = txtTape.Text & "|"
    'End If

    'ElseIf chrByte = 27 Then
    'figs = False
    'ElseIf chrByte = 13 Then
    'txtTape.Text = txtTape.Text & vbCrLf
    'ElseIf chrByte = 30 Then
    ' txtTape.Text = txtTape.Text & vbCrLf
    'Else
    'If figs Then
    'txtTape.Text = txtTape.Text & chrfigs(chrByte)
    'Else
    'txtTape.Text = txtTape.Text & chrltrs(chrByte)
    'End If
    'End If
End Class