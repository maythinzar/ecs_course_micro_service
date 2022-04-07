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
        private readonly ICourseTypeRepository _repoCourseType;
        private readonly ICourseCategoryRepository _repoCourseCategory;
        private readonly ICourseTagRepository _repoCourseTag;
        private readonly ICareerRepository _repoCareer;
        private readonly ICourseCareerRepository _repoCourseCareer;
        private readonly ICourseInstructorRepository _repoCourseInstructor;
        private readonly ICoursePrerequisiteRepository _repoCoursePrerequisite;
        private readonly ITagRepository _repoTag;

        public CourseService(ICourseRepository repoCourse, ICourseTypeRepository repoCourseType, ICourseCategoryRepository repoCourseCategory, ICourseTagRepository repoCourseTag, ICareerRepository repoCareer, ICourseCareerRepository repoCourseCareer, ICourseInstructorRepository repoCourseInstructor, ITagRepository repoTag, ICoursePrerequisiteRepository repoCoursePrerequisite)
        {
            this._repoCourse = repoCourse;
            this._repoCourseType = repoCourseType;
            this._repoCourseCategory = repoCourseCategory;
            this._repoCourseTag = repoCourseTag;
            this._repoCareer = repoCareer;
            this._repoCourseCareer = repoCourseCareer;
            this._repoCourseInstructor = repoCourseInstructor;
            this._repoTag = repoTag;
            this._repoCoursePrerequisite = repoCoursePrerequisite;
        }

        #region CourseType
        public List<VmCourseType> GetActiveCourseType()
        {
            var output = new List<VmCourseType>();


            var dbCourseTypes = _repoCourseType.GetActiveAll();
            foreach (var dbCourseType in dbCourseTypes)
            {
                var vmCourseType = new VmCourseType();
                Copy<CourseType, VmCourseType>(dbCourseType, vmCourseType);
                output.Add(vmCourseType);
            }

            return output;
        }
        #endregion

        #region CourseCategory
        public List<VmCourseCategory> GetActiveCourseCategory()
        {
            var output = new List<VmCourseCategory>();


            var dbCourseCategorys = _repoCourseCategory.GetActiveAll();
            foreach (var dbCourseCategory in dbCourseCategorys)
            {
                var vmCourseCategory = new VmCourseCategory();
                Copy<CourseCategory, VmCourseCategory>(dbCourseCategory, vmCourseCategory);
                output.Add(vmCourseCategory);
            }

            return output;
        }
        #endregion

        #region Tag
        public List<VmTag> GetActiveTag()
        {
            var output = new List<VmTag>();


            var dbTags = _repoTag.GetActiveAll();
            foreach (var dbTag in dbTags)
            {
                var vmTag = new VmTag();
                Copy<Tag, VmTag>(dbTag, vmTag);
                output.Add(vmTag);
            }

            return output;
        }
        #endregion

        #region Course 
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

                if(vmCourse.CourseCategoryId == 0)
                {
                    dbCourse.CourseCategory = new CourseCategory()
                    { 
                        Name = vmCourse.SelectedCategory,
                        Active = true,
                        SystemActive = true,
                        CreatedBy = vmCourse.CreatedBy,
                        CreatedOn = DateTime.Now,
                        ModifiedBy = vmCourse.CreatedBy,
                        ModifiedOn = DateTime.Now
                    };
                }
                _repoCourse.Commit();


                if(vmCourse.SelectedTag != null)
                {
                    foreach (var tag in vmCourse.SelectedTag)
                    {
                        if (!string.IsNullOrEmpty(tag))
                        {
                            var tagName = tag.Trim();
                            var tagId = _repoTag.GetIdByName(tagName);
                            if(tagId == 0)
                            {
                                var newTag = _repoTag.Add( new Tag() { Name = tagName, CreatedBy = vmCourse.CreatedBy, ModifiedBy= vmCourse.CreatedBy });
                                tagId = newTag.Id;
                            }

                            _repoCourseTag.Add(new CourseTag() { CourseId = dbCourse.Id, TagId = tagId, CreatedBy = vmCourse.CreatedBy, ModifiedBy = vmCourse.CreatedBy });
                        }
                    }
                }


                if (vmCourse.SelectedCareer != null)
                {
                    foreach (var career in vmCourse.SelectedCareer)
                    { 
                        if (!string.IsNullOrEmpty(career))
                        {
                            var careerName = career.Trim();
                            var careerId = _repoCareer.GetIdByName(careerName);
                            if (careerId == 0)
                            {
                                var newCareer = _repoCareer.Add(new Career() { Name = careerName, CreatedBy = vmCourse.CreatedBy, ModifiedBy = vmCourse.CreatedBy });
                                careerId = newCareer.Id;
                            }

                            _repoCourseCareer.Add(new CourseCareer() { CourseId = dbCourse.Id, CareerId = careerId, CreatedBy = vmCourse.CreatedBy, ModifiedBy = vmCourse.CreatedBy });
                        }
                    }
                }

                if (vmCourse.CourseInstructors != null)
                {
                    foreach (var instructor in vmCourse.CourseInstructors)
                    {
                        _repoCourseInstructor.Add(new CourseInstructor() { CourseId = dbCourse.Id, InstructorId = instructor.InstructorId, Role = instructor.Role, CreatedBy = vmCourse.CreatedBy, ModifiedBy = vmCourse.CreatedBy }); 
                    }
                }

                if (vmCourse.CoursePrerequisites != null)
                {
                    foreach (var category in vmCourse.CoursePrerequisites)
                    {
                        var categoryId = category.Id;
                        if(category.Id == 0)
                        {
                            var tmpName = category.CourseCategoryName;
                            var dbCategory = _repoCourseCategory.Add(new CourseCategory() { Name = tmpName, CreatedBy = vmCourse.CreatedBy, ModifiedBy = vmCourse.CreatedBy });

                            categoryId = dbCategory.Id;
                        }

                        _repoCoursePrerequisite.Add( new CoursePrerequisite() { CourseId = dbCourse.Id, CourseCategoryId = categoryId, OtherRemarks = category.OtherRemarks, IsMandatory = category.IsMandatory, CreatedBy = vmCourse.CreatedBy, ModifiedBy = vmCourse.CreatedBy });
                    }
                }



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


            var dbCourses = _repoCourse.GetActiveAll();
            foreach (var dbCourse in dbCourses)
            {
                var vmCourse = new VmCourse();
                Copy<Course, VmCourse>(dbCourse, vmCourse);
                output.Add(vmCourse);
            }

            return output;
        }
        #endregion





    }
}
