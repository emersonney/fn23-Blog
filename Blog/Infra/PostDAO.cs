using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Infra
{
    public class PostDAO
    {

        private BlogContext contexto;
        public PostDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }


        public IList<Post> Lista()
        {

            var lista = contexto.Posts.ToList();
            return lista;
        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {

            var lista = contexto.Posts.ToList();
            return lista;

        }

        public void Adiciona(Post post)
        {

            contexto.Posts.Add(post);
            contexto.SaveChanges();
        }

        public void Publica(int id)
        {
            Post post = contexto.Posts.Find(id);
            post.Publicado = true;
            post.DataPublicao = DateTime.Now;
            contexto.SaveChanges();
        }

        public void Atualiza(Post post)
        {
            contexto.Entry(post).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public IList<string> ListaCategoriasQueContemTermo(string termo)
        {

            return contexto.Posts
            .Where(p => p.Categoria.Contains(termo))
             .Select(p => p.Categoria)
            .Distinct()
            .ToList();

        }

        public IList<Post> ListaPublicados()
        {

            return contexto.Posts.Where(p => p.Publicado)
             .OrderByDescending(p => p.DataPublicao)
             .ToList();

        }

        public IList<Post> BuscaPeloTermo(string termo)
        {

            return contexto.Posts
            .Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
            .ToList();
        }


        internal Post BuscaPorId(int id)
        {
        
                var post = contexto.Posts.Find(id);
                return post;

        }

        public void Remove(int id)
        {
                var lista = contexto.Posts.Find(id);
                contexto.Remove(lista);
                contexto.SaveChanges();

        }

    }
}
