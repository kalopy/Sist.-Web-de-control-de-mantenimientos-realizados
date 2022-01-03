
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Mantenimientos de Trabajos:</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous">

</head>
<body>
    <div class="container">

        <div class="row">
            <h2>Mantenimientos de Trabajos</h2>
        </div>
     
        <div class="row">
            <button class="btn btn-primary" onclick="window.location.href='Mantenimiento/Create';">Nuevo Mantenimiento</button>
        </div>

        <div class="row">
            <label>Cliente: </label>
        </div>

        <div class="row">
           <select class="form-control" onchange="BuscarMantenimientos()" name="cboClientes" id="cboClientes">
                @For Each row In ViewData("clientes")
                    @<option value="@row("CodCliente")">@row("NombreRazonSocial")</option>
                Next
            </select>
        </div>

        <br />

        <div class="row">
            <table class="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <th></th>
                        <th>Fecha Realizacion</th>
                        <th>Nombre o Razon Social</th>
                        <th>Ubicacion</th>
                        <th>Personal</th>
                        <th>Ultimo Matenimiento</th>
                    </tr>
                </thead>
                <tbody id="planilla"></tbody>
            </table>
        </div>

    </div>
    
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>

    <script type="text/javascript">

        function BuscarMantenimientos() {
            
            var parametro = {
                id: $("#cboClientes").val()
            };
            $.ajax({
                type: "POST",
                url: '../../Mantenimiento/RecuperarListaDeMantenimientos',
                data: parametro,
                dataType: "json",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    var row = "";
                    for (i = 0; i < datos.length; i++) {
                        row += "<tr><td></td><td>" + datos[i].FechaRealizacion + "</td><td>" + datos[i].NombreRazonSocial + "</td><td>" + datos[i].Nombre + "</td><td>" + datos[i].NombreApellido + "</td><td>" + datos[i].FechaUltimoMatenimiento +"</td></tr>";
                    }
                    $("#planilla").html(row);
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }
    </script>

    

</body>
</html>

