using FlaschenpostTestDAL.Context;
using FlaschenpostTestDAL.Entities;
using FlaschenpostTestDAL.Interface;
using FlaschenpostTestDAL.Repositories;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestxUnit.Item
{
    public static class StaticItem
    {
        public static TodoItem TodoItem { get; set; } = new TodoItem() { Title = "Test unit todoItem", Description = "Test description item", 
            CategoryId = 1, CreatedAt = DateTime.UtcNow, IsCompleted = false, Priority = Priority.Low  };

        public static Category Category { get; set; } = new Category() { Title = "Test unit category", Description = "Test description category" };
    }
}
