using Com.MrIT.Common;
using Com.MrIT.DBEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.MrIT.DataRepository
{
    public interface IGenericRepository<T> where T : GenericEntity
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

         T  Get(long id);

        

        IEnumerable<T> GetActiveAll();
        IEnumerable<T> GetAll();
        PageResult<T> GetPage(string keyword, int page, int totalRecords = 10);
        T GetLastRow();


        void Commit();
    }
}
