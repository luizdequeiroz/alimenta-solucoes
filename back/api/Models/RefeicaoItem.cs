using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace api.Models
{
    [Table("tbitemrefeicao")]
    public class RefeicaoItem
    {
        [Key]
        [Column("irfnumsequencial")]
        public int Id { get; set; }

        [Column("irfqtdreceita")]
        public decimal QuantidadeReceita { get; set; }

        [Column("irfreceita")]
        public int ReceitaId { get; set; }

        [Column("irfrefeicao")]
        public int RefeicaoId { get; set; }
    }
}