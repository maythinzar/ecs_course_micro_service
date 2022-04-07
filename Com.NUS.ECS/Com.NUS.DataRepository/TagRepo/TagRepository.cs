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

    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(DataContext context, ILoggerFactory loggerFactory) :
       base(context, loggerFactory, "TagRepository")
        {

        }

        public long GetIdByName(string tag)
        {
            long output = 0;
            var dbResult = entities.FirstOrDefault(e=>e.Name.ToLower() == tag.ToLower());
            if(dbResult != null)
            {
                output = dbResult.Id;
            }

            return output; 
        }
    }
}
