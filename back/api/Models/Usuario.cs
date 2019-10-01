using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tbusuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("usunumsequencial")]
        public int Id { get; set; }

        [Column("usunome")]
        public string Nome { get; set; }

        [Column("ususenha")]
        public string Senha { get; set; }

        [Column("usutoken")]
        public string Token { get; set; }

        [Column("usuadmin")]
        public int Admin { get; set; }

        [NotMapped]
        public DateTime DataCriacao { get; set; }
        
        [NotMapped]
        public DateTime DataExpiracao { get; set; }
        
        [NotMapped]
        public bool IsAutenticado { get; set; }
    }
}