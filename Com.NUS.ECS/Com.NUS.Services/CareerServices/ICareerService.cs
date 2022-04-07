using Com.MrIT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.Services
{
    public interface ICareerService
    {
        VmGenericServiceResult AddCareer(VmCareer vmCareer);
        VmGenericServiceResult UpdateCareer(VmCareer vmCareer);
        VmGenericServiceResult DeleteCareer(long id, string modifiedBy);
        List<VmCareer> GetActiveCareers();
    }
}
