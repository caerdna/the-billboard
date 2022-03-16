using TheBillboard.Abstract;
using TheBillboard.Models;

namespace TheBillboard.Gateways;



public class AuthorsGateway : IAuthorGateway
{
    private int _lastId = 2;
    private Dictionary<int, Author> _authors = new Dictionary<int, Author>()
    {
        {1, new("Mario", "Rossi", "mariorossi@gmail.com", DateTime.Now.AddHours(-4), DateTime.Now.AddHours(-3),1) },
        {2, new("Diego ", "Bianco", "diegoBianco@gmail.com", DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1),2) },
    };


    public int RequestId()
    {
        _lastId++;
        return _lastId;
    }

    public Dictionary<int, Author> GetAll() => _authors;

    public Author? GetById(int id) => _authors.ContainsKey(id) ? _authors[id] : new Author("Error", "author retrieval failed", "");

    public Author Create(Author author)
    {
        if (!_authors.ContainsKey((int)author.Id))
        {
            _authors.Add((int)author.Id, author);
            return author;
        }
        else
            return new Author("Error", "author creation failed", "");
    }

    public void Delete(int id) => _authors.Remove(id);

    public Author Update(Author author)
    {
        _authors[(int)author.Id] = author;
        return author;
    }


}