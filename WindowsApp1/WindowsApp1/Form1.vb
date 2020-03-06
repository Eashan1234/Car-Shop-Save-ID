Public Class Form1
    Dim i As Integer
    Dim ExteriorColors(6) As RadioButton
    Dim InteriorColors(3) As RadioButton
    Dim Packages(4) As CheckBox
    Dim Features(8) As CheckBox
    Dim MixedColor(3) As RadioButton
    Dim Wheel(3) As RadioButton
    Dim FileD As String
    Dim NumEntries As Integer
    Dim numEx As Integer
    Dim numIn As Integer
    Dim numPcg(4) As Integer
    Dim numFe(8) As Integer
    Dim numWh As Integer
    Dim numMI As Integer
    Dim Switch As Boolean
    Dim delete As Boolean

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Switch = True
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Luxury")
        ComboBox1.Items.Add("Sport")
        ComboBox1.Items.Add("Family")

        ComboBox2.Items.Add("Mercades")
        ComboBox2.Items.Add("Toyota")
        ComboBox2.Items.Add("Honda")
        ComboBox2.Items.Add("Infiniti")
        ComboBox2.Items.Add("BMW")
        ComboBox2.Items.Add("Chevy")
        ComboBox2.Items.Add("Lambhorgini")
        ComboBox2.Items.Add("Ferrari")
        ComboBox2.Items.Add("Nissan")
        ComboBox2.Items.Add("Tesla")

        ComboBox3.Items.Add("Sedan")
        ComboBox3.Items.Add("Truck")
        ComboBox3.Items.Add("Sport Utility")
        ComboBox3.Items.Add("Coupe")
        ComboBox3.Items.Add("Hatchback")
        ComboBox3.Items.Add("Convertable")
        ComboBox3.Items.Add("Minivan")
        ComboBox3.Items.Add("Limousine")

        ComboBox2.Text = "Select Car Brand"
        ComboBox3.Text = "Select Body Type"
        ComboBox1.Text = "Select Car Category"
        ControlArray()

    End Sub

    Private Sub Generate_Click(sender As Object, e As EventArgs) Handles Generate.Click
        GenerateFun()
    End Sub

    Public Sub GenerateFun()
        For i = 0 To 5
            If (ExteriorColors(i).Checked) Then
                numEx = i
            End If
        Next

        For i = 0 To 3
            If (Packages(i).Checked) Then
                numPcg(i) = 1
            Else
                numPcg(i) = 0
            End If
        Next

        For i = 0 To 2
            If MixedColor(i).Checked Then
                numMI = i
            End If

            If Wheel(i).Checked Then
                numWh = i
            End If

            If (InteriorColors(i).Checked) Then
                numIn = i
            End If
        Next

        For i = 0 To 7
            If (Features(i).Checked) Then
                numFe(i) = 1
            Else
                numFe(i) = 0
            End If
        Next
        ListBox1.Items.Add((ComboBox1.SelectedIndex + 1).ToString + (ComboBox2.SelectedIndex + 1).ToString + (ComboBox3.SelectedIndex + 1).ToString + (ComboBox4.SelectedIndex + 1).ToString + (numPcg(0).ToString) + (numPcg(1).ToString) + (numPcg(2).ToString) + (numPcg(3).ToString) + (numFe(0).ToString) + (numFe(1).ToString) + (numFe(2).ToString) + (numFe(3).ToString) + (numFe(4).ToString) + (numFe(5).ToString) + (numFe(6).ToString) + (numFe(7).ToString) + (numEx + 1).ToString + (numIn + 1).ToString + (numMI + 1).ToString + (numWh + 1).ToString)
        NumEntries += 1
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ControlArray()
        ExteriorColors(0) = RadioButton1
        ExteriorColors(1) = RadioButton2
        ExteriorColors(2) = RadioButton3
        ExteriorColors(3) = RadioButton4
        ExteriorColors(4) = RadioButton5
        ExteriorColors(5) = RadioButton6

        InteriorColors(0) = RadioButton12
        InteriorColors(1) = RadioButton10
        InteriorColors(2) = RadioButton8

        MixedColor(0) = RadioButton17
        MixedColor(1) = RadioButton15
        MixedColor(2) = RadioButton13

        Wheel(0) = RadioButton21
        Wheel(1) = RadioButton19
        Wheel(2) = RadioButton14

        Packages(0) = CheckBox8
        Packages(1) = CheckBox7
        Packages(2) = CheckBox6
        Packages(3) = CheckBox13

        Features(0) = CheckBox1
        Features(1) = CheckBox2
        Features(2) = CheckBox3
        Features(3) = CheckBox4
        Features(4) = CheckBox9
        Features(5) = CheckBox10
        Features(6) = CheckBox11
        Features(7) = CheckBox12
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        FileD = "C:\Data\CP2\Inventory.txt"

        FileOpen(1, FileD, OpenMode.Output)
        For i = 0 To (NumEntries - 1)
            PrintLine(1, ListBox1.Items(i))
        Next
        MsgBox("File Successfully Saved!")
        FileClose()
    End Sub

    Private Sub RetrieveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetrieveToolStripMenuItem.Click
        Dim FileLen As Integer
        FileD = "C:\Data\CP2\Inventory.txt"
        i = 0

        FileOpen(1, FileD, OpenMode.Input)


        Dim RetrieveArr(10) As String

        Do Until EOF(1)
            RetrieveArr(i) = LineInput(1)
            i = i + 1
        Loop

        FileLen = i

        Dialog1.ShowDialog()

        If Dialog1.DialogResult = DialogResult.Cancel Then
            For i = 0 To (FileLen - 1)
                ListBox1.Items.Add(RetrieveArr(i))
                NumEntries += 1
            Next
        ElseIf Dialog1.DialogResult = DialogResult.OK Then
            ListBox1.Items.Clear()
            For i = 0 To (FileLen - 1)
                ListBox1.Items.Add(RetrieveArr(i))
                NumEntries += 1
            Next
        End If

        FileClose()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        delete = True
        Select Case MsgBox("Are you sure you want to premenantly remove this record?", MsgBoxStyle.YesNoCancel)
            Case MsgBoxResult.Yes
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            Case MsgBoxResult.Cancel
                Return
            Case MsgBoxResult.No
                Return
        End Select
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Switch Then
            If (delete <> True) Then
                If ListBox1.SelectedItem Is Nothing Then
                    MsgBox("You are not clicking on an item!")
                    Return
                End If

                Debug.Print(CInt(Mid(ListBox1.SelectedItem, 2, 1)) - 1)

                ComboBox1.SelectedIndex = CInt(Mid(ListBox1.SelectedItem, 1, 1)) - 1
                ComboBox2.SelectedIndex = CInt(Mid(ListBox1.SelectedItem, 2, 1)) - 1
                ComboBox3.SelectedIndex = CInt(Mid(ListBox1.SelectedItem, 3, 1)) - 1
                ComboBox4.SelectedIndex = CInt(Mid(ListBox1.SelectedItem, 4, 1)) - 1

                ExteriorColors(CInt(Mid(ListBox1.SelectedItem, 17, 1)) - 1).Checked = True

                InteriorColors(CInt(Mid(ListBox1.SelectedItem, 18, 1)) - 1).Checked = True

                MixedColor(CInt(Mid(ListBox1.SelectedItem, 19, 1)) - 1).Checked = True

                Wheel(CInt(Mid(ListBox1.SelectedItem, 20, 1)) - 1).Checked = True

                For i = 4 To 7
                    If CInt(Mid(ListBox1.SelectedItem, i + 1, 1)) = 1 Then
                        Packages(i - 4).Checked = True
                    Else
                        Packages(i - 4).Checked = False
                    End If
                Next i

                For i = 8 To 15
                    If CInt(Mid(ListBox1.SelectedItem, i + 1, 1)) = 1 Then
                        Features(i - 8).Checked = True
                    Else
                        Features(i - 8).Checked = False
                    End If
                Next
            End If
        End If
        delete = False
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox4.Items.Clear()

        If (ComboBox2.SelectedIndex = 0) Then
            PictureBox1.BackgroundImage = ImageList1.Images(0)
            ComboBox4.Items.Add("S-Class")
            ComboBox4.Items.Add("AMG C Class")
            ComboBox4.Items.Add("C 300 Formatic")
        ElseIf (ComboBox2.SelectedIndex = 1) Then
            PictureBox1.BackgroundImage = ImageList1.Images(1)
            ComboBox4.Items.Add("RAV-4")
            ComboBox4.Items.Add("Camery")
            ComboBox4.Items.Add("Highlander")
        ElseIf (ComboBox2.SelectedIndex = 2) Then
            PictureBox1.BackgroundImage = ImageList1.Images(2)
            ComboBox4.Items.Add("Accord")
            ComboBox4.Items.Add("Odessey")
            ComboBox4.Items.Add("CRV")
        ElseIf (ComboBox2.SelectedIndex = 3) Then
            PictureBox1.BackgroundImage = ImageList1.Images(3)
            ComboBox4.Items.Add("QX50")
            ComboBox4.Items.Add("Q50")
            ComboBox4.Items.Add("QX60")
        ElseIf (ComboBox2.SelectedIndex = 4) Then
            PictureBox1.BackgroundImage = ImageList1.Images(4)
            ComboBox4.Items.Add("X4")
            ComboBox4.Items.Add("X5")
            ComboBox4.Items.Add("X6")
        ElseIf (ComboBox2.SelectedIndex = 5) Then
            PictureBox1.BackgroundImage = ImageList1.Images(5)
            ComboBox4.Items.Add("Corvette")
            ComboBox4.Items.Add("Camero")
            ComboBox4.Items.Add("Spark")
        ElseIf (ComboBox2.SelectedIndex = 6) Then
            PictureBox1.BackgroundImage = ImageList1.Images(6)
            ComboBox4.Items.Add("Urus")
            ComboBox4.Items.Add("Centanario")
            ComboBox4.Items.Add("Aventador")
        ElseIf (ComboBox2.SelectedIndex = 7) Then
            PictureBox1.BackgroundImage = ImageList1.Images(7)
            ComboBox4.Items.Add("SuperFast")
            ComboBox4.Items.Add("GTC-Lusso")
            ComboBox4.Items.Add("California")
        ElseIf (ComboBox2.SelectedIndex = 8) Then
            PictureBox1.BackgroundImage = ImageList1.Images(8)
            ComboBox4.Items.Add("Frontier")
            ComboBox4.Items.Add("Ultima")
            ComboBox4.Items.Add("Murano")
        ElseIf (ComboBox2.SelectedIndex = 9) Then
            PictureBox1.BackgroundImage = ImageList1.Images(9)
            ComboBox4.Items.Add("Model X")
            ComboBox4.Items.Add("Roadster")
            ComboBox4.Items.Add("Model 3")
        End If
    End Sub

    Private Sub ChangeBtn_Click(sender As Object, e As EventArgs) Handles ChangeBtn.Click
        Switch = False
        If ListBox1.SelectedItem Is Nothing Then
            MsgBox("You are not clicking on an item!")
            Return
        End If
        Dim index As Integer = ListBox1.SelectedIndex
        ListBox1.Items.RemoveAt(index)
        GenerateFun()
        Switch = True
    End Sub
End Class
