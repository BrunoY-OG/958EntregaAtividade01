using System;

namespace Cs958 {
    internal class FileSystem {
        internal static string MatrizPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                "matriz.txt");
        internal static string CaminhoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                "caminho.txt");


    }
}
