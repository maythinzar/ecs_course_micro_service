using Com.MrIT.DataRepository;
using Com.MrIT.Services;
using Com.MrIT.ViewModels;
using System;
using Xunit;

namespace Com.NUS.TestXUnit
{
    public class InstituteServiceTest
    {

        [Theory]
        [InlineData("Institute A", "System")]
        public void AddInstitute_Test(string name, string createdBy) 
        {
            InstituteService instituteService = new InstituteService(null);
            var vmInstitute = new VmInstitute() { Name = name, CreatedBy = createdBy, ModifiedBy = createdBy };
            var expected = true;

            var vmResult = instituteService.AddInstitute(vmInstitute);
             
            Assert.Equal(expected,vmResult.IsSuccess);
        }
    }
}
