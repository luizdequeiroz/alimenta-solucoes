using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("tbreceita")]
    public class Receita
    {
        [Key]
        [Column("recnumsequencial")]
        public int Id { get; set; }

        [Column("recnome")]
        public string nome { get; set; }

        [Column("recunidademedida")]
        public string unidadeMedida { get; set; }

        [Column("recmodopreparo")]
        public string modoPreparo { get; set; }

        [Column("recquantidaderendimento")]
        public decimal quantidadeRendimento { get; set; }

        public IEnumerable<Produto> produtos { get; set; }

    }
}
