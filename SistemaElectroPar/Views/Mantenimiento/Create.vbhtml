
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Nuevo Mantenimiento</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" 
          integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous">

</head>
<body>
    <div class="container">
        <h2>Nuevo Mantenimiento</h2>

        <form action="create" method="post" class="form-horizontal">
            <div class="container">

                @*ComboBoxClientes*@
                <div class="row">
                    <label for="txtNombre">Clientes</label>
                    <select class="form-control" onchange="BuscarContratosPorCliente()" id="cboClientes" name="cboClientes">
                        @For Each row In ViewData("clientes")
                            @<option value="@row("CodCliente")">@row("NombreRazonSocial")</option>
                        Next
                    </select>
                </div>

                <br>

                @*ComboBoxContratos*@
                <div class="row">
                    <label for="txtNombre">Contratos</label>
                    <select class="form-control" id="cboContrato" name="cboContrato"></select>
                </div>

                <br>

                @*Fecha Realizacion*@
                <div class="row">
                    <label @*class="control-label col-xs-3"*@>Fecha Realizacion</label>
                    @*<div class="col-xs-9 col-sm-4 col-md-9 col-lg-4">*@
                    
                    @*</div>*@
                </div>

                <div class="row">
                    <input type="date" class="form-control" placeholder="FechaRealizacion" name="fechaRealizacion" style="width:200px" />
                </div>

                <br>

                @*ComboBox Empleados*@
                <div class="row">
                    <label for="txtNombre">Empleado</label>
                    <select class="form-control" id="cboEmpleados" name="cboEmpleados">
                        @For Each row In ViewData("personales")
                            @<option value="@row("CodPersonal")">@row("NombreApellido")</option>
                        Next
                    </select>
                </div>

                <br>

                <div class="row">
                    <label for="txtNombre">Detalle del trabajo</label>
                </div>
                <div class="row">
                    <input type="text" class="form-control" name="detalleTrabajo" style="width:200px">
                </div>

                <br />

                @*Botones*@
                <div class="form-group">
                    <div class="row">
                        <button type="submit" class="btn btn-primary">Guardar</button>
                        <input type="reset" class="btn btn-default" value="Cancelar" />
                    </div>
                </div>

            </div>
        </form>

    </div>

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js"
            integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>

    @*Funcion JS*@
    <script type="text/javascript">

        function BuscarContratosPorCliente() {

            var cod_cliente = $('#cboClientes').val();

            //metodo Ajax
            $.ajax({
                //la url para la peticion
                url: '../../Mantenimiento/RecuperarContratosPorCliente',
                //definimos parametros que se va enviar
                data: {
                    id: cod_cliente
                },
                //definimos la forma de envio
                type: "POST",
                //tipo de dato que va a retornar la accion
                dateType: 'JSON',
                //ejecutamos la accion y guarda el resultado en retorno
                success: function (retorno) {
                    var datos = jQuery.parseJSON(retorno);
                    var row = "";
                    for (i = 0; i < datos.length; i++) {
                        row += '<option value="' + datos[i].CodContrato + '">' + datos[i].NroContrato + '</option>';
                    }
                    $("#cboContrato").html(row);
                },
                error: function () {
                    alert("se ha producido un error.");
                },
                alert: function () {
                    alert(retorno);
                },
            }) //Metodo ajax

        }
    </script>

</body>
</html>


