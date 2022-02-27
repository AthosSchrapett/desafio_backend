using desafio_backend.Data;
using desafio_backend.Models;

namespace desafio_backend.Endpoints;

public class PagamentoPost
{
    public static string Template => "/pagamento";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(PagamentoRequest pagamentoRequest, AppDbContext dbContext)
    {
        var pagamento = new Pagamento(pagamentoRequest.ValorTotal, pagamentoRequest.ValorPago);

        if (pagamento.ValorTotal > 0 && pagamento.ValorPago > 0)
        {
            dbContext.Pagamento.Add(pagamento);

            var troco = new Troco(DefineTroco(pagamentoRequest.ValorTotal, pagamentoRequest.ValorPago), pagamento.Id);
            dbContext.Troco.Add(troco);

            dbContext.SaveChanges();

            return Results.Ok();
        }
        else
        {
            return Results.NotFound();
        }
    }
    public static double DefineTroco(double valorTotal, double valorPago)
    {
        double valorTroco = valorPago - valorTotal;

        return valorTroco;
    }
}
