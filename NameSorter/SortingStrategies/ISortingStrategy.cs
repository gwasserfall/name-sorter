namespace NameSorter.SortingStrategies
{
    public interface ISortingStrategy
    {
        public IEnumerable<string> Sort(IEnumerable<string> unsorted);
    }
}
