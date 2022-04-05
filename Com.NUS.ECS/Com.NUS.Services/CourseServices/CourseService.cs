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
    public class CourseService : BaseService, ICourseService
    {
        private readonly ICourseRepository _repoCourse;

        public CourseService(ICourseRepository repoCourse)
        {
            this._repoCourse = repoCourse;
        }


        public VmGenericServiceResult AddCourse(VmCourse vmCourse)
        {

            var result = new VmGenericServiceResult();
            try
            {
                var dbCourse = new Course();
                Copy<VmCourse, Course>(vmCourse, dbCourse);
                Guid generateGuid = Guid.NewGuid();
                dbCourse.Guid = generateGuid.ToString();
                dbCourse = _repoCourse.Add(dbCourse);
                _repoCourse.Commit();
                result.IsSuccess = true;

                if (dbCourse != null)
                {
                    result.ReturnId = dbCourse.Id;
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

        public VmGenericServiceResult UpdateCourse(VmCourse vmCourse)
        {

            var result = new VmGenericServiceResult();
            try
            {
                var dbCourse = new Course();
                Copy<VmCourse, Course>(vmCourse, dbCourse);

                dbCourse = _repoCourse.Update(dbCourse);
                _repoCourse.Commit();
                result.IsSuccess = true;

                if (dbCourse != null)
                {
                    result.ReturnId = dbCourse.Id;
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


        public VmGenericServiceResult DeleteCourse(long id, string modifiedBy)
        {

            var result = new VmGenericServiceResult();
            try
            {
                var dbCourse = _repoCourse.Get(id);
                dbCourse.Active = false;
                dbCourse.ModifiedBy = modifiedBy;
                dbCourse = _repoCourse.Update(dbCourse);
                _repoCourse.Commit();
                result.IsSuccess = true;

                if (dbCourse != null)
                {
                    result.ReturnId = dbCourse.Id;
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




        public List<VmCourse> GetActiveCourses()
        {
            var output = new List<VmCourse>();


            var dbCourses = _repoCourse.GetAll();
            foreach (var dbCourse in dbCourses)
            {
                var vmCourse = new VmCourse();
                Copy<Course, VmCourse>(dbCourse, vmCourse);
                output.Add(vmCourse);
            }

            return output;
        }


    }
}
