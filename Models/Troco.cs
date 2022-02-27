namespace desafio_backend.Models;

public class Troco
{
    public Guid Id { get; set; }
    public double ValorTroco { get; set; }
    public Guid PagamentoId { get; set; }
    public Pagamento Pagamento { get; set; }

    public Troco(double valorTroco, Guid pagamentoId)
    {
        Id = Guid.NewGuid();
        this.ValorTroco = valorTroco;
        this.PagamentoId = pagamentoId;
    }    
}
