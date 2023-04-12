using System;

namespace DevIO.Business.Models
{
    public abstract class Entity // Será a clase base de todas as entidades
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }   
}