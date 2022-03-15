using System.ComponentModel.DataAnnotations;

namespace TheBillboard.Models;
public record Message(
    [Required(ErrorMessage = "Il campo titolo e' obbligatorio"), MinLength(4, ErrorMessage = "Il campo titolo deve essere lungo almeno 4 caratteri")]
    string Title, 
    [Required(ErrorMessage = "Il campo body e' obbligatorio"), MinLength(4, ErrorMessage = "Il campo body deve essere lungo almeno 4 caratteri")]
    string Body,
    [Required(ErrorMessage = "Il campo autore e' obbligatorio"), MinLength(1, ErrorMessage = "Il campo autore deve essere lungo almeno 1 carattere")]
    string Author, 
    DateTime? CreatedAt = default,
    DateTime? UpdatedAt = default, 
    int? Id = default)
{
    public DateTime? CreatedAt { get; set; } = CreatedAt;
    public DateTime? UpdatedAt { get; set; } = UpdatedAt;
    public int? Id { get; set; } = Id;

    public string FormattedCreatedAt => CreatedAt.HasValue 
        ? CreatedAt.Value.ToString("yyyy-MM-dd HH:mm") 
        : string.Empty;
    
    public string FormattedUpdatedAt => UpdatedAt.HasValue 
        ? UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm")
        : string.Empty;
}