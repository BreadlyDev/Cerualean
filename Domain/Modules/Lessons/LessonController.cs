using Cerualean.Domain.Common.Exceptions;
using Cerualean.Domain.Modules.Lessons.Dtos;
using Cerualean.Domain.Modules.Lessons.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cerualean.Domain.Modules.Lessons
{
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("{courseId:int}/lesson/list")]
        public async Task<IActionResult> GetListByCategory([FromRoute] int courseId)
        {
            try
            {
                return Ok(await _lessonService.GetLessonListByCourse(courseId));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, ExceptionMessages.InternalServerError);
            }
        }

        [HttpGet]
        [Route("lesson/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _lessonService.GetLessonById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, ExceptionMessages.InternalServerError);
            }
        }

        [HttpPost]
        [Route("{courseId:int}/create/")]
        public async Task<IActionResult> Create(
            [FromRoute] int categoryId,
            [FromBody] CreateLessonDto LessonDto
        )
        {
            try
            {
                var LessonModel = _lessonService.CreateLesson(categoryId, LessonDto);
                return CreatedAtAction(nameof(GetById), new { id = LessonModel.Id }, LessonModel);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, ExceptionMessages.InternalServerError);
            }
        }

        [HttpPut, HttpPatch]
        [Route("lesson/{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateLessonDto LessonDto
        )
        {
            try
            {
                return Ok(await _lessonService.UpdateLesson(id, LessonDto));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, ExceptionMessages.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("lesson/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try 
            {
                return Ok(await _lessonService.DeleteLesson(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, ExceptionMessages.InternalServerError);
            }
        }
    }
}