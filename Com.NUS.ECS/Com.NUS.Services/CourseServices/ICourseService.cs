using Com.MrIT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.Services
{
    public interface ICourseService
    {


        #region CourseType
        List<VmCourseType> GetActiveCourseType();
        #endregion

        #region CourseCategory
        List<VmCourseCategory> GetActiveCourseCategory();
        #endregion

        #region Tag
        List<VmTag> GetActiveTag();
        #endregion 

        #region Course
        VmGenericServiceResult AddCourse(VmCourse vmCourse);
        VmGenericServiceResult UpdateCourse(VmCourse vmCourse);
        VmGenericServiceResult DeleteCourse(long id, string modifiedBy);
        List<VmCourse> GetActiveCourses();
        #endregion

    }
}
