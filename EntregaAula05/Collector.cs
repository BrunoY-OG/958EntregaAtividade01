namespace Cs958 {
    internal class Collector {
        internal static bool ColetaLinha(string? linhaLida, out int[]? listaNumeros) {
            if ((linhaLida is null) || (linhaLida == string.Empty)) {
                Console.WriteLine($"Erro processando linha: linha vazia.");
                listaNumeros = default;
                return false;
            }
            string[] listaLinha = linhaLida.Split(",");
            listaNumeros = new int[listaLinha.Length];
            for (int iC1 = 0; iC1 < listaLinha.Length; iC1++) {
                if (!int.TryParse(listaLinha[iC1], out listaNumeros[iC1])) {
                    Console.WriteLine($"Erro processando linha na coluna {iC1}:{Environment.NewLine}" +
                                      $"    TryParse retornou false.");
                    return false;
                }
            }
            return true;
        }
        internal static bool ColetaMatriz(out int[,]? matriz) {
            string? matrizLida = FileHandler.Load(FileHandler.PathToMatriz);
            if ((matrizLida is null) || (matrizLida == string.Empty)) {
                Console.WriteLine($"Erro processando matriz: arquivo vazio.");
                matriz = default;
                return false;
            }
            string[] linhasMatriz = matrizLida.Split(Environment.NewLine);
            if (!ColetaLinha(linhasMatriz[0], out int[]? numerosLidos)) {
                matriz = default; 
                return false;
            }
            int qntdCol = numerosLidos.Length;
            matriz = new int[qntdCol, qntdCol];
            if (!ConverteuListaParaLinhadaMatriz(matriz, 0, numerosLidos)) {
                matriz = default;
                return false;
            }
            for (int iLinha = 1; iLinha < qntdCol; iLinha++) {
                if (!ColetaLinha(linhasMatriz[iLinha], out numerosLidos)) {
                    matriz = default;
                    return false;
                }
                if (!ConverteuListaParaLinhadaMatriz(matriz, iLinha, numerosLidos)) {
                    matriz = default;
                    return false;
                }
            }
            return true;
        }

        internal static bool ColetaCaminho(out int[]? caminho) =>
            ColetaLinha(FileHandler.Load(FileHandler.PathToCaminho), out caminho);

        internal static bool ConverteuListaParaLinhadaMatriz(int[,] matriz, int currentLine, int[] listaNumeros) {
            if (listaNumeros.Length > matriz.GetLength(0)) {
                Console.WriteLine($"Erro processando matriz na linha {currentLine}:{Environment.NewLine}" +
                                  $"    há mais elementos lidos do que a linha comporta.");
                return false;
            }
            for (int iC1 = currentLine + 1; iC1 < listaNumeros.Length; iC1++) {
                matriz[currentLine, iC1] = listaNumeros[iC1];
                matriz[iC1, currentLine] = listaNumeros[iC1];
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
