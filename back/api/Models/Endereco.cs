using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tbendereco")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("endnumsequencial")]
        public int Id { get; set; }

        [Column("endbairro")]
        public string Bairro { get; set; }

        [Column("endcep")]
        public string Cep { get; set; }

        [Column("endcidade")]
        public string Cidade { get; set; }

        [Column("endcomplemento")]
        public string Complemento { get; set; }

        [Column("endestado")]
        public string Estado { get; set; }

        [Column("endlogradouro")]
        public string Logradouro { get; set; }

        [Column("endnumero")]
        public string Numero { get; set; }

        [Column("endpais")]
        public string Pais { get; set; }
    }
}