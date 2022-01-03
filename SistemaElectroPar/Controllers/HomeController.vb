Imports System.Web.Mvc
Imports ClasesElectroPar
Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Util.inicializaSesion("KALO", "Electropar", "kalo", "kalo")
            Return View()
        End Function
    End Class
End Namespace