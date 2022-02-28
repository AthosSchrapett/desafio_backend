using desafio_backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.Endpoints;

public class PagamentoDelete
{
    public static string Template => "/pagamento/{id:Guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, AppDbContext dbContext)
    {
        var pagamento = dbContext.Pagamento.Where(p => p.Id == id).FirstOrDefault();

        if (pagamento == null)
            return Results.NotFound();
        else
        {
            dbContext.Pagamento.Remove(pagamento);
            dbContext.SaveChanges();
            return Results.Ok();
        }
    }
}
