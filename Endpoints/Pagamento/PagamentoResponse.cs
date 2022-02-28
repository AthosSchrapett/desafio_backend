namespace desafio_backend.Endpoints;

public class PagamentoResponse
{
    public Guid Id { get; set; }
    public double ValorTotal { get; set; }
    public double ValorPago { get; set; }
}
