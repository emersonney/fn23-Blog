﻿using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            PostDAO dao = new PostDAO();
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);

        }

        public IActionResult Busca(string termo)
        {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            ViewBag.Mensagem = termo;
            return View("Index", posts);
        }


    }

}
