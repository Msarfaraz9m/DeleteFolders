using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RemoveFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoveUnwantedFileFromLocation(@"X:\");
        }

        private static void RemoveUnwantedFileFromLocation(string directory)
        {
            List<string> filesToRemove = new List<string> { "bin", "obj" };
            foreach (var item in Directory.EnumerateDirectories(directory))
            {
                if (filesToRemove.Any(y => item.Substring(item.LastIndexOf('\\') + 1) == y))
                    Directory.Delete(item, true);
                else
                    RemoveUnwantedFileFromLocation(item);
            }
        }
    }
}
