Imports System.Windows.Forms

Public Class frmConfiguracion

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click


        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "servidor", Me.txtServidor.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "baseDeDatos", Me.txtBaseDeDatos.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "usuario", Me.txtusuario.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "contra", Me.txtContra.Text)

        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "servidor", Nothing) Is Nothing Then

            Me.txtServidor.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "servidor", Nothing).ToString()
            Me.txtBaseDeDatos.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "baseDeDatos", Nothing).ToString()
            Me.txtusuario.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "usuario", Nothing).ToString()
            Me.txtContra.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "contra", Nothing).ToString()

        End If

    End Sub
End Class
