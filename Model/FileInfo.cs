namespace XML_Cleaner.Model;

public class FileInformation
{
    // file path with file name at the end of the path string
    public string? FullPath { get; set; } = string.Empty;
    // file path without file name at the end of the path string
    public string? Path { get; set; } = string.Empty;
    // get in bytes and convert in necessary value if needed in output
    public ulong FileSize { get; set; } = 0;
    // file name
    public string? FileName { get; set; } = string.Empty;
    // file content
    public string? FileContent { get; set; } = string.Empty;
}