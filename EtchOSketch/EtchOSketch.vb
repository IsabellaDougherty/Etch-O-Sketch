'Isabella Dougherty
'RCET0265
'Spring 2023
'Etch-O-Sketch
'https://github.com/IsabellaDougherty/Etch-O-Sketch.git

Option Explicit On

Public Class EtchOSketch
    Dim currentColor As Color = New Color
    Private Sub EtchOSketch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentColor = Color.Black
    End Sub

    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove, PictureBox.MouseDown
        Static lastX%, lastY%
        Select Case e.Button.ToString
            Case "Left"
                DrawLineSegment(lastX, lastY, e.X, e.Y)
            Case "Middle"
                selectColor()
        End Select
        Me.Text = $"({e.X},{e.Y}) button: {e.Button.ToString} Color: {Me.currentColor.ToString}"
        lastX = e.X
        lastY = e.Y
    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click
        selectColor()
    End Sub

    Private Sub DrawWaveformsButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click
        waveDraw()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        PictureBox.Refresh()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Dim yesNo As Integer
        yesNo = MsgBox(“Are you sure you would like to quit?”, vbQuestion + vbYesNo + vbDefaultButton2, “Exit Menu”)
        If yesNo = vbYes Then
            End
        End If
    End Sub

    Private Sub DrawWaveformsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawWaveformsToolStripMenuItem.Click
        waveDraw()
    End Sub

    Private Sub SelectColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click
        selectColor()
    End Sub

    Sub DrawLineSegment(x1%, y1%, x2%, y2%)
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As Pen = New Pen(Me.currentColor)
        g.DrawLine(Pen, x1, y1, x2, y2)
        Pen.Dispose()
        g.Dispose()
    End Sub

    Sub waveDraw()

    End Sub

    Sub selectColor()
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        PictureBox.Refresh()
    End Sub
End Class
