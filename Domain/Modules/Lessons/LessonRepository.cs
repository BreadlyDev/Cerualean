using Cerualean.Data;
using Cerualean.Domain.Modules.Lessons.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cerualean.Domain.Modules.Lessons
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDBContext _context;

        public LessonRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Lesson> CreateLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson?> DeleteLesson(int id)
        {
            var lessonModel = await _context.Lessons.FindAsync(id);

            if (lessonModel == null)
            {
                return null;
            }

            _context.Lessons.Remove(lessonModel);
            return lessonModel;
        }

        public async Task<Lesson?> GetLessonById(int id)
        {
            var lessonModel = await _context.Lessons.FindAsync(id);

            if (lessonModel == null)
            {
                return null;
            }

            return lessonModel;
        }

        public async Task<Lesson?> GetLessonByTitle(string title)
        {
            var lessonModel = await _context.Lessons.FirstOrDefaultAsync(
                lesson => lesson.Title == title
            );

            if (lessonModel == null)
            {
                return null;
            }

            return lessonModel;    
        }

        public async Task<List<Lesson>> GetLessonList()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<List<Lesson>> GetLessonListByCourse(int courseId)
        {
            var lessonModel = await _context.Lessons
            .Where(lesson => lesson.CourseId == courseId).ToListAsync();

            return lessonModel;
        }

        public async Task<bool> LessonExists(int id)
        {
            return await _context.Lessons.AnyAsync(lesson => lesson.Id == id);
        }

        public async Task<Lesson?> UpdateLesson(int id, Lesson lesson)
        {
            var existingLessonModel = await _context.Lessons.FindAsync(id);

            if (existingLessonModel == null)
            {
                return null;
            }

            existingLessonModel.Title = lesson.Title;
            existingLessonModel.Description = lesson.Description;
            existingLessonModel.PreviousLessonId = lesson.PreviousLessonId;
            existingLessonModel.NextLessonId = lesson.NextLessonId;
            existingLessonModel.CourseId = lesson.CourseId;

            await _context.SaveChangesAsync();
            return existingLessonModel;
        }
    }
}