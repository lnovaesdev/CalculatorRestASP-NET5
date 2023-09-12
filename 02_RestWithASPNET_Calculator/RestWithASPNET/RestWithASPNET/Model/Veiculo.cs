using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Model
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("modelo")]
        public string Modelo { get; set; }
        [Column("marca")]
        public string Marca { get; set; }
        [Column("valor")]
        public decimal Valor { get; set; }

    }
}
