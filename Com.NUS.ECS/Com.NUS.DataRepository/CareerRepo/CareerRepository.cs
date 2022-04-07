using Com.MrIT.Common;
using Com.MrIT.DBEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.DataRepository
{

    public class CareerRepository : GenericRepository<Career>, ICareerRepository
    {
        public CareerRepository(DataContext context, ILoggerFactory loggerFactory) :
       base(context, loggerFactory, "CareerRepository")
        {

        }

        public long GetIdByName(string career)
        {
            long output = 0;
            var dbResult = entities.FirstOrDefault(e => e.Name.ToLower() == career.ToLower());
            if (dbResult != null)
            {
                output = dbResult.Id;
            }

            return output;
        }
    }
}
