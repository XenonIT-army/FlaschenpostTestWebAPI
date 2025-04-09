using AutoMapper;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;

namespace FlaschenpostTestWebAPI.Services
{
    public class CategoryService : IService<Category>
    {
        private IRepository<CategoryDB> _categoryRep;
        IMapper mapper;


        public CategoryService(IRepository<CategoryDB> categoryRep)
        {
            _categoryRep = categoryRep;
            var config = new MapperConfiguration(cfg =>
            cfg
            .CreateMap<CategoryDB, Category>().ReverseMap());
            mapper = config.CreateMapper();
        }

        public Task<Category> AddAsync(Category dto)
        {
            return Task.Run(() =>
            {
                var entity = mapper.Map<CategoryDB>(dto);

                var item = _categoryRep.AddAsync(entity);

                return mapper.Map<Category>(item);
            });
        }

        public Task Delete(Category dto)
        {
            return Task.Run(() =>
            {
                var entity = _categoryRep.GetByIdAsync(dto.Id);
                _categoryRep.Delete(entity);
                return true;
            });
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                var res = _categoryRep
               .GetAllAsync()
               .Select(entity => mapper.Map<Category>(entity));
                return res;
            });
        }

        public Task<Category> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                var entity = _categoryRep.GetByIdAsync(id);
                return mapper.Map<Category>(entity);
            });
        }

        public Task<int> GetNextId(Func<Category, int> keySelector)
        {
            return Task.Run(() =>
            {
                var entity = _categoryRep.GetNextId(p => p.Id);
                return mapper.Map<int>(entity);
            });
        }

        public Task Update(Category dto)
        {
            return Task.Run(() =>
            {
                var entity = mapper.Map<CategoryDB>(dto);
                _categoryRep.Update(entity);
                return true;
            });
        }

        public Task<bool> Save()
        {
            return Task.Run(() =>
            {
                var res = _categoryRep.Save();
                return res;
            });
        }
    }
}
