using Dapper;
using desafio_backend.Endpoints;
using Npgsql;

namespace desafio_backend.Data;

public class QueryTroco
{
    private readonly IConfiguration configuration;

    public QueryTroco(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<dynamic> Execute()
    {
        var db = new NpgsqlConnection(configuration["ConnectionString:desafio_backendDB"]);
        var query = "select \"Id\",\"ValorTroco\",\"NotasInfo\",\"MoedasInfo\",\"PagamentoId\"from \"Troco\"";

        return db.Query<dynamic>(
            query
        );
    }
}
