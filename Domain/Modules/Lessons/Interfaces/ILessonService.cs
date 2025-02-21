using Cerualean.Domain.Modules.Lessons.Dtos;

namespace Cerualean.Domain.Modules.Lessons.Interfaces
{
    public interface ILessonService
    {
        public Task<List<LessonDto>> GetLessonListByCourse(int courseId);
        public Task<List<LessonDto>> GetLessonList();
        public Task<LessonDto> GetLessonById(int id);
        public Task<LessonDto> GetLessonByTitle(string title);
        public Task<LessonDto> CreateLesson(int courseId, CreateLessonDto lessonDto);
        public Task<LessonDto> UpdateLesson(int id, UpdateLessonDto lessonDto);
        public Task<LessonDto> DeleteLesson(int id);
    }
}