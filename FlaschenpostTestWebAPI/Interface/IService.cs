namespace FlaschenpostTestWebAPI.Interface
{
    public interface IService<TEntityDto>
    {
        Task<TEntityDto> GetById(int id);
        Task<IEnumerable<TEntityDto>> GetAll();
        Task<TEntityDto> Add(TEntityDto dto);
        Task<bool> Update(TEntityDto dto);
        Task<bool> Delete(TEntityDto dto);
        //public Task<int> GetNextId(Func<TEntityDto, int> keySelector);
        Task<bool> Save();
    }
}
