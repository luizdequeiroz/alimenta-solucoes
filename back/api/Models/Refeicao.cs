using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tbrefeicao")]
    public class Refeicao
    {
        [Key]
        [Column("refnumsequencial")]
        public int Id { get; set; }

        [Column("refdatarefeicao")]
        public DateTime DataRefeicao { get; set; }

        [Column("reftiporefeicao")]
        public string TipoRefeicao { get; set; }

        [Column("refvalorrefeicao")]
        public decimal ValorRefeicao { get; set; }

        [Column("refhorarioentrega")]
        public DateTime HorarioEntrega { get; set; }

        [Column("refcliente")]
        public int ClienteId { get; set; }
    }
}