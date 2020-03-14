using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog.Controllers
{

    public class HomeController : Controller
    {

        private PostDAO dao;

        public HomeController(PostDAO dao)
        {
            this.dao = dao;
        }

        public IActionResult Index()
        {
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public IActionResult Busca(string termo)
        {
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            ViewBag.Mensagem = termo;
            return View("Index", posts);
        }


    }

}
