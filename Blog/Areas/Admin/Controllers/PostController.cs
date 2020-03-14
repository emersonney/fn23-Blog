using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")] [Authorize]
    public class PostController : Controller
    {

        private PostDAO dao;

        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }

        public IActionResult Index()
        {
            var lista = dao.Lista();
            return View(lista);
        }

        public IActionResult Adiciona()
        {
            var model = new Post();
            return View("Adiciona", model);
        }

        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Adiciona", post);
            }
        }

        public IActionResult RemovePost(int id)
        {
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult PublicaPost(int id)
        {
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        public IActionResult Visualiza(int id)
        {
            var post = dao.BuscaPorId(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult EditaPost(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", post);
            }
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string termoDigitado)
        {
            var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }
    }

}