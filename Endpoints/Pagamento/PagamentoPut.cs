using desafio_backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.Endpoints;

public class PagamentoPut
{
    public static string Template => "/pagamento/{id:Guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, PagamentoRequest pagamentoRequest, AppDbContext dbContext)
    {
        var pagamento = dbContext.Pagamento.Where(p => p.Id == id).FirstOrDefault();
        var troco = dbContext.Troco.Where(t => t.PagamentoId == pagamento.Id).FirstOrDefault();

        List<string> notasInfo = new();
        List<string> moedasInfo = new();

        if (pagamento == null)
            return Results.NotFound();

        if (pagamento.ValorTotal > 0 && pagamento.ValorPago > pagamento.ValorTotal)
        {
            pagamento.EditValor(pagamentoRequest.ValorTotal, pagamentoRequest.ValorPago);
            troco.EditValor(
                DefineTroco.DefineInfoTroco(
                    pagamentoRequest.ValorTotal,
                    pagamentoRequest.ValorPago,
                    notasInfo,
                    moedasInfo
                ),
                notasInfo,
                moedasInfo);

            dbContext.SaveChanges();
            return Results.Ok();
        }
        else
        {
            return Results.BadRequest();
        }             
    }
}
