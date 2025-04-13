using FlaschenpostTestDAL.Context;
using FlaschenpostTestDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Data
{
    public static class Constants
    {
        public static List<ProjectDB> Projects = new List<ProjectDB>
        {
            new ProjectDB
            {
                Id = 1,
                Title = "Balance",
                Description = "Improve work-life balance.",
                CategoryId = 1,
                Icon = "\uea28"
            },
            new ProjectDB
            {
                Id = 2,
                Title = "Personal",
                Description = "Learn to speak another language.",
                CategoryId = 2,
                Icon = "\uf8fe"
            },
             new ProjectDB
            {
                Id = 3,
                Title = "Fitness",
                Description = "Promote health and fitness activities",
                CategoryId = 3,
                Icon = "\uf837"
            },
              new ProjectDB
            {
                Id = 4,
                Title = "Family and Friends",
                Description = "Strengthen relationships with family and friends.",
                CategoryId = 4,
                Icon = "\uf5a9"
            }
        };
        public static List<CategoryDB> Categories = new List<CategoryDB>
        {
            new CategoryDB
            {
                Id = 1,
                Title = "work",
                Description = "Description 1",
                 Color = "Green"
            },
            new CategoryDB
            {
                Id = 2,
                Title = "education",
                Description = "Description 2",
                Color = "Blue"
            },
              new CategoryDB
            {
                Id = 3,
                Title = "self",
                Description = "Description 3",
                Color = "Yellow"
            },
                new CategoryDB
            {
                Id = 4,
                Title = "relationships",
                Description = "Description 4",
                Color = "Grey"
            }
        };
       
public static List<TodoItemDB> TodoItems = new List<TodoItemDB>
        {
            new TodoItemDB
            {
                Id = 1,
                Title = "Survey Employees",
                Description = "Description 1",
                ProjectId = 1,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = null,
            },
            new TodoItemDB
            {
                Id = 2,
                Title = "Analyze Survey Results",
                Description = "Description 2",
                ProjectId = 1,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = null,
            },
            new TodoItemDB
            {
                Id = 3,
                Title = "Develop Action Plan",
                Description = "Description 3",
                ProjectId = 1,
                IsCompleted = true,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = DateTime.Now,
            },
            new TodoItemDB
            {
                Id = 4,
                Title = "Read a Book",
                Description = "Description 2",
                ProjectId = 2,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = null,
            },
            new TodoItemDB
            {
                Id = 5,
                Title = "Attend a Workshop",
                Description = "Description 2",
                ProjectId = 2,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = null,
            },
            new TodoItemDB
            {
                Id = 6,
                Title = "Practice a Hobby",
                Description = "Description 2",
                ProjectId = 2,
                IsCompleted = true,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = DateTime.Now,
            },
            new TodoItemDB
            {
                Id = 7,
                Title = "Morning Yoga",
                Description = "Description 2",
                ProjectId = 3,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = null,
            },
            new TodoItemDB
            {
                Id = 8,
                Title = "Evening Run",
                Description = "Description 2",
                ProjectId = 3,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = null,
            },
            new TodoItemDB
            {
                Id = 9,
                Title = "Healthy Cooking Class",
                Description = "Description 2",
                ProjectId = 3,
                IsCompleted = true,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = DateTime.Now,
            },
            new TodoItemDB
            {
                Id = 10,
                Title = "Plan a Family Reunion",
                Description = "Description 2",
                ProjectId = 4,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = null,
            },
            new TodoItemDB
            {
                Id = 11,
                Title = "Organize a Friends",
                Description = "Description 2",
                ProjectId = 4,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = null,
            },
            new TodoItemDB
            {
                Id = 12,
                Title = "Weekly Phone Calls",
                Description = "Description 2",
                ProjectId = 4,
                IsCompleted = true,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                CompletedAt = DateTime.Now,
            }
        };

    }
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Project.Any())
            {
                context.Project.AddRange(Constants.Projects);
            }
            if (!context.TodoItem.Any())
            {
                context.TodoItem.AddRange(Constants.TodoItems);
            }
            if (!context.Category.Any())
            {
                context.Category.AddRange(Constants.Categories);
            }
            context.SaveChanges();
        }
    }
}
