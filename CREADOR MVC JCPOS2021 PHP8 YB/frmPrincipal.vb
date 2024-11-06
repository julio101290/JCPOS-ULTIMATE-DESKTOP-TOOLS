

Public Class frmPrincipal
    Private Sub smnuAcercaDe_Click(sender As Object, e As EventArgs) Handles smnuAcercaDe.Click

        ' Con esta sentencia se decimos que se ejecute dentro de la ventana principal
        frmAcercaDe.MdiParent = Me

        ' Con esta sentencia lanzamos la ventana
        frmAcercaDe.Show()


    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub smnuConfiguracion_Click(sender As Object, e As EventArgs) Handles smnuConfiguracion.Click

        frmConfiguracion.MdiParent = Me

        frmConfiguracion.Show()




    End Sub

    Private Sub smnuGenerarCatalogo_Click(sender As Object, e As EventArgs) Handles smnuGenerarCatalogo.Click

        frmCreaCatalogo.MdiParent = Me

        frmCreaCatalogo.Show()



    End Sub

    Private Sub PruebaToolStripMenuItem_Click(sender As Object, e As EventArgs) 



    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        frmConfiguracion.MdiParent = Me

        frmConfiguracion.Show()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        frmCreaCatalogo.MdiParent = Me

        frmCreaCatalogo.Show()

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        ' Con esta sentencia se decimos que se ejecute dentro de la ventana principal
        frmAcercaDe.MdiParent = Me

        ' Con esta sentencia lanzamos la ventana
        frmAcercaDe.Show()

    End Sub
End Class
