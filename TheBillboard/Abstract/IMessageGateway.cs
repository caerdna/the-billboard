using TheBillboard.Models;

namespace TheBillboard.Abstract;

public interface IMessageGateway
{
    int RequestId();
    IEnumerable<Message> GetAll();
    Message? GetById(int id);
    Message Create(Message message);
    Message Update(Message message);
    void Delete(int id);
}