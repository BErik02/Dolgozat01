namespace Sportolo13A.Models.DTOs
{
    public class UpdateErdemenyDTO
    {
        public string Competition { get; set; }
        public string Description { get; set; }
        public DateTime Resulttime = DateTime.Now;
        public DateTime UpdateTime =DateTime.Now;
        public int id { get; set; }
    }
}
