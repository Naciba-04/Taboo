using Taboo.Entities;

namespace Taboo.DTOs.Words;

public class WordGetDto
{
    public string Text { get; set; }
    public Language Language { get; set; }
    public IEnumerable<string> BannedWords { get; set; }

}
