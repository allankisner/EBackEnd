using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EBackEnd.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Key]
        [Column("idVenda")]
        public int IdVenda { get; set; }

        // Chave Estrangeira
        [Column("idCliente")]
        public int idCliente { get; set; }
        [ForeignKey(nameof(idCliente))]
        public Cliente Cliente { get; set; }

        // Chave Estrangeira
        [Column("idProduto")]
        public int idProduto { get; set; }
        [ForeignKey(nameof(idProduto))]
        public Produto Produto { get; set; }

        [Column("qtdVenda")]

        public int qtdVenda { get; set; }

        [Column("vlrUnitarioVenda")]

        public int vlrUnitarioVenda { get; set; }

        [Column("dthVenda")]

        public DateTime dthVenda { get; set; }

        [Column("vlrTotalVenda")]

        public float vlrTotalVenda { get; set; }
    }
}
