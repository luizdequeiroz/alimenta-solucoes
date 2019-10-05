using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("tbproduto")]
    public class Produto
    {
            [Key]
            [Column("pronumsequencial")]
            public int Id { get; set; }

            [Column("pronome")]
            public string nome { get; set; }

            [Column("prounidademedida")]
            public string unidadeMedida { get; set; }

    }
}
