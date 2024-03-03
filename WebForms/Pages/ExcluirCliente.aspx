<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ExcluirCliente.aspx.cs" Inherits="WebForm.Pages.ExcluirCliente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Literal ID="lblMensagemErro" runat="server" Visible="false"></asp:Literal>

    <h2>Excluir Cliente</h2>
    <div>
        <label for="txtCPF">CPF:</label>
        <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" />
        <asp:Button ID="btnExcluirCliente" runat="server" Text="Excluir Cliente" CssClass="btn btn-danger" OnClick="btnExcluirCliente_Click" />
    </div>

     <script type="text/javascript">
         $(document).ready(function () {
             $('#<%= txtCPF.ClientID %>').mask('000.000.000-00', { reverse: true });
        });
         function confirmarExclusao() {
             if (confirm("Tem certeza que deseja excluir o cliente?")) {
                 // Se o usuário confirmar, faz uma chamada AJAX para o servidor
                 PageMethods.ExcluirClienteConfirmado('<%= txtCPF.Text %>', onSucesso, onError);
             }
         }

         // Função de retorno de sucesso da chamada AJAX
         function onSucesso() {
             alert('Cliente excluído com sucesso!');
             // Lógica adicional após a exclusão
         }

         // Função de retorno de erro da chamada AJAX
         function onError() {
             alert('Erro ao excluir o cliente.');
         }
     </script>
</asp:Content>
