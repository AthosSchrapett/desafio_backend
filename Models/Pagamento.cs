namespace desafio_backend.Models;

public class Pagamento
{    
    public Guid Id { get; set; }
    public double Valor { get; set; }

    public Pagamento(double valor)
    {
        Id = Guid.NewGuid();
        this.Valor = valor;
    }

}
