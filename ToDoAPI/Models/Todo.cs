namespace ToDoAPI.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemovedDate { get; set; }

    }
}
