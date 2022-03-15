using Microsoft.AspNetCore.Mvc;
using TheBillboard.Abstract;
using TheBillboard.Models;

namespace TheBillboard.Controllers;

public class MessagesController : Controller
{
    private readonly IMessageGateway _messageGateway;
    private readonly ILogger<MessagesController> _logger;

    public MessagesController(IMessageGateway messageGateway, ILogger<MessagesController> logger)
    {
        _messageGateway = messageGateway;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var messages = _messageGateway.GetAll();
        return View(messages);
    }

    [HttpPost]
    public IActionResult Create(Message message)
    {


        if (message.Id is null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            message.CreatedAt = DateTime.Now;
            message.UpdatedAt = DateTime.Now;
            message.Id = _messageGateway.RequestId();
            _messageGateway.Create(message);
        }
        else
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }
            message.UpdatedAt = DateTime.Now;
            _messageGateway.Update(message);
        }

        _logger.LogInformation($"Message received: {message.Title}");
        return RedirectToAction("Index");

    }

    public IActionResult Detail(int id)
    {
        var message = _messageGateway.GetById(id);
        return View(message);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update(int id)
    {
        var message = _messageGateway.GetById(id);
        return View(message);
    }

    public IActionResult Delete(int id)
    {
        _messageGateway.Delete(id);
        return RedirectToAction("Index");
    }
}