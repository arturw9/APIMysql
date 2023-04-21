﻿using System.ComponentModel.DataAnnotations;

namespace APIMysql.Models
{
    public class Itens
    {
        [Key]
        [StringLength(100)]
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string valor { get; set; }
        public string quantidade { get; set; }
    }
}
