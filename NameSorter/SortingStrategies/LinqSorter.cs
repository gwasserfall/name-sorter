using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.SortingStrategies
{
    /// <summary>
    /// A very simple sorter using Linq OrderBy, surname is moved to front of the name
    /// all spaces removed and the entire string converted to lowercase, this is used as the key to sort by.
    /// </summary>
    public class LinqSorter : ISortingStrategy
    {
        public IEnumerable<string> Sort(IEnumerable<string> unsorted)
        {
            if (unsorted == null || unsorted.Count() < 1)
                throw new Exception("Nothing to sort.");

            return unsorted.OrderBy(GetSortingKey);
        }

        private string GetSortingKey(string name) 
        {
            var split = name.ToLowerInvariant().Split(' ');

            var lastName = split.Last();
            var givenNames = string.Join("", split.Take(split.Length - 1));

            return $"{lastName}{givenNames}";
        }
    }
}
