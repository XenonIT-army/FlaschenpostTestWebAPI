using AutoMapper;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;

namespace FlaschenpostTestWebAPI.Services
{
    public class ProjectService : IService<Project>
    {
        private IRepository<ProjectDB> _categoryRep;
        IMapper mapper;


        public ProjectService(IRepository<ProjectDB> categoryRep)
        {
            _categoryRep = categoryRep;
            var config = new MapperConfiguration(cfg =>
            cfg
            .CreateMap<ProjectDB, Project>().ReverseMap());
            mapper = config.CreateMapper();
        }

        public Task<Project> AddAsync(Project dto)
        {
            return Task.Run(() =>
            {
                var entity = mapper.Map<ProjectDB>(dto);

                var item = _categoryRep.AddAsync(entity);

                return mapper.Map<Project>(item);
            });
        }

        public Task Delete(Project dto)
        {
            return Task.Run(() =>
            {
                var entity = _categoryRep.GetByIdAsync(dto.Id);
                _categoryRep.Delete(entity);
                return true;
            });
        }

        public Task<IEnumerable<Project>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                var res = _categoryRep
               .GetAllAsync()
               .Select(entity => mapper.Map<Project>(entity));
                return res;
            });
        }

        public Task<Project> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                var entity = _categoryRep.GetByIdAsync(id);
                return mapper.Map<Project>(entity);
            });
        }

        public Task Update(Project dto)
        {
            return Task.Run(() =>
            {
                var entity = mapper.Map<ProjectDB>(dto);
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
