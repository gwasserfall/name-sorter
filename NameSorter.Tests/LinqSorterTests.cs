using System.Linq;
using System.Reflection;
using System.Text;
using NameSorter.SortingStrategies;

namespace NameSorter.Tests
{
    public class LinqSorterTests
    {
        private string[] LoadTestNames(string fileName)
        {
            var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var solutionRoot = Path.GetFullPath(Path.Combine(assemblyDir, "../../../.."));
            var filePath = Path.Combine(solutionRoot, "NameLists", fileName);
            return File.ReadAllLines(filePath, Encoding.UTF8);
        }


        [Fact]
        public void Sort_CalledWithEmptyCollection_ThrowsException()
        {
            string[] empty = [];

            LinqSorter sorter = new LinqSorter();

            var ex = Assert.Throws<Exception>(() => 
            { 
                var sorted = sorter.Sort(empty);            
            });

            Assert.Equal("Nothing to sort.", ex.Message);
        }

        [Fact]
        public void Sort_LastNamesOnly_SortsCorrectly()
        {
            string[] unsorted = ["Wasserfall", "Mardon"];
            string[] expected = ["Mardon", "Wasserfall"];

            LinqSorter sorter = new LinqSorter();

            var sorted = sorter.Sort(unsorted);
            
            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void Sort_SimpleSortOutputsExpectedResult() 
        {
            string[] unsorted = 
                 [
                    "Janet Parsons",
                    "Vaughn Lewis",
                    "Adonis Julius Archer",
                    "Shelby Nathan Yoder",
                    "Marin Alvarez",
                    "London Lindsey",
                    "Beau Tristan Bentley",
                    "Leo Gardner",
                    "Hunter Uriah Mathew Clarke",
                    "Mikayla Lopez",
                    "Frankie Conner Ritter"
                ];

            string[] expected =
                [
                    "Marin Alvarez",
                    "Adonis Julius Archer",
                    "Beau Tristan Bentley",
                    "Hunter Uriah Mathew Clarke",
                    "Leo Gardner",
                    "Vaughn Lewis",
                    "London Lindsey",
                    "Mikayla Lopez",
                    "Janet Parsons",
                    "Frankie Conner Ritter",
                    "Shelby Nathan Yoder"
                ];

            LinqSorter sorter = new LinqSorter();

            var sorted = sorter.Sort(unsorted);

            Assert.Equal(expected, sorted);
        }


        [Fact]
        public void Sort_VerySimilarNamesGetSortedCorrectly()
        {
            string[] unsorted =
                [
                    "Hunter Uriah Mathew Clarke",
                    "Hunter Uriah Mathews Clarke",
                    "Hunter Uriah Marthews Clarke",
                    "Hunter Uariah Marthews Clarke",
                ];

            string[] expected =
                [
                    "Hunter Uariah Marthews Clarke",
                    "Hunter Uriah Marthews Clarke",
                    "Hunter Uriah Mathew Clarke",
                    "Hunter Uriah Mathews Clarke",
                ];

            LinqSorter sorter = new LinqSorter();

            var sorted = sorter.Sort(unsorted);

            Assert.Equal(expected, sorted.ToArray());
        }

        [Fact]
        public void Sort_BaselineSortedCorrectly()
        {
            string[] unsorted = LoadTestNames("baseline-unsorted.txt");

            string[] expected = LoadTestNames("baseline-sorted.txt");

            LinqSorter sorter = new LinqSorter();

            var sorted = sorter.Sort(unsorted);

            Assert.Equal(expected, sorted.ToArray());
        }

        [Fact]
        public void Sort_OneThousandSortedCorrectly()
        {
            string[] unsorted = LoadTestNames("1000-unsorted.txt");

            string[] expected = LoadTestNames("1000-sorted.txt");

            LinqSorter sorter = new LinqSorter();

            var sorted = sorter.Sort(unsorted);

            Assert.Equal(expected, sorted.ToArray());
        }
    }
}
