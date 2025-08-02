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
                throw new ArgumentException("Missing file path.");

            return new() { FilePath = args[0] };
        }
    }
}
