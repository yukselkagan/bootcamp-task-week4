using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IGenericServise<T, TDto> where T : IEntityBase where TDto :IDtoBase
    {
        IResponse<List<TDto>> GetAll();
        IResponse<List<TDto>> GetAll(Expression<Func<T,bool>> expression);
        IResponse<TDto> Find(int id);
        IResponse<TDto> Find(string id);
        IQueryable<T> GetIQueryable();
        IResponse<TDto> Add(TDto item, bool saveChanges = true);
        Task<TDto> AddAsync(TDto item);
        TDto Update(TDto item);
        Task<TDto> UpdateAsync(TDto item);
        IResponse<bool> DeleteById(int id, bool saveChanges = true);
        Task<bool> DeleteByIdAsync(int id);
        bool Delete(TDto item);
        Task<bool> DeleteAsync(TDto item);
        void Save();
    }
}
