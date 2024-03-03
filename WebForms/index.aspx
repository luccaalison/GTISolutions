<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.cs" Inherits="WebForm.index" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <asp:Literal ID="lblMensagemErro" runat="server" Visible="false"></asp:Literal>

            <h2>Buscar Cliente por CPF</h2>
                <div>
                   <label for="txtCPF">CPF:</label>
                    <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" />
                    <asp:Button ID="btnBuscarCliente" runat="server" Text="Buscar Cliente" OnClick="btnBuscarCliente_Click" CssClass="btn btn-primary" />
                </div>
   <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $('#<%= txtCPF.ClientID %>').mask('000.000.000-00', { reverse: true });
    });
</script>
</asp:Content>
