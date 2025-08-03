using NameSorter.FileServices;

namespace NameSorter.Tests
{
    public class FileHandlerTests
    {
        [Fact]
        public void ReadLinesCalledWithBadPath_ShouldThrowFileNotFoundException()
        {
            var fileHandler = new FileHandler();

            Assert.Throws<FileNotFoundException>(() => fileHandler.ReadLines("/fake/file/path.txt"));
        }

        [Fact]
        public void ReadLinesCalledWithEmptyPath_ShouldThrowArgumentException()
        {
            var fileHandler = new FileHandler();

            Assert.Throws<ArgumentException>(() => fileHandler.ReadLines(""));
        }

        [Fact]
        public void ReadLines_HandlesUnicodeCharacters()
        {
            var fileHandler = new FileHandler();

            var tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath,
                [
                    "Robert O’Martin"
                ]
            );

            var lines = fileHandler.ReadLines(tempFilePath);

            Assert.Equal("Robert O’Martin", lines.ElementAt(0));
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

        [Fact]
        public void ReadLines_ThrowsExceptionIfFileIsEmpty()
        {
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, [" "]);

            var fileHandler = new FileHandler();

            Assert.Throws<Exception>(() => 
            { 
                var lines = fileHandler.ReadLines(tempFilePath);
            
            });

            File.Delete(tempFilePath);
        }
    }
}