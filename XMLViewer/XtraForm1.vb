Public Class XtraForm1
    Private Sub Close_Form(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Close_Form(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If Convert.ToInt32(e.KeyChar) = 13 Then
            Me.Close()
        End If
    End Sub
End Class