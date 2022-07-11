using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopNews;
public class TopNewsItem
{
    public int Id { get; set; }

    [MaxLength(128),MinLength(1)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(128)]
    public string Author { get; set; } = string.Empty;
    
    [MaxLength(Int16.MaxValue)]
    public string Text { get; set; } = string.Empty;

    [Required]
    public DateTimeOffset PublicationDate { get; set; }

    public DateTimeOffset CreatedDate {get;set;} = DateTimeOffset.Now;
}