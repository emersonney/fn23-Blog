using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Infra
{
    public class PostDAO
    {

        public IList<Post> Lista()
        {

            var lista = new List<Post>();
            using (SqlConnection cnx = ConnectionFactory.CriaConexaoAberta())
            {
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "Select * From Posts";
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                    lista.Add(post);
                }
            }
            return lista;
        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }
        }

        public void Adiciona(Post post)
        {

            using (SqlConnection cnx = ConnectionFactory.CriaConexaoAberta())
            {

                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = @"insert into Posts (Titulo, Resumo, Categoria) values 
                    (@titulo,@resumo,@categoria)";

                comando.Parameters.AddWithValue("titulo", post.Titulo);
                comando.Parameters.AddWithValue("resumo", post.Resumo);
                comando.Parameters.AddWithValue("categoria", post.Categoria);

                comando.ExecuteNonQuery();


            }

        }

        public void Publica(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                post.Publicado = true;
                post.DataPublicao = DateTime.Now;
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<string> ListaCategoriasQueContemTermo(string termo)
        {

            using (var contexto = new BlogContext())
            {

                return contexto.Posts
                    .Where(p => p.Categoria.Contains(termo))
                    .Select(p => p.Categoria)
                    .Distinct()                    
                    .ToList();

            }

        }


    }
}
