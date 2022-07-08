namespace Rosetta;

[DebuggerDisplay("{Name,nq} {Version.OriginalVersion,nq}")]
public sealed class Library
{
    public string Name { get; }
    public NuGetVersion Version { get; }
    public LibraryType Type { get; }
    public string? Sha512 { get; }
    public string? Path { get; }
    public bool? HasTools { get; }
    public ISet<string> Files { get; }

    public Library(
        string name, NuGetVersion version, LibraryType type,
        string? sha512, string? path, bool? hasTools,
        IEnumerable<string> files)
    {
        if (files is null)
        {
            throw new ArgumentNullException(nameof(files));
        }

        Name = name ?? throw new ArgumentNullException(nameof(name));
        Version = version ?? throw new ArgumentNullException(nameof(version));
        Type = type;
        Sha512 = sha512;
        Path = path;
        HasTools = hasTools;
        Files = new HashSet<string>(files);
    }
}