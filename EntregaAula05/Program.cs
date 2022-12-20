using System;

namespace Cs958 {
    public class exercicio {
        public static void Main() {            
            if (!Collector.ColetaMatriz(out int[,]? distancias)) return;
            if (!Collector.ColetaCaminho(out var caminho)) return;
            if (Collector.CalculaDistancia(distancias, caminho, out int totalDistancia))
                Console.WriteLine($"A distância total é de {totalDistancia} km.");
        }
    }
}