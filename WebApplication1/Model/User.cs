namespace WebApplication1.Model
{
    public class User
    {
       public int Id { get; set; }
       public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public  int? UpdatedBy { get; set; }
    }
}
