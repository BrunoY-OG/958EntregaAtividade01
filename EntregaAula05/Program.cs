using System;

namespace Cs958 {
    public class exercicio {
        public static void Main() {            
            int[,]? distancias = Utils.ColetaMatriz();
            if (distancias is null) return;
            Console.WriteLine("Entre com a rota:");
            if (!Utils.ColetaLinha(out var rota)) return;
            int totalDistancia = Utils.CalculaDistancia(distancias, rota);
            if (totalDistancia >= 0) {
                Console.WriteLine($"A distância total é de {totalDistancia} km.");
            }
        }
    }
}