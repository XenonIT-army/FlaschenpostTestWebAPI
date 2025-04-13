﻿namespace FlaschenpostTestWebAPI.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public string Icon { get; set; } = string.Empty;
    }
}
