using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tbcliente")]
    public class Cliente
    {
        public Cliente()
        {
            Desativado = "N";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clinumsequencial")]
        public int Id { get; set; }

        [Column("clinome")]
        public string Nome { get; set; }

        [Column("clicpf")]
        public string Cpf { get; set; }

        [Column("clicnpj")]
        public string Cnpj { get; set; }

        [Column("clitelefone")]
        public string Telefone { get; set; }

        [Column("cliendereco")]
        public int EnderecoId { get; set; }

        [Column("clienderecoentrega")]
        public int EnderecoEntregaId { get; set; }

        [Column("clipesrepresentante")]
        public int RepresentanteId { get; set; }

        [Column("clidesativado")]
        public string Desativado { get; set; }

        [NotMapped]
        public Endereco Endereco { get; set; }

        [NotMapped]
        public Endereco EnderecoEntrega { get; set; }

        public void DesativarCliente()
        {
            Desativado = "S";
        }
    }
}