<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblServidor = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.txtBaseDeDatos = New System.Windows.Forms.TextBox()
        Me.lblBaseDatos = New System.Windows.Forms.Label()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtContra = New System.Windows.Forms.TextBox()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnGuardar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelar, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(160, 159)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGuardar.Location = New System.Drawing.Point(4, 3)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(77, 27)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.Location = New System.Drawing.Point(89, 3)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 27)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = True
        Me.lblServidor.Location = New System.Drawing.Point(31, 31)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(53, 15)
        Me.lblServidor.TabIndex = 1
        Me.lblServidor.Text = "Servidor:"
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(121, 28)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(192, 23)
        Me.txtServidor.TabIndex = 2
        '
        'txtBaseDeDatos
        '
        Me.txtBaseDeDatos.Location = New System.Drawing.Point(121, 60)
        Me.txtBaseDeDatos.Name = "txtBaseDeDatos"
        Me.txtBaseDeDatos.Size = New System.Drawing.Size(192, 23)
        Me.txtBaseDeDatos.TabIndex = 4
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.AutoSize = True
        Me.lblBaseDatos.Location = New System.Drawing.Point(31, 63)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(84, 15)
        Me.lblBaseDatos.TabIndex = 3
        Me.lblBaseDatos.Text = "Base De Datos:"
        '
        'txtusuario
        '
        Me.txtusuario.Location = New System.Drawing.Point(121, 93)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(192, 23)
        Me.txtusuario.TabIndex = 6
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(31, 96)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(50, 15)
        Me.lblUsuario.TabIndex = 5
        Me.lblUsuario.Text = "Usuario:"
        '
        'txtContra
        '
        Me.txtContra.Location = New System.Drawing.Point(121, 128)
        Me.txtContra.Name = "txtContra"
        Me.txtContra.Size = New System.Drawing.Size(192, 23)
        Me.txtContra.TabIndex = 8
        Me.txtContra.UseSystemPasswordChar = True
        '
        'lblContraseña
        '
        Me.lblContraseña.AutoSize = True
        Me.lblContraseña.Location = New System.Drawing.Point(31, 131)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.Size = New System.Drawing.Size(70, 15)
        Me.lblContraseña.TabIndex = 7
        Me.lblContraseña.Text = "Contraseña:"
        '
        'frmConfiguracion
        '
        Me.AcceptButton = Me.btnGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(343, 204)
        Me.Controls.Add(Me.txtContra)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.txtBaseDeDatos)
        Me.Controls.Add(Me.lblBaseDatos)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.lblServidor)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfiguracion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConfiguracion"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblServidor As Label
    Friend WithEvents txtServidor As TextBox
    Friend WithEvents txtBaseDeDatos As TextBox
    Friend WithEvents lblBaseDatos As Label
    Friend WithEvents txtusuario As TextBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents txtContra As TextBox
    Friend WithEvents lblContraseña As Label
End Class
