using FlaschenpostTestDAL.Abstructions;
using FlaschenpostTestDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Repositories
{
    public class TodoItemDBRepository : BaseRepository<TodoItemDB>
    {
        public TodoItemDBRepository(DbContext db) : base(db)
        {
        }
    }
}
