using TheBillboard.Models;

namespace TheBillboard.ViewModels
{
    public record MessageAndAuthors(Message Message, Dictionary<int, Author> Authors)
    {

    }
}
