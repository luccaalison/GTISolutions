using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms;
using WebServiceEndereco = WebForm.WCFService.EnderecoCliente;
using WebServiceCliente = WebForm.WCFService.Cliente;

namespace WebForms.Pages
{
     public partial class AlterarCliente : System.Web.UI.Page
    {
        private WebServiceCliente clienteGlobal;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string cpfValidate = Request.QueryString["cpf"];

                if (!string.IsNullOrEmpty(cpfValidate)) {
                    cpf.ReadOnly = true;
                    CarregarDadosDoCliente(cpfValidate);
                    CarregarEstadosAsync().Wait();
                    CarregarCidadesPorEstado(uf.SelectedValue).Wait();
                }
                else {
                    lblMensagemErro.Text = "Cliente não encontrado.";
                    lblMensagemErro.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "setTimeout(function(){ window.location.href = 'index.aspx'; }, 3000);", true);
                }
            }
        }

        private void CarregarDadosDoCliente(string cpfValidate) {

            ClientePresenter clientePresenter = new ClientePresenter();
            WebServiceCliente cliente = clientePresenter.ObterClientePorCPF(cpfValidate);
            clienteGlobal = cliente;
            Sexo.DataSource = Enum.GetValues(typeof(SexoEnum));
            Sexo.DataBind();

            estCivil.DataSource = Enum.GetValues(typeof(EstadoCivilEnum));
            estCivil.DataBind();

            if (cliente != null) {
                cpf.Text = cliente.CPF;
                nome.Text = cliente.Nome;
                rg.Text = cliente.RG;
                dtExpedicao.Text = cliente.DataExpedicao.ToString();
                orgExpedicao.SelectedValue = cliente.OrgaoExpedicao;
                ufExpedicao.SelectedValue = cliente.UFExpedicao;
                dtNascimento.Text = cliente.DataNascimento.ToString();
                Sexo.SelectedValue = cliente.Sexo;
                estCivil.SelectedValue = cliente.EstadoCivil;
                cep.Text = cliente.Endereco.CEP;
                rua.Text = cliente.Endereco.Logradouro;
                numero.Text = cliente.Endereco.Numero;
                complemento.Text = cliente.Endereco.Complemento;
                bairro.Text = cliente.Endereco.Bairro;
                cidade.SelectedValue = cliente.Endereco.Cidade;
                uf.SelectedValue = cliente.Endereco.UF;
                
            }
            else {
                lblMensagemErro.Text = "Cliente não encontrado.";
                lblMensagemErro.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "setTimeout(function(){ window.location.href = 'index.aspx'; }, 3000);", true);
            }
        }
        protected void estado_SelectedIndexChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(cep.Text)) {
                CarregarCidadesPorEstado(uf.SelectedValue).Wait();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(cep.Text)) {
                string cepFormat = cep.Text.Replace("-", "");
                CarregarDadosPorCEP(cepFormat);
            }
        }
        protected void btnAlterar_Click(object sender, EventArgs e) {
            string campoVazio = GetCampoVazio();
            if (!String.IsNullOrWhiteSpace(campoVazio)) {
                lblMensagemErro.Text = String.Format("Preencha o campo {0} *", campoVazio);
                lblMensagemErro.Visible = true;
                return;
            }
            else {
                try {
                    ClientePresenter clientePresenter = new ClientePresenter();
                    WebServiceCliente cliente = clientePresenter.ObterClientePorCPF(cpf.Text);
                    clienteGlobal = cliente;

                    WebServiceEndereco enderecoCliente = new WebServiceEndereco {
                        CEP = cep.Text.Replace("-", ""),
                        Logradouro = rua.Text,
                        Numero = numero.Text,
                        Complemento = complemento.Text,
                        Bairro = bairro.Text,
                        Cidade = cidade.SelectedValue,
                        UF = uf.SelectedValue
                    };

                    WebServiceCliente ClienteEdit = new WebServiceCliente {
                        CPF = cpf.Text,
                        Nome = nome.Text,
                        RG = rg.Text,
                        DataExpedicao = dtExpedicao.Text,
                        OrgaoExpedicao = orgExpedicao.SelectedValue,
                        UFExpedicao = ufExpedicao.SelectedValue,
                        DataNascimento = dtNascimento.Text,
                        Sexo = Sexo.SelectedValue,
                        EstadoCivil = estCivil.SelectedValue,
                        Endereco = enderecoCliente
                    };


                    clientePresenter.EditarCliente(clienteGlobal.ClienteId, ClienteEdit);

                    lblMensagemErro.Text = "Cliente editado com sucesso!";
                    lblMensagemErro.Visible = true;
                }
                catch (Exception ex) {
                    // Em caso de erro, exiba uma mensagem de erro
                    lblMensagemErro.Text = $"Erro ao editar o cliente: {ex.Message}";
                    lblMensagemErro.Visible = true;
                }
            }
        }
            private int ObterClienteIdDaQueryString() {
                string queryStringId = Request.QueryString["id"];
                int clienteId;

                if (int.TryParse(queryStringId, out clienteId)) {
                    return clienteId;
                }

                throw new ArgumentException("ID do cliente não encontrado na QueryString ou é inválido.");
            }
            private string GetCampoVazio() {
            if (string.IsNullOrWhiteSpace(cpf.Text)) return "CPF";
            if (string.IsNullOrWhiteSpace(nome.Text)) return "Nome";
            if (string.IsNullOrWhiteSpace(rg.Text)) return "RG";
            if (string.IsNullOrWhiteSpace(dtExpedicao.Text)) return "Data de Expedição";
            if (string.IsNullOrWhiteSpace(dtNascimento.Text)) return "Data de Nascimento";
            if (string.IsNullOrWhiteSpace(Sexo.SelectedValue)) return "Sexo";
            if (string.IsNullOrWhiteSpace(estCivil.SelectedValue)) return "Estado Civil";
            if (string.IsNullOrWhiteSpace(cep.Text)) return "CEP";
            if (string.IsNullOrWhiteSpace(rua.Text)) return "Rua";
            if (string.IsNullOrWhiteSpace(numero.Text)) return "Número";
            if (string.IsNullOrWhiteSpace(bairro.Text)) return "Bairro";
            if (string.IsNullOrWhiteSpace(cidade.SelectedValue)) return "Cidade";
            if (string.IsNullOrWhiteSpace(uf.SelectedValue)) return "UF";

            return string.Empty;
        }

        protected void CarregarDadosPorCEP(string cep) {
            ViaCEPService viaCEPService = new ViaCEPService();
            ViaCEPResponse viaCepResponse = viaCEPService.ConsultarCEP(cep).Result;

            if (viaCepResponse != null) {

                CarregarCidadesPorEstado(viaCepResponse.UF).Wait();

                rua.Text = viaCepResponse.Logradouro;
                bairro.Text = viaCepResponse.Bairro;
                cidade.Text = viaCepResponse.Localidade;
                uf.SelectedValue = viaCepResponse.UF;

            }
        }

        public class IBGEState
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("sigla")]
            public string Sigla { get; set; }

            [JsonProperty("nome")]
            public string Nome { get; set; }
        }

        public class IBGEApiClient
        {
            private const string BaseUrl = "https://servicodados.ibge.gov.br/api/v1/localidades/";

            public async Task<List<IBGEState>> GetStatesAsync() {
                string url = $"{BaseUrl}estados";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (HttpClient client = new HttpClient()) {
                    try {
                        HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode) {
                            string jsonResponse = await response.Content.ReadAsStringAsync();

                            if (!string.IsNullOrEmpty(jsonResponse)) {
                                List<IBGEState> states = JsonConvert.DeserializeObject<List<IBGEState>>(jsonResponse);

                                if (states != null) {
                                    return states;
                                }
                                else {
                                    return null;
                                }
                            }
                            else {
                                return null;
                            }
                        }
                        else {
                            return null;
                        }
                    }
                    catch (Exception ex) {
                        throw ex;
                    }
                }
            }
        }

        public async Task CarregarEstadosAsync() {
            try {
                var ibgeApiClient = new IBGEApiClient();
                var estados = await ibgeApiClient.GetStatesAsync();

                if (estados != null && estados.Any()) {
                    uf.DataSource = estados;
                    uf.DataTextField = "Sigla";
                    uf.DataValueField = "Sigla";
                    uf.DataBind();
                }
                else {

                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        protected async Task CarregarCidadesPorEstado(string uf) {
            var viaCEPService = new ViaCEPService();
            var cidades = await viaCEPService.ObterCidadesPorEstado(uf);

            cidade.Items.Clear();

            foreach (var cidadeNome in cidades) {
                cidade.Items.Add(new ListItem(cidadeNome, cidadeNome));
            }
        }

        protected void uf_SelectedIndexChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(uf.SelectedValue)) {
                CarregarCidadesPorEstado(uf.SelectedValue).Wait();
            }
        }

        public class ViaCEPService
        {
            private const string ViaCEPBaseUrl = "https://viacep.com.br/ws/";
            public async Task<List<string>> ObterCidadesPorEstado(string uf) {
                try {
                    using (var httpClient = new HttpClient()) {
                        var response = await httpClient.GetStringAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{uf}/municipios");
                        var cidades = JsonConvert.DeserializeObject<List<IBGECidade>>(response);

                        return cidades.ConvertAll(c => c.Nome);
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine($"Erro ao obter cidades: {ex.Message}");
                    return new List<string>();
                }
            }
            public async Task<ViaCEPResponse> ConsultarCEP(string cep) {
                using (HttpClient client = new HttpClient()) {
                    HttpResponseMessage response = await client.GetAsync($"{ViaCEPBaseUrl}{cep}/json");

                    if (response.IsSuccessStatusCode) {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        return serializer.Deserialize<ViaCEPResponse>(jsonResponse);
                    }

                    return null;
                }
            }
        }

        public class ViaCEPResponse
        {
            public string CEP { get; set; }
            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            public string UF { get; set; }
            public string IBGE { get; set; }
            public string GIA { get; set; }
            public string DDD { get; set; }
            public string SIAFI { get; set; }
        }
        public class IBGECidade
        {
            [JsonProperty("nome")]
            public string Nome { get; set; }
        }

        public enum SexoEnum
        {
            Selecione,
            Masculino,
            Feminino,
            Outros
        }

        public enum EstadoCivilEnum
        {
            Selecione,
            Solteiro,
            Casado,
            Viuvo,
            Divorciado
        }
    }
}