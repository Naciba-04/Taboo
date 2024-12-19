using Taboo.Entities;

namespace Taboo.DTOs.Words;

public class WordGetDto
{
    public string Text { get; set; }
    public Language Language { get; set; }
    public ICollection<BannedWord> BannedWords { get; set; }
}
