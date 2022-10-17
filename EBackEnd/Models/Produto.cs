using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EBackEnd.Models
{
    [Table("Produto")]
    public class Produto
    {

        [Key]
        [Column("idProduto")]

        public int IdProduto { get; set; }

        [Column("dscProduto")]

        public string? DscProduto { get; set; }

        [Column("vlrUnitario")]

        public int VlrUnitario { get; set; }
    }
}
