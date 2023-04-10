'Isabella Dougherty
'RCET0265
'Spring 2023
'Etch-O-Sketch
'https://github.com/IsabellaDougherty/Etch-O-Sketch.git

Option Explicit On

Public Class EtchOSketch
    Dim currentColor As Color = New Color
    Dim shake As New Point(20, 35)
    Dim unshake As New Point(12, 27)
    Dim sound As Boolean
    Private Sub EtchOSketch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentColor = Color.Black
        SoundCheckBox.Checked = False
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
        PictureBox.Location = shake
        sound = SoundCheckBox.Checked
        If sound Then
            Try
                My.Computer.Audio.Play(My.Resources.Shaker_Sound)
            Catch ex As Exception
            End Try
        End If

        System.Threading.Thread.Sleep(250)
        PictureBox.Location = unshake
        For i = 0 To 7
            System.Threading.Thread.Sleep(250)
            PictureBox.Location = shake
            System.Threading.Thread.Sleep(250)
            PictureBox.Location = unshake
        Next

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
        Dim x As Double
        Dim y As Double
        Dim wavePen As New Pen(Color.Black, 3)
        Dim g As Graphics = PictureBox.CreateGraphics

        ClearButton.PerformClick()

        'draw a center line in the wave
        wavePen = New Pen(Color.Black, 1)
        For r = 1 To 10
            g.DrawLine(wavePen, CType(77.6 * r, Single), CType(0, Single), CType(77.6 * r, Single), CType(326, Single))
        Next
        For r = 1 To 10
            g.DrawLine(wavePen, CType(0, Single), CType(32.6 * r, Single), CType(776, Single), CType(32.6 * r, Single))
        Next

        For r As Double = 0 To 776
            wavePen = New Pen(Color.Black, 3)
            y = Math.Sin(r / 776 * 2 * Math.PI) * 100 + 150
            x = r
            g.DrawLine(wavePen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))

            wavePen = New Pen(Color.Blue, 3)
            y = Math.Cos(r / 776 * 2 * Math.PI) * 100 + 150
            x = r
            g.DrawLine(wavePen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))

            wavePen = New Pen(Color.DarkRed, 3)
            y = Math.Tan(r / 776 * 2 * Math.PI) * 100 + 150
            'x = r
            If y > 362 Then
            Else
                x = -r + 776
                g.DrawLine(wavePen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))
            End If

        Next
    End Sub

    Sub selectColor()
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ClearButton.PerformClick()
    End Sub

    Sub shakeSound()
        Try
            My.Computer.Audio.Play("C:\Users\bella\Downloads\chajchas-91758.wav",
            AudioPlayMode.WaitToComplete)
        Catch ex As Exception
        End Try
    End Sub
End Class
