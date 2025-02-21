namespace Cerualean.Domain.Modules.Lessons.Interfaces
{
    public interface ILessonRepository
    {
        public Task<List<Lesson>> GetLessonListByCourse(int courseId);
        public Task<List<Lesson>> GetLessonList();
        public Task<Lesson?> GetLessonById(int id);
        public Task<Lesson?> GetLessonByTitle(string title);
        public Task<Lesson> CreateLesson(Lesson lesson);
        public Task<Lesson?> UpdateLesson(int id, Lesson lesson);
        public Task<Lesson?> DeleteLesson(int id);
        public Task<bool> LessonExists(int id);
    }
}