using System.IO;

namespace GlobalStrings.Utils
{
    internal static class Checkers
    {
        internal static bool CheckJsonFileExtension(string filepath) => Path.GetExtension(filepath) == ".json";
    }
}