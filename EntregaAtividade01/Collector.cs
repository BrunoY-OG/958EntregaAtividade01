using System.Globalization;
using CsvHelper;
namespace Cs958 {
    internal class Collector {
        internal static readonly string PathToMatriz = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            "matriz.txt");

        internal static readonly string PathToCaminho = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            "caminho.txt");


        internal static bool ColetaMatriz(out int[,]? matriz) {
            try {
                using var reader = new StreamReader(PathToMatriz);
                using var csv = new CsvParser(reader, CultureInfo.InvariantCulture);
                if ((csv is null) || (!csv.Read())) {
                    matriz = default;
                    return false;
                }
                var numColunas = csv.Record.Length;
                matriz = new int[numColunas, numColunas];
                for (int i = 0; i < numColunas; i++) {
                    var linha = csv.Record;
                    for (int j = 0; j < numColunas; j++) {
                        matriz[i, j] = int.Parse(linha[j]);
                    }
                    csv.Read();
                }
            }
            catch {
                Console.WriteLine($"Erro coletando matriz.");
                matriz = default;
                return false;
            }            
            return true;
        }

        internal static bool ColetaCaminho(out int[]? caminho) {
            try {
                using var reader = new StreamReader(PathToCaminho);
                using var csv = new CsvParser(reader, CultureInfo.InvariantCulture);
                if (!csv.Read()) {
                    caminho = default;
                    return false;
                }
                var numColunas = csv.Record.Length;
                caminho = new int[numColunas];
                var linha = csv.Record;
                for (int i = 0; i < numColunas; i++) {
                    caminho[i] = int.Parse(linha[i]);
                }
            }
            catch {
                Console.WriteLine($"Erro coletando caminho.");
                caminho = default;
                return false;
            }
            return true;
        }

        internal static bool CalculaDistancia(int[,] distancias, int[] rota, out int distanciaTotal) {
            distanciaTotal = 0;
            for (int cidade = 0; cidade < rota.Length - 1; cidade++) {
                if (rota[cidade + 1] > distancias.GetLength(0)) {
                    Console.WriteLine($"Erro processando a rota:{Environment.NewLine}" +
                                      $"    A cidade número {rota[cidade + 1]} não existe.");
                    return false;
                }
                distanciaTotal += distancias[rota[cidade] - 1, rota[cidade + 1] - 1];
            }
            return true;
        }

    }
}
