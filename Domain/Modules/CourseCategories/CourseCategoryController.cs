using Cerualean.Domain.Common.Exceptions;
using Cerualean.Domain.Modules.CourseCategories.Dtos;
using Cerualean.Domain.Modules.CourseCategories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cerualean.Domain.Modules.CourseCategories
{
    [Route("/course/category/")]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryService _categoryService;
        public CourseCategoryController(ICourseCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetList()
        {
            try 
            {
                return Ok(await _categoryService.GetCourseCategoryList());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _categoryService.GetCourseCategoryById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("create/")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCourseCategoryDto categoryDto
        )
        {
            var categoryModel = await _categoryService.CreateCourseCategory(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel);
        }

        [HttpPut, HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateCourseCategoryDto categoryDto
        )
        {
            try
            {
                return Ok(await _categoryService.UpdateCourseCategory(id, categoryDto));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                return Ok(await _categoryService.DeleteCourseCategory(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}