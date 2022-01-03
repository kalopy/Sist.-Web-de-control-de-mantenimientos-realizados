Imports ClasesElectroPar.Util
Public Class Cliente
#Region "Metodos"



    Shared Function ConsultarClientes() As DataTable
        Return gDatos.TraerDataTable("spConsultarClientes")
    End Function


#End Region
End Class
