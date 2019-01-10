using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authormanager3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace authormanager3.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        // GET: Author
        public ActionResult Index( )
        {
            return View(_authorRepo.ListAll());
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View(_authorRepo.GetById(id));
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View(new Author());
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author newAuthor, IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(newAuthor);

            }
                try
            {
                 _authorRepo.AddAuthor(newAuthor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(newAuthor);
            }
        }

    }
}