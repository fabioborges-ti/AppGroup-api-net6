#nullable disable

using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Domain.Dtos.Rent
{
    public class DetailsCnpjDto
    {
        [JsonProperty("abertura", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("abertura")]
        public string Abertura { get; set; }

        [JsonProperty("situacao", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("situacao")]
        public string Situacao { get; set; }

        [JsonProperty("tipo", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonProperty("fantasia", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("fantasia")]
        public string Fantasia { get; set; }

        [JsonProperty("porte", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("porte")]
        public string Porte { get; set; }

        [JsonProperty("natureza_juridica", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("natureza_juridica")]
        public string NaturezaJuridica { get; set; }

        [JsonProperty("atividade_principal", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("atividade_principal")]
        public List<AtividadePrincipal> AtividadePrincipal { get; set; }

        [JsonProperty("qsa", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("qsa")]
        public List<Qsa> Qsa { get; set; }

        [JsonProperty("logradouro", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("numero", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        [JsonProperty("complemento", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("municipio", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("municipio")]
        public string Municipio { get; set; }

        [JsonProperty("bairro", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("uf", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf")]
        public string Uf { get; set; }

        [JsonProperty("cep", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("telefone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("data_situacao", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data_situacao")]
        public string DataSituacao { get; set; }

        [JsonProperty("cnpj", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("ultima_atualizacao", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ultima_atualizacao")]
        public DateTime UltimaAtualizacao { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonProperty("efr", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("efr")]
        public string Efr { get; set; }

        [JsonProperty("motivo_situacao", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("motivo_situacao")]
        public string MotivoSituacao { get; set; }

        [JsonProperty("situacao_especial", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("situacao_especial")]
        public string SituacaoEspecial { get; set; }

        [JsonProperty("data_situacao_especial", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data_situacao_especial")]
        public string DataSituacaoEspecial { get; set; }

        [JsonProperty("atividades_secundarias", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("atividades_secundarias")]
        public List<AtividadesSecundaria> AtividadesSecundarias { get; set; }

        [JsonProperty("capital_social", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("capital_social")]
        public string CapitalSocial { get; set; }

        [JsonProperty("extra", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("extra")]
        public Extra Extra { get; set; }

        [JsonProperty("billing", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("billing")]
        public Billing Billing { get; set; }
    }

    public class AtividadePrincipal
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class AtividadesSecundaria
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Billing
    {
        [JsonProperty("free", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("free")]
        public bool Free { get; set; }

        [JsonProperty("database", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("database")]
        public bool Database { get; set; }
    }

    public class Extra
    {

    }

    public class Qsa
    {
        [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonProperty("qual", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("qual")]
        public string Qual { get; set; }
    }


}
