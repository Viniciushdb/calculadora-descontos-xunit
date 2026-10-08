namespace CalculadoraDescontos.App;

public class DescontoService
{
    /// <summary>
    /// BRONZE: menos de 5 compras | PRATA: de 5 a 10 (inclusive) | OURO: mais de 10.
    /// </summary>
    public string ObterCategoriaCliente(int totalCompras)
    {
        if (totalCompras < 5)
            return "BRONZE";

        if (totalCompras <= 10)
            return "PRATA";

        return "OURO";
    }

    /// <summary>
    /// Retorna o valor final com o desconto aplicado. Ex.: (100, 10) => 90
    /// </summary>
    public int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)
    {
        return valorOriginal * (100 - percentualDesconto) / 100;
    }

    /// <summary>
    /// Válido se idade >= 18 OU se for a primeira compra.
    /// </summary>
    public bool EValidoParaCupom(int idade, bool primeiraCompra)
    {
        return idade >= 18 || primeiraCompra;
    }
}
