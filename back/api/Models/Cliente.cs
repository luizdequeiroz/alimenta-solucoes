using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }
        public int EnderecoEntregaId { get; set; }
        public int PessoaRepresentante { get; set; }
        [NotMapped]
        public IEnumerable<Refeicao> Dias { get; set; }
    }
}
