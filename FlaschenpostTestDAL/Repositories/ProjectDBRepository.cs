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
    public class ProjectDBRepository : BaseRepository<ProjectDB>
    {
        public ProjectDBRepository(DbContext db) : base(db)
        {
        }
    }
}
