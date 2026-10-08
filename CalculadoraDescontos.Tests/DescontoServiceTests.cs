using CalculadoraDescontos.App;

namespace CalculadoraDescontos.Tests;

public class DescontoServiceTests
{
    private readonly DescontoService _service = new();

    // Teste 1 (string)
    [Theory]
    [InlineData(2, "BRONZE")]
    [InlineData(7, "PRATA")]
    [InlineData(15, "OURO")]
    public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(int totalCompras, string esperado)
    {
        var resultado = _service.ObterCategoriaCliente(totalCompras);

        Assert.Equal(esperado, resultado);
    }

    // Teste 2 (int)
    [Theory]
    [InlineData(100, 10, 90)]
    [InlineData(200, 20, 160)]
    [InlineData(50, 0, 50)]
    public void CalcularDescontoPorPercentual_DeveRetornarValorFinalComDesconto(int valorOriginal, int percentual, int esperado)
    {
        var resultado = _service.CalcularDescontoPorPercentual(valorOriginal, percentual);

        Assert.Equal(esperado, resultado);
    }

    // Teste 3 (bool)
    [Theory]
    [InlineData(20, false, true)]   // Maior de idade, não primeira compra
    [InlineData(16, true, true)]    // Menor de idade, primeira compra
    [InlineData(17, false, false)]  // Menor de idade, não primeira compra
    public void EValidoParaCupom_DeveRespeitarRegraDeIdadeOuPrimeiraCompra(int idade, bool primeiraCompra, bool esperado)
    {
        var resultado = _service.EValidoParaCupom(idade, primeiraCompra);

        Assert.Equal(esperado, resultado);
    }
}
