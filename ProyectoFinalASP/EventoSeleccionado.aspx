<%@ Page Title="Evento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventoSeleccionado.aspx.cs" Inherits="ProyectoFinalASP.EventoSeleccionado" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <asp:Literal ID="ltEventoSeleccionado" runat="server" />

        <div class="row">
            <div class="col-8">
                <div class="row">
                    <div class="col-10">
                        <asp:TextBox ID="textoMensaje" class="w-100" enabled="false" placeholder="Escribe aqui tu mensaje" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:Button Text="Enviar" class="btn btn-outline-dark w-100" runat="server" ID="enviarMensaje" OnClick="enviarMensaje_Click" />
                    </div>
                </div>
            </div>
            <div class='col-4' style="text-align: center">
                <asp:Button ID="btnUnirseAlEvento" class='btn btn-success' runat="server" Text="¡Unirme al evento!" OnClick="btnUnirseAlEvento_Click" />
                <asp:Button ID="btnBorrarseDelEvento" class='btn btn-danger' runat="server" Text="Borrarme del evento" Visible="false" OnClick="btnBorrarseDelEvento_Click" />
            </div>
        </div>
    </div>
    <br />

</asp:Content>
