using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Model
{
    [Table("seguro")]
    public class Seguro
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("idperson")]
        public long IdPerson { get; set; }
        [Column("idveiculo")]
        public long IdVeiculo { get; set; }
        [Column("valorseguro")]
        public decimal ValorSeguro { get; set; }

    }
}
