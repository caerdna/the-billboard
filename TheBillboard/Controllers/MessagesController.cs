using Microsoft.AspNetCore.Mvc;
using TheBillboard.Abstract;
using TheBillboard.Models;
using TheBillboard.ViewModels;

namespace TheBillboard.Controllers;

public class MessagesController : Controller
{
    private readonly IMessageGateway _messageGateway;
    private readonly IAuthorGateway _authorGateway;
    private readonly ILogger<MessagesController> _logger;


    public MessagesController(IMessageGateway messageGateway, IAuthorGateway authorGateway, ILogger<MessagesController> logger)
    {
        _messageGateway = messageGateway;
        _authorGateway = authorGateway;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var messages = _messageGateway.GetAll();
        return View(messages);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var viewmodel = new MessageAndAuthors(null, _authorGateway.GetAll());
        return View(viewmodel);
    }

    [HttpPost]
    public IActionResult Create(MessageAndAuthors viewmodel)
    {
        var message = viewmodel.Message;
        /*
        if (!ModelState.IsValid)
        {
            return View();
        }
        */
        message.CreatedAt = DateTime.Now;
        message.UpdatedAt = DateTime.Now;
        message.Id = _messageGateway.RequestId();
        _messageGateway.Create(message);

        _logger.LogInformation($"Message received: {message.Title}");
        return RedirectToAction("Index");

    }

    public IActionResult Detail(int id)
    {
        var myView = new MessageAndAuthors(_messageGateway.GetById(id), _authorGateway.GetAll());
        return View(myView);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var message = _messageGateway.GetById(id); 
        var viewmodel = new MessageAndAuthors(message, _authorGateway.GetAll());
        return View(viewmodel);
    }

    [HttpPost]
    public IActionResult Update(MessageAndAuthors viewmodel)
    {
        var message = viewmodel.Message;
        /*
        if (!ModelState.IsValid)
        {
            return View();
        }
        */
        message.UpdatedAt = DateTime.Now;
        _messageGateway.Update(message);

        _logger.LogInformation($"Message updated: {message.Title}");
        return RedirectToAction("Index");

    }

    public IActionResult Delete(int id)
    {
        _messageGateway.Delete(id);
        return RedirectToAction("Index");
    }
}