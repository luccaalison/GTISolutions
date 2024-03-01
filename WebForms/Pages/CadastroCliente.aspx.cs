using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace WebForms.Pages
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CarregarEstadosAsync().Wait();
                if (uf.SelectedIndex >0) CarregarCidadesPorEstado(uf.SelectedValue);
            }
        }
        protected void estado_SelectedIndexChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(cep.Text)) {
                CarregarCidadesPorEstado(uf.SelectedValue);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(cep.Text)) {
                CarregarDadosPorCEP(cep.Text);
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e) {


        }
        protected void CarregarDadosPorCEP(string cep) {
            ViaCEPService viaCEPService = new ViaCEPService();
            ViaCEPResponse viaCepResponse = viaCEPService.ConsultarCEP(cep).Result;

            if (viaCepResponse != null) {
                // Preencha os controles (rua, cidade, estado, etc.) com os dados obtidos do ViaCEPResponse.
                rua.Text = viaCepResponse.Logradouro;
                bairro.Text = viaCepResponse.Bairro;
                cidade.Text = viaCepResponse.Localidade;
                uf.SelectedValue = viaCepResponse.UF;

                // Chame a função para carregar as cidades do estado
                CarregarCidadesPorEstado(viaCepResponse.UF);
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
                        return null;
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
                    uf.DataTextField = "Nome";
                    uf.DataValueField = "Sigla";
                    uf.DataBind();
                }
                else {

                }
            }
            catch (Exception ex) {

            }
        }
        protected async void CarregarCidadesPorEstado(string uf) {
            var viaCEPService = new ViaCEPService();
            var cidades = await viaCEPService.ObterCidadesPorEstado(uf);

            cidade.Items.Clear();

            foreach (var cidadeNome in cidades) {
                cidade.Items.Add(new ListItem(cidadeNome, cidadeNome));
            }
        }

        public class ViaCEPService
        {
            private const string ViaCEPBaseUrl = "https://viacep.com.br/ws/";
            public async Task<List<string>> ObterCidadesPorEstado(string uf) {
                try {
                    using (var httpClient = new HttpClient()) {
                        var response = await httpClient.GetStringAsync($"{ViaCEPBaseUrl}{uf}/json/");
                        var cidades = JsonConvert.DeserializeObject<List<ViaCEPCidade>>(response);

                        return cidades.ConvertAll(c => c.Localidade);
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
        public class ViaCEPCidade
        {
            [JsonProperty("localidade")]
            public string Localidade { get; set; }
        }
    }
}