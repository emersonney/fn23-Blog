﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required][StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        public string Resumo { get; set; }
        public string Categoria { get; set; }
        public bool Publicado { get; set; }
        public DateTime? DataPublicao { get; set; }

    }
}
