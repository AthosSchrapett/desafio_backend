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
        var pagamento = new Pagamento(pagamentoRequest.Valor);

        dbContext.Pagamento.Add(pagamento);
        dbContext.SaveChanges();

        return Results.Ok();
    }
}
