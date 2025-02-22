using Cerualean.Domain.Common.Exceptions;
using Cerualean.Domain.CourseModule.Helpers;
using Cerualean.Domain.CourseModule.Interfaces;
using Cerualean.Domain.Modules.Lessons.Dtos;
using Cerualean.Domain.Modules.Lessons.Helpers;
using Cerualean.Domain.Modules.Lessons.Interfaces;

namespace Cerualean.Domain.Modules.Lessons
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepo;
        private readonly ICourseRepository _courseRepo;
        public LessonService(
            ILessonRepository lessonRepo,
            ICourseRepository courseRepo
        )
        {
            _lessonRepo = lessonRepo;
            _courseRepo = courseRepo;
        }

        public async Task<LessonDto> CreateLesson(int courseId, CreateLessonDto LessonDto)
        {
            var courseExists = await _courseRepo.CourseExists(courseId);

            if (!courseExists)
            {
                throw new NotFoundException(CourseExceptionMessages.CourseNotFound);
            }

            var lessonModel = await _lessonRepo.CreateLesson(
                LessonDto.ToLessonFromCreateLessonDto(courseId)
            );

            return lessonModel.ToLessonDto();
        }

        public async Task<LessonDto> DeleteLesson(int id)
        {
            var lessonModel = await _lessonRepo.DeleteLesson(id) 
            ?? throw new NotFoundException(LessonExceptionMessages.LessonNotFound);
            
            return lessonModel.ToLessonDto();
        }

        public async Task<LessonDto> GetLessonById(int id)
        {
            var lessonModel = await _lessonRepo.GetLessonById(id) 
            ?? throw new NotFoundException(LessonExceptionMessages.LessonNotFound);

            return lessonModel.ToLessonDto();
        }

        public async Task<LessonDto> GetLessonByTitle(string title)
        {
            var lessonModel = await _lessonRepo.GetLessonByTitle(title)
            ?? throw new NotFoundException(LessonExceptionMessages.LessonNotFound);
        
            return lessonModel.ToLessonDto();
        }

        public async Task<List<LessonDto>> GetLessonList()
        {
            var lessonModelList = await _lessonRepo.GetLessonList();
            return lessonModelList.Select(lesson => lesson.ToLessonDto()).ToList();
        }

        public async Task<List<LessonDto>> GetLessonListByCourse(int courseId)
        {
            var lessonModelList = await _lessonRepo.GetLessonListByCourse(courseId);
            return lessonModelList.Select(lesson => lesson.ToLessonDto()).ToList();
        }

        public async Task<LessonDto> UpdateLesson(int id, UpdateLessonDto lessonDto)
        {
            var lessonModel = await _lessonRepo.UpdateLesson(
                id, lessonDto.ToLessonFromUpdateLessonDto()
            ) 
            ?? throw new NotFoundException(LessonExceptionMessages.LessonNotFound);
            return lessonModel.ToLessonDto();
        }
    }
}