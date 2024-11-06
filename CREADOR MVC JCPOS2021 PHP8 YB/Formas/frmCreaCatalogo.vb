Imports System.Windows.Forms

Public Class frmCreaCatalogo

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim strModelo As String
        Dim strControlador As String
        Dim strVista As String

        'Guardamos en el registro de windows la variable de txtTabla
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "txtTabla", Me.txtTabla.Text)

        'Guardamos en el registro de windows la variable de txtTabla
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "txtRuta", Me.txtRuta.Text)


        strModelo = crearModelo.generaModelo()
        strControlador = crearControlador.generaControlador()
        strVista = crearVista.generarVista()

        ' Instrucción para guardar el texto del modelo en un archivo
        My.Computer.FileSystem.WriteAllText(Me.txtRuta.Text & "/modelos/" & txtTabla.Text & ".modelo.php", strModelo, False, System.Text.Encoding.ASCII)

        ' Instrucción para guardar el texto del modelo en un archivo
        My.Computer.FileSystem.WriteAllText(Me.txtRuta.Text & "/controladores/" & txtTabla.Text & ".controlador.php", strControlador, False, System.Text.Encoding.ASCII)

        ' Instrucción para guardar el texto del modelo en un archivo
        My.Computer.FileSystem.WriteAllText(Me.txtRuta.Text & "/vistas/modulos/" & txtTabla.Text & ".php", strVista, False, System.Text.Encoding.ASCII)


        MessageBox.Show("Guardado Correctamente")

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnRuta_Click(sender As Object, e As EventArgs) Handles btnRuta.Click

        dlgRuta.ShowDialog()

        txtRuta.Text = dlgRuta.SelectedPath


    End Sub

    Private Sub frmCreaCatalogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Leemos la variable por default de la tabla desde el registro de windows
        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "txtTabla", Nothing) Is Nothing Then

            Me.txtTabla.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "txtTabla", Nothing).ToString()

        End If

        'Leemos la variable por default de la tabla desde el registro de windows
        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "txtRuta", Nothing) Is Nothing Then

            Me.txtRuta.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "txtRuta", Nothing).ToString()

        End If



    End Sub
End Class
