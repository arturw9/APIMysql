using System.ComponentModel.DataAnnotations;

namespace APIMysql.Models
{
    public class Item
    {
        [Key]
        [StringLength(100)]

        public Guid? Id { get; set; }
     
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string valor { get; set; }
        public string quantidade { get; set; }
    }
}
