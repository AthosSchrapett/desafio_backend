using desafio_backend.Data;

namespace desafio_backend.Endpoints;

public class TrocoGet
{
    public static string Template => "/trocos";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext dbContext)
    {
        var trocos = dbContext.Troco.ToList();
        var response = trocos.Select(t => new TrocoResponse
        {
            Id = t.Id,
            ValorTroco = t.ValorTroco,
            NotasInfo = t.NotasInfo,
            MoedasInfo = t.MoedasInfo,
            PagamentoId = t.PagamentoId,
        });
        return Results.Ok(response);
    }
}
