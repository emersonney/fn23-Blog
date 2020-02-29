using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo Titulo é de preenchimento obrigatório!")]
        [StringLength(50, ErrorMessage = "Digite no máximo 50 caracteres para o campo Titulo!")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Resumo é de preenchimento obrigatório!")]
        public string Resumo { get; set; }
        public string Categoria { get; set; }
        public bool Publicado { get; set; }
        public DateTime? DataPublicao { get; set; }

    }
}
