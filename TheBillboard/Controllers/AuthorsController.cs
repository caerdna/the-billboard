using Microsoft.AspNetCore.Mvc;
using TheBillboard.Abstract;
using TheBillboard.Models;



namespace TheBillboard.Controllers

{
    public class AuthorController : Controller

    {
        private readonly IAuthorGateway _authorGateway;

        private readonly ILogger<AuthorController> _logger;



        public AuthorController(IAuthorGateway authorGateway, ILogger<AuthorController> logger)

        {

            _authorGateway = authorGateway;

            _logger = logger;

        }



        public IActionResult Index()

        {

            var author = _authorGateway.GetAll();

            return View(author);

        }



        [HttpPost]

        public IActionResult Create(Author author)

        {

            if (!ModelState.IsValid)

            {

                return View();

            }

            else

            {

                if (author.Id is null)

                {

                    author.Id = _authorGateway.RequestId();

                    _authorGateway.Create(author);

                }

                else

                {

                    _authorGateway.Update(author);

                }



                _logger.LogInformation($"Message received: {author.Name}");

                return RedirectToAction("Index");

            }

        }



        public IActionResult Detail(int id)

        {

            var author = _authorGateway.GetById(id);

            return View(author);

        }



        public IActionResult Create()

        {

            return View();

        }



        public IActionResult Update(int id)

        {

            var author = _authorGateway.GetById(id);

            return View(author);

        }



        public IActionResult Delete(int id)

        {

            _authorGateway.Delete(id);

            return RedirectToAction("Index");

        }

    }

}