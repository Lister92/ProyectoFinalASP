<%@ Page Title="Eventos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventosDisponibles.aspx.cs" Inherits="ProyectoFinalASP.EventosDisponibles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <asp:Literal ID="ltEventosDisponibles" runat="server" />
        <br />
        <br />

        <script>
            //Ir Evento concreto
            function irEvento(idEvento)
            {
                window.location.href = '/EventoSeleccionado.aspx?idEvento=' + idEvento;
            }
            
        </script>
    </div>
</asp:Content>

