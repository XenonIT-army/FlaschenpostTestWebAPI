using AutoMapper;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using System.Collections.Generic;

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

        public Task<Category> Add(Category dto)
        {
            var entity = mapper.Map<CategoryDB>(dto);

            var item = _categoryRep.Add(entity);
            return Task.FromResult<Category>(mapper.Map<Category>(item));
        }

        public Task<bool> Delete(Category dto)
        {
            var entity = _categoryRep.GetById(dto.Id);
            _categoryRep.Delete(entity);
            return Task.FromResult(true); 
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            var res = _categoryRep
               .GetAll()
               .Select(entity => mapper.Map<Category>(entity));
            return Task.FromResult<IEnumerable<Category>>(res);
        }

        public Task<Category> GetById(int id)
        {
            var entity = _categoryRep.GetById(id);
            return Task.FromResult<Category>(mapper.Map<Category>(entity));
        }

        public Task<bool> Update(Category dto)
        {
            var entity = mapper.Map<CategoryDB>(dto);
            _categoryRep.Update(entity);
            return Task.FromResult(true);

        }

        public Task<bool> Save()
        {
            var res = _categoryRep.Save();
            return Task.FromResult(res);
        }
    }
}
