using TheBillboard.Models;

namespace TheBillboard.Abstract
{
    public interface IAuthorGateway
    {
        int RequestId();
        IEnumerable<Author> GetAll();
        Author? GetById(int id);
        Author Create(Author author);
        Author Update(Author author);
        void Delete(int id);
    }
}
