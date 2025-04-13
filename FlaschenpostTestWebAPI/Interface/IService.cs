namespace FlaschenpostTestWebAPI.Interface
{
    public interface IService<TEntityDto>
    {
        Task<TEntityDto> GetByIdAsync(int id);
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<TEntityDto> AddAsync(TEntityDto dto);
        Task Update(TEntityDto dto);
        Task Delete(TEntityDto dto);
        //public Task<int> GetNextId(Func<TEntityDto, int> keySelector);
        Task<bool> Save();
    }
}
