using NameSorter.FileServices;

namespace NameSorter.Tests
{
    public class FileHandlerTests
    {
        [Fact]
        public void WhenReadLinesCalledWithBadPath_ShouldThrowFileNotFoundException()
        {
            var fileHandler = new FileHandler();

            Assert.Throws<FileNotFoundException>(() => fileHandler.ReadLines("/fake/file/path.txt"));
        }

        [Fact]
        public void WhenReadLinesCalledWithEmptyPath_ShouldThrowArgumentException()
        {
            var fileHandler = new FileHandler();

            Assert.Throws<ArgumentException>(() => fileHandler.ReadLines(""));
        }

        [Fact]
        public void ReadLines_ReturnsTrimmedNonEmptyLines()
        {
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, 
                [
                    "Robert Martin",
                    " Bob Martin ",
                    " ",
                    "  "
                ]
            );

            var fileHandler = new FileHandler();

            var lines = fileHandler.ReadLines(tempFilePath);

            Assert.Equal(2, lines.Count());
            Assert.Equal("Robert Martin", lines.ElementAt(0));
            Assert.Equal("Bob Martin", lines.ElementAt(1));

            File.Delete(tempFilePath);
        }
    }
}