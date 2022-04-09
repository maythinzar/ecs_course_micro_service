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
    public class CareerService : BaseService, ICareerService
    {
        private readonly ICareerRepository _repoCareer;

        public CareerService(ICareerRepository repoCareer)
        {
            this._repoCareer = repoCareer;
        }


        public VmGenericServiceResult AddCareer(VmCareer vmCareer)
        {

            var result = new VmGenericServiceResult();
            try
            {
                var dbCareer = new Career();
                Copy<VmCareer, Career>(vmCareer, dbCareer);
                 
                dbCareer = _repoCareer.Add(dbCareer);
                _repoCareer.Commit();
                result.IsSuccess = true;

                if (dbCareer != null)
                {
                    result.ReturnId = dbCareer.Id;
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

        public VmGenericServiceResult UpdateCareer(VmCareer vmCareer)
        {

            var result = new VmGenericServiceResult();
            try
            {
                var dbCareer = new Career();
                Copy<VmCareer, Career>(vmCareer, dbCareer);

                dbCareer = _repoCareer.Update(dbCareer);
                _repoCareer.Commit(); 
                result.IsSuccess = true;

                if (dbCareer != null)
                {
                    result.ReturnId = dbCareer.Id;
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


        public VmGenericServiceResult DeleteCareer(long id, string modifiedBy)
        {

            var result = new VmGenericServiceResult();
            try
            {
                var dbCareer = _repoCareer.Get(id);
                dbCareer.Active = false;
                dbCareer.ModifiedBy = modifiedBy;
                dbCareer = _repoCareer.Update(dbCareer);
                _repoCareer.Commit();
                result.IsSuccess = true;

                if (dbCareer != null)
                {
                    result.ReturnId = dbCareer.Id;
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




        public List<VmCareer> GetActiveCareers()
        {
            var output = new List<VmCareer>();


            var dbCareers = _repoCareer.GetAll();
            foreach (var dbCareer in dbCareers)
            {
                var vmCareer = new VmCareer();
                Copy<Career, VmCareer>(dbCareer, vmCareer);
                output.Add(vmCareer);
            }

            return output;
        }


    }
}
