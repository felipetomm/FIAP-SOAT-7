namespace FIAP.Infrastructure.CrossCutting.Extensions;

public static class StringCpfExtension
{
    /// <summary>
    /// Validate if current string is a valid brazilian CPF
    /// Code from: https://www.macoratti.net/11/09/c_val1.htm
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsValidCPF(this string value)
    {
        var cpf = value;

        int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
        string tempCpf;
        string digito;
        int soma;
        int resto;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }

    /// <summary>
    /// Validate if current string is a valid brazilian CNPJ
    /// Code from: https://www.macoratti.net/11/09/c_val1.htm
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsValidCNPJ(this string value)
    {
        var cnpj = value;

        int[] multiplicador1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        int[] multiplicador2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        int soma;

        int resto;

        string digito;

        string tempCnpj;

        cnpj = cnpj.Trim();

        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cnpj.Length != 14)
            return false;

        tempCnpj = cnpj.Substring(0, 12);

        soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        resto = (soma % 11);

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCnpj = tempCnpj + digito;

        soma = 0;

        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = (soma % 11);

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cnpj.EndsWith(digito);
    }

    /// <summary>
    /// Return masked brazilian CPF
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaskCPF(this string value)
    {
        var number = value.OnlyDigits();
        if (string.IsNullOrWhiteSpace(number))
        {
            return value;
        }
        return Convert.ToUInt64(number).ToString(@"000\.000\.000\-00");
    }

    /// <summary>
    /// Return masked brazilian CNPJ
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaskCNPJ(this string value)
    {
        var number = value.OnlyDigits();
        if (string.IsNullOrWhiteSpace(number))
        {
            return value;
        }
        return Convert.ToUInt64(number).ToString(@"00\.000\.000\/0000\-00");
    }
}