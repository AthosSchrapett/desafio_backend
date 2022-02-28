namespace desafio_backend.Endpoints;

public class DefineTroco
{
    public static double DefineInfoTroco(double valorTotal, double valorPago, List<string> notasInfo, List<string> moedasInfo)
    {
        List<double> notas = new List<double> { 10.00, 20.00, 50.00, 100.00 };
        List<double> moedas = new List<double> { 0.01, 0.05, 0.10, 0.50 };

        List<double> notasTroco = new();
        List<double> moedasTroco = new();

        double valorTroco = Math.Round(valorPago - valorTotal, 2);

        double trocoRetirado = valorTroco;
        double trocoParaSepararNotas = trocoRetirado;

        do
        {
            var notasMaiores = notas.Where(x => x <= trocoRetirado);

            foreach (double nota in notasMaiores.Reverse())
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

        } while (trocoParaSepararNotas >= 10);

        do
        {
            var moedasMaiores = moedas.Where(x => x <= trocoRetirado);

            foreach (double moeda in moedasMaiores.Reverse())
            {
                if (moeda == (trocoRetirado - moeda) || moeda == moedas.Where(x => x <= trocoRetirado).Reverse().First())
                {
                    trocoRetirado = Math.Round(trocoRetirado - moeda, 2);
                    moedasTroco.Add(Math.Round(moeda, 2));
                    break;
                }
            }

        } while (trocoRetirado > 0);

        foreach (double nota in notasTroco.Distinct())
            notasInfo.Add($"Troco em Notas de {nota} R$: {notasTroco.Where(x => x == nota).Count()}");
        foreach (double moeda in moedasTroco.Distinct())
            moedasInfo.Add($"Troco em Moedas de {moeda} R$: {moedasTroco.Where(x => x == moeda).Count()}");

        return valorTroco;
    }
}
