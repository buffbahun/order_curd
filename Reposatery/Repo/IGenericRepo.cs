using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Reposatery.Repo
{
    public interface IGenericRepo<T> where T: class
    {
        IQueryable<T> getQueryable();
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void DeleteRange(int id);
        void Save();
    }
}
