using System.ComponentModel.DataAnnotations;

namespace APIMysql.Models
{
    public class User
    {
        [Key]
        [StringLength(100)]
        public string Email { get; set; }   

        public string Senha { get; set; }
    }
}
