using System.IO;

namespace WriterTest.Extensions
{
    internal static class TestExtensions
    {
        #region Public Methods

        public static string GetPath(this string relativeSchemaPath)
        {
            var solutionDirectory = GetSolutionDirectoryInfo().FullName;

            var result = Path.Combine(
                path1: solutionDirectory,
                path2: relativeSchemaPath);

            return result;
        }

        #endregion Public Methods

        #region Private Methods

        private static DirectoryInfo GetSolutionDirectoryInfo(string currentPath = default)
        {
            currentPath ??= Directory.GetCurrentDirectory();

            var result = new DirectoryInfo(currentPath);

            while ((result?.GetFiles("*.sln").Length ?? 0) == 0
                && result.Parent != default)
            {
                result = result.Parent;
            }

            return result;
        }

        #endregion Private Methods
    }
}