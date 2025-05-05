using AutoMapper;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;

namespace FlaschenpostTestWebAPI.Services
{
    public class TodoItemService : IService<TodoItem>
    {
        private IRepository<TodoItemDB> _todoItemRep;
        IMapper mapper;


        public TodoItemService(IRepository<TodoItemDB> todoItemRep)
        {
            _todoItemRep = todoItemRep;
            var config = new MapperConfiguration(cfg =>
            cfg
            .CreateMap<TodoItemDB, TodoItem>().ReverseMap());
            mapper = config.CreateMapper();
        }

        public Task<TodoItem> Add(TodoItem dto)
        {
                var entity = mapper.Map<TodoItemDB>(dto);
                var item = _todoItemRep.Add(entity);
                return Task.FromResult<TodoItem>(mapper.Map<TodoItem>(item));
        }

        public Task<bool> Delete(TodoItem dto)
        {
                var entity = _todoItemRep.GetById(dto.Id);
                _todoItemRep.Delete(entity);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<TodoItem>> GetAll()
        {
           
                var res = _todoItemRep
               .GetAll()
               .Select(entity => mapper.Map<TodoItem>(entity));
                return Task.FromResult<IEnumerable<TodoItem>>(res);
        }

        public Task<TodoItem> GetById(int id)
        {
                var entity = _todoItemRep.GetById(id);
            return Task.FromResult(mapper.Map<TodoItem>(entity));
        }

        public Task<bool> Update(TodoItem dto)
        {
                var entity = mapper.Map<TodoItemDB>(dto);
                _todoItemRep.Update(entity);
            return Task.FromResult(true);
        }

        public Task<bool> Save()
        {
                _todoItemRep.Save();
            return Task.FromResult(true);
        }
    }
}
