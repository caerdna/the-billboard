using System.ComponentModel.DataAnnotations;


namespace TheBillboard.Models
{
    public record Author(
    [Required(ErrorMessage = "Il campo nome e' obbligatorio"), MinLength(4, ErrorMessage = "Il campo nome deve essere lungo almeno 4 caratteri")]
    string Name,
    [Required(ErrorMessage = "Il campo cognome e' obbligatorio"), MinLength(4, ErrorMessage = "Il campo cognome deve essere lungo almeno 4 caratteri")]
    string Surname,
    [Required(ErrorMessage = "Il campo email e' obbligatorio"), MinLength(4, ErrorMessage = "Il campo cognome deve essere lungo almeno 4 caratteri")]
    string Email,
    DateTime? CreatedAt = default,
    DateTime? UpdatedAt = default,
    int? IdAuthor = default)
    {
        public int? Id { get; set; } = IdAuthor;
    }
}
