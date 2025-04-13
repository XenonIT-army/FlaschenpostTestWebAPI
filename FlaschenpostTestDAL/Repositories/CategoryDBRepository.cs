using FlaschenpostTestDAL.Abstructions;
using FlaschenpostTestDAL.Data;
using FlaschenpostTestDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Repositories
{
    public class CategoryDBRepository : BaseRepository<CategoryDB>
    {
        public CategoryDBRepository(DbContext db) : base(db)
        {
        }
    }
}
