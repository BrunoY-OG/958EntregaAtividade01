using System.IO;

namespace Cs958 {
    internal class FileHandler {
        internal static readonly string PathToMatriz = Path.Combine( 
                            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            "matriz.txt");

        internal static readonly string PathToCaminho = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            "caminho.txt");

        internal static string? Load(string path) {
            try {
                return  File.ReadAllText(path);
            }
            catch {
                return null;
            }
        }

    }
}
