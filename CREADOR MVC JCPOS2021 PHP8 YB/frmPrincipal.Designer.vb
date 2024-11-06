<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuConfiguracion = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuGenerarCatalogo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAyuda = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuProcesos, Me.mnuAyuda})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(770, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuArchivo
        '
        Me.mnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuConfiguracion, Me.smnuSalir})
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.Size = New System.Drawing.Size(60, 20)
        Me.mnuArchivo.Text = "Archivo"
        '
        'smnuConfiguracion
        '
        Me.smnuConfiguracion.Name = "smnuConfiguracion"
        Me.smnuConfiguracion.Size = New System.Drawing.Size(150, 22)
        Me.smnuConfiguracion.Text = "Configuración"
        '
        'smnuSalir
        '
        Me.smnuSalir.Name = "smnuSalir"
        Me.smnuSalir.Size = New System.Drawing.Size(150, 22)
        Me.smnuSalir.Text = "Salir"
        '
        'mnuProcesos
        '
        Me.mnuProcesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuGenerarCatalogo})
        Me.mnuProcesos.Name = "mnuProcesos"
        Me.mnuProcesos.Size = New System.Drawing.Size(66, 20)
        Me.mnuProcesos.Text = "Procesos"
        '
        'smnuGenerarCatalogo
        '
        Me.smnuGenerarCatalogo.Name = "smnuGenerarCatalogo"
        Me.smnuGenerarCatalogo.Size = New System.Drawing.Size(180, 22)
        Me.smnuGenerarCatalogo.Text = "Generar Catalogo"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuAcercaDe})
        Me.mnuAyuda.Name = "mnuAyuda"
        Me.mnuAyuda.Size = New System.Drawing.Size(53, 20)
        Me.mnuAyuda.Text = "Ayuda"
        '
        'smnuAcercaDe
        '
        Me.smnuAcercaDe.Name = "smnuAcercaDe"
        Me.smnuAcercaDe.Size = New System.Drawing.Size(126, 22)
        Me.smnuAcercaDe.Text = "Acerca de"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnNuevo, Me.toolStripSeparator1, Me.btnAyuda})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(770, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(23, 22)
        Me.btnNuevo.Text = "&Nuevo"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "&Guardar"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnAyuda
        '
        Me.btnAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(23, 22)
        Me.btnAyuda.Text = "&Ayuda"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 435)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPrincipal"
        Me.Text = "Creador de Catalogos JCPOS2021"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuArchivo As ToolStripMenuItem
    Friend WithEvents smnuConfiguracion As ToolStripMenuItem
    Friend WithEvents smnuSalir As ToolStripMenuItem
    Friend WithEvents mnuProcesos As ToolStripMenuItem
    Friend WithEvents smnuGenerarCatalogo As ToolStripMenuItem
    Friend WithEvents mnuAyuda As ToolStripMenuItem
    Friend WithEvents smnuAcercaDe As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNuevo As ToolStripButton
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnAyuda As ToolStripButton
End Class
