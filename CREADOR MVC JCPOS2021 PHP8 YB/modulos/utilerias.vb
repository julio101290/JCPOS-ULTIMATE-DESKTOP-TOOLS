Module utilerias

    Public Function strPrimeraMayuscula(strCadena As String) As String

        Return UCase(Mid$(strCadena, 1, 1)) & Mid$(strCadena, 2, strCadena.Length)

    End Function

End Module
