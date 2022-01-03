Imports ClasesElectroPar.Util
Public Class Personal
#Region "Metodos"


    Shared Function ConsultarPersonales() As DataTable
        Return gDatos.TraerDataTable("spConsultarPersonales")
    End Function


#End Region
End Class
