using System.ComponentModel.DataAnnotations;

namespace VSComMariaDB.Model
{
    public class Produto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Descricao{ get; set; }

        
        public decimal Preco { get; set; }

        
        public bool Novidade { get; set; }

        [MaxLength(10500)]
        public string Imagem { get; set; }

        public bool Disponivel { get; set; }






    }
}
