namespace XML_Cleaner.Model;

public class FileInfo
{
    // file path with file name at the end of the path string
    public string? FullPath { get; set; }
    // file path without file name at the end of the path string
    public string? Path { get; set; }
    // get in bytes and convert in necessary value if needed in output
    public long FileSize  { get; set; }
    // file name
    public string? FileName { get; set; }
}