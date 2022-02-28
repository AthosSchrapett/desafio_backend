using Dapper;
using desafio_backend.Endpoints;
using Npgsql;

namespace desafio_backend.Data;

public class QueryPagamento
{
    private readonly IConfiguration configuration;

    public QueryPagamento(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<PagamentoResponse> Execute()
    {
        var db = new NpgsqlConnection(configuration["ConnectionString:desafio_backendDB"]);
        var query = "select \"Id\",\"ValorTotal\",\"ValorPago\"from \"Pagamento\"";

        return db.Query<PagamentoResponse>(
            query
        );
    }
}
