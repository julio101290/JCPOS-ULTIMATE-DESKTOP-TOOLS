'IMPORTAMOS LAS LIBRERIAS NECESARIAS PARA LA CONEXIÓN A MYSQL/MARIADB
Imports MySqlConnector.MySqlConnection

'EMPIEZA EL MODULO
Module crearControlador

    ' CON PUBLIC SUB CREAMOS PROCEDIMIENTOS
    Public Function generaControlador() As String

        ' VARIABLES PARA LA CONEXIÓN
        Dim strServidor As String
        Dim strBaseDeDatos As String
        Dim strUsuario As String
        Dim strContra As String

        'Variables de uso
        Dim strCampos As String
        Dim strCamposNoLLave As String
        Dim strLLavePrimaria As String
        Dim strCamposValue As String
        Dim strBindingInsert As String
        Dim strBindingUpdate As String
        Dim strCamposUpdate As String
        Dim strControlador As String
        Dim strDatos As String
        Dim strSegundoCampo As String

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

            ' SI SE ABRE LA CONEXIÓN MANDAMOS MENSAJE
            connection.Open()



            Dim comando = New MySqlConnector.MySqlCommand("SHOW KEYS FROM  " & frmCreaCatalogo.txtTabla.Text & " WHERE Key_name = 'PRIMARY'", connection)

            Dim resultado = comando.ExecuteReader

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



            Dim contador As Integer
            contador = 0


            While (resultado.Read)
                strDatos &= " $datos[""nuevo" & UCase(Mid$(resultado("Field"), 1, 1)) & Mid$(resultado("Field"), 2, 100) & """] =  $_POST[ ""nuevo" & UCase(Mid$(resultado("Field"), 1, 1)) & Mid$(resultado("Field"), 2, 100) & """];" & vbCrLf

                If contador = 1 Then
                    ' SEGUNDO CAMPO
                    strSegundoCampo = resultado("Field")
                End If

                strDatos &= " $datos[""" & UCase(Mid$(resultado("Field"), 1, 1)) & Mid$(resultado("Field"), 2, 100) & """] =  $_POST[ ""editar" & UCase(Mid$(resultado("Field"), 1, 1)) & Mid$(resultado("Field"), 2, 100) & """];" & vbCrLf


                contador = contador + 1

            End While


            strControlador &= "" & "<?php" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "class Controlador" & UCase(Mid$(frmCreaCatalogo.txtTabla.Text, 1, 1)) & Mid$(frmCreaCatalogo.txtTabla.Text, 2, 100) & " {" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " /*=============================================" & vbCrLf
            strControlador &= "" & " REGISTRO" & vbCrLf
            strControlador &= "" & " =============================================*/" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " static public function ctrIngresar(){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  if(isset($_POST[""nuevo" & UCase(Mid$(strSegundoCampo, 1, 1)) & Mid$(strSegundoCampo, 2, 100) & """])){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    $tabla = """ & frmCreaCatalogo.txtTabla.Text & " "";" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf

            'LLENA ARREGLO
            strControlador &= "" & strDatos & vbCrLf

            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    $respuesta = Modelo" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "::mdlIngresar($tabla, $datos);" & vbCrLf
            strControlador &= "" & "    " & vbCrLf
            strControlador &= "" & "    " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    if($respuesta == ""ok""){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     echo '<script>" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     swal({" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "      type: ""success""," & vbCrLf
            strControlador &= "" & "      title: ""Guardado correctamente!""," & vbCrLf
            strControlador &= "" & "      showConfirmButton: true," & vbCrLf
            strControlador &= "" & "      confirmButtonText: ""Cerrar""" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     }).then(function(result){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "      if(result.value){" & vbCrLf
            strControlador &= "" & "      " & vbCrLf
            strControlador &= "" & "       window.location = """ & frmCreaCatalogo.txtTabla.Text & " "";" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "      }" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     });" & vbCrLf
            strControlador &= "" & "    " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     </script>';" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    }else{" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "                                    echo '<script>" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     swal({" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "      type: ""Error""," & vbCrLf
            strControlador &= "" & "      title: "" '.$respuesta.'""," & vbCrLf
            strControlador &= "" & "      showConfirmButton: true," & vbCrLf
            strControlador &= "" & "      confirmButtonText: ""Cerrar""" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     }).then(function(result){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "      if(result.value){" & vbCrLf
            strControlador &= "" & "      " & vbCrLf
            strControlador &= "" & "       window.location = """ & frmCreaCatalogo.txtTabla.Text & " "";" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "      }" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     });" & vbCrLf
            strControlador &= "" & "    " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     </script>';" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "                                } " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "   " & vbCrLf
            strControlador &= "" & "   }" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " }" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " /*=============================================" & vbCrLf
            strControlador &= "" & " MOSTRAR " & vbCrLf
            strControlador &= "" & " =============================================*/" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " static public function ctrMostrar($item, $valor){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  $tabla = """ & frmCreaCatalogo.txtTabla.Text & " ""; " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  $respuesta = Modelo" & UCase(Mid$(frmCreaCatalogo.txtTabla.Text, 1, 1)) & Mid$(frmCreaCatalogo.txtTabla.Text, 2, 100) & "::mdlMostrar($tabla, $item, $valor); " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  return $respuesta;" & vbCrLf
            strControlador &= "" & " }" & vbCrLf
            strControlador &= "" & "" & vbCrLf



            strControlador &= "" & " /*=============================================" & vbCrLf
            strControlador &= "" & " EDITAR " & vbCrLf
            strControlador &= "" & " =============================================*/" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " static public function ctrEditar(){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  if(isset($_POST[""editar" & UCase(Mid$(frmCreaCatalogo.txtTabla.Text, 1, 1)) & Mid$(frmCreaCatalogo.txtTabla.Text, 2, 100) & """])){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    $tabla = """ & frmCreaCatalogo.txtTabla.Text & " "";" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  $datos = $_POST;" & vbCrLf
            strControlador &= "" & "          " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    $respuesta = Modelo" & UCase(Mid$(frmCreaCatalogo.txtTabla.Text, 1, 1)) & Mid$(frmCreaCatalogo.txtTabla.Text, 2, 100) & "::mdlEditar($tabla, $datos); " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    if($respuesta == ""ok""){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     echo'<script>" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     swal({" & vbCrLf
            strControlador &= "" & "        type: ""success""," & vbCrLf
            strControlador &= "" & "        title: ""Editado correctamente""," & vbCrLf
            strControlador &= "" & "        showConfirmButton: true," & vbCrLf
            strControlador &= "" & "        confirmButtonText: ""Cerrar""" & vbCrLf
            strControlador &= "" & "        }).then(function(result) {" & vbCrLf
            strControlador &= "" & "         if (result.value) {" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "         window.location = """ & frmCreaCatalogo.txtTabla.Text & " "";" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "         }" & vbCrLf
            strControlador &= "" & "        })" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     </script>';" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    }" & vbCrLf
            strControlador &= "" & "   else{" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    echo'<script>" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "     swal({" & vbCrLf
            strControlador &= "" & "        type: ""Error""," & vbCrLf
            strControlador &= "" & "        title: "" '.$respuesta.'""," & vbCrLf
            strControlador &= "" & "        showConfirmButton: true," & vbCrLf
            strControlador &= "" & "        confirmButtonText: ""Cerrar""" & vbCrLf
            strControlador &= "" & "        }).then(function(result) {" & vbCrLf
            strControlador &= "" & "       if (result.value) {" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "       window.location = """ & frmCreaCatalogo.txtTabla.Text & " "";" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "       }" & vbCrLf
            strControlador &= "" & "      })" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "      </script>';" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "   " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  }" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "}" & vbCrLf

            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " }" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " /*=============================================" & vbCrLf
            strControlador &= "" & " BORRAR " & vbCrLf
            strControlador &= "" & " =============================================*/" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " static public function ctrBorrar(){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  if(isset($_GET[""borrar" & UCase(Mid$(frmCreaCatalogo.txtTabla.Text, 1, 1)) & Mid$(frmCreaCatalogo.txtTabla.Text, 2, 100) & """])){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "   $tabla =""" & frmCreaCatalogo.txtTabla.Text & " "";" & vbCrLf
            strControlador &= "" & "   $datos = $_GET[""id" & UCase(Mid$(frmCreaCatalogo.txtTabla.Text, 1, 1)) & Mid$(frmCreaCatalogo.txtTabla.Text, 2, 100) & """];" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "   $respuesta = Modelo" & UCase(Mid$(frmCreaCatalogo.txtTabla.Text, 1, 1)) & Mid$(frmCreaCatalogo.txtTabla.Text, 2, 100) & "::mdlBorrar($tabla, $datos); " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "   if($respuesta == ""ok""){" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    echo'<script>" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    swal({" & vbCrLf
            strControlador &= "" & "       type: ""success""," & vbCrLf
            strControlador &= "" & "       title: ""Borrado correctamente""," & vbCrLf
            strControlador &= "" & "       showConfirmButton: true," & vbCrLf
            strControlador &= "" & "       confirmButtonText: ""Cerrar""," & vbCrLf
            strControlador &= "" & "       closeOnConfirm: false" & vbCrLf
            strControlador &= "" & "       }).then(function(result) {" & vbCrLf
            strControlador &= "" & "        if (result.value) {" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "        window.location = """ & frmCreaCatalogo.txtTabla.Text & " "";" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "        }" & vbCrLf
            strControlador &= "" & "       })" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "    </script>';" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "   }  " & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "  }" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & " }" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "" & vbCrLf
            strControlador &= "" & "}" & vbCrLf


            strControlador &= "" & " // BUSCA " & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "" & vbCrLf

            strControlador &= "" & " if(isset($_POST[""buscar" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """])) {" & vbCrLf
            strControlador &= "" & "   " & vbCrLf
            strControlador &= "" & "  include '../modelos/" & frmCreaCatalogo.txtTabla.Text & ".modelo.php';" & vbCrLf
            strControlador &= "" & "  " & vbCrLf
            strControlador &= "" & "  $valor = $_POST[""id" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & """];" & vbCrLf
            strControlador &= "" & "  " & vbCrLf
            strControlador &= "" & " $respuesta = Modelo" & utilerias.strPrimeraMayuscula(frmCreaCatalogo.txtTabla.Text) & "::mdlMostrar(""" & frmCreaCatalogo.txtTabla.Text & " "",""id"",$valor);" & vbCrLf
            strControlador &= "" & "        " & vbCrLf
            strControlador &= "" & " echo json_encode($respuesta);" & vbCrLf
            strControlador &= "" & " " & vbCrLf
            strControlador &= "" & "}" & vbCrLf



            generaControlador = strControlador
        Catch ex As Exception
            ' SI NO SE ABRE LA CONEXIÓN MANDAMOS MENSAJE DE ERROR
            MsgBox("ERROR " & ex.Message)

            Exit Function
        End Try

    End Function

End Module
