using Com.MrIT.DataRepository;
using Com.MrIT.DBEntities;
using Com.MrIT.Services;
using Com.MrIT.ViewModels;
using Moq;
using System;
using Xunit;

namespace Com.NUS.TestXUnit
{
    public class InstituteServiceTest: BaseService
    {
       
        public readonly Mock<IInstituteRepository> _repoInstituteMock = new Mock<IInstituteRepository>();

        [Fact]
        public void DoesntSaveToDatabaseWhenInvalidSomething()
        {
            InstituteService instituteService = new InstituteService(_repoInstituteMock.Object);

            var vmResult = instituteService.AddInstitute(null);

            Assert.False(vmResult.IsSuccess);
            _repoInstituteMock.Verify(x => x.Add(It.IsAny<Institute>()), Times.Never);
        }

        [Fact]
        public void SaveInstituteToDatabaseWhenValid()
        {
            var vmInstitute = new VmInstitute{ Name = "Foo"};
            
            InstituteService instituteService = new InstituteService(_repoInstituteMock.Object);
            var dbInstitute = new Institute();
            Copy<VmInstitute, Institute>(vmInstitute, dbInstitute);
            _repoInstituteMock.Setup(x => x.Add(dbInstitute)).Returns(dbInstitute);
            var vmResult = instituteService.AddInstitute(vmInstitute);

            Assert.True(vmResult.IsSuccess);
            _repoInstituteMock.Verify(x => x.Add(It.IsAny<Institute>()), Times.Once);
        }
    }
}
