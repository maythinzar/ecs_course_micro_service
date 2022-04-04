using Com.MrIT.Common;
using Com.MrIT.Common.Configuration;
using Com.MrIT.DataRepository;
using Com.MrIT.DBEntities;
using Com.MrIT.ViewModels;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<InstituteService> _logger;

        public InstituteService(IInstituteRepository repoInstitute )
        {
            this._repoInstitute = repoInstitute; 
        }
        public InstituteService(IInstituteRepository repoInstitute, ILogger<InstituteService> logger)
        {
            this._repoInstitute = repoInstitute;
            this._logger = logger;
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
                _logger.LogError("Error Log: AddInstitute:" + ex.Message);
                result.IsSuccess = false;
                result.ReturnId = 0;
                result.Error = ex;
            }  
            return result;
        }

        public VmGenericServiceResult UpdateInstitute(VmInstitute vmInstitute)
        {

            var result = new VmGenericServiceResult();
            try
            {
                var dbInstitute = new Institute();
                Copy<VmInstitute, Institute>(vmInstitute, dbInstitute);

                dbInstitute = _repoInstitute.Update(dbInstitute);

                result.IsSuccess = true;

                if (dbInstitute != null)
                {
                    result.ReturnId = dbInstitute.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Log: AddInstitute:" + ex.Message);
                result.IsSuccess = false;
                result.ReturnId = 0;
                result.Error = ex;
            }
            return result;
        }


        public VmGenericServiceResult DeleteInstitute(long id, string modifiedBy)
        {

            var result = new VmGenericServiceResult();
            try
            {
                var dbInstitute = _repoInstitute.Get(id);
                dbInstitute.Active = false;
                dbInstitute.ModifiedBy = modifiedBy;
                dbInstitute = _repoInstitute.Update(dbInstitute);

                result.IsSuccess = true;

                if (dbInstitute != null)
                {
                    result.ReturnId = dbInstitute.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Log: AddInstitute:" + ex.Message);
                result.IsSuccess = false;
                result.ReturnId = 0;
                result.Error = ex;
            }
            return result;
        }




        public List<VmInstitute> GetActiveInstitutes()
        {
            var output = new List<VmInstitute>();

            try
            {
                var dbInstitutes = _repoInstitute.GetAll();
                foreach (var dbInstitute in dbInstitutes)
                {
                    var vmInstitute = new VmInstitute();
                    Copy<Institute, VmInstitute>(dbInstitute, vmInstitute);
                    output.Add(vmInstitute);
                } 
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Log: GetActiveInstitute:" +ex.Message);
            }
            return output;
        }


    }
}
