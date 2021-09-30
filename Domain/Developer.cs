using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
    }
}