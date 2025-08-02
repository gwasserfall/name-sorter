using NameSorter.CommandLine;

namespace NameSorter.Tests
{
    public class CommandLineArgsTests
    {
        [Fact]
        public void WhenParseCalledWithNoArgs_ShouldThrowArgumentExceptionWithMessage()
        {
            var cmdArgs = new CommandLineArgs();

            var exception = Assert.Throws<ArgumentException>(() => 
            { 
                cmdArgs.Parse([]);
            });

            Assert.Equal("Missing file path.", exception.Message);
        }

        [Fact]
        public void WhenParseCalledWithOneArg_ShouldReturnOptionsWithFilePath()
        {
            var cmdArgs = new CommandLineArgs();

            var cmdOptions = cmdArgs.Parse(["/a/file/path.txt"]);

            Assert.Equal("/a/file/path.txt", cmdOptions.FilePath);
        }
    }
}