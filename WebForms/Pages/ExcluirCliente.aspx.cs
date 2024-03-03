using System;
using System.Web.Services;
using System.Web.UI;
using WebForms;
using WebServiceCliente = WebForm.WCFService.Cliente;

namespace WebForm.Pages
{
    public partial class ExcluirCliente : Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
            }
        }

        protected void btnExcluirCliente_Click(object sender, EventArgs e) {
            try {
                string cpf = txtCPF.Text;
                ClientePresenter clientePresenter = new ClientePresenter();
                WebServiceCliente cliente = clientePresenter.ObterClientePorCPF(cpf);

                if (cliente != null) {
                    int clienteId = cliente.ClienteId;

                    // Usar Ajax para chamar o método do servidor
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "confirmarExclusao",
                        $"confirmarExclusao('{cpf}', {clienteId});", true);

                    lblMensagemErro.Text = "Cliente excluído com sucesso!";
                    lblMensagemErro.Visible = true;
                }
                else {
                    lblMensagemErro.Text = "Cliente não encontrado.";
                    lblMensagemErro.Visible = true;
                }
            }
            catch (Exception ex) {
                lblMensagemErro.Text = $"Erro ao excluir o cliente: {ex.Message}";
                lblMensagemErro.Visible = true;
            }
        }

        [WebMethod]
        public static void ExcluirClienteConfirmado(string cpf, int clienteId) {
            ClientePresenter clientePresenter = new ClientePresenter();
            WebServiceCliente cliente = clientePresenter.ObterClientePorCPF(cpf);

            if (cliente != null) {
                clientePresenter.ExcluirCliente(cliente.ClienteId);
            }
        }
    }
}
