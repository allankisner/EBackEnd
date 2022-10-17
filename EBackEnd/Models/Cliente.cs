using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EBackEnd.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        
            [Key]
            [Column("ClientId")]

            public int IdCliente { get; set; }

            [Column("NmCliente")]

            public string nmCliente { get; set; }

            [Column("Cidade")]

            public string Cidade { get; set; }
        }
    }

