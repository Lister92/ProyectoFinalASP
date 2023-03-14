<%@ Page Title="Ruta Seleccionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RutaSeleccionada.aspx.cs" Inherits="ProyectoFinalASP.RutaSeleccionada" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-12">
        <asp:Literal ID="ltDatosRuta" runat="server" />
    </div>

    <div class="container">
        <div class="row">
            <label>Eventos</label>
            <div class="col-2 list-group">
                <asp:Literal ID="ltEventosRuta" runat="server" />
            </div>
            <div class="col-7" id="map" style="height: 500px;"></div>

            <div class="col-3">
                <asp:Literal ID="ltDescripcion" runat="server" />

                <!-- Botón que triggerea el modal -->
                <div class="center">
                    <asp:Button class="btn btn-primary" runat="server" ID="btnCrearEvento" Text="Crear Evento" OnClick="btnCrearEvento_Click"/>
                    <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#Formulario">
                        Crear Evento
                    </button>--%>
                </div>

                <!-- Modal -->
                <div class="modal fade" id="Formulario" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content" style="width: 145%;">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Nuevo Evento</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h4>Fecha</h4>
                                    </div>
                                    <div class="col-md-6">
                                        <h4>Hora</h4>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <input id="dpFechaEvento" data-provide="datepicker" type="date" class="form-control">
                                    </div>
                                    <div class="col-md-6">
                                        <input type="time" id="txtHoraEvento" name="appt">
                                    </div>
                                </div>
                                <br>

                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" value="" id="cbVoluntarios">
                                            <label class="form-check-label" for="flexCheckDefault">
                                                Necesita Voluntarios
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-primary" onclick="crearEvento()">Crear evento</button>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:HiddenField ID="coordenadas" runat="server" />
                <asp:HiddenField ID="idRutaNuevoEvento" runat="server" />
            </div>
        </div>

        <script>
            //Ir Evento concreto
            function irEvento(idEvento) {
                window.location.href = '/EventoSeleccionado.aspx?id=' + idEvento;
            }

            function crearEvento() {
                var fecha = document.getElementById("dpFechaEvento").value;
                var hora = document.getElementById("txtHoraEvento").value;
                var needVoluntario = document.getElementById("cbVoluntarios").checked;
                var idRutaHidden = document.getElementById("<%=idRutaNuevoEvento.ClientID%>").value;
                window.location.href = '/EventoSeleccionado.aspx?idRuta=' + idRutaHidden + '&fechaEvento=' + fecha + '&horaEvento=' + hora + ' &volEvento=' + needVoluntario;
            }

            var HiddenValue = document.getElementById("<%=coordenadas.ClientID%>").value;

            var myObject = eval('(' + document.getElementById("<%=coordenadas.ClientID%>").value + ')');

            var coordInicial1 = myObject[0];
            var coordInicial2 = myObject[1];
            //alert(coordInicial1 + " = " + myObject[0]);
            //alert(coordInicial2 + " = " + myObject[1]);

            var map = L.map('map').setView([coordInicial2, coordInicial1], 15);

            L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
                maxZoom: 19,
                attribution: '© OpenStreetMap'
            }).addTo(map);

            var popup = L.popup();

            var trazado = L.geoJSON().addTo(map);
            var lineaTotal = null;

            var i = 0;
            do {
                var i1 = i + 1;
                var i2 = i + 2;
                var i3 = i + 3;

                lineaTotal = [{
                    "type": "LineString",
                    "coordinates": [[myObject[i], myObject[i1]], [myObject[i2], myObject[i3]]]
                }];

                trazado.addData(lineaTotal);

                i = i + 2;
            } while (i < myObject.length);


        //var myRequest = {
        //    key: 'rutaCheckpoints',  //Pack myRequest with whatever you need
        //    action: 'show',
        //    otherThing: 'blank'
        //};

        ////To send it, you will need to serialize myRequest.  JSON.strigify will do the trick
        //var requestData = JSON.stringify(myRequest);

        //$.ajax({
        //    type: "POST",
        //    url: "RutaSeleccionada.aspx.cs",
        //    data: { inputData: double[] }, //Change inputData to match the argument in your controller method

        //    success: function (response) {
        //        if (response.Status !== "OK") {
        //            alert("Exception: " + response.Status + " |  " + response.Message);
        //        }
        //        else {
        //            //Add code for successful thing here.
        //            //response will contain whatever you put in it on the server side.  
        //            //In this example I'm expecting Status, Message, and MyArray

        //        }
        //    },
        //    failure: function (response) {
        //        alert("Failure: " + response.Status + " |  " + response.Message);
        //    },
        //    error: function (response) {
        //        alert("Error: " + response.Status + " |  " + response.Message);
        //    }
        //});
        </script>
    </div>
</asp:Content>
