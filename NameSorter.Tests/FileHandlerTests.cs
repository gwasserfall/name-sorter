using NameSorter.FileServices;

namespace NameSorter.Tests
{
    public class FileHandlerTests
    {
        string GetTempTxtFilePath() => Path.GetTempFileName() + ".txt";

        [Fact]
        public void ReadLines_CalledWithBadPath_ShouldThrowFileNotFoundException()
        {
            var fileHandler = new FileHandler();

            var ex = Assert.Throws<FileNotFoundException>(() => fileHandler.ReadLines("/fake/file/path.txt"));

            Assert.Equal("File not found.\n\nUsage: ./name-sorter.exe <path-to-name-list.txt>", ex.Message);
        }

        [Fact]
        public void ReadLines_CalledWithNonTxtExt_ThrowsException()
        {
            var fileHandler = new FileHandler();

            var ex = Assert.Throws<Exception>(() => fileHandler.ReadLines("./path.xlsx"));

            Assert.Equal("Invalid file extension. Only .txt files are supported.", ex.Message);
        }

        [Fact]
        public void ReadLines_CalledWithEmptyPath_ShouldThrowArgumentException()
        {
            var fileHandler = new FileHandler();

            Assert.Throws<ArgumentException>(() => fileHandler.ReadLines(""));
        }

        [Fact]
        public void ReadLines_HandlesUnicodeCharacters()
        {
            var fileHandler = new FileHandler();

            var tempFilePath = GetTempTxtFilePath();
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
            var tempFilePath = GetTempTxtFilePath();
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
            var tempFilePath = GetTempTxtFilePath();
            File.WriteAllLines(tempFilePath, [" "]);

            var fileHandler = new FileHandler();

            var ex = Assert.Throws<Exception>(() => 
            { 
                var lines = fileHandler.ReadLines(tempFilePath);
            
            });

            Assert.Equal("Provided file does not contain any names.", ex.Message);

            File.Delete(tempFilePath);
        }
    }
}