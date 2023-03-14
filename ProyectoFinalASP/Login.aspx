<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinalASP.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Dinamic Content -->
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-sm-4 mt-5 mb-5">
                <h4 class="center">Iniciar sesión</h4>

                <div class="pt-1 pb-3">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox type="email" class="form-control" ID="emailBox" required="true" runat="server"></asp:TextBox>
                </div>

                <div class="pt-1 pb-3">
                    <label for="password" class="form-label">Password</label>
                    <asp:TextBox type="password" class="form-control" ID="passwordBox" required="true" runat="server"></asp:TextBox>
                </div>

                <asp:Button ID="ButtonSubmit" runat="server" Text="Iniciar Sesión" class="btn btn-primary d-block m-auto" OnClick="ButtonSubmit_Click" />
                <br />
                <asp:Label ID="labelEmailPassword" runat="server"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
