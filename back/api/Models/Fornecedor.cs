using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("tbfornecedor")]
    public class Fornecedor
    {
        [Key]
        [Column("fornumsequencial")]
        public int Id { get; set; }

        [Column("fornome")]
        public string nome { get; set; }

        [Column("forendereco")]
        public string endereco { get; set; }

        [Column("fortelefone")]
        public string telefone { get; set; }
    }
}
