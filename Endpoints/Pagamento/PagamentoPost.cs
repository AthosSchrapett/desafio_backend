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
        List<string> notasInfo = new();
        List<string> moedasInfo = new();

        if (pagamento.ValorTotal > 0 && pagamento.ValorPago > pagamento.ValorTotal)
        {
            dbContext.Pagamento.Add(pagamento);

            var troco = new Troco(
                DefineTroco.DefineInfoTroco(
                    pagamentoRequest.ValorTotal, 
                    pagamentoRequest.ValorPago,
                    notasInfo, 
                    moedasInfo
                ), 
                pagamento.Id,
                notasInfo,
                moedasInfo
                );
            dbContext.Troco.Add(troco);

            dbContext.SaveChanges();

            return Results.Ok();
        }
        else
        {
            return Results.BadRequest();
        }
    }
}
