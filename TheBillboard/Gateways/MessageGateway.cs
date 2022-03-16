using TheBillboard.Abstract;
using TheBillboard.Models;

namespace TheBillboard.Gateways;

public class MessageGateway : IMessageGateway
{
    private int _lastId = 2;
    private Dictionary<int, Message> _messages = new Dictionary<int, Message>()
    {
        {1, new("Hello  World!", "What A Wonderful World!",1, DateTime.Now.AddHours(-4), DateTime.Now.AddHours(-3), 1) },
        {2, new("Hello  World!", "What A Wonderful World!",1, DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1), 2) },
    };

    public int RequestId()
    {
        _lastId++;
        return _lastId;
    }

    public IEnumerable<Message> GetAll() => _messages.Values;

    public Message GetById(int id) => _messages.ContainsKey(id) ? _messages[id] : new Message("Error", "message retrieval failed", 0);

    public Message Create(Message message)
    {
        if (!_messages.ContainsKey((int)message.Id))
        {
            _messages.Add((int)message.Id, message);
            return message;
        }
        else
            return new Message("Error", "message creation failed", 0);
    }

    public void Delete(int id) => _messages.Remove(id);

    public Message Update(Message message)
    {
        _messages[(int)message.Id] = message;
        return message;
    }


}

  