<%@ Page Title="Rutas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RutasDisponibles.aspx.cs" Inherits="ProyectoFinalASP.RutasDisponibles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <asp:Literal ID="ltRutasDisponibles" runat="server" />
        <asp:HiddenField ID="idRutaSeleccionada" runat="server" />
        
        <br />
        <br />

        <script>
            function irRuta(idRuta) {
                window.location.href = '/RutaSeleccionada.aspx?id=' + idRuta;
            }
        </script>

    </div>
</asp:Content>
