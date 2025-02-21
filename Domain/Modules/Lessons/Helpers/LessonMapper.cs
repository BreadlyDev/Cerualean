using Cerualean.Domain.Modules.Lessons.Dtos;

namespace Cerualean.Domain.Modules.Lessons.Helpers
{
    public static class LessonMapper
    {
        public static LessonDto ToLessonDto(this Lesson lessonModel)
        {
            return new LessonDto 
            {
                Id = lessonModel.Id,
                Title = lessonModel.Title,
                Description = lessonModel.Description,
                NextLessonId = lessonModel.NextLessonId,
                PreviousLessonId = lessonModel.PreviousLessonId,
                CourseId = lessonModel.CourseId
            };
        }

        public static Lesson ToLessonFromLessonDto(this LessonDto lessonDto)
        {
            return new Lesson 
            {
                Id = lessonDto.Id,
                Title = lessonDto.Title,
                Description = lessonDto.Description,
                NextLessonId = lessonDto.NextLessonId,
                PreviousLessonId = lessonDto.PreviousLessonId,
                CourseId = lessonDto.CourseId
            };
        }

        public static Lesson ToLessonFromCreateLessonDto(this CreateLessonDto lessonDto, int courseId)
        {
            return new Lesson 
            {
                Title = lessonDto.Title,
                Description = lessonDto.Description,
                NextLessonId = lessonDto.NextLessonId,
                PreviousLessonId = lessonDto.PreviousLessonId,
                CourseId = courseId
            };
        }

        public static Lesson ToLessonFromUpdateLessonDto(this UpdateLessonDto lessonDto)
        {
            return new Lesson 
            {
                Title = lessonDto.Title,
                Description = lessonDto.Description,
                NextLessonId = lessonDto.NextLessonId,
                PreviousLessonId = lessonDto.PreviousLessonId,
                CourseId = lessonDto.CourseId
            };
        }
    }
}