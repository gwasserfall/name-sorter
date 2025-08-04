using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.CommandLine
{
    public class CommandLineArgs
    {
        public Options Parse(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("No file path provided.\n\nUsage: ./name-sorter.exe <path-to-name-list.txt>");

            return new() { FilePath = args[0] };
        }
    }
}
