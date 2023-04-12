using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    // abstract = só pode ser herdada, não pode ser instanciada
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        // protected = todos que herdarem de Repository terão acesso ao contexto
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            // AsNoTracking ajuda na performance. Deve ser usando quando não tem intenção de buscar e alterar o estado no banco
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity) // não podemos declarar o "async" na interface
        {
            //Db.Set<TEntity>().Add(entity); // Se não tivessemos adicionado o protected readonly DbSet
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            //DbSet.Remove(await DbSet.FindAsync(id));
            //await SaveChanges();

            // ou

            //var entity = new TEntity { Id = id }; // Por isso o uso do "new()" na declaração de Repository
            //DbSet.Remove(await DbSet.FindAsync(id));
            //await SaveChanges();

            // ou

            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}