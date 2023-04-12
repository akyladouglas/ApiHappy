using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    // Repositório genérico (serve para qualquer entidade)
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity // Herda de IDisposable para poder realizar o disposable das conexões; TEntity só pode ser de um tipo herdado do tipo Entity ("que seja filha de Entity")
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id); // void

        // Possibilitando passar uma expressão lambda para o método Buscar, para buscar qualquer entidade por qualquer parâmetro
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}