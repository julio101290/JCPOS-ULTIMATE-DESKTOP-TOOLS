'IMPORTAMOS LAS LIBRERIAS NECESARIAS PARA LA CONEXIÓN A MYSQL/MARIADB
Imports MySqlConnector.MySqlConnection

'EMPIEZA EL MODULO
Module crearVista

    ' CON PUBLIC SUB CREAMOS PROCEDIMIENTOS
    Public Function generarVista() As String

        ' VARIABLES PARA LA CONEXIÓN
        Dim strServidor As String
        Dim strBaseDeDatos As String
        Dim strUsuario As String
        Dim strContra As String

        'Variables de uso
        Dim contador As Integer
        Dim strEncabezadosTabla As String
        Dim strCampos As String
        Dim strControlesNuevos As String
        Dim strControlesEditar As String
        Dim strEditarJS As String
        Dim strBloquear As String
        Dim strEditarTraeDatos As String
        Dim strDatos As String
        Dim strLLavePrimaria As String
        Dim strVista As String
        Dim strSegundoCampo As String

        contador = 0
        strEncabezadosTabla = ""
        strCampos = ""
        strControlesNuevos = ""
        strEditarJS = ""
        strDatos = ""

        'OBTENEMOS LOS DATOS DE CONFIGURACIÖN DEL REGISTRO DE WINDOWS PREVIAMENTE GUARDADAS
        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "servidor", Nothing) Is Nothing Then
            strServidor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "servidor", Nothing).ToString()
            strBaseDeDatos = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "baseDeDatos", Nothing).ToString()
            strUsuario = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "usuario", Nothing).ToString()
            strContra = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CREADORMVCPHP", "contra", Nothing).ToString()
        Else

            MsgBox("No se han capturado la conexión a la base de datos")
            Exit Function


        End If


        ' METEMOS LA CADENA DE CONEXIÓN EN UNA VARIABLE
        Dim cadenaConexion = "Server=" & strServidor & ";User ID=" & strUsuario & ";Password=" & strContra & ";Database=" & strBaseDeDatos

        ' CREAMOS LA CONEXIÓN CON LA CADENA DE CONEXIÓN
        Dim connection = New MySqlConnector.MySqlConnection(cadenaConexion)

        Try


            connection.Open()
            Dim comando = New MySqlConnector.MySqlCommand("delete from clases where clase= 'controladores/" & frmCreaCatalogo.txtTabla.Text & ".controlador.php'", connection)
            Dim resultado = comando.ExecuteReader()
            comando = Nothing
            resultado = Nothing
            connection.Close()



            connection.Open()
            comando = New MySqlConnector.MySqlCommand("delete from clases where clase= 'modelos/" & frmCreaCatalogo.txtTabla.Text & ".modelo.php'", connection)
            resultado = comando.ExecuteReader()
            comando = Nothing
            resultado = Nothing
            connection.Close()

            connection.Open()
            comando = New MySqlConnector.MySqlCommand("insert into clases(clase) values('controladores/" & frmCreaCatalogo.txtTabla.Text & ".controlador.php')", connection)
            resultado = comando.ExecuteReader()
            comando = Nothing
            resultado = Nothing
            connection.Close()

            connection.Open()
            comando = New MySqlConnector.MySqlCommand("insert into clases(clase) values( 'modelos/" & frmCreaCatalogo.txtTabla.Text & ".modelo.php')", connection)
            resultado = comando.ExecuteReader()
            comando = Nothing
            resultado = Nothing
            connection.Close()

            ' SI SE ABRE LA CONEXIÓN MANDAMOS MENSAJE
            connection.Open()




            comando = New MySqlConnector.MySqlCommand("SHOW KEYS FROM  " & frmCreaCatalogo.txtTabla.Text & " WHERE Key_name = 'PRIMARY'", connection)

            resultado = comando.ExecuteReader

            resultado.Read()


            'ASIGNAMOS EL CAMPO LLAVE

            strLLavePrimaria = resultado.GetString("Column_name")


            'OBTENEMOS LOS CAMPOS DE LA TABLA
            connection.Close()
            connection.Open()
            comando = Nothing
            comando = New MySqlConnector.MySqlCommand("describe  " & frmCreaCatalogo.txtTabla.Text & "", connection)
            resultado = Nothing
            resultado = comando.ExecuteReader



            contador = 0


            While (resultado.Read)
                strEncabezadosTabla &= "<th>" & utilerias.strPrimeraMayuscula(resultado("Field")) & "</th>" & vbCrLf

                strCampos &= "<td>'.$value[""" & resultado("Field") & """].'</td>" & vbCrLf

                If contador > 0 Then

                    strControlesNuevos &= "" & "            <!-- ENTRADA PARA " & UCase(resultado("Field")) & " --> " & vbCrLf
                    strControlesNuevos &= "" & " " & vbCrLf
                    strControlesNuevos &= "" & "            <div class=""form-group""> " & vbCrLf
                    strControlesNuevos &= "" & " " & vbCrLf
                    strControlesNuevos &= "" & "              <div class=""input-group""> " & vbCrLf
                    strControlesNuevos &= "" & " " & vbCrLf
                    strControlesNuevos &= "" & "                <span class=""input-group-addon"">" & utilerias.strPrimeraMayuscula(resultado("Field")) & ": </span>  " & vbCrLf
                    strControlesNuevos &= "" & " " & vbCrLf
                    strControlesNuevos &= "" & "                <input type=""text"" class=""form-control input-lg"" name=""nuevo" & utilerias.strPrimeraMayuscula(resultado("Field")) & """ placeholder=""Ingresar " & utilerias.strPrimeraMayuscula(resultado("Field")) & """ required> " & vbCrLf
                    strControlesNuevos &= "" & " " & vbCrLf
                    strControlesNuevos &= "" & "              </div> " & vbCrLf
                    strControlesNuevos &= "" & " " & vbCrLf
                    strControlesNuevos &= "" & "            </div> " & vbCrLf

                    strEditarJS &= "" & "            $(""#editarDescripcion"").val(respuesta[""descripcion""]);" & vbCrLf

                End If


                If resultado("Key") = "PRI" Then
                    strBloquear = "readonly"
                Else
                    strBloquear = ""
                End If



                strControlesEditar &= "" & "            <!-- ENTRADA PARA " & UCase(resultado("Field")) & " --> " & vbCrLf
                strControlesEditar &= "" & " " & vbCrLf
                strControlesEditar &= "" & "            <div class=""form-group""> " & vbCrLf
                strControlesEditar &= "" & " " & vbCrLf
                strControlesEditar &= "" & "              <div class=""input-group""> " & vbCrLf
                strControlesEditar &= "" & " " & vbCrLf
                strControlesEditar &= "" & "                <span class=""input-group-addon"">" & utilerias.strPrimeraMayuscula(resultado("Field")) & ": </span>  " & vbCrLf
                strControlesEditar &= "" & " " & vbCrLf
                strControlesEditar &= "" & "                <input " & strBloquear & "  type=""text"" class=""form-control input-lg"" id=""editar" & utilerias.strPrimeraMayuscula(resultado("Field")) & """ name=""editar" & utilerias.strPrimeraMayuscula(resultado("Field")) & """ placeholder=""Ingresar " & utilerias.strPrimeraMayuscula(resultado("Field")) & """ required> " & vbCrLf
                strControlesEditar &= "" & " " & vbCrLf
                strControlesEditar &= "" & "              </div> " & vbCrLf
                strControlesEditar &= "" & " " & vbCrLf
                strControlesEditar &= "" & "            </div> " & vbCrLf

                strEditarTraeDatos &= "" & "            $(""#editar" & utilerias.strPrimeraMayuscula(resultado("Field")) & """).val(respuesta[""" & resultado("Field") & """]); " & vbCrLf

                contador = contador + 1

            End While


            strControlesEditar &= "" & " <input type=""hidden"" id=""editar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """  name = ""editar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """ > " & vbCrLf
            strEncabezadosTabla &= "<th>Acciones</th>"
            strCampos &= "<td> " & vbCrLf
            strCampos &= "<div class = ""btn-group""> " & vbCrLf



            strCampos &= "                    <button class= ""btn btn-warning btnEditar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """ id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & " = ""'.$value[""id""].'"" data-toggle = ""modal"" data-target = ""#modalEditar" & Trim(utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text)) & """> <i class = ""fa fa-pencil""> </i> </button> " & vbCrLf

            strCampos &= "<button class = ""btn btn-danger btnEliminar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """ id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "= ""'.$value[""id""].'""><i class= ""fa fa-times""></i></button>" & vbCrLf

            strCampos &= "</div>" & vbCrLf

            strCampos &= "</td> " & vbCrLf

            strVista &= "" & "<?php" & vbCrLf
            strVista &= "" & vbCrLf
            strVista &= "" & "if(""off"" == ""offf""){" & vbCrLf
            strVista &= "" & vbCrLf
            strVista &= "" & "  echo '<script>" & vbCrLf
            strVista &= "" & vbCrLf
            strVista &= "" & "    window.location = ""inicio""; " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  </script>'; " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  return; " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "} " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "?> " & vbCrLf
            strVista &= "" & "<div class=""content-wrapper"">" & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  <section class=""content-header"">" & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    <h1> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      Administrar <?php echo  mb_strtolower(preg_replace('/(?<=\\w)(\\p{Lu})/u', ' $1', ' " & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & " ')); ?> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    </h1> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    <ol class=""breadcrumb""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      <li><a href=""inicio""><i class=""fa fa-dashboard""></i> Inicio</a></li> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      <li class=""active"">Administrar <?php echo  mb_strtolower(preg_replace('/(?<=\\w)(\\p{Lu})/u', ' $1', '" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & " ')); ?></li> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    </ol> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  </section> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  <section class=""content""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    <div class=""box""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      <div class=""box-header With-border""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <button class=""btn btn-primary"" data-toggle=""modal"" data-target=""#modalAgregar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          Agregar <?php echo  mb_strtolower(preg_replace('/(?<=\\w)(\\p{Lu})/u', ' $1', '" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & " ')); ?> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        </button> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      <div class=""box-body""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "       <table class=""table table-bordered table-striped dt-responsive tablas"" width=""100%""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <thead> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "         <tr> " & vbCrLf
            strVista &= "" & " " & strEncabezadosTabla
            strVista &= "" & "         </tr>  " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        </thead> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <tbody> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <?php " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        $item = null; " & vbCrLf
            strVista &= "" & "        $valor = null; " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        $" & frmCreaCatalogo.txtTabla.Text & "= Controlador" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "::ctrMostrar($item, $valor); " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "       foreach ($" & frmCreaCatalogo.txtTabla.Text & " as $key => $value){ " & vbCrLf
            strVista &= "" & " " & vbCrLf



            strVista &= "" & "          echo ' <tr> " & vbCrLf

            strVista &= "" & strCampos & vbCrLf

            strVista &= "" & " " & vbCrLf
            strVista &= "" & "                </tr>'; " & vbCrLf
            strVista &= "" & "        } " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        ?>  " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        </tbody> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "       </table> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  </section> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "</div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "<!--===================================== " & vbCrLf
            strVista &= "" & "MODAL <?php echo  mb_strtolower(preg_replace('/(?<=\\w)(\\p{Lu})/u', ' $1', ' " & (frmCreaCatalogo.txtTabla.Text) & " ')); ?> " & vbCrLf
            strVista &= "" & " ======================================--> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "<div id=""modalAgregar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """ class=""modal fade"" role=""dialog""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  <div class=""modal-dialog""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    <div class=""modal-content""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      <form role=""form"" method=""post"" enctype=""multipart/form-data""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <!--===================================== " & vbCrLf
            strVista &= "" & "        CABEZA DEL MODAL " & vbCrLf
            strVista &= "" & "        ======================================--> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <div class=""modal-header"" style=""background:#3c8dbc; color:white"" > " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <h4 class=""modal-title"">Agregar <?php echo  mb_strtolower(preg_replace('/(?<=\\w)(\\p{Lu})/u', ' $1', ' " & (frmCreaCatalogo.txtTabla.Text) & " ')); ?> </h4> " & vbCrLf
            strVista &= "" & " " & vbCrLf

            strVista &= "" & "        </div> " & vbCrLf

            strVista &= "" & "        <!--===================================== " & vbCrLf
            strVista &= "" & "        CUERPO DEL MODAL " & vbCrLf
            strVista &= "" & "        ======================================--> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <div class=""modal-body""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <div class=""box-body""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "            <!-- ENTRADA PARA DESCRIPCION --> " & vbCrLf

            strVista &= "" & " " & strControlesNuevos & vbCrLf


            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <!--===================================== " & vbCrLf
            strVista &= "" & "        PIE DEL MODAL " & vbCrLf
            strVista &= "" & "        ====================================== --> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <div class=""modal-footer""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <button type=""button"" class=""btn btn-Default pull-left"" data-dismiss=""modal"">Salir</button> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <button type=""submit"" class=""btn btn-primary"">Guardar</button> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <?php " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "           $crear = new Controlador" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "(); " & vbCrLf
            strVista &= "" & "           $crear ->ctrIngresar(); " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        ?> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      </form> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "</div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "<!--===================================== " & vbCrLf
            strVista &= "" & "MODAL EDITAR USUARIO " & vbCrLf
            strVista &= "" & " ======================================--> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "<div id=""modalEditar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """ class=""modal fade"" role=""dialog"">" & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  <div class=""modal-dialog""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    <div class=""modal-content""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      <form role=""form"" method=""post"" enctype=""multipart/form-data""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <!--===================================== " & vbCrLf
            strVista &= "" & "        CABEZA DEL MODAL " & vbCrLf
            strVista &= "" & "        ======================================--> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <div class=""modal-header"" style=""background:#3c8dbc; color:white"" > " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <h4 class=""modal-title"">Agregar <?php echo  mb_strtolower(preg_replace('/(?<=\\w)(\\p{Lu})/u', ' $1', ' " & (frmCreaCatalogo.txtTabla.Text) & " ')); ?> </h4> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <!--===================================== " & vbCrLf
            strVista &= "" & "        CUERPO DEL MODAL " & vbCrLf
            strVista &= "" & "        ======================================--> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <div class=""modal-body""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <div class=""box-body""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "            <!-- ENTRADA PARA DESCRIPCION --> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & strControlesEditar
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <!--===================================== " & vbCrLf
            strVista &= "" & "        PIE DEL MODAL " & vbCrLf
            strVista &= "" & "        ======================================--> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        <div class=""modal-footer""> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <button type=""button"" class=""btn btn-Default pull-left"" data-dismiss=""modal"">Salir</button> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "          <button type=""submit"" class=""btn btn-primary"">Modificar</button> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "     <?php " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "           $editar = new Controlador" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "(); " & vbCrLf
            strVista &= "" & "           $editar ->ctrEditar(); " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "        ?>  " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "      </form> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "    </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "  </div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "</div> " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "<?php " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "   $borrar = new Controlador" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "(); " & vbCrLf
            strVista &= "" & "   $borrar ->ctrBorrar(); " & vbCrLf
            strVista &= "" & " " & vbCrLf
            strVista &= "" & "?>  " & vbCrLf

            'JAVASCRIPT FUNCIONES
            strVista &= "" & "<script type=""text/javascript"">" & vbCrLf

            'ELIMINAR


            strVista &= "" & "/*= == == == == == == == == == == == == == == == == == == == == == ==" & vbCrLf
            strVista &= "" & " ELIMINAR " & UCase(frmCreaCatalogo.txtTabla.Text) & vbCrLf
            strVista &= "" & " == == == == == == == == == == == == == == == == == == == == == == = */" & vbCrLf
            strVista &= "" & "$("".tablas "").on(""click"", "".btnEliminar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """, function() {" & vbCrLf

            strVista &= "" & "    var id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & " = $(this).attr(""id" & frmCreaCatalogo.txtTabla.Text & """);" & vbCrLf

            strVista &= "" & "    swal( {" & vbCrLf
            strVista &= "" & "        title: '¿Está seguro de borrar?'," & vbCrLf
            strVista &= "" & "        text: ""¡Si no lo está puede cancelar la accíón!""," & vbCrLf
            strVista &= "" & "        type: 'warning'," & vbCrLf
            strVista &= "" & "        showCancelButton: true," & vbCrLf
            strVista &= "" & "        confirmButtonColor: '#3085d6'," & vbCrLf
            strVista &= "" & "        cancelButtonColor: '#d33'," & vbCrLf
            strVista &= "" & "        cancelButtonText: 'Cancelar'," & vbCrLf
            strVista &= "" & "       confirmButtonText: 'Si, borrar!'" & vbCrLf
            strVista &= "" & "    }).then(function(result) {" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "        if (result.value) {" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "            window.location = ""index.php?ruta=" & (frmCreaCatalogo.txtTabla.Text) & "&id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "=""+id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "+""&borrar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "=borrar"";" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "        }" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "    })" & vbCrLf

            strVista &= "" & "})" & vbCrLf


            'editar

            strVista &= "" & "/* = == == == == == == == == == == == == == == == == == == == == == ==" & vbCrLf
            strVista &= "" & " EDITAR " & vbCrLf
            strVista &= "" & " == == == == == == == == == == == == == == == == == == == == == == = */" & vbCrLf
            strVista &= "" & "$("".tablas "").on(""click"", "".btnEditar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """, function() {" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "    var id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & " = $(this).attr(""id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """);" & vbCrLf
            strVista &= "" & "  console.log(id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & ");"
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "    var datos = new FormData();" & vbCrLf
            strVista &= "" & "    datos.append(""id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """, id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "); " & vbCrLf
            strVista &= "" & "    datos.append(""buscar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """, ""buscar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """);" & vbCrLf
            strVista &= "" & "   " & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "    $.ajax( {" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "        url:""controladores/" & frmCreaCatalogo.txtTabla.Text & ".controlador.php""," & vbCrLf
            strVista &= "" & "        method:""POST""," & vbCrLf
            strVista &= "" & "        data: datos," & vbCrLf
            strVista &= "" & "        cache: false," & vbCrLf
            strVista &= "" & "        contentType: false," & vbCrLf
            strVista &= "" & "        processData: false," & vbCrLf
            strVista &= "" & "       dataType:""json""," & vbCrLf
            strVista &= "" & "       success: function(respuesta) {" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & strEditarTraeDatos & vbCrLf
            strVista &= "" & "            " & vbCrLf
            strVista &= "" & "        }" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "    });" & vbCrLf
            strVista &= "" & "" & vbCrLf
            strVista &= "" & "})" & vbCrLf


            strVista &= "" & "</script>" & vbCrLf
            Return strVista
        Catch ex As Exception
            ' SI NO SE ABRE LA CONEXIÓN MANDAMOS MENSAJE DE ERROR
            MsgBox("ERROR " & ex.Message)

            Exit Function
        End Try

    End Function

End Module
