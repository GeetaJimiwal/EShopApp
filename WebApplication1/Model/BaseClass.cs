namespace WebApplication1.Model
{
    public class BaseClass
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }  
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
