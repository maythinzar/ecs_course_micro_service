using Com.MrIT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.Services
{
    public interface IInstituteService
    {
        VmGenericServiceResult AddInstitute(VmInstitute vmInstitute);
    }
}
