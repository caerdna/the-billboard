using TheBillboard.Models;

namespace TheBillboard.Abstract;

    public interface IAuthorGateway
    {
        int RequestId();
        Dictionary<int,Author> GetAll();
        Author? GetById(int id);
        Author Create(Author author);
        Author Update(Author author);
        void Delete(int id);
    }

