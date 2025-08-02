using NameSorter.CommandLine;
using NameSorter.FileServices;
using NameSorter.SortingStrategies;

namespace NameSorter
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var argsParser = new CommandLineArgs();
                var options = argsParser.Parse(args);

                var sorter = new LinqSorter();
                var fileHandler = new FileHandler();

                NameSortingService app = new(fileHandler, sorter);

                app.Run(options);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
