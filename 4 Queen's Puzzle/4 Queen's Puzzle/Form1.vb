Public Class _4QueensPuzzle
    Dim n As Integer = 4, qCnt As Integer
    Dim cells(n, n) As Button
    Dim R(n), C(n), D1(2 * n - 1), D2(2 * n - 1) As Boolean

    Private Sub _4QueensPuzzle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim m As Integer = n ^ 2, d As Integer = 2 * n - 1
        For i = 0 To m - 1
            Dim r As Integer = i \ n, c As Integer = i Mod n
            If i < 10 Then
                cells(r, c) = DirectCast(Controls.Find("cell0" & i, False).First, Button)
            Else
                cells(r, c) = DirectCast(Controls.Find("cell" & i, False).First, Button)
            End If
            cells(r, c).Enabled = False
            cells(r, c).Text = ""
        Next
        qCnt = 0
        For i = 0 To d - 1
            R(i \ 2) = True
            C(i \ 2) = True
            D1(i) = True
            D2(i) = True
        Next
        startBtn.Enabled = True
        restartBtn.Enabled = False
    End Sub

    Private Function IsAllOccupied(n As Integer, R() As Boolean, C() As Boolean, D1() As Boolean, D2() As Boolean)
        For i = 0 To n - 1
            For j = 0 To n - 1
                If R(i) And C(j) And D1((n - 1) + i - j) And D2(i + j) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Sub GameOver()
        For i = 0 To n - 1
            For j = 0 To n - 1
                cells(i, j).Enabled = False
            Next
        Next
        restartBtn.Enabled = True
    End Sub

    Private Sub button_Click(sender As Object, e As EventArgs) Handles cell15.Click, cell14.Click, cell13.Click, cell12.Click, cell11.Click, cell10.Click, cell09.Click, cell08.Click, cell07.Click, cell06.Click, cell05.Click, cell04.Click, cell03.Click, cell02.Click, cell01.Click, cell00.Click
        Dim cellName As String = CType(sender, Button).Name
        Dim cellNum As Integer = CType(cellName.Substring(4), Integer)
        Dim row As Integer = cellNum \ n, col = cellNum Mod n
        If R(row) And C(col) And D1((n - 1) + row - col) And D2(row + col) Then
            cells(row, col).Text = "Q"
            cells(row, col).Enabled = False
            qCnt += 1
            R(row) = False
            C(col) = False
            D1((n - 1) + row - col) = False
            D2(row + col) = False
            If qCnt = n Then
                GameOver()
                MessageBox.Show("Solved!")
            ElseIf IsAllOccupied(n, R, C, D1, D2) Then
                GameOver()
                MessageBox.Show("Game Over!")
            End If
        Else
            MessageBox.Show("Occupied")
        End If
    End Sub

    Private Sub startBtn_Click(sender As Object, e As EventArgs) Handles startBtn.Click
        For i = 0 To n - 1
            For j = 0 To n - 1
                cells(i, j).Enabled = True
            Next
        Next
        startBtn.Enabled = False
    End Sub

    Private Sub restartBtn_Click(sender As Object, e As EventArgs) Handles restartBtn.Click
        Dim d As Integer = 2 * n - 1
        For i = 0 To n - 1
            For j = 0 To n - 1
                cells(i, j).Text = ""
            Next
        Next
        For i = 0 To d - 1
            R(i \ 2) = True
            C(i \ 2) = True
            D1(i) = True
            D2(i) = True
        Next
        qCnt = 0
        startBtn.Enabled = True
        restartBtn.Enabled = False
    End Sub
End Class
