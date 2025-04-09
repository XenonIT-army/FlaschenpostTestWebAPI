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

        public Task<TodoItem> AddAsync(TodoItem dto)
        {
            return Task.Run(() =>
            {
                var entity = mapper.Map<TodoItemDB>(dto);

                var item = _todoItemRep.AddAsync(entity);

                return mapper.Map<TodoItem>(item);
            });
        }

        public Task Delete(TodoItem dto)
        {
            return Task.Run(() =>
            {
                var entity = _todoItemRep.GetByIdAsync(dto.Id);
                _todoItemRep.Delete(entity);
                return true;
            });
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                var res = _todoItemRep
               .GetAllAsync()
               .Select(entity => mapper.Map<TodoItem>(entity));
                return res;
            });
        }

        public Task<TodoItem> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                var entity = _todoItemRep.GetByIdAsync(id);
                return mapper.Map<TodoItem>(entity);
            });
        }

        public Task<int> GetNextId(Func<TodoItem, int> keySelector)
        {
            return Task.Run(() =>
            {
                var entity = _todoItemRep.GetNextId(p => p.Id);
                return mapper.Map<int>(entity);
            });
        }

        public Task Update(TodoItem dto)
        {
            return Task.Run(() =>
            {
                var entity = mapper.Map<TodoItemDB>(dto);
                _todoItemRep.Update(entity);
                return true;
            });
        }

        public Task<bool> Save()
        {
            return Task.Run(() =>
            {
                _todoItemRep.Save();
                return true;
            });
        }
    }
}
