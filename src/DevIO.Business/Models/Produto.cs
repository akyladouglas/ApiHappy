using System;

namespace DevIO.Business.Models
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; } // Chave estrangeira (O produto pertence a um fornecedor)
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        // EF Relations
        public Fornecedor Fornecedor { get; set; }
    }
}