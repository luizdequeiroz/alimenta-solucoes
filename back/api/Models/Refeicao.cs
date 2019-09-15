using api.Models.Enums;
using ExtensionsPlus;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Refeicao
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        [NotMapped]
        public TipoRefeicao Tipo
        {
            get => TipoString.ToEnumIndex<TipoRefeicao>();
            set => this.TipoString = value.ToDescriptionString();
        }
        public string TipoString { get; set; }
        public decimal Valor { get; set; }
        public TimeSpan HorarioEntrega { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataRefeicao { get; set; }

        public string ClienteNome { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteCNPJ { get; set; }
        public string ClienteTelefone { get; set; }
        public string ClienteEndereco { get; set; }
        public string ClienteEnderecoEntrega { get; set; }
        public int ClientePessoaRepresentante { get; set; }
    }
}