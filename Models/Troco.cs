namespace desafio_backend.Models;

public class Troco
{
    public Guid Id { get; set; }
    public double ValorTroco { get; set; }
    public List<string> NotasInfo { get; set; }
    public List<string> MoedasInfo { get; set; }
    public Guid PagamentoId { get; set; }
    public Pagamento Pagamento { get; set; }

    public Troco(double valorTroco, Guid pagamentoId, List<string> notasInfo, List<string> moedasInfo)
    {
        Id = Guid.NewGuid();
        this.ValorTroco = valorTroco;
        this.PagamentoId = pagamentoId;
        this.NotasInfo = notasInfo;
        this.MoedasInfo = moedasInfo;
    }

    public void EditValor(double valorTroco, List<string> notasInfo, List<string> moedasInfo)
    {
        this.ValorTroco = valorTroco;
        this.NotasInfo = notasInfo;
        this.MoedasInfo = moedasInfo;
    }
}
