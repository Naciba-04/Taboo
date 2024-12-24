using Taboo.Entities;

namespace Taboo.DTOs.Words;

public class WordUpdateDto
{
    public string Text { get; set; }
    public Language Language { get; set; }
    public ICollection<string> BannedWords { get; set; }
}
