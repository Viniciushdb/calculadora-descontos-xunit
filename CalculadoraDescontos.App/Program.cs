using CalculadoraDescontos.App;

var service = new DescontoService();

Console.WriteLine(service.ObterCategoriaCliente(7));
Console.WriteLine(service.CalcularDescontoPorPercentual(100, 10));
Console.WriteLine(service.EValidoParaCupom(16, true));
