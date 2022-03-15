using System.ComponentModel.DataAnnotations;


namespace TheBillboard.Models
{
    public record Author(
    [Required(ErrorMessage = "Il campo nome e' obbligatorio"), MinLength(4, ErrorMessage = "Il campo nome deve essere lungo almeno 4 caratteri")]
    string Name,
    [Required(ErrorMessage = "Il campo cognome e' obbligatorio"), MinLength(4, ErrorMessage = "Il campo cognome deve essere lungo almeno 4 caratteri")]
    string Surname,
    int? Id = default)
    {
        public int? Id { get; set; } = Id;
    }
}
