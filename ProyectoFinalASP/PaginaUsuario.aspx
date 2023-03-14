<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaUsuario.aspx.cs" Inherits="ProyectoFinalASP.PaginaUsuario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        
        <div class="mt-4 mb-1" style="text-align: center">
            <h3>Mi perfil</h3>
        </div>
        <asp:Literal ID="ltPaginaUsuario" runat="server" />

        <div class="mt-4 mb-1" style="text-align: center">
            <br />
            <h3>Eventos</h3>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Eventos Disponibles" OnClick="Button1_Click" Visible="False" />
        </div>

        <asp:Literal ID="ltPaginaUsuarioEventos" runat="server" />
        
        <br />
        <br />

        <script>
            //Ir Evento concreto
            function irEvento(idEvento) {
                window.location.href = '/EventoSeleccionado.aspx?idEvento=' + idEvento;
            }

        </script>


    </div>
</asp:Content>
