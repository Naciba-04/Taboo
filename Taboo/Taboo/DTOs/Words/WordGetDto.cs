using Taboo.Entities;

namespace Taboo.DTOs.Words;

public class WordGetDto
{
    public string Text { get; set; }
    public Language Language { get; set; }
    public HashSet<string> BannedWords { get; set; }

}
