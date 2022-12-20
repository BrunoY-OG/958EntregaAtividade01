using System;

namespace Cs958 {
    public class exercicio {
        public static void Main() {            
            if (!Utils.ColetaMatriz(out int[,]? distancias)) return;
            if (!Utils.ColetaCaminho(out var caminho)) return;
            if (Utils.CalculaDistancia(distancias, caminho, out int totalDistancia))
                Console.WriteLine($"A distância total é de {totalDistancia} km.");
        }
    }
}