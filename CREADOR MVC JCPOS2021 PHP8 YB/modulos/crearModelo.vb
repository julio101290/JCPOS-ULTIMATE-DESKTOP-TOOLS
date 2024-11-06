'IMPORTAMOS LAS LIBRERIAS NECESARIAS PARA LA CONEXIÓN A MYSQL/MARIADB
Imports MySqlConnector.MySqlConnection

'EMPIEZA EL MODULO
Module crearModelo

    ' CON PUBLIC SUB CREAMOS PROCEDIMIENTOS
    Public Function generaModelo() As String

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
        Dim strModelo As String

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


                ' CAMPOS PARA EL Select
                If contador = 0 Then
                    strCampos = resultado.GetString("Field") & vbCrLf
                Else
                    strCampos = strCampos & "," & resultado("Field") & vbCrLf
                End If

                'CAMPOS PARA EL INSERT

                If resultado("Key") <> "PRI" Then
                    If contador = 1 Then
                        strCamposNoLLave = resultado("Field") & vbCrLf
                    Else
                        strCamposNoLLave = strCamposNoLLave & "," & resultado("Field") & vbCrLf
                    End If

                End If

                ' CAMPOS PARA EL VALUE

                If resultado("Key") <> "PRI" Then
                    If contador = 1 Then
                        strCamposValue = ":" & resultado("Field") & vbCrLf
                    Else
                        strCamposValue = strCamposValue & "," & ":" & resultado("Field") & vbCrLf
                    End If
                End If

                If resultado("Key") <> "PRI" Then
                    strBindingInsert = strBindingInsert & "     $stmt -> bindParam("":" & resultado("Field") & """, $datos[""nuevo" & UCase(Mid$(resultado("Field"), 1, 1)) & Mid$(resultado("Field"), 2, 100) & """], PDO::PARAM_STR);" & vbCrLf
                End If

                ' CAMPOS UPDATE
                If resultado("Key") <> "PRI" Then

                    If contador = 1 Then

                        strCamposUpdate = strCamposUpdate & resultado("Field") & "= :" & resultado("Field")

                    Else

                        strCamposUpdate = strCamposUpdate & "," & resultado("Field") & "= :" & resultado("Field")

                    End If

                End If

                strBindingUpdate = strBindingUpdate & "     $stmt -> bindParam("":" & resultado("Field") & """, $datos[""editar" & utilerias.strPrimeraMayuscula(resultado("Field")) & """], PDO::PARAM_STR);" & vbCrLf

                contador = contador + 1



            End While


            strModelo = ""
            strModelo &= "<?php" & vbCrLf
            strModelo &= "require_once ""conexion.php"";" & vbCrLf
            strModelo &= "" & "" & vbCrLf



            strModelo &= "" & "Class Modelo" & UCase(Mid$(frmCreaCatalogo.txtTabla.Text, 1, 1)) & Mid$(frmCreaCatalogo.txtTabla.Text, 2, 25) & " {" & vbCrLf
            strModelo &= "" & "   /* =============================================" & vbCrLf
            strModelo &= "" & "     MOSTRAR " & UCase(frmCreaCatalogo.txtTabla.Text) & vbCrLf
            strModelo &= "" & "      ============================================= */" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "    Static Public Function mdlMostrar($tabla, $item, $valor) {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "       If ($item != Null) {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           $stmt = Conexion:: conectar() -> prepare( ""Select " & strCampos

            strModelo &= "" & "           From " & frmCreaCatalogo.txtTabla.Text & " a WHERE $item = :$item"");" & vbCrLf
            strModelo &= "" & "" & vbCrLf


            strModelo &= "" & "           $stmt -> bindParam( "":"" .$item, $valor, PDO::PARAM_STR);" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           Try {" & vbCrLf
            strModelo &= "" & "               $stmt -> execute();" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "                Return $stmt -> fetch();" & vbCrLf
            strModelo &= "" & "           } Catch (PDOException $e) {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "               $arr = $stmt -> errorInfo();" & vbCrLf
            strModelo &= "" & "                $arr[3] = ""Error"";" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "               If ($e -> getMessage() == 23000) {" & vbCrLf
            strModelo &= "" & "                   $mensaje = "" El registro esta duplicado, Favor de checar el numero de nomina "";" & vbCrLf
            strModelo &= "" & "                   Return $mensaje;" & vbCrLf
            strModelo &= "" & "               } Else {" & vbCrLf
            strModelo &= "" & "                  Return $arr[2];" & vbCrLf
            strModelo &= "" & "              }" & vbCrLf
            strModelo &= "" & "           }" & vbCrLf
            strModelo &= "" & "           " & vbCrLf
            strModelo &= "" & "           " & vbCrLf
            strModelo &= "" & "       } Else {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           $stmt = Conexion:: conectar() -> prepare(""Select * " & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           " & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           From " & frmCreaCatalogo.txtTabla.Text & " a ""); " & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           $stmt -> execute();" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           Return $stmt -> fetchAll();" & vbCrLf
            strModelo &= "" & "       }" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "       $stmt -> close();" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "        $stmt = Null;" & vbCrLf
            strModelo &= "" & "   }" & vbCrLf
            strModelo &= "" & "" & vbCrLf

            ' REGISTRO

            strModelo &= "" & "   /* ==================================================================" & vbCrLf
            strModelo &= "" & "     REGISTRO" & vbCrLf
            strModelo &= "" & "    ==================================================================== */" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "   Static Public Function mdlIngresar($tabla, $datos) {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "      $stmt = Conexion:: conectar() -> prepare(""INSERT INTO " & frmCreaCatalogo.txtTabla.Text & "(" & strCamposNoLLave & "" & vbCrLf
            strModelo &= "" & "        " & vbCrLf
            strModelo &= "" & "                                                                       )" & vbCrLf
            strModelo &= "" & "                                                                       VALUES(" & strCamposValue & ")" & vbCrLf
            strModelo &= "" & "                          " & vbCrLf
            strModelo &= "" & "                                                                              ""); " & vbCrLf
            strModelo &= "" & ""

            strModelo &= "" & strBindingInsert & vbCrLf

            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "       If ($stmt -> execute()) {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           Return ""ok"";" & vbCrLf
            strModelo &= "" & "       } Else {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           $arr = $stmt -> errorInfo();" & vbCrLf
            strModelo &= "" & "           $arr[3] = "" Error "";" & vbCrLf
            strModelo &= "" & "          Return $arr[2];" & vbCrLf
            strModelo &= "" & "      }" & vbCrLf

            strModelo &= "" & "      $stmt -> close();" & vbCrLf

            strModelo &= "" & "      $stmt = Null;" & vbCrLf
            strModelo &= "" & "  }" & vbCrLf



            'EDITAR ACTUALIZAR
            strModelo &= "" & "  /* ==================================================================" & vbCrLf
            strModelo &= "" & "   EDITAR " & vbCrLf
            strModelo &= "" & "     ================================================================== */" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "   Static Public Function mdlEditar($tabla, $datos) {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "       $stmt = Conexion:: conectar() -> prepare("" UPDATE $tabla Set " & strCamposUpdate & "" & vbCrLf
            strModelo &= "" & ""
            strModelo &= "" & "                                                                   WHERE id =:" & strLLavePrimaria & "  ""); " & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & strBindingUpdate
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "       If ($stmt -> execute()) {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "           Return ""ok"";" & vbCrLf
            strModelo &= "" & "     } Else {" & vbCrLf
            strModelo &= "" & ""
            strModelo &= "" & "          Return ""Error"";" & vbCrLf
            strModelo &= "" & "      }" & vbCrLf
            strModelo &= "" & ""
            strModelo &= "" & "     $stmt -> close();" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "      $stmt = Null;" & vbCrLf
            strModelo &= "" & "   }" & vbCrLf
            strModelo &= "" & "   " & vbCrLf
            strModelo &= "" & " " & vbCrLf & vbCrLf
            strModelo &= "" & "  /* ===================================================================" & vbCrLf
            strModelo &= "" & "     BORRAR USUARIO" & vbCrLf
            strModelo &= "" & "     =================================================================== */" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "  Static Public Function mdlBorrar($tabla, $datos) {" & vbCrLf

            strModelo &= "" & "       $stmt = Conexion:: conectar() -> prepare( "" DELETE From " & frmCreaCatalogo.txtTabla.Text & " WHERE id =:id"");" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "       $stmt -> bindParam("":id"", $datos, PDO::PARAM_INT);" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "      If ($stmt -> execute()) {" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "Return ""ok"";" & vbCrLf
            strModelo &= "" & "      } Else {" & vbCrLf

            strModelo &= "" & "          Return ""Error"";" & vbCrLf
            strModelo &= "" & "      }" & vbCrLf

            strModelo &= "" & "        $stmt -> close();" & vbCrLf

            strModelo &= "" & "       $stmt = Null;" & vbCrLf
            strModelo &= "" & "    }" & vbCrLf
            strModelo &= "" & "" & vbCrLf
            strModelo &= "" & "}" & vbCrLf


            generaModelo = strModelo
        Catch ex As Exception
            ' SI NO SE ABRE LA CONEXIÓN MANDAMOS MENSAJE DE ERROR
            MsgBox("ERROR " & ex.Message)

            Exit Function
        End Try

    End Function

End Module
