using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Rent;
using Newtonsoft.Json;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetDetailsCnpj.Handlers;

public class GetDetailsHandler : Handler<GetDetailsCnpjRequest>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GetDetailsHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public override async Task Process(GetDetailsCnpjRequest request)
    {
        try
        {
            var cnpj = request.Cnpj;

            var client = _httpClientFactory.CreateClient();

            string url = $"https://receitaws.com.br/v1/cnpj/{cnpj}";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DetailsCnpjDto>(content);

                request.DetailsCnpj = result;
            }
            else
            {
                request.HasError = true;
                request.ErrorMessage = "An error occurred when requesting company details.";
                return;
            }
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
