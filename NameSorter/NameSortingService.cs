using NameSorter.CommandLine;
using NameSorter.FileServices;
using NameSorter.SortingStrategies;

namespace NameSorter
{
    public class NameSortingService
    {
        private readonly ISortingStrategy _sorter;
        private readonly FileHandler _fileHandler;

        public NameSortingService(FileHandler fileHandler, ISortingStrategy sorter)
        {
            _fileHandler = fileHandler;
            _sorter = sorter;
        }

        public void Run(Options options) 
        {
            var unsorted = _fileHandler.ReadLines(options.FilePath);

            var sorted = _sorter.Sort(unsorted);

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            foreach (var line in sorted)
            {
                Console.WriteLine(line);
            }

            File.WriteAllLines("sorted-names-list.txt", sorted);
        }
    }
}
