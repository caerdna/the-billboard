using TheBillboard.Abstract;
using TheBillboard.Models;

namespace TheBillboard.Gateways;

public class MessageGateway : IMessageGateway
{
    private int _lastId = 2;
    private ICollection<Message> _messages = new List<Message>()
    {
        new("Hello  World!", "What A Wonderful World!", "Alberto", DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1), 1),
        new("Hello  World!", "What A Wonderful World!", "Alberto", DateTime.Now, DateTime.Now, 2),
    };

    public int RequestId()
    {
        _lastId++;
        return _lastId;
    }

    public IEnumerable<Message> GetAll() => _messages;

    public Message? GetById(int id) => _messages.SingleOrDefault(message => message.Id == id);

    public Message Create(Message message)
    {
        if (!_messages.Any(item => message.Id == item.Id))
        {
            _messages.Add(message);
            return message;
        }
        else
            return null;
    }

    public void Delete(int id) =>
        _messages = _messages
            .Where(message => message.Id != id)
            .ToList();

    public Message Update(Message message)
    {
        Delete((int)message.Id);
        _messages.Add(message);
        return message;
    }


}

  