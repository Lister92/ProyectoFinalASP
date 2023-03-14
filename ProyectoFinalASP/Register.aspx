<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProyectoFinalASP.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Dinamic Content -->
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-7 mt-5 mb-5">
                <h4 id="textoTitle" class="text-center pb-4">Saca el máximo partido a tus rutas</h4>

                <form>
                    <div class="row">
                        <div class="col">

                            <label for="email" class="form-label">Email</label>
                            <asp:TextBox type="email" class="form-control" ID="emailBox" required="true" runat="server"></asp:TextBox>
                            <span class="form-text" id="errorEmail" runat="server"></span>
                            <br>
                            <br>

                            <label for="passwordV2" class="form-label">Contraseña</label>
                            <asp:TextBox type="password" class="form-control" ID="passwordBox" required="true" runat="server"></asp:TextBox>
                            <span class="form-text" id="errorPassword" runat="server"></span>
                            <br>
                            <br>
                        </div>

                        <div class="col">

                            <label for="email" class="form-label">Repetir Email</label>
                            <asp:TextBox type="email" class="form-control" ID="rEmailBox" required="true" runat="server"></asp:TextBox>
                            <span class="form-text" id="errorEmailV2" runat="server"></span>
                            <br>
                            <br>

                            <label for="password" class="form-label">Repetir Contraseña</label>
                            <asp:TextBox type="password" class="form-control" ID="rPasswordBox" required="true" runat="server"></asp:TextBox>
                            <span class="form-text" id="errorPasswordV2" runat="server"></span>
                            <br>
                        </div>
                    </div>

                </form>

                <asp:Button class="btn btn-primary d-block m-auto" runat="server" Text="Continuar" ID="btnContinuarRegistro" OnClick="btnContinuarRegistro_Click" />
            </div>
        </div>
    </div>

    <%--
    <div class="container" style="width: 30%">
        
        <div class="row justify-content-center">
            <asp:Button ID="Button2" runat="server" Text="Sign up with Google" />
        </div>
        <br />
        <div class="row justify-content-center">
            <asp:Button ID="Button3" runat="server" Text="Facebook" />
        </div>
    </div>
    --%>
</asp:Content>
