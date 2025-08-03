using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.FileServices
{
    public class FileHandler
    {
        public IEnumerable<string> ReadLines(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be blank.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            var lines = File.ReadAllLines(filePath)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x));

            if (lines.Count() < 1)
                throw new Exception("File has no readable content.");

            return lines;
        }
    }
}
