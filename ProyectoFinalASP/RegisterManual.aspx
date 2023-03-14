<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterManual.aspx.cs" Inherits="ProyectoFinalASP.RegisterManual" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Dinamic Content -->
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-7   mt-4 mb-5">
                <h4 id="textoTitle" class="text-center pb-4">Información Adicional</h4>

                <form>
                    <div class="row">
                        <div class="col">

                            <label class="form-label">Nombre</label>
                            <asp:TextBox type="text" ID="usernameBox" class="form-control" required="true" runat="server"></asp:TextBox>
                            <br />
                            <br />

                            <label class="form-label">Fecha de nacimiento</label>
                            <asp:TextBox type="date" ID="birthdateBox" class="form-control" required="true" runat="server"></asp:TextBox>
                            <br />
                            <br />

                            <label class="form-label">Móvil</label>
                            <asp:TextBox type="text" ID="phoneBox" class="form-control" required="true" runat="server"></asp:TextBox>
                            <span class="form-text" id="errorTelf" runat="server"></span>
                            <br />
                            <br />

                            <label class="form-label">Tipo Minusvalía</label>
                            <asp:TextBox type="text" ID="tipoMinusvaliaBox" class="form-control" required="true" runat="server">Ninguna</asp:TextBox>
                            <br />
                            <br />
                            <asp:CheckBox ID="esMinusvalidoCheckBox" runat="server" Text="&nbsp;Minusválido" />
                        </div>

                        <div class="col">

                            <label class="form-label">Apellidos</label>
                            <asp:TextBox type="text" ID="surnameBox" class="form-control" required="true" runat="server"></asp:TextBox>
                            <br>
                            <br>

                            <label class="form-label">Localidad</label>
                            <asp:TextBox type="text" ID="localidadBox" class="form-control" required="true" runat="server"></asp:TextBox>
                            <br>
                            <br>

                            <label class="form-label">Dependencia</label>
                            <asp:TextBox type="text" ID="dependenciaBox" class="form-control" required="true" runat="server">Ninguna</asp:TextBox>
                            <br>
                            <br>

                            <label class="form-label">Porcentaje Minusvalía</label>
                            <asp:TextBox type="number" ID="porcentajeMinusBox" class="form-control" required="true" runat="server">0</asp:TextBox>
                            <br>
                            <br>
                            <asp:CheckBox ID="esVoluntarioCheckBox" runat="server" Text="&nbsp;Inscribirse como voluntario" />
                        </div>
                    </div>
                </form>
                <br />

                <asp:Button class="btn btn-primary d-block m-auto" runat="server" Text="Enviar datos" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
                <br />
                <asp:Label ID="label" runat="server"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
