Imports ClasesElectroPar.Util
Public Class Mantenimiento
#Region "Atributos"
    Private CodMatenimiento As Integer
    Private FechaRealizacion As Date
    Private CodContrato As Integer
    Private CodEmpleado As Integer
    Private DetalleTrabajo As String
#End Region

#Region "Propiedades"
    Public Property pCodMatenimiento As Integer
        Get
            Return CodMatenimiento
        End Get
        Set(value As Integer)
            CodMatenimiento = value
        End Set
    End Property
    Public Property pFechaRealizacion As Date
        Get
            Return FechaRealizacion
        End Get
        Set(value As Date)
            FechaRealizacion = value
        End Set
    End Property
    Public Property pCodContrato As Integer
        Get
            Return CodContrato
        End Get
        Set(value As Integer)
            CodContrato = value
        End Set
    End Property

    Public Property pCodEmpleado As Integer
        Get
            Return CodEmpleado
        End Get
        Set(value As Integer)
            CodEmpleado = value
        End Set
    End Property
    Public Property pDetalleTrabajo As String
        Get
            Return DetalleTrabajo
        End Get
        Set(value As String)
            DetalleTrabajo = value
        End Set
    End Property
#End Region

#Region "Metodos"

    Shared Function ConsultarMantenimientos(vCodCliente As Integer) As DataTable
        Return gDatos.TraerDataTable("spConsultarMantenimientos", vCodCliente)
    End Function

    Public Sub InsertarMantenimiento()
        Try
            gDatos.Ejecutar("spInsertarMantenimiento", Me.FechaRealizacion, Me.CodContrato, Me.CodEmpleado, Me.DetalleTrabajo)
        Catch ex As Exception

            Throw ex
        End Try

    End Sub
#End Region
End Class
