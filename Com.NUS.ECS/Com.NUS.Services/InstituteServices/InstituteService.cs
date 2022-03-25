using Com.MrIT.Common;
using Com.MrIT.Common.Configuration;
using Com.MrIT.DataRepository;
using Com.MrIT.DBEntities;
using Com.MrIT.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.Services
{
    public class InstituteService : BaseService, IInstituteService
    {
        private readonly IInstituteRepository _repoInstitute;
        public InstituteService(DataRepository.IInstituteRepository repoInstitute)
        {
            this._repoInstitute = repoInstitute;
        }


        public VmGenericServiceResult AddInstitute(VmInstitute vmInstitute)
        {
            
            var result = new VmGenericServiceResult();
            try
            {
                var dbInstitute = new Institute();
                Copy<VmInstitute, Institute>(vmInstitute, dbInstitute);

                dbInstitute = _repoInstitute.Add(dbInstitute);

                result.IsSuccess = true;

                if(dbInstitute != null)
                {
                    result.ReturnId = dbInstitute.Id;
                } 
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ReturnId = 0;
                result.Error = ex;
            }  
            return result;
        }


    }
}
