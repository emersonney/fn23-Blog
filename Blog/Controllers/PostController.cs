using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {

        private IList<Post> listaDePosts;

        public PostController()
        {
            this.listaDePosts = new List<Post>
            {
                new Post { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" },
                new Post { Titulo = "Cassino Royale", Resumo = "007", Categoria = "Filme" },
                new Post { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria = "Livro" },
                new Post { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" }

            };
        }


    public IActionResult Index()
        {
            //ViewBag.Posts = listaDePosts;
            return View(listaDePosts);
        }

        public IActionResult Adiciona()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            listaDePosts.Add(post);
            return View("Index", listaDePosts);
        }

    }

 

}