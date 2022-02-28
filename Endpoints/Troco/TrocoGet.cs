using desafio_backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.Endpoints;

public class TrocoGet
{
    public static string Template => "/trocos";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(QueryTroco query) =>
        Results.Ok(query.Execute());
}
