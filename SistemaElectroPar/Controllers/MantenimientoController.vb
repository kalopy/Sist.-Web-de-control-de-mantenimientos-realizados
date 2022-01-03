Imports System.Web.Mvc
Imports ClasesElectroPar

Namespace Controllers
    Public Class MantenimientoController
        Inherits Controller

        ' GET: Mantenimiento

        Function Index() As ActionResult
            ViewData("clientes") = Cliente.ConsultarClientes.AsEnumerable
            Return View()
        End Function

        Function RecuperarListaDeMantenimientos(id As Integer) As JsonResult
            Dim dt As New DataTable
            dt = Mantenimiento.ConsultarMantenimientos(id)
            Return Json(Newtonsoft.Json.JsonConvert.SerializeObject(dt))
        End Function

        Function RecuperarContratosPorCliente(id As Integer) As JsonResult
            Dim dt As New DataTable
            dt = Contrato.ConsultarContratosPorCliente(id)
            Return Json(Newtonsoft.Json.JsonConvert.SerializeObject(dt))
        End Function

        Function Create() As ActionResult

            Dim dtClientes As New DataTable
            dtClientes = Cliente.ConsultarClientes
            ViewData("clientes") = dtClientes.AsEnumerable

            Dim dtPersonales As New DataTable
            dtPersonales = Personal.ConsultarPersonales
            ViewData("personales") = dtPersonales.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult

            Dim vMantenimiento As New Mantenimiento

            With vMantenimiento
                .pFechaRealizacion = form("fechaRealizacion")
                .pCodContrato = form("cboClientes")
                .pCodEmpleado = form("cboEmpleados")
                .pDetalleTrabajo = form("detalleTrabajo")

                .InsertarMantenimiento()
            End With

            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace