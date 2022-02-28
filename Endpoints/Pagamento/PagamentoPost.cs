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

        if (pagamento.ValorTotal > 0 && pagamento.ValorPago > pagamento.ValorTotal)
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
        List<double> notas = new List<double> { 10.00, 20.00, 50.00, 100.00 };
        List<double> moedas = new List<double> { 0.01, 0.05, 0.10, 0.50 };

        List<double> notasTroco = new List<double>();
        List<double> moedasTroco = new List<double>();

        double valorTroco = Math.Round(valorPago - valorTotal, 2);

        double trocoRetirado = valorTroco;
        double trocoParaSepararNotas = trocoRetirado;

        var index = 0;
        do
        {
            var notasMaiores = notas.Where(x => x <= trocoRetirado);

            foreach (var nota in notasMaiores.Reverse())
            {
                if (!trocoParaSepararNotas.ToString().Split(",")[0].EndsWith("0"))
                {
                    string trocoConvertido = trocoParaSepararNotas.ToString().Split(",")[0];
                    trocoParaSepararNotas = Convert.ToDouble(trocoConvertido.Remove(trocoConvertido.Length - 1) + "0");
                }

                if (nota == (trocoParaSepararNotas - nota) || nota == notas.Where(x => x <= trocoParaSepararNotas).Reverse().First())
                {
                    trocoParaSepararNotas -= nota;
                    trocoRetirado = Math.Round(trocoRetirado - nota, 2);
                    notasTroco.Add(Math.Round(nota, 2));

                    break;
                }
            }

            index++;

        } while (notasTroco.Count() >= index);

        do
        {
            var moedasMaiores = moedas.Where(x => x <= trocoRetirado);

            foreach (var moeda in moedasMaiores.Reverse())
            {
                if(moeda == (trocoRetirado - moeda) || moeda == moedas.Where(x => x <= trocoRetirado).Reverse().First())
                {
                    trocoRetirado -= Math.Round(moeda, 2);
                    moedasTroco.Add(Math.Round(moeda, 2));
                    break;
                }
            }

            index++;

        } while (moedas.Count() >= index);

        List<string> notasInfo = new List<string>();
        List<string> moedasInfo = new List<string>();

        foreach (var nota in notasTroco.Distinct())
            notasInfo.Add($"Troco em Notas de {nota} R$: " + notasTroco.Where(x => x == nota).Count().ToString()) ;
        foreach (var moeda in moedasTroco.Distinct())
            moedasInfo.Add($"Troco em Moedas de {moeda} R$: " + moedasTroco.Where(x => x == moeda).Count().ToString());

        return valorTroco;
    }
}
