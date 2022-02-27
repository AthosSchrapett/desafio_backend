namespace desafio_backend.Models;

public class Pagamento
{    
    public Guid Id { get; set; }
    public double ValorTotal { get; set; }
    public double ValorPago { get; set; }

    public Pagamento(double valorTotal, double valorPago)
    {
        Id = Guid.NewGuid();
        this.ValorTotal = valorTotal;
        this.ValorPago = valorPago;
    }
}
