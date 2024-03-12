namespace Barrent.Common.Extensions;

/// <summary>
/// Extends <see cref="DirectoryInfo"/>
/// </summary>
public static class DirectoryInfoExtensions
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
    /// </summary>
    /// <param name="sourceDirectory">Directory to copy.</param>
    /// <param name="destPath">Destination path.</param>
    /// <param name="recursive">Indicates if subdirectories should be copied as well.</param>
    /// <exception cref="DirectoryNotFoundException"></exception>
    public static void CopyDirectory(this DirectoryInfo sourceDirectory, string destPath, bool recursive)
    {
        // Check if the source directory exists
        if (!sourceDirectory.Exists)
            throw new DirectoryNotFoundException($"Source directory not found: {sourceDirectory.FullName}");

        // Cache directories before we start copying
        var dirs = sourceDirectory.GetDirectories();

        // Create the destination directory
        Directory.CreateDirectory(destPath);

        // Get the files in the source directory and copy to the destination directory
        foreach (var file in sourceDirectory.GetFiles())
        {
            var targetFilePath = Path.Combine(destPath, file.Name);
            file.CopyTo(targetFilePath);
        }

        // If recursive and copying subdirectories, recursively call this method
        if (recursive)
        {
            foreach (var subDir in dirs)
            {
                var newDestinationDir = Path.Combine(destPath, subDir.Name);
                CopyDirectory(subDir, newDestinationDir, true);
            }
        }
    }
}