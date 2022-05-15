using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories.Interfaces
{
    public interface IGenericRepository <Entity>  where Entity : EntityBase
    { 
        Entity GetById(int id);
        List<Entity> GetAll(int top, int page);
        void Insert(Entity fornecedor);
        void Update(Entity fornecedor);
        void Delete(int id);
    }
}
