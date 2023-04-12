using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        // Não precisaríamos adicionar os métodos aqui, pois já estão sendo herdados de IRepository.
        // Tudo que fizermos aqui será para Fornecedor. Estendemos IRepository especializando para a classe Fornecedor.

        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEnderecos(Guid id);
    }
}