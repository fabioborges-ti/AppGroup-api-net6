namespace AppGroup.Rental.Application.Common.Functions;

public static class Utils
{
    public static bool BeValidCNPJ(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        // Remove caracteres não numéricos do CNPJ
        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        // Verifica se o CNPJ tem 14 dígitos
        if (cnpj.Length != 14)
            return false;

        // Verifica se todos os dígitos são iguais, o que não é permitido para um CNPJ válido
        if (cnpj.Distinct().Count() == 1)
            return false;

        // Calcula os dígitos verificadores
        int[] multipliers1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multipliers2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        // Verifica o primeiro dígito verificador
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            sum += int.Parse(cnpj[i].ToString()) * multipliers1[i];
        }
        int remainder = sum % 11;
        int digit1 = remainder < 2 ? 0 : 11 - remainder;

        if (int.Parse(cnpj[12].ToString()) != digit1)
            return false;

        // Verifica o segundo dígito verificador
        sum = 0;
        for (int i = 0; i < 13; i++)
        {
            sum += int.Parse(cnpj[i].ToString()) * multipliers2[i];
        }
        remainder = sum % 11;
        int digit2 = remainder < 2 ? 0 : 11 - remainder;

        return int.Parse(cnpj[13].ToString()) == digit2;
    }
}
