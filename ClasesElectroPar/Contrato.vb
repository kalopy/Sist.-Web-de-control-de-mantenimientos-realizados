Imports ClasesElectroPar.Util
Public Class Contrato
    Shared Function ConsultarContratosPorCliente(vCodCliente As Integer) As DataTable
        Return gDatos.TraerDataTable("spConsultarContratosPorCliente", vCodCliente)
    End Function
End Class
