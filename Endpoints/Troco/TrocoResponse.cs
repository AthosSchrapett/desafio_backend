namespace desafio_backend.Endpoints;

public record TrocoResponse
{
    public Guid Id { get; set; }
    public double ValorTroco { get; set; }
    public List<string> NotasInfo { get; set; }
    public List<string> MoedasInfo { get; set; }
    public Guid PagamentoId { get; set; }
}
