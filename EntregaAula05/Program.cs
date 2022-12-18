using System;
namespace Cs958 {
    public class exercicio1 {
        private static void ColetaInput(string pergunta, out int valor) {
            Console.Write($"{pergunta} : ");
            while ((!int.TryParse(Console.ReadLine(), out valor))
                    || (valor < 0)) {
                Console.WriteLine("     Valor inválido.");
                Console.Write("     Entre com um valor válido: ");
            }
        }

        private int[,] ColetaMatrizQuadrada(int tamanho) {
            int[,] result = new int[tamanho, tamanho];
            for (int iC1 = 0; iC1 < tamanho; iC1++) {
                for (int iC2 = iC1 + 1; iC2 < tamanho; iC2++) {
                    ColetaInput($"Qual a distância de {iC1} para {iC2}?", out int distancia);
                    result[iC1, iC2] = distancia;
                    result[iC2, iC1] = distancia;
                }
            }
            return result;
        }
        

    }
}