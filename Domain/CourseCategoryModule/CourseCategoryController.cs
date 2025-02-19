using Cerualean.Domain.CourseCategoryModule.Dtos;
using Cerualean.Domain.CourseCategoryModule.Helpers;
using Cerualean.Domain.CourseCategoryModule.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cerualean.Domain.CourseCategoryModule
{
    [Route("/course/category/")]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryRepository _categoryRepo;
        public CourseCategoryController(ICourseCategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetList()
        {
            var categoryModelList = await _categoryRepo.GetCourseCategoryList();
            
            categoryModelList.ForEach(category => 
            CourseCategoryMappers.ToCourseCategoryDto(category));
            
            return Ok(categoryModelList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var categoryModel = await _categoryRepo.GetCourseCategoryById(id);

            if (categoryModel == null)
            {
                return NotFound(CourseCategoryErrors.CourseCategoryWasNotFound);
            }

            return Ok(CourseCategoryMappers.ToCourseCategoryDto(categoryModel));
        }

        [HttpPost]
        [Route("create/")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCourseCategoryDto categoryDto)
        {
            var categoryModel = await _categoryRepo.CreateCourseCategory(
                CourseCategoryMappers.ToCourseCategoryFromCreateDto(categoryDto)
            );
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateCourseCategoryDto categoryDto)
        {
            var categoryModel = await _categoryRepo.UpdateCourseCategory(id,
            CourseCategoryMappers.ToCourseCategoryFromUpdateDto(categoryDto));

            if (categoryModel == null)
            {
                return NotFound(CourseCategoryErrors.CourseCategoryWasNotFound);
            }

            return Ok(categoryModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var categoryModel = await _categoryRepo.DeleteCourseCategory(id);

            if (categoryModel == null)
            {
                return NotFound(CourseCategoryErrors.CourseCategoryWasNotFound);
            }

            return Ok(categoryModel);
        }
    }
}