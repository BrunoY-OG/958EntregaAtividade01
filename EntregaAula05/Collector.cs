using System;

namespace Cs958 {
    internal class Collector {
        internal static bool ColetaLinha(out int[] listaNumeros) {
            string? linhaLida = Console.ReadLine();
            while ((linhaLida is null) || (linhaLida == string.Empty)) {
                Console.WriteLine($"Erro: linha vazia.");
                Console.Write($"Por favor, entre com a lista separada por ',':");
                linhaLida = Console.ReadLine();
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
            Console.WriteLine("Por favor, entre com a matriz:");
            if (!ColetaLinha(out var linhaLida)) {
                matriz = default; 
                return false;
            }
            int qntdCol = linhaLida.Length;
            matriz = new int[qntdCol, qntdCol];
            if (!ConverteuListaParaLinhadaMatriz(matriz, 0, linhaLida)) {
                matriz = default;
                return false;
            }
            for (int iLinha = 1; iLinha < qntdCol; iLinha++) {
                if (!ColetaLinha(out linhaLida)) {
                    matriz = default;
                    return false;
                }
                if (!ConverteuListaParaLinhadaMatriz(matriz, iLinha, linhaLida)) {
                    matriz = default;
                    return false;
                }
            }
            return true;
        }

        internal static bool ColetaCaminho(out int[]? caminho) {
            Console.WriteLine("Entre com o caminhho:");
            if (!ColetaLinha(out caminho)) return false;
            return true;
        }

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
                if (rota[cidade + 1] >= distancias.GetLength(0)) {
                    Console.WriteLine($"Erro processando a rota:{Environment.NewLine}" +
                                      $"    A cidade número {rota[cidade + 1]} não existe.");
                    return false;
                }
                distanciaTotal += distancias[rota[cidade], rota[cidade + 1]];
            }
            return true;
        }

    }
}
