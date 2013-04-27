Public Class CPU
    '
    '                            0      1    2    3    4    5    6    7    8    9    10   11   12   13    14   15   16  17    18  19   20    21   22  23   24    25  26    27     28   29   30     31
    Dim chrfigs() As String = {"figs", "1", "2", "*", "4", "(", ")", "7", "8", "", "=", "-", "v", vbLf, " ", ",", "0", ">", "", "3", "", "5", "6", "/", "x", "9", "+", "LTRS", ".", "n", vbCr, "X"}
    Dim chrfigs16() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-", ".", vbLf, " ", "X", "figs", ">", "", "*", "", "(", ")", "/", "x", "<>", "=", "LTRS", "v", "n", vbCr, ","}
    Dim chrltrs() As String = {"figs", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "LTRS", ".", "?", "£", "X"}
    Dim figs As Boolean = True
    Dim MyDrum As BinaryReader
    '
    '
    ' The computer has a basic word length of 39 bits with the "main store" being a drum 9216 40 bit words
    ' One bit of each word was reserved for parity leaving 39 data bits. 
    ' In the emulator these bits are store in the low-order bits of an int64
    ' the sign bit is extended to fill all the remaining high order bits.
    '
    'Computing Store
    '===============
    '
    ' This is laid out as follows:-
    '
    '   0  ->  7        Accumulators X9-X7 - Note X0 is always zero
    '   8  ->  14       Un-Assigned - Always contain zero
    '   15              Hadn Switchs
    '   16              Input/Output - Checked
    '   17              Input/Output - 5 bits unchecked
    '   18 - 31         Un-assigned: always zero)
    '   32              Constant -1.0
    '   33              Constant 1/2
    '   34              Constant 2**-10
    '   35              Constant 2**-13
    '   36-63           Unassigned - Always zero
    '   64-111          Program/Data Coded as 0.0 through 5.7
    '                   (But stored as 64-111)
    '   112-127         (Un assigned always contaon zero)
    '
    'Instruction Summary
    '===================
    '
    ' The instructions are generally of the forma
    '  
    '    N,X,OP,Modifier
    '
    ' and stored in pairs in 39 bit word as follows:-
    '
    '    "N" => 7 bits Address => Accumulator, Special Register, Store, Literal.
    '    "X" => 3 Bits Accumulator
    '    "M" => 6 Bits Function Code
    '
    '    Not the Pegasus are numbered the other way to intel bits
    '
    '
    '
    'The "N" Field'
    '=============
    '
    'N is written as an integer. 
    '===========================
    '
    'Stored directly in the "N" field. For instruction groups 0,1 and 2 

    '"n" < 8 =>      implies an accumulator
    '
    '7 < "n" < 64    implies a special register 
    '
    '
    '"N" is written as "block.register" 
    '==================================
    '
    'Implies an ordinary register. The high bit is set to show this is an ordinary register.
    '
    'Ex
    '
    ' written Form                     "N" Field
    '
    '0.3                            1 000 011
    '2.6                            1 010 110
    '5.2                            1 101 010
    '
    '
    '
    'The "X" field
    '=============
    '
    '
    'X = 0 -> 7 and is always an accumulator .....
    '
    'If the number is written as an Integer 
    '
    'N = 0 -> 128
    '
    '< 64 = Accumulator 
    '
    ' The computing store. 
    '
    '      Entries 0 to 63 are the Accumulators and Special registers 
    '      Entries 64 to 127 are normal Registers or program store
    '
    Private Ord_Regs(127) As Int64
    '
    ' The Order Number Register 
    '
    Private Ord_Num_reg As Int32
    '
    ' The order register => used for decoding the current order.
    '
    Private Ord_reg As Int64
    '
    ' This is the overflow bit
    '
    Private OVR As Boolean
    '
    ' Some usefull constants
    '
    Const Smallest As Int64 = &O1777777774000000000000
    Const Largest As Int64 = &O3777777777777
    Public running As Boolean
    Dim Printer As Creed54

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        ' InitializeComponent()
        '
        ' Start at Address 0
        '
        Creed54.Show()
        '
        Ord_Num_reg = 0
        ' Add any initialization after the InitializeComponent() call.
        OVR = 0
        Ord_Regs(0) = &O1234567123456
        Ord_Regs(7 + 64) = 99
        Ord_Regs(2) = 88
        running = False

        ' MsgBox("Values are " & Hex(88) & " " & Hex(99))

        'MyDrum = File.Open("Pegasus.DRM", FileMode.OpenOrCreate)

        'If MyDrum.Length < (5 * 9216) Then
        'For i = 1 To 9216
        '       MyDrum.
        'Next
        'End If

        'While SourceStream.Position <> SourceStream.Length

        'chrByte = SourceStream.ReadByte()


    End Sub

    Public Function ReadN(ByVal RegAddress As Int32) As Int64
        If RegAddress = 0 Then
            ReadN = 0
        Else
            ReadN = Ord_Regs(RegAddress)
        End If
    End Function

    Public Sub WriteN(ByVal RegAddress As Int32, ByVal RegValue As Int64)
        If RegAddress = 16 Then
            RegValue = RegValue And &O37
            If RegValue = 16 Then
                figs = False
            ElseIf RegValue = 27 Then
                figs = False
            ElseIf (figs) Then
                Creed54.txtPrint.Text = Creed54.txtPrint.Text & chrfigs16(RegValue)
            Else
                Creed54.txtPrint.Text = Creed54.txtPrint.Text & chrltrs(RegValue)
            End If
        ElseIf RegAddress = 17 Then
            RegValue = RegValue And &O37
            If RegValue = 0 Then
                figs = False
            ElseIf RegValue = 27 Then
                figs = False
            ElseIf (figs) Then
                Creed54.txtPrint.Text = Creed54.txtPrint.Text & chrfigs(RegValue)
            Else
                Creed54.txtPrint.Text = Creed54.txtPrint.Text & chrltrs(RegValue)
            End If
        ElseIf RegAddress <> 0 Then
            Ord_Regs(RegAddress) = RegValue
        End If
    End Sub
    Public Sub PrintChrs(ByVal PrtChar As String)
        Creed54.txtPrint.Text = Creed54.txtPrint.Text & PrtChar
    End Sub
    '
    ' This function writes to the computing stire and sets overflow as appropriate
    '
    ' It works because the calculations are perfomed to 64 bits 
    '
    Public Sub WriteNO(ByVal RegAddress As Int32, ByVal RegValue As Int64)
        If RegValue < Smallest Then
            RegValue = RegValue Or Smallest
            OVR = True
        ElseIf RegValue > Largest Then
            RegValue = RegValue And Largest
            OVR = True
        End If

        If RegAddress <> 0 Then
            WriteN(RegAddress, RegValue)
        End If
    End Sub

    Public Sub WritePQ(ByVal Value1 As UInt32, ByVal Value2 As Int64)
        Ord_Regs(6) = Value1
        Ord_Regs(7) = Value2
    End Sub
    Public Sub WriteD(ByVal Value1 As Decimal)
        Ord_Regs(6) = Value1
        Ord_Regs(7) = Value1 / &O777777777777
    End Sub
    Public Function ReadOrdNum() As Int16
        ReadOrdNum = Ord_Num_reg
    End Function
    Public Sub WriteOrdNum(ByVal Address As Integer)
        Ord_Num_reg = Address
    End Sub
    Public Sub WriteOVR(ByVal flag As Boolean)
        OVR = flag
    End Sub
    Public Function ReadOVR()
        ReadOVR = OVR
    End Function
    Public Function ReadM(ByVal Address As Integer) As Int64

    End Function

    '
    ' Returns the order pointed to by the order number register. 
    ' The high bit of the regsiter determines if wwe return the "A" or "B" order 
    ''
    Public Function ReadOrd() As Int32
        If Ord_Num_reg < 64 Then
            ReadOrd = Ord_Regs(Ord_Num_reg + 64) And &O1777777
        Else
            ReadOrd = (Ord_Regs(Ord_Num_reg) >> 19) And &O1777777
        End If
    End Function


    Public Sub ExecuteInstruction(ByVal instruction As Int64)

        Dim X As ULong  ' Accumuator Number
        Dim N As ULong  ' 
        Dim XV, NV, XH, XL, NH, NL, A1, A2, A3, A4, AL, AH As Decimal
        Dim F As ULong
        Dim M As ULong
        Dim NegProd As Boolean

        '
        ' Execute first instruction of pair
        '
        Ord_reg = instruction
        'MsgBox("order is " & Oct(Ord_reg))
        '
        N = (Ord_reg And &O17770000) >> 12
        X = (Ord_reg And &O7000) >> 9
        F = (Ord_reg And &O770) >> 3
        M = (Ord_reg And &O7)
        '
        ' Now increment the Order Number Register
        '
        If (Ord_Num_reg > 63) Then
            Ord_Num_reg = Ord_Num_reg - 64
        Else
            Ord_Num_reg = Ord_Num_reg + 65
        End If
        '
        '
        ' MsgBox(Oct(N) & " " & Oct(X) & " " & Oct(F) & " " & Oct(M))
        '
        ' Test instructions
        '
        'X = 7
        'N = 2
        'M = 0
        'F = &O41

        Select Case F
            '
            ' Group zero - Answer in the accumulator "X"
            '
            Case &O0   ' x = n
                WriteN(X, ReadN(N))
            Case &O1   ' x = x + n
                WriteNO(X, (ReadN(X) + ReadN(N)))
            Case &O2 ' x = - n             '
                WriteNO(X, (0 - ReadN(N)))
            Case &O3 ' x = x - n
                WriteNO(X, (ReadN(X) - ReadN(N)))
            Case &O4 ' x = n - x
                WriteNO(X, (ReadN(N) - ReadN(X)))
            Case &O5 ' x = x & n - Bitwise AND
                WriteN(X, (ReadN(N) And ReadN(X)))
            Case &O6 ' x = x XOR n - Bitwise exclusive OR
                WriteN(X, (ReadN(N) Xor ReadN(X)))
            Case &O7 ' Not Implemented
                MsgBox("un-impelmented instruction executed")
                '
                ' Group one - Answer in a register.
                '
            Case &O10   ' x = n
                WriteN(N, ReadN(X))
            Case &O11   ' x = N + X
                WriteNO(N, (ReadN(X) + ReadN(N)))
            Case &O12 ' x = - x             '
                WriteNO(N, (0 - ReadN(X)))
            Case &O13 ' x = n - x
                WriteNO(N, (ReadN(N) - ReadN(X)))
            Case &O14 ' x = x - n
                WriteNO(N, (ReadN(X) - ReadN(N)))
            Case &O15 ' x = n & X - Bitwise AND
                WriteN(N, (ReadN(N) And ReadN(X)))
            Case &O16 ' x = x XOR n - Bitwise exclusive OR
                WriteN(N, (ReadN(N) Xor ReadN(X)))
            Case &O17 ' Not Implemented
                '
                ' Group two - Multiply - Answer is always in 6 & 7
                ' So we need a 76-bit answer This is going to be fun
                '
            Case &O20 To &O22
                ' 20 = pq = x * n  
                ' 21 = pq = x * n (rounded)
                NegProd = False
                '
                ' Get memory address and split into two parts
                '
                XV = ReadN(X)
                '
                ' if -ve make +ve
                '
                If XV < 0 Then
                    XV = -XV
                    NegProd = True ' assume only this is -ve for now
                End If
                '
                ' Split into two parts
                '
                XH = XV >> 19
                XL = XV And &O1777777
                '
                ' Get register and split
                '
                NV = ReadN(N)
                If NV < 0 Then
                    NV = -NV
                    NegProd = Not NegProd ' Flip this
                End If
                NH = NV >> 19
                NL = NV And &O1777777
                If (XV = 0) And (NV = 0) Then
                    AL = 0
                    AH = 0
                Else
                    A1 = XL * NL
                    A2 = XL * NH
                    A3 = XH * NL
                    A4 = XH * NH
                    '
                    ' Now assemble the product
                    '
                    If Not NegProd Then
                        AL = (A1 + (A2 << 19) + (A3 << 19)) And &O3777777777777
                        AH = A4 + (A2 >> 19) + (A3 >> 19)
                    Else
                        AL = -((A1 + (A2 << 19) + (A3 << 19)) And &O3777777777777)
                        AH = -(A4 + (A2 >> 19) + (A3 >> 19))
                        If AH = 0 Then AH = -1
                    End If
                End If
                '
                ' 21 order rounds
                '
                If F = &O21 Then
                    AL = AL + &O2000000000000
                    If AL And &O400000000000 Then
                        AL = AL And &O3777777777777
                        AH = AH + 1
                    End If
                End If
                '
                ' 22 order sums Not sure if this is correct for -ve sums.....
                '
                If F = &O22 Then
                    AL = AL + ReadN(7)
                    AH = AH + ReadN(6)
                    If AL And &O3777777777777 <> 0 Then
                        AL = AL And &O3777777777777
                        AH = AH + 1
                    End If
                End If
                WriteNO(6, AH)
                WriteN(7, AL)
                MsgBox("High word = " & Oct(AH) & " Low Word =" & Oct(AL))

            Case &O23 ' Normalize q =  + e(q) + OVL
                '
                '     ovl     sign(c7)      Carry Required
                '    clear      +               0
                '    clear      -               -e
                '     set       +               -2e
                '     set       -               +e
                '
                '
                If Not OVR Then
                    '
                    ' OVR is clear - just need to subtract 1 from p if sign bit set q 
                    '
                    If Ord_Regs(7) And &O3777777777777 Then
                        WriteNO(6, Ord_Regs(6) - 1)
                    End If
                Else
                    '
                    ' overflow set 
                    '
                    OVR = False

                    If Ord_Regs(7) And &O3777777777777 Then
                        '
                        ' sign bit in X7 is set need to adjust
                        '
                        WriteNO(6, Ord_Regs(6) + 1)
                    Else
                        WriteNO(6, Ord_Regs(6) - 2)
                    End If

                End If
            Case &O24 ' Divide .....
                '
                ' X7 = P/Q
                ' X6 = Remainder
                '
                A1 = ReadN(N)
                A2 = ReadN(7)
                A3 = A1 / A2
                WriteN(7, A3)
                WriteN(6, A1 - (A2 * A3))

            Case &O25 'rounded divide
                WritePQ(0, (ReadN(N) And ReadN(X)))
            Case &O26 ' Fractional divide  
                WritePQ(0, (ReadN(N) Xor ReadN(X)))
            Case &O27 ' Not Implemented
                MsgBox("un-impelmented instruction executed")
                '
                ' Group Three - Unassigned
                '
            Case &O30 To &O36
                MsgBox("un-impelmented instruction executed")
                '
                ' Group Four - Immediate
                '
            Case &O40   ' x = N
                WriteN(X, N)
            Case &O41   ' x = N + X
                WriteNO(X, (ReadN(X) + N))
            Case &O42 ' x = - x             '
                WriteN(X, -N)
            Case &O43 ' x = n - x
                WriteNO(X, (ReadN(X) - N))
            Case &O44 ' x = x - n
                WriteNO(X, (N - ReadN(X)))
            Case &O45 ' x = n & X - Bitwise AND
                WriteN(X, (N And ReadN(X)))
            Case &O46 ' x = x XOR n - Bitwise exclusive OR
                WriteN(X, (N Xor ReadN(X)))
            Case &O47 ' Not Implemented
                MsgBox("un-impelmented instruction executed")
                '
                ' Group five - shifts 
                '
            Case &O50   ' Shift left arithmentic
                WriteNO(X, ReadN(X) << N)
            Case &O51   ' Shift Right arithmetic rounded
                WriteN(X, (ReadN(X) >> N))
            Case &O52 ' Shift Left Logical
                WriteN(X, (ReadN(X) << N))
            Case &O53 ' shift right logical
                WriteN(X, ((ReadN(X) And &HFFFFFFFFFF) >> N))
            Case &O54 ' Double length shifts
                WriteN(6, (ReadN(X) - ReadN(N)))
            Case &O55 ' double length un rounded
                WriteN(6, (ReadN(N) And ReadN(X)))
            Case &O56 ' rounded double shift
                WriteN(N, (ReadN(N) Xor ReadN(X)))
            Case &O57 ' Not Implemented
                MsgBox("un-impelmented instruction executed")
                '
                ' Group Six - Jumps
                '
            Case &O60   ' Junp if X=0
                If (ReadN(X) = 0) Then
                    Ord_Num_reg = N
                End If
            Case &O61   ' Jump if x <> 0
                If (ReadN(X) <> 0) Then
                    Ord_Num_reg = N
                End If
            Case &O62 ' Jump if x >= 0   
                If (ReadN(X) >= 0) Then
                    Ord_Num_reg = N
                End If
            Case &O63 ' jump if x < 0
                If (ReadN(X) < 0) Then
                    Ord_Num_reg = N
                End If
            Case &O64 ' Jump if overflow clear
                If Not OVR Then
                    Ord_Num_reg = N
                End If
                OVR = False
            Case &O65 ' Jump if overflow set and clear overflow
                If OVR Then
                    Ord_Num_reg = N
                End If
                OVR = False
            Case &O66 ' Unit Modify: Inrememnt modifier adn jump if Xp <> 0  
                WriteN(N, (ReadN(N) Xor ReadN(X)))
            Case &O67 ' Unit Modify: decrememnt modifier adn jump if  <> 0
                MsgBox("un-impelmented instruction executed")
                '
                '
                ' Group Seven Main Store Transfers
                '
            Case &O70   ' Read word from drum to X1
                WriteN(6, ReadN(X) * ReadN(N))
            Case &O71   ' write to drum from X1
                WriteN(6, (ReadN(X) + ReadN(N)))
            Case &O72 ' Block read from Drum        
                WriteN(6, (0 - ReadN(X)))
            Case &O73 ' Block write to drum
                WriteN(N, (ReadN(N) - ReadN(X)))
            Case &O74 ' select input/output device
                WriteN(N, (ReadN(X) - ReadN(N)))
            Case &O75
                MsgBox("un-impelmented instruction executed")
            Case &O76
                MsgBox("un-impelmented instruction executed")
            Case &O77 ' Stop
                MsgBox("Stop instruction executed")
                running = False
                '
                ''
                '
                '
            Case Else
                MsgBox("un-impelmented instruction executed")
        End Select
        ' MsgBox("Answers are " & ReadN(N) & " " & ReadN(X) & vbCr & "In Octal " & Oct(ReadN(N)) & " " & Oct(ReadN(X)))

    End Sub
End Class
