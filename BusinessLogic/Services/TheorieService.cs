using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.Theorie;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;

namespace BusinessLogic.Services;

internal class TheorieService(ITheorieRepository theorieRepository) : ITheorieService
{
	public async Task AddAsync(CreateTheorieDto theorie, CancellationToken cancellationToken = default)
	{
		await theorieRepository.AddAsync(theorie.ToTheorieFromCreateTheorieDto(), cancellationToken);
	}

	public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		await theorieRepository.DeleteByIdAsync(id, cancellationToken);
	}

	public async Task<TheorieDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		var theorie = await theorieRepository.GetByIdAsync(id, cancellationToken);

		if (theorie == null)
		{
			return null;
		}

		return theorie.ToTheorieDto();
	}

	public async Task<TheorieDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
	{
		var theorie = await theorieRepository.GetByTitleAsync(title, cancellationToken);

		if (theorie == null)
		{
			return null;
		}

		return theorie.ToTheorieDto();
	}

	public async Task<ICollection<TheorieDto>> GetListByPageAndLessonAsync(int lessonId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		var theorieList = await theorieRepository.GetListByPageAndLessonAsync(lessonId, page, pageSize, cancellationToken);
		var theorieDtoList = theorieList.Select(p => p.ToTheorieDto()).ToList();
		return theorieDtoList;
	}

	public async Task<ICollection<TheorieDto>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
	{
		var theorieList = await theorieRepository.GetListByPageAsync(page, pageSize, cancellationToken);
		var theorieDtoList = theorieList.Select(p => p.ToTheorieDto()).ToList();
		return theorieDtoList;
	}

	public async Task UpdateByIdAsync(int id, UpdateTheorieDto newTheorie, CancellationToken cancellationToken = default)
	{
		await theorieRepository.UpdateByIdAsync(id, newTheorie.ToTheorieFromUpdateTheorieDto(), cancellationToken);
	}
}

