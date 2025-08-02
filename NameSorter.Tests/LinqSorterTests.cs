using System.Linq;
using NameSorter.SortingStrategies;

namespace NameSorter.Tests
{
    public class LinqSorterTests
    {
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
    }
}
