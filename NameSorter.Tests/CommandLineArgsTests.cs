using NameSorter.CommandLine;

namespace NameSorter.Tests
{
    public class CommandLineArgsTests
    {
        [Fact]
        public void Parse_CalledWithNoArgs_ShouldThrowArgumentExceptionWithMessage()
        {
            var cmdArgs = new CommandLineArgs();

            var exception = Assert.Throws<ArgumentException>(() => 
            { 
                cmdArgs.Parse([]);
            });

            Assert.Equal("No file path provided.\n\nUsage: ./name-sorter.exe <path-to-name-list.txt>", exception.Message);
        }

        [Fact]
        public void Parse_CalledWithOneArg_ShouldReturnOptionsWithFilePath()
        {
            var cmdArgs = new CommandLineArgs();

            var cmdOptions = cmdArgs.Parse(["/a/file/path.txt"]);

            Assert.Equal("/a/file/path.txt", cmdOptions.FilePath);
        }
    }
}