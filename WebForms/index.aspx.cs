using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using WCFServiceHost.Models;
using WebForms;

namespace WebForm
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e) {
            string cpf = txtCPF.Text;
            ClientePresenter clientePresenter = new ClientePresenter();

            clientePresenter.ObterClientePorCPF(cpf);

            if (clientePresenter != null) {
                Response.Redirect($"Pages/AlterarCliente.aspx?cpf={cpf}");
            }
            else {
                lblMensagemErro.Text = "Cliente não encontrado.";
                lblMensagemErro.Visible = true;
            }
        }
    }
   
}