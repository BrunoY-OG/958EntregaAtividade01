using System;

namespace Cs958 {
    public class exercicio1 {
        public static void Main() {
            
            bool ColetaLinha(out int[] listaNumeros) {
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

            bool ConverteuListaParaLinhadaMatriz(int[,] matriz, int currentLine, int[] listaNumeros) {
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

            int[,]? ColetaMatriz() {
                Console.WriteLine("Por favor, entre com a matriz:");
                if (!ColetaLinha(out var linhaLida)) return default;
                int qntdCol = linhaLida.Length;
                int[,] matriz = new int[qntdCol,qntdCol];
                if (!ConverteuListaParaLinhadaMatriz(matriz, 0, linhaLida)) return default;
                for (int iLinha = 1; iLinha < qntdCol; iLinha++) {
                    if (!ColetaLinha(out linhaLida)) return default;
                    if (!ConverteuListaParaLinhadaMatriz(matriz, iLinha, linhaLida)) return default;
                }
                return matriz;
            }

            int CalculaDistancia(int[,] distancias, int[] rota) {
                var distanciaTotal = 0;
                for (int cidade = 0; cidade < rota.Length - 1; cidade++) {
                    if (rota[cidade + 1] >= distancias.GetLength(0)) {
                        Console.WriteLine($"Erro processando a rota:{Environment.NewLine}" +
                                          $"    A cidade número {rota[cidade + 1]} não existe.");
                        return -1;
                    }
                    distanciaTotal += distancias[rota[cidade], rota[cidade + 1]];
                }
                return distanciaTotal;
            }


            int[,]? distancias = ColetaMatriz();
            if (distancias is null) return;
            Console.WriteLine("Entre com a rota:");
            if (!ColetaLinha(out var rota)) return;
            int totalDistancia = CalculaDistancia(distancias, rota);
            if (totalDistancia >= 0) {
                Console.WriteLine($"A distância total é de {totalDistancia} km.");
            }
        }
    }
}