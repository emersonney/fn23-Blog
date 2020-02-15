using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {

        private IList<Post> listaDePosts;

        public PostController()
        {

            //    this._listaDePosts = new List<Post>
            //{
            //    new Post { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" },
            //    new Post { Titulo = "Cassino Royale", Resumo = "007", Categoria = "Filme" },
            //    new Post { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria = "Livro" },
            //    new Post { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" }

            //};
        }


    public IActionResult Index()
        {

            //var strCnx = @"Data Source = (localdb)\MSSQLLocalDB;Database=Blog;
            //    Integrated Security = True";

            //SqlConnection conexao = new SqlConnection(strCnx);
            //conexao.Open();

            //SqlCommand comando = new SqlCommand("Select * From Posts", conexao);
            //SqlDataReader leitor = comando.ExecuteReader();

            //while(leitor.Read())
            //{
            //    var post = new Post();
            //    post.Titulo     = leitor["Titulo"].ToString();
            //    post.Resumo     = leitor["Resumo"].ToString();
            //    post.Categoria  = leitor["Categoria"].ToString();
            //    post.Id         = Convert.ToInt32(leitor["Id"]);

            //    _listaDePosts.Add( post );
            //}
            //conexao.Close();

            using (BlogContext contexto = new BlogContext())
            {
                var _lista = contexto.Posts.ToList();
                return View(_lista);
            }

            //    PostDAO dao = new PostDAO();
            //IList<Post> lista = dao.Lista();

            //ViewBag.Posts = listaDePosts;
            //return View(lista);
        }

        public IActionResult Adiciona()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            //listaDePosts.Add(post);

            //PostDAO dao = new PostDAO();
            //dao.Adiciona(post);

            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            }

                //IList<Post> lista = dao.Lista();

                //return View("Index", lista);

                return RedirectToAction("Index");

        }


        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                //var lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();

                var lista = from p in contexto.Posts where p.Categoria.Contains(categoria) select p;


                return lista.ToList();
            }

        }

        public IActionResult RemovePost(int id)
        {

            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                contexto.Posts.Remove(post);
                contexto.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            Console.WriteLine("Categoria = " + categoria);

            IList<Post> lista = FiltraPorCategoria(categoria);

            return View("Index", lista);
        }


    }

   
 

}