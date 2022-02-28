using desafio_backend.Data;

namespace desafio_backend.Endpoints;

public class PagamentoGet
{
    public static string Template => "/pagamentos";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(QueryPagamento query) =>
        Results.Ok(query.Execute());
}

