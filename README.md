# CalculadoraDescontos

Solução .NET 10 para categorização de clientes, cálculo de descontos e validação de cupom, com testes parametrizados em xUnit.
Atividade da disciplina **Garantia da Qualidade de Software** (Gestão e Qualidade de Software).

## Estrutura

```
CalculadoraDescontos.sln
├── CalculadoraDescontos.App     -> código de produção (DescontoService)
└── CalculadoraDescontos.Tests   -> testes unitários com xUnit
```

## Métodos (`DescontoService`)

| Método | Retorno | Regra |
|---|---|---|
| `ObterCategoriaCliente(int totalCompras)` | `string` | `"BRONZE"` (< 5), `"PRATA"` (5 a 10), `"OURO"` (> 10) |
| `CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)` | `int` | Valor final com desconto. Ex.: `(100, 10)` → `90` |
| `EValidoParaCupom(int idade, bool primeiraCompra)` | `bool` | `true` se idade ≥ 18 **ou** primeira compra |

## Diferença entre `[Fact]` e `[Theory]`

- **`[Fact]`**: teste único, **sem parâmetros**. Roda sempre uma vez, com os mesmos valores escritos dentro do método. Serve para um cenário fixo.
- **`[Theory]`**: teste **parametrizado**. O método recebe parâmetros, e cada `[InlineData(...)]` fornece um conjunto de valores. O xUnit executa o método **uma vez para cada `[InlineData]`**, e cada execução aparece como um teste individual no resultado.

Com `[Theory]`, em vez de escrever vários métodos quase idênticos, escrevemos um só e listamos os cenários:

```csharp
[Theory]
[InlineData(2, "BRONZE")]
[InlineData(7, "PRATA")]
[InlineData(15, "OURO")]
public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(int totalCompras, string esperado)
{
    Assert.Equal(esperado, _service.ObterCategoriaCliente(totalCompras));
}
```

## Testes (`DescontoServiceTests`)

| Teste | Tipo | Cenários |
|---|---|---|
| `ObterCategoriaCliente_...` | `string` | 2 → BRONZE, 7 → PRATA, 15 → OURO |
| `CalcularDescontoPorPercentual_...` | `int` | (100, 10) → 90, (200, 20) → 160, (50, 0) → 50 |
| `EValidoParaCupom_...` | `bool` | (20, false) → true, (16, true) → true, (17, false) → false |

Total: 9 execuções de teste (3 `[Theory]` × 3 `[InlineData]`).

## Como executar

Pré-requisito: [.NET SDK 10](https://dotnet.microsoft.com/download).

```bash
dotnet test
```

Para ver cada `[InlineData]` listado individualmente:

```bash
dotnet test --logger "console;verbosity=detailed"
```

## Como a solução foi criada

```bash
dotnet new sln -n CalculadoraDescontos
dotnet new console -n CalculadoraDescontos.App -f net10.0
dotnet new xunit -n CalculadoraDescontos.Tests -f net10.0
dotnet sln add CalculadoraDescontos.App/CalculadoraDescontos.App.csproj
dotnet sln add CalculadoraDescontos.Tests/CalculadoraDescontos.Tests.csproj
dotnet add CalculadoraDescontos.Tests/CalculadoraDescontos.Tests.csproj reference CalculadoraDescontos.App/CalculadoraDescontos.App.csproj
```

## Licença

[MIT](LICENSE)
