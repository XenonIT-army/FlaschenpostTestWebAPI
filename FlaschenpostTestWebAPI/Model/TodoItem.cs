namespace FlaschenpostTestWebAPI.Model
{
    public class TodoItem
    {
        public int Id { get; private set; }                        
        public string Title { get; set; }                   
        public string Description { get; set; }          
        public bool IsCompleted { get; set; }               
        public DateTime CreatedAt { get; set; }             
        public DateTime? DueDate { get; set; }            
        public DateTime? CompletedAt { get; set; }        
        public Priority Priority { get; set; }
        public int CategoryId { get; set; }
    }

    public enum Priority
    {
        None = 0,
        Low = 1, 
        Medium = 2, 
        High = 3
    }
}
