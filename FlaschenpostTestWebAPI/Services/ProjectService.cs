using AutoMapper;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;

namespace FlaschenpostTestWebAPI.Services
{
    public class ProjectService : IService<Project>
    {
        private IRepository<ProjectDB> _projectRep;
        IMapper mapper;


        public ProjectService(IRepository<ProjectDB> categoryRep)
        {
            _projectRep = categoryRep;
            var config = new MapperConfiguration(cfg =>
            cfg
            .CreateMap<ProjectDB, Project>().ReverseMap());
            mapper = config.CreateMapper();
        }

        public Task<Project> Add(Project dto)
        {
            var entity = mapper.Map<ProjectDB>(dto);

            var item = _projectRep.Add(entity);
            return Task.FromResult<Project>(mapper.Map<Project>(item));
        }

        public Task<bool> Delete(Project dto)
        {
            var entity = _projectRep.GetById(dto.Id);
            _projectRep.Delete(entity);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Project>> GetAll()
        {
            var res = _projectRep
               .GetAll()
               .Select(entity => mapper.Map<Project>(entity));
            return Task.FromResult<IEnumerable<Project>>(res);
        }

        public Task<Project> GetById(int id)
        {
            var entity = _projectRep.GetById(id);
            return Task.FromResult<Project>(mapper.Map<Project>(entity));
        }

        public Task<bool> Update(Project dto)
        {
            var entity = mapper.Map<ProjectDB>(dto);
            _projectRep.Update(entity);
            return Task.FromResult(true);
        }

        public Task<bool> Save()
        {
            var res = _projectRep.Save();
            return Task.FromResult(res);
        }
    }
}
